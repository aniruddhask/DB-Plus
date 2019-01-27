using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for SQLProcedure.
	/// </summary>
	public class SQLProcedure : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private SqlConnection conCC;
		private System.Windows.Forms.ComboBox cmbTables;
		private System.Windows.Forms.GroupBox gbxProcedure;
		private System.Windows.Forms.CheckBox chkInsert;
		private System.Windows.Forms.CheckBox chkUpdate;
		private System.Windows.Forms.CheckBox chkDelete;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.TextBox txtOutPut;
		private System.Windows.Forms.Button btnSaveAs;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.CheckBox chkSelect;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Button btnClear;
		private DataTable dtTables=new DataTable();
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.TextBox txtRemark;
		DataSet dsTable;
		public SQLProcedure(string ConnectionString)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			conCC=new SqlConnection();
			conCC.ConnectionString=ConnectionString;
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
			this.cmbTables = new System.Windows.Forms.ComboBox();
			this.gbxProcedure = new System.Windows.Forms.GroupBox();
			this.chkSelect = new System.Windows.Forms.CheckBox();
			this.chkDelete = new System.Windows.Forms.CheckBox();
			this.chkUpdate = new System.Windows.Forms.CheckBox();
			this.chkInsert = new System.Windows.Forms.CheckBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.txtOutPut = new System.Windows.Forms.TextBox();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.lblResult = new System.Windows.Forms.Label();
			this.btnClear = new System.Windows.Forms.Button();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.gbxProcedure.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbTables
			// 
			this.cmbTables.Location = new System.Drawing.Point(8, 8);
			this.cmbTables.Name = "cmbTables";
			this.cmbTables.Size = new System.Drawing.Size(152, 21);
			this.cmbTables.TabIndex = 0;
			this.cmbTables.TextChanged += new System.EventHandler(this.cmbTables_TextChanged);
			this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
			// 
			// gbxProcedure
			// 
			this.gbxProcedure.Controls.Add(this.chkSelect);
			this.gbxProcedure.Controls.Add(this.chkDelete);
			this.gbxProcedure.Controls.Add(this.chkUpdate);
			this.gbxProcedure.Controls.Add(this.chkInsert);
			this.gbxProcedure.Location = new System.Drawing.Point(168, 0);
			this.gbxProcedure.Name = "gbxProcedure";
			this.gbxProcedure.Size = new System.Drawing.Size(282, 34);
			this.gbxProcedure.TabIndex = 1;
			this.gbxProcedure.TabStop = false;
			this.gbxProcedure.Text = "Procedure For...";
			// 
			// chkSelect
			// 
			this.chkSelect.Location = new System.Drawing.Point(216, 13);
			this.chkSelect.Name = "chkSelect";
			this.chkSelect.Size = new System.Drawing.Size(62, 16);
			this.chkSelect.TabIndex = 3;
			this.chkSelect.Text = "&Select";
			// 
			// chkDelete
			// 
			this.chkDelete.Location = new System.Drawing.Point(150, 12);
			this.chkDelete.Name = "chkDelete";
			this.chkDelete.Size = new System.Drawing.Size(61, 16);
			this.chkDelete.TabIndex = 2;
			this.chkDelete.Text = "&Delete";
			// 
			// chkUpdate
			// 
			this.chkUpdate.Location = new System.Drawing.Point(80, 14);
			this.chkUpdate.Name = "chkUpdate";
			this.chkUpdate.Size = new System.Drawing.Size(66, 15);
			this.chkUpdate.TabIndex = 1;
			this.chkUpdate.Text = "&Update";
			// 
			// chkInsert
			// 
			this.chkInsert.Location = new System.Drawing.Point(11, 12);
			this.chkInsert.Name = "chkInsert";
			this.chkInsert.Size = new System.Drawing.Size(64, 16);
			this.chkInsert.TabIndex = 0;
			this.chkInsert.Text = "&Insert";
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(464, 8);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.TabIndex = 2;
			this.btnCreate.Text = "&Create";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// txtOutPut
			// 
			this.txtOutPut.ForeColor = System.Drawing.Color.Navy;
			this.txtOutPut.Location = new System.Drawing.Point(8, 38);
			this.txtOutPut.Multiline = true;
			this.txtOutPut.Name = "txtOutPut";
			this.txtOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutPut.Size = new System.Drawing.Size(776, 426);
			this.txtOutPut.TabIndex = 3;
			this.txtOutPut.Text = "";
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Location = new System.Drawing.Point(624, 496);
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.TabIndex = 4;
			this.btnSaveAs.Text = "Save &As...";
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(704, 496);
			this.btnRun.Name = "btnRun";
			this.btnRun.TabIndex = 5;
			this.btnRun.Text = "&Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.InitialDirectory = "C:\\CompleteDataBaseAccess";
			// 
			// lblResult
			// 
			this.lblResult.Location = new System.Drawing.Point(344, 497);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(272, 16);
			this.lblResult.TabIndex = 6;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(547, 8);
			this.btnClear.Name = "btnClear";
			this.btnClear.TabIndex = 7;
			this.btnClear.Text = "C&lear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// chkAll
			// 
			this.chkAll.Location = new System.Drawing.Point(736, 12);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(42, 16);
			this.chkAll.TabIndex = 8;
			this.chkAll.Text = "&All";
			this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
			// 
			// txtRemark
			// 
			this.txtRemark.Location = new System.Drawing.Point(8, 468);
			this.txtRemark.Multiline = true;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRemark.Size = new System.Drawing.Size(320, 44);
			this.txtRemark.TabIndex = 9;
			this.txtRemark.Text = "";
			// 
			// SQLProcedure
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(239)), ((System.Byte)(220)));
			this.ClientSize = new System.Drawing.Size(786, 520);
			this.Controls.Add(this.txtRemark);
			this.Controls.Add(this.chkAll);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnSaveAs);
			this.Controls.Add(this.txtOutPut);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.gbxProcedure);
			this.Controls.Add(this.cmbTables);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SQLProcedure";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SQLProcedure";
			this.Load += new System.EventHandler(this.SQLProcedure_Load);
			this.gbxProcedure.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SQLProcedure_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.Text="Procedure Generator: " + conCC.ConnectionString;
				btnCreate.Enabled=false;
				btnRun.Enabled=false;
				btnSaveAs.Enabled=false;
				conCC.Open();
				SqlCommand objSqlCommand = new SqlCommand("sp_tables",conCC);
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
				conCC.Close();
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
		}
		void insError(string strError)
		{
			//MessageBox.Show(strError);
			MessageBox.Show("There Is Some Problem In Your Process, Kindly Repeat The Process");
			DataSet dsRequirements=new DataSet();
			if(System.IO.File.Exists(@"C:\Program Files\CompleteDataBaseErrors.xml"))
			{
				dsRequirements.ReadXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
				DataRow drError=dsRequirements.Tables[0].NewRow();
				drError["ErrorMessage"]=strError;
				drError["DateTime"]=System.DateTime.Now.ToString();
				dsRequirements.Tables[0].Rows.Add(drError);
				System.IO.File.Delete(@"C:\Program Files\CompleteDataBaseErrors.xml");
				dsRequirements.WriteXml(@"C:\Program Files\CompleteDataBaseErrors.xml");
			}
		}
		private void insRemark()
		{
			if(txtRemark.Text!="")
			{
				txtOutPut.Text += @"/*" + txtRemark.Text + @"*/";
			}
		}
		private void fillDataSet(string strTableName)
		{
			try
			{
				conCC.Open();
				SqlCommand cmdTable=new SqlCommand("SP_HELP " + strTableName, conCC);
				SqlDataAdapter daTable=new SqlDataAdapter(cmdTable);
				dsTable=new DataSet();
				daTable.Fill(dsTable);
				writeProc(strTableName);
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
			finally
			{
				conCC.Close();
			}
		}

		private void pInsertUpdate(string strTableName)
		{
			try
			{
				insRemark();
				txtOutPut.Text += "\r\n--DROP PROCEDURE p" + strTableName + "_IU\r\n";
				txtOutPut.Text += "CREATE PROCEDURE p" + strTableName + "_IU\r\n(\r\n";
				txtOutPut.Text += "	@Flag Char,\r\n";
				
				string strInsert="";
				string strInsertParameter="";
				foreach(DataRow drRow in dsTable.Tables[1].Rows)
				{
					if(drRow[0].ToString()!="cDate")
					{
						string strDataLength="";
						if(drRow[1].ToString()=="varchar")
							strDataLength="("+drRow[3].ToString()+")";
						txtOutPut.Text += "\r\n" + @"	@"+ drRow[0].ToString() + " " + drRow[1].ToString() + strDataLength + ",";
						strInsert += drRow[0].ToString()+",";
						strInsertParameter += @"@" + drRow[0].ToString()+",";
					}
				}
				strInsert = strInsert.Trim().Remove(strInsert.Length -1, 1);
				strInsertParameter = strInsertParameter.Trim().Remove(strInsertParameter.Length -1, 1);
//				MessageBox.Show(txtOutPut.Text.LastIndexOf(",").ToString() + ", " + txtOutPut.Text.Length.ToString());
//				MessageBox.Show(txtOutPut.Text);
				txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length-1);
				txtOutPut.Text += "\r\n)\r\n";
				txtOutPut.Text += "AS\r\n";
				txtOutPut.Text += "BEGIN\r\n";
				txtOutPut.Text += "	IF @Flag='I'\r\n";
				txtOutPut.Text += "	BEGIN\r\n";
				txtOutPut.Text += "		INSERT INTO " + cmbTables.Text + "(" + strInsert + ")\r\n";
				txtOutPut.Text += "			VALUES(" + strInsertParameter + ")\r\n";
				txtOutPut.Text += "	END\r\n";
				txtOutPut.Text += "	ELSE\r\n";
				txtOutPut.Text += "	BEGIN\r\n";
				txtOutPut.Text += "		UPDATE	" + cmbTables.Text + "\r\n";
				txtOutPut.Text += "		SET";
				foreach(DataRow drRow in dsTable.Tables[1].Rows)
				{
					if(drRow[0].ToString()!="cDate")
					{
						if(drRow[0].ToString()!=dsTable.Tables[5].Rows[0]["index_keys"].ToString())
						{
							txtOutPut.Text += "\r\n			" + drRow[0].ToString() + @"=@"+ drRow[0].ToString() + " ,";
						}
					}
				}
				txtOutPut.Text = txtOutPut.Text.Substring(0, txtOutPut.Text.Length-1);
				txtOutPut.Text += "\r\n		WHERE	" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @"=@" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
				txtOutPut.Text += "	END\r\n";
				txtOutPut.Text += "END\r\n\r\n";
			}
			catch(Exception ex)
			{
				//MessageBox.Show(strTableName);
				insError(ex.ToString());
			}
		}

		private void pInsert(string strTableName)
		{
			try
			{
				insRemark();
				txtOutPut.Text += "\r\n--DROP PROCEDURE p" + strTableName + "_I\r\n";
				txtOutPut.Text += "CREATE PROCEDURE p" + strTableName + "_I(\r\n";
				
				string strInsert="";
				string strInsertParameter="";
				foreach(DataRow drRow in dsTable.Tables[1].Rows)
				{
					if(drRow[0].ToString()!="cDate")
					{
						string strDataLength="";
						if(drRow[1].ToString()=="varchar")
							strDataLength="("+drRow[3].ToString()+")";
						txtOutPut.Text += @"	@"+ drRow[0].ToString() + " " + drRow[1].ToString() + strDataLength + ",\r\n";
						if(drRow[0].ToString()!=dsTable.Tables[5].Rows[0]["index_keys"].ToString())
						{
							strInsert += drRow[0].ToString()+",";
							strInsertParameter += @"@" + drRow[0].ToString()+",";
						}
					}
				}
				strInsert = strInsert.Remove(strInsert.Length-1,1);
				strInsertParameter =strInsertParameter.Remove(strInsertParameter.Length-1,1);
				txtOutPut.Text =txtOutPut.Text.Trim().Remove(txtOutPut.Text.LastIndexOf(","), 1);
				txtOutPut.Text += "\r\n ) \r\n";
				txtOutPut.Text += "AS\r\n";
				txtOutPut.Text += "BEGIN\r\n";
				txtOutPut.Text += "	INSERT INTO " + cmbTables.Text + "(" + strInsert + ")\r\n";
				txtOutPut.Text += "		VALUES(" + strInsertParameter + ")\r\n";
				txtOutPut.Text += "END\r\n\r\n";
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
		}

		private void pDelete(string strTableName)
		{
			try
			{
				insRemark();
				txtOutPut.Text += "\r\n--DROP PROCEDURE p" + strTableName + "_D\r\n";
				txtOutPut.Text += "CREATE PROCEDURE p" + strTableName + "_D(\r\n";
				
				foreach(DataRow drRow in dsTable.Tables[1].Rows)
				{
					if(drRow[0].ToString()!="cDate")
					{
						string strDataLength="";
						if(drRow[1].ToString()=="varchar")
							strDataLength="("+drRow[3].ToString()+")";
						if(drRow[0].ToString()==dsTable.Tables[5].Rows[0]["index_keys"].ToString())
						{
							txtOutPut.Text += @"	@"+ drRow[0].ToString() + " " + drRow[1].ToString() + strDataLength + ")\r\n";
						}
					}
				}
				txtOutPut.Text += "AS\r\n";
				txtOutPut.Text += "BEGIN\r\n";
				txtOutPut.Text += "	DELETE FROM " + cmbTables.Text + "\r\n";
				txtOutPut.Text += "	WHERE " + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @"=@" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
				txtOutPut.Text += "END\r\n\r\n";
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
		}

		private void pSelect(string strTableName)
		{
			try
			{
				insRemark();
				txtOutPut.Text += "\r\n--DROP PROCEDURE p" + strTableName + "_S\r\n";
				txtOutPut.Text += "CREATE PROCEDURE p" + strTableName + "_S(\r\n";
				txtOutPut.Text += @"	@Flag Char," + "\r\n";
				foreach(DataRow drRow in dsTable.Tables[1].Rows)
				{
					if(drRow[0].ToString()!="cDate")
					{
						string strDataLength="";
						if(drRow[1].ToString()=="varchar")
							strDataLength="("+drRow[3].ToString()+")";
						if(drRow[0].ToString()==dsTable.Tables[5].Rows[0]["index_keys"].ToString())
						{
							txtOutPut.Text += @"	@"+ drRow[0].ToString() + " " + drRow[1].ToString() + strDataLength + ")\r\n";
						}
					}
				}
				txtOutPut.Text += "AS\r\n";
				txtOutPut.Text += "BEGIN\r\n";
				txtOutPut.Text += @"	IF @Flag='A' " + "\r\n";
				txtOutPut.Text += "	BEGIN \r\n";
				txtOutPut.Text += "		SELECT * \r\n		FROM " + cmbTables.Text + "\r\n";
				txtOutPut.Text += "	END\r\n";
				txtOutPut.Text += "	ELSE\r\n";
				txtOutPut.Text += "	BEGIN \r\n";
				txtOutPut.Text += "		SELECT * \r\n		FROM " + cmbTables.Text + "\r\n";
				txtOutPut.Text += "		WHERE " + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + @"=@" + dsTable.Tables[5].Rows[0]["index_keys"].ToString() + "\r\n";
				txtOutPut.Text += "	END\r\n";
				txtOutPut.Text += "END\r\n\r\n";
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
		}

		private void writeProc(string strTableName)
		{
			if(chkInsert.Checked && chkUpdate.Checked)
			{
				pInsertUpdate(strTableName);
			}
			else if(chkInsert.Checked)
			{
				pInsert(strTableName);
			}
			if(chkDelete.Checked)
			{
				pDelete(strTableName);
			}
			if(chkSelect.Checked)
			{
				pSelect(strTableName);
			}
		}
		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(chkAll.Checked)
				{
					IEnumerator ie=cmbTables.Items.GetEnumerator();
					while(ie.MoveNext())
					{
						//MessageBox.Show(ie.Current.ToString());
						fillDataSet(ie.Current.ToString());
					}
				}
				else
				{
					fillDataSet(cmbTables.Text);
				}
				btnRun.Enabled=true;
				btnSaveAs.Enabled=true;
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
			finally
			{
				conCC.Close();
			}
		}

		private void btnSaveAs_Click(object sender, System.EventArgs e)
		{
			try
			{
				saveFileDialog1.ShowDialog();
				string strPath=saveFileDialog1.FileName;
				saveFileDialog1.Dispose();
//				MessageBox.Show(strPath);
				if(System.IO.File.Exists(strPath))
				{
					MessageBox.Show("Ffdsfafsdf");
				}
				else
				{
					StreamWriter sw=new StreamWriter(strPath, true);
					sw.Write(txtOutPut.Text);
					sw.Close();
				}
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
		}

		private void btnRun_Click(object sender, System.EventArgs e)
		{
			try
			{
				conCC.Open();
				string strCommand=txtOutPut.Text.Replace("\r", " ");
				strCommand=strCommand.Replace("\n", " ");
				strCommand=strCommand.Replace("\t", " ");
				Analyser frmAnalyser=new Analyser(conCC);
				frmAnalyser.Show();
			}
			catch(Exception ex)
			{
				insError(ex.ToString());
			}
			finally
			{
				conCC.Close();
			}
		}

		private void cmbTables_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbTables.Text!="")
			{
				btnCreate.Enabled=true;
				btnRun.Enabled=true;
				btnSaveAs.Enabled=true;
			}
			else
			{
				btnCreate.Enabled=false;
				btnRun.Enabled=false;
				btnSaveAs.Enabled=false;
			}
		}

		private void cmbTables_TextChanged(object sender, System.EventArgs e)
		{
			if(cmbTables.Text!="")
			{
				btnCreate.Enabled=true;
				btnRun.Enabled=true;
				btnSaveAs.Enabled=true;
			}
			else
			{
				btnCreate.Enabled=false;
				btnRun.Enabled=false;
				btnSaveAs.Enabled=false;
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			txtOutPut.Text="";
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
				btnCreate.Enabled=true;
		}
	}
}