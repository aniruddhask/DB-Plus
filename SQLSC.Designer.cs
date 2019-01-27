namespace CompleteDataBaseAccess
{
    partial class SQLSC
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
            this.btnGetDatabases = new System.Windows.Forms.Button();
            this.listDatabases = new System.Windows.Forms.ListBox();
            this.listTables = new System.Windows.Forms.ListBox();
            this.txtSQLScript = new System.Windows.Forms.TextBox();
            this.lblServerDetails = new System.Windows.Forms.Label();
            this.lblTables = new System.Windows.Forms.Label();
            this.lblDatabases = new System.Windows.Forms.Label();
            this.lblTableDefination = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetDatabases
            // 
            this.btnGetDatabases.Location = new System.Drawing.Point(12, 30);
            this.btnGetDatabases.Name = "btnGetDatabases";
            this.btnGetDatabases.Size = new System.Drawing.Size(141, 23);
            this.btnGetDatabases.TabIndex = 0;
            this.btnGetDatabases.Text = "Get Databases";
            this.btnGetDatabases.UseVisualStyleBackColor = true;
            this.btnGetDatabases.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // listDatabases
            // 
            this.listDatabases.FormattingEnabled = true;
            this.listDatabases.Location = new System.Drawing.Point(159, 30);
            this.listDatabases.Name = "listDatabases";
            this.listDatabases.Size = new System.Drawing.Size(139, 173);
            this.listDatabases.TabIndex = 1;
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.listDatabases_SelectedIndexChanged);
            // 
            // listTables
            // 
            this.listTables.FormattingEnabled = true;
            this.listTables.Location = new System.Drawing.Point(304, 30);
            this.listTables.Name = "listTables";
            this.listTables.Size = new System.Drawing.Size(395, 173);
            this.listTables.TabIndex = 1;
            this.listTables.SelectedIndexChanged += new System.EventHandler(this.listTables_SelectedIndexChanged);
            // 
            // txtSQLScript
            // 
            this.txtSQLScript.Location = new System.Drawing.Point(12, 210);
            this.txtSQLScript.Multiline = true;
            this.txtSQLScript.Name = "txtSQLScript";
            this.txtSQLScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQLScript.Size = new System.Drawing.Size(687, 305);
            this.txtSQLScript.TabIndex = 2;
            // 
            // lblServerDetails
            // 
            this.lblServerDetails.AutoSize = true;
            this.lblServerDetails.Location = new System.Drawing.Point(9, 9);
            this.lblServerDetails.Name = "lblServerDetails";
            this.lblServerDetails.Size = new System.Drawing.Size(89, 13);
            this.lblServerDetails.TabIndex = 3;
            this.lblServerDetails.Text = "Server Details";
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(308, 9);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(44, 13);
            this.lblTables.TabIndex = 4;
            this.lblTables.Text = "Tables";
            // 
            // lblDatabases
            // 
            this.lblDatabases.AutoSize = true;
            this.lblDatabases.Location = new System.Drawing.Point(156, 9);
            this.lblDatabases.Name = "lblDatabases";
            this.lblDatabases.Size = new System.Drawing.Size(67, 13);
            this.lblDatabases.TabIndex = 5;
            this.lblDatabases.Text = "Databases";
            // 
            // lblTableDefination
            // 
            this.lblTableDefination.AutoSize = true;
            this.lblTableDefination.Location = new System.Drawing.Point(12, 190);
            this.lblTableDefination.Name = "lblTableDefination";
            this.lblTableDefination.Size = new System.Drawing.Size(100, 13);
            this.lblTableDefination.TabIndex = 6;
            this.lblTableDefination.Text = "Table Defination";
            // 
            // SQLSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 527);
            this.Controls.Add(this.lblTableDefination);
            this.Controls.Add(this.lblDatabases);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.lblServerDetails);
            this.Controls.Add(this.txtSQLScript);
            this.Controls.Add(this.listTables);
            this.Controls.Add(this.listDatabases);
            this.Controls.Add(this.btnGetDatabases);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SQLSC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Getting Table Defination";
            this.Load += new System.EventHandler(this.SQLSC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetDatabases;
        private System.Windows.Forms.ListBox listDatabases;
        private System.Windows.Forms.ListBox listTables;
        private System.Windows.Forms.TextBox txtSQLScript;
        private System.Windows.Forms.Label lblServerDetails;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Label lblDatabases;
        private System.Windows.Forms.Label lblTableDefination;
    }
}