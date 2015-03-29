using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRECEServer.Model;
using IRECE;

namespace IRECE
{
    public class Channel : IRECEChannel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Client> Clients { get; set; }

        public static SystemChannel SystemChannel { get; set; }
        public static List<Channel> Channels { get; set; }

        public static Channel GetByName(string name)
        {
            foreach (Channel channel in Channel.Channels)
            {
                if (channel.Name == name)
                {
                    return channel;
                }
            }
            return null;
        }

        public static Channel GetSystemChannel()
        {
            return SystemChannel;
        }

        public virtual void Manage(Client c, IRECEMessage m)
        {
            if (m.Command == IRECEMessage.JOIN)
            {
                JoinChannel(c);
                return;
            }
            if (m.Command == IRECEMessage.LEAVE)
            {
                LeaveChannel(c);
                return;
            }
            UTF8Encoding utf8 = new UTF8Encoding();
            foreach (Client cli in Clients)
            {
                SendMessage(cli, m);
            }
        }

        protected void SendACK(Client c)
        {
            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.ACK, "");
        }

        public void SendMessage(Client c, Channel channel, String command, String text, String user = null)
        {
            SendMessage(c, channel.Name, command, text, user);
        }
        public void SendMessage(Client c, String channel, String command, String text, String user = null)
        {
            IRECEMessage message = new IRECEMessage();
            message.Channel = channel;
            message.Command = command;
            message.Text = text;
            message.User = user;
            SendMessage(c, message);
        }
        public void SendMessage(Client c, IRECEMessage message)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            try
            {
                Console.WriteLine(message);
                c.Socket.Send(utf8.GetBytes(message.ToString()));
            }
            catch (Exception e)
            {
                // Socket is closed during the transmission
                Console.WriteLine(e.ToString());
            }
        }

        public static List<Channel> GetPublicChannels()
        {
            List<Channel> channels = new List<Channel>();
            foreach (Channel chan in Channel.Channels)
            {
                if (chan.Type == IRECEChannel.TYPE_PUBLIC)
                {
                    channels.Add(chan);
                }
            }
            return channels;
        }

        public void JoinChannel(Client c)
        {
            Clients.Add(c);
            c.Channels.Add(this);
            string userText = "User " + c.User.Username;
            userText += " joined the channel.";
            foreach (Client cli in Clients)
            {
                if (cli == c)
                {
                    continue;
                }
                SendMessage(cli, this, IRECEMessage.USER_JOIN, userText, c.User.Username);
            }
        }

        public void LeaveChannel(Client c, string type = "normal")
        {
            string userText = "User " + c.User.Username;
            if (type == "normal")
            {
                userText += " disconnected.";
            }
            else if (type == "timeout")
            {
                userText += " timed out.";
            }
            else
            {
                userText += " disconnected (error).";
            }
            foreach (Client cli in Clients)
            {
                if (cli == c)
                {
                    continue;
                }
                SendMessage(cli, this, IRECEMessage.USER_DISCONNECT, userText, c.User.Username);
            }
            Clients.Remove(c);
            c.Channels.Remove(this);
        }
    }
}
