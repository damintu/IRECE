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
                case IRECEMessage.USER:
                    connectUser(c, m.Text);
                    break;
                case IRECEMessage.PASSWORD:
                    connectUserWithPassword(c, m.Text);
                    break;
                default:
                    SendError(c, "Unknown command.");
                    break;
            }
        }

        private bool connectUser(Client c, string username)
        {
            foreach (Client cli in Client.Clients)
            {
                if (cli.User != null && cli.User.Username == username)
                {
                    SendError(c, "Username already exists.");
                    return false;
                }
            }
            c.Username = username;
            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.PASSWORD_REQUEST, "");
            return true;
        }

        private bool connectUserWithPassword(Client c, string password)
        {
            if (c.Username == null)
            {
                SendError(c, "Username ?");
                return false;
            }
           
            User user = User.GetByUsername(c.Username);
            if (user == null)
            {
                user = new User();
                user.Username = c.Username;
                user.Password = password;
                c.User = user;
                SendACK(c);
                return true;
            }
            else if (user.Password != password)
            {
                SendError(c, "Bad credentials.");
                return false;
            }
            c.User = user;
            SendACK(c);
            return true;
        }

        public void SendError(Client c, string text)
        {
            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.ERROR, text);
        }
    }
}
