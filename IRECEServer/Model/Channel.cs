using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRECE;

namespace IRECEServer.Model
{
    class Channel
    {
        public const string SYSTEM_CH_MAIN = "main";
        public const string SYSTEM_CH_SYSTEM = "system";

        public const string TYPE_PUBLIC = "public";

        public string Name { get; set; }
        public string Type { get; set; }
        public List<Client> Clients { get; set; }

        public static List<Channel> Channels { get; set; }

        public static Channel GetByName(string name)
        {
            foreach (Channel channel in Channel.Channels) {
                if (channel.Name == name)
                {
                    return channel;
                }
            }
            return null;
        }

        public void Send(IRECEMessage m)
        {
            Console.WriteLine(m.ToString());
        }
    }
}
