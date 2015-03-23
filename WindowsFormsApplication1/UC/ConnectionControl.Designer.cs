namespace IRECEClient.UC
{
    partial class ConnectionControl
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
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.IpAdressLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.validateBtn = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(109, 13);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(100, 20);
            this.ipTextBox.TabIndex = 0;
            // 
            // IpAdressLabel
            // 
            this.IpAdressLabel.AutoSize = true;
            this.IpAdressLabel.Location = new System.Drawing.Point(39, 16);
            this.IpAdressLabel.Name = "IpAdressLabel";
            this.IpAdressLabel.Size = new System.Drawing.Size(64, 13);
            this.IpAdressLabel.TabIndex = 1;
            this.IpAdressLabel.Text = "Adresse IP :";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(71, 43);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 13);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port :";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(109, 40);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 3;
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(134, 149);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(75, 23);
            this.validateBtn.TabIndex = 4;
            this.validateBtn.Text = "Connexion";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(68, 75);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(39, 13);
            this.loginLabel.TabIndex = 5;
            this.loginLabel.Text = "Login :";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(109, 72);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(100, 20);
            this.loginTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(109, 110);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 7;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(48, 113);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(59, 13);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password :";
            // 
            // ConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.IpAdressLabel);
            this.Controls.Add(this.ipTextBox);
            this.Name = "ConnectionControl";
            this.Size = new System.Drawing.Size(221, 194);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label IpAdressLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
    }
}
