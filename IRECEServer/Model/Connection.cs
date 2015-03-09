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
            return;
        }
    }
}
