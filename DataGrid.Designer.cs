namespace CompleteDataBaseAccess
{
    partial class DataGrid
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
            this.btnHTML = new System.Windows.Forms.Button();
            this.btnCS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDatasourceForDataGrid = new System.Windows.Forms.ComboBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.lstDataGridGolumns = new System.Windows.Forms.ListBox();
            this.cmbDataKeyField = new System.Windows.Forms.ComboBox();
            this.lblDataKeyField = new System.Windows.Forms.Label();
            this.lblDataGridColumn = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnReferesh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.chkHasEvent = new System.Windows.Forms.CheckBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkPushButton = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHTML
            // 
            this.btnHTML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnHTML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnHTML.Location = new System.Drawing.Point(177, 317);
            this.btnHTML.Name = "btnHTML";
            this.btnHTML.Size = new System.Drawing.Size(75, 26);
            this.btnHTML.TabIndex = 20;
            this.btnHTML.Text = "&HTML";
            this.btnHTML.UseVisualStyleBackColor = false;
            this.btnHTML.Click += new System.EventHandler(this.btnHTML_Click);
            // 
            // btnCS
            // 
            this.btnCS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnCS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCS.Location = new System.Drawing.Point(255, 317);
            this.btnCS.Name = "btnCS";
            this.btnCS.Size = new System.Drawing.Size(75, 26);
            this.btnCS.TabIndex = 21;
            this.btnCS.Text = "Manage&r";
            this.btnCS.UseVisualStyleBackColor = false;
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source For Grid From";
            // 
            // cmbSelection
            // 
            this.cmbSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbSelection.FormattingEnabled = true;
            this.cmbSelection.Items.AddRange(new object[] {
            "-Select-",
            "Table",
            "View",
            "Stored Procedure",
            "Temporary Table"});
            this.cmbSelection.Location = new System.Drawing.Point(176, 11);
            this.cmbSelection.Name = "cmbSelection";
            this.cmbSelection.Size = new System.Drawing.Size(184, 21);
            this.cmbSelection.TabIndex = 1;
            this.cmbSelection.SelectedIndexChanged += new System.EventHandler(this.cmbSelection_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label2.Location = new System.Drawing.Point(80, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select A Value";
            // 
            // cmbDatasourceForDataGrid
            // 
            this.cmbDatasourceForDataGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatasourceForDataGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbDatasourceForDataGrid.FormattingEnabled = true;
            this.cmbDatasourceForDataGrid.Location = new System.Drawing.Point(177, 36);
            this.cmbDatasourceForDataGrid.Name = "cmbDatasourceForDataGrid";
            this.cmbDatasourceForDataGrid.Size = new System.Drawing.Size(407, 21);
            this.cmbDatasourceForDataGrid.TabIndex = 4;
            this.cmbDatasourceForDataGrid.SelectedIndexChanged += new System.EventHandler(this.cmbDatasourceForDataGrid_SelectedIndexChanged);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnModify.Enabled = false;
            this.btnModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnModify.Location = new System.Drawing.Point(366, 11);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(218, 23);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modify &Tempory Table";
            this.btnModify.UseVisualStyleBackColor = false;
            // 
            // lstDataGridGolumns
            // 
            this.lstDataGridGolumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.lstDataGridGolumns.FormattingEnabled = true;
            this.lstDataGridGolumns.Location = new System.Drawing.Point(177, 88);
            this.lstDataGridGolumns.Name = "lstDataGridGolumns";
            this.lstDataGridGolumns.Size = new System.Drawing.Size(306, 108);
            this.lstDataGridGolumns.TabIndex = 10;
            // 
            // cmbDataKeyField
            // 
            this.cmbDataKeyField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataKeyField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbDataKeyField.FormattingEnabled = true;
            this.cmbDataKeyField.Location = new System.Drawing.Point(177, 61);
            this.cmbDataKeyField.Name = "cmbDataKeyField";
            this.cmbDataKeyField.Size = new System.Drawing.Size(183, 21);
            this.cmbDataKeyField.TabIndex = 6;
            // 
            // lblDataKeyField
            // 
            this.lblDataKeyField.AutoSize = true;
            this.lblDataKeyField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.lblDataKeyField.Location = new System.Drawing.Point(80, 64);
            this.lblDataKeyField.Name = "lblDataKeyField";
            this.lblDataKeyField.Size = new System.Drawing.Size(90, 13);
            this.lblDataKeyField.TabIndex = 5;
            this.lblDataKeyField.Text = "Data Key Field";
            // 
            // lblDataGridColumn
            // 
            this.lblDataGridColumn.AutoSize = true;
            this.lblDataGridColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.lblDataGridColumn.Location = new System.Drawing.Point(54, 91);
            this.lblDataGridColumn.Name = "lblDataGridColumn";
            this.lblDataGridColumn.Size = new System.Drawing.Size(116, 13);
            this.lblDataGridColumn.TabIndex = 9;
            this.lblDataGridColumn.Text = "Data Grid Columns";
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnUp.Location = new System.Drawing.Point(489, 88);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(95, 23);
            this.btnUp.TabIndex = 11;
            this.btnUp.Text = "&Up";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnDown.Location = new System.Drawing.Point(489, 117);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(95, 23);
            this.btnDown.TabIndex = 12;
            this.btnDown.Text = "&Down";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnReferesh
            // 
            this.btnReferesh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnReferesh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnReferesh.Location = new System.Drawing.Point(490, 173);
            this.btnReferesh.Name = "btnReferesh";
            this.btnReferesh.Size = new System.Drawing.Size(94, 23);
            this.btnReferesh.TabIndex = 14;
            this.btnReferesh.Text = "Re&fresh";
            this.btnReferesh.UseVisualStyleBackColor = false;
            this.btnReferesh.Click += new System.EventHandler(this.btnReferesh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label3.Location = new System.Drawing.Point(61, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Data Grid Buttons";
            // 
            // pnlButton
            // 
            this.pnlButton.AutoScroll = true;
            this.pnlButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.pnlButton.Location = new System.Drawing.Point(176, 202);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(307, 109);
            this.pnlButton.TabIndex = 17;
            // 
            // chkHasEvent
            // 
            this.chkHasEvent.AutoSize = true;
            this.chkHasEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkHasEvent.Location = new System.Drawing.Point(366, 63);
            this.chkHasEvent.Name = "chkHasEvent";
            this.chkHasEvent.Size = new System.Drawing.Size(94, 17);
            this.chkHasEvent.TabIndex = 7;
            this.chkHasEvent.Text = "Has &Buttons";
            this.chkHasEvent.UseVisualStyleBackColor = true;
            this.chkHasEvent.CheckedChanged += new System.EventHandler(this.chkHasEvent_CheckedChanged);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnChange.Location = new System.Drawing.Point(333, 317);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(69, 26);
            this.btnChange.TabIndex = 22;
            this.btnChange.Text = "&aspx.cs";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnRemove.Location = new System.Drawing.Point(489, 145);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(95, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkPushButton
            // 
            this.chkPushButton.AutoSize = true;
            this.chkPushButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkPushButton.Location = new System.Drawing.Point(73, 226);
            this.chkPushButton.Name = "chkPushButton";
            this.chkPushButton.Size = new System.Drawing.Size(100, 17);
            this.chkPushButton.TabIndex = 16;
            this.chkPushButton.Text = "Push Butt&ons";
            this.chkPushButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDelete);
            this.groupBox1.Controls.Add(this.chkSelect);
            this.groupBox1.Controls.Add(this.chkUpdate);
            this.groupBox1.Controls.Add(this.chkInsert);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.groupBox1.Location = new System.Drawing.Point(487, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 116);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ".CS for";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkDelete.Location = new System.Drawing.Point(15, 87);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(63, 17);
            this.chkDelete.TabIndex = 3;
            this.chkDelete.Text = "D&elete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkSelect.Location = new System.Drawing.Point(15, 67);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(61, 17);
            this.chkSelect.TabIndex = 2;
            this.chkSelect.Text = "&Select";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkUpdate.Location = new System.Drawing.Point(15, 47);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(66, 17);
            this.chkUpdate.TabIndex = 1;
            this.chkUpdate.Text = "U&pdate";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkInsert.Location = new System.Drawing.Point(15, 27);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(60, 17);
            this.chkInsert.TabIndex = 0;
            this.chkInsert.Text = "&Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(408, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkAll.Location = new System.Drawing.Point(463, 63);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(62, 17);
            this.chkAll.TabIndex = 8;
            this.chkAll.Text = "For All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkHasEvent_CheckedChanged);
            // 
            // DataGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(594, 355);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkPushButton);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkHasEvent);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReferesh);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblDataGridColumn);
            this.Controls.Add(this.lblDataKeyField);
            this.Controls.Add(this.cmbDataKeyField);
            this.Controls.Add(this.lstDataGridGolumns);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.cmbDatasourceForDataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCS);
            this.Controls.Add(this.btnHTML);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DataGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generation For DataGrid";
            this.Load += new System.EventHandler(this.DataGrid_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHTML;
        private System.Windows.Forms.Button btnCS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDatasourceForDataGrid;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ListBox lstDataGridGolumns;
        private System.Windows.Forms.ComboBox cmbDataKeyField;
        private System.Windows.Forms.Label lblDataKeyField;
        private System.Windows.Forms.Label lblDataGridColumn;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnReferesh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.CheckBox chkHasEvent;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkPushButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAll;
    }
}