using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;
using System.Data.OleDb;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace CompleteDataBaseAccess
{
    public partial class frmDataBackup : Form
    {
        private OleDbConnection _OleDbConnection = new OleDbConnection();
        private Server _SQLServer;
        private ArrayList _arrlstConnectionParameters;
        public frmDataBackup(ArrayList arrlstConnectionParameters)
        {
            InitializeComponent();
            _arrlstConnectionParameters = new ArrayList();
            _arrlstConnectionParameters = arrlstConnectionParameters;
        }
        public OleDbConnection ConnectionObj
        {
            get
            {
                return _OleDbConnection;
            }
            set
            {
                _OleDbConnection = value;
            }
        }
        private void frmDataBackup_Load(object sender, EventArgs e)
        {
            if (ConnectionObj != null)
                _SQLServer = new Server(new ServerConnection(new SqlConnection("user id=" + _arrlstConnectionParameters[1].ToString() + "; password=" + _arrlstConnectionParameters[2].ToString() + "; data source=" + _arrlstConnectionParameters[0].ToString())));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringCollection strScript = new StringCollection();
                StreamWriter oStreamWriter = new StreamWriter(txtFolderName.Text + @"\" + txtDatabaseName.Text + "_" + DateTime.Now.DayOfYear.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Ticks.ToString() + ".sql");
                foreach (Database tmpdb in _SQLServer.Databases)
                {
                    if (tmpdb.Name == txtDatabaseName.Text)
                    {
                        if (comboBox1.Text == "All" || comboBox1.Text == "Tables")
                        {
                            foreach (Table tbl in tmpdb.Tables)
                            {
                                if (tbl.Name.Contains("tbl"))
                                {
                                    //MessageBox.Show(tbl.Name);
                                    strScript = tbl.Script();
                                    foreach (string str in strScript)
                                    {
                                        oStreamWriter.WriteLine("\r\n");
                                        oStreamWriter.Write(str);
                                    }
                                }
                            }
                        }
                        if (comboBox1.Text == "All" || comboBox1.Text == "Procedures")
                        {
                            foreach (StoredProcedure tbl in tmpdb.StoredProcedures)
                            {
                                if (tbl.Name.Contains("usptbl"))
                                {
                                    //MessageBox.Show(tbl.Name);
                                    strScript = tbl.Script();
                                    foreach (string str in strScript)
                                    {
                                        oStreamWriter.WriteLine("\r\n");
                                        oStreamWriter.Write(str);
                                    }
                                }
                            }
                        }
                        if (comboBox1.Text == "All" || comboBox1.Text == "Views")
                        {
                            foreach (Microsoft.SqlServer.Management.Smo.View tbl in tmpdb.Views)
                            {
                                strScript = tbl.Script();
                                foreach (string str in strScript)
                                {
                                    oStreamWriter.WriteLine("\r\n");
                                    oStreamWriter.Write(str);
                                }
                            }
                        }
                    }
                }
                oStreamWriter.Close();
                MessageBox.Show("Script generated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
        }
    }
}