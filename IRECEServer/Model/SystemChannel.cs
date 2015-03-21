using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRECE;

namespace IRECEServer.Model
{
    public class SystemChannel : Channel
    {
        public new string Type { get { return Channel.SYSTEM_CH_SYSTEM; } }

        public override void Manage(Client c, IRECEMessage m)
        {
            switch (m.Command)
            {
                case "user":
                    connectUser(c, m.Text);
                    break;
                case "pass":
                    connectUser(c, m.Text);
                    break;
                default:
                    // TODO Do things
                    break;
            }
        }

        private bool connectUser(Client c, string username)
        {
            foreach (Client cli in Client.Clients)
            {
                if (cli.User != null && cli.User.Username == username)
                {
                    SendError(c, "Le nom d'utilisateur demandé est déjà connecté.");
                    return false;
                }
            }
            c.Username = username;
            return true;
        }

        public void SendError(Client c, string text)
        {
            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.ERROR, text);
        }
    }
}
