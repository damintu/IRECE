namespace IRECEClient.Forms
{
    partial class MainForm
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
            this.messageControl1 = new IRECEClient.UC.MessageControl();
            this.connectionControl1 = new IRECEClient.UC.ConnectionControl();
            this.SuspendLayout();
            // 
            // messageControl1
            // 
            this.messageControl1.Location = new System.Drawing.Point(12, 197);
            this.messageControl1.Name = "messageControl1";
            this.messageControl1.Size = new System.Drawing.Size(721, 180);
            this.messageControl1.TabIndex = 2;
            // 
            // connectionControl1
            // 
            this.connectionControl1.Location = new System.Drawing.Point(12, 12);
            this.connectionControl1.Name = "connectionControl1";
            this.connectionControl1.Size = new System.Drawing.Size(260, 179);
            this.connectionControl1.TabIndex = 1;
            this.connectionControl1.Load += new System.EventHandler(this.connectionControl1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 389);
            this.Controls.Add(this.messageControl1);
            this.Controls.Add(this.connectionControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ConnectionControl connectionControl1;
        private UC.MessageControl messageControl1;

    }
}