using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using IRECE;

namespace IRECEServer.Model
{
    public class Client
    {
        public Socket Socket { get; set; }

        public string Username { get; set; }

        public User User { get; set; }

        public List<Channel> Channels { get; set; }

        public static List<Client> Clients { get; set; }

        public Client(Socket s)
        {
            Socket = s;
        }

        public void Run()
        {
            byte[] b = new byte[2048];
            int k;
            try
            {
                Channel current;
                while ((k = Socket.Receive(b)) != 0)
                {
                    string message = Encoding.UTF8.GetString(b, 0, k);
                    IRECEMessage mes = IRECEMessage.Deserialize(message);
                    if (null == mes.Channel)
                    {
                        Channel.SystemChannel.SendError(this, "No channel given.");
                    }
                    else
                    {
                        current = Channel.GetByName(mes.Channel);
                        if (null == current)
                        {
                            Channel.SystemChannel.SendError(this, "Unknown channel.");
                        }
                        else
                        {
                            current.Manage(this, mes);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Channel.SystemChannel.Disconnect(this);
            }
        }
    }
}
