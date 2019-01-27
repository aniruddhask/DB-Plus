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
	/// Summary description for ProcedureSelection.
	/// </summary>
	public class ProcedureSelection : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstProcedure;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ArrayList arrlstProc=new ArrayList();
		private System.Windows.Forms.ListBox lstSelectedProcedure;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.GroupBox gbxProcDesc;
		private System.Windows.Forms.DataGrid dtgProcDetails;
		SqlConnection objSqlConnction=new SqlConnection();
		public ProcedureSelection(ArrayList arrlstProcedure, SqlConnection newSqlConnection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			arrlstProc=arrlstProcedure;
			objSqlConnction=newSqlConnection;
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
			this.lstProcedure = new System.Windows.Forms.ListBox();
			this.lstSelectedProcedure = new System.Windows.Forms.ListBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.gbxProcDesc = new System.Windows.Forms.GroupBox();
			this.dtgProcDetails = new System.Windows.Forms.DataGrid();
			this.gbxProcDesc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgProcDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// lstProcedure
			// 
			this.lstProcedure.Location = new System.Drawing.Point(6, 5);
			this.lstProcedure.Name = "lstProcedure";
			this.lstProcedure.Size = new System.Drawing.Size(208, 95);
			this.lstProcedure.TabIndex = 0;
			this.lstProcedure.SelectedIndexChanged += new System.EventHandler(this.lstProcedure_SelectedIndexChanged);
			// 
			// lstSelectedProcedure
			// 
			this.lstSelectedProcedure.Location = new System.Drawing.Point(304, 5);
			this.lstSelectedProcedure.Name = "lstSelectedProcedure";
			this.lstSelectedProcedure.Size = new System.Drawing.Size(176, 95);
			this.lstSelectedProcedure.TabIndex = 2;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(224, 5);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "&>";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(224, 32);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 4;
			this.btnRemove.Text = "&<";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// gbxProcDesc
			// 
			this.gbxProcDesc.Controls.Add(this.dtgProcDetails);
			this.gbxProcDesc.Location = new System.Drawing.Point(8, 104);
			this.gbxProcDesc.Name = "gbxProcDesc";
			this.gbxProcDesc.Size = new System.Drawing.Size(472, 168);
			this.gbxProcDesc.TabIndex = 5;
			this.gbxProcDesc.TabStop = false;
			// 
			// dtgProcDetails
			// 
			this.dtgProcDetails.DataMember = "";
			this.dtgProcDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgProcDetails.Location = new System.Drawing.Point(3, 16);
			this.dtgProcDetails.Name = "dtgProcDetails";
			this.dtgProcDetails.Size = new System.Drawing.Size(464, 149);
			this.dtgProcDetails.TabIndex = 0;
			// 
			// ProcedureSelection
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(482, 273);
			this.Controls.Add(this.gbxProcDesc);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lstSelectedProcedure);
			this.Controls.Add(this.lstProcedure);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ProcedureSelection";
			this.Text = "ProcedureSelection";
			this.Load += new System.EventHandler(this.ProcedureSelection_Load);
			this.gbxProcDesc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgProcDetails)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ProcedureSelection_Load(object sender, System.EventArgs e)
		{
			IDictionaryEnumerator iDEProcedure=CompleteDataBase.htProcedure.GetEnumerator();
			IEnumerator enumProc=arrlstProc.GetEnumerator();
			while(enumProc.MoveNext())
				lstProcedure.Items.Add(enumProc.Current.ToString());
			gbxProcDesc.Visible=false;
		}
		Hashtable htParameterLst=new Hashtable();
		private void lstProcedure_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(lstProcedure.SelectedIndex!=-1)
				{
					SqlCommand newSqlCommand = new SqlCommand("SP_HELP " + lstProcedure.SelectedItem.ToString(), objSqlConnction);	
					SqlDataAdapter daParameter=new SqlDataAdapter(newSqlCommand);
					DataSet dsParameter=new DataSet();
					daParameter.Fill(dsParameter);
					if(dsParameter.Tables.Count>1)
					{
						dtgProcDetails.DataSource=dsParameter.Tables[1];
						gbxProcDesc.Visible=true;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lstProcedure.SelectedIndex!=-1)
				{
					lstSelectedProcedure.Items.Add(lstProcedure.SelectedItem);
					lstProcedure.Items.Remove(lstProcedure.SelectedItem);
				}
				else
				{
					MessageBox.Show("No Procedure Selected.");
					lstProcedure.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(lstSelectedProcedure.SelectedIndex!=-1)
			{
				lstProcedure.Items.Add(lstSelectedProcedure.SelectedItem);
				lstSelectedProcedure.Items.RemoveAt(lstSelectedProcedure.SelectedIndex);
			}
			else
			{
				MessageBox.Show("No Procedure Selected.");
				lstSelectedProcedure.Focus();
			}
		}
	}
}
