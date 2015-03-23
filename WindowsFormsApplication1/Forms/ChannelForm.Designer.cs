namespace IRECEClient.Forms
{
    partial class ChannelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.channelsListView = new System.Windows.Forms.ListView();
            this.channelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // channelsListView
            // 
            this.channelsListView.Location = new System.Drawing.Point(12, 22);
            this.channelsListView.Name = "channelsListView";
            this.channelsListView.Size = new System.Drawing.Size(246, 228);
            this.channelsListView.TabIndex = 0;
            this.channelsListView.UseCompatibleStateImageBehavior = false;
            this.channelsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.channelsListView_MouseDoubleClick);
            // 
            // channelLabel
            // 
            this.channelLabel.AutoSize = true;
            this.channelLabel.Location = new System.Drawing.Point(13, 3);
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(95, 13);
            this.channelLabel.TabIndex = 1;
            this.channelLabel.Text = "Liste des channels";
            // 
            // ChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.channelLabel);
            this.Controls.Add(this.channelsListView);
            this.Name = "ChannelForm";
            this.Text = "ChannelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView channelsListView;
        private System.Windows.Forms.Label channelLabel;
    }
}