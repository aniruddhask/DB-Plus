using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for BaseControl.
	/// </summary>
	public class BaseControl : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblDataBase;
		private System.Windows.Forms.ComboBox cmbDataBase;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAnalyser;
		private System.Windows.Forms.Button btnReconnect;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btn_GenerateBO;
		private System.Windows.Forms.Button btnGenerateProcedure;
		private System.Windows.Forms.Button btnTempBO;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDesc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBD;
		private SqlConnection objSqlConnection;
		string strServer;
		string strUserID;
		string strPwd;
		public BaseControl(string Server, string LoginName, string Password)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			strPwd=Password;
			strServer=Server;
			strUserID=LoginName;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			this.Close();
			Connection newCon=new Connection("Second");
			newCon.Show();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BaseControl));
			this.lblDataBase = new System.Windows.Forms.Label();
			this.cmbDataBase = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBD = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btn_GenerateBO = new System.Windows.Forms.Button();
			this.btnAnalyser = new System.Windows.Forms.Button();
			this.btnGenerateProcedure = new System.Windows.Forms.Button();
			this.btnTempBO = new System.Windows.Forms.Button();
			this.btnReconnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblDesc = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblDataBase
			// 
			this.lblDataBase.Location = new System.Drawing.Point(8, 8);
			this.lblDataBase.Name = "lblDataBase";
			this.lblDataBase.Size = new System.Drawing.Size(64, 16);
			this.lblDataBase.TabIndex = 0;
			this.lblDataBase.Text = "Data Base";
			// 
			// cmbDataBase
			// 
			this.cmbDataBase.BackColor = System.Drawing.Color.White;
			this.cmbDataBase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmbDataBase.Location = new System.Drawing.Point(79, 4);
			this.cmbDataBase.Name = "cmbDataBase";
			this.cmbDataBase.Size = new System.Drawing.Size(173, 21);
			this.cmbDataBase.TabIndex = 2;
			this.cmbDataBase.Text = "DataBases";
			this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.btnBD);
			this.groupBox1.Controls.Add(this.btnGenerate);
			this.groupBox1.Controls.Add(this.btn_GenerateBO);
			this.groupBox1.Controls.Add(this.btnAnalyser);
			this.groupBox1.Controls.Add(this.btnGenerateProcedure);
			this.groupBox1.Controls.Add(this.btnTempBO);
			this.groupBox1.Location = new System.Drawing.Point(-8, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 40);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// btnBD
			// 
			this.btnBD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.btnBD.Location = new System.Drawing.Point(256, 9);
			this.btnBD.Name = "btnBD";
			this.btnBD.Size = new System.Drawing.Size(88, 23);
			this.btnBD.TabIndex = 23;
			this.btnBD.Text = "&BD Generator";
			this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(187, -95);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 25);
			this.btnGenerate.TabIndex = 22;
			this.btnGenerate.Text = "&Generate";
			// 
			// btn_GenerateBO
			// 
			this.btn_GenerateBO.AllowDrop = true;
			this.btn_GenerateBO.BackColor = System.Drawing.SystemColors.Control;
			this.btn_GenerateBO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_GenerateBO.Location = new System.Drawing.Point(155, 129);
			this.btn_GenerateBO.Name = "btn_GenerateBO";
			this.btn_GenerateBO.Size = new System.Drawing.Size(104, 23);
			this.btn_GenerateBO.TabIndex = 21;
			this.btn_GenerateBO.Text = "Generate B&O";
			// 
			// btnAnalyser
			// 
			this.btnAnalyser.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.btnAnalyser.Location = new System.Drawing.Point(14, 11);
			this.btnAnalyser.Name = "btnAnalyser";
			this.btnAnalyser.TabIndex = 20;
			this.btnAnalyser.Text = "Anal&yser";
			this.btnAnalyser.Click += new System.EventHandler(this.btnAnalyser_Click);
			// 
			// btnGenerateProcedure
			// 
			this.btnGenerateProcedure.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.btnGenerateProcedure.Location = new System.Drawing.Point(94, 10);
			this.btnGenerateProcedure.Name = "btnGenerateProcedure";
			this.btnGenerateProcedure.TabIndex = 21;
			this.btnGenerateProcedure.Text = "&Procedure";
			this.btnGenerateProcedure.Click += new System.EventHandler(this.btnGenerateProcedure_Click);
			// 
			// btnTempBO
			// 
			this.btnTempBO.AllowDrop = true;
			this.btnTempBO.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.btnTempBO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnTempBO.Location = new System.Drawing.Point(176, 10);
			this.btnTempBO.Name = "btnTempBO";
			this.btnTempBO.Size = new System.Drawing.Size(72, 23);
			this.btnTempBO.TabIndex = 20;
			this.btnTempBO.Text = "&Temp BO";
			this.btnTempBO.Click += new System.EventHandler(this.btnTempBO_Click);
			// 
			// btnReconnect
			// 
			this.btnReconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnReconnect.Image")));
			this.btnReconnect.Location = new System.Drawing.Point(374, 4);
			this.btnReconnect.Name = "btnReconnect";
			this.btnReconnect.Size = new System.Drawing.Size(24, 23);
			this.btnReconnect.TabIndex = 19;
			this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(5)), ((System.Byte)(0)), ((System.Byte)(6)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 16);
			this.label1.TabIndex = 21;
			this.label1.Text = "Utility Version:- 1.0.2309.23154";
			// 
			// lblDesc
			// 
			this.lblDesc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(5)), ((System.Byte)(0)), ((System.Byte)(6)));
			this.lblDesc.ForeColor = System.Drawing.Color.Silver;
			this.lblDesc.Location = new System.Drawing.Point(-8, 63);
			this.lblDesc.Name = "lblDesc";
			this.lblDesc.Size = new System.Drawing.Size(720, 16);
			this.lblDesc.TabIndex = 20;
			this.lblDesc.Text = "                                                        Powered & Supported By:- " +
				"Binary Solution Pvt. Ltd.";
			// 
			// BaseControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.DarkGray;
			this.ClientSize = new System.Drawing.Size(405, 85);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblDesc);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmbDataBase);
			this.Controls.Add(this.lblDataBase);
			this.Controls.Add(this.btnReconnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "BaseControl";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "BaseControl";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.BaseControl_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnReconnect_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Connection newCon=new Connection("Second");
			newCon.Show();
		}

		private void btnAnalyser_Click(object sender, System.EventArgs e)
		{
			Analyser newAnalyser=new Analyser(objSqlConnection);
			newAnalyser.ShowInTaskbar=false;
			newAnalyser.Show();
		}

		private void btnGenerateProcedure_Click(object sender, System.EventArgs e)
		{
			SQLProcedure objProc=new SQLProcedure(objSqlConnection.ConnectionString);
			objProc.ShowInTaskbar=false;
			objProc.Show();
		}

		private void btnTempBO_Click(object sender, System.EventArgs e)
		{
			TemporaryBOGeneration tmpBO=new TemporaryBOGeneration(objSqlConnection.ConnectionString);
			tmpBO.ShowInTaskbar=false;
			tmpBO.Show();
		}

		private void BaseControl_Load(object sender, System.EventArgs e)
		{
			try
			{
				objSqlConnection=new SqlConnection("User ID=" + strUserID + "; Password=" + strPwd + "; Data Source=" + strServer);
				if(!System.IO.Directory.Exists(@"C:\CompleteDataBaseAccess"))
				{
					System.IO.Directory.CreateDirectory(@"C:\CompleteDataBaseAccess");
				}
				objSqlConnection.Open();
				SqlCommand objSqlCommand=new SqlCommand("SP_DataBases", objSqlConnection);
				objSqlCommand.CommandType=CommandType.StoredProcedure;
				SqlDataReader objSqlDataReader=objSqlCommand.ExecuteReader();
				cmbDataBase.Items.Clear();
				while (objSqlDataReader.Read())
				{
					cmbDataBase.Items.Add(objSqlDataReader[0].ToString());
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

		private void cmbDataBase_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			objSqlConnection=new SqlConnection("User ID=" + strUserID + "; Password=" + strPwd + "; Data Source=" + strServer + ";Initial Catalog=" + cmbDataBase.Text);
		}

		private void btnBD_Click(object sender, System.EventArgs e)
		{
			CompleteDataBase newCompleteDataBase=new CompleteDataBase(objSqlConnection);
			newCompleteDataBase.ShowInTaskbar=false;
			newCompleteDataBase.Show();
		}
	}
}
