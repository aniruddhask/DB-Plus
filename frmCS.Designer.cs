namespace CompleteDataBaseAccess
{
    partial class frmCS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerateCS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(8, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 178);
            this.panel1.TabIndex = 0;
            // 
            // btnGenerateCS
            // 
            this.btnGenerateCS.Location = new System.Drawing.Point(1175, 9);
            this.btnGenerateCS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerateCS.Name = "btnGenerateCS";
            this.btnGenerateCS.Size = new System.Drawing.Size(90, 20);
            this.btnGenerateCS.TabIndex = 0;
            this.btnGenerateCS.Text = "Generate CS";
            this.btnGenerateCS.UseVisualStyleBackColor = true;
            this.btnGenerateCS.Click += new System.EventHandler(this.btnGenerateCS_Click);
            // 
            // frmCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 218);
            this.Controls.Add(this.btnGenerateCS);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Behind File Generate";
            this.Load += new System.EventHandler(this.frmCS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerateCS;
    }
}