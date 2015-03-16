using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using IRECEServer.Model;
using IRECE.Message;

namespace IRECEServer
{
    class Program
    {
        const String SERVER_IP = "127.0.0.1";
        const int SERVER_PORT = 5000;

        static void Main(string[] args)
        {
            Channel ch = new Channel();
            IRECEMessage str = new IRECEMessage();
            str.Text = "Test";
            ch.Send(str);
            IRECEMessage m = (IRECEMessage) IRECEMessage.Deserialize("{\"Text\":\"Test\",\"Command\":null}");
            Console.WriteLine(m.Text);

            try
            {
                IPAddress serverIp = IPAddress.Parse(SERVER_IP);
                TcpListener serverListener = new TcpListener(serverIp, SERVER_PORT);

                serverListener.Start();

                Console.WriteLine("Server running at port " + SERVER_PORT + ".");

                while (true) {
                    Socket s = serverListener.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                    Client c = new Client(s);
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
