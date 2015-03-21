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
            SendACK(c);
            UTF8Encoding utf8 = new UTF8Encoding();
            foreach (Client cli in Clients)
            {
                cli.Socket.Send(utf8.GetBytes(m.ToString()));
            }
        }

        protected void SendACK(Client c)
        {
            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.ACK, "");
        }

        public void SendMessage(Client c, Channel channel, String command, String text)
        {
            SendMessage(c, channel.Name, command, text);
        }
        public void SendMessage(Client c, String channel, String command, String text)
        {
            IRECEMessage message = new IRECEMessage();
            message.Channel = channel;
            message.Command = command;
            message.Text = text;
            UTF8Encoding utf8 = new UTF8Encoding();
            c.Socket.Send(utf8.GetBytes(message.ToString()));
        }
    }
}
