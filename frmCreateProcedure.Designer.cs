using System.Windows.Forms;
namespace CompleteDataBaseAccess
{
    partial class frmCreateProcedure
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
            Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnCreateProcedure = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGenerateBusinessData = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboProcedureType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(12, 12);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(324, 21);
            this.cmbTables.TabIndex = 0;
            // 
            // btnCreateProcedure
            // 
            this.btnCreateProcedure.Location = new System.Drawing.Point(521, 10);
            this.btnCreateProcedure.Name = "btnCreateProcedure";
            this.btnCreateProcedure.Size = new System.Drawing.Size(136, 23);
            this.btnCreateProcedure.TabIndex = 2;
            this.btnCreateProcedure.Text = "Create Procedure";
            this.btnCreateProcedure.UseVisualStyleBackColor = true;
            this.btnCreateProcedure.Click += new System.EventHandler(this.btnCreateProcedure_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 39);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(815, 242);
            this.txtOutput.TabIndex = 6;
            // 
            // btnGenerateBusinessData
            // 
            this.btnGenerateBusinessData.Location = new System.Drawing.Point(663, 10);
            this.btnGenerateBusinessData.Name = "btnGenerateBusinessData";
            this.btnGenerateBusinessData.Size = new System.Drawing.Size(164, 23);
            this.btnGenerateBusinessData.TabIndex = 3;
            this.btnGenerateBusinessData.Text = "Generate Business Data";
            this.btnGenerateBusinessData.UseVisualStyleBackColor = true;
            this.btnGenerateBusinessData.Click += new System.EventHandler(this.btnGenerateBusinessData_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 287);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(129, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy To Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(722, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboProcedureType
            // 
            this.cboProcedureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcedureType.FormattingEnabled = true;
            this.cboProcedureType.Items.AddRange(new object[] {
            "ALL",
            "INSERT",
            "UPDATE",
            "DELETE",
            "SELECT"});
            this.cboProcedureType.Location = new System.Drawing.Point(342, 12);
            this.cboProcedureType.Name = "cboProcedureType";
            this.cboProcedureType.Size = new System.Drawing.Size(173, 21);
            this.cboProcedureType.TabIndex = 1;
            // 
            // frmCreateProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 317);
            this.Controls.Add(this.cboProcedureType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGenerateBusinessData);
            this.Controls.Add(this.btnCreateProcedure);
            this.Controls.Add(this.cmbTables);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCreateProcedure";
            this.Text = "frmCreateProcedure";
            this.Load += new System.EventHandler(this.frmCreateProcedure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnCreateProcedure;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGenerateBusinessData;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboProcedureType;
    }
}