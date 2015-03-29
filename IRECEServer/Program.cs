using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using IRECEServer.Model;
using IRECE;

namespace IRECEServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel.Channels = new List<Channel>();
            SystemChannel sysChan = new SystemChannel();
            sysChan.Name = Channel.SYSTEM_CH_SYSTEM;
            sysChan.Clients = new List<Client>();
            Channel.Channels.Add(sysChan);
            Channel.SystemChannel = sysChan;
            Channel ch = new Channel();
            ch.Name = Channel.SYSTEM_CH_MAIN;
            ch.Type = Channel.TYPE_PUBLIC;
            ch.Clients = new List<Client>();
            Channel.Channels.Add(ch);
            Channel ch2 = new Channel();
            ch2.Name = Channel.SYSTEM_CH_MAIN + "2";
            ch2.Type = Channel.TYPE_PUBLIC;
            ch2.Clients = new List<Client>();
            Channel.Channels.Add(ch2);

            Client.Clients = new List<Client>();
            User.Load();

            try
            {
                IPAddress serverIp = IPAddress.Parse(IRECECore.LocalIPAddress());
                TcpListener serverListener = new TcpListener(serverIp, IRECECore.SERVER_PORT);

                serverListener.Start();

                Console.WriteLine("Server running at "+serverIp.ToString() + ":" + IRECECore.SERVER_PORT + ".");

                while (true) {
                    Socket s = serverListener.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                    Client c = new Client(s);
                    c.Channels = new List<Channel>();
                    Client.Clients.Add(c);
                    Channel.SystemChannel.Clients.Add(c);
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
