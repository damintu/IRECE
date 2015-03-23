using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRECEClient.Service;
using System.Threading;
using IRECE;

namespace IRECEClient.Forms
{
    public partial class ChatForm : Form
    {
        private string channelName;
        public event EventHandler EventMessage;
        public List<IRECEMessage> listMessage;

        public ChatForm()
        {
            InitializeComponent();
        }

        public ChatForm(string channelName)
        {
            InitializeComponent();
            this.channelName = channelName;
            channelLabel.Text = channelName;
            StreamService stm = StreamService.Instance;
            Thread thr = new Thread(() => stm.handleRequest(listMessage,channelName,this));
            thr.Start();
        }

        private void envoyerButton_Click(object sender, EventArgs e)
        {

        }


        internal void updateMessages()
        {
            this.messagesListBox.Items.Clear();
            foreach (IRECEMessage message in listMessage)
            {
                this.messagesListBox.Items.Add(message);
            }
        }
    }

}

