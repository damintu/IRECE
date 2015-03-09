using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class IRCE : Form
    {
        Socket socket;
        EndPoint endPointLocal, endPointRemote;
        byte[] buffer;
        public IRCE()
        {
            
            InitializeComponent();
        }

        private void labelClientHote_Click(object sender, EventArgs e)
        {

        }

        private void IRCE_Load(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.ReuseAddress, true);

            textBoxClientHote.Text = getLocalIP();
            textBoxServeurHote.Text = getLocalIP();

        }

        private string getLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
                return "127.0.0.1";
            }


            return null;
        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            //on binde le socket
            endPointLocal = new IPEndPoint(IPAddress.Parse(textBoxClientPort.Text), Convert.ToInt32(textBoxClientPort.Text));
            socket.Bind(endPointLocal);
            // on se connecte au serveur
            endPointRemote = new IPEndPoint(IPAddress.Parse(textBoxServeurHote.Text), Convert.ToInt32(textBoxServeurPort.Text));
            socket.Connect(endPointRemote);

            //on listen sur le bon port
            buffer = new Byte[1500];
            socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointRemote, new AsyncCallback(MessageCallBack), buffer);

        }

        private void MessageCallBack(IAsyncResult aResult){
            
            try{
                byte[] receivedData = new byte[1500];
            receivedData = (byte[]) aResult.AsyncState;
            //on convertit byte en string
            ASCIIEncoding aEncoding  = new ASCIIEncoding();
            string receivedMessage = aEncoding.GetString(receivedData);

            //on ajoute le message dans la listMessage

            listMessages.Items.Add("Friend : "+receivedMessage);

            buffer= new byte[1500];
            socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointRemote, new AsyncCallback(MessageCallBack), buffer);

            }catch(Exception e){
                MessageBox.Show(e.ToString());

            }
            



        }

        private void buttonEnvoyer_Click(object sender, EventArgs e)
        {
        //Convert string message to byte[]
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendMessage = new byte[1500];
            sendMessage = aEncoding.GetBytes(textBoxMessage.Text);
            
         //on envoie le message encodé
            socket.Send(sendMessage);
            listMessages.Items.Add("Me : " + textBoxMessage.Text);

        }
       
    }
}
