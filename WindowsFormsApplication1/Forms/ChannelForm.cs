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
        public static List<ChatForm> OpenChatForms = new List<ChatForm>();

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
            foreach (ChatForm form in ChannelForm.OpenChatForms)
            {
                if (form.Type == IRECEChannel.TYPE_PUBLIC && form.channelName == askedChannel)
                {
                    form.Focus();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            bool joined;
            joined = stm.JoinChannel(askedChannel);
            if (joined)
            {
                ChatForm chatForm = new ChatForm(askedChannel);
                ChannelForm.OpenChatForms.Add(chatForm);
                chatForm.Show();
            }
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
                openRoomTimer.Enabled = true;
            }
            else
            {
                Close();
            }
        }

        private void openRoomTimer_Tick(object sender, EventArgs e)
        {
            if (stm.PrivateRooms.Count > 0)
            {
                KeyValuePair<string, string> first = stm.PrivateRooms.First();
                ChatForm chatForm = new ChatForm(first.Value, IRECEChannel.TYPE_PRIVATE);
                ChannelForm.OpenChatForms.Add(chatForm);
                chatForm.Show();
                stm.PrivateRooms.Remove(first.Key);
            }
        }
    }
}
