using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for Programmer.
	/// </summary>
	public class Programmer : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Programmer()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Programmer));
            this.SuspendLayout();
            // 
            // Programmer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(363, 136);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Programmer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Application";
            this.Load += new System.EventHandler(this.Programmer_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void Programmer_Load(object sender, System.EventArgs e)
		{
            //try
            //{
            //    Microsoft.Win32.Registry.ClassesRoot.DeleteValue(EncDec.Encrypt("dTimeInstalled", "cDate"));
            //    Microsoft.Win32.Registry.ClassesRoot.DeleteValue(EncDec.Encrypt("dTimeLastAccess", "LastAccess"));
            //    Microsoft.Win32.Registry.ClassesRoot.DeleteValue(EncDec.Encrypt("DB2Register", "HDD 0506 Register"));
            //    MessageBox.Show("Registry Clear Succefully.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
		}
	}
}
