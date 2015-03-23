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
        private IRECEMessage channelMessage;
        StreamService stm = StreamService.Instance;

        public ChannelForm()
        {
            InitializeComponent();
            MainForm mainForm = new MainForm();
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                channelMessage = stm.LastMessage;

                List<string> channelList = new List<string>();
                channelList = ParseChannelStringIntoListString(channelMessage.Text);

                foreach(string channel in channelList){
                  ListViewItem listChannelItems = new ListViewItem(channel);
                  channelsListView.Items.Add(listChannelItems);
                }
                               
            }
                                
                      
          }

        private List<string> ParseChannelStringIntoListString(string channelString)
        {
            List<string> listChannel = new List<string>();
            string[] subStrings = channelString.Split(';');
            foreach (string st in subStrings){
               listChannel.Add(st);
            }
                
            return listChannel;
        }

        private void channelsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChatForm chatForm = new ChatForm(channelsListView.SelectedItems[0].Text);
            chatForm.Show();
        }


        
    }
}
