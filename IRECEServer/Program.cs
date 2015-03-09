using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using IRECEServer.Model;

namespace IRECEServer
{
    class Program
    {
        const String SERVER_IP = "127.0.0.1";
        const int SERVER_PORT = 5000;

        static void Main(string[] args)
        {
            try
            {
                IPAddress serverIp = IPAddress.Parse(SERVER_IP);
                TcpListener serverListener = new TcpListener(serverIp, SERVER_PORT);

                serverListener.Start();

                Console.WriteLine("Server running at port " + SERVER_PORT + ".");

                while (true) {
                    Socket s = serverListener.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                    Connection c = new Connection(s);
                    Thread conThread = new Thread(c.Run);
                    conThread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR : " + e.StackTrace);
                Console.WriteLine("Shutting down.");
                // TODO Clean all connections.
            }   
        }
    }
}
