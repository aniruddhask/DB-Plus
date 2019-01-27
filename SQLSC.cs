using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;

namespace CompleteDataBaseAccess
{
    public partial class SQLSC : Form
    {
        private ArrayList _arrlstConnectionParameters;
        private Server _srvSQLServer;
        public SQLSC(ArrayList arrlstConnectionParameters)
        {
            InitializeComponent();
            _arrlstConnectionParameters = new ArrayList();
            _arrlstConnectionParameters = arrlstConnectionParameters;
        }

        //You could also use dynamic arrays here
        //with ArrayList
        Database[] arrDBs = new Database[100];
        Table[] arrTables = new Table[1000];
        //Microsoft.SqlServer.Management.Smo.View[] arrTables = new Microsoft.SqlServer.Management.Smo.View[1000];
        private void SQLSC_Load(object sender, EventArgs e)
        {
            _srvSQLServer = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(new System.Data.SqlClient.SqlConnection("user id=" + _arrlstConnectionParameters[1].ToString() + "; password=" + _arrlstConnectionParameters[2].ToString() + "; data source=" + _arrlstConnectionParameters[0].ToString())));
            lblServerDetails.Text = _arrlstConnectionParameters[0].ToString();
        }

        private void ClearArray()
        {
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            listDatabases.Items.Clear();
            listTables.Items.Clear();
            txtSQLScript.Clear();
            ClearArray();

            listDatabases.DisplayMember = "Name";

            int i = 0;

            foreach (Database tmpdb in _srvSQLServer.Databases)
            {
                if (!tmpdb.IsSystemObject)
                {
                    listDatabases.Items.Add(tmpdb.ToString());
                    arrDBs[i] = tmpdb;
                    i++;
                }
            }
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            listTables.Items.Clear();
            txtSQLScript.Clear();
            listTables.DisplayMember = "ToString()";

            Database tmpdb = new Database();
            tmpdb = arrDBs[listDatabases.SelectedIndex];
            int i = 0;

            foreach (Table tmptable in tmpdb.Tables)
            {
                if (tmptable.IsSystemObject != true)
                {
                    listTables.Items.Add(tmptable.ToString());
                    arrTables[i] = tmptable;
                    i++;
                }
            }
            for (int iIndex = 0; iIndex < i; iIndex++)
                GetScript(iIndex);
        }

        private void GetScript(int iIndex)
        {
            StringCollection sc = new StringCollection();

            //Get the table's script
            sc = arrTables[iIndex].Script();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sc.Count; i++)
            {
                sb.AppendLine(sc[i]);
            }

            //txtSQLScript.Text = sb.ToString();
            string strPath = @".\Tables";
            if (!System.IO.Directory.Exists(strPath))
                System.IO.Directory.CreateDirectory(strPath);
            System.IO.StreamWriter swTable = new System.IO.StreamWriter(strPath+ @"\"+ listDatabases.SelectedItem.ToString() + ".txt", true);
            swTable.Write(sb.ToString());
            swTable.WriteLine("                                                       ");
            swTable.WriteLine("                                                       ");
            swTable.WriteLine("*******************************************************");
            swTable.Close();
        }
        private void listTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();

            //Get the table's script
            sc = arrTables[listTables.SelectedIndex].Script();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sc.Count; i++)
            {
                sb.AppendLine(sc[i]);
            }

            txtSQLScript.Text = sb.ToString();
        }
    }
}