using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using IRECE.Message;

namespace IRECEServer.Model
{
    class Client
    {
        private Socket socket;

        public Client(Socket s)
        {
            socket = s;
        }

        public void Run()
        {
            byte[] b = new byte[100];
            int k;
            while ((k = socket.Receive(b)) != 0)
            {
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                Channel c = new Channel();
                Message s = new Message();
                s.Text = "Test";
                c.Send(s);

                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
            }
        }
    }
}
