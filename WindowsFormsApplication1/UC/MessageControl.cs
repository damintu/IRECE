using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRECEClient.Service;
using System.IO;
using IRECE;

namespace IRECEClient.UC
{
    public partial class MessageControl : UserControl
    {
        public MessageControl()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (this.messageTextBox.Text != "")
            {
                try
                {
                  IRECEMessage mes = new IRECEMessage();
                  mes.Channel = "main";
                  mes.Command = IRECEMessage.USER;
                  mes.Text = this.messageTextBox.Text;

                  Console.WriteLine("Transmitting.....");
                  Stream stm = StreamService.Instance.Stm;

                  byte[] bytes = new byte[mes.ToString().Length * sizeof(char)];
                  System.Buffer.BlockCopy(mes.ToString().ToCharArray(), 0, bytes, 0, bytes.Length);
                  stm.Write(bytes, 0, bytes.Length);

                  byte[] bb = new byte[100];
                
                  int k = stm.Read(bb, 0, 100);
                                     

                  for (int i = 0; i < k; i++)
                      Console.Write(Convert.ToChar(bb[i]));
                }
                catch
                {

                }
              }
          }
    }
}
