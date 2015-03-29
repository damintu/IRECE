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
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
            Thread receptionThread = new Thread(Receive);
            receptionThread.IsBackground = true;
            receptionThread.Start();
            userlistTimer.Enabled = true;
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

        private void sendButton_Click(object sender, EventArgs e)
        {
            stm.SendMessageToChannel(messageTextBox.Text, channelName);
            messageTextBox.Clear();
        }

        private void Receive()
        {
            while (true)
            {
                if (stm.MessagesByChannel.ContainsKey(channelName) && stm.MessagesByChannel[channelName].Count > 0)
                {
                    messageList.Invoke(new Action(() => {
                        string user = stm.MessagesByChannel[channelName][0].User;
                        string text = stm.MessagesByChannel[channelName][0].Text;
                        messageList.AppendText(user + " : " + text + "\n");
                    }
                    ));
                    
                    stm.MessagesByChannel[channelName].RemoveAt(0);
                }
            }
        }

        private void messageList_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void userlistTimer_Tick(object sender, EventArgs e)
        {
            RefreshUsers();
        }
    }
}
