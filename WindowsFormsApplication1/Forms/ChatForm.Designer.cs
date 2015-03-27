namespace IRECEClient.Forms
{
    partial class ChatForm
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
            this.messagesListBox = new System.Windows.Forms.ListBox();
            this.usersListView = new System.Windows.Forms.ListView();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.envoyerButton = new System.Windows.Forms.Button();
            this.listUserCoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messagesListBox
            // 
            this.messagesListBox.FormattingEnabled = true;
            this.messagesListBox.Location = new System.Drawing.Point(13, 49);
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.Size = new System.Drawing.Size(467, 199);
            this.messagesListBox.TabIndex = 0;
            // 
            // usersListView
            // 
            this.usersListView.Location = new System.Drawing.Point(496, 49);
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(186, 199);
            this.usersListView.TabIndex = 1;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(13, 283);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(561, 20);
            this.messageTextBox.TabIndex = 2;
            // 
            // envoyerButton
            // 
            this.envoyerButton.Location = new System.Drawing.Point(580, 280);
            this.envoyerButton.Name = "envoyerButton";
            this.envoyerButton.Size = new System.Drawing.Size(102, 23);
            this.envoyerButton.TabIndex = 3;
            this.envoyerButton.Text = "Envoyer";
            this.envoyerButton.UseVisualStyleBackColor = true;
            // 
            // listUserCoLabel
            // 
            this.listUserCoLabel.AutoSize = true;
            this.listUserCoLabel.Location = new System.Drawing.Point(496, 30);
            this.listUserCoLabel.Name = "listUserCoLabel";
            this.listUserCoLabel.Size = new System.Drawing.Size(160, 13);
            this.listUserCoLabel.TabIndex = 5;
            this.listUserCoLabel.Text = "Liste des utilisateurs connectés :";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 339);
            this.Controls.Add(this.listUserCoLabel);
            this.Controls.Add(this.envoyerButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.usersListView);
            this.Controls.Add(this.messagesListBox);
            this.Name = "ChatForm";
            this.Text = "Chat en cours";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox messagesListBox;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button envoyerButton;
        private System.Windows.Forms.Label listUserCoLabel;
    }
}