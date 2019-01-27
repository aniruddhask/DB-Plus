using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for OkCancelBOFunction.
	/// </summary>
	public class OkCancelBOFunction : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtFunctionName;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OkCancelBOFunction()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.txtFunctionName = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtFunctionName
			// 
			this.txtFunctionName.Location = new System.Drawing.Point(2, 8);
			this.txtFunctionName.Name = "txtFunctionName";
			this.txtFunctionName.Size = new System.Drawing.Size(224, 20);
			this.txtFunctionName.TabIndex = 0;
			this.txtFunctionName.Text = "";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(72, 32);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(152, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// OkCancelBOFunction
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(232, 58);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtFunctionName);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OkCancelBOFunction";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.OkCancelBOFunction_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void OkCancelBOFunction_Load(object sender, System.EventArgs e)
		{
			txtFunctionName.Text=CompleteDataBase.strFunctionName;
			txtFunctionName.SelectAll();
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			CompleteDataBase.strFunctionName=txtFunctionName.Text;
			this.Dispose();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			CompleteDataBase.strFunctionName="Cancel";
			this.Dispose();
		}
	}
}
