using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace CompleteDataBaseAccess
{
    public partial class SQLSC : Form
    {
        private ArrayList _arrlstConnectionParameters;
        public SQLSC(ArrayList arrlstConnectionParameters)
        {
            InitializeComponent();
            _arrlstConnectionParameters = new ArrayList();
            _arrlstConnectionParameters = arrlstConnectionParameters;
        }

        //You could also use dynamic arrays here
        //with ArrayList
        //Microsoft.SqlServer.Management.Smo.View[] arrTables = new Microsoft.SqlServer.Management.Smo.View[1000];
        private void SQLSC_Load(object sender, EventArgs e)
        {
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

        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            listTables.Items.Clear();
            txtSQLScript.Clear();
            listTables.DisplayMember = "ToString()";

        }

        private void GetScript(int iIndex)
        {
        }
        private void listTables_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}