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
                case IRECEMessage.CHANNELS_REQUEST:
                    requestChannels(c);
                    break;
                case IRECEMessage.USERLIST_REQUEST:
                    requestUsers(c, m.Text);
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
                addChannel(c, Channel.GetByName(Channel.SYSTEM_CH_MAIN));
                SendACK(c);
                return true;
            }
            else if (user.Password != password)
            {
                SendError(c, "Bad credentials.");
                return false;
            }
            c.User = user;
            addChannel(c, Channel.GetByName(Channel.SYSTEM_CH_MAIN));
            SendACK(c);
            return true;
        }

        private void addChannel(Client c, Channel ch)
        {
            ch.Clients.Add(c);
            c.Channels.Add(ch);
        }

        private void requestChannels(Client c)
        {
            if (!checkConnected(c))
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            bool comma = false;
            foreach (Channel ch in c.Channels)
            {
                if (comma)
                {
                    sb.Append(';');
                }
                sb.Append(ch.Name);
                comma = true;
            }

            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.CHANNELS_RESPONSE, sb.ToString());
        }

        private void requestUsers(Client c, string channelName)
        {
            if (!checkConnected(c))
            {
                return;
            }
            Channel chan = Channel.GetByName(channelName);
            // We send the same error if the channel does not exist or should not be accessed by this user ;
            // we don't want the user to know that this channel exists if she's not supposed to access it
            if (null == chan || !chan.Clients.Contains(c))
            {
                SendError(c, "Unknown channel.");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(chan.Name);
            sb.Append(":");
            bool comma = false;
            foreach (Client cli in chan.Clients)
            {
                if (comma)
                {
                    sb.Append(';');
                }
                sb.Append(cli.User.Username);
                comma = true;
            }

            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.USERLIST_RESPONSE, sb.ToString());
        }

        private bool checkConnected(Client c)
        {
            if (c.User == null)
            {
                SendError(c, "Connection needed.");
                return false;
            }
            return true;
        }

        public void SendError(Client c, string text)
        {
            SendMessage(c, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.ERROR, text);
        }

        public void Disconnect(Client c, string type = "normal")
        {
            string userText = "User " + c.User.Username;
            string clientText = "Client " + c.Socket.RemoteEndPoint + " (username:"+c.User.Username+")";
            if (type == "normal")
            {
                userText += " disconnected.";
                clientText += " disconnected.";
            }
            else if (type == "timeout")
            {
                userText += " timed out.";
                clientText += " timed out.";
            }
            else
            {
                userText += " disconnected (error).";
                clientText += " disconnected (error).";
            }
            List<Client> toSendList = new List<Client>();
            foreach (Channel chan in c.Channels)
            {
                foreach (Client cli in chan.Clients)
                {
                    if (cli == c)
                    {
                        continue;
                    }
                    if (toSendList.Contains(cli))
                    {
                        continue;
                    }
                    SendMessage(cli, chan, IRECEMessage.MESSAGE, userText);
                    toSendList.Add(cli);
                }
            }
            foreach (Client cli in toSendList)
            {
                SendMessage(cli, Channel.SYSTEM_CH_SYSTEM, IRECEMessage.USER_DISCONNECT, c.User.Username);
            }
            Console.WriteLine(clientText);
        }
    }
}
