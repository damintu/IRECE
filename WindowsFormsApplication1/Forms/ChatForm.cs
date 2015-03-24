using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRECE;
using IRECEClient.Service;

namespace IRECEClient.Forms
{
    public partial class ChatForm : Form
    {

        private IRECEMessage lastMessage;
        private string channelName;
        StreamService stm = StreamService.Instance;

        public ChatForm()
        {
            InitializeComponent();
        }

        public ChatForm(string channelName)
        {
            InitializeComponent();

            this.channelName = channelName;
            channelLabel.Text = channelName;
           // lastMessage = stm.LastMessage;
        }



    }
}
