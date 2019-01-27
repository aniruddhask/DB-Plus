namespace CompleteDataBaseAccess
{
    partial class Enterprise
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
            this.components = new System.ComponentModel.Container();
            this.cmsA = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTables = new System.Windows.Forms.Panel();
            this.cmsA.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsA
            // 
            this.cmsA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.cmsA.Name = "contextMenuStrip1";
            this.cmsA.Size = new System.Drawing.Size(175, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addToolStripMenuItem.Text = "Add Table (s)...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // pnlTables
            // 
            this.pnlTables.AllowDrop = true;
            this.pnlTables.AutoScroll = true;
            this.pnlTables.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTables.BackColor = System.Drawing.Color.White;
            this.pnlTables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTables.Location = new System.Drawing.Point(0, 0);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(937, 209);
            this.pnlTables.TabIndex = 1;
            // 
            // Enterprise
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 440);
            this.ContextMenuStrip = this.cmsA;
            this.Controls.Add(this.pnlTables);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Enterprise";
            this.Text = "Enterprise";
            this.Load += new System.EventHandler(this.frm_Load);
            this.cmsA.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsA;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTables;

    }
}