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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.IpAdressLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.validateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // IpAdressLabel
            // 
            this.IpAdressLabel.AutoSize = true;
            this.IpAdressLabel.Location = new System.Drawing.Point(4, 20);
            this.IpAdressLabel.Name = "IpAdressLabel";
            this.IpAdressLabel.Size = new System.Drawing.Size(64, 13);
            this.IpAdressLabel.TabIndex = 1;
            this.IpAdressLabel.Text = "Adresse IP :";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(7, 49);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 13);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(134, 79);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(75, 23);
            this.validateBtn.TabIndex = 4;
            this.validateBtn.Text = "Connexion";
            this.validateBtn.UseVisualStyleBackColor = true;
            // 
            // ConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.IpAdressLabel);
            this.Controls.Add(this.textBox1);
            this.Name = "ConnectionControl";
            this.Size = new System.Drawing.Size(221, 105);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label IpAdressLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button validateBtn;
    }
}
