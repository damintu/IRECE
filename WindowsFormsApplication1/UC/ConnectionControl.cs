using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using IRECEClient.Service;
using IRECEClient.Forms;
using IRECE;
namespace IRECEClient.UC
{
    public partial class ConnectionControl : UserControl
    {
        public ConnectionControl()
        {
            InitializeComponent();
            this.ipTextBox.Text = "192.168.0.23";
            this.portTextBox.Text = "5000";
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();

                if (this.ipTextBox.Text != "" && this.portTextBox.Text != "" && this.loginTextBox.Text != "")
                {

                    tcpclnt.Connect(this.ipTextBox.Text, Convert.ToInt32(this.portTextBox.Text));
                    StreamService.Instance.Stm = tcpclnt.GetStream();

                    IRECEMessage message = new IRECEMessage();

                    message.Command = IRECE.IRECEMessage.USER;
                    message.Text = this.loginTextBox.Text;
                    message.Channel = IRECEChannel.SYSTEM_CH_SYSTEM;

                    StreamService stm = StreamService.Instance;
                    stm.SendMessage(message);
                    message = stm.getMessage();
                    //TODO FAIRE CHIER l'USER QUAND IL SUCE DES BITES
                    if( message.Command == IRECEMessage.PASSWORD_REQUEST) 
                    {
                        message.Command = IRECEMessage.PASSWORD;
                        message.Text = this.passwordTextBox.Text;
                        stm.SendMessage(message);
                        message = stm.getMessage();
                        if (message.Command == IRECEMessage.ACK)
                        {
                            this.ParentForm.DialogResult = DialogResult.OK;
                            this.ParentForm.Close();
                        }
                    }



                    
                    
                }
            }
            catch (Exception exep)
            {
                Console.WriteLine(exep.ToString());
            }
        }
        
          


    }
}
