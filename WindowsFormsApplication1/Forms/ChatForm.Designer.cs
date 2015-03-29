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
            this.components = new System.ComponentModel.Container();
            this.usersListView = new System.Windows.Forms.ListView();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.listUserCoLabel = new System.Windows.Forms.Label();
            this.messageList = new System.Windows.Forms.RichTextBox();
            this.userlistTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // usersListView
            // 
            this.usersListView.Location = new System.Drawing.Point(496, 32);
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(186, 242);
            this.usersListView.TabIndex = 1;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.List;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(13, 283);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(561, 20);
            this.messageTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(580, 280);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(102, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Envoyer";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // listUserCoLabel
            // 
            this.listUserCoLabel.AutoSize = true;
            this.listUserCoLabel.Location = new System.Drawing.Point(496, 16);
            this.listUserCoLabel.Name = "listUserCoLabel";
            this.listUserCoLabel.Size = new System.Drawing.Size(160, 13);
            this.listUserCoLabel.TabIndex = 5;
            this.listUserCoLabel.Text = "Liste des utilisateurs connectés :";
            // 
            // messageList
            // 
            this.messageList.Location = new System.Drawing.Point(13, 13);
            this.messageList.Name = "messageList";
            this.messageList.ReadOnly = true;
            this.messageList.Size = new System.Drawing.Size(477, 264);
            this.messageList.TabIndex = 6;
            this.messageList.Text = "";
            this.messageList.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.messageList_LinkClicked);
            // 
            // userlistTimer
            // 
            this.userlistTimer.Interval = 1500;
            this.userlistTimer.Tick += new System.EventHandler(this.userlistTimer_Tick);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 339);
            this.Controls.Add(this.messageList);
            this.Controls.Add(this.listUserCoLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.usersListView);
            this.Name = "ChatForm";
            this.Text = "Chat en cours";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label listUserCoLabel;
        private System.Windows.Forms.RichTextBox messageList;
        private System.Windows.Forms.Timer userlistTimer;
    }
}