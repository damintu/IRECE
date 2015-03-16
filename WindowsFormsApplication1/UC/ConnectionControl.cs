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

namespace IRECEClient.UC
{
    public partial class ConnectionControl : UserControl
    {
        public ConnectionControl()
        {
            InitializeComponent();
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            try
            {


                TcpClient tcpclnt = new TcpClient();

                if (this.ipTextBox.Text != "" && this.portTextBox.Text != "")
                {

                    tcpclnt.Connect(this.ipTextBox.Text, Convert.ToInt32(this.portTextBox.Text));
                    StreamService.Instance.Stm = tcpclnt.GetStream();
                }
            }
            catch (Exception exep)
            {
                Console.WriteLine(exep.ToString());
            }
        }
        
          


    }
}
