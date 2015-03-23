using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IRECE;
using IRECEClient.Forms;

namespace IRECEClient.Service
{
    class StreamService : EventArgs
    {
        private IRECEMessage lastMessage;

        public IRECEMessage LastMessage
        {
            get { return lastMessage; }
            set { lastMessage = value; }
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
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            StringBuilder sb =  new StringBuilder();

            for (int i = 0; i < k; i++)
            {
                sb.Append((Convert.ToChar(bb[i])));
                Console.Write((Convert.ToChar(bb[i])));
            }
            lastMessage = IRECEMessage.Deserialize(sb.ToString());
            return lastMessage;
        }

        public IRECEMessage handleRequest(List<IRECEMessage> list, String channelName, ChatForm form)
        {

            //TODO GROS SWITCH DES FAMILLES
            while (true) { 
                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < k; i++)
                {
                    sb.Append((Convert.ToChar(bb[i])));
                    Console.Write((Convert.ToChar(bb[i])));
                }
                list.Add(IRECEMessage.Deserialize(sb.ToString()));

                form.updateMessages();
                //TODO ENVOYER EVENT TO channelName windows.

            }
        }



    }
}
