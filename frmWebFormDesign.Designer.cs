namespace CompleteDataBaseAccess
{
    partial class frmWebFormDesign
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateControl = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDateKeyField = new System.Windows.Forms.ComboBox();
            this.chklstGridColumns = new System.Windows.Forms.CheckedListBox();
            this.btnGenerateBD = new System.Windows.Forms.Button();
            this.btnControlCS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Table";
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(107, 27);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(355, 21);
            this.cmbTables.TabIndex = 1;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(352, 54);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "&Get References";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(111, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 120);
            this.panel1.TabIndex = 4;
            // 
            // btnCreateControl
            // 
            this.btnCreateControl.Location = new System.Drawing.Point(111, 207);
            this.btnCreateControl.Name = "btnCreateControl";
            this.btnCreateControl.Size = new System.Drawing.Size(121, 23);
            this.btnCreateControl.TabIndex = 7;
            this.btnCreateControl.TabStop = false;
            this.btnCreateControl.Text = "Create &Control";
            this.btnCreateControl.UseVisualStyleBackColor = true;
            this.btnCreateControl.Click += new System.EventHandler(this.btnCreateControl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Key Field";
            // 
            // cmbDateKeyField
            // 
            this.cmbDateKeyField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateKeyField.FormattingEnabled = true;
            this.cmbDateKeyField.Location = new System.Drawing.Point(107, 83);
            this.cmbDateKeyField.Name = "cmbDateKeyField";
            this.cmbDateKeyField.Size = new System.Drawing.Size(355, 21);
            this.cmbDateKeyField.TabIndex = 4;
            // 
            // chklstGridColumns
            // 
            this.chklstGridColumns.CheckOnClick = true;
            this.chklstGridColumns.FormattingEnabled = true;
            this.chklstGridColumns.Location = new System.Drawing.Point(111, 419);
            this.chklstGridColumns.Name = "chklstGridColumns";
            this.chklstGridColumns.Size = new System.Drawing.Size(596, 116);
            this.chklstGridColumns.TabIndex = 8;
            this.chklstGridColumns.TabStop = false;
            this.chklstGridColumns.Visible = false;
            // 
            // btnGenerateBD
            // 
            this.btnGenerateBD.Location = new System.Drawing.Point(713, 419);
            this.btnGenerateBD.Name = "btnGenerateBD";
            this.btnGenerateBD.Size = new System.Drawing.Size(135, 23);
            this.btnGenerateBD.TabIndex = 10;
            this.btnGenerateBD.TabStop = false;
            this.btnGenerateBD.Text = "Generate BD";
            this.btnGenerateBD.UseVisualStyleBackColor = true;
            this.btnGenerateBD.Visible = false;
            this.btnGenerateBD.Click += new System.EventHandler(this.btnGenerateBD_Click);
            // 
            // btnControlCS
            // 
            this.btnControlCS.Enabled = false;
            this.btnControlCS.Location = new System.Drawing.Point(321, 110);
            this.btnControlCS.Name = "btnControlCS";
            this.btnControlCS.Size = new System.Drawing.Size(141, 23);
            this.btnControlCS.TabIndex = 5;
            this.btnControlCS.Text = "&Open Generator";
            this.btnControlCS.UseVisualStyleBackColor = true;
            this.btnControlCS.Click += new System.EventHandler(this.btnControlCS_Click);
            // 
            // frmWebFormDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 142);
            this.Controls.Add(this.btnControlCS);
            this.Controls.Add(this.btnGenerateBD);
            this.Controls.Add(this.chklstGridColumns);
            this.Controls.Add(this.btnCreateControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbDateKeyField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmWebFormDesign";
            this.Text = "Generate Your Web Form";
            this.Load += new System.EventHandler(this.frmWebFormDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDateKeyField;
        private System.Windows.Forms.CheckedListBox chklstGridColumns;
        private System.Windows.Forms.Button btnGenerateBD;
        private System.Windows.Forms.Button btnControlCS;
    }
}