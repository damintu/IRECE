using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IRECEServer.Model
{
    class Connection
    {
        private Socket socket;

        public Connection(Socket s)
        {
            socket = s;
        }

        public void Run()
        {
            Console.WriteLine("Running !");
            byte[] b = new byte[100];
            int k = socket.Receive(b);
            Console.WriteLine("Recieved...");
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            socket.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
        }
    }
}
