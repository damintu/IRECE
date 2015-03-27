using System;
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
        public List<string> Channels;
        private Dictionary<string, bool> updatedUsers = new Dictionary<string, bool>();
        public Dictionary<string, List<string>> UsersByChannel = new Dictionary<string, List<string>>();

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
            byte[] bb = new byte[1024];
            int k = stm.Read(bb, 0, 1024);

            StringBuilder sb =  new StringBuilder();

            for (int i = 0; i < k; i++)
            {
                sb.Append((Convert.ToChar(bb[i])));
                Console.Write((Convert.ToChar(bb[i])));
            }
            return IRECEMessage.Deserialize(sb.ToString());
        }

        public void Receive()
        {
            IRECEMessage message;
            while (true)
            {
                message = getMessage();
                if (message.Channel == IRECEChannel.SYSTEM_CH_SYSTEM)
                {
                    switch (message.Command)
                    {
                        case IRECEMessage.CHANNELS_RESPONSE:
                            UpdateChannels(message);
                            break;
                        case IRECEMessage.USERLIST_RESPONSE:
                            UpdateUsers(message);
                            break;
                    }
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
    }
}
