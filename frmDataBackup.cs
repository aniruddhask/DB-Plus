using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace CompleteDataBaseAccess
{
    public partial class frmDataBackup : Form
    {
        private OleDbConnection _OleDbConnection = new OleDbConnection();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}