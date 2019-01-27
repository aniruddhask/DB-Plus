using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CompleteDataBase : System.Windows.Forms.Form
	{
		SqlConnection objSqlConnection;
		DataSet objDataSet = new DataSet();
		int i;
		int clmCounter = 0;
		int rowCounter = 0;
		SqlDataAdapter objSqlDataAdapter;
		private System.Windows.Forms.ComboBox cmbDataBase;
		private System.Windows.Forms.ComboBox cmbTables;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_ShowTableContent;
		private System.Windows.Forms.Button btn_First;
		private System.Windows.Forms.Button btn_Previous;
		private System.Windows.Forms.Button btn_Next;
		private System.Windows.Forms.Button btn_Last;
		private System.Windows.Forms.Button btn_AddNew;
		private System.Windows.Forms.Button btn_Update;
		private System.Windows.Forms.Button btn_Delete;
		private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btn_GenerateBD;
		private System.Windows.Forms.Button btn_GeneretBR;
		private System.Windows.Forms.Button btn_GenerateBO;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNameSpace;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCNPreFix;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCNPostFix;
		private System.Windows.Forms.TextBox txtPrivateVariablePreFix;
		private System.Windows.Forms.Label label7;
		private System.ComponentModel.IContainer components;


		string strServerName="";
		string strLoginName="";
		private System.Windows.Forms.GroupBox gbxDataBase;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbBD;
		private System.Windows.Forms.TabPage tbBR;
		private System.Windows.Forms.TabPage tbBO;
		private System.Windows.Forms.CheckBox chkAllTables;
		private System.Windows.Forms.ListBox lstProcedure;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblDesc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstFunction;
		private System.Windows.Forms.Button btnAddFun;
		private System.Windows.Forms.GroupBox gbxFunction;
		private System.Windows.Forms.Button btnRenameFunction;
		private System.Windows.Forms.Button btnDeleteFunction;
		private System.Windows.Forms.Button btnProcUsed;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbtnSql;
		private System.Windows.Forms.RadioButton rbtnOleDb;
		private System.Windows.Forms.Button btnViewUsed;
		private System.Windows.Forms.Button btnEditFunction;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnAnalyser;
		private System.Windows.Forms.Button btnGenerate;
		string strPassword="";
		public CompleteDataBase(SqlConnection newSqlConnection)
		{
			InitializeComponent();
			objSqlConnection=newSqlConnection;
		}
		public CompleteDataBase(string Server, string LoginName, string Password)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			strServerName=Server;
			strLoginName=LoginName;
			strPassword=Password;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CompleteDataBase));
			this.cmbDataBase = new System.Windows.Forms.ComboBox();
			this.cmbTables = new System.Windows.Forms.ComboBox();
			this.btn_ShowTableContent = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Delete = new System.Windows.Forms.Button();
			this.btn_Update = new System.Windows.Forms.Button();
			this.btn_AddNew = new System.Windows.Forms.Button();
			this.btn_Last = new System.Windows.Forms.Button();
			this.btn_Next = new System.Windows.Forms.Button();
			this.btn_Previous = new System.Windows.Forms.Button();
			this.btn_First = new System.Windows.Forms.Button();
			this.btn_Add = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btn_GenerateBO = new System.Windows.Forms.Button();
			this.btn_GeneretBR = new System.Windows.Forms.Button();
			this.btn_GenerateBD = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txtPrivateVariablePreFix = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtCNPostFix = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCNPreFix = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNameSpace = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.gbxDataBase = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbBD = new System.Windows.Forms.TabPage();
			this.chkAllTables = new System.Windows.Forms.CheckBox();
			this.tbBR = new System.Windows.Forms.TabPage();
			this.tbBO = new System.Windows.Forms.TabPage();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btnEditFunction = new System.Windows.Forms.Button();
			this.btnViewUsed = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbtnOleDb = new System.Windows.Forms.RadioButton();
			this.rbtnSql = new System.Windows.Forms.RadioButton();
			this.btnProcUsed = new System.Windows.Forms.Button();
			this.gbxFunction = new System.Windows.Forms.GroupBox();
			this.btnAddFun = new System.Windows.Forms.Button();
			this.btnRenameFunction = new System.Windows.Forms.Button();
			this.btnDeleteFunction = new System.Windows.Forms.Button();
			this.lstFunction = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.lstProcedure = new System.Windows.Forms.ListBox();
			this.lblDesc = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.btnAnalyser = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.gbxDataBase.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tbBD.SuspendLayout();
			this.tbBR.SuspendLayout();
			this.tbBO.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gbxFunction.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbDataBase
			// 
			this.cmbDataBase.BackColor = System.Drawing.Color.White;
			this.cmbDataBase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmbDataBase.Location = new System.Drawing.Point(10, 18);
			this.cmbDataBase.Name = "cmbDataBase";
			this.cmbDataBase.Size = new System.Drawing.Size(173, 22);
			this.cmbDataBase.TabIndex = 1;
			this.cmbDataBase.Text = "DataBases";
			this.cmbDataBase.Visible = false;
			this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
			// 
			// cmbTables
			// 
			this.cmbTables.BackColor = System.Drawing.Color.White;
			this.cmbTables.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmbTables.Location = new System.Drawing.Point(8, 8);
			this.cmbTables.Name = "cmbTables";
			this.cmbTables.Size = new System.Drawing.Size(176, 22);
			this.cmbTables.TabIndex = 3;
			this.cmbTables.Text = "Tables";
			this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
			// 
			// btn_ShowTableContent
			// 
			this.btn_ShowTableContent.BackColor = System.Drawing.SystemColors.Control;
			this.btn_ShowTableContent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_ShowTableContent.Location = new System.Drawing.Point(8, 11);
			this.btn_ShowTableContent.Name = "btn_ShowTableContent";
			this.btn_ShowTableContent.Size = new System.Drawing.Size(81, 23);
			this.btn_ShowTableContent.TabIndex = 0;
			this.btn_ShowTableContent.Text = "&Column (s)";
			this.btn_ShowTableContent.Click += new System.EventHandler(this.btn_ShowTableContent_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel1.Location = new System.Drawing.Point(3, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(567, 213);
			this.panel1.TabIndex = 1;
			// 
			// btn_Delete
			// 
			this.btn_Delete.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Delete.Location = new System.Drawing.Point(8, 112);
			this.btn_Delete.Name = "btn_Delete";
			this.btn_Delete.Size = new System.Drawing.Size(80, 23);
			this.btn_Delete.TabIndex = 7;
			this.btn_Delete.Text = "&Delete";
			this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
			// 
			// btn_Update
			// 
			this.btn_Update.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Update.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Update.Location = new System.Drawing.Point(8, 80);
			this.btn_Update.Name = "btn_Update";
			this.btn_Update.Size = new System.Drawing.Size(80, 23);
			this.btn_Update.TabIndex = 6;
			this.btn_Update.Text = "&Update";
			this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
			// 
			// btn_AddNew
			// 
			this.btn_AddNew.BackColor = System.Drawing.SystemColors.Control;
			this.btn_AddNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_AddNew.Location = new System.Drawing.Point(8, 16);
			this.btn_AddNew.Name = "btn_AddNew";
			this.btn_AddNew.Size = new System.Drawing.Size(80, 23);
			this.btn_AddNew.TabIndex = 5;
			this.btn_AddNew.Text = "Add Ne&w";
			this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
			// 
			// btn_Last
			// 
			this.btn_Last.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Last.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Last.Location = new System.Drawing.Point(384, 11);
			this.btn_Last.Name = "btn_Last";
			this.btn_Last.Size = new System.Drawing.Size(88, 23);
			this.btn_Last.TabIndex = 4;
			this.btn_Last.Text = "&Last";
			this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
			// 
			// btn_Next
			// 
			this.btn_Next.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Next.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Next.Location = new System.Drawing.Point(288, 11);
			this.btn_Next.Name = "btn_Next";
			this.btn_Next.Size = new System.Drawing.Size(88, 23);
			this.btn_Next.TabIndex = 3;
			this.btn_Next.Text = "&Next";
			this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
			// 
			// btn_Previous
			// 
			this.btn_Previous.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Previous.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Previous.Location = new System.Drawing.Point(192, 11);
			this.btn_Previous.Name = "btn_Previous";
			this.btn_Previous.Size = new System.Drawing.Size(87, 23);
			this.btn_Previous.TabIndex = 2;
			this.btn_Previous.Text = "&Previous";
			this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
			// 
			// btn_First
			// 
			this.btn_First.BackColor = System.Drawing.SystemColors.Control;
			this.btn_First.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_First.Location = new System.Drawing.Point(96, 11);
			this.btn_First.Name = "btn_First";
			this.btn_First.Size = new System.Drawing.Size(88, 23);
			this.btn_First.TabIndex = 1;
			this.btn_First.Text = "&First";
			this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
			// 
			// btn_Add
			// 
			this.btn_Add.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_Add.Location = new System.Drawing.Point(8, 48);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(80, 23);
			this.btn_Add.TabIndex = 8;
			this.btn_Add.Text = "&Add";
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.groupBox1.Controls.Add(this.btn_ShowTableContent);
			this.groupBox1.Controls.Add(this.btn_First);
			this.groupBox1.Controls.Add(this.btn_Previous);
			this.groupBox1.Controls.Add(this.btn_Next);
			this.groupBox1.Controls.Add(this.btn_Last);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.Location = new System.Drawing.Point(200, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(479, 39);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.groupBox3.Controls.Add(this.btn_AddNew);
			this.groupBox3.Controls.Add(this.btn_Add);
			this.groupBox3.Controls.Add(this.btn_Update);
			this.groupBox3.Controls.Add(this.btn_Delete);
			this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox3.Location = new System.Drawing.Point(579, 40);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(96, 144);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Commands";
			// 
			// btn_GenerateBO
			// 
			this.btn_GenerateBO.AllowDrop = true;
			this.btn_GenerateBO.BackColor = System.Drawing.SystemColors.Control;
			this.btn_GenerateBO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_GenerateBO.Location = new System.Drawing.Point(552, 232);
			this.btn_GenerateBO.Name = "btn_GenerateBO";
			this.btn_GenerateBO.Size = new System.Drawing.Size(104, 23);
			this.btn_GenerateBO.TabIndex = 3;
			this.btn_GenerateBO.Text = "Generate B&O";
			this.btn_GenerateBO.Click += new System.EventHandler(this.btn_GenerateBO_Click);
			// 
			// btn_GeneretBR
			// 
			this.btn_GeneretBR.BackColor = System.Drawing.SystemColors.Control;
			this.btn_GeneretBR.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_GeneretBR.Location = new System.Drawing.Point(568, 229);
			this.btn_GeneretBR.Name = "btn_GeneretBR";
			this.btn_GeneretBR.Size = new System.Drawing.Size(104, 23);
			this.btn_GeneretBR.TabIndex = 2;
			this.btn_GeneretBR.Text = "Generate B&R";
			this.btn_GeneretBR.Click += new System.EventHandler(this.btn_GeneretBR_Click);
			// 
			// btn_GenerateBD
			// 
			this.btn_GenerateBD.BackColor = System.Drawing.SystemColors.Control;
			this.btn_GenerateBD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_GenerateBD.Location = new System.Drawing.Point(584, 223);
			this.btn_GenerateBD.Name = "btn_GenerateBD";
			this.btn_GenerateBD.Size = new System.Drawing.Size(90, 23);
			this.btn_GenerateBD.TabIndex = 1;
			this.btn_GenerateBD.Text = "Generate B&D";
			this.btn_GenerateBD.Click += new System.EventHandler(this.btn_GenerateBD_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(239)), ((System.Byte)(220)));
			this.groupBox6.Controls.Add(this.txtPrivateVariablePreFix);
			this.groupBox6.Controls.Add(this.label7);
			this.groupBox6.Controls.Add(this.txtCNPostFix);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Controls.Add(this.txtCNPreFix);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.txtNameSpace);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox6.Location = new System.Drawing.Point(-88, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(992, 64);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "              Namespace & ClassNamePrefix";
			// 
			// txtPrivateVariablePreFix
			// 
			this.txtPrivateVariablePreFix.BackColor = System.Drawing.Color.White;
			this.txtPrivateVariablePreFix.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtPrivateVariablePreFix.Location = new System.Drawing.Point(544, 16);
			this.txtPrivateVariablePreFix.Name = "txtPrivateVariablePreFix";
			this.txtPrivateVariablePreFix.Size = new System.Drawing.Size(120, 20);
			this.txtPrivateVariablePreFix.TabIndex = 7;
			this.txtPrivateVariablePreFix.Text = "";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(239)), ((System.Byte)(220)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(376, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(161, 15);
			this.label7.TabIndex = 6;
			this.label7.Text = "Private Variable PreFix";
			// 
			// txtCNPostFix
			// 
			this.txtCNPostFix.BackColor = System.Drawing.Color.White;
			this.txtCNPostFix.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCNPostFix.Location = new System.Drawing.Point(544, 40);
			this.txtCNPostFix.Name = "txtCNPostFix";
			this.txtCNPostFix.Size = new System.Drawing.Size(120, 20);
			this.txtCNPostFix.TabIndex = 5;
			this.txtCNPostFix.Text = "";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(239)), ((System.Byte)(220)));
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(376, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 15);
			this.label6.TabIndex = 4;
			this.label6.Text = "ClassNamePostfix";
			// 
			// txtCNPreFix
			// 
			this.txtCNPreFix.BackColor = System.Drawing.Color.White;
			this.txtCNPreFix.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtCNPreFix.Location = new System.Drawing.Point(248, 40);
			this.txtCNPreFix.Name = "txtCNPreFix";
			this.txtCNPreFix.Size = new System.Drawing.Size(120, 20);
			this.txtCNPreFix.TabIndex = 3;
			this.txtCNPreFix.Text = "";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(239)), ((System.Byte)(220)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(136, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(109, 15);
			this.label5.TabIndex = 2;
			this.label5.Text = "ClassNamePrefix";
			// 
			// txtNameSpace
			// 
			this.txtNameSpace.BackColor = System.Drawing.Color.White;
			this.txtNameSpace.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtNameSpace.Location = new System.Drawing.Point(248, 16);
			this.txtNameSpace.Name = "txtNameSpace";
			this.txtNameSpace.Size = new System.Drawing.Size(120, 20);
			this.txtNameSpace.TabIndex = 1;
			this.txtNameSpace.Text = "";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(239)), ((System.Byte)(220)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(136, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 15);
			this.label4.TabIndex = 0;
			this.label4.Text = "namespace";
			// 
			// gbxDataBase
			// 
			this.gbxDataBase.BackColor = System.Drawing.SystemColors.Control;
			this.gbxDataBase.Controls.Add(this.cmbDataBase);
			this.gbxDataBase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbxDataBase.Location = new System.Drawing.Point(8, 0);
			this.gbxDataBase.Name = "gbxDataBase";
			this.gbxDataBase.Size = new System.Drawing.Size(192, 46);
			this.gbxDataBase.TabIndex = 14;
			this.gbxDataBase.TabStop = false;
			this.gbxDataBase.Text = "Choose DataBase";
			this.gbxDataBase.Visible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbBD);
			this.tabControl1.Controls.Add(this.tbBR);
			this.tabControl1.Controls.Add(this.tbBO);
			this.tabControl1.Location = new System.Drawing.Point(3, 71);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(688, 283);
			this.tabControl1.TabIndex = 5;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tbBD
			// 
			this.tbBD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.tbBD.Controls.Add(this.chkAllTables);
			this.tbBD.Controls.Add(this.cmbTables);
			this.tbBD.Controls.Add(this.panel1);
			this.tbBD.Controls.Add(this.groupBox1);
			this.tbBD.Controls.Add(this.groupBox3);
			this.tbBD.Controls.Add(this.btn_GenerateBD);
			this.tbBD.Location = new System.Drawing.Point(4, 23);
			this.tbBD.Name = "tbBD";
			this.tbBD.Size = new System.Drawing.Size(680, 256);
			this.tbBD.TabIndex = 0;
			this.tbBD.Text = "Business Data";
			// 
			// chkAllTables
			// 
			this.chkAllTables.Location = new System.Drawing.Point(582, 192);
			this.chkAllTables.Name = "chkAllTables";
			this.chkAllTables.Size = new System.Drawing.Size(91, 24);
			this.chkAllTables.TabIndex = 10;
			this.chkAllTables.Text = "All Tables";
			// 
			// tbBR
			// 
			this.tbBR.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(138)), ((System.Byte)(188)), ((System.Byte)(189)));
			this.tbBR.Controls.Add(this.btn_GeneretBR);
			this.tbBR.Location = new System.Drawing.Point(4, 23);
			this.tbBR.Name = "tbBR";
			this.tbBR.Size = new System.Drawing.Size(680, 256);
			this.tbBR.TabIndex = 1;
			this.tbBR.Text = "Business Rules";
			// 
			// tbBO
			// 
			this.tbBO.AutoScroll = true;
			this.tbBO.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.tbBO.Controls.Add(this.btnGenerate);
			this.tbBO.Controls.Add(this.btnEditFunction);
			this.tbBO.Controls.Add(this.btnViewUsed);
			this.tbBO.Controls.Add(this.groupBox2);
			this.tbBO.Controls.Add(this.btnProcUsed);
			this.tbBO.Controls.Add(this.gbxFunction);
			this.tbBO.Controls.Add(this.lstFunction);
			this.tbBO.Controls.Add(this.button1);
			this.tbBO.Controls.Add(this.lstProcedure);
			this.tbBO.Controls.Add(this.btn_GenerateBO);
			this.tbBO.Location = new System.Drawing.Point(4, 23);
			this.tbBO.Name = "tbBO";
			this.tbBO.Size = new System.Drawing.Size(680, 256);
			this.tbBO.TabIndex = 2;
			this.tbBO.Text = "Business Object";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(584, 8);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.TabIndex = 16;
			this.btnGenerate.Text = "&Generate";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// btnEditFunction
			// 
			this.btnEditFunction.Location = new System.Drawing.Point(272, 60);
			this.btnEditFunction.Name = "btnEditFunction";
			this.btnEditFunction.Size = new System.Drawing.Size(136, 23);
			this.btnEditFunction.TabIndex = 15;
			this.btnEditFunction.Text = "Edit Function...";
			// 
			// btnViewUsed
			// 
			this.btnViewUsed.Location = new System.Drawing.Point(272, 34);
			this.btnViewUsed.Name = "btnViewUsed";
			this.btnViewUsed.Size = new System.Drawing.Size(136, 23);
			this.btnViewUsed.TabIndex = 14;
			this.btnViewUsed.Text = "View Used...";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbtnOleDb);
			this.groupBox2.Controls.Add(this.rbtnSql);
			this.groupBox2.Location = new System.Drawing.Point(528, 192);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(128, 38);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Connection Type";
			// 
			// rbtnOleDb
			// 
			this.rbtnOleDb.Checked = true;
			this.rbtnOleDb.Location = new System.Drawing.Point(63, 16);
			this.rbtnOleDb.Name = "rbtnOleDb";
			this.rbtnOleDb.Size = new System.Drawing.Size(56, 16);
			this.rbtnOleDb.TabIndex = 1;
			this.rbtnOleDb.TabStop = true;
			this.rbtnOleDb.Text = "OleDb";
			// 
			// rbtnSql
			// 
			this.rbtnSql.Location = new System.Drawing.Point(8, 16);
			this.rbtnSql.Name = "rbtnSql";
			this.rbtnSql.Size = new System.Drawing.Size(45, 16);
			this.rbtnSql.TabIndex = 0;
			this.rbtnSql.Text = "Sql";
			// 
			// btnProcUsed
			// 
			this.btnProcUsed.Location = new System.Drawing.Point(272, 8);
			this.btnProcUsed.Name = "btnProcUsed";
			this.btnProcUsed.Size = new System.Drawing.Size(135, 23);
			this.btnProcUsed.TabIndex = 12;
			this.btnProcUsed.Text = "Procedures Used...";
			this.btnProcUsed.Click += new System.EventHandler(this.btnProcUsed_Click);
			// 
			// gbxFunction
			// 
			this.gbxFunction.Controls.Add(this.btnAddFun);
			this.gbxFunction.Controls.Add(this.btnRenameFunction);
			this.gbxFunction.Controls.Add(this.btnDeleteFunction);
			this.gbxFunction.Location = new System.Drawing.Point(8, 96);
			this.gbxFunction.Name = "gbxFunction";
			this.gbxFunction.Size = new System.Drawing.Size(256, 48);
			this.gbxFunction.TabIndex = 9;
			this.gbxFunction.TabStop = false;
			this.gbxFunction.Text = "Function(s)";
			// 
			// btnAddFun
			// 
			this.btnAddFun.Location = new System.Drawing.Point(8, 16);
			this.btnAddFun.Name = "btnAddFun";
			this.btnAddFun.TabIndex = 6;
			this.btnAddFun.Text = "Add";
			this.btnAddFun.Click += new System.EventHandler(this.btnAddFun_Click);
			// 
			// btnRenameFunction
			// 
			this.btnRenameFunction.Location = new System.Drawing.Point(88, 16);
			this.btnRenameFunction.Name = "btnRenameFunction";
			this.btnRenameFunction.TabIndex = 7;
			this.btnRenameFunction.Text = "Rename";
			this.btnRenameFunction.Click += new System.EventHandler(this.btnRenameFunction_Click);
			// 
			// btnDeleteFunction
			// 
			this.btnDeleteFunction.Location = new System.Drawing.Point(168, 16);
			this.btnDeleteFunction.Name = "btnDeleteFunction";
			this.btnDeleteFunction.TabIndex = 8;
			this.btnDeleteFunction.Text = "Delete";
			this.btnDeleteFunction.Click += new System.EventHandler(this.btnDeleteFunction_Click);
			// 
			// lstFunction
			// 
			this.lstFunction.ItemHeight = 14;
			this.lstFunction.Location = new System.Drawing.Point(8, 8);
			this.lstFunction.Name = "lstFunction";
			this.lstFunction.Size = new System.Drawing.Size(256, 88);
			this.lstFunction.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(176, 400);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lstProcedure
			// 
			this.lstProcedure.ItemHeight = 14;
			this.lstProcedure.Location = new System.Drawing.Point(8, 320);
			this.lstProcedure.Name = "lstProcedure";
			this.lstProcedure.Size = new System.Drawing.Size(163, 102);
			this.lstProcedure.TabIndex = 0;
			// 
			// lblDesc
			// 
			this.lblDesc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(5)), ((System.Byte)(0)), ((System.Byte)(6)));
			this.lblDesc.ForeColor = System.Drawing.Color.Silver;
			this.lblDesc.Location = new System.Drawing.Point(-8, 360);
			this.lblDesc.Name = "lblDesc";
			this.lblDesc.Size = new System.Drawing.Size(720, 16);
			this.lblDesc.TabIndex = 15;
			this.lblDesc.Text = "                                                      Powered & Supported By:- Bi" +
				"nary Solution Pvt. Ltd.";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(5)), ((System.Byte)(0)), ((System.Byte)(6)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 360);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "Utility Version:- 1.0.2309.23154";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(608, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "&Reconnect";
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnAnalyser
			// 
			this.btnAnalyser.Location = new System.Drawing.Point(528, 7);
			this.btnAnalyser.Name = "btnAnalyser";
			this.btnAnalyser.TabIndex = 18;
			this.btnAnalyser.Text = "Anal&yser";
			this.btnAnalyser.Visible = false;
			this.btnAnalyser.Click += new System.EventHandler(this.btnAnalyser_Click);
			// 
			// CompleteDataBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(699, 380);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblDesc);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnAnalyser);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.gbxDataBase);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "CompleteDataBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Complete DataBase Access Control";
			this.Load += new System.EventHandler(this.CompleteDataBase_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.gbxDataBase.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tbBD.ResumeLayout(false);
			this.tbBR.ResumeLayout(false);
			this.tbBO.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.gbxFunction.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		DataTable dtTables=new DataTable();

		private void CompleteDataBase_Load(object sender, System.EventArgs e)
		{
			try
			{
				btnAnalyser.Enabled=false;
				Text=objSqlConnection.ConnectionString;
				if(!System.IO.Directory.Exists(@"C:\CompleteDataBaseAccess"))
				{
					System.IO.Directory.CreateDirectory(@"C:\CompleteDataBaseAccess");
				}
//				objSqlConnection = new SqlConnection("User ID = " + strLoginName + " ; pwd = " + strPassword + "; Data Source = " + strServerName);
				objSqlConnection.Open();
				SqlCommand objSqlCommand = new SqlCommand("sp_tables",objSqlConnection);
				SqlDataAdapter daTables = new SqlDataAdapter(objSqlCommand);
				dtTables.Rows.Clear();
				daTables.Fill(dtTables);
				cmbTables.Items.Clear();
				foreach(DataRow dr in dtTables.Rows)
				{
					if(dr[3].ToString() == "TABLE")
					{
						if(dr[2].ToString() != "dtproperties")
							cmbTables.Items.Add(dr[2].ToString());
					}
				}
				objSqlConnection.Close();
//				this.btn_ShowTableContent.Enabled = false;
//				this.btn_Add.Enabled = false;
//				this.btn_AddNew.Enabled = false;
//				this.btn_Delete.Enabled = false;
//				this.btn_First.Enabled = false;
//				this.btn_GenerateBD.Enabled = false;
//				this.btn_GenerateBO.Enabled = false;
//				this.btn_GeneretBR.Enabled = false;
//				this.btn_Last.Enabled = false;
//				this.btn_Next.Enabled = false;
//				this.btn_Previous.Enabled = false;
//				this.btn_Update.Enabled = false;
//				this.btn_ShowTableContent.Enabled = false;
				i = 0;
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}
		private void btn_ShowTableContent_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_AddNew.Enabled = true;
				this.btn_First.Enabled = true;
				this.btn_GenerateBD.Enabled = true;
				this.btn_GenerateBO.Enabled = true;
				this.btn_GeneretBR.Enabled = true;
				this.btn_Last.Enabled = true;
				this.btn_Next.Enabled = true;
				this.btn_Add.Enabled = false;
				this.btn_Previous.Enabled = true;
				i=0;
				objSqlConnection.Open();
				SqlCommand objSqlCommand = new SqlCommand();
				objSqlCommand.CommandText = "select * from " + this.cmbTables.Text;
				objSqlCommand.Connection = objSqlConnection;
				objSqlDataAdapter = new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objDataSet.Tables.Clear();
				objSqlDataAdapter.Fill(objDataSet,"dTabels");
				panel1.Controls.Clear();
				foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					System.Windows.Forms.Label lbl = new Label();
					lbl.Width = 150;
					lbl.Top = 5 + i * 22;
					lbl.ForeColor = System.Drawing.Color.Crimson;
					lbl.Text = objDataColumn.ColumnName;

					System.Windows.Forms.TextBox txt = new TextBox();
					txt.Top = 5 + i * 22;
					txt.Width = 350;
					txt.Left = 160;
					panel1.Controls.Add(lbl);
					panel1.Controls.Add(txt);
					i = i + 1;
				}
				objSqlConnection.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_First_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_Update.Enabled = true;
				this.btn_Delete.Enabled = true;
				clmCounter = 0;
				rowCounter = 0;
				if(objDataSet.Tables[0].Rows.Count>0)
				{
					foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
					{
						panel1.Controls[1+clmCounter*2].Text = (objDataSet.Tables[0].Rows[0])[objDataColumn.ColumnName].ToString();
						clmCounter = clmCounter + 1;
					}
				}
				else
				{
					MessageBox.Show("Table Has No Row.");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Previous_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_Update.Enabled = true;
				this.btn_Delete.Enabled = true;
				clmCounter = 0;
				rowCounter = rowCounter - 1;
				if ( rowCounter <0)
				{
					rowCounter = 0;
				}
				if(objDataSet.Tables[0].Rows.Count>0)
				{
					foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
					{
						panel1.Controls[1+clmCounter*2].Text = (objDataSet.Tables[0].Rows[rowCounter])[objDataColumn.ColumnName].ToString();
						clmCounter = clmCounter + 1;
					}
				}
				else
				{
					MessageBox.Show("Table Has No Row.");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Next_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_Update.Enabled = true;
				this.btn_Delete.Enabled = true;
				clmCounter = 0;
				rowCounter = rowCounter + 1;
				if (rowCounter > objDataSet.Tables[0].Rows.Count-1)
				{
					rowCounter = objDataSet.Tables[0].Rows.Count - 1;
				}
				if(objDataSet.Tables[0].Rows.Count>0)
				{
					foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
					{
						panel1.Controls[1+clmCounter*2].Text = (objDataSet.Tables[0].Rows[rowCounter])[objDataColumn.ColumnName].ToString();
						clmCounter = clmCounter + 1;
					}
				}
				else
				{
					MessageBox.Show("Table Has No Row.");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Last_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_Update.Enabled = true;
				this.btn_Delete.Enabled = true;
				clmCounter = 0;
				rowCounter = objDataSet.Tables[0].Rows.Count-1;
				if(objDataSet.Tables[0].Rows.Count>0)
				{
					foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
					{
						panel1.Controls[1+clmCounter*2].Text = (objDataSet.Tables[0].Rows[objDataSet.Tables[0].Rows.Count-1])[objDataColumn.ColumnName].ToString();
						clmCounter = clmCounter + 1;
					}
				}
				else
				{
					MessageBox.Show("Table Has No Row.");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_AddNew_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_Add.Enabled = true;
				clmCounter = 0;
				foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					panel1.Controls[1+clmCounter*2].Text = "";
					clmCounter = clmCounter + 1;
				}
				this.btn_AddNew.Enabled = false;
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btn_AddNew.Enabled = true;
				DataRow objDataRow = objDataSet.Tables[0].NewRow();
				clmCounter = 0;
				foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					objDataRow[clmCounter] = panel1.Controls[1+clmCounter*2].Text;
					clmCounter = clmCounter + 1;
				}
				objDataSet.Tables[0].Rows.Add(objDataRow);
				SqlCommandBuilder objSqlCommandBuilder = new SqlCommandBuilder(objSqlDataAdapter);
				objSqlDataAdapter.InsertCommand = objSqlCommandBuilder.GetInsertCommand();
				objSqlDataAdapter.Update(objDataSet,"dTabels");
				this.btn_Add.Enabled = false;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please Enter a Valid " + panel1.Controls[clmCounter*2].Text);
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Update_Click(object sender, System.EventArgs e)
		{
			try
			{
				clmCounter = 0;
				foreach(DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					(objDataSet.Tables[0].Rows[rowCounter])[clmCounter] = panel1.Controls[1+clmCounter*2].Text;
					clmCounter = clmCounter + 1;
				}
				SqlCommandBuilder objSqlCommandBuilder = new SqlCommandBuilder(objSqlDataAdapter);
				objSqlDataAdapter.UpdateCommand = objSqlCommandBuilder.GetUpdateCommand();
				objSqlDataAdapter.InsertCommand = objSqlCommandBuilder.GetInsertCommand();
				objSqlDataAdapter.DeleteCommand = objSqlCommandBuilder.GetDeleteCommand();
				objSqlDataAdapter.Update(objDataSet,"dTabels");
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Delete_Click(object sender, System.EventArgs e)
		{
			try
			{
				MessageBox.Show("delete from " + this.cmbTables.Text + " where " + objDataSet.Tables[0].Columns[0].ColumnName + " = " + this.panel1.Controls[1+0].Text);
				objSqlConnection.Open();
				MessageBox.Show(objDataSet.Tables[0].Columns[0].DataType.ToString());
				SqlCommand objSqlCommand = new SqlCommand("delete from " + this.cmbTables.Text + " where " + objDataSet.Tables[0].Columns[0].ColumnName + " = '" + this.panel1.Controls[1+0].Text +"'", objSqlConnection);
				objSqlCommand.ExecuteNonQuery();
				objDataSet.Tables[0].Rows.Remove(objDataSet.Tables[0].Rows[rowCounter]);
				objSqlConnection.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_GenerateXML_Click(object sender, System.EventArgs e)
		{
			try
			{
				string fileName = @"C:\CompleteDataBaseAccess\" + this.cmbTables.Text + "Of" + this.cmbDataBase.Text + ".XML";
				objDataSet.WriteXml(fileName);
				fileName = @"C:\XMLsOfDataTables\" + this.cmbTables.Text + "OfA" + this.cmbDataBase.Text + ".XML";
				objDataSet.WriteXml(fileName, System.Data.XmlWriteMode.WriteSchema);
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_GenerateBD_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(BDValidate())
				{
					if(chkAllTables.Checked)
					{
						foreach(DataRow dr in dtTables.Rows)
						{
							if(dr[3].ToString() == "TABLE")
							{
								objSqlConnection.Open();
								SqlCommand objSqlCommand = new SqlCommand();
								objSqlCommand.CommandText = "select * from " + dr[2].ToString();
								objSqlCommand.Connection = objSqlConnection;
								objSqlDataAdapter = new SqlDataAdapter();
								objSqlDataAdapter.SelectCommand = objSqlCommand;
								objDataSet.Tables.Clear();
								objSqlDataAdapter.Fill(objDataSet,"dTabels");
								GenerateBD(dr[2].ToString());
								objSqlConnection.Close();
							}
						}
					}
					else
					{
						if(GenerateBD(this.cmbTables.Text))
							MessageBox.Show("BD Generation Complete Successfully.");
					}
					btn_GenerateBD.Enabled=false;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}
		
		bool BDValidate()
		{
			if(this.txtNameSpace.Text == "")
			{
				MessageBox.Show("Please Insert NameSpace.");
				txtNameSpace.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private void btn_GeneretBR_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.IO.Stream  objStream	= new FileStream(@"C:\CompleteDataBaseAccess\" + this.cmbTables.Text + "BR.cs",System.IO.FileMode.OpenOrCreate);
				System.IO.StreamWriter objStreamWriter = new StreamWriter(objStream);
				objStreamWriter.WriteLine("using System;");
				objStreamWriter.WriteLine("using System.Data;");
				objStreamWriter.WriteLine("using System.Data.SqlClient;");
				objStreamWriter.WriteLine("namespace " + this.cmbDataBase.Text + "." + this.cmbTables.Text+".BussnessRule");
				objStreamWriter.WriteLine("{");
				objStreamWriter.WriteLine("	/// <summary>");
				objStreamWriter.WriteLine("	/// Summary Description for " + this.cmbTables.Text + "BR.");
				objStreamWriter.WriteLine("	/// </summary>");
				objStreamWriter.WriteLine("	public class " + this.cmbTables.Text + "BR");
				objStreamWriter.WriteLine("	{");
				objStreamWriter.WriteLine("		public " + this.cmbTables.Text + "BR()");
				objStreamWriter.WriteLine("		{}");	
				objStreamWriter.WriteLine("		/// <summary>");
				objStreamWriter.WriteLine("		/// Method for validate;");
				objStreamWriter.WriteLine("		/// </summary>");
				objStreamWriter.WriteLine("		private bool Validate(" + this.cmbTables.Text + "BD " + "obj" + this.cmbTables.Text + "BD)");
				objStreamWriter.WriteLine("		{");
				objStreamWriter.WriteLine("		 return true;");
				objStreamWriter.WriteLine("		}");
				objStreamWriter.WriteLine("		/// <summary>");
				objStreamWriter.WriteLine("		/// Method for Add;");
				objStreamWriter.WriteLine("		/// </summary>");
				objStreamWriter.WriteLine("		public bool Add(" + this.cmbTables.Text + "BD " + "obj" +this.cmbTables.Text + "BD)");
				objStreamWriter.WriteLine("		{");
				objStreamWriter.WriteLine("			if(this.Validate(obj" + this.cmbTables.Text + "BD))");
				objStreamWriter.WriteLine("			{");
				objStreamWriter.WriteLine("				" + this.cmbTables.Text + "BO obj" + this.cmbTables.Text + "BO = new " + this.cmbTables.Text + "BO();");
				objStreamWriter.WriteLine("				obj" + this.cmbTables.Text + "BO.Add(obj" + this.cmbTables.Text + "BD);");
				objStreamWriter.WriteLine("			}");
				objStreamWriter.WriteLine("			return true;");
				objStreamWriter.WriteLine("		}");
				objStreamWriter.WriteLine("		/// <summary>");
				objStreamWriter.WriteLine("		/// Method for Modify;");
				objStreamWriter.WriteLine("		/// </summary>");
				objStreamWriter.WriteLine("		public bool Modify(" + this.cmbTables.Text + "BD " + "obj" + this.cmbTables.Text + "BD)");
				objStreamWriter.WriteLine("		{");
				objStreamWriter.WriteLine("			if(this.Validate(obj" + this.cmbTables.Text + "BD))");
				objStreamWriter.WriteLine("			{");
				objStreamWriter.WriteLine("				" + this.cmbTables.Text + "BO obj" + this.cmbTables.Text + "BO = new " + this.cmbTables.Text + "BO();");
				objStreamWriter.WriteLine("				obj" + this.cmbTables.Text + "BO.Modify(obj" + this.cmbTables.Text + "BD);");
				objStreamWriter.WriteLine("			}");
				objStreamWriter.WriteLine("			return true;");
				objStreamWriter.WriteLine("		}");
				objStreamWriter.WriteLine("		/// <summary>");
				objStreamWriter.WriteLine("		/// Method for Delete;");
				objStreamWriter.WriteLine("		/// </summary>");
				objStreamWriter.WriteLine("		public bool Delete(" + this.cmbTables.Text + "BD " + "obj" + this.cmbTables.Text + "BD)");
				objStreamWriter.WriteLine("		{");
				objStreamWriter.WriteLine("			if(this.Validate(obj" + this.cmbTables.Text + "BD))");
				objStreamWriter.WriteLine("			{");
				objStreamWriter.WriteLine("				" + this.cmbTables.Text + "BO obj" + this.cmbTables.Text + "BO = new " + this.cmbTables.Text + "BO();");
				objStreamWriter.WriteLine("				obj" + this.cmbTables.Text + "BO.Delete(obj" + this.cmbTables.Text + "BD);");
				objStreamWriter.WriteLine("			}");
				objStreamWriter.WriteLine("			return true;");
				objStreamWriter.WriteLine("		}");
				objStreamWriter.WriteLine("		/// <summary>");
				objStreamWriter.WriteLine("		/// Method for Insert");
				objStreamWriter.WriteLine("		/// </summary>");
				objStreamWriter.WriteLine("		public SqlDataAdapter Select()");
				objStreamWriter.WriteLine("		{");
				objStreamWriter.WriteLine("			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();");
				objStreamWriter.WriteLine("			" + this.cmbTables.Text + "BO obj" + this.cmbTables.Text + "BO = new " + this.cmbTables.Text + "BO();");
				objStreamWriter.WriteLine("			objSqlDataAdapter = obj" + this.cmbTables.Text + "BO.Select();");
				objStreamWriter.WriteLine("			return objSqlDataAdapter;");
				objStreamWriter.WriteLine("		}");
				objStreamWriter.WriteLine("	}//class close");
				objStreamWriter.WriteLine("}//Namespaceclose");
				objStreamWriter.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btn_Exit_Click(object sender, System.EventArgs e)
		{
			try
			{
				Application.Exit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_GenerateBO_Click(object sender, System.EventArgs e)
		{
			TemporaryBOGeneration tmpBO=new TemporaryBOGeneration(objSqlConnection.ConnectionString);
			tmpBO.ShowDialog();
//			try
//			{
//				System.IO.Stream  objStream	= new FileStream(@"C:\CompleteDataBaseAccess\" + this.cmbTables.Text + "BO.cs",System.IO.FileMode.OpenOrCreate);
//				System.IO.StreamWriter objStreamWriter = new StreamWriter(objStream);
//				objStreamWriter.WriteLine("using System;");
//				objStreamWriter.WriteLine("using System.Data;");
//				objStreamWriter.WriteLine("using System.Data.SqlClient;");
//				objStreamWriter.WriteLine("namespace " + this.cmbDataBase.Text + "." + this.cmbTables.Text+".BussnessObject");
//				objStreamWriter.WriteLine("{");
//				objStreamWriter.WriteLine("	/// <summary>");
//				objStreamWriter.WriteLine("	/// Summary Description for " + this.cmbTables.Text + "BO.");
//				objStreamWriter.WriteLine("	/// </summary>");
//				objStreamWriter.WriteLine("	public class " + this.cmbTables.Text + "BO");
//				objStreamWriter.WriteLine("	{");
//				objStreamWriter.WriteLine("		public " + this.cmbTables.Text + "BO()");
//				objStreamWriter.WriteLine("		{}");	
//				objStreamWriter.WriteLine("		/// <summary>");
//				objStreamWriter.WriteLine("		/// Method for Add;");
//				objStreamWriter.WriteLine("		/// </summary>");
//				objStreamWriter.WriteLine("		public void Add(" + this.cmbTables.Text + "BD " + "obj" +this.cmbTables.Text + "BD)");
//				objStreamWriter.WriteLine("		{");
//				objStreamWriter.WriteLine("		}");
//				objStreamWriter.WriteLine("		/// <summary>");
//				objStreamWriter.WriteLine("		/// Method for Modify;");
//				objStreamWriter.WriteLine("		/// </summary>");
//				objStreamWriter.WriteLine("		public void Modify(" + this.cmbTables.Text + "BD " + "obj" + this.cmbTables.Text + "BD)");
//				objStreamWriter.WriteLine("		{");
//				objStreamWriter.WriteLine("		}");
//				objStreamWriter.WriteLine("		/// <summary>");
//				objStreamWriter.WriteLine("		/// Method for Delete;");
//				objStreamWriter.WriteLine("		/// </summary>");
//				objStreamWriter.WriteLine("		public void Delete(" + this.cmbTables.Text + "BD " + "obj" + this.cmbTables.Text + "BD)");
//				objStreamWriter.WriteLine("		{");
//				objStreamWriter.WriteLine("		}");
//				objStreamWriter.WriteLine("		/// <summary>");
//				objStreamWriter.WriteLine("		/// Method for Insert");
//				objStreamWriter.WriteLine("		/// </summary>");
//				objStreamWriter.WriteLine("		public SqlDataAdapter Select()");
//				objStreamWriter.WriteLine("		{");
//				objStreamWriter.WriteLine("			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();");
//				objStreamWriter.WriteLine("			return objSqlDataAdapter;");
//				objStreamWriter.WriteLine("		}");
//				objStreamWriter.WriteLine("	}//class close");
//				objStreamWriter.WriteLine("}//Namespaceclose");
//				objStreamWriter.Close();
//			}
//			catch (Exception ex)
//			{
//				MessageBox.Show(ex.ToString());
//			}
		}

		private void cmbDataBase_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				btnAnalyser.Enabled=true;
				objSqlConnection = new SqlConnection("User ID = " + strLoginName + " ; pwd = " + strPassword + "; Data Source = " + strServerName + "; Initial Catalog =" + this.cmbDataBase.Text);
				objSqlConnection.Open();
				SqlCommand objSqlCommand = new SqlCommand("sp_tables",objSqlConnection);
				SqlDataAdapter daTables = new SqlDataAdapter(objSqlCommand);
				dtTables.Rows.Clear();
				daTables.Fill(dtTables);
				cmbTables.Items.Clear();
				foreach(DataRow dr in dtTables.Rows)
				{
					if(dr[3].ToString() == "TABLE")
					{
						cmbTables.Items.Add(dr[2].ToString());
					}
				}
				objSqlConnection.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void cmbTables_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.btn_ShowTableContent.Enabled = true;
		}

		private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			cmbDataBase.Items.Clear();
			cmbTables.Items.Clear();
		}

		private void textBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			cmbDataBase.Items.Clear();
			cmbTables.Items.Clear();
		}

		private bool GenerateBD(string _TableName)
		{
			try
			{
				System.IO.Stream  objStream= new FileStream(@"C:\CompleteDataBaseAccess\" + this.txtCNPreFix.Text + _TableName + txtCNPostFix.Text + ".cs",System.IO.FileMode.OpenOrCreate);
				System.IO.StreamWriter objStreamWriter = new StreamWriter(objStream);
				objStreamWriter.WriteLine("using System;");
				objStreamWriter.WriteLine("namespace " + txtNameSpace.Text);
				objStreamWriter.WriteLine("{");
				objStreamWriter.WriteLine("	/// <summary>");
				objStreamWriter.WriteLine("	/// Summary Description for " + txtCNPreFix.Text + _TableName + txtCNPostFix.Text);
				objStreamWriter.WriteLine("	/// </summary>");
				objStreamWriter.WriteLine("	public class " + this.txtCNPreFix.Text +_TableName + txtCNPostFix.Text);
				objStreamWriter.WriteLine("	{");
				string defaultCunstructor="";
				int lastColumn=0;
				foreach (DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					string varPri="";
					if(objDataColumn.DataType.ToString()=="System.String")
						varPri="str";
					else if(objDataColumn.DataType.ToString()=="System.Int64")
						varPri="l";
					else if(objDataColumn.DataType.ToString()=="System.Int32")
						varPri="i";
					else if(objDataColumn.DataType.ToString()=="System.Boolean")
						varPri="bl";
					else if(objDataColumn.DataType.ToString()=="System.DateTime")
						varPri="dTime";
					objStreamWriter.WriteLine("		private " + objDataColumn.DataType.ToString() + " " + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + ";");
					if(lastColumn < objDataSet.Tables[0].Columns.Count-1)
					{
						defaultCunstructor += objDataColumn.DataType + " " + objDataColumn.ColumnName + ", ";
					}
					else
					{
						defaultCunstructor += objDataColumn.DataType + " " + objDataColumn.ColumnName;
					}
					lastColumn+=1;
				}
				objStreamWriter.WriteLine("		public " + this.txtCNPreFix.Text + _TableName + txtCNPostFix.Text + "()");
				objStreamWriter.WriteLine("		{}");
				objStreamWriter.WriteLine("		public " + this.txtCNPreFix.Text + _TableName + txtCNPostFix.Text + "(" + defaultCunstructor + ")");
				objStreamWriter.WriteLine("		{");
				foreach (DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					string varPri="";
					if(objDataColumn.DataType.ToString()=="System.String")
						varPri="str";
					else if(objDataColumn.DataType.ToString()=="System.Int64")
						varPri="l";
					else if(objDataColumn.DataType.ToString()=="System.Int32")
						varPri="i";
					else if(objDataColumn.DataType.ToString()=="System.Boolean")
						varPri="bl";
					else if(objDataColumn.DataType.ToString()=="System.DateTime")
						varPri="dTime";
					objStreamWriter.WriteLine("			" + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + " = " + objDataColumn.ColumnName + ";");
				}
				objStreamWriter.WriteLine("		}");
				foreach (DataColumn objDataColumn in objDataSet.Tables[0].Columns)
				{
					string varPri="";
					if(objDataColumn.DataType.ToString()=="System.String")
						varPri="str";
					else if(objDataColumn.DataType.ToString()=="System.Int64")
						varPri="l";
					else if(objDataColumn.DataType.ToString()=="System.Int32")
						varPri="i";
					else if(objDataColumn.DataType.ToString()=="System.Boolean")
						varPri="bl";
					else if(objDataColumn.DataType.ToString()=="System.DateTime")
						varPri="dTime";
					objStreamWriter.WriteLine("		/// <summary>");
					objStreamWriter.WriteLine("		/// This is Properties For " + objDataColumn.ColumnName+";");
					objStreamWriter.WriteLine("		/// </summary>");
					objStreamWriter.WriteLine("		public " + objDataColumn.DataType.ToString() + " " + objDataColumn.ColumnName);
					objStreamWriter.WriteLine("		{");
					objStreamWriter.WriteLine("			set");
					objStreamWriter.WriteLine("			{");
					objStreamWriter.WriteLine("				" + txtPrivateVariablePreFix.Text + varPri + objDataColumn.ColumnName + " = value;");
					objStreamWriter.WriteLine("			}");
					objStreamWriter.WriteLine("			get");
					objStreamWriter.WriteLine("			{");
					objStreamWriter.WriteLine("				return " + txtPrivateVariablePreFix.Text + varPri +objDataColumn.ColumnName + ";");
					objStreamWriter.WriteLine("			}");
					objStreamWriter.WriteLine("		}");
				}
				objStreamWriter.WriteLine("	}//Class Close");
				objStreamWriter.WriteLine("}//NameSpace Close");
				objStreamWriter.Close();
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
				return false;
			}
		}

		private void cmbType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btn_GenerateBD.Enabled=true;
		}

		private void btnProcedures_Click(object sender, System.EventArgs e)
		{
		}

		ArrayList arrlstProcedures=new ArrayList();
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tabControl1.SelectedIndex==2)
			{
				try
				{
					objSqlConnection.Open();
					SqlCommand cmdGetProc=new SqlCommand("SP_HELP", objSqlConnection);
					cmdGetProc.CommandType=CommandType.StoredProcedure;
					SqlDataReader drProc=cmdGetProc.ExecuteReader();
					lstProcedure.Items.Clear();
					arrlstProcedures.Clear();
					while(drProc.Read())
					{
						if(drProc[2].ToString()=="stored procedure")
						{
							if(drProc[0].ToString().Substring(0, 2)!="dt")
							{
								lstProcedure.Items.Add(drProc[0].ToString());
								arrlstProcedures.Add(drProc[0].ToString());
							}
						}
					}
					objSqlConnection.Close();
				}
				catch(Exception ex)
				{
					MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
					DataSet dsRequirements=new DataSet();
					if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
					{
						dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
						DataRow drError=dsRequirements.Tables[0].NewRow();
						drError["ErrorMessage"]=ex.ToString();
						drError["DateTime"]=System.DateTime.Now.ToString();
						dsRequirements.Tables[0].Rows.Add(drError);
						System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
						dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					}
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				objSqlConnection.Open();
				SqlCommand cmdProcCol=new SqlCommand("SP_HELP " + lstProcedure.SelectedItem.ToString(), objSqlConnection);
				SqlDataAdapter daCol=new SqlDataAdapter(cmdProcCol);
				DataSet dsCol = new DataSet();
				daCol.Fill(dsCol);
				MessageBox.Show(dsCol.Tables.Count.ToString());
				foreach(DataRow dr in dsCol.Tables[1].Rows)
					MessageBox.Show(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString());
				objSqlConnection.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		/*Variable Declation For Add, Rename And Delete Class Functions*/
		public static string strFunctionName="Enter Function Name";
		private bool bFunctionAddOrRename=true;
		private string strRenameFunction="";

		private void btnAddFun_Click(object sender, System.EventArgs e)
		{
			bFunctionAddOrRename=true;
			addFunction();
		}
		private void addFunction()
		{
			try
			{
				strFunctionName="Enter Function Name";
				OkCancelBOFunction newOkCancelBOFunction=new OkCancelBOFunction();
				newOkCancelBOFunction.Text="Add Function";
				newOkCancelBOFunction.ShowDialog();
				validateFunction();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}
		private void validateFunction()
		{
			bool bValidFunction=false;
			for(int iCountOflstFunction=0; iCountOflstFunction<lstFunction.Items.Count; iCountOflstFunction++)
			{
				if(strFunctionName==lstFunction.Items[iCountOflstFunction].ToString())
				{
					bValidFunction=true;
					break;
				}
			}
			if(bValidFunction)
			{
				MessageBox.Show("Function Name Already Exists, Please Enter Different Function Name.");
				if(bFunctionAddOrRename)
					addFunction();
				else
					renameFunction();
			}
			else
			{
				if(strFunctionName!="Cancel")
				{
					if(bFunctionAddOrRename)
						lstFunction.Items.Add(strFunctionName);
					else
					{
						lstFunction.Items.Remove(strRenameFunction);
						lstFunction.Items.Add(strFunctionName);
					}
				}
			}
		}

		private void btnDeleteFunction_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lstFunction.SelectedIndex!=-1)
					lstFunction.Items.RemoveAt(lstFunction.SelectedIndex);
				else
					MessageBox.Show("Please Select A Function To Be Deleted.");
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void btnRenameFunction_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lstFunction.SelectedIndex!=-1)
				{
					bFunctionAddOrRename=false;
					strRenameFunction=lstFunction.SelectedItem.ToString();
					strFunctionName=lstFunction.SelectedItem.ToString();
					renameFunction();
				}
				else
					MessageBox.Show("Function Must Be Selected.");
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}
		private void renameFunction()
		{
			try
			{
				OkCancelBOFunction newOkCancelBOFunction=new OkCancelBOFunction();
				newOkCancelBOFunction.Text="Rename Function";
				newOkCancelBOFunction.ShowDialog();
				validateFunction();
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}
		/*Variable Declaration For Procedure Used*/
		public static Hashtable htProcedure=new Hashtable();
		public static Hashtable htDependingProcedure=new Hashtable();

		private void btnProcUsed_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lstFunction.Items.Count!=0)
				{
					if(lstFunction.SelectedIndex!=-1)
					{
						ProcedureSelection newProcedureSelection=new ProcedureSelection(arrlstProcedures, objSqlConnection);
						newProcedureSelection.Text="Select Procedures for " + lstFunction.SelectedItem.ToString();
						newProcedureSelection.ShowDialog();
					}
					else
					{
						MessageBox.Show("Please Select A Function From The List");
						lstFunction.Focus();
					}
				}
				else
				{
					MessageBox.Show("Add Functions Before Creating Procedure List.");
					btnAddFun.Focus();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
					DataRow drError=dsRequirements.Tables[0].NewRow();
					drError["ErrorMessage"]=ex.ToString();
					drError["DateTime"]=System.DateTime.Now.ToString();
					dsRequirements.Tables[0].Rows.Add(drError);
					System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				}
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
//			this.Close();
//			Connection newCon=new Connection();
//			newCon.Show();
		}

		private void btnAnalyser_Click(object sender, System.EventArgs e)
		{
			Analyser newAnalyser=new Analyser(objSqlConnection);
			newAnalyser.ShowInTaskbar=false;
			newAnalyser.Show();
		}

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			SQLProcedure objProc=new SQLProcedure(objSqlConnection.ConnectionString);
			objProc.ShowInTaskbar=false;
			objProc.ShowDialog();
		}
	}
}