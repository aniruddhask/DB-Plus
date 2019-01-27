using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for TemporaryBOGeneration.
	/// </summary>
	public class TemporaryBOGeneration : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtOutPut;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtObjectPassed;
		private System.Windows.Forms.TextBox txtFlag;
		private System.Windows.Forms.Label lblObject;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gbxConnectionType;
		private System.Windows.Forms.RadioButton rbtnOleDb;
		private System.Windows.Forms.RadioButton rbtnSqlClient;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label lblConnectionName;
		private System.Windows.Forms.TextBox txtConnectionName;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbProcedure;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string _strConString="";
		private System.Windows.Forms.ComboBox cmbConnectionName;
		private System.Windows.Forms.ComboBox cmbObjectPassed;
		private SqlConnection objSqlConnection;
		public TemporaryBOGeneration(string ConnectionString)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_strConString=ConnectionString;
			objSqlConnection=new SqlConnection();
			objSqlConnection.ConnectionString=ConnectionString;
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtOutPut = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtObjectPassed = new System.Windows.Forms.TextBox();
			this.txtFlag = new System.Windows.Forms.TextBox();
			this.lblObject = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.gbxConnectionType = new System.Windows.Forms.GroupBox();
			this.rbtnSqlClient = new System.Windows.Forms.RadioButton();
			this.rbtnOleDb = new System.Windows.Forms.RadioButton();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.lblConnectionName = new System.Windows.Forms.Label();
			this.txtConnectionName = new System.Windows.Forms.TextBox();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbProcedure = new System.Windows.Forms.ComboBox();
			this.cmbConnectionName = new System.Windows.Forms.ComboBox();
			this.cmbObjectPassed = new System.Windows.Forms.ComboBox();
			this.gbxConnectionType.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtOutPut
			// 
			this.txtOutPut.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtOutPut.ForeColor = System.Drawing.Color.Navy;
			this.txtOutPut.Location = new System.Drawing.Point(8, 80);
			this.txtOutPut.Multiline = true;
			this.txtOutPut.Name = "txtOutPut";
			this.txtOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutPut.Size = new System.Drawing.Size(664, 273);
			this.txtOutPut.TabIndex = 0;
			this.txtOutPut.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(592, 52);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtObjectPassed
			// 
			this.txtObjectPassed.Location = new System.Drawing.Point(160, 8);
			this.txtObjectPassed.Name = "txtObjectPassed";
			this.txtObjectPassed.Size = new System.Drawing.Size(184, 21);
			this.txtObjectPassed.TabIndex = 2;
			this.txtObjectPassed.Text = "";
			this.txtObjectPassed.Visible = false;
			// 
			// txtFlag
			// 
			this.txtFlag.Location = new System.Drawing.Point(160, 7);
			this.txtFlag.Name = "txtFlag";
			this.txtFlag.Size = new System.Drawing.Size(184, 21);
			this.txtFlag.TabIndex = 3;
			this.txtFlag.Text = "";
			// 
			// lblObject
			// 
			this.lblObject.Location = new System.Drawing.Point(16, 40);
			this.lblObject.Name = "lblObject";
			this.lblObject.Size = new System.Drawing.Size(100, 16);
			this.lblObject.TabIndex = 6;
			this.lblObject.Text = "Object Passed";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Flag Value (if any)";
			this.label2.Visible = false;
			// 
			// gbxConnectionType
			// 
			this.gbxConnectionType.Controls.Add(this.rbtnSqlClient);
			this.gbxConnectionType.Controls.Add(this.rbtnOleDb);
			this.gbxConnectionType.Location = new System.Drawing.Point(369, 42);
			this.gbxConnectionType.Name = "gbxConnectionType";
			this.gbxConnectionType.Size = new System.Drawing.Size(150, 36);
			this.gbxConnectionType.TabIndex = 9;
			this.gbxConnectionType.TabStop = false;
			this.gbxConnectionType.Text = "Connection Type";
			// 
			// rbtnSqlClient
			// 
			this.rbtnSqlClient.Location = new System.Drawing.Point(73, 17);
			this.rbtnSqlClient.Name = "rbtnSqlClient";
			this.rbtnSqlClient.Size = new System.Drawing.Size(73, 15);
			this.rbtnSqlClient.TabIndex = 1;
			this.rbtnSqlClient.Text = "&SqlClient";
			// 
			// rbtnOleDb
			// 
			this.rbtnOleDb.Checked = true;
			this.rbtnOleDb.Location = new System.Drawing.Point(8, 18);
			this.rbtnOleDb.Name = "rbtnOleDb";
			this.rbtnOleDb.Size = new System.Drawing.Size(58, 15);
			this.rbtnOleDb.TabIndex = 0;
			this.rbtnOleDb.TabStop = true;
			this.rbtnOleDb.Text = "&OleDb";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(520, 52);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(72, 23);
			this.btnGenerate.TabIndex = 10;
			this.btnGenerate.Text = "&Generate";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// lblConnectionName
			// 
			this.lblConnectionName.Location = new System.Drawing.Point(16, 59);
			this.lblConnectionName.Name = "lblConnectionName";
			this.lblConnectionName.Size = new System.Drawing.Size(128, 16);
			this.lblConnectionName.TabIndex = 11;
			this.lblConnectionName.Text = "Connection Name";
			// 
			// txtConnectionName
			// 
			this.txtConnectionName.Location = new System.Drawing.Point(160, 56);
			this.txtConnectionName.Name = "txtConnectionName";
			this.txtConnectionName.Size = new System.Drawing.Size(184, 21);
			this.txtConnectionName.TabIndex = 12;
			this.txtConnectionName.Text = "";
			this.txtConnectionName.Visible = false;
			// 
			// cmbType
			// 
			this.cmbType.Items.AddRange(new object[] {
														 "Long",
														 "Char",
														 "String"});
			this.cmbType.Location = new System.Drawing.Point(344, 7);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(72, 21);
			this.cmbType.TabIndex = 13;
			this.cmbType.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(424, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "Procedure";
			// 
			// cmbProcedure
			// 
			this.cmbProcedure.Location = new System.Drawing.Point(494, 2);
			this.cmbProcedure.Name = "cmbProcedure";
			this.cmbProcedure.Size = new System.Drawing.Size(186, 21);
			this.cmbProcedure.TabIndex = 15;
			// 
			// cmbConnectionName
			// 
			this.cmbConnectionName.Location = new System.Drawing.Point(160, 56);
			this.cmbConnectionName.Name = "cmbConnectionName";
			this.cmbConnectionName.Size = new System.Drawing.Size(184, 21);
			this.cmbConnectionName.TabIndex = 16;
			// 
			// cmbObjectPassed
			// 
			this.cmbObjectPassed.Location = new System.Drawing.Point(160, 32);
			this.cmbObjectPassed.Name = "cmbObjectPassed";
			this.cmbObjectPassed.Size = new System.Drawing.Size(184, 21);
			this.cmbObjectPassed.TabIndex = 17;
			// 
			// TemporaryBOGeneration
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(212)), ((System.Byte)(214)));
			this.ClientSize = new System.Drawing.Size(680, 358);
			this.Controls.Add(this.cmbObjectPassed);
			this.Controls.Add(this.cmbConnectionName);
			this.Controls.Add(this.cmbProcedure);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtConnectionName);
			this.Controls.Add(this.lblConnectionName);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.gbxConnectionType);
			this.Controls.Add(this.lblObject);
			this.Controls.Add(this.txtObjectPassed);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtOutPut);
			this.Controls.Add(this.cmbType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtFlag);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "TemporaryBOGeneration";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TemporaryBOGeneration";
			this.Load += new System.EventHandler(this.TemporaryBOGeneration_Load);
			this.gbxConnectionType.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strOleDb="SqlDbType";
				string strVariablePre="";
				if(rbtnOleDb.Checked)
					strOleDb="OleDbType";
				objSqlConnection.Open();
				SqlCommand newSqlCommand = new SqlCommand("SP_HELP " + cmbProcedure.SelectedItem.ToString(), objSqlConnection);	
				SqlDataAdapter daParameter=new SqlDataAdapter(newSqlCommand);
				DataSet dsParameter=new DataSet();
				daParameter.Fill(dsParameter);
				objSqlConnection.Close();
				if(strOleDb=="OleDbType")
				{
					txtOutPut.Text +="\r\n " + cmbConnectionName.Text + ".Open();";
					txtOutPut.Text="\r\n OleDbCommand cmd" + cmbProcedure.SelectedItem.ToString() + "=new OleDbCommand(";
					txtOutPut.Text=txtOutPut.Text + Convert.ToChar(34) + cmbProcedure.SelectedItem.ToString() + Convert.ToChar(34) + ", " + cmbConnectionName.Text + ");";
					txtOutPut.Text += "\r\ncmd" + cmbProcedure.SelectedItem.ToString() + ".CommandType=CommandType.StoredProcedure;";
				}
				if(dsParameter.Tables.Count>1)
				{
					string strDataType="";
					foreach(DataRow dr in dsParameter.Tables[1].Rows)
					{
						if(dr[1].ToString()=="char")
							strDataType=strOleDb + ".Char";
						else if(dr[1].ToString()=="bigint")
							strDataType=strOleDb + ".BigInt";
						else if(dr[1].ToString()=="varchar")
							strDataType="typeof(string)";
						else if(dr[1].ToString()=="bit")
							strDataType="OleDbType.Boolean";
						else if(dr[1].ToString()=="float")
							strDataType="typeof(float)";
						else if(dr[1].ToString()=="tiniint")
							strDataType="OleDbType.TiniInt";
						else if(dr[1].ToString()=="datetime")
							strDataType="OleDbType.DBDate";
						else if(dr[1].ToString()=="int")
							strDataType="typeof(int)";
						else if(dr[1].ToString()=="numeric")
							strDataType="OleDbType.Numeric";
						else
							strDataType="OleDbType." + dr[1].ToString();

						txtOutPut.Text +="\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".Parameters.Add(" + Convert.ToChar(34) + dr[0].ToString()  + Convert.ToChar(34) + ", " + strDataType + ").Value=" + cmbObjectPassed.Text + "." + dr[0].ToString().Remove(0,1) + ";";
					}
				}
				txtOutPut.Text +="\r\n cmd" + cmbProcedure.SelectedItem.ToString() + ".ExecuteNonQuery();";
				addToXML();
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

		private void TemporaryBOGeneration_Load(object sender, System.EventArgs e)
		{
			try
			{
				fillValueFromXML();
				objSqlConnection.Open();
				SqlCommand cmdGetProc=new SqlCommand("SP_HELP", objSqlConnection);
				cmdGetProc.CommandType=CommandType.StoredProcedure;
				SqlDataReader drProc=cmdGetProc.ExecuteReader();
				cmbProcedure.Items.Clear();
				while(drProc.Read())
				{
					if(drProc[2].ToString()=="stored procedure")
					{
						if(drProc[0].ToString().Substring(0, 2)!="dt")
						{
							cmbProcedure.Items.Add(drProc[0].ToString());
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
		private void fillValueFromXML()
		{
			try
			{
				DataSet dsRequirements=new DataSet();
				if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseReq.xml"))
				{
					dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseReq.xml");
					cmbConnectionName.Items.Clear();
					foreach(DataRow drConnection in dsRequirements.Tables["Connection"].Rows)
					{
						cmbConnectionName.Items.Add(drConnection[0].ToString());
					}
					
					cmbObjectPassed.Items.Clear();
					foreach(DataRow drObject in dsRequirements.Tables["Object"].Rows)
					{
						cmbObjectPassed.Items.Add(drObject[0].ToString());
					}
				}
				else
				{
					DataTable dtConnection=new DataTable("Connection");
					dtConnection.Columns.Add(new DataColumn("ConnectionName", typeof(string)));
					DataRow drConnection=dtConnection.NewRow();
					drConnection["ConnectionName"]="ConCare";
					dtConnection.Rows.Add(drConnection);

					DataTable dtObjectPassed=new DataTable("Object");
					dtObjectPassed.Columns.Add(new DataColumn("ObjectName", typeof(string)));
					DataRow drObject=dtObjectPassed.NewRow();
					drObject["ObjectName"]="";
					dtObjectPassed.Rows.Add(drObject);
					dsRequirements.Tables.Add(dtConnection);
					dsRequirements.Tables.Add(dtObjectPassed);
					dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseReq.xml");
					fillValueFromXML();
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
		private void addToXML()
		{
			try
			{
				DataSet dsRequirements=new DataSet();
				dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseReq.xml");
				//cmbConnectionName.Items.Clear();
				bool bConnection=false;
				foreach(DataRow drConnection in dsRequirements.Tables["Connection"].Rows)
				{
					if(drConnection[0].ToString()==cmbConnectionName.Text)
						bConnection=true;
				}
				if(!bConnection)
				{
					DataRow drConncetionNew=dsRequirements.Tables["Connection"].NewRow();
					drConncetionNew[0]=cmbConnectionName.Text;
					dsRequirements.Tables["Connection"].Rows.Add(drConncetionNew);
				}


				bool bObject=false;
				foreach(DataRow drObject in dsRequirements.Tables["Object"].Rows)
				{
					if(drObject[0].ToString()==cmbObjectPassed.Text)
						bObject=true;
				}
				if(!bObject)
				{
					DataRow drObject=dsRequirements.Tables["Object"].NewRow();
					drObject[0]=cmbObjectPassed.Text;
					dsRequirements.Tables["Object"].Rows.Add(drObject);
				}
				dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseReq.xml");
				fillValueFromXML();
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
}