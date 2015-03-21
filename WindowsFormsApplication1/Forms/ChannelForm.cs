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

namespace IRECEClient.Forms
{
    public partial class ChannelForm : Form
    {

        public ChannelForm()
        {
            InitializeComponent();
            MainForm mainForm = new MainForm();
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                                
            }
            

          

            
          
        }
    }
}
