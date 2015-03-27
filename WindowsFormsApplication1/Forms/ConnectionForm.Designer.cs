namespace IRECEClient.Forms
{
    partial class ConnectionForm
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
            this.connectionControl = new IRECEClient.UC.ConnectionControl();
            this.SuspendLayout();
            // 
            // connectionControl
            // 
            this.connectionControl.Location = new System.Drawing.Point(12, 12);
            this.connectionControl.Name = "connectionControl";
            this.connectionControl.Size = new System.Drawing.Size(224, 195);
            this.connectionControl.TabIndex = 1;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 220);
            this.Controls.Add(this.connectionControl);
            this.Name = "ConnectionForm";
            this.Text = "Connection";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ConnectionControl connectionControl;

    }
}