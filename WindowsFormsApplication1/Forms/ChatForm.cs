using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRECEClient.Forms
{
    public partial class ChatForm : Form
    {
        private string channelName;

        public ChatForm()
        {
            InitializeComponent();
        }

        public ChatForm(string channelName)
        {
            InitializeComponent();
            this.channelName = channelName;
            channelLabel.Text = channelName;
        }

    }
}
