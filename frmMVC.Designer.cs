namespace CompleteDataBaseAccess
{
    partial class frmMVC
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
            this.btnFields = new System.Windows.Forms.Button();
            this.btnCC = new System.Windows.Forms.Button();
            this.btnPL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFields
            // 
            this.btnFields.Location = new System.Drawing.Point(12, 12);
            this.btnFields.Name = "btnFields";
            this.btnFields.Size = new System.Drawing.Size(159, 27);
            this.btnFields.TabIndex = 0;
            this.btnFields.Text = "Fields";
            this.btnFields.UseVisualStyleBackColor = true;
            this.btnFields.Click += new System.EventHandler(this.btnFields_Click);
            // 
            // btnCC
            // 
            this.btnCC.Location = new System.Drawing.Point(12, 45);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(159, 27);
            this.btnCC.TabIndex = 1;
            this.btnCC.Text = "Common Constants";
            this.btnCC.UseVisualStyleBackColor = true;
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnPL
            // 
            this.btnPL.Location = new System.Drawing.Point(12, 78);
            this.btnPL.Name = "btnPL";
            this.btnPL.Size = new System.Drawing.Size(159, 27);
            this.btnPL.TabIndex = 1;
            this.btnPL.Text = "Procedure Listing";
            this.btnPL.UseVisualStyleBackColor = true;
            this.btnPL.Click += new System.EventHandler(this.btnPL_Click);
            // 
            // frmMVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 119);
            this.Controls.Add(this.btnPL);
            this.Controls.Add(this.btnCC);
            this.Controls.Add(this.btnFields);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMVC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFields;
        private System.Windows.Forms.Button btnCC;
        private System.Windows.Forms.Button btnPL;
    }
}