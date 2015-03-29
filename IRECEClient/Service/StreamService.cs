﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IRECE;
using System.Net.Sockets;
using System.Threading;

namespace IRECEClient.Service
{
    class StreamService
    {
        private bool updatedChannels = false;
        public string User;
        public List<string> Channels;
        public Dictionary<string, string> PrivateRooms = new Dictionary<string, string>();
        private Dictionary<string, bool> updatedUsers = new Dictionary<string, bool>();
        public Dictionary<string, List<string>> UsersByChannel = new Dictionary<string, List<string>>();
        public Dictionary<string, List<IRECEMessage>> MessagesByChannel = new Dictionary<string, List<IRECEMessage>>();

        public bool Connected
        {
            get;
            set;
        }

        private static StreamService instance;

        private StreamService() { }

        public static StreamService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StreamService();
                    instance.Connected = false;
                }
                return instance;
            }
        }

        private Stream stm;

        public Stream Stm
        {
          get { return stm; }
          set { stm = value; }
        }

        public void SendMessage(IRECEMessage message)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            this.Stm.Write(utf8.GetBytes(message.ToString()), 0, utf8.GetBytes(message.ToString()).Length);
        }

        public IRECEMessage getMessage()
        {
            byte[] bb = new byte[200000];
            int k = stm.Read(bb, 0, 200000);

            StringBuilder sb =  new StringBuilder();

            for (int i = 0; i < k; i++)
            {
                sb.Append((Convert.ToChar(bb[i])));
            }
            return IRECEMessage.Deserialize(sb.ToString());
        }

        public void Receive()
        {
            IRECEMessage message;
            while (true)
            {
                message = getMessage();
                switch (message.Command)
                {
                    case IRECEMessage.CHANNELS_RESPONSE:
                        UpdateChannels(message);
                        break;
                    case IRECEMessage.USERLIST_RESPONSE:
                        UpdateUsers(message);
                        break;
                    case IRECEMessage.OPEN_ROOM:
                        OpenRoom(message);
                        break;
                    case IRECEMessage.MESSAGE:
                    case IRECEMessage.USER_DISCONNECT:
                    case IRECEMessage.USER_JOIN:
                    case IRECEMessage.IMAGE:
                        ManageTextMessage(message);
                        break;
                }
            }
        }

        public bool InitiateConnection(string ip, string port)
        {
            return InitiateConnection(ip, Convert.ToInt32(port));
        }

        public bool InitiateConnection(string ip, int port)
        {
            TcpClient tcpclnt = new TcpClient();
            try
            {
                tcpclnt.Connect(ip, port);
                Connected = true;
                stm = tcpclnt.GetStream();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ConnectUser(string username, string password)
        {
            if (!Connected)
            {
                return false;
            }
            IRECEMessage message = new IRECEMessage();
            IRECEMessage response;

            message.Command = IRECE.IRECEMessage.USER;
            message.Text = username;
            message.Channel = IRECEChannel.SYSTEM_CH_SYSTEM;
            SendMessage(message);
            response = getMessage();
            if (response.Command != IRECEMessage.PASSWORD_REQUEST)
            {
                return false;
            }
            message.Command = IRECEMessage.PASSWORD;
            message.Text = password;
            SendMessage(message);
            response = getMessage();
            if (response.Command != IRECEMessage.ACK)
            {
                return false;
            }
            Thread receptionThread = new Thread(Receive);
            receptionThread.IsBackground = true;
            receptionThread.Start();
            User = username;
            return true;
        }

        public List<string> GetChannels()
        {
            if (!Connected)
            {
                return null;
            }
            updatedChannels = false;
            IRECEMessage message = new IRECEMessage();
            message.Command = IRECEMessage.CHANNELS_REQUEST;
            message.Channel = IRECEChannel.SYSTEM_CH_SYSTEM;
            message.User = User;
            message.Text = "";
            SendMessage(message);
            while (updatedChannels == false)
            {
                continue;
            }
            return Channels;
        }

        private void UpdateChannels(IRECEMessage channelsResponse)
        {
            if (null == Channels)
            {
                Channels = new List<string>();
            }
            else
            {
                Channels.Clear();
            }

            string[] subStrings = channelsResponse.Text.Split(';');

            foreach (string st in subStrings)
            {
                Channels.Add(st);
            }
            updatedChannels = true;
        }

        public List<string> GetUsers(string channel)
        {
            if (!Connected)
            {
                return null;
            }
            updatedUsers[channel] = false;
            IRECEMessage message = new IRECEMessage();
            message.Command = IRECEMessage.USERLIST_REQUEST;
            message.User = User;
            message.Channel = IRECEChannel.SYSTEM_CH_SYSTEM;
            message.Text = channel;
            SendMessage(message);
            while (updatedUsers[channel] == false)
            {
                continue;
            }
            return UsersByChannel[channel];
        }


        private void UpdateUsers(IRECEMessage usersResponse)
        {
            string[] subStrings = usersResponse.Text.Split(':');
            string channel = subStrings[0];
            if (!UsersByChannel.ContainsKey(channel) || null == UsersByChannel[channel])
            {
                UsersByChannel[channel] = new List<string>();
            }
            else
            {
                UsersByChannel[channel].Clear();
            }

            subStrings = subStrings[1].Split(';');
            foreach (string st in subStrings)
            {
                UsersByChannel[channel].Add(st);
            }
            updatedUsers[channel] = true;
        }

        public void SendMessageToChannel(string text, string channel)
        {
            IRECEMessage message = new IRECEMessage();
            message.Channel = channel;
            message.Command = IRECEMessage.MESSAGE;
            message.User = User;
            message.Text = text;
            SendMessage(message);
            return;
        }

        public void SendImageToChannel(string text, string channel)
        {
            IRECEMessage message = new IRECEMessage();
            message.Channel = channel;
            message.Command = IRECEMessage.IMAGE;
            message.User = User;
            message.Text = text;
            SendMessage(message);
            return;
        }

        private void ManageTextMessage(IRECEMessage message)
        {
            if (!MessagesByChannel.ContainsKey(message.Channel))
            {
                MessagesByChannel[message.Channel] = new List<IRECEMessage>();
            }
            MessagesByChannel[message.Channel].Add(message);
        }

        public bool JoinChannel(string channel)
        {
            if (!Connected)
            {
                return false;
            }
            IRECEMessage message = new IRECEMessage();
            message.Command = IRECEMessage.JOIN;
            message.User = User;
            message.Channel = channel;
            message.Text = "";
            SendMessage(message);
            return true;
        }

        public bool JoinPrivateChannel(string user)
        {
            if (!Connected)
            {
                return false;
            }
            IRECEMessage message = new IRECEMessage();
            message.Command = IRECEMessage.JOIN_PRIVATE;
            message.User = User;
            message.Channel = IRECEChannel.SYSTEM_CH_SYSTEM;
            message.Text = user;
            SendMessage(message);
            return true;
        }

        public bool LeaveChannel(string channel)
        {
            if (!Connected)
            {
                return false;
            }
            IRECEMessage message = new IRECEMessage();
            message.Command = IRECEMessage.LEAVE;
            message.User = User;
            message.Channel = channel;
            message.Text = "";
            SendMessage(message);
            return true;
        }

        public void OpenRoom(IRECEMessage message)
        {
            if (!PrivateRooms.ContainsKey(message.Text))
            {
                PrivateRooms[message.Text] =  message.Channel;
            }
        }
    }
}
