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
                
            }
            

          

            
          
        }
    }
}
