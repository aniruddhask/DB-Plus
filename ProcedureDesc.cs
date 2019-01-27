using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for ProcedureDesc.
	/// </summary>
	public class ProcedureDesc : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstParameterLst;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Hashtable htProcedureParameter=new Hashtable();
		public ProcedureDesc(Hashtable htParameterLst)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
	
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			htProcedureParameter=htProcedureParameter;
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
			this.lstParameterLst = new System.Windows.Forms.ListBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstParameterLst
			// 
			this.lstParameterLst.Location = new System.Drawing.Point(6, 4);
			this.lstParameterLst.Name = "lstParameterLst";
			this.lstParameterLst.Size = new System.Drawing.Size(168, 160);
			this.lstParameterLst.TabIndex = 0;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(180, 5);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(180, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// ProcedureDesc
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(258, 167);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.lstParameterLst);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ProcedureDesc";
			this.ShowInTaskbar = false;
			this.Text = "ProcedureDesc";
			this.Load += new System.EventHandler(this.ProcedureDesc_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ProcedureDesc_Load(object sender, System.EventArgs e)
		{
			foreach(DictionaryEntry deParameter in htProcedureParameter)
				lstParameterLst.Items.Add(deParameter.Value);
		}
	}
}
