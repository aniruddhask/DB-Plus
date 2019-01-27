namespace CompleteDataBaseAccess
{
    partial class Registration
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
            this.wbRegistration = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbRegistration
            // 
            this.wbRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbRegistration.Location = new System.Drawing.Point(0, 0);
            this.wbRegistration.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRegistration.Name = "wbRegistration";
            this.wbRegistration.Size = new System.Drawing.Size(790, 443);
            this.wbRegistration.TabIndex = 0;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 443);
            this.Controls.Add(this.wbRegistration);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Registered For  Better Support.";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbRegistration;
    }
}