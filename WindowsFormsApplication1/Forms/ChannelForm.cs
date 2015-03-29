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
using IRECE;

namespace IRECEClient.Forms
{
    public partial class ChannelForm : Form
    {
        StreamService stm = StreamService.Instance;
        private List<ChatForm> openChatForms = new List<ChatForm>();

        public ChannelForm()
        {
            InitializeComponent();
        }

        public void RefreshChannels()
        {
            channelsListView.Items.Clear();
            List<string> listChannel = StreamService.Instance.GetChannels();
            foreach (string channel in listChannel)
            {
                ListViewItem listChannelItems = new ListViewItem(channel);
                channelsListView.Items.Add(listChannelItems);
            }
        }

        private void channelsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string askedChannel = channelsListView.SelectedItems[0].Text;
            foreach (ChatForm form in openChatForms)
            {
                if (form.channelName == askedChannel)
                {
                    form.Focus();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            ChatForm chatForm = new ChatForm(askedChannel);
            openChatForms.Add(chatForm);
            chatForm.Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshChannels();
        }

        private void ChannelForm_Load(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm();
            if (connectionForm.ShowDialog() == DialogResult.OK)
            {
                RefreshChannels();
            }
            else
            {
                Close();
            }
        }
    }
}
