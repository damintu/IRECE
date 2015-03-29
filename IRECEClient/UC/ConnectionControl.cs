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
            this.ipTextBox.Text = IRECECore.LocalIPAddress();
            this.portTextBox.Text = IRECECore.SERVER_PORT.ToString();
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            if (ipTextBox.Text != "" && portTextBox.Text != "" && loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                StreamService service = StreamService.Instance;
                bool step;
                step = service.InitiateConnection(ipTextBox.Text, portTextBox.Text);
                if (!step)
                {
                    errorLabel.Text = "Impossible de contacter le serveur.";
                    return;
                }
                step = service.ConnectUser(loginTextBox.Text, passwordTextBox.Text);
                if (!step)
                {
                    errorLabel.Text = "Authentification impossible.";
                    return;
                }
                ParentForm.DialogResult = DialogResult.OK;
                ParentForm.Close();
            }
        }
        
          


    }
}
