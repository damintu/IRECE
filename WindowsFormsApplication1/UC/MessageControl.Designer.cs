namespace IRECEClient.UC
{
    partial class MessageControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.channelNamelabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(715, 147);
            this.listBox1.TabIndex = 0;
            // 
            // channelNamelabel
            // 
            this.channelNamelabel.AutoSize = true;
            this.channelNamelabel.Location = new System.Drawing.Point(3, 160);
            this.channelNamelabel.Name = "channelNamelabel";
            this.channelNamelabel.Size = new System.Drawing.Size(75, 13);
            this.channelNamelabel.TabIndex = 1;
            this.channelNamelabel.Text = "Non connecté";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(147, 157);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(489, 20);
            this.messageTextBox.TabIndex = 2;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(85, 160);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(56, 13);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "Message :";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(642, 157);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 4;
            this.sendBtn.Text = "Envoyer";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // MessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.channelNamelabel);
            this.Controls.Add(this.listBox1);
            this.Name = "MessageControl";
            this.Size = new System.Drawing.Size(721, 190);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label channelNamelabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button sendBtn;
    }
}
