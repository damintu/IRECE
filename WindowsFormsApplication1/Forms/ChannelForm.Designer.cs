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
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // channelsListView
            // 
            this.channelsListView.Location = new System.Drawing.Point(12, 12);
            this.channelsListView.Name = "channelsListView";
            this.channelsListView.Size = new System.Drawing.Size(246, 228);
            this.channelsListView.TabIndex = 0;
            this.channelsListView.UseCompatibleStateImageBehavior = false;
            this.channelsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.channelsListView_MouseDoubleClick);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(13, 247);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Rafraichir";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 283);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.channelsListView);
            this.Name = "ChannelForm";
            this.Text = "Liste des channels";
            this.Load += new System.EventHandler(this.ChannelForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView channelsListView;
        private System.Windows.Forms.Button refreshButton;
    }
}