using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Reflection;

namespace CompleteDataBaseAccess
{
    /// <summary>
    /// Summary description for DbPlusInOne.
    /// </summary>
    public class DbPlusInOne : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TabControl tbCommand;
        private System.Windows.Forms.TabPage tbClassess;
        private System.Windows.Forms.TabPage tbProcedure;
        private System.Windows.Forms.TabPage tbCodeGeneration;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblConnectionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblObject;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.CheckBox chkAllTables;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkSelect;

        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.ComboBox cmbProcedure;
        private System.Windows.Forms.ComboBox cmbConnectionName;
        private System.Windows.Forms.ComboBox cmbObjectPassed;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.ComboBox cmbTableForProcedures;

        private System.Windows.Forms.RadioButton rbtnSqlClient;
        private System.Windows.Forms.RadioButton rbtnOleDb;

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.TextBox txtCNPostFix;
        private System.Windows.Forms.TextBox txtPrivateVariablePreFix;
        private System.Windows.Forms.TextBox txtCNPreFix;
        private System.Windows.Forms.TextBox txtOutPut;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.TextBox txtProcCode;

        private System.Windows.Forms.Button btn_First;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_AddNew;
        private System.Windows.Forms.Button btn_ShowTableContent;
        private System.Windows.Forms.Button btn_GenerateBD;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private IContainer components;

        /// <summary>
        /// Required designer variable.
        /// </summary>

        #region Variable declaration

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtObject;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Button btnCopyCode;
        private Button btnMessage;
        private Button btnClearProc;
        private Button btnSettings;
        private CheckBox chkIsSelect;
        private Button btnColumns;

        int clmCounter = 0;
        ArrayList arrlstParameters;
        OleDbConnection conCC;
        OleDbDataAdapter oOleDbDataAdapterGetRecordsFromSelectedTable;
        DataSet _oDataSetHoldingTheMainTableData;
        DataSet dsTable;
        System.Data.DataTable dtTables = new DataTable();
        System.Data.DataTable dtTablesP = new DataTable();
        ArrayList arrlstTables;
        int rowCounter = 0;
        private PictureBox picErrorManagement;
        private ToolTip toolTip1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Button btnManager;
        private Button btnExport;
        public Label lblExport;
        private Button btnDataGrid;
        private Button btnCode;
        private Label lblCurrentTableName;
        private CheckBox chkIsTransaction;
        private CheckBox chkIsUniqueIdentifier;
        private Button btnMVC;
        private PictureBox imgReconnect;
        #endregion

        public DbPlusInOne(ArrayList arrlstConnectionString)
        {
            InitializeComponent();

            arrlstParameters = arrlstConnectionString;
            if (arrlstParameters.Count != 5)
                conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString());
            else
                conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbPlusInOne));
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.tbCommand = new System.Windows.Forms.TabControl();
            this.tbClassess = new System.Windows.Forms.TabPage();
            this.btnCode = new System.Windows.Forms.Button();
            this.btnDataGrid = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColumns = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.btn_First = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_AddNew = new System.Windows.Forms.Button();
            this.btn_ShowTableContent = new System.Windows.Forms.Button();
            this.btn_GenerateBD = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.txtCNPreFix = new System.Windows.Forms.TextBox();
            this.chkAllTables = new System.Windows.Forms.CheckBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.txtCNPostFix = new System.Windows.Forms.TextBox();
            this.txtPrivateVariablePreFix = new System.Windows.Forms.TextBox();
            this.tbProcedure = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsUniqueIdentifier = new System.Windows.Forms.CheckBox();
            this.chkIsTransaction = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.cmbTableForProcedures = new System.Windows.Forms.ComboBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrentTableName = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtOutPut = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tbCodeGeneration = new System.Windows.Forms.TabPage();
            this.btnCopyCode = new System.Windows.Forms.Button();
            this.txtProcCode = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkIsSelect = new System.Windows.Forms.CheckBox();
            this.btnClearProc = new System.Windows.Forms.Button();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.txtObject = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblConnectionName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProcedure = new System.Windows.Forms.ComboBox();
            this.cmbConnectionName = new System.Windows.Forms.ComboBox();
            this.cmbObjectPassed = new System.Windows.Forms.ComboBox();
            this.lblObject = new System.Windows.Forms.Label();
            this.rbtnOleDb = new System.Windows.Forms.RadioButton();
            this.rbtnSqlClient = new System.Windows.Forms.RadioButton();
            this.btnSettings = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.picErrorManagement = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imgReconnect = new System.Windows.Forms.PictureBox();
            this.btnManager = new System.Windows.Forms.Button();
            this.lblExport = new System.Windows.Forms.Label();
            this.btnMVC = new System.Windows.Forms.Button();
            this.tbCommand.SuspendLayout();
            this.tbClassess.SuspendLayout();
            this.tbProcedure.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbCodeGeneration.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgReconnect)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbDataBase.Location = new System.Drawing.Point(509, 3);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(141, 21);
            this.cmbDataBase.TabIndex = 0;
            this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
            // 
            // tbCommand
            // 
            this.tbCommand.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbCommand.Controls.Add(this.tbClassess);
            this.tbCommand.Controls.Add(this.tbProcedure);
            this.tbCommand.Controls.Add(this.tbCodeGeneration);
            this.tbCommand.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbCommand.Location = new System.Drawing.Point(0, 32);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.SelectedIndex = 0;
            this.tbCommand.ShowToolTips = true;
            this.tbCommand.Size = new System.Drawing.Size(662, 393);
            this.tbCommand.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbCommand.TabIndex = 2;
            // 
            // tbClassess
            // 
            this.tbClassess.AllowDrop = true;
            this.tbClassess.AutoScroll = true;
            this.tbClassess.BackColor = System.Drawing.Color.White;
            this.tbClassess.Controls.Add(this.btnMVC);
            this.tbClassess.Controls.Add(this.btnCode);
            this.tbClassess.Controls.Add(this.btnDataGrid);
            this.tbClassess.Controls.Add(this.btnExport);
            this.tbClassess.Controls.Add(this.label6);
            this.tbClassess.Controls.Add(this.label5);
            this.tbClassess.Controls.Add(this.label4);
            this.tbClassess.Controls.Add(this.label1);
            this.tbClassess.Controls.Add(this.btnColumns);
            this.tbClassess.Controls.Add(this.btnMessage);
            this.tbClassess.Controls.Add(this.btn_First);
            this.tbClassess.Controls.Add(this.btn_Previous);
            this.tbClassess.Controls.Add(this.btn_Next);
            this.tbClassess.Controls.Add(this.btn_Last);
            this.tbClassess.Controls.Add(this.panel1);
            this.tbClassess.Controls.Add(this.btn_AddNew);
            this.tbClassess.Controls.Add(this.btn_ShowTableContent);
            this.tbClassess.Controls.Add(this.btn_GenerateBD);
            this.tbClassess.Controls.Add(this.btn_Delete);
            this.tbClassess.Controls.Add(this.btn_Update);
            this.tbClassess.Controls.Add(this.btn_Add);
            this.tbClassess.Controls.Add(this.cmbTables);
            this.tbClassess.Controls.Add(this.txtCNPreFix);
            this.tbClassess.Controls.Add(this.chkAllTables);
            this.tbClassess.Controls.Add(this.txtNameSpace);
            this.tbClassess.Controls.Add(this.txtCNPostFix);
            this.tbClassess.Controls.Add(this.txtPrivateVariablePreFix);
            this.tbClassess.Location = new System.Drawing.Point(4, 25);
            this.tbClassess.Name = "tbClassess";
            this.tbClassess.Size = new System.Drawing.Size(654, 364);
            this.tbClassess.TabIndex = 0;
            this.tbClassess.Text = "Classes";
            // 
            // btnCode
            // 
            this.btnCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCode.Location = new System.Drawing.Point(597, 7);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(53, 29);
            this.btnCode.TabIndex = 29;
            this.btnCode.Text = "C";
            this.btnCode.UseVisualStyleBackColor = false;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // btnDataGrid
            // 
            this.btnDataGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnDataGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnDataGrid.Location = new System.Drawing.Point(543, 93);
            this.btnDataGrid.Name = "btnDataGrid";
            this.btnDataGrid.Size = new System.Drawing.Size(39, 22);
            this.btnDataGrid.TabIndex = 28;
            this.btnDataGrid.Text = "BO";
            this.btnDataGrid.UseVisualStyleBackColor = false;
            this.btnDataGrid.Click += new System.EventHandler(this.btnDataGrid_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnExport.Location = new System.Drawing.Point(369, 334);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(53, 22);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "EXP";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label6.Location = new System.Drawing.Point(316, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "ClassName Postfix";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label5.Location = new System.Drawing.Point(69, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Namespace";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label4.Location = new System.Drawing.Point(58, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Private Prefix";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label1.Location = new System.Drawing.Point(321, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "ClassName Prefix";
            // 
            // btnColumns
            // 
            this.btnColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnColumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnColumns.Location = new System.Drawing.Point(428, 334);
            this.btnColumns.Name = "btnColumns";
            this.btnColumns.Size = new System.Drawing.Size(74, 22);
            this.btnColumns.TabIndex = 17;
            this.btnColumns.Text = "Columns";
            this.btnColumns.UseVisualStyleBackColor = false;
            this.btnColumns.Visible = false;
            this.btnColumns.Click += new System.EventHandler(this.btnColumns_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnMessage.Location = new System.Drawing.Point(508, 334);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(74, 22);
            this.btnMessage.TabIndex = 18;
            this.btnMessage.Text = "&Message";
            this.btnMessage.UseVisualStyleBackColor = false;
            this.btnMessage.Visible = false;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // btn_First
            // 
            this.btn_First.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_First.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_First.Location = new System.Drawing.Point(78, 334);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(53, 22);
            this.btn_First.TabIndex = 13;
            this.btn_First.Text = "|<";
            this.btn_First.UseVisualStyleBackColor = false;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_Previous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_Previous.Location = new System.Drawing.Point(137, 334);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(53, 22);
            this.btn_Previous.TabIndex = 14;
            this.btn_Previous.Text = "<";
            this.btn_Previous.UseVisualStyleBackColor = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_Next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_Next.Location = new System.Drawing.Point(196, 334);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(53, 22);
            this.btn_Next.TabIndex = 15;
            this.btn_Next.Text = ">";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_Last.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_Last.Location = new System.Drawing.Point(255, 334);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(53, 22);
            this.btn_Last.TabIndex = 16;
            this.btn_Last.Text = ">|";
            this.btn_Last.UseVisualStyleBackColor = false;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.panel1.Location = new System.Drawing.Point(78, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 212);
            this.panel1.TabIndex = 12;
            // 
            // btn_AddNew
            // 
            this.btn_AddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_AddNew.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_AddNew.Location = new System.Drawing.Point(158, 93);
            this.btn_AddNew.Name = "btn_AddNew";
            this.btn_AddNew.Size = new System.Drawing.Size(74, 22);
            this.btn_AddNew.TabIndex = 7;
            this.btn_AddNew.Text = "N&ew";
            this.btn_AddNew.UseVisualStyleBackColor = false;
            this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
            // 
            // btn_ShowTableContent
            // 
            this.btn_ShowTableContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_ShowTableContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_ShowTableContent.Location = new System.Drawing.Point(78, 93);
            this.btn_ShowTableContent.Name = "btn_ShowTableContent";
            this.btn_ShowTableContent.Size = new System.Drawing.Size(74, 22);
            this.btn_ShowTableContent.TabIndex = 6;
            this.btn_ShowTableContent.Text = "Sho&w";
            this.btn_ShowTableContent.UseVisualStyleBackColor = false;
            this.btn_ShowTableContent.Click += new System.EventHandler(this.btn_ShowTableContent_Click);
            // 
            // btn_GenerateBD
            // 
            this.btn_GenerateBD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_GenerateBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_GenerateBD.Location = new System.Drawing.Point(501, 93);
            this.btn_GenerateBD.Name = "btn_GenerateBD";
            this.btn_GenerateBD.Size = new System.Drawing.Size(36, 22);
            this.btn_GenerateBD.TabIndex = 11;
            this.btn_GenerateBD.Text = "BD";
            this.btn_GenerateBD.UseVisualStyleBackColor = false;
            this.btn_GenerateBD.Click += new System.EventHandler(this.btn_GenerateBD_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_Delete.Location = new System.Drawing.Point(398, 93);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(74, 22);
            this.btn_Delete.TabIndex = 10;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_Update.Location = new System.Drawing.Point(318, 93);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(74, 22);
            this.btn_Update.TabIndex = 9;
            this.btn_Update.Text = "&Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btn_Add.Location = new System.Drawing.Point(238, 93);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(74, 22);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = "&Insert";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // cmbTables
            // 
            this.cmbTables.BackColor = System.Drawing.Color.White;
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbTables.Location = new System.Drawing.Point(6, 5);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(306, 21);
            this.cmbTables.TabIndex = 0;
            // 
            // txtCNPreFix
            // 
            this.txtCNPreFix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtCNPreFix.Location = new System.Drawing.Point(435, 32);
            this.txtCNPreFix.Name = "txtCNPreFix";
            this.txtCNPreFix.Size = new System.Drawing.Size(147, 21);
            this.txtCNPreFix.TabIndex = 3;
            this.txtCNPreFix.Text = "clsBD";
            this.txtCNPreFix.TextChanged += new System.EventHandler(this.txtCNPreFix_TextChanged);
            this.txtCNPreFix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCNPreFix_KeyPress);
            // 
            // chkAllTables
            // 
            this.chkAllTables.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkAllTables.Location = new System.Drawing.Point(316, 7);
            this.chkAllTables.Name = "chkAllTables";
            this.chkAllTables.Size = new System.Drawing.Size(251, 16);
            this.chkAllTables.TabIndex = 1;
            this.chkAllTables.Text = "Check To Generate Class for all tables.";
            this.chkAllTables.UseVisualStyleBackColor = false;
            this.chkAllTables.CheckedChanged += new System.EventHandler(this.chkAllTables_CheckedChanged);
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtNameSpace.Location = new System.Drawing.Point(148, 32);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(164, 21);
            this.txtNameSpace.TabIndex = 2;
            this.txtNameSpace.Text = "C_ERP.BusinessData";
            // 
            // txtCNPostFix
            // 
            this.txtCNPostFix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtCNPostFix.Location = new System.Drawing.Point(435, 57);
            this.txtCNPostFix.Name = "txtCNPostFix";
            this.txtCNPostFix.Size = new System.Drawing.Size(147, 21);
            this.txtCNPostFix.TabIndex = 5;
            // 
            // txtPrivateVariablePreFix
            // 
            this.txtPrivateVariablePreFix.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtPrivateVariablePreFix.Location = new System.Drawing.Point(148, 57);
            this.txtPrivateVariablePreFix.Name = "txtPrivateVariablePreFix";
            this.txtPrivateVariablePreFix.Size = new System.Drawing.Size(164, 21);
            this.txtPrivateVariablePreFix.TabIndex = 4;
            this.txtPrivateVariablePreFix.Text = "_";
            // 
            // tbProcedure
            // 
            this.tbProcedure.BackColor = System.Drawing.Color.Transparent;
            this.tbProcedure.Controls.Add(this.groupBox2);
            this.tbProcedure.Controls.Add(this.groupBox3);
            this.tbProcedure.Location = new System.Drawing.Point(4, 25);
            this.tbProcedure.Name = "tbProcedure";
            this.tbProcedure.Size = new System.Drawing.Size(654, 364);
            this.tbProcedure.TabIndex = 1;
            this.tbProcedure.Text = "Procedures";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.chkIsUniqueIdentifier);
            this.groupBox2.Controls.Add(this.chkIsTransaction);
            this.groupBox2.Controls.Add(this.chkDelete);
            this.groupBox2.Controls.Add(this.cmbTableForProcedures);
            this.groupBox2.Controls.Add(this.chkUpdate);
            this.groupBox2.Controls.Add(this.chkInsert);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.chkSelect);
            this.groupBox2.Location = new System.Drawing.Point(1, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 57);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // chkIsUniqueIdentifier
            // 
            this.chkIsUniqueIdentifier.BackColor = System.Drawing.Color.Transparent;
            this.chkIsUniqueIdentifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkIsUniqueIdentifier.Location = new System.Drawing.Point(377, 38);
            this.chkIsUniqueIdentifier.Name = "chkIsUniqueIdentifier";
            this.chkIsUniqueIdentifier.Size = new System.Drawing.Size(136, 16);
            this.chkIsUniqueIdentifier.TabIndex = 6;
            this.chkIsUniqueIdentifier.Text = "Is &UniqueIdentifier";
            this.chkIsUniqueIdentifier.UseVisualStyleBackColor = false;
            // 
            // chkIsTransaction
            // 
            this.chkIsTransaction.BackColor = System.Drawing.Color.Transparent;
            this.chkIsTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkIsTransaction.Location = new System.Drawing.Point(270, 37);
            this.chkIsTransaction.Name = "chkIsTransaction";
            this.chkIsTransaction.Size = new System.Drawing.Size(109, 16);
            this.chkIsTransaction.TabIndex = 6;
            this.chkIsTransaction.Text = "Is &Transaction";
            this.chkIsTransaction.UseVisualStyleBackColor = false;
            // 
            // chkDelete
            // 
            this.chkDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkDelete.Location = new System.Drawing.Point(500, 15);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(63, 15);
            this.chkDelete.TabIndex = 3;
            this.chkDelete.Text = "&Delete";
            this.chkDelete.UseVisualStyleBackColor = false;
            // 
            // cmbTableForProcedures
            // 
            this.cmbTableForProcedures.BackColor = System.Drawing.SystemColors.Window;
            this.cmbTableForProcedures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTableForProcedures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbTableForProcedures.Location = new System.Drawing.Point(5, 12);
            this.cmbTableForProcedures.Name = "cmbTableForProcedures";
            this.cmbTableForProcedures.Size = new System.Drawing.Size(358, 21);
            this.cmbTableForProcedures.TabIndex = 0;
            this.cmbTableForProcedures.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.BackColor = System.Drawing.Color.Transparent;
            this.chkUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkUpdate.Location = new System.Drawing.Point(431, 14);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(66, 17);
            this.chkUpdate.TabIndex = 2;
            this.chkUpdate.Text = "&Update";
            this.chkUpdate.UseVisualStyleBackColor = false;
            // 
            // chkInsert
            // 
            this.chkInsert.BackColor = System.Drawing.Color.Transparent;
            this.chkInsert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkInsert.Location = new System.Drawing.Point(369, 14);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(60, 16);
            this.chkInsert.TabIndex = 1;
            this.chkInsert.Text = "&Insert";
            this.chkInsert.UseVisualStyleBackColor = false;
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkAll.Location = new System.Drawing.Point(5, 38);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(306, 15);
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "Check to Create Procedures for Al&l Tables";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkSelect
            // 
            this.chkSelect.BackColor = System.Drawing.Color.Transparent;
            this.chkSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkSelect.Location = new System.Drawing.Point(567, 14);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(69, 16);
            this.chkSelect.TabIndex = 4;
            this.chkSelect.Text = "&Select";
            this.chkSelect.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.lblCurrentTableName);
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Controls.Add(this.btnSaveAs);
            this.groupBox3.Controls.Add(this.btnRun);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.txtOutPut);
            this.groupBox3.Controls.Add(this.btnCreate);
            this.groupBox3.Location = new System.Drawing.Point(0, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(658, 318);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // lblCurrentTableName
            // 
            this.lblCurrentTableName.AutoSize = true;
            this.lblCurrentTableName.Location = new System.Drawing.Point(135, 294);
            this.lblCurrentTableName.Name = "lblCurrentTableName";
            this.lblCurrentTableName.Size = new System.Drawing.Size(41, 13);
            this.lblCurrentTableName.TabIndex = 5;
            this.lblCurrentTableName.Text = "label7";
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCopy.Location = new System.Drawing.Point(6, 289);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(123, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy &To Clipboard";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnSaveAs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnSaveAs.Location = new System.Drawing.Point(492, 289);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 1;
            this.btnSaveAs.Text = "Save &As...";
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnRun.Location = new System.Drawing.Point(332, 289);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnClear.Location = new System.Drawing.Point(571, 289);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Cl&ear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtOutPut
            // 
            this.txtOutPut.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutPut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtOutPut.Location = new System.Drawing.Point(6, 13);
            this.txtOutPut.Multiline = true;
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutPut.Size = new System.Drawing.Size(640, 270);
            this.txtOutPut.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCreate.Location = new System.Drawing.Point(412, 289);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tbCodeGeneration
            // 
            this.tbCodeGeneration.BackColor = System.Drawing.Color.White;
            this.tbCodeGeneration.Controls.Add(this.btnCopyCode);
            this.tbCodeGeneration.Controls.Add(this.txtProcCode);
            this.tbCodeGeneration.Controls.Add(this.groupBox4);
            this.tbCodeGeneration.Location = new System.Drawing.Point(4, 25);
            this.tbCodeGeneration.Name = "tbCodeGeneration";
            this.tbCodeGeneration.Size = new System.Drawing.Size(654, 364);
            this.tbCodeGeneration.TabIndex = 2;
            this.tbCodeGeneration.Text = "Code Generation";
            // 
            // btnCopyCode
            // 
            this.btnCopyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnCopyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnCopyCode.Location = new System.Drawing.Point(2, 340);
            this.btnCopyCode.Name = "btnCopyCode";
            this.btnCopyCode.Size = new System.Drawing.Size(125, 21);
            this.btnCopyCode.TabIndex = 21;
            this.btnCopyCode.Text = "Copy To Clipboard";
            this.btnCopyCode.UseVisualStyleBackColor = false;
            this.btnCopyCode.Click += new System.EventHandler(this.btnCopyCode_Click);
            // 
            // txtProcCode
            // 
            this.txtProcCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtProcCode.Location = new System.Drawing.Point(2, 94);
            this.txtProcCode.Multiline = true;
            this.txtProcCode.Name = "txtProcCode";
            this.txtProcCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProcCode.Size = new System.Drawing.Size(641, 240);
            this.txtProcCode.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkIsSelect);
            this.groupBox4.Controls.Add(this.btnClearProc);
            this.groupBox4.Controls.Add(this.txtConnection);
            this.groupBox4.Controls.Add(this.txtObject);
            this.groupBox4.Controls.Add(this.btnGenerate);
            this.groupBox4.Controls.Add(this.lblConnectionName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cmbProcedure);
            this.groupBox4.Controls.Add(this.cmbConnectionName);
            this.groupBox4.Controls.Add(this.cmbObjectPassed);
            this.groupBox4.Controls.Add(this.lblObject);
            this.groupBox4.Controls.Add(this.rbtnOleDb);
            this.groupBox4.Controls.Add(this.rbtnSqlClient);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(648, 91);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // chkIsSelect
            // 
            this.chkIsSelect.AutoSize = true;
            this.chkIsSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.chkIsSelect.Location = new System.Drawing.Point(453, 17);
            this.chkIsSelect.Name = "chkIsSelect";
            this.chkIsSelect.Size = new System.Drawing.Size(76, 17);
            this.chkIsSelect.TabIndex = 17;
            this.chkIsSelect.Text = "Is Select";
            this.chkIsSelect.UseVisualStyleBackColor = true;
            // 
            // btnClearProc
            // 
            this.btnClearProc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnClearProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnClearProc.Location = new System.Drawing.Point(416, 66);
            this.btnClearProc.Name = "btnClearProc";
            this.btnClearProc.Size = new System.Drawing.Size(103, 23);
            this.btnClearProc.TabIndex = 16;
            this.btnClearProc.Text = "&Clear";
            this.btnClearProc.UseVisualStyleBackColor = false;
            this.btnClearProc.Click += new System.EventHandler(this.btnClearProc_Click);
            // 
            // txtConnection
            // 
            this.txtConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtConnection.Location = new System.Drawing.Point(120, 64);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(182, 21);
            this.txtConnection.TabIndex = 2;
            // 
            // txtObject
            // 
            this.txtObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtObject.Location = new System.Drawing.Point(120, 40);
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(182, 21);
            this.txtObject.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnGenerate.Location = new System.Drawing.Point(306, 66);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(104, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "&Generate Code";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.lblConnectionName.Location = new System.Drawing.Point(8, 64);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(106, 16);
            this.lblConnectionName.TabIndex = 11;
            this.lblConnectionName.Text = "Connection Name";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Procedure";
            // 
            // cmbProcedure
            // 
            this.cmbProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcedure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.cmbProcedure.Location = new System.Drawing.Point(120, 16);
            this.cmbProcedure.Name = "cmbProcedure";
            this.cmbProcedure.Size = new System.Drawing.Size(327, 21);
            this.cmbProcedure.TabIndex = 0;
            // 
            // cmbConnectionName
            // 
            this.cmbConnectionName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(136)))));
            this.cmbConnectionName.Location = new System.Drawing.Point(630, 40);
            this.cmbConnectionName.Name = "cmbConnectionName";
            this.cmbConnectionName.Size = new System.Drawing.Size(184, 21);
            this.cmbConnectionName.TabIndex = 2;
            this.cmbConnectionName.Visible = false;
            // 
            // cmbObjectPassed
            // 
            this.cmbObjectPassed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(136)))));
            this.cmbObjectPassed.Location = new System.Drawing.Point(630, 16);
            this.cmbObjectPassed.Name = "cmbObjectPassed";
            this.cmbObjectPassed.Size = new System.Drawing.Size(184, 21);
            this.cmbObjectPassed.TabIndex = 1;
            this.cmbObjectPassed.Visible = false;
            // 
            // lblObject
            // 
            this.lblObject.BackColor = System.Drawing.Color.Transparent;
            this.lblObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.lblObject.Location = new System.Drawing.Point(10, 43);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(89, 16);
            this.lblObject.TabIndex = 6;
            this.lblObject.Text = "Object Passed";
            // 
            // rbtnOleDb
            // 
            this.rbtnOleDb.BackColor = System.Drawing.Color.Transparent;
            this.rbtnOleDb.Checked = true;
            this.rbtnOleDb.ForeColor = System.Drawing.Color.SteelBlue;
            this.rbtnOleDb.Location = new System.Drawing.Point(307, 45);
            this.rbtnOleDb.Name = "rbtnOleDb";
            this.rbtnOleDb.Size = new System.Drawing.Size(61, 16);
            this.rbtnOleDb.TabIndex = 3;
            this.rbtnOleDb.TabStop = true;
            this.rbtnOleDb.Text = "&OleDb";
            this.rbtnOleDb.UseVisualStyleBackColor = false;
            // 
            // rbtnSqlClient
            // 
            this.rbtnSqlClient.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSqlClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.rbtnSqlClient.Location = new System.Drawing.Point(370, 45);
            this.rbtnSqlClient.Name = "rbtnSqlClient";
            this.rbtnSqlClient.Size = new System.Drawing.Size(77, 16);
            this.rbtnSqlClient.TabIndex = 4;
            this.rbtnSqlClient.Text = "&SqlClient";
            this.rbtnSqlClient.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnSettings.Location = new System.Drawing.Point(554, 32);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 23);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "&Settings...";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.label3.Location = new System.Drawing.Point(448, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Database";
            // 
            // picErrorManagement
            // 
            this.picErrorManagement.BackColor = System.Drawing.Color.Transparent;
            this.picErrorManagement.Image = ((System.Drawing.Image)(resources.GetObject("picErrorManagement.Image")));
            this.picErrorManagement.Location = new System.Drawing.Point(404, 3);
            this.picErrorManagement.Name = "picErrorManagement";
            this.picErrorManagement.Size = new System.Drawing.Size(18, 19);
            this.picErrorManagement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picErrorManagement.TabIndex = 24;
            this.picErrorManagement.TabStop = false;
            this.picErrorManagement.Click += new System.EventHandler(this.picErrorManagement_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolTip1.ForeColor = System.Drawing.Color.Red;
            this.toolTip1.Tag = "Erros";
            // 
            // imgReconnect
            // 
            this.imgReconnect.Image = ((System.Drawing.Image)(resources.GetObject("imgReconnect.Image")));
            this.imgReconnect.Location = new System.Drawing.Point(428, 3);
            this.imgReconnect.Name = "imgReconnect";
            this.imgReconnect.Size = new System.Drawing.Size(18, 19);
            this.imgReconnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgReconnect.TabIndex = 25;
            this.imgReconnect.TabStop = false;
            this.imgReconnect.Click += new System.EventHandler(this.imgReconnect_Click);
            // 
            // btnManager
            // 
            this.btnManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnManager.Location = new System.Drawing.Point(448, 32);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(100, 23);
            this.btnManager.TabIndex = 26;
            this.btnManager.Text = "&Enterprise Manager";
            this.btnManager.UseVisualStyleBackColor = false;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // lblExport
            // 
            this.lblExport.AutoSize = true;
            this.lblExport.Location = new System.Drawing.Point(12, 428);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(0, 13);
            this.lblExport.TabIndex = 27;
            // 
            // btnMVC
            // 
            this.btnMVC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.btnMVC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(57)))), ((int)(((byte)(13)))));
            this.btnMVC.Location = new System.Drawing.Point(597, 42);
            this.btnMVC.Name = "btnMVC";
            this.btnMVC.Size = new System.Drawing.Size(53, 29);
            this.btnMVC.TabIndex = 29;
            this.btnMVC.Text = "MVC";
            this.btnMVC.UseVisualStyleBackColor = false;
            this.btnMVC.Click += new System.EventHandler(this.btnMVC_Click);
            // 
            // DbPlusInOne
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 456);
            this.Controls.Add(this.lblExport);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.imgReconnect);
            this.Controls.Add(this.picErrorManagement);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.cmbDataBase);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DbPlusInOne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Db Plus";
            this.Load += new System.EventHandler(this.DbPlusInOne_Load);
            this.tbCommand.ResumeLayout(false);
            this.tbClassess.ResumeLayout(false);
            this.tbClassess.PerformLayout();
            this.tbProcedure.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbCodeGeneration.ResumeLayout(false);
            this.tbCodeGeneration.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgReconnect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region ClassesTab
        void RegionClass()
        {
            try
            {
                //check for directory exist.
                if (!System.IO.Directory.Exists(@"C:\CompleteDataBaseAccess"))
                {
                    //creating a directory.
                    System.IO.Directory.CreateDirectory(@"C:\CompleteDataBaseAccess");
                }
                OleDbCommand objOleDbCommand;
                //condition check for sql server or mysql.
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    //initialize the command for getting all the table of sql sever selected database.
                    objOleDbCommand = new OleDbCommand("sp_tables", conCC);
                }
                else
                {
                    //reset connection to the information_schema for getting tables of selected database from mysql database.
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=Information_Schema");
                    //initialize the command for getting all the table of mysql selected database.
                    objOleDbCommand = new OleDbCommand("SELECT '0' AS 'Column1', '0' AS 'Column2', TABLE_NAME, Table_Type FROM TABLES WHERE TABLE_SCHEMA='" + cmbDataBase.Text + "'", conCC);
                }
                //check for connection state.
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                //initializing a data adapter for getting tables from the database.
                OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                //clearing the global table of database tables collection.
                dtTables.Rows.Clear();
                //re-initialize the arraylist contains table names of the selected database.
                arrlstTables = new ArrayList();
                //filling the global datatable of tables.
                daTables.Fill(dtTables);
                //clearing the combo of tables of classes region.
                cmbTables.Items.Clear();
                //loop for filling the table combo.
                foreach (DataRow dr in dtTables.Rows)
                {
                    //check for table and non system table.
                    if (dr[3].ToString().IndexOf("TABLE") != -1 || dr[3].ToString().IndexOf("SYSTEM VIEW") != -1)
                    {
                        //excluding the dtproperties table.
                        if (dr[2].ToString() != "dtproperties" && dr[3].ToString().IndexOf("SYS") == -1 && dr[2].ToString().StartsWith(System.Configuration.ConfigurationSettings.AppSettings["strTableInitial"]))
                        {
                            //adding a tablename into combo of table.
                            cmbTables.Items.Add(dr[2].ToString());
                            //adding a tablename into arraylist containing the table name(s).
                            arrlstTables.Add(dr[2].ToString());
                        }
                    }
                }
                //closing the connection.
                conCC.Close();
                //re-initialize the connection for selected database.
                conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + cmbDataBase.Text);
                //i = 0;
            }
            catch (Exception ex)
            {
                //inserting the error into a xml file.
                insError(ex.ToString());
            }
        }

        #endregion

        #region ProcedureCode
        void CodeForProcedure()
        {
            try
            {
                #region Getting the list of procedure of SQL Server
                //condition check for sql server or mysql.
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    //checking for the connection state
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    //initialize command to getting all the procedure from sql server for selected database.
                    OleDbCommand cmdGetProc = new OleDbCommand("SP_HELP", conCC);
                    //defining the connection type.
                    cmdGetProc.CommandType = CommandType.StoredProcedure;
                    //declare and initialize the dataReader for holding procedure name(s) of selected database.
                    OleDbDataReader drProc = cmdGetProc.ExecuteReader();
                    //clearing all the item(s) from the procedure combo of code generation.
                    cmbProcedure.Items.Clear();
                    //condition for end of the record.
                    while (drProc.Read())
                    {
                        //condition for extracting stored procedure.
                        if (drProc[2].ToString() == "stored procedure")
                        {
                            if (drProc[0].ToString().Substring(0, 2) != "dt")
                            {
                                //adding stored procedure's name to the combo.
                                cmbProcedure.Items.Add(drProc[0].ToString());
                            }
                        }
                    }
                    //closing the connection.
                    conCC.Close();
                }
                #endregion
                #region Getting the list of procedure of MySQL
                else
                {
                    //reset the connection to mysql to getting all the record from the MySQL for selected database.
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=mysql");
                    //check for connection state.
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    //declaring and initializing the command to getting all the procedure of selected database.
                    OleDbCommand cmdGetProc = new OleDbCommand("SELECT Name FROM mysql.proc WHERE DB='" + cmbDataBase.Text + "'", conCC);
                    //declaring and initializing the dataReader for holding the procedure's names.
                    OleDbDataReader drProc = cmdGetProc.ExecuteReader();
                    //clearing the combo of procedure name for generating code.
                    cmbProcedure.Items.Clear();
                    //check for end of record.
                    while (drProc.Read())
                    {
                        //adding a procedure name into the combo.
                        cmbProcedure.Items.Add(drProc[0].ToString());
                    }
                    //closing the connection.
                    conCC.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                //inserting the error.
                insError(ex.ToString());
            }

        }
        #endregion

        #region Run time pannel

        #region Pannel According To The Table Selection

        /// <summary>
        /// function to create the pannel according to the table selected.
        /// </summary>
        void fillPannelAccordingToTheTableSelection()
        {
            try
            {
                //button to a new record into selected table is set enable to true.
                this.btn_AddNew.Enabled = true;
                //button to navigate the record jump to first is set enable to true.
                this.btn_First.Enabled = true;
                //button to generate Property Class file for the selected table is set enable to true.
                this.btn_GenerateBD.Enabled = true;
                //button to navigate the record at last possion is set enable to true.
                this.btn_Last.Enabled = true;
                //button to navigate the record one step forward is set enable to ture.
                this.btn_Next.Enabled = true;
                //button to insert a record is set enable to false.
                this.btn_Add.Enabled = false;
                //button to navigate the record one step backword is set enable to true.
                this.btn_Previous.Enabled = true;
                //condition check for sql server or mysql.
                if (arrlstParameters[3].ToString().ToLower() != "sqloledb")
                {
                    //reset the connection to mysql to getting all the record from the MySQL for selected database.
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + cmbDataBase.Text);
                }
                //check for connection state.
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                //initializing a command for getting all the data of selecte table.
                OleDbCommand oOleDbCommandSelectDataFromSelectedTable = new OleDbCommand("select * from " + this.cmbTables.Text, conCC);
                //initializing the data adapter for getting the table data.
                oOleDbDataAdapterGetRecordsFromSelectedTable = new OleDbDataAdapter(oOleDbCommandSelectDataFromSelectedTable);
                //clearing the data from the main dataset which holds the main table records.
                _oDataSetHoldingTheMainTableData = new DataSet();
                //filling the main dataset.
                oOleDbDataAdapterGetRecordsFromSelectedTable.Fill(_oDataSetHoldingTheMainTableData, "dTabels");
                //clear all the controls from the pannel.
                panel1.Controls.Clear();
                //increamentor for pannel controls.
                int iCounterForControlsInPannel = 0;
                //loop for table columns.
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    //defining a lable for pannel
                    System.Windows.Forms.Label lbl = new Label();
                    //assigning the width to the lable.
                    lbl.Width = 130;
                    //set left possion of lable.
                    lbl.Left = 50;
                    //set top possion of lable.
                    lbl.Top = 5 + iCounterForControlsInPannel * 25;
                    //set forcolor of lable.
                    //lbl.ForeColor = System.Drawing.Color.FromArgb(156, 86, 136);
                    //set name of the lable.
                    lbl.Text = objDataColumn.ColumnName;

                    //defining a textbox for pannel.
                    System.Windows.Forms.TextBox txt = new TextBox();
                    //set top possion of textbox.
                    txt.Top = 5 + iCounterForControlsInPannel * 25;
                    //set width of textbox.
                    txt.Width = 250;
                    //set height of textbox.
                    txt.Height = 16;
                    //set left possion of textbox.
                    txt.Left = 190;
                    //set forcolor of textbox.
                    //txt.ForeColor=Color.FromArgb(156, 86, 136);

                    //adding the lable to the pannel.
                    panel1.Controls.Add(lbl);
                    //adding the textbox to the pannel.
                    panel1.Controls.Add(txt);
                    //increament for pannel controls
                    iCounterForControlsInPannel += 1;
                }
            }
            catch (Exception ex)
            {
                //inserting the error.
                insError(ex.ToString());
            }
            finally
            {
                //close the connection.
                conCC.Close();
            }
        }
        #endregion

        #region Add New Click
        /// <summary>
        /// function to clear all the data from pannel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                //button to insert a record is set enable to true.
                this.btn_Add.Enabled = true;
                //counter for columns of main table is set to 0.
                clmCounter = 0;
                //loop for clearing all the value(s) on pannel's controls
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    //n-th value is clear from the pannel.
                    panel1.Controls[1 + clmCounter * 2].Text = "";
                    //increament the column counter of main table.
                    clmCounter = clmCounter + 1;
                }
                //button to reset all the controls on pannel is set enable to false.
                this.btn_AddNew.Enabled = false;
            }
            catch (Exception ex)
            {
                //inserting the error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Insert record
        /// <summary>
        /// function to insert a record to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, System.EventArgs e)
        {
            try
            {
                //button to reset all the controls on pannel is set enable to true.
                this.btn_AddNew.Enabled = true;
                //declare a new row for main table.
                DataRow objDataRow = _oDataSetHoldingTheMainTableData.Tables[0].NewRow();
                //set counter for main table's columns to 0.
                clmCounter = 0;
                //loop for main table's columns.
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    //set the value in new row.
                    objDataRow[clmCounter] = panel1.Controls[1 + clmCounter * 2].Text;
                    //increament the column counter for the main table.
                    clmCounter = clmCounter + 1;
                }
                //adding a new row in the main table.
                _oDataSetHoldingTheMainTableData.Tables[0].Rows.Add(objDataRow);
                //defining command builder to updating the actual database.
                OleDbCommandBuilder objOleDbCommandBuilder = new OleDbCommandBuilder(oOleDbDataAdapterGetRecordsFromSelectedTable);
                //set command to dataadapter to update the actual database.
                oOleDbDataAdapterGetRecordsFromSelectedTable.InsertCommand = objOleDbCommandBuilder.GetInsertCommand();
                //update the actual database.
                oOleDbDataAdapterGetRecordsFromSelectedTable.Update(_oDataSetHoldingTheMainTableData, "dTabels");
                //button to insert a record is set enable to false.
                this.btn_Add.Enabled = false;
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Update Record
        /// <summary>
        /// function to update record to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, System.EventArgs e)
        {
            try
            {
                //reset column counter of main table.
                clmCounter = 0;
                //loop for columns of main table.
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    //getting data for updation.
                    (_oDataSetHoldingTheMainTableData.Tables[0].Rows[rowCounter])[clmCounter] = panel1.Controls[1 + clmCounter * 2].Text;
                    //increase column counter by 1.
                    clmCounter = clmCounter + 1;
                }
                //declare a command builder for updation on main database.
                OleDbCommandBuilder objOleDbCommandBuilder = new OleDbCommandBuilder(oOleDbDataAdapterGetRecordsFromSelectedTable);
                //assigning commands to adapter for updating the actual record.
                oOleDbDataAdapterGetRecordsFromSelectedTable.UpdateCommand = objOleDbCommandBuilder.GetUpdateCommand();
                oOleDbDataAdapterGetRecordsFromSelectedTable.InsertCommand = objOleDbCommandBuilder.GetInsertCommand();
                oOleDbDataAdapterGetRecordsFromSelectedTable.DeleteCommand = objOleDbCommandBuilder.GetDeleteCommand();
                //finally update the record to database.
                oOleDbDataAdapterGetRecordsFromSelectedTable.Update(_oDataSetHoldingTheMainTableData, "dTabels");
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Delete Record
        /// <summary>
        /// function to delete record from the database.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void btn_Delete_Click(object sender, System.EventArgs e)
        {
            try
            {
                //check for connection state.
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                //initialize command for delete record from database.
                OleDbCommand oOleDbCommandDeleteRecord = new OleDbCommand("DELETE FROM " + cmbTables.Text + " WHERE " + _oDataSetHoldingTheMainTableData.Tables[0].Columns[0].ColumnName + " = '" + this.panel1.Controls[1 + 0].Text + "'", conCC);
                //executing the query.
                oOleDbCommandDeleteRecord.ExecuteNonQuery();
                //remove deleted record from the global dataset.
                _oDataSetHoldingTheMainTableData.Tables[0].Rows.Remove(_oDataSetHoldingTheMainTableData.Tables[0].Rows[rowCounter]);
                //closing the connection.
                conCC.Close();
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region First Record
        /// <summary>
        /// function to navigate the record to its first possition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_First_Click(object sender, System.EventArgs e)
        {
            try
            {
                //button to update the actual record is set enable to true.
                btn_Update.Enabled = true;
                //button to delete the actual record is set enable to true.
                btn_Delete.Enabled = true;
                //reset column counter for global dataset.
                clmCounter = 0;
                //reset row counter for global dataset.
                rowCounter = 0;
                //condition for checking existance of records in the global dataset.
                if (_oDataSetHoldingTheMainTableData.Tables[0].Rows.Count > 0)
                {
                    //loop for column of global dataset
                    foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    {
                        //set data to appropriate control of pannel.
                        panel1.Controls[1 + clmCounter * 2].Text = (_oDataSetHoldingTheMainTableData.Tables[0].Rows[0])[objDataColumn.ColumnName].ToString();
                        //increase the column counter.
                        clmCounter = clmCounter + 1;
                    }
                }
                else
                {
                    //throw a message for no record.
                    MessageBox.Show("Table Has No Row.");
                }
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Prev record
        /// <summary>
        /// function to navigate the record a step in forward direction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Previous_Click(object sender, System.EventArgs e)
        {
            try
            {
                //button to update the actual record is set enable to true.
                this.btn_Update.Enabled = true;
                //button to delete the actual record is set enable to true.
                this.btn_Delete.Enabled = true;
                //reset column counter of global dataset.
                clmCounter = 0;
                //decrease row counter of global dataset.
                rowCounter = rowCounter - 1;
                //condition for -1 record.
                if (rowCounter < 0)
                {
                    //reset to first record.
                    rowCounter = 0;
                }
                //condition to check existance of records.
                if (_oDataSetHoldingTheMainTableData.Tables[0].Rows.Count > 0)
                {
                    //loop for columns of global dataset.
                    foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    {
                        //set data to appropriate control of pannel.
                        panel1.Controls[1 + clmCounter * 2].Text = (_oDataSetHoldingTheMainTableData.Tables[0].Rows[rowCounter])[objDataColumn.ColumnName].ToString();
                        //increase column counter by 1.
                        clmCounter = clmCounter + 1;
                    }
                }
                else
                {
                    //throw message for no record.
                    MessageBox.Show("Table Has No Row.");
                }
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Next record
        /// <summary>
        /// function to navigate the record on step forward.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_Click(object sender, System.EventArgs e)
        {
            try
            {
                //button to update the actual record is set enable to true.
                btn_Update.Enabled = true;
                //button to delete the actual record is set enable to true.
                btn_Delete.Enabled = true;
                //reset the column counter for global dataset.
                clmCounter = 0;
                //increase row counter by 1.
                rowCounter = rowCounter + 1;
                //condition for last record.
                if (rowCounter > _oDataSetHoldingTheMainTableData.Tables[0].Rows.Count - 1)
                {
                    //set row counter to last record.
                    rowCounter = _oDataSetHoldingTheMainTableData.Tables[0].Rows.Count - 1;
                }
                //condition to check existance the records.
                if (_oDataSetHoldingTheMainTableData.Tables[0].Rows.Count > 0)
                {
                    //loop for columns of global dataset.
                    foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    {
                        //set data to appropriate control of pannel.
                        panel1.Controls[1 + clmCounter * 2].Text = (_oDataSetHoldingTheMainTableData.Tables[0].Rows[rowCounter])[objDataColumn.ColumnName].ToString();
                        //increase column counter by 1.
                        clmCounter = clmCounter + 1;
                    }
                }
                else
                {
                    //throw a message is table has no row.
                    MessageBox.Show("Table Has No Row.");
                }
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Jump to last record
        /// <summary>
        /// function to navigate the record to last.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Last_Click(object sender, System.EventArgs e)
        {
            try
            {
                //button to update the actual record is set enable to true.
                this.btn_Update.Enabled = true;
                //button to delete the actual record is set enable to true.
                this.btn_Delete.Enabled = true;
                //reset the column counter for global dataset.
                clmCounter = 0;
                //set the row counter for global dataset to the last.
                rowCounter = _oDataSetHoldingTheMainTableData.Tables[0].Rows.Count - 1;
                //condition to check existance the records in table.
                if (_oDataSetHoldingTheMainTableData.Tables[0].Rows.Count > 0)
                {
                    //loop for columns of global dataset.
                    foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    {
                        //set data to appropriate control of pannel.
                        panel1.Controls[1 + clmCounter * 2].Text = (_oDataSetHoldingTheMainTableData.Tables[0].Rows[_oDataSetHoldingTheMainTableData.Tables[0].Rows.Count - 1])[objDataColumn.ColumnName].ToString();
                        //increase column counter by one.
                        clmCounter = clmCounter + 1;
                    }
                }
                else
                {
                    //throw a massage is table has no row.
                    MessageBox.Show("Table Has No Row.");
                }
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }

        }
        #endregion

        #endregion

        #region Classess

        #region Validation For The Generating Business Data
        /// <summary>
        /// Validation to creating the property class .
        /// </summary>
        /// <returns></returns>
        bool BDValidate()
        {
            //condition to check whethere the namespase is entered or not.
            if (txtNameSpace.Text == "")
            {
                //throw a message if namespase is not entered.
                MessageBox.Show("Please Insert NameSpace.");
                //set focus to Namespace's textbox.
                txtNameSpace.Focus();
                //return false.
                return false;
            }
            else
            {
                //return true after validation perform successfully.
                return true;
            }
        }
        #endregion

        #region Starting for the property class generation
        /// <summary>
        /// function to create Property Class for selected table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GenerateBD_Click(object sender, System.EventArgs e)
        {
            try
            {
                //perform validation.
                if (BDValidate())
                {
                    //checking for creation all table's Property class.
                    if (chkAllTables.Checked)
                    {
                        frmChooseTables o = new frmChooseTables(arrlstTables);
                        o.ShowDialog();
                        //loop for all tables in the database.
                        foreach (string strTable in arrlstTables)
                        {
                            //check for connection state.
                            if (conCC.State == ConnectionState.Closed)
                                conCC.Open();
                            //initialize the command to getting all the records from the database for active table.
                            OleDbCommand oOleDbCommandDataFromActiveTable = new OleDbCommand("select * from " + strTable, conCC);
                            //reinitialize the global data adapter.
                            oOleDbDataAdapterGetRecordsFromSelectedTable = new OleDbDataAdapter(oOleDbCommandDataFromActiveTable);
                            //clear the global dataset.
                            _oDataSetHoldingTheMainTableData.Tables.Clear();
                            //filling the global dataset.
                            oOleDbDataAdapterGetRecordsFromSelectedTable.Fill(_oDataSetHoldingTheMainTableData, "dTabels");
                            //calling the funtion to generate property class for given table.
                            GenerateBD(strTable);
                            //closing connection.
                            conCC.Close();
                        }
                        //throw a message after completion of property class.
                        MessageBox.Show("BD Generation Complete Successfully.");
                    }
                    else
                    {
                        //condition for successfully generation of property class for selected table.
                        if (GenerateBD(cmbTables.Text))
                        {
                            //throw a message after completion of property class.
                            MessageBox.Show("BD Generation Complete Successfully.");
                        }
                    }
                    //button to generate property class is set to false.
                    btn_GenerateBD.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Filling The DataSet For Generating A Business Class
        /// <summary>
        /// function to fill dataset to writing stored procedure.
        /// </summary>
        /// <param name="strTableName"></param>
        private void fillDataSet(string strTableName)
        {
            try
            {
                //declare a command for getting records and table structure.
                OleDbCommand oOleDbCommandGetTableNames;
                //condition to check for SQL SERVER or MySQL.
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    //initialize the command for getting table structure.
                    oOleDbCommandGetTableNames = new OleDbCommand("SP_HELP " + strTableName, conCC);
                    //oOleDbCommandGetTableNames.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    //reset connectio to Information_Schema for getting table structure from MySQL database.
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=Information_Schema");
                    //initialize the command for getting table structure.
                    oOleDbCommandGetTableNames = new OleDbCommand("SELECT Column_Name, Column_Type FROM Columns WHERE TABLE_SCHEMA='" + cmbDataBase.Text + "' AND TABLE_NAME='" + strTableName + "' ORDER BY Ordinal_Position", conCC);
                }
                //check for connection state.
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                //declare a false table.
                DataTable dtFalseTableToHelpInPerformingOperations = new DataTable();
                //declare a table which hold the table structure for given table.
                DataTable dtTableSturcture = new DataTable();
                //initializing data adapter to get the structure of given table.
                OleDbDataAdapter daTable = new OleDbDataAdapter(oOleDbCommandGetTableNames);
                //reset dataset for use of creating procedure.
                dsTable = new DataSet();
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    //fill the table structure to a table.
                    daTable.Fill(dsTable);
                }
                else
                {
                    //fill the table structure to a table.
                    daTable.Fill(dtTableSturcture);
                    //adding a false table to dataset.
                    dsTable.Tables.Add(dtFalseTableToHelpInPerformingOperations);
                    //adding a table which holds table structure to the dataset.
                    dsTable.Tables.Add(dtTableSturcture);
                    //calling the function to writing the prcedure sql for selected table.
                }
                writeProc(strTableName);
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
            finally
            {
                //close connection
                conCC.Close();
            }
        }
        #endregion

        #region Business Class Generation Code
        /// <summary>
        /// function to generate the property class for given table.
        /// </summary>
        /// <param name="_TableName"></param>
        /// <returns>bool</returns>
        private bool GenerateBD(string _TableName)
        {
            try
            {
                //initializing the stream to creating a .cs file in C:\CompleteDataBaseAccess\  .
                System.IO.Stream objStream = new FileStream(@"C:\CompleteDataBaseAccess\" + txtCNPreFix.Text + _TableName + txtCNPostFix.Text + ".cs", System.IO.FileMode.OpenOrCreate);
                //initializing stream writer for writing the whole code in property class.
                System.IO.StreamWriter objStreamWriter = new StreamWriter(objStream);
                //writing code for generating Property Class.
                objStreamWriter.WriteLine("using System;");
                objStreamWriter.WriteLine("namespace " + txtNameSpace.Text);
                objStreamWriter.WriteLine("{");
                objStreamWriter.WriteLine("	/// <summary>");
                objStreamWriter.WriteLine("	/// Summary Description for " + txtCNPreFix.Text + _TableName + txtCNPostFix.Text);
                objStreamWriter.WriteLine("	/// </summary>");
                objStreamWriter.WriteLine("	public class " + this.txtCNPreFix.Text + _TableName + txtCNPostFix.Text);
                objStreamWriter.WriteLine("	{");
                string defaultCunstructor = "";
                int lastColumn = 0;
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    string varPri = "";
                    if (objDataColumn.DataType.ToString() == "System.String")
                        varPri = "str";
                    else if (objDataColumn.DataType.ToString() == "System.Int64")
                        varPri = "l";
                    else if (objDataColumn.DataType.ToString() == "System.Int32")
                        varPri = "i";
                    else if (objDataColumn.DataType.ToString() == "System.Boolean")
                        varPri = "bl";
                    else if (objDataColumn.DataType.ToString() == "System.DateTime")
                        varPri = "dTime";
                    objStreamWriter.WriteLine("		private " + objDataColumn.DataType.ToString() + " " + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + ";");
                    if (lastColumn < _oDataSetHoldingTheMainTableData.Tables[0].Columns.Count - 1)
                    {
                        defaultCunstructor += objDataColumn.DataType + " " + objDataColumn.ColumnName + ", ";
                    }
                    else
                    {
                        defaultCunstructor += objDataColumn.DataType + " " + objDataColumn.ColumnName;
                    }
                    lastColumn += 1;
                }
                objStreamWriter.WriteLine("		private e" + _TableName + " " + txtPrivateVariablePreFix.Text + "e" + _TableName + ";");
                objStreamWriter.WriteLine("		public " + this.txtCNPreFix.Text + _TableName + txtCNPostFix.Text + "()");
                objStreamWriter.WriteLine("		{}");
                objStreamWriter.WriteLine("		public " + this.txtCNPreFix.Text + _TableName + txtCNPostFix.Text + "(" + defaultCunstructor + ")");
                objStreamWriter.WriteLine("		{");
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    string varPri = "";
                    if (objDataColumn.DataType.ToString() == "System.String")
                        varPri = "str";
                    else if (objDataColumn.DataType.ToString() == "System.Int64")
                        varPri = "l";
                    else if (objDataColumn.DataType.ToString() == "System.Int32")
                        varPri = "i";
                    else if (objDataColumn.DataType.ToString() == "System.Boolean")
                        varPri = "bl";
                    else if (objDataColumn.DataType.ToString() == "System.DateTime")
                        varPri = "dTime";
                    objStreamWriter.WriteLine("			" + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + " = " + objDataColumn.ColumnName + ";");
                }
                objStreamWriter.WriteLine("		}");
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    string varPri = "";
                    if (objDataColumn.DataType.ToString() == "System.String")
                        varPri = "str";
                    else if (objDataColumn.DataType.ToString() == "System.Int64")
                        varPri = "l";
                    else if (objDataColumn.DataType.ToString() == "System.Int32")
                        varPri = "i";
                    else if (objDataColumn.DataType.ToString() == "System.Boolean")
                        varPri = "bl";
                    else if (objDataColumn.DataType.ToString() == "System.DateTime")
                        varPri = "dTime";
                    objStreamWriter.WriteLine("		/// <summary>");
                    objStreamWriter.WriteLine("		/// This is Properties For " + objDataColumn.ColumnName + ";");
                    objStreamWriter.WriteLine("		/// </summary>");
                    objStreamWriter.WriteLine("		public " + objDataColumn.DataType.ToString() + " " + objDataColumn.ColumnName);
                    objStreamWriter.WriteLine("		{");
                    objStreamWriter.WriteLine("			set");
                    objStreamWriter.WriteLine("			{");
                    objStreamWriter.WriteLine("				" + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + " = value;");
                    objStreamWriter.WriteLine("			}");
                    objStreamWriter.WriteLine("			get");
                    objStreamWriter.WriteLine("			{");
                    objStreamWriter.WriteLine("				return " + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + ";");
                    objStreamWriter.WriteLine("			}");
                    objStreamWriter.WriteLine("		}");
                }
                #region To Bind ENum in Business Data
                objStreamWriter.WriteLine("		/// <summary>");
                objStreamWriter.WriteLine("		/// This is Properties For e" + _TableName + ";");
                objStreamWriter.WriteLine("		/// </summary>");
                objStreamWriter.WriteLine("		public e" + _TableName + " Operation");
                objStreamWriter.WriteLine("		{");
                objStreamWriter.WriteLine("			set");
                objStreamWriter.WriteLine("			{");
                objStreamWriter.WriteLine("				" + txtPrivateVariablePreFix.Text + "e" + _TableName + " = value;");
                objStreamWriter.WriteLine("			}");
                objStreamWriter.WriteLine("			get");
                objStreamWriter.WriteLine("			{");
                objStreamWriter.WriteLine("				return " + txtPrivateVariablePreFix.Text + "e" + _TableName + ";");
                objStreamWriter.WriteLine("			}");
                objStreamWriter.WriteLine("		}");
                #endregion
                objStreamWriter.WriteLine("	}//Class Close");
                objStreamWriter.WriteLine(" // Creating Enum for Business Operation");
                objStreamWriter.WriteLine(" public enum e" + _TableName);
                objStreamWriter.WriteLine(" {");
                objStreamWriter.WriteLine("     Insert,");
                objStreamWriter.WriteLine("     Update,");
                objStreamWriter.WriteLine("     Delete,");
                objStreamWriter.WriteLine("     Get_All_Records,");
                objStreamWriter.WriteLine("     Get_Record_By_PrimaryId");
                objStreamWriter.WriteLine(" }");
                objStreamWriter.WriteLine("}//NameSpace Close");
                objStreamWriter.Close();
                return true;
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
                return false;
            }
        }

        #endregion

        #endregion

        #region Procedures

        #region ProcedureCreateTab
        /// <summary>
        /// function to fill the combo of procedure.
        /// </summary>
        void ProcedureCreate()
        {
            try
            {
                //button to create sql procedure is set enable to false.
                btnCreate.Enabled = false;
                //button to run sql is set enable to false.
                btnRun.Enabled = false;
                //button to Save sql procedure is set enable to false.
                btnSaveAs.Enabled = false;
                //initializing a command for gettign table list.
                OleDbCommand objOleDbCommand;
                //check for Sql Server or MySQL
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                    objOleDbCommand = new OleDbCommand("sp_tables", conCC);
                else
                {
                    //reset the connection to get list of procedures from mySql database for selected database.
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=Information_Schema");
                    objOleDbCommand = new OleDbCommand("SELECT '0' AS 'Column1', '0' AS 'Column2', TABLE_NAME, Table_Type FROM TABLES WHERE TABLE_SCHEMA='" + cmbDataBase.Text + "'", conCC);
                }
                //check for connection state.
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                //initialize a dataadapter for table list
                OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                //clear datatable which holds table name to create procedures
                dtTablesP.Rows.Clear();
                //fill datatable which holds table name to create procedures
                daTables.Fill(dtTablesP);
                //clear the combo of tables for procedure creation.
                cmbTableForProcedures.Items.Clear();
                //reset the arrylist of holding tables
                arrlstTables = new ArrayList();
                //loop for tables in datatable
                foreach (DataRow dr in dtTablesP.Rows)
                {
                    //check for tables and not for system table
                    if (dr[3].ToString().IndexOf("TABLE") != -1 && dr[3].ToString().IndexOf("SYS") == -1)
                    {
                        //check for dtproperties table.
                        if (dr[2].ToString() != "dtproperties" && dr[2].ToString().StartsWith(System.Configuration.ConfigurationSettings.AppSettings["strTableInitial"]))
                        {
                            //adding the table name to the combo of tables
                            cmbTableForProcedures.Items.Add(dr[2].ToString());
                            //adding the table name to the arraylist of tables
                            arrlstTables.Add(dr[2].ToString());
                        }
                    }
                }
                //connection closing.
                conCC.Close();
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
        }
        #endregion

        #region Checks For Checking For The CheckBox Checks
        /// <summary>
        /// function to validate for generating procedures.
        /// </summary>
        /// <returns></returns>
        private bool ValidCheck()
        {
            if (chkDelete.Checked)
                return true;
            else if (chkSelect.Checked)
                return true;
            else if (chkDelete.Checked)
                return true;
            else if (chkInsert.Checked)
                return true;
            else
                return false;
        }
        #endregion

        #region Start the creation of code for procedure
        //declare arraylist variable to hold all the procedures.
        ArrayList arrlstProcedures;
        //declare a string contain total code for procedure
        string strTotalProcedure;
        /// <summary>
        /// function to initiate creation of procedure code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            try
            {
                //initialize arryalist to hold all the procedures.
                arrlstProcedures = new ArrayList();
                ArrayList arrlst1 = new ArrayList();
                //initialize string for total procedure code.
                strTotalProcedure = "";
                //check for validation
                if (ValidCheck())
                {
                    //check for all tables.
                    if (chkAll.Checked)
                    {
                        //enumerator for all tables
                        IEnumerator ie = cmbTableForProcedures.Items.GetEnumerator();
                        //condition to check end of record.
                        while (ie.MoveNext())
                        {
                            arrlst1.Add(ie.Current.ToString());
                        }

                        frmChooseTables o = new frmChooseTables(arrlst1);
                        o.ShowDialog();
                        foreach (string strTableName in arrlst1)
                        {
                            if (strTableName.StartsWith(System.Configuration.ConfigurationSettings.AppSettings["strTableInitial"]))
                                //calling function to generate code for procedures.
                                fillDataSet(strTableName);
                        }
                    }
                    else
                    {
                        //calling function to generate code for procedures.
                        fillDataSet(cmbTableForProcedures.Text);
                    }
                    //button to run created procedure in selected database is set enable to true.
                    btnRun.Enabled = true;
                    //button to save created procedure as script is set enable to true.
                    btnSaveAs.Enabled = true;
                    //adding created procedure to display textbox.
                    //txtOutPut.Text = strTotalProcedure;
                }
                else
                {
                    //throw a message if no selection
                    MessageBox.Show("Please Select One Of 'Insert', 'Update', 'Select' And 'Delete'");
                }
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
            }
            finally
            {
                //connection closing.
                conCC.Close();
            }
        }
        #endregion
        Hashtable htDataTypes;
        private void fillDataTypes()
        {
            htDataTypes = new Hashtable();
            htDataTypes.Add("varchar", "VarChar");
            htDataTypes.Add("char", "Char");
            htDataTypes.Add("int", "Int");
            htDataTypes.Add("bigint", "BigInt");
            htDataTypes.Add("decimal", "Decimal");
            htDataTypes.Add("datetime", "DateTime");
            htDataTypes.Add("smalldatetime", "SmallDateTime");
            htDataTypes.Add("bit", "Bit");
            htDataTypes.Add("boolean", "Boolean");
            htDataTypes.Add("binary", "Binary");
            htDataTypes.Add("float", "Float");
            htDataTypes.Add("image", "Image");
            htDataTypes.Add("numeric", "Numeric");
            htDataTypes.Add("tinyint", "TinyInt");
            htDataTypes.Add("smallint", "SmallInt");
            htDataTypes.Add("nchar", "nChar");
            htDataTypes.Add("nvarchar", "nVarChar");
            htDataTypes.Add("text", "Text");
            htDataTypes.Add("ntext", "nText");
            htDataTypes.Add("money", "Money");
            htDataTypes.Add("smallmoney", "SmallMoney");
            htDataTypes.Add("real", "Real");
            htDataTypes.Add("varbinary", "VarBinary");
            htDataTypes.Add("uniqueidentifier", "UniqueIdentifier");
        }
        #region Write Code For Insert & Update Procedure
        /// <summary>
        /// function to generate code for insert procedure.
        /// </summary>
        /// <param name="strTableName">String</param>
        private void pInsertUpdate(string strTableName)
        {
            try
            {
                #region SQL SERVER
                lblCurrentTableName.Text = strTableName;
                //condition to check for sql server or mysql.
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    txtOutPut.Text += "IF EXISTS (SELECT [ID] FROM sysobjects WHERE [Name] LIKE '" + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "')\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += " DROP PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                    //function call to insert remark at the top of procedure.
                    insRemark(dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString());
                    txtOutPut.Text += "CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "\r\n(\r\n";
                    txtOutPut.Text += "	-- adding parameter with the name flag to the procedure\r\n";
                    txtOutPut.Text += "	@Flag VarChar(32),";
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "\r\n -- adding parameter with the name UserSessionId to the procedure\r\n";
                        txtOutPut.Text += "	@UserSessionId " + (chkIsUniqueIdentifier.Checked ? "UniqueIdentifier" : "VarChar(128)") + " = Null,";
                    }
                    string strInsert = "";
                    string strInsertParameter = "";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;

                    string[] strColumnsToLeave = System.Configuration.ConfigurationSettings.AppSettings["strColumnsToLeave"].Split(',');
                    ArrayList arrlstColumnsToLeave = new ArrayList();
                    foreach (string strColumnName in strColumnsToLeave)
                    {
                        arrlstColumnsToLeave.Add(strColumnName);
                    }
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (!arrlstColumnsToLeave.Contains(drRow[0].ToString()))
                        {
                            string strDataLength = "";
                            string strNullable = "";
                            if (drRow[6].ToString() == "yes" && drRow[1].ToString() != "char")
                                strNullable = " = Null";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            txtOutPut.Text += "\r\n	-- adding parameter with the name " + drRow[0].ToString() + " to the procedure";
                            txtOutPut.Text += "\r\n" + @"	@" + drRow[0].ToString() + " " + htDataTypes[drRow[1]].ToString() + strDataLength + strNullable + ",";
                            if (bIsPrimaryKey)
                            {
                                strInsert += "[" + drRow[0].ToString() + "], ";
                                if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                {
                                    strInsertParameter += @" @" + drRow[0].ToString() + ",";
                                }
                            }
                            else
                            {
                                strInsert += "[" + drRow[0].ToString() + "], ";
                                strInsertParameter += @"@" + drRow[0].ToString() + ", ";
                            }
                        }
                    }
                    strInsert = strInsert.Trim().Remove(strInsert.Trim().Length - 1, 1);
                    strInsertParameter = strInsertParameter.Trim().Remove(strInsertParameter.Trim().Length - 1, 1);
                    strInsert += " ";
                    strInsertParameter += " ";
                    txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length - 1);
                    txtOutPut.Text += "\r\n)\r\n";
                    txtOutPut.Text += "AS\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += "	IF @Flag = '" + System.Configuration.ConfigurationSettings.AppSettings["strInsertFlag"] + "'\r\n";
                    txtOutPut.Text += "	BEGIN\r\n";
                    //txtOutPut.Text += "         BEGIN TRAN\r\n";
                    //txtOutPut.Text += "         DECLARE @AutoNumber BigInt\r\n";
                    //txtOutPut.Text += "         DECLARE @PrimaryKey VarChar(128)\r\n";
                    //txtOutPut.Text += "         INSERT INTO NextAvailableId (ParkName) \r\n";
                    //txtOutPut.Text += "             SELECT [Name] FROM ParkSummary\r\n";
                    //txtOutPut.Text += "         IF @@Error <> 0\r\n";
                    //txtOutPut.Text += "             ROLLBACK TRAN\r\n";
                    //txtOutPut.Text += "         SELECT @AutoNumber = @@Identity\r\n";
                    //txtOutPut.Text += "         SELECT @PrimaryKey = [Name] FROM ParkSummary\r\n";
                    //txtOutPut.Text += "         SET @PrimaryKey = @PrimaryKey + '-" + strTableName + "-' + REPLACE(STR(CAST(@AutoNumber AS VarChar(20)), 20), ' ', '0')\r\n";
                    //txtOutPut.Text += "         SELECT @AutoNumber = @@Identity\r\n";
                    txtOutPut.Text += "\r\n";
                    if (chkIsUniqueIdentifier.Checked)
                    {
                        txtOutPut.Text += "		-- declaring a local variable to hold the newly generated primary id for current table \r\n";
                        txtOutPut.Text += "		DECLARE @vNextAutoId UniqueIdentifier\r\n";
                        txtOutPut.Text += "		-- holding new value for primary key \r\n";
                        txtOutPut.Text += "		SET @vNextAutoId = NewId()\r\n\r\n";
                        txtOutPut.Text += "		-- inset a new row to the table \r\n";
                        txtOutPut.Text += "		INSERT INTO " + strTableName + "(" + strInsert + ")\r\n";
                        txtOutPut.Text += "			VALUES(@vNextAutoId, " + strInsertParameter + ")\r\n\r\n";
                    }
                    else
                    {
                        txtOutPut.Text += "		-- declaring a local variable to hold the newly generated primary id for current table \r\n";
                        txtOutPut.Text += "		DECLARE @vNextAutoId VarChar(128)\r\n";
                        txtOutPut.Text += "		-- calling procedure to get new id \r\n";
                        txtOutPut.Text += "		EXEC usptblNextAutoNumberUpdate '" + strTableName + "', @AvailableId = @vNextAutoId OUTPUT\r\n\r\n";
                        txtOutPut.Text += "		-- inset a new row to the table \r\n";
                        txtOutPut.Text += "		INSERT INTO " + strTableName + "(" + strInsert + ")\r\n";
                        txtOutPut.Text += "			VALUES(@vNextAutoId, " + strInsertParameter + ")\r\n\r\n";
                    }
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "		-- updating operation and referenceid on current usertransaction \r\n";
                        txtOutPut.Text += "		-- EXEC usptblUserTransactionInsertUpdate 'Insert', @UserTransactionId, Null, Null, Null, 'Add', @vNextAutoId \r\n\r\n";
                    }
                    txtOutPut.Text += "		-- return with newly generated id \r\n";
                    txtOutPut.Text += "		SELECT @vNextAutoId \r\n";
                    //txtOutPut.Text += "         IF @@Error <> 0\r\n";
                    //txtOutPut.Text += "             ROLLBACK TRAN\r\n";
                    //txtOutPut.Text += "     SELECT @PrimaryKey\r\n";
                    //txtOutPut.Text += "     COMMIT TRAN\r\n";
                    txtOutPut.Text += "	END\r\n";
                    txtOutPut.Text += "	ELSE\r\n";
                    txtOutPut.Text += "	BEGIN\r\n";
                    txtOutPut.Text += "		UPDATE	" + strTableName + "\r\n";
                    txtOutPut.Text += "		SET";
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (!arrlstColumnsToLeave.Contains(drRow[0].ToString()))
                        //if (drRow[0].ToString() != "cDate" && drRow[0].ToString() != "LastModifiedDateTime" && drRow[0].ToString() != "CreatedDateTime")
                        {
                            if (bIsPrimaryKey)
                            {
                                if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                    txtOutPut.Text += "\r\n 			[" + drRow[0].ToString() + @"] = @" + drRow[0].ToString() + ", ";
                            }
                            else
                                txtOutPut.Text += "\r\n			[" + drRow[0].ToString() + "] " + @" = @" + drRow[0].ToString() + ", ";
                        }
                    }
                    //updated on 5th apr 2009
                    //txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length - 1);
                    txtOutPut.Text = txtOutPut.Text.Remove(txtOutPut.Text.LastIndexOf(','), 1);
                    //if (bIsPrimaryKey)
                    //    txtOutPut.Text += "\r\n		WHERE	" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @" = @" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
                    //else
                    txtOutPut.Text += "\r\n		WHERE	" + dsTable.Tables[1].Rows[0][0].ToString() + @" = @" + dsTable.Tables[1].Rows[0][0].ToString() + "\r\n\r\n";
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "		-- updating operation and referenceid on current usertransaction \r\n";
                        txtOutPut.Text += "		-- EXEC usptblUserTransactionInsertUpdate 'Insert', @UserTransactionId, Null, Null, Null, 'Edit', @" + dsTable.Tables[1].Rows[0][0].ToString() + " \r\n";
                    }
                    txtOutPut.Text += "	END\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n";
                }
                #endregion
                #region MySQL
                else
                {
                    txtOutPut.Text += "DELIMITER $$ \r\n";
                    txtOutPut.Text += "$$ CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "(\r\n";
                    txtOutPut.Text += " _Flag Char,\r\n";
                    string strInsert = "";
                    string strInsertParameter = "";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;
                    bool bIsNotFirstColumn = false;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate")
                        {
                            string strDataLength = "";
                            string strNullable = "";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else
                                strDataLength = "";
                            txtOutPut.Text += "" + @"   _" + drRow[0].ToString().Replace("bigint(20)", "bigint") + " " + drRow[1].ToString().Replace("bigint(20)", "bigint") + strDataLength + strNullable + ",\r\n";
                            if (bIsNotFirstColumn)
                            {
                                if (bIsPrimaryKey)
                                {
                                    if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                    {
                                        strInsert += drRow[0].ToString() + ",";
                                        strInsertParameter += @"    _" + drRow[0].ToString() + ",";
                                    }
                                }
                                else
                                {
                                    strInsert += drRow[0].ToString() + ",";
                                    strInsertParameter += @" _" + drRow[0].ToString() + ",";
                                }
                            }
                        }
                        bIsNotFirstColumn = true;
                    }
                    strInsert = strInsert.Trim().Remove(strInsert.Length - 1, 1);
                    strInsertParameter = strInsertParameter.Remove(strInsertParameter.LastIndexOf(","));
                    txtOutPut.Text = txtOutPut.Text.Remove(txtOutPut.Text.LastIndexOf(","));
                    txtOutPut.Text += "\r\n) \r\n";
                    txtOutPut.Text += "BEGIN \r\n";
                    txtOutPut.Text += " IF _Flag='I' \r\n";
                    txtOutPut.Text += " THEN ";
                    txtOutPut.Text += "     INSERT INTO " + strTableName + "(" + strInsert + ") \r\n";
                    txtOutPut.Text += "         VALUES(" + strInsertParameter + "); \r\n";
                    txtOutPut.Text += " ELSE \r\n";
                    txtOutPut.Text += "     UPDATE " + strTableName + " \r\n";
                    txtOutPut.Text += "     SET\r\n";
                    bIsNotFirstColumn = false;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate" && bIsNotFirstColumn)
                        {
                            if (bIsPrimaryKey)
                            {
                                if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                    txtOutPut.Text += " " + drRow[0].ToString() + @"=_" + drRow[0].ToString() + " ,\r\n";
                            }
                            else
                                txtOutPut.Text += "         " + drRow[0].ToString() + @"=_" + drRow[0].ToString() + " ,\r\n";
                        }
                        bIsNotFirstColumn = true;
                    }
                    txtOutPut.Text = txtOutPut.Text.Remove(txtOutPut.Text.LastIndexOf(","));
                    txtOutPut.Text += "\r\n     WHERE " + dsTable.Tables[1].Rows[0][0].ToString() + @"=_" + dsTable.Tables[1].Rows[0][0].ToString() + ";";
                    txtOutPut.Text += "\r\n END IF; \r\n";
                    txtOutPut.Text += "END $$ \r\n";
                    txtOutPut.Text += "\r\nDELIMITER ; ";
                }
                #endregion
                arrlstProcedures.Add(txtOutPut.Text);
                //strTotalProcedure = txtOutPut.Text;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #region Write Code For Insert & Update Procedure
        /// <summary>
        /// function to generate code for insert procedure.
        /// </summary>
        /// <param name="strTableName">String</param>
        private void pInsertUpdateDelete(string strTableName)
        {
            try
            {
                #region SQL SERVER
                lblCurrentTableName.Text = strTableName;
                //condition to check for sql server or mysql.
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    txtOutPut.Text += "IF EXISTS (SELECT [ID] FROM sysobjects WHERE [Name] LIKE '" + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "')\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += " DROP PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                    //function call to insert remark at the top of procedure.
                    insRemark(dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString());
                    txtOutPut.Text += "CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "\r\n(\r\n";
                    txtOutPut.Text += "	-- adding parameter with the name flag to the procedure\r\n";
                    txtOutPut.Text += "	@Flag VarChar(32),";
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "\r\n -- adding parameter with the name UserSessionId to the procedure\r\n";
                        txtOutPut.Text += "	@UserSessionId " + (chkIsUniqueIdentifier.Checked ? "UniqueIdentifier" : "VarChar(128)") + " = Null,";
                    }
                    string strInsert = "";
                    string strInsertParameter = "";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;

                    string[] strColumnsToLeave = System.Configuration.ConfigurationSettings.AppSettings["strColumnsToLeave"].Split(',');
                    ArrayList arrlstColumnsToLeave = new ArrayList();
                    foreach (string strColumnName in strColumnsToLeave)
                    {
                        arrlstColumnsToLeave.Add(strColumnName);
                    }
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (!arrlstColumnsToLeave.Contains(drRow[0].ToString()))
                        {
                            string strDataLength = "";
                            string strNullable = "";
                            if (drRow[6].ToString() == "yes" && drRow[1].ToString() != "char")
                                strNullable = " = Null";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            txtOutPut.Text += "\r\n	-- adding parameter with the name " + drRow[0].ToString() + " to the procedure";
                            txtOutPut.Text += "\r\n" + @"	@" + drRow[0].ToString() + " " + htDataTypes[drRow[1]].ToString() + strDataLength + strNullable + ",";
                            if (bIsPrimaryKey)
                            {
                                strInsert += "[" + drRow[0].ToString() + "], ";
                                if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                {
                                    strInsertParameter += @" @" + drRow[0].ToString() + ",";
                                }
                            }
                            else
                            {
                                strInsert += "[" + drRow[0].ToString() + "], ";
                                strInsertParameter += @"@" + drRow[0].ToString() + ", ";
                            }
                        }
                    }
                    strInsert = strInsert.Trim().Remove(strInsert.Trim().Length - 1, 1);
                    strInsertParameter = strInsertParameter.Trim().Remove(strInsertParameter.Trim().Length - 1, 1);
                    strInsert += " ";
                    strInsertParameter += " ";
                    txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length - 1);
                    txtOutPut.Text += "\r\n)\r\n";
                    txtOutPut.Text += "AS\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += "	IF @Flag = '" + System.Configuration.ConfigurationSettings.AppSettings["strInsertFlag"] + "'\r\n";
                    txtOutPut.Text += "	BEGIN\r\n";
                    //txtOutPut.Text += "         BEGIN TRAN\r\n";
                    //txtOutPut.Text += "         DECLARE @AutoNumber BigInt\r\n";
                    //txtOutPut.Text += "         DECLARE @PrimaryKey VarChar(128)\r\n";
                    //txtOutPut.Text += "         INSERT INTO NextAvailableId (ParkName) \r\n";
                    //txtOutPut.Text += "             SELECT [Name] FROM ParkSummary\r\n";
                    //txtOutPut.Text += "         IF @@Error <> 0\r\n";
                    //txtOutPut.Text += "             ROLLBACK TRAN\r\n";
                    //txtOutPut.Text += "         SELECT @AutoNumber = @@Identity\r\n";
                    //txtOutPut.Text += "         SELECT @PrimaryKey = [Name] FROM ParkSummary\r\n";
                    //txtOutPut.Text += "         SET @PrimaryKey = @PrimaryKey + '-" + strTableName + "-' + REPLACE(STR(CAST(@AutoNumber AS VarChar(20)), 20), ' ', '0')\r\n";
                    //txtOutPut.Text += "         SELECT @AutoNumber = @@Identity\r\n";
                    txtOutPut.Text += "\r\n";
                    if (chkIsUniqueIdentifier.Checked)
                    {
                        txtOutPut.Text += "		-- declaring a local variable to hold the newly generated primary id for current table \r\n";
                        txtOutPut.Text += "		DECLARE @vNextAutoId UniqueIdentifier\r\n";
                        txtOutPut.Text += "		-- holding new value for primary key \r\n";
                        txtOutPut.Text += "		SET @vNextAutoId = NewId()\r\n\r\n";
                        txtOutPut.Text += "		-- inset a new row to the table \r\n";
                        txtOutPut.Text += "		INSERT INTO " + strTableName + "(" + strInsert + ")\r\n";
                        txtOutPut.Text += "			VALUES(@vNextAutoId, " + strInsertParameter + ")\r\n\r\n";
                    }
                    else
                    {
                        txtOutPut.Text += "		-- declaring a local variable to hold the newly generated primary id for current table \r\n";
                        txtOutPut.Text += "		DECLARE @vNextAutoId VarChar(128)\r\n";
                        txtOutPut.Text += "		-- calling procedure to get new id \r\n";
                        txtOutPut.Text += "		EXEC usptblNextAutoNumberUpdate '" + strTableName + "', @AvailableId = @vNextAutoId OUTPUT\r\n\r\n";
                        txtOutPut.Text += "		-- inset a new row to the table \r\n";
                        txtOutPut.Text += "		INSERT INTO " + strTableName + "(" + strInsert + ")\r\n";
                        txtOutPut.Text += "			VALUES(@vNextAutoId, " + strInsertParameter + ")\r\n\r\n";
                    }
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "		-- updating operation and referenceid on current usertransaction \r\n";
                        txtOutPut.Text += "		-- EXEC usptblUserTransactionInsertUpdate 'Insert', @UserTransactionId, Null, Null, Null, 'Add', @vNextAutoId \r\n\r\n";
                    }
                    txtOutPut.Text += "		-- return with newly generated id \r\n";
                    txtOutPut.Text += "		SELECT @vNextAutoId \r\n";
                    //txtOutPut.Text += "         IF @@Error <> 0\r\n";
                    //txtOutPut.Text += "             ROLLBACK TRAN\r\n";
                    //txtOutPut.Text += "     SELECT @PrimaryKey\r\n";
                    //txtOutPut.Text += "     COMMIT TRAN\r\n";
                    txtOutPut.Text += "	END\r\n";
                    txtOutPut.Text += "	ELSE IF @Flag = 'Update'\r\n";
                    txtOutPut.Text += "	BEGIN\r\n";
                    txtOutPut.Text += "		UPDATE	" + strTableName + "\r\n";
                    txtOutPut.Text += "		SET";
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (!arrlstColumnsToLeave.Contains(drRow[0].ToString()))
                        //if (drRow[0].ToString() != "cDate" && drRow[0].ToString() != "LastModifiedDateTime" && drRow[0].ToString() != "CreatedDateTime")
                        {
                            if (bIsPrimaryKey)
                            {
                                if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                    txtOutPut.Text += "\r\n 			[" + drRow[0].ToString() + @"] = @" + drRow[0].ToString() + ", ";
                            }
                            else
                                txtOutPut.Text += "\r\n			[" + drRow[0].ToString() + "] " + @" = @" + drRow[0].ToString() + ", ";
                        }
                    }
                    //updated on 5th apr 2009
                    //txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length - 1);
                    txtOutPut.Text = txtOutPut.Text.Remove(txtOutPut.Text.LastIndexOf(','), 1);
                    //if (bIsPrimaryKey)
                    //    txtOutPut.Text += "\r\n		WHERE	" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @" = @" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
                    //else
                    txtOutPut.Text += "\r\n		WHERE	" + dsTable.Tables[1].Rows[0][0].ToString() + @" = @" + dsTable.Tables[1].Rows[0][0].ToString() + "\r\n\r\n";
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "		-- updating operation and referenceid on current usertransaction \r\n";
                        txtOutPut.Text += "		-- EXEC usptblUserTransactionInsertUpdate 'Insert', @UserTransactionId, Null, Null, Null, 'Edit', @" + dsTable.Tables[1].Rows[0][0].ToString() + " \r\n";
                    }
                    txtOutPut.Text += "	END\r\n";
                    txtOutPut.Text += " ELSE\r\n";
                    txtOutPut.Text += " BEGIN\r\n";
                    txtOutPut.Text += "	-- performing delete to the table with the given criataria\r\n";
                    txtOutPut.Text += "	-- to delete record we are setting true to the Status column\r\n";
                    txtOutPut.Text += "	UPDATE  " + strTableName + "\r\n";
                    txtOutPut.Text += "	SET     [Status] = " + (cmbDataBase.Text == "IRIS_MIS" ? "'Deleted'" : "2") + " -- set 2 the Status column to remove it from the selection\r\n";
                    //if (bIsPrimaryKey)
                    //    txtOutPut.Text += "	WHERE " + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @"=@" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
                    //else
                    txtOutPut.Text += "	WHERE   " + dsTable.Tables[1].Rows[0][0].ToString() + @" = @" + dsTable.Tables[1].Rows[0][0].ToString() + "";
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "\r\n\r\n     -- updating operation and referenceid on current usertransaction \r\n";
                        txtOutPut.Text += "     -- EXEC usptblUserTransactionInsertUpdate 'Insert', @UserTransactionId, Null, Null, Null, 'Delete', @" + dsTable.Tables[1].Rows[0][0].ToString() + " \r\n";
                    }
                    txtOutPut.Text += " END\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n";
                }
                #endregion
                #region MySQL
                else
                {
                    txtOutPut.Text += "DELIMITER $$ \r\n";
                    txtOutPut.Text += "$$ CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "(\r\n";
                    txtOutPut.Text += " _Flag Char,\r\n";
                    string strInsert = "";
                    string strInsertParameter = "";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;
                    bool bIsNotFirstColumn = false;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate")
                        {
                            string strDataLength = "";
                            string strNullable = "";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else
                                strDataLength = "";
                            txtOutPut.Text += "" + @"   _" + drRow[0].ToString().Replace("bigint(20)", "bigint") + " " + drRow[1].ToString().Replace("bigint(20)", "bigint") + strDataLength + strNullable + ",\r\n";
                            if (bIsNotFirstColumn)
                            {
                                if (bIsPrimaryKey)
                                {
                                    if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                    {
                                        strInsert += drRow[0].ToString() + ",";
                                        strInsertParameter += @"    _" + drRow[0].ToString() + ",";
                                    }
                                }
                                else
                                {
                                    strInsert += drRow[0].ToString() + ",";
                                    strInsertParameter += @" _" + drRow[0].ToString() + ",";
                                }
                            }
                        }
                        bIsNotFirstColumn = true;
                    }
                    strInsert = strInsert.Trim().Remove(strInsert.Length - 1, 1);
                    strInsertParameter = strInsertParameter.Remove(strInsertParameter.LastIndexOf(","));
                    txtOutPut.Text = txtOutPut.Text.Remove(txtOutPut.Text.LastIndexOf(","));
                    txtOutPut.Text += "\r\n) \r\n";
                    txtOutPut.Text += "BEGIN \r\n";
                    txtOutPut.Text += " IF _Flag='I' \r\n";
                    txtOutPut.Text += " THEN ";
                    txtOutPut.Text += "     INSERT INTO " + strTableName + "(" + strInsert + ") \r\n";
                    txtOutPut.Text += "         VALUES(" + strInsertParameter + "); \r\n";
                    txtOutPut.Text += " ELSE \r\n";
                    txtOutPut.Text += "     UPDATE " + strTableName + " \r\n";
                    txtOutPut.Text += "     SET\r\n";
                    bIsNotFirstColumn = false;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate" && bIsNotFirstColumn)
                        {
                            if (bIsPrimaryKey)
                            {
                                if (drRow[0].ToString() != dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                                    txtOutPut.Text += " " + drRow[0].ToString() + @"=_" + drRow[0].ToString() + " ,\r\n";
                            }
                            else
                                txtOutPut.Text += "         " + drRow[0].ToString() + @"=_" + drRow[0].ToString() + " ,\r\n";
                        }
                        bIsNotFirstColumn = true;
                    }
                    txtOutPut.Text = txtOutPut.Text.Remove(txtOutPut.Text.LastIndexOf(","));
                    txtOutPut.Text += "\r\n     WHERE " + dsTable.Tables[1].Rows[0][0].ToString() + @"=_" + dsTable.Tables[1].Rows[0][0].ToString() + ";";
                    txtOutPut.Text += "\r\n END IF; \r\n";
                    txtOutPut.Text += "END $$ \r\n";
                    txtOutPut.Text += "\r\nDELIMITER ; ";
                }
                #endregion
                arrlstProcedures.Add(txtOutPut.Text);
                //strTotalProcedure = txtOutPut.Text;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #region Write Code For Insert Procedure

        private void pInsert(string strTableName)
        {
            try
            {
                #region Insert Procedure For SQL Server
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    txtOutPut.Text += "IF EXISTS (SELECT [ID] FROM sysobjects WHERE [Name] LIKE '" + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "')\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += " DROP PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString() + "\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                    insRemark(dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString());
                    txtOutPut.Text += "CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertPost"].ToString() + "(\r\n";
                    string strInsert = "";
                    string strInsertParameter = "";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate" && drRow[0].ToString() != "LastModifiedDateTime" && drRow[0].ToString() != "CreatedDateTime")
                        {
                            string strDataLength = "";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            txtOutPut.Text += @"	@" + drRow[0].ToString() + " " + drRow[1].ToString() + strDataLength + ",\r\n";
                            if (bIsPrimaryKey)
                            {
                                strInsert += drRow[0].ToString() + ", ";
                                strInsertParameter += @"@" + drRow[0].ToString() + ", ";
                            }
                            else
                            {
                                strInsert += drRow[0].ToString() + ", ";
                                strInsertParameter += @"@" + drRow[0].ToString() + ", ";
                            }
                        }
                        else
                        {
                            strInsert += drRow[0].ToString() + ", ";
                            strInsertParameter += @"GetDate(), ";
                        }
                    }
                    strInsert = strInsert.Trim().Remove(strInsert.Length - 1, 1);
                    strInsertParameter = strInsertParameter.Trim().Remove(strInsertParameter.Length - 1, 1);
                    txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length - 1);
                    txtOutPut.Text += "\r\n ) \r\n";
                    txtOutPut.Text += "AS\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += "	INSERT INTO " + cmbTableForProcedures.Text + "(" + strInsert + ")\r\n";
                    txtOutPut.Text += "		VALUES(" + strInsertParameter + ")\r\n";
                    txtOutPut.Text += "END\r\n\r\n";
                }
                #endregion
                #region Insert Procedure For MySQL
                else
                {
                    txtOutPut.Text += "\r\nDELIMITER $$ \r\n";
                    txtOutPut.Text += "$$ CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["InsertPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["InsertPost"].ToString() + "(";
                    string strInsert = "";
                    string strInsertParameter = "";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate")
                        {
                            string strDataLength = "";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            txtOutPut.Text += @" _" + drRow[0].ToString() + " " + drRow[1].ToString() + strDataLength + ",";
                            if (bIsPrimaryKey)
                            {
                                strInsert += drRow[0].ToString() + ",";
                                strInsertParameter += @"_" + drRow[0].ToString() + ",";
                            }
                            else
                            {
                                strInsert += drRow[0].ToString() + ",";
                                strInsertParameter += @"_" + drRow[0].ToString() + ",";
                            }
                        }
                    }
                    strInsert = strInsert.Trim().Remove(strInsert.Length - 1, 1);
                    strInsertParameter = strInsertParameter.Trim().Remove(strInsertParameter.Length - 1, 1);
                    txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length - 1);
                    txtOutPut.Text += " ) ";
                    txtOutPut.Text += "BEGIN ";
                    txtOutPut.Text += " INSERT INTO " + cmbTableForProcedures.Text + "(" + strInsert + ") ";
                    txtOutPut.Text += " VALUES(" + strInsertParameter + "); ";
                    txtOutPut.Text += "END $$ ";
                    txtOutPut.Text += "\r\nDELIMITER ; ";
                }
                #endregion
                arrlstProcedures.Add(txtOutPut.Text);
                strTotalProcedure += txtOutPut.Text;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #region Code For Delete Procedure
        private void pDelete(string strTableName)
        {
            try
            {
                #region DELETE Procedure For SQL Server
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    txtOutPut.Text += "IF EXISTS (SELECT [ID] FROM sysobjects WHERE [Name] LIKE '" + dsSettings.Tables[0].Rows[0]["DeletePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["DeletePost"].ToString() + "')\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += " DROP PROCEDURE " + dsSettings.Tables[0].Rows[0]["DeletePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["DeletePost"].ToString() + "\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                    insRemark(dsSettings.Tables[0].Rows[0]["DeletePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["DeletePost"].ToString());
                    txtOutPut.Text += "CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["DeletePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["DeletePost"].ToString() + "(\r\n";
                    txtOutPut.Text += "	-- adding parameter with the name Flag to the procedure";
                    txtOutPut.Text += "\r\n	@Flag VarChar(64) = Null,\r\n";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate")
                        {
                            string strDataLength = "";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            //if (bIsPrimaryKey)
                            //{
                            //    if (drRow[0].ToString() == dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                            //    {
                            //        txtOutPut.Text += @"	-- adding parameter with the name " + drRow[0].ToString() + " to the procedure\r\n";
                            //        txtOutPut.Text += @"	@" + drRow[0].ToString() + " " + htDataTypes[drRow[1]].ToString() + strDataLength + "\r\n";
                            //    }
                            //}
                            //else
                            {
                                txtOutPut.Text += @"	-- adding parameter with the name " + drRow[0].ToString() + " to the procedure\r\n";
                                txtOutPut.Text += "	@" + drRow[0].ToString() + " " + htDataTypes[drRow[1]].ToString() + strDataLength + "";
                                if (chkIsTransaction.Checked)
                                {
                                    txtOutPut.Text += ",\r\n	-- adding parameter with the name UserSessionId to the procedure\r\n";
                                    txtOutPut.Text += "	@UserSessionId " + (chkIsUniqueIdentifier.Checked ? "UniqueIdentifier" : "VarChar(128)") + " = Null";
                                }
                                break;
                            }
                        }
                    }
                    txtOutPut.Text += ")\r\n";
                    txtOutPut.Text += "AS\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += "	-- performing delete to the table with the given criataria\r\n";
                    txtOutPut.Text += "	-- to delete record we are setting true to the Status column\r\n";
                    txtOutPut.Text += "	UPDATE  " + strTableName + "\r\n";
                    txtOutPut.Text += "	SET     [Status] = " + (cmbDataBase.Text == "IRIS_MIS" ? "'Deleted'" : "2") + " -- set 2 the Status column to remove it from the selection\r\n";
                    //if (bIsPrimaryKey)
                    //    txtOutPut.Text += "	WHERE " + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @"=@" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
                    //else
                    txtOutPut.Text += "	WHERE   " + dsTable.Tables[1].Rows[0][0].ToString() + @" = @" + dsTable.Tables[1].Rows[0][0].ToString() + "";
                    if (chkIsTransaction.Checked)
                    {
                        txtOutPut.Text += "\r\n\r\n     -- updating operation and referenceid on current usertransaction \r\n";
                        txtOutPut.Text += "     -- EXEC usptblUserTransactionInsertUpdate 'Insert', @UserTransactionId, Null, Null, Null, 'Delete', @" + dsTable.Tables[1].Rows[0][0].ToString() + " \r\n";
                    }
                    txtOutPut.Text += "\r\nEND\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                }
                #endregion
                #region DELETE Procedure For MySQL
                else
                {
                    txtOutPut.Text += "\r\nDELIMITER $$ \r\n";
                    txtOutPut.Text += " $$ CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["DeletePre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["DeletePost"].ToString() + "( ";
                    txtOutPut.Text += @" _" + dsTable.Tables[1].Rows[0][0].ToString() + " " + dsTable.Tables[1].Rows[0][1].ToString() + ") ";
                    txtOutPut.Text += "BEGIN \r\n";
                    txtOutPut.Text += " DELETE FROM " + strTableName + " \r\n";
                    txtOutPut.Text += " WHERE " + dsTable.Tables[1].Rows[0][0].ToString() + @"=_" + dsTable.Tables[1].Rows[0][0].ToString() + "; \r\n";
                    txtOutPut.Text += "END $$";
                    txtOutPut.Text += "\r\nDELIMITER ; ";
                }
                #endregion
                arrlstProcedures.Add(txtOutPut.Text);
                //strTotalProcedure += txtOutPut.Text;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #region Write Code For Select Procedure

        private void pSelect(string strTableName)
        {
            try
            {
                #region SELECT Procedure For SQL Server
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    txtOutPut.Text += "IF EXISTS (SELECT [ID] FROM sysobjects WHERE [Name] LIKE '" + dsSettings.Tables[0].Rows[0]["SelectPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["SelectPost"].ToString() + "')\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += " DROP PROCEDURE " + dsSettings.Tables[0].Rows[0]["SelectPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["SelectPost"].ToString() + "\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                    insRemark(dsSettings.Tables[0].Rows[0]["SelectPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["SelectPost"].ToString());
                    txtOutPut.Text += "CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["SelectPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["SelectPost"].ToString() + "(\r\n";
                    txtOutPut.Text += "	-- adding parameter with the name flag\r\n";
                    txtOutPut.Text += @"	@Flag VarChar(32)," + "\r\n";
                    bool bIsPrimaryKey = false;
                    if (dsTable.Tables.Count > 5)
                        bIsPrimaryKey = true;
                    foreach (DataRow drRow in dsTable.Tables[1].Rows)
                    {
                        if (drRow[0].ToString() != "cDate" && drRow[0].ToString() != "CreatedDateTime")
                        {
                            string strDataLength = "";
                            if (drRow[1].ToString() == "varchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            else if (drRow[1].ToString() == "nvarchar")
                                strDataLength = "(" + drRow[3].ToString() + ")";
                            //if (bIsPrimaryKey)
                            //{
                            //    if (drRow[0].ToString() == dsTable.Tables[5].Rows[0]["index_keys"].ToString())
                            //    {
                            //        txtOutPut.Text += @"	@" + drRow[0].ToString() + " " + htDataTypes[drRow[1]].ToString() + strDataLength + ")\r\n";
                            //    }
                            //}
                            //else
                            {
                                txtOutPut.Text += "	-- adding parameter with the name " + drRow[0].ToString() + " to the procedure\r\n";
                                txtOutPut.Text += @"	@" + drRow[0].ToString() + " " + htDataTypes[drRow[1]].ToString() + strDataLength + "\r\n)\r\n";
                                break;
                            }
                        }
                    }
                    txtOutPut.Text += "AS\r\n";
                    txtOutPut.Text += "BEGIN\r\n";
                    txtOutPut.Text += "	IF @Flag = '" + System.Configuration.ConfigurationSettings.AppSettings["strSelectAllFlag"] + "'" + "\r\n";
                    txtOutPut.Text += "	BEGIN \r\n";
                    txtOutPut.Text += "		SELECT  * \r\n		FROM    " + strTableName;
                    txtOutPut.Text += "\r\n	END\r\n";
                    txtOutPut.Text += "	ELSE\r\n";
                    txtOutPut.Text += "	BEGIN \r\n";
                    txtOutPut.Text += "		SELECT  * \r\n		FROM    " + strTableName + "\r\n";
                    //if (bIsPrimaryKey)
                    //    txtOutPut.Text += "		WHERE " + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @" = @" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
                    //else
                    txtOutPut.Text += "		WHERE   " + dsTable.Tables[1].Rows[0][0].ToString() + @" = @" + dsTable.Tables[1].Rows[0][0].ToString() + "\r\n";
                    txtOutPut.Text += "\r\n	END\r\n";
                    txtOutPut.Text += "END\r\n";
                    txtOutPut.Text += "GO\r\n\r\n";
                }
                #endregion
                #region SELECT Procedure For MySQL
                else
                {
                    txtOutPut.Text += "\r\nDELIMITER $$ \r\n";
                    txtOutPut.Text += " $$ CREATE PROCEDURE " + dsSettings.Tables[0].Rows[0]["SelectPre"].ToString() + strTableName + dsSettings.Tables[0].Rows[0]["SelectPost"].ToString() + "( \r\n";
                    txtOutPut.Text += @"    _Flag Char," + " ";
                    txtOutPut.Text += @"    _" + dsTable.Tables[1].Rows[0][0].ToString() + " " + dsTable.Tables[1].Rows[0][1].ToString() + ") ";
                    txtOutPut.Text += "BEGIN \r\n";
                    txtOutPut.Text += " IF _Flag='A' \r\n";
                    txtOutPut.Text += " THEN";
                    txtOutPut.Text += "     SELECT * FROM " + strTableName + "; \r\n";
                    txtOutPut.Text += " ELSE \r\n";
                    txtOutPut.Text += "     SELECT * FROM " + strTableName + "\r\n";
                    txtOutPut.Text += "     WHERE " + dsTable.Tables[1].Rows[0][0].ToString() + @"=_" + dsTable.Tables[1].Rows[0][0].ToString() + "; \r\n";
                    txtOutPut.Text += " END IF; \r\n";
                    txtOutPut.Text += "END $$";
                    txtOutPut.Text += "\r\nDELIMITER ; ";
                }
                #endregion
                arrlstProcedures.Add(txtOutPut.Text);
                //strTotalProcedure += txtOutPut.Text;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #region Insert remark in the procedures

        private void insRemark(string ProcedureName)
        {
            if (dsSettings.Tables[0].Rows[0]["CommentForProcedure"].ToString() != "")
            {
                txtOutPut.Text += "\r\n";
                string strDate = DateTime.Now.ToString("dd MMM yyyy") + "   ";
                txtOutPut.Text += @"/*\r\n" + dsSettings.Tables[0].Rows[0]["CommentForProcedure"].ToString().Replace("03rd Mar 2010", strDate).Replace("Procedure Name:", "Procedure Name: " + ProcedureName);
                txtOutPut.Text += "\r\nEXEC " + ProcedureName + "\r\n=======================================================================================================================================\r\n";
                txtOutPut.Text += "*/\r\n";
            }
            else
                txtOutPut.Text = "";
        }


        #endregion

        #region Call for appropriate procedure

        private void writeProc(string strTableName)
        {
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
            {
                pInsertUpdateDelete(strTableName);
            }
            else
            {
                if (chkInsert.Checked && chkUpdate.Checked)
                {
                    pInsertUpdate(strTableName);
                }
                else if (chkInsert.Checked)
                {
                    pInsert(strTableName);
                }
                if (chkDelete.Checked)
                {
                    pDelete(strTableName);
                }
            }
            if (chkSelect.Checked)
            {
                pSelect(strTableName);
            }
        }

        #endregion

        #region Procedure Script Save

        private void btnSaveAs_Click(object sender, System.EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                string strPath = saveFileDialog1.FileName;
                if (strPath != "")
                {
                    saveFileDialog1.Dispose();
                    if (System.IO.File.Exists(strPath))
                    {
                        DialogResult dResult = MessageBox.Show("File Already Exists, Do You Want To Replace It.", "File Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dResult.ToString() == "Yes")
                        {
                            File.Delete(strPath);
                            StreamWriter sw = new StreamWriter(strPath, true);
                            sw.Write(txtOutPut.Text);
                            sw.Close();
                        }
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(strPath, true);
                        sw.Write(txtOutPut.Text);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        #endregion

        #region Procedure code clear

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            txtOutPut.Text = "";
        }

        #endregion

        #endregion

        #region Error Inserting
        void insError(string strError)
        {
            DataSet dsRequirements = new DataSet();
            if (System.IO.File.Exists(@".\CompleteDataBaseErrors.xml"))
            {
                dsRequirements.ReadXml(@".\CompleteDataBaseErrors.xml");
                DataRow drError = dsRequirements.Tables[0].NewRow();
                drError["ErrorMessage"] = strError;
                if (DateTime.Now.Year == 2006)
                    drError["DateTime"] = System.DateTime.Now.ToString();
                else
                    drError["DateTime"] = "0";
                dsRequirements.Tables[0].Rows.Add(drError);
                System.IO.File.Delete(@".\CompleteDataBaseErrors.xml");
                dsRequirements.WriteXml(@".\CompleteDataBaseErrors.xml");
            }
            MessageBox.Show("Make Sure That You Have Not Lost Your Connection From Database, Or Try Again.");
        }
        #endregion

        #region Connection String Change On the basis of selected database

        private void cmbDataBase_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cmbDataBase.Text != "")
                    btnDataGrid.Enabled = true;
                else
                    btnDataGrid.Enabled = false;
                if (arrlstParameters.Count != 5)
                {
                    arrlstParameters.Add(cmbDataBase.Text);
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
                }
                else
                {
                    arrlstParameters[4] = cmbDataBase.Text;
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
                }
                RegionClass();
                ProcedureCreate();
                CodeForProcedure();
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #region .NET Procedure Code

        #region Procedure code for the .net

        private void btnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                #region Code Generation For SQL SERVER
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    cmbObjectPassed.Text = txtObject.Text;
                    cmbConnectionName.Text = txtConnection.Text;
                    string strOleDb = "SqlDbType";
                    if (rbtnOleDb.Checked)
                        strOleDb = "OleDbType";
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    OleDbCommand newSqlCommand = new OleDbCommand("SP_HELP " + cmbProcedure.SelectedItem.ToString(), conCC);
                    OleDbDataAdapter daParameter = new OleDbDataAdapter(newSqlCommand);
                    DataSet dsParameter = new DataSet();
                    daParameter.Fill(dsParameter);
                    conCC.Close();
                    if (strOleDb == "OleDbType")
                    {
                        txtProcCode.Text += "\r\n " + @"// Check for connection state.";
                        txtProcCode.Text += "\r\n if(" + cmbConnectionName.Text + ".State==ConnectionState.Close)";
                        txtProcCode.Text += "\r\n    " + cmbConnectionName.Text + ".Open();";
                        txtProcCode.Text += "\r\n " + @"// creating a command object to communicate with database.";
                        txtProcCode.Text += "\r\n OleDbCommand cmd" + cmbProcedure.SelectedItem.ToString() + "=new OleDbCommand(";
                        txtProcCode.Text += "\r\n " + @"// initializing the command and connection.";
                        txtProcCode.Text += Convert.ToChar(34) + cmbProcedure.SelectedItem.ToString() + Convert.ToChar(34) + ", " + cmbConnectionName.Text + ");";
                        txtProcCode.Text += "\r\n " + @"// set command type.";
                        txtProcCode.Text += "\r\ncmd" + cmbProcedure.SelectedItem.ToString() + ".CommandType=CommandType.StoredProcedure;";
                    }
                    else
                    {
                        txtProcCode.Text += "\r\n " + @"// Check for connection state.";
                        txtProcCode.Text += "\r\n if(" + cmbConnectionName.Text + ".State==ConnectionState.Close)";
                        txtProcCode.Text += "\r\n    " + cmbConnectionName.Text + ".Open();";
                        txtProcCode.Text += "\r\n " + @"// creating a command object to communicate with database.";
                        txtProcCode.Text += "\r\n SqlCommand cmd" + cmbProcedure.SelectedItem.ToString() + "=new SqlCommand(";
                        txtProcCode.Text += "\r\n " + @"// initializing the command and connection.";
                        txtProcCode.Text += Convert.ToChar(34) + cmbProcedure.SelectedItem.ToString() + Convert.ToChar(34) + ", " + cmbConnectionName.Text + ");";
                        txtProcCode.Text += "\r\n " + @"// set command type.";
                        txtProcCode.Text += "\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".CommandType=CommandType.StoredProcedure;";
                    }
                    if (dsParameter.Tables.Count > 1)
                    {
                        string strDataType = "";
                        foreach (DataRow dr in dsParameter.Tables[1].Rows)
                        {
                            if (strOleDb == "OleDbType")
                            {
                                if (dr[1].ToString() == "char")
                                    strDataType = "OleDbType.Char";
                                else if (dr[1].ToString() == "bigint")
                                    strDataType = "OleDbType.BigInt";
                                else if (dr[1].ToString() == "varchar")
                                    strDataType = "typeof(string)";
                                else if (dr[1].ToString() == "bit")
                                    strDataType = "OleDbType.Boolean";
                                else if (dr[1].ToString() == "float")
                                    strDataType = "typeof(float)";
                                else if (dr[1].ToString() == "tiniint")
                                    strDataType = "OleDbType.TiniInt";
                                else if (dr[1].ToString() == "datetime")
                                    strDataType = "OleDbType.DBDate";
                                else if (dr[1].ToString() == "int")
                                    strDataType = "typeof(int)";
                                else if (dr[1].ToString() == "numeric")
                                    strDataType = "OleDbType.Numeric";
                                else
                                    strDataType = "OleDbType." + dr[1].ToString();
                            }
                            else
                            {
                                if (dr[1].ToString() == "char")
                                    strDataType = "SqlDbType.Char";
                                else if (dr[1].ToString() == "bigint")
                                    strDataType = "SqlDbType.BigInt";
                                else if (dr[1].ToString() == "varchar")
                                    strDataType = "SqlDbType.VarChar";
                                else if (dr[1].ToString() == "bit")
                                    strDataType = "SqlDbType.Bit";
                                else if (dr[1].ToString() == "float")
                                    strDataType = "SqlDbType.Float";
                                else if (dr[1].ToString() == "tiniint")
                                    strDataType = "SqlDbType.TiniInt";
                                else if (dr[1].ToString() == "datetime")
                                    strDataType = "SqlDbType.DateTime";
                                else if (dr[1].ToString() == "int")
                                    strDataType = "SqlDbType.Int";
                                else if (dr[1].ToString() == "numeric")
                                    strDataType = "SqlDbType.BigInt";
                                else
                                    strDataType = "SqlDbType." + dr[1].ToString();
                            }
                            txtProcCode.Text += "\r\n " + @"// adding parameter with name " + dr[0].ToString() + " to the procedure.";
                            txtProcCode.Text += "\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value=" + cmbObjectPassed.Text + "." + dr[0].ToString().Remove(0, 1) + ";";
                        }
                    }
                    if (chkIsSelect.Checked)
                    {
                        if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataTable")
                        {
                            if (rbtnOleDb.Checked)
                            {
                                txtProcCode.Text += "\r\n OleDbDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new OleDbDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataTable dt" + cmbProcedure.SelectedItem.ToString() + " = new DataTable();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(dt" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return dt" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                            else
                            {
                                txtProcCode.Text += "\r\n SqlDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new SqlDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataTable dt" + cmbProcedure.SelectedItem.ToString() + " = new DataTable();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(dt" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return dt" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                        }
                        else if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataSet")
                        {
                            if (rbtnOleDb.Checked)
                            {
                                txtProcCode.Text += "\r\n OleDbDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new OleDbDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataSet ds" + cmbProcedure.SelectedItem.ToString() + " = new DataSet();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(ds" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return ds" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                            else
                            {
                                txtProcCode.Text += "\r\n SqlDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new SqlDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataSet ds" + cmbProcedure.SelectedItem.ToString() + " = new DataSet();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(ds" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return ds" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                        }
                        else if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataReader")
                        {
                            if (rbtnOleDb.Checked)
                            {
                                txtProcCode.Text += "\r\n OleDbDataReader dr" + cmbProcedure.SelectedItem.ToString() + "= cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteReader();";
                                txtProcCode.Text += "\r\n return dr" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                            else
                            {
                                txtProcCode.Text += "\r\n SqlDataReader dr" + cmbProcedure.SelectedItem.ToString() + "= cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteReader();";
                                txtProcCode.Text += "\r\n return dr" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                        }
                        else
                        {
                            txtProcCode.Text += "\r\n return cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteScalar();";
                        }
                    }
                    else
                    {
                        txtProcCode.Text += "\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteNonQuery();";
                    }
                }
                #endregion
                #region Code Generation For MySQL
                else
                {
                    cmbObjectPassed.Text = txtObject.Text;
                    cmbConnectionName.Text = txtConnection.Text;
                    string strOleDb = "SqlDbType";
                    if (rbtnOleDb.Checked)
                        strOleDb = "OleDbType";
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    OleDbCommand newSqlCommand = new OleDbCommand("SELECT param_list FROM mysql.proc WHERE Name='" + cmbProcedure.SelectedItem.ToString() + "'", conCC);
                    byte[] strParameterList;
                    Array arrParameterList;
                    DataSet dsParameter = new DataSet();
                    OleDbDataAdapter oOleDbDataAdapter = new OleDbDataAdapter(newSqlCommand);
                    oOleDbDataAdapter.Fill(dsParameter);
                    strParameterList = (byte[])dsParameter.Tables[0].Rows[0][0];
                    DataTable dtParameter = new DataTable();
                    dtParameter.Columns.Add("Name", typeof(string));
                    dtParameter.Columns.Add("DataType", typeof(string));
                    string strByte = "";
                    arrParameterList = strParameterList.ToString().Split(',');
                    foreach (byte b in strParameterList)
                    {
                        strByte += Convert.ToChar(b).ToString();
                    }
                    arrParameterList = strByte.Split(',');
                    if (strParameterList.Length > 0)
                    {
                        for (int i = 0; i < arrParameterList.Length; i++)
                        {
                            DataRow drPara = dtParameter.NewRow();
                            drPara[0] = arrParameterList.GetValue(i).ToString().Trim().Substring(0, arrParameterList.GetValue(i).ToString().Trim().IndexOf(" "));
                            if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("varchar") != -1 || arrParameterList.GetValue(i).ToString().ToLower().IndexOf("nvarchar") != -1)
                                drPara[1] = "varchar";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("char") != -1)
                                drPara[1] = "char";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("bigint") != -1)
                                drPara[1] = "bigint";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("int") != -1)
                                drPara[1] = "int";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("bit") != -1)
                                drPara[1] = "bit";
                            else
                                drPara[0] = "varchar";
                            dtParameter.Rows.Add(drPara);
                        }
                    }
                    conCC.Close();
                    if (strOleDb == "OleDbType")
                    {
                        txtProcCode.Text += "\r\n " + @"// Check for connection state.";
                        txtProcCode.Text += "\r\n if(" + cmbConnectionName.Text + ".State==ConnectionState.Close)";
                        txtProcCode.Text += "\r\n " + cmbConnectionName.Text + ".Open();";
                        txtProcCode.Text += "\r\n " + @"// creating a command object to communicate with database.";
                        txtProcCode.Text += "\r\n OleDbCommand cmd" + cmbProcedure.SelectedItem.ToString() + "=new OleDbCommand(";
                        txtProcCode.Text += Convert.ToChar(34) + cmbProcedure.SelectedItem.ToString() + Convert.ToChar(34) + ", " + cmbConnectionName.Text + ");";
                        txtProcCode.Text += "\r\n " + @"// set command type.";
                        txtProcCode.Text += "\r\ncmd" + cmbProcedure.SelectedItem.ToString() + ".CommandType=CommandType.StoredProcedure;";
                    }
                    else
                    {
                        txtProcCode.Text += "\r\n " + cmbConnectionName.Text + ".Open();";
                        txtProcCode.Text += "\r\n SqlCommand cmd" + cmbProcedure.SelectedItem.ToString() + "=new SqlCommand(";
                        txtProcCode.Text += Convert.ToChar(34) + cmbProcedure.SelectedItem.ToString() + Convert.ToChar(34) + ", " + cmbConnectionName.Text + ");";
                        txtProcCode.Text += "\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".CommandType=CommandType.StoredProcedure;";
                    }
                    string strDataType = "";
                    foreach (DataRow dr in dtParameter.Rows)
                    {
                        if (dr[1].ToString() == "char")
                            strDataType = "OleDbType.Char";
                        else if (dr[1].ToString() == "bigint")
                            strDataType = "OleDbType.BigInt";
                        else if (dr[1].ToString() == "varchar")
                            strDataType = "typeof(string)";
                        else if (dr[1].ToString() == "bit")
                            strDataType = "OleDbType.Boolean";
                        else if (dr[1].ToString() == "float")
                            strDataType = "typeof(float)";
                        else if (dr[1].ToString() == "tiniint")
                            strDataType = "OleDbType.TiniInt";
                        else if (dr[1].ToString() == "datetime")
                            strDataType = "OleDbType.DBDate";
                        else if (dr[1].ToString() == "int")
                            strDataType = "typeof(int)";
                        else if (dr[1].ToString() == "numeric")
                            strDataType = "OleDbType.Numeric";
                        else
                            strDataType = "OleDbType." + dr[1].ToString();
                        txtProcCode.Text += "\r\n " + @"// adding parameter with name " + dr[0].ToString() + " to the procedure.";
                        txtProcCode.Text += "\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value=" + cmbObjectPassed.Text + "." + dr[0].ToString().Remove(0, 1) + ";";
                    }
                    if (chkIsSelect.Checked)
                    {
                        if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataTable")
                        {
                            if (rbtnOleDb.Checked)
                            {
                                txtProcCode.Text += "\r\n OleDbDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new OleDbDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataTable dt" + cmbProcedure.SelectedItem.ToString() + " = new DataTable();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(dt" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return dt" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                            else
                            {
                                txtProcCode.Text += "\r\n SqlDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new SqlDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataTable dt" + cmbProcedure.SelectedItem.ToString() + " = new DataTable();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(dt" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return dt" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                        }
                        else if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataSet")
                        {
                            if (rbtnOleDb.Checked)
                            {
                                txtProcCode.Text += "\r\n OleDbDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new OleDbDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataSet ds" + cmbProcedure.SelectedItem.ToString() + " = new DataSet();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(ds" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return ds" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                            else
                            {
                                txtProcCode.Text += "\r\n SqlDataAdapter da" + cmbProcedure.SelectedItem.ToString() + "= new SqlDataAdapter(cmd" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n DataSet ds" + cmbProcedure.SelectedItem.ToString() + " = new DataSet();";
                                txtProcCode.Text += "\r\n da" + cmbProcedure.SelectedItem.ToString() + ".Fill(ds" + cmbProcedure.SelectedItem.ToString() + ");";
                                txtProcCode.Text += "\r\n return ds" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                        }
                        else if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataReader")
                        {
                            if (rbtnOleDb.Checked)
                            {
                                txtProcCode.Text += "\r\n OleDbDataReader dr" + cmbProcedure.SelectedItem.ToString() + "= cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteReader();";
                                txtProcCode.Text += "\r\n return dr" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                            else
                            {
                                txtProcCode.Text += "\r\n SqlDataReader dr" + cmbProcedure.SelectedItem.ToString() + "= cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteReader();";
                                txtProcCode.Text += "\r\n return dr" + cmbProcedure.SelectedItem.ToString() + ";";
                            }
                        }
                        else
                        {
                            txtProcCode.Text += "\r\n return cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteScalar();";
                        }
                    }
                    else
                    {
                        txtProcCode.Text += "\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteNonQuery();";
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        #endregion

        #endregion

        #region Others

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbTableForProcedures.Text != "")
            {
                btnCreate.Enabled = true;
                btnRun.Enabled = true;
                btnSaveAs.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
                btnRun.Enabled = false;
                btnSaveAs.Enabled = false;
            }
        }

        private void btn_ShowTableContent_Click(object sender, System.EventArgs e)
        {
            fillPannelAccordingToTheTableSelection();
        }
        string strCurrentTable = "";
        int iCurrentRow = 0;
        int iTotalRow = 0;
        DataSet dsSettings;
        Thread oThreadLable;

        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }

        void ChangeLableStatus()
        {
            SetControlPropertyValue(lblExport, "Text", "Exporting Table (" + strCurrentTable + ") : Record " + iCurrentRow.ToString() + " of " + iTotalRow.ToString());
            //lblExport.Text = ;
        }

        private void DbPlusInOne_Load(object sender, System.EventArgs e)
        {
            try
            {
                oThreadLable = new Thread(new ThreadStart(ChangeLableStatus));
                oThreadLable.Start();
                btnDataGrid.Enabled = false;
                OleDbCommand objOleDbCommand;
                dsSettings = new DataSet();
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                if (arrlstParameters[3].ToString().ToLower() == "SQLOLEDB".ToLower())
                {
                    objOleDbCommand = new OleDbCommand("SP_DataBases", conCC);
                    objOleDbCommand.CommandType = CommandType.StoredProcedure;
                    fillDataTypes();
                }
                else
                    objOleDbCommand = new OleDbCommand("SELECT SCHEMA_NAME FROM SCHEMATA", conCC);
                OleDbDataReader objOleDbDataReader = objOleDbCommand.ExecuteReader();
                cmbDataBase.Items.Clear();
                while (objOleDbDataReader.Read())
                {
                    cmbDataBase.Items.Add(objOleDbDataReader[0].ToString());
                }
                conCC.Close();
                dsSettings.ReadXml(@".\SettingForDBPlus.xml");
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void chkAllTables_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAllTables.Checked)
                btn_GenerateBD.Enabled = true;
            else
                btn_GenerateBD.Enabled = false;
        }

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtOutPut.Text);
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void btnCopyCode_Click(object sender, System.EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtProcCode.Text);
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAll.Checked)
                btnCreate.Enabled = true;
            else
                btnCreate.Enabled = false;
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            Message objMethods = new Message(conCC);
            objMethods.ShowDialog();
        }

        private void btnClearProc_Click(object sender, EventArgs e)
        {
            txtProcCode.Text = "";
            txtObject.Text = "";
            txtConnection.Text = "";
            cmbProcedure.Text = "";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings frmSetting = new Settings();
            frmSetting.ShowInTaskbar = false;
            frmSetting.ShowDialog();
            dsSettings = new DataSet();
            dsSettings.ReadXml(@".\SettingForDBPlus.xml");
        }

        private void btnDataGrid_Click(object sender, EventArgs e)
        {
            DataGrid oDataGrid = new DataGrid(arrlstParameters);
            oDataGrid.ShowInTaskbar = false;
            oDataGrid.ShowDialog();
        }

        private void txtCNPreFix_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 126)
                {
                    e.Handled = true;
                    JScriptMenu oJScriptMenu = new JScriptMenu(conCC);
                    oJScriptMenu.ShowInTaskbar = false;
                    oJScriptMenu.ShowDialog();
                }
                else if (e.KeyChar == 48)
                {
                    e.Handled = true;
                    WriteXLS();
                }
                else if (e.KeyChar == 50)
                {
                    SQLSC oServerDefinations = new SQLSC(arrlstParameters);
                    oServerDefinations.ShowInTaskbar = false;
                    oServerDefinations.ShowDialog();
                }
                else if (e.KeyChar == 49)
                {
                    e.Handled = true;
                    if (chkAllTables.Checked)
                    {
                        //loop for all tables in the database.
                        foreach (string strTable in arrlstTables)
                        {
                            //check for connection state.
                            if (conCC.State == ConnectionState.Closed)
                                conCC.Open();
                            //initialize the command to getting all the records from the database for active table.
                            OleDbCommand oOleDbCommandDataFromActiveTable = new OleDbCommand("select * from " + strTable, conCC);
                            //reinitialize the global data adapter.
                            oOleDbDataAdapterGetRecordsFromSelectedTable = new OleDbDataAdapter(oOleDbCommandDataFromActiveTable);
                            //clear the global dataset.
                            _oDataSetHoldingTheMainTableData.Tables.Clear();
                            //filling the global dataset.
                            oOleDbDataAdapterGetRecordsFromSelectedTable.Fill(_oDataSetHoldingTheMainTableData, "dTabels");
                            //creation of xml file of contain data of main table.
                            _oDataSetHoldingTheMainTableData.WriteXml(@"C:\CompleteDataBaseAccess\" + cmbTables.Text + ".xml");
                            //closing connection.
                            conCC.Close();
                        }
                        //throw a message after completion of property class.
                        MessageBox.Show("XML Completed Successfully.");
                    }
                    else if (e.KeyChar == 50)
                    {
                        try
                        {
                            if (cmbDataBase.Text != "")
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            insError(ex.ToString());
                        }
                    }
                    else
                    {
                        //creation of xml file of contain data of main table.
                        _oDataSetHoldingTheMainTableData.WriteXml(@"C:\CompleteDataBaseAccess\" + cmbTables.Text + ".xml");
                        //throw a message after completion of property class.
                        MessageBox.Show("XML Generation Complete Successfully.");
                    }
                }
                else if (e.KeyChar == 53)
                {
                    frmDataBackup frm = new frmDataBackup(arrlstParameters);
                    frm.ShowDialog();
                }
                else if (e.KeyChar == 54)
                {
                    GetProcedureCode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetProcedureCode()
        {
            try
            {
                OleDbDataAdapter daProcedure = new OleDbDataAdapter("SELECT	* FROM	sysObjects WHERE	XType IN ('P', 'FN') ORDER BY [Name]", conCC);
                DataTable dtProc = new DataTable();
                daProcedure.Fill(dtProc);
                string strProcedureText = "";
                foreach (DataRow dr in dtProc.Rows)
                {
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    if (!dr["Name"].ToString().ToLower().Contains("diag") && dr["XType"].ToString().Trim().ToUpper() == "P")
                    {
                        strProcedureText += "IF EXISTS (SELECT * FROM sysObjects WHERE [Name]='" + dr["Name"].ToString() + "')\r\n";
                        strProcedureText += "BEGIN\r\n";
                        strProcedureText += "   DROP PROCEDURE " + dr["Name"].ToString() + "\r\n";
                        strProcedureText += "END\r\n";
                        strProcedureText += "GO\r\n";
                        strProcedureText += "\r\n";
                        OleDbCommand cmdProcedure = new OleDbCommand("SP_HELPTEXT", conCC);
                        cmdProcedure.CommandType = CommandType.StoredProcedure;
                        cmdProcedure.Parameters.Add("@objname", OleDbType.VarChar).Value = dr["Name"].ToString();
                        OleDbDataReader oDr = cmdProcedure.ExecuteReader();
                        while (oDr.Read())
                            strProcedureText += oDr[0].ToString();
                        strProcedureText += "\r\nGO\r\n";
                        strProcedureText += "\r\n";
                    }
                    if (!dr["Name"].ToString().ToLower().Contains("diag") && dr["XType"].ToString().Trim().ToUpper() == "FN")
                    {
                        strProcedureText += "IF EXISTS (SELECT * FROM sysObjects WHERE [Name]='" + dr["Name"].ToString() + "')\r\n";
                        strProcedureText += "BEGIN\r\n";
                        strProcedureText += "   DROP FUNCTION " + dr["Name"].ToString() + "\r\n";
                        strProcedureText += "END\r\n";
                        strProcedureText += "GO\r\n";
                        strProcedureText += "\r\n";
                        OleDbCommand cmdProcedure = new OleDbCommand("SP_HELPTEXT", conCC);
                        cmdProcedure.CommandType = CommandType.StoredProcedure;
                        cmdProcedure.Parameters.Add("@objname", OleDbType.VarChar).Value = dr["Name"].ToString();
                        OleDbDataReader oDr = cmdProcedure.ExecuteReader();
                        while (oDr.Read())
                            strProcedureText += oDr[0].ToString();
                        strProcedureText += "\r\nGO\r\n";
                        strProcedureText += "\r\n";
                    }
                }
                StreamWriter sw = new StreamWriter(@"C:\CompleteDataBaseAccess\" + cmbDataBase.Text + "_Procedures" + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0') + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ".sql");
                sw.Write(strProcedureText);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void getObjectsFromDatabase(string strDatabase)
        {
            DataTable dtTableObjects = new DataTable();
            dtTableObjects.Columns.Add("ObjectName", typeof(string));
            dtTableObjects.Columns.Add("ObjectType", typeof(string));
            dtTableObjects.Columns.Add("Definition", typeof(string));

            DataTable dtViewObjects = new DataTable();
            dtViewObjects.Columns.Add("ObjectName", typeof(string));
            dtViewObjects.Columns.Add("ObjectType", typeof(string));
            dtViewObjects.Columns.Add("Definition", typeof(string));

            DataTable dtProcedureObjects = new DataTable();
            dtProcedureObjects.Columns.Add("ObjectName", typeof(string));
            dtProcedureObjects.Columns.Add("ObjectType", typeof(string));
            dtProcedureObjects.Columns.Add("Definition", typeof(string));

            if (conCC.State == ConnectionState.Closed)
                conCC.Open();
            OleDbCommand cmdObjects = new OleDbCommand("SP_HELP", conCC);
            cmdObjects.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter daObjects = new OleDbDataAdapter(cmdObjects);
            DataSet dsObjects = new DataSet();
            daObjects.Fill(dsObjects);
            ArrayList arrlstProceduresName = new ArrayList();
            foreach (DataRow drObject in dsObjects.Tables[0].Rows)
            {
                if (drObject["Object_type"].ToString() == "user table")
                {

                }
                else if (drObject["Object_type"].ToString() == "view")
                {
                }
                else if (drObject["Object_type"].ToString() == "stored procedure")
                {
                    arrlstProceduresName.Add(drObject["Name"].ToString());
                }
            }
            StreamWriter sw = new StreamWriter(@"C:\Procedures_" + strDatabase + ".txt");
            foreach (string strProcName in arrlstProceduresName)
            {
                OleDbCommand cmdGetDefinition = new OleDbCommand("SP_HELPTEXT " + strProcName, conCC);
                cmdObjects.CommandType = CommandType.StoredProcedure;
                DataTable dtPro = new DataTable();
                OleDbDataAdapter daPro = new OleDbDataAdapter(cmdGetDefinition);
                daPro.Fill(dtPro);
                foreach (DataRow dr in dtPro.Rows)
                {
                    sw.WriteLine(dr[0].ToString());
                }
                sw.WriteLine("****************************************");
                sw.WriteLine("                                        ");
                sw.WriteLine("****************************************");

            }
            sw.Close();

        }

        #region Execution of created Procedure(s)
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + cmbDataBase.Text);
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                foreach (string strCommand in arrlstProcedures)
                {
                    OleDbCommand cmdProcedure2 = new OleDbCommand(strCommand, conCC);
                    cmdProcedure2.ExecuteNonQuery();
                }
                btnRun.Enabled = false;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
            finally
            {
                conCC.Close();
            }
        }
        #endregion

        #region Generate coding for the manager class
        public string GetCodeForServerFile(OleDbConnection oCon, string TableName, string Operation, bool IsSqlClient)
        {
            try
            {
                string strOleDb = "OleDbType";
                dsSettings = new DataSet();
                dsSettings.ReadXml(@".\SettingForDBPlus.xml");
                if (IsSqlClient)
                    strOleDb = "SqlType";
                if (oCon.State == ConnectionState.Closed)
                    oCon.Open();
                string strCommandName;
                if (Operation == "I")
                    strCommandName = dsSettings.Tables[0].Rows[0]["InsertPre"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString();
                else if (Operation == "U")
                    strCommandName = dsSettings.Tables[0].Rows[0]["InsertPre"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString();
                else if (Operation == "D")
                    strCommandName = dsSettings.Tables[0].Rows[0]["DeletePre"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["DeletePost"].ToString();
                else
                    strCommandName = dsSettings.Tables[0].Rows[0]["SelectPre"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["SelectPost"].ToString();
                OleDbCommand newOleDbCommand;
                DataSet dsParameter = new DataSet();
                string strParameterParanthisic = "";
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    newOleDbCommand = new OleDbCommand("SP_HELP " + strCommandName, oCon);
                    OleDbDataAdapter daParameter = new OleDbDataAdapter(newOleDbCommand);
                    daParameter.Fill(dsParameter);
                    oCon.Close();
                    if (strOleDb == "OleDbType")
                    {
                        txtProcCode.Text = "                " + @"// Check for connection state.";
                        txtProcCode.Text += "\r\n               if(oCon.State==ConnectionState.Closed)";
                        txtProcCode.Text += "\r\n                    oCon.Open();";
                        txtProcCode.Text += "\r\n               " + @"// creating a command object to communicate with database.";
                        txtProcCode.Text += "\r\n               " + @"// & initializing command and connection to the object.";
                        txtProcCode.Text += "\r\n                   OleDbCommand cmd" + strCommandName + " = new OleDbCommand(";
                        txtProcCode.Text += Convert.ToChar(34) + strCommandName + Convert.ToChar(34) + ", " + "oCon" + ");";
                        txtProcCode.Text += "\r\n               " + @"// defining the command type.";
                        txtProcCode.Text += "\r\n               cmd" + strCommandName + ".CommandType = CommandType.StoredProcedure;";
                        txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Transaction = oTran;";
                        txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Connection = oTran.Connection;";
                    }
                    else
                    {
                        //updated on 27th nov 2008
                        //updated on 5th apr 2009
                        //transaction object is not needed in the selection 
                        if ((Operation == "I" || Operation == "U" || Operation == "D"))
                        {
                            txtProcCode.Text = "\r\n               " + @"// creating a command object to communicate with database & initializing command and connection to the object.";
                            txtProcCode.Text += "\r\n               SqlCommand cmd" + strCommandName + " = new SqlCommand(";
                            txtProcCode.Text += Convert.ToChar(34) + strCommandName + Convert.ToChar(34) + ");";
                            txtProcCode.Text += "\r\n               " + @"// defining the command type.";
                            txtProcCode.Text += "\r\n               cmd" + strCommandName + ".CommandType = CommandType.StoredProcedure;";
                            txtProcCode.Text += "\r\n               " + @"// assigning transaction to the command.";
                            txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Transaction = ObjectTransaction;";
                            txtProcCode.Text += "\r\n               " + @"// assigning connection to the command.";
                            txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Connection = ObjectTransaction.Connection;";
                        }
                        else
                        {
                            //txtProcCode.Text = "                " + @"// Check for connection state.";
                            //txtProcCode.Text += "\r\n               if(oCon.State==ConnectionState.Closed)";
                            //txtProcCode.Text += "\r\n                    oCon.Open();";
                            txtProcCode.Text = "\r\n               " + @"// creating a command object to communicate with database & initializing command and connection to the object.";
                            txtProcCode.Text += "\r\n               SqlCommand cmd" + strCommandName + " = new SqlCommand(";
                            txtProcCode.Text += Convert.ToChar(34) + strCommandName + Convert.ToChar(34) + ");";
                            txtProcCode.Text += "\r\n               " + @"// defining the command type.";
                            txtProcCode.Text += "\r\n               cmd" + strCommandName + ".CommandType = CommandType.StoredProcedure;";
                            txtProcCode.Text += "\r\n                " + @"// setting connection to the command.";
                            txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Connection = oCon;";
                        }
                    }
                }
                else
                {
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=mysql");
                    newOleDbCommand = new OleDbCommand("SELECT param_list FROM mysql.proc WHERE Name='" + strCommandName + "'", oCon);
                    byte[] strParameterList;
                    Array arrParameterList;
                    OleDbDataAdapter oOleDbDataAdapter = new OleDbDataAdapter(newOleDbCommand);
                    oOleDbDataAdapter.Fill(dsParameter);
                    strParameterList = (byte[])dsParameter.Tables[0].Rows[0][0];
                    DataTable dtParameter = new DataTable();
                    dtParameter.Columns.Add("Name", typeof(string));
                    dtParameter.Columns.Add("DataType", typeof(string));
                    string strByte = "";
                    arrParameterList = strParameterList.ToString().Split(',');
                    foreach (byte b in strParameterList)
                    {
                        strByte += Convert.ToChar(b).ToString();
                    }
                    arrParameterList = strByte.Split(',');
                    if (strParameterList.Length > 0)
                    {
                        for (int i = 0; i < arrParameterList.Length; i++)
                        {
                            DataRow drPara = dtParameter.NewRow();
                            drPara[0] = arrParameterList.GetValue(i).ToString().Trim().Substring(0, arrParameterList.GetValue(i).ToString().Trim().IndexOf(" "));
                            if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("varchar") != -1 || arrParameterList.GetValue(i).ToString().ToLower().IndexOf("nvarchar") != -1)
                                drPara[1] = "varchar";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("char") != -1)
                                drPara[1] = "char";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("bigint") != -1)
                                drPara[1] = "bigint";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("int") != -1)
                                drPara[1] = "int";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("ntext") != -1)
                                drPara[1] = "ntext";
                            else if (arrParameterList.GetValue(i).ToString().ToLower().IndexOf("bit") != -1)
                                drPara[1] = "bit";
                            else
                                drPara[1] = "varchar";
                            dtParameter.Rows.Add(drPara);
                            strParameterParanthisic += "?,";
                        }
                        strParameterParanthisic = strParameterParanthisic.Remove(strParameterParanthisic.LastIndexOf(","));
                        dsParameter.Tables.Add(dtParameter);
                    }
                    if (strOleDb == "OleDbType")
                    {
                        txtProcCode.Text = "                " + @"// Check for connection state.";
                        txtProcCode.Text += "\r\n               if(oCon.State==ConnectionState.Closed)";
                        txtProcCode.Text += "\r\n                    oCon.Open();";
                        txtProcCode.Text += "\r\n               " + @"// creating a command object to communicate with database.";
                        txtProcCode.Text += "\r\n               " + @"// & initializing command and connection to the object.";
                        txtProcCode.Text += "\r\n                   OleDbCommand cmd" + strCommandName + "=new OleDbCommand(";
                        txtProcCode.Text += Convert.ToChar(34) + "Call " + strCommandName + "(" + strParameterParanthisic + ")" + Convert.ToChar(34) + ", " + "oCon" + ");";
                        //txtProcCode.Text += "\r\n               " + @"// defining the command type.";
                        //txtProcCode.Text += "\r\n               cmd" + strCommandName + ".CommandType=CommandType.StoredProcedure;";
                    }
                    else
                    {
                        txtProcCode.Text = "                " + @"// Check for connection state.";
                        txtProcCode.Text += "\r\n               if(oCon.State==ConnectionState.Closed)";
                        txtProcCode.Text += "\r\n                    oCon.Open();";
                        txtProcCode.Text += "\r\n               " + @"// creating a command object to communicate with database & initializing command and connection to the object.";
                        txtProcCode.Text += "\r\n               MySqlCommand cmd" + strCommandName + "=new MySqlCommand(";
                        txtProcCode.Text += Convert.ToChar(34) + strCommandName + Convert.ToChar(34) + ", " + "oCon" + ");";
                        txtProcCode.Text += "\r\n               " + @"// defining the command type.";
                        txtProcCode.Text += "\r\n               cmd" + strCommandName + ".CommandType=CommandType.StoredProcedure;";
                    }
                }

                if (dsParameter.Tables.Count > 1)
                {
                    string strDataType = "";
                    foreach (DataRow dr in dsParameter.Tables[1].Rows)
                    {
                        if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                        {
                            if (dr[1].ToString() == "char")
                                strDataType = "SqlDbType.Char";
                            else if (dr[1].ToString() == "bigint")
                                strDataType = "SqlDbType.BigInt";
                            else if (dr[1].ToString() == "varchar")
                                strDataType = "SqlDbType.VarChar";
                            else if (dr[1].ToString() == "nvarchar")
                                strDataType = "SqlDbType.nVarChar";
                            else if (dr[1].ToString() == "text")
                                strDataType = "SqlDbType.Text";
                            else if (dr[1].ToString() == "ntext")
                                strDataType = "SqlDbType.NText";
                            else if (dr[1].ToString() == "decimal")
                                strDataType = "SqlDbType.Decimal";
                            else if (dr[1].ToString() == "bit")
                                strDataType = "SqlDbType.Bit";
                            else if (dr[1].ToString() == "float")
                                strDataType = "SqlDbType.Float";
                            else if (dr[1].ToString() == "tiniint")
                                strDataType = "SqlDbType.TiniInt";
                            else if (dr[1].ToString() == "datetime")
                                strDataType = "SqlDbType.DateTime";
                            else if (dr[1].ToString() == "int")
                                strDataType = "SqlDbType.Int";
                            else if (dr[1].ToString() == "text")
                                strDataType = "SqlDbType.Text";
                            else if (dr[1].ToString() == "binary")
                                strDataType = "SqlDbType.Binary";
                            else if (dr[1].ToString() == "numeric")
                                strDataType = "SqlDbType.Numeric";
                            else
                                strDataType = "SqlDbType." + dr[1].ToString();
                        }
                        else if (strOleDb != "OleDbType")
                        {
                            if (dr[1].ToString() == "char")
                                strDataType = "MySqlDbType.Char";
                            else if (dr[1].ToString() == "MySqlDbType.VarChar")
                                strDataType = "MySqlDbType.BigInt";
                            else if (dr[1].ToString() == "MySqlDbType.Int64")
                                strDataType = "typeof(string)";
                            else if (dr[1].ToString() == "nvarchar")
                                strDataType = "MySqlDbType.String";
                            else if (dr[1].ToString() == "bit")
                                strDataType = "MySqlDbType.Bit";
                            else if (dr[1].ToString() == "float")
                                strDataType = "MySqlDbType.Float";
                            else if (dr[1].ToString() == "tiniint")
                                strDataType = "MySqlDbType.Int16";
                            else if (dr[1].ToString() == "datetime")
                                strDataType = "MySqlDbType.Datetime";
                            else if (dr[1].ToString() == "int")
                                strDataType = "MySqlDbType.Int32";
                            else if (dr[1].ToString() == "numeric")
                                strDataType = "MySqlDbType.Numeric";
                            else if (dr[1].ToString() == "varchar")
                                strDataType = "MySqlDbType.String";
                            else if (dr[1].ToString() == "char")
                                strDataType = "MySqlDbType.VarChar";
                            else if (dr[1].ToString() == "bigint")
                                strDataType = "MySqlDbType.Int64";
                            else if (dr[1].ToString() == "int")
                                strDataType = "MySqlDbType.Int32";
                            else if (dr[1].ToString() == "bit")
                                strDataType = "MySqlDbType.Bit";
                            else
                                strDataType = "MySqlDbType." + dr[1].ToString();
                        }
                        else
                        {
                            if (dr[1].ToString() == "char")
                                strDataType = "OleDbType.Char";
                            else if (dr[1].ToString() == "bigint")
                                strDataType = "OleDbType.BigInt";
                            else if (dr[1].ToString() == "varchar")
                                strDataType = "OleDbType.VarChar";
                            else if (dr[1].ToString() == "nvarchar")
                                strDataType = "OleDbType.NVarChar";
                            else if (dr[1].ToString() == "bit")
                                strDataType = "OleDbType.Bit";
                            else if (dr[1].ToString() == "float")
                                strDataType = "OleDbType.Float";
                            else if (dr[1].ToString() == "tiniint")
                                strDataType = "OleDbType.TiniInt";
                            else if (dr[1].ToString() == "datetime")
                                strDataType = "OleDbType.DateTime";
                            else if (dr[1].ToString() == "int")
                                strDataType = "OleDbType.Int";
                            else if (dr[1].ToString() == "numeric")
                                strDataType = "OleDbType.BigInt";
                            else
                                strDataType = "OleDbType." + dr[1].ToString();
                        }
                        if (Operation == "I" && dr[0].ToString().Remove(0, 1) == "Flag")
                        {
                            txtProcCode.Text += "\r\n               " + @"// adding parameter with name " + dr[0].ToString() + " to the command.";
                            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                            else
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                        }
                        else if (Operation == "U" && dr[0].ToString().Remove(0, 1) == "Flag")
                        {
                            txtProcCode.Text += "\r\n               " + @"// adding parameter with name " + dr[0].ToString() + " to the command.";
                            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                            else
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                        }
                        else if (Operation == "D" && dr[0].ToString().Remove(0, 1) == "Flag")
                        {
                            txtProcCode.Text += "\r\n               " + @"// adding parameter with name " + dr[0].ToString() + " to the command.";
                            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                            else
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                        }
                        else if (Operation == "A" && dr[0].ToString().Remove(0, 1) == "Flag")
                        {
                            txtProcCode.Text += "\r\n               " + @"// adding parameter with name " + dr[0].ToString() + " to the command.";
                            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                            else
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ".Operation.ToString().Replace('_', ' ');";
                        }
                        else if (Operation == "S" && dr[0].ToString().Remove(0, 1) == "Flag")
                        {
                            txtProcCode.Text += "\r\n               " + @"// adding parameter with name " + dr[0].ToString() + " to the command.";
                            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = '" + Operation + "';";
                            else
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = '" + Operation + "';";
                        }
                        else
                        {
                            txtProcCode.Text += "\r\n               " + @"// adding parameter with name " + dr[0].ToString() + " to the command.";
                            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString().Remove(0, 1) + ";";
                            else
                                txtProcCode.Text += "\r\n               cmd" + strCommandName + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + ", " + strDataType + ").Value = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString().Remove(0, 1) + ";";
                        }
                    }
                }
                if (Operation == "A" || Operation == "S")
                {
                    if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataTable")
                    {
                        if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                        {
                            txtProcCode.Text += "\r\n               //creating the adaptor object to get data from the database.";
                            txtProcCode.Text += "\r\n               SqlDataAdapter da" + strCommandName + "= new SqlDataAdapter(cmd" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //creating the datatable object to hold data from the database.";
                            txtProcCode.Text += "\r\n               DataTable dt" + strCommandName + " = new DataTable();";
                            txtProcCode.Text += "\r\n               //fill the datatable with data.";
                            txtProcCode.Text += "\r\n               da" + strCommandName + ".Fill(dt" + strCommandName + ");";
                            #region Change 27th Nov 2008 Details in Get Method
                            string strConvert = "";
                            if (Operation == "S")
                            {
                                txtProcCode.Text += "\r\n               if (dt" + strCommandName + ".Rows.Count > 0)";
                                txtProcCode.Text += "\r\n               {";
                                newOleDbCommand = new OleDbCommand("SP_HELP " + TableName, oCon);
                                OleDbDataAdapter daColumns = new OleDbDataAdapter(newOleDbCommand);
                                DataSet dsCol = new DataSet();
                                daColumns.Fill(dsCol);

                                foreach (DataRow dr in dsCol.Tables[1].Rows)
                                {
                                    strConvert = "Convert.To";
                                    if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                                    {
                                        if (dr[1].ToString() == "char")
                                            strConvert += "String(";
                                        else if (dr[1].ToString() == "bigint")
                                            strConvert += "Int64(";
                                        else if (dr[1].ToString() == "varchar")
                                            strConvert += "String(";
                                        else if (dr[1].ToString() == "nvarchar")
                                            strConvert += "String(";
                                        else if (dr[1].ToString() == "text")
                                            strConvert += "String(";
                                        else if (dr[1].ToString() == "ntext")
                                            strConvert += "String(";
                                        else if (dr[1].ToString() == "decimal")
                                            strConvert += "Decimal(";
                                        else if (dr[1].ToString() == "bit")
                                            strConvert += "Boolean(";
                                        else if (dr[1].ToString() == "float")
                                            strConvert += "Double(";
                                        else if (dr[1].ToString() == "tiniint")
                                            strConvert += "Int16";
                                        else if (dr[1].ToString() == "datetime")
                                            strConvert += "DateTime(";
                                        else if (dr[1].ToString() == "int")
                                            strConvert += "Int32(";
                                        else if (dr[1].ToString() == "text")
                                            strConvert += "String(";
                                        else if (dr[1].ToString() == "numeric")
                                            strConvert += "Decimal(";
                                        else
                                            strConvert = "SqlDbType." + dr[1].ToString();
                                    }
                                    txtProcCode.Text += "\r\n                   //setting value for property " + dr[0].ToString() + ".";
                                    txtProcCode.Text += "\r\n                   " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = " + strConvert + "dt" + strCommandName + ".Rows[0][" + Convert.ToChar(34) + dr[0].ToString() + Convert.ToChar(34) + "]);";
                                }
                                txtProcCode.Text += "\r\n               }";
                            }
                            #endregion
                            txtProcCode.Text += "\r\n               //return datatable.";
                            txtProcCode.Text += "\r\n               return dt" + strCommandName + ";";
                        }
                        else if (!IsSqlClient)
                        {
                            txtProcCode.Text += "\r\n               //creating the adaptor object to get data from the database.";
                            txtProcCode.Text += "\r\n               OleDbDataAdapter da" + strCommandName + "= new OleDbDataAdapter(cmd" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //creating the datatable object to hold data from the database.";
                            txtProcCode.Text += "\r\n               DataTable dt" + strCommandName + " = new DataTable();";
                            txtProcCode.Text += "\r\n               //fill the datatable with data.";
                            txtProcCode.Text += "\r\n               da" + strCommandName + ".Fill(dt" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //return datatable.";
                            txtProcCode.Text += "\r\n               return dt" + strCommandName + ";";
                        }
                        else
                        {
                            txtProcCode.Text += "\r\n               //creating the adaptor object to get data from the database.";
                            txtProcCode.Text += "\r\n               MySqlDataAdapter da" + strCommandName + "= new MySqlDataAdapter(cmd" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //creating the datatable object to hold data from the database.";
                            txtProcCode.Text += "\r\n               DataTable dt" + strCommandName + " = new DataTable();";
                            txtProcCode.Text += "\r\n               //fill the datatable with data.";
                            txtProcCode.Text += "\r\n               da" + strCommandName + ".Fill(dt" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //return datatable.";
                            txtProcCode.Text += "\r\n               return dt" + strCommandName + ";";
                        }
                    }
                    else if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataSet")
                    {
                        if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                        {
                            txtProcCode.Text += "\r\n               //creating the adaptor object to get data from the database.";
                            txtProcCode.Text += "\r\n               SqlDataAdapter da" + strCommandName + "= new SqlDataAdapter(cmd" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //creating the dataset object to hold data from the database.";
                            txtProcCode.Text += "\r\n               DataSet ds" + strCommandName + " = new DataSet();";
                            txtProcCode.Text += "\r\n               //fill the datatable with data.";
                            txtProcCode.Text += "\r\n               da" + strCommandName + ".Fill(dt" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //return datatable.";
                            txtProcCode.Text += "\r\n               return dt" + strCommandName + ";";
                        }
                        else if (!IsSqlClient)
                        {
                            txtProcCode.Text += "\r\n               //creating the adaptor object to get data from the database.";
                            txtProcCode.Text += "\r\n               OleDbDataAdapter da" + strCommandName + "= new OleDbDataAdapter(cmd" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //creating the dataset object to hold data from the database.";
                            txtProcCode.Text += "\r\n               DataSet ds" + strCommandName + " = new DataSet();";
                            txtProcCode.Text += "\r\n               //fill the dataset with data.";
                            txtProcCode.Text += "\r\n               da" + strCommandName + ".Fill(ds" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //return dataset.";
                            txtProcCode.Text += "\r\n               return ds" + strCommandName + ";";
                        }
                        else
                        {
                            txtProcCode.Text += "\r\n               //creating the adaptor object to get data from the database.";
                            txtProcCode.Text += "\r\n               MySqlDataAdapter da" + strCommandName + "= new MySqlDataAdapter(cmd" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //creating the dataset object to hold data from the database.";
                            txtProcCode.Text += "\r\n               DataSet ds" + strCommandName + " = new DataSet();";
                            txtProcCode.Text += "\r\n               //fill the dataset with data.";
                            txtProcCode.Text += "\r\n               da" + strCommandName + ".Fill(ds" + strCommandName + ");";
                            txtProcCode.Text += "\r\n               //return dataset.";
                            txtProcCode.Text += "\r\n               return ds" + strCommandName + ";";
                        }
                    }
                    else if (dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() == "DataReader")
                    {
                        if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                        {
                            txtProcCode.Text += "\r\n               //creating the reader object to get data from the database.";
                            txtProcCode.Text += "\r\n               SqlDataReader dr" + strCommandName + "= cmd" + strCommandName + ".ExecureReader();";
                            txtProcCode.Text += "\r\n               return dr" + strCommandName + ";";
                        }
                        else if (!IsSqlClient)
                        {
                            txtProcCode.Text += "\r\n               OleDbDataReader dr" + strCommandName + "= cmd" + strCommandName + ".ExecuteReader();";
                            txtProcCode.Text += "\r\n               return dr" + strCommandName + ";";
                        }
                        else
                        {
                            txtProcCode.Text += "\r\n               MySqlDataReader dr" + strCommandName + "= cmd" + strCommandName + ".ExecuteReader();";
                            txtProcCode.Text += "\r\n               return dr" + strCommandName + ";";
                        }
                    }
                    else
                    {
                        txtProcCode.Text += "\r\n               return cmd" + ".ExecuteScalar();";
                    }
                }
                else if (Operation == "I")
                {
                    string strPrimaryPropertyValue = "";
                    txtProcCode.Text += "\r\n               //executing the command to open connection.\r\n               ";
                    int iIndexForPrimaryKey = 0;
                    foreach (DataRow dr in dsParameter.Tables[1].Rows)
                    {
                        strPrimaryPropertyValue = dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + TableName.Replace("tbl", "") + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString().Remove(0, 1) + " = ";
                        iIndexForPrimaryKey++;
                        if (iIndexForPrimaryKey == 2)
                            break;
                    }
                    txtProcCode.Text += strPrimaryPropertyValue + "Convert.ToString(cmd" + strCommandName + ".ExecuteScalar());";
                }
                else
                {
                    txtProcCode.Text += "\r\n               //executing the command to open connection.";
                    txtProcCode.Text += "\r\n               cmd" + strCommandName + ".ExecuteNonQuery();";
                }
                return txtProcCode.Text;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
                throw ex;
            }
        }
        #endregion

        #region Creation of Table Structure Of any Database of SQL Server
        private Excel.Application ExcelApp;
        private Excel.Workbook objBook;
        private Excel.Worksheet objSheet;
        //private Excel.Range range;
        //string strAttendeeList, strAbsenteeList, strCopiesToList;
        //int totActionItems;
        //object oMissing, oTemplate;
        //private string strTitle;

        private void btnColumns_Click(object sender, EventArgs e)
        {
            WriteXLS();
        }
        private void WriteXLS()
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                object fileName = "normal.xls";
                object newTemplate = false;
                object docType = 0;
                object isVisible = true;

                ExcelApp = new Excel.ApplicationClass();
                ExcelApp.Visible = true;
                objBook = ExcelApp.Workbooks.Add(missing);
                int iCounterForTables = 1;
                int iCounter = 0;
                foreach (string strTable in arrlstTables)
                {
                    if (objBook.Sheets.Count < iCounter + 1)
                    {
                    }
                    else
                    {
                        objBook.Sheets.Add(missing, missing, missing, missing);
                    }
                    iCounter++;
                }
                foreach (string strTable in arrlstTables)
                {
                    if (MessageBox.Show("Do you wish to add this [ " + strTable + " ] to excel?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().ToLower() == "no")
                    {

                    }
                    else
                    {
                        if (conCC.State == ConnectionState.Closed)
                            conCC.Open();
                        OleDbCommand objOleDbCommand = new OleDbCommand();
                        DataSet dsColumnsWriting = new DataSet();
                        objOleDbCommand.CommandText = "SP_HELP [" + strTable + "]";
                        objOleDbCommand.Connection = conCC;
                        oOleDbDataAdapterGetRecordsFromSelectedTable = new OleDbDataAdapter();
                        oOleDbDataAdapterGetRecordsFromSelectedTable.SelectCommand = objOleDbCommand;
                        oOleDbDataAdapterGetRecordsFromSelectedTable.Fill(dsColumnsWriting);
                        int iColumnCounter = 0;
                        foreach (DataRow drCol in dsColumnsWriting.Tables[1].Rows)
                        {
                            ArrayList arrlst = new ArrayList();
                            arrlst.Add(strTable);
                            arrlst.Add(drCol[0].ToString());
                            arrlst.Add(drCol[1].ToString());
                            arrlst.Add(drCol[3].ToString());
                            CreateFile(arrlst, iColumnCounter, iCounterForTables);
                            iColumnCounter += 1;
                        }
                        conCC.Close();
                        iCounterForTables += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        public void CreateFile(ArrayList array, int iCounter, int iSheetNumber)
        {
            if (iCounter == 0)
            {
                object missing = System.Reflection.Missing.Value;
                objSheet = (Excel.Worksheet)objBook.Sheets[iSheetNumber];
                string strSheetName = array[0].ToString().Replace("tbl", "");
                if (strSheetName.Length <= 30)
                    objSheet.Name = strSheetName;
                else
                    objSheet.Name = strSheetName.Substring(0, 30);
                //objSheet.Cells[1, 1] = array[0].ToString();

                //objSheet.Cells[2, 1] = "Column Name";
                //objSheet.Cells[2, 2] = "Data Type";
                //objSheet.Cells[2, 3] = "Length";

                objSheet.Cells[1, 1] = array[1].ToString();
                objSheet.Cells[1, 2] = array[2].ToString();
                objSheet.Cells[1, 3] = array[3].ToString();
            }
            else
            {
                objSheet.Cells[iCounter + 1, 1] = array[1].ToString();
                objSheet.Cells[iCounter + 1, 2] = array[2].ToString();
                objSheet.Cells[iCounter + 1, 3] = array[3].ToString();
            }
        }
        #endregion

        private void picErrorManagement_Click(object sender, EventArgs e)
        {
            getObjectsFromDatabase(cmbDataBase.Text);
            Errors oErrorManager = new Errors();
            oErrorManager.ShowInTaskbar = false;
            oErrorManager.ShowDialog();
        }

        private void imgReconnect_Click(object sender, EventArgs e)
        {
            this.Hide();
            Connection oConnection = new Connection("First");
            oConnection.ShowInTaskbar = false;
            oConnection.Show();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            arrlstParameters.Add(cmbDataBase.Text);
            Enterprise frmEnterprise = new Enterprise(arrlstParameters);
            frmEnterprise.ShowInTaskbar = false;
            frmEnterprise.ShowDialog();
        }

        private void txtCNPreFix_TextChanged(object sender, EventArgs e)
        {

        }

        #region Table Data Script Generation Code
        /// <summary>
        /// function to generate the property class for given table.
        /// </summary>
        /// <param name="_TableName"></param>
        /// <returns>bool</returns>
        private bool GenerateTableData(string _TableName, string FileName)
        {
            try
            {
                //writing code for generating Property Class.
                System.IO.StreamWriter objStream = new StreamWriter(@"C:\CompleteDataBaseAccess\" + FileName, true);
                string strDataScripts = "";
                objStream.WriteLine("SET IDENTITY_INSERT " + _TableName + " ON\r\n\r\n");
                string strInsertSQL = "INSERT INTO " + _TableName + " (";
                string strValuesSQL = "";
                iCurrentRow = 0;
                foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                {
                    strInsertSQL += objDataColumn.ColumnName + ", ";
                }
                strInsertSQL = strInsertSQL.Substring(0, strInsertSQL.LastIndexOf(",")) + ")\r\n\t";
                foreach (DataRow drRow in _oDataSetHoldingTheMainTableData.Tables[0].Rows)
                {
                    iCurrentRow++;
                    SetControlPropertyValue(lblExport, "Text", "Exporting Table (" + _TableName + ") : Record " + iCurrentRow.ToString() + " of " + iTotalRow.ToString());
                    strValuesSQL = "VALUES (";
                    foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    {
                        if (objDataColumn.DataType.ToString() == "System.Boolean")
                            strValuesSQL += drRow[objDataColumn] == DBNull.Value ? "Null, " : Convert.ToInt32(drRow[objDataColumn]).ToString() + ", ";
                        //else if (objDataColumn.DataType.ToString() == "System.DateTime")
                        //{
                        //    strValuesSQL += "GetDate(), ";
                        //}
                        else
                            strValuesSQL += drRow[objDataColumn] == DBNull.Value ? "Null, " : "'" + drRow[objDataColumn].ToString().Replace("'", "''") + "', ";
                    }
                    strValuesSQL = strValuesSQL.Substring(0, strValuesSQL.LastIndexOf(",")) + ")\r\n";
                    if (strInsertSQL.Trim() != "")
                        objStream.WriteLine(strInsertSQL + strValuesSQL);
                    // strDataScripts += strInsertSQL + strValuesSQL;
                }
                objStream.WriteLine("SET IDENTITY_INSERT " + _TableName + " OFF\r\n\r\n");
                // initializing the stream to creating a .cs file in C:\CompleteDataBaseAccess\
                objStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                //inserting error.
                insError(ex.ToString());
                return false;
            }
        }

        #endregion

        Thread oThread;
        bool bIsSaperate = false;
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtUserInfo = new DataTable("tblUserInfo");
                dtUserInfo.Columns.Add("UserId", typeof(string));
                dtUserInfo.Columns.Add("FirstName", typeof(string));
                dtUserInfo.Columns.Add("LastName", typeof(string));
                dtUserInfo.Columns.Add("EmailAddress", typeof(string));
                dtUserInfo.Columns.Add("Topic", typeof(string));
                dtUserInfo.Columns.Add("Phone", typeof(string));
                dtUserInfo.Columns.Add("AboutUs", typeof(string));
                dtUserInfo.Columns.Add("IsClosed", typeof(int));
                DataTable dtChat = new DataTable("tblChat");
                dtChat.Columns.Add("IsRedCarpetMessage", typeof(int));
                dtChat.Columns.Add("Message", typeof(string));
                dtChat.Columns.Add("cDateTime", typeof(DateTime));
                DataRow dr1 = dtUserInfo.NewRow();
                dr1[0] = Guid.NewGuid().ToString();
                dr1[1] = "Aniruddha Singh";
                dr1[2] = "Kushwaha";
                dr1[3] = "aniruddha@intigate.co.in";
                dr1[4] = "Holidays in India / Indian Resident";
                dr1[5] = "9953241404";
                dr1[6] = "NewsPaper Ad";
                dr1[7] = "0";
                dtUserInfo.Rows.Add(dr1);
                DataRow dr2 = dtChat.NewRow();
                dr2[0] = "0";
                dr2[1] = "hello is there anybody to help me";
                dr2[2] = DateTime.Now;
                dtChat.Rows.Add(dr2);
                ds.Tables.Add(dtUserInfo);
                ds.Tables.Add(dtChat);
                ds.WriteXml(@"D:\RedCarpetChat.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                /*
                                string strCommand = "SELECT 	OBJECT_NAME(F.parent_object_id) AS TableName, COL_NAME(FC.parent_object_id, FC.parent_column_id) AS ColumnName, OBJECT_NAME (F.referenced_object_id) AS ReferenceTableName, ";
                                strCommand += "		COL_NAME(FC.referenced_object_id, FC.referenced_column_id) AS ReferenceColumnName, F.Name AS ForeignKey ";
                                strCommand += "FROM 	sys.foreign_keys AS F ";
                                strCommand += "		INNER JOIN sys.foreign_key_columns AS FC ON (F.OBJECT_ID = FC.constraint_object_id) ";
                                strCommand += "ORDER BY ReferenceColumnName";
                */


                // intigate 
                if (DialogResult.Yes == MessageBox.Show("Do you want to put data into saperate file \r\n based upon table(s)", "Write Option", MessageBoxButtons.YesNo))
                    bIsSaperate = true;
                else
                    bIsSaperate = false;
                strSelectedDatabase = cmbDataBase.Text;
                oThread = new Thread(new ThreadStart(GTD));
                oThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        string strSelectedDatabase;
        public void GTD()
        {
            string strFileName = strSelectedDatabase + DateTime.Now.ToString("_dd_MM_yyyy_HH_mm") + ".sql";
            if (chkAllTables.Checked)
            {
                //loop for all tables in the database.
                foreach (string strTable in arrlstTables)
                {
                    if (bIsSaperate)
                        strFileName = strSelectedDatabase + "_" + strTable + "_" + DateTime.Now.ToString("_dd_MM_yyyy_HH_mm") + ".sql";
                    //check for connection state.
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    //initialize the command to getting all the records from the database for active table.
                    OleDbCommand oOleDbCommandDataFromActiveTable = new OleDbCommand("SELECT * FROM " + strTable, conCC);
                    //reinitialize the global data adapter.
                    oOleDbDataAdapterGetRecordsFromSelectedTable = new OleDbDataAdapter(oOleDbCommandDataFromActiveTable);
                    //clear the global dataset.
                    _oDataSetHoldingTheMainTableData.Tables.Clear();
                    //filling the global dataset.
                    oOleDbDataAdapterGetRecordsFromSelectedTable.Fill(_oDataSetHoldingTheMainTableData, "dTabels");
                    iTotalRow = _oDataSetHoldingTheMainTableData.Tables[0].Rows.Count;
                    //lblExport.Text = "Exporting Table (" + strTable + ") : Record 0 of " + _oDataSetHoldingTheMainTableData.Tables[0].Rows.Count.ToString();
                    //calling the funtion to generate property class for given table.
                    GenerateTableData(strTable, strFileName);
                    //closing connection.
                    conCC.Close();
                }
                oThread.Abort();
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            try
            {
                frmWebFormDesign oWD = new frmWebFormDesign(arrlstParameters);
                //oWD.ShowInTaskbar = false;
                oWD.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnMVC_Click(object sender, EventArgs e)
        {
            try
            {
                frmMVC oWD = new frmMVC(conCC);
                oWD.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}