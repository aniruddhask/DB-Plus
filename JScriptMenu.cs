using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace CompleteDataBaseAccess
{
	/// <summary>
	/// Summary description for JScriptMenu.
	/// </summary>
	public class JScriptMenu : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.TextBox txtScript;
        private Label label1;
        private TextBox txtFrom;
        private Label label2;
        OleDbConnection oSqlConnection;
        private Button btnCopyScript;
        private Button btnCopyButtonHtml;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JScriptMenu(OleDbConnection conCC)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            oSqlConnection = conCC;
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopyScript = new System.Windows.Forms.Button();
            this.btnCopyButtonHtml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(631, 8);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtOutput.Location = new System.Drawing.Point(8, 33);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(902, 241);
            this.txtOutput.TabIndex = 1;
            // 
            // txtScript
            // 
            this.txtScript.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtScript.Location = new System.Drawing.Point(8, 280);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ReadOnly = true;
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(900, 205);
            this.txtScript.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select From";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(86, 10);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(228, 21);
            this.txtFrom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "(ParentId, Display, URL) Columns are required.";
            // 
            // btnCopyScript
            // 
            this.btnCopyScript.Location = new System.Drawing.Point(806, 8);
            this.btnCopyScript.Name = "btnCopyScript";
            this.btnCopyScript.Size = new System.Drawing.Size(101, 23);
            this.btnCopyScript.TabIndex = 6;
            this.btnCopyScript.Text = "Copy &Script";
            this.btnCopyScript.UseVisualStyleBackColor = false;
            this.btnCopyScript.Click += new System.EventHandler(this.btnCopyScript_Click);
            // 
            // btnCopyButtonHtml
            // 
            this.btnCopyButtonHtml.Location = new System.Drawing.Point(712, 8);
            this.btnCopyButtonHtml.Name = "btnCopyButtonHtml";
            this.btnCopyButtonHtml.Size = new System.Drawing.Size(88, 23);
            this.btnCopyButtonHtml.TabIndex = 7;
            this.btnCopyButtonHtml.Text = "Copy &HTML";
            this.btnCopyButtonHtml.UseVisualStyleBackColor = false;
            this.btnCopyButtonHtml.Click += new System.EventHandler(this.btnCopyButtonHtml_Click);
            // 
            // JScriptMenu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(914, 490);
            this.Controls.Add(this.btnCopyButtonHtml);
            this.Controls.Add(this.btnCopyScript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGenerate);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "JScriptMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Scrolling Menu Bar";
            this.Load += new System.EventHandler(this.JScriptMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region J Script

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (oSqlConnection.State == ConnectionState.Closed)
                    oSqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + txtFrom.Text, oSqlConnection);
				OleDbDataAdapter da=new OleDbDataAdapter(cmd);
				System.Data.DataTable dt=new System.Data.DataTable();
				da.Fill(dt);

				string strButtons="";
				string strFunUp="";
				string strFunDown="";
				string strVar="";
				string strOther="";
				string strScript="		<script language=" + Convert.ToChar(34) +" javascript " + Convert.ToChar(34) + ">\r\n		var iCurrent=1;\r\n		var iPrevious=1;\r\n";

				int iEntry=0;
				int iCount=0;

				foreach(DataRow dr in dt.Rows)
				{
					if(iEntry==0)
					{
						if(dr["ParentId"].ToString()=="0")
						{
							iCount+=1;
							strButtons+="<INPUT id='inp" + iCount + "' onclick='btnClick_" + iCount + "()' type='button' class='btn'>\r\n";
							strButtons+="	<div id='MainMenu" + iCount + "' class='MainMenu'>\r\n";
							strButtons+="		<TABLE class='tbl'>\r\n";
							
							strVar+="\r\n		var iTotalHeightPnl_" + iCount + "=document.getElementById('MainMenu" + iCount + "').offsetHeight;";
							strVar+="\r\n		var iActualHeight_" + iCount + "=iTotalHeightPnl_" + iCount + ";";

							strFunUp+="\r\n		if(iPrevious==" + iCount + ")";
							strFunUp+="\r\n			SlideUp_" + iCount + "();";

							strFunDown+="\r\n		if(iCurrent==" + iCount + ")";
							strFunDown+="\r\n			SlideDown_" + iCount + "();";
							
							strOther+="		function btnClick_" + iCount + "()\r\n";
							strOther+="		{\r\n";
							strOther+="			iPrevious=iCurrent;\r\n";
							strOther+="			iCurrent=" + iCount + ";\r\n";
							strOther+="			RunSlider();\r\n";
							strOther+="		}\r\n";
			
							strOther+="		function SlideUp_" + iCount + "()\r\n";
							strOther+="		{\r\n";
							strOther+="		if(iActualHeight_" + iCount + ">1)\r\n";
							strOther+="				{\r\n";
							strOther+="				iActualHeight_" + iCount + " = iActualHeight_" + iCount + " - 1;\r\n";
							strOther+="				document.getElementById('MainMenu" + iCount + "').style.height=iActualHeight_" + iCount + ";\r\n";
							strOther+="				window.setTimeout(" + Convert.ToChar(34) + "SlideUp_" + iCount + "();" + Convert.ToChar(34) + ",10);\r\n";
							strOther+="				}\r\n";
							strOther+="		}\r\n";

							strOther+="		function SlideDown_" + iCount + "()\r\n";
							strOther+="		{\r\n";
							strOther+="		if(iActualHeight_" + iCount + "<iTotalHeightPnl_" + iCount + ")\r\n";
							strOther+="				{\r\n";
							strOther+="				iActualHeight_" + iCount + " = iActualHeight_" + iCount + " + 1;\r\n";
							strOther+="				document.getElementById('MainMenu" + iCount + "').style.height=iActualHeight_" + iCount + ";\r\n";
							strOther+="				window.setTimeout(" + Convert.ToChar(34) + "SlideDown_" + iCount + "();" + Convert.ToChar(34) + ",10);\r\n";
							strOther+="				}\r\n";
							strOther+="		}\r\n";

						}
						else
						{
							strButtons+="				<TR><TD><A href=" + Convert.ToChar(34) + Convert.ToChar(34) + ">" + dr[2].ToString() + "</A></TD></TR>\r\n";
						}
						iEntry=1;
					}
					else
					{
						if(dr["ParentId"].ToString()=="0")
						{
							iCount+=1;
							strButtons+="		</TABLE></div>\r\n";
                            strButtons+="<INPUT id='inp" + iCount + "' onclick='btnClick_" + iCount + "()' type='button' class='btn'>\r\n";
							strButtons+="	<div id='MainMenu" + iCount + "' class='MainMenu'>\r\n";
							strButtons+="		<TABLE class='tbl'>\r\n";
						
							strVar+="		var iTotalHeightPnl_" + iCount + "=document.getElementById('MainMenu" + iCount + "').offsetHeight\r\n";
							strVar+="		var iActualHeight_" + iCount + "=iTotalHeightPnl_" + iCount + ";";

							strFunUp+="\r\n		else if(iPrevious==" + iCount + ")";
							strFunUp+="\r\n			SlideUp_" + iCount + "();";

							strFunDown+="\r\n		else if(iCurrent==" + iCount + ")";
							strFunDown+="\r\n			SlideDown_" + iCount + "();";

							strOther+="		function btnClick_" + iCount + "()\r\n";
							strOther+="		{\r\n";
							strOther+="			iPrevious=iCurrent;\r\n";
							strOther+="			iCurrent=" + iCount + ";\r\n";
							strOther+="			RunSlider();\r\n";
							strOther+="		}\r\n";
			
							strOther+="		function SlideUp_" + iCount + "()\r\n";
							strOther+="		{\r\n";
							strOther+="		if(iActualHeight_" + iCount + ">1)\r\n";
							strOther+="				{\r\n";
							strOther+="				iActualHeight_" + iCount + " = iActualHeight_" + iCount + " - 1;\r\n";
							strOther+="				document.getElementById('MainMenu" + iCount + "').style.height=iActualHeight_" + iCount + ";\r\n";
							strOther+="				window.setTimeout(" + Convert.ToChar(34) + "SlideUp_" + iCount + "();" + Convert.ToChar(34) + ",10);\r\n";
							strOther+="				}\r\n";
							strOther+="		}\r\n";

							strOther+="		function SlideDown_" + iCount + "()\r\n";
							strOther+="		{\r\n";
							strOther+="		if(iActualHeight_" + iCount + "<iTotalHeightPnl_" + iCount + ")\r\n";
							strOther+="				{\r\n";
							strOther+="				iActualHeight_" + iCount + " = iActualHeight_" + iCount + " + 1;\r\n";
							strOther+="				document.getElementById('MainMenu" + iCount + "').style.height=iActualHeight_" + iCount + ";\r\n";
							strOther+="				window.setTimeout(" + Convert.ToChar(34) + "SlideDown_" + iCount + "();" + Convert.ToChar(34) + ",10);\r\n";
							strOther+="				}\r\n";
							strOther+="		}\r\n";

						}
						else
						{
                            strButtons += "				<TR><TD><A href=" + Convert.ToChar(34) + dr["Url"].ToString() + Convert.ToChar(34) + ">" + dr["Display"].ToString() + "</A></TD></TR>\r\n";
						}
					}
				}

				string strscr=strScript;
				strscr+="\r\n" + strVar + "\r\n";

				strscr+="		function RunSlider()\r\n";
				strscr+="		{\r\n";
				strscr+="			if(iCurrent!=iPrevious)\r\n";
				strscr+="			{\r\n";
				strscr+="				Down();\r\n";
				strscr+="				Up();\r\n";
				strscr+="			}\r\n";
				strscr+="		}\r\n\r\n";
				
				strscr+="		function Up()\r\n";
				strscr+="		{\r\n";
				strscr+=strFunUp;
				strscr+="\r\n		}\r\n";
				
				strscr+="		function Down()\r\n";
				strscr+="		{\r\n";
				strscr+=strFunDown;
				strscr+="\r\n		}\r\n";

				strscr+=strOther;
				strscr+="\r\n</Script>";

				txtOutput.Text=strButtons;
				txtScript.Text=strscr;

                btnCopyScript.Enabled = true;
                btnCopyButtonHtml.Enabled = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				oSqlConnection.Close();
			}
		}

		#endregion

        private void JScriptMenu_Load(object sender, EventArgs e)
        {
            btnCopyButtonHtml.Enabled = false;
            btnCopyScript.Enabled = false;
        }

        private void btnCopyButtonHtml_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "</Tabel></DIV>";
            Clipboard.SetDataObject(txtOutput.Text);
        }

        private void btnCopyScript_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtScript.Text);
        }
	}
}
