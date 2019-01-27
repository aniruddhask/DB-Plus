namespace CompleteDataBaseAccess
{
    partial class TableView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTableName = new System.Windows.Forms.Panel();
            this.chklstColumns = new ColumnView();
            this.btnMinMax = new System.Windows.Forms.Button();
            this.lblTableName = new System.Windows.Forms.TextBox();
            this.pnlTableName.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTableName
            // 
            this.pnlTableName.Controls.Add(this.chklstColumns);
            this.pnlTableName.Location = new System.Drawing.Point(0, 16);
            this.pnlTableName.Name = "pnlTableName";
            this.pnlTableName.Size = new System.Drawing.Size(200, 135);
            this.pnlTableName.TabIndex = 0;
            // 
            // chklstColumns
            // 
            this.chklstColumns.FormattingEnabled = true;
            this.chklstColumns.Location = new System.Drawing.Point(1, 1);
            this.chklstColumns.Name = "chklstColumns";
            this.chklstColumns.Size = new System.Drawing.Size(198, 132);
            this.chklstColumns.TabIndex = 0;
            this.chklstColumns.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chklstColumns_MouseDown);
            // 
            // btnMinMax
            // 
            this.btnMinMax.Location = new System.Drawing.Point(182, 2);
            this.btnMinMax.Name = "btnMinMax";
            this.btnMinMax.Size = new System.Drawing.Size(16, 14);
            this.btnMinMax.TabIndex = 1;
            this.btnMinMax.Text = "_";
            this.btnMinMax.UseVisualStyleBackColor = true;
            this.btnMinMax.Click += new System.EventHandler(this.btnMinMax_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTableName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTableName.Location = new System.Drawing.Point(2, 2);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.ReadOnly = true;
            this.lblTableName.ShortcutsEnabled = false;
            this.lblTableName.Size = new System.Drawing.Size(179, 14);
            this.lblTableName.TabIndex = 2;
            // 
            // TableView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.btnMinMax);
            this.Controls.Add(this.pnlTableName);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(200, 154);
            this.Load += new System.EventHandler(this.TableView_Load);
            this.Resize += new System.EventHandler(this.TableView_Resize);
            this.pnlTableName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTableName;
        private System.Windows.Forms.Button btnMinMax;
        private ColumnView chklstColumns;
        private System.Windows.Forms.TextBox lblTableName;
    }
}
