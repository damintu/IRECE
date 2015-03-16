using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRECE;

namespace IRECEServer.Model
{
    class SystemChannel : Channel
    {
        public new string Name { get { return Channel.SYSTEM_CH_SYSTEM; } }
        public new string Type { get { return Channel.SYSTEM_CH_SYSTEM; } }

        public void Manage(Client c, IRECEMessage m)
        {
            Channel ch = Channel.GetByName(m.Channel);
            if (null == ch)
            {
                // TODO Send error to client;
            }

            switch (m.Command)
            {
                case IRECEMessage.CONNECT:
                    connectClient(c, ch);
                    break;
                default:
                    // TODO Do things
                    break;
            }
        }

        private void connectClient(Client c, Channel ch)
        {

        }
    }
}
