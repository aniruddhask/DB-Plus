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
	/// Summary description for Form2.
	/// </summary>
	public class Analyser : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.DataGrid dgridOutPut;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnGrid;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label lblMsg;
		SqlConnection conCC=new SqlConnection();
		public Analyser(SqlConnection newCon)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			conCC=newCon;
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
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.btnRun = new System.Windows.Forms.Button();
			this.dgridOutPut = new System.Windows.Forms.DataGrid();
			this.btnGrid = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.lblMsg = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgridOutPut)).BeginInit();
			this.SuspendLayout();
			// 
			// txtQuery
			// 
			this.txtQuery.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.txtQuery.ForeColor = System.Drawing.Color.Navy;
			this.txtQuery.Location = new System.Drawing.Point(8, 24);
			this.txtQuery.Multiline = true;
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtQuery.Size = new System.Drawing.Size(920, 192);
			this.txtQuery.TabIndex = 0;
			this.txtQuery.Text = "";
			// 
			// btnRun
			// 
			this.btnRun.BackColor = System.Drawing.Color.LightCyan;
			this.btnRun.Location = new System.Drawing.Point(8, 0);
			this.btnRun.Name = "btnRun";
			this.btnRun.TabIndex = 1;
			this.btnRun.Text = "&Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// dgridOutPut
			// 
			this.dgridOutPut.DataMember = "";
			this.dgridOutPut.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridOutPut.Location = new System.Drawing.Point(8, 216);
			this.dgridOutPut.Name = "dgridOutPut";
			this.dgridOutPut.ReadOnly = true;
			this.dgridOutPut.Size = new System.Drawing.Size(920, 376);
			this.dgridOutPut.TabIndex = 2;
			// 
			// btnGrid
			// 
			this.btnGrid.Location = new System.Drawing.Point(88, 0);
			this.btnGrid.Name = "btnGrid";
			this.btnGrid.TabIndex = 3;
			this.btnGrid.Text = "&Grid";
			this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(168, 0);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.TabIndex = 4;
			this.btnOpen.Text = "&Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// lblMsg
			// 
			this.lblMsg.Location = new System.Drawing.Point(256, 3);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(664, 16);
			this.lblMsg.TabIndex = 5;
			// 
			// Analyser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(930, 592);
			this.Controls.Add(this.lblMsg);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnGrid);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.dgridOutPut);
			this.Controls.Add(this.txtQuery);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Analyser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Query Analyser (Designed By Aniruddha)";
			this.Load += new System.EventHandler(this.Analyser_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgridOutPut)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Analyser_Load(object sender, System.EventArgs e)
		{
			this.Text="Query Analyser " + conCC.ConnectionString;
		}

		private void btnRun_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlCommand cmdRun=new SqlCommand(txtQuery.SelectedText, conCC);
				DataSet dsResult=new DataSet();
				SqlDataAdapter daResult=new SqlDataAdapter(cmdRun);
				daResult.Fill(dsResult);
				if(dsResult.Tables.Count>0)
				{
					dgridOutPut.DataSource=dsResult.Tables;
					lblMsg.Visible = false;
				}
				else
				{
					lblMsg.Visible = true;
                    lblMsg.Text = "Command executed successfully.";
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

		private void btnGrid_Click(object sender, System.EventArgs e)
		{
			if(btnGrid.Text=="&Grid")
			{
				txtQuery.Height=636;
				dgridOutPut.Visible=false;
				btnGrid.Text="Show &Grid";
			}
			else
			{
				txtQuery.Height=192;
				dgridOutPut.Visible=true;
				btnGrid.Text="&Grid";
			}
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			try
			{
				openFileDialog1.ShowDialog();
				string strOpen = openFileDialog1.FileName;
				if(strOpen!="")
				{
					StreamReader srOpen = new StreamReader(strOpen);
					txtQuery.Text = srOpen.ReadToEnd();
					srOpen.Close();
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
	}
}
