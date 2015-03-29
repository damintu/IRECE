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
using System.IO;

namespace IRECEClient.Forms
{
    public partial class ChatForm : Form
    {
        public string channelName;
        public string Type = IRECEChannel.TYPE_PUBLIC;

        StreamService stm = StreamService.Instance;

        public ChatForm()
        {
            InitializeComponent();
        }

        public ChatForm(string channel, string type = IRECEChannel.TYPE_PUBLIC)
        {
            InitializeComponent();
            channelName = channel;
            Type = type;
            Text = Text + " : " + channelName;
            RefreshUsers();
            Thread receptionThread = new Thread(Receive);
            receptionThread.IsBackground = true;
            receptionThread.Start();
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
                        if (stm.MessagesByChannel[channelName][0].Command == IRECEMessage.USER_DISCONNECT
                            || stm.MessagesByChannel[channelName][0].Command == IRECEMessage.USER_JOIN)
                        {
                            string text = stm.MessagesByChannel[channelName][0].Text;
                            messageList.AppendText(text + "\n");
                        }
                        if (stm.MessagesByChannel[channelName][0].Command == IRECEMessage.IMAGE)
                        {
                            Image image = IRECEImageHelper.ImageFromBase64String(stm.MessagesByChannel[channelName][0].Text);
                            PictureForm form = new PictureForm(image, stm.MessagesByChannel[channelName][0].User);
                            form.Show();
                        }
                        else
                        {
                            string user = stm.MessagesByChannel[channelName][0].User;
                            string text = stm.MessagesByChannel[channelName][0].Text;
                            messageList.AppendText(user + " : " + text + "\n");
                        }
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

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            stm.LeaveChannel(channelName);
            ChannelForm.OpenChatForms.Remove(this);
        }

        private void usersListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string askedUser = usersListView.SelectedItems[0].Text;
            foreach (ChatForm form in ChannelForm.OpenChatForms)
            {
                if (form.Type == IRECEChannel.TYPE_PRIVATE && form.channelName == askedUser)
                {
                    form.Focus();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            stm.JoinPrivateChannel(askedUser);
        }

        private void refreshUsersButton_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void ChatForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void ChatForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] imageFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Image image = null;
            try
            {
                image = Image.FromFile(imageFile[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Ceci n'est pas une image !");
            }

            if (image != null)
            {

                FileInfo fileInfo = new FileInfo(imageFile[0]);
                if (fileInfo.Length > 100000)
                {
                    MessageBox.Show("L'image à une taille supérieur à 100 Ko");
                }
                else
                {
                    string imageBase64 = IRECEImageHelper.ImageToBase64String(image);
                    stm.SendImageToChannel(imageBase64, channelName);
                }
            }
        }

        private void messageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                stm.SendMessageToChannel(messageTextBox.Text, channelName);
                messageTextBox.Clear();
            }
        }
    }
}
