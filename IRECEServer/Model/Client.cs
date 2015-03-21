using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using IRECE;

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
            byte[] b = new byte[2048];
            int k;
            while ((k = socket.Receive(b)) != 0)
            {
                string message = Encoding.UTF8.GetString(b, 0, k);
                IRECEMessage mes = IRECEMessage.Deserialize(message);
                Channel c = new Channel();
                c.Send(mes);

                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
            }
        }
    }
}
