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
        public string channelName;
        StreamService stm = StreamService.Instance;

        public ChatForm()
        {
            InitializeComponent();
        }

        public ChatForm(string channel)
        {
            InitializeComponent();
            channelName = channel;
            Text = Text + " : " + channelName;
            RefreshUsers();
        }

        public void RefreshUsers()
        {
            usersListView.Items.Clear();
            List<string> listUsers = StreamService.Instance.GetUsers(channelName);
            foreach (string user in listUsers)
            {
                ListViewItem listUserItem = new ListViewItem(user);
                usersListView.Items.Add(listUserItem);
            }
        }
    }
}
