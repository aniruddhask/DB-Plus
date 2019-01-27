using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class AddItem : Form
    {
        ArrayList arrlstParameters;
        public AddItem(ArrayList arrlstConnectionString)
        {
            InitializeComponent();
            arrlstParameters = arrlstConnectionString;
        }

        public ArrayList arrlstSelectedTables = new ArrayList();

        private void AddItem_Load(object sender, EventArgs e)
        {
            OleDbConnection conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
            try
            {
                conCC.Open();
                OleDbCommand objOleDbCommand;
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    //initialize the command for getting all the table of sql sever selected database.
                    objOleDbCommand = new OleDbCommand("sp_tables", conCC);
                }
                else
                {
                    //reset connection to the information_schema for getting tables of selected database from mysql database.
                    conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=Information_Schema");
                    //initialize the command for getting all the table of mysql selected database.
                    objOleDbCommand = new OleDbCommand("SELECT '0' AS 'Column1', '0' AS 'Column2', TABLE_NAME, Table_Type FROM TABLES WHERE TABLE_SCHEMA='" + arrlstParameters[4].ToString() + "'", conCC);
                }
                OleDbDataAdapter oDa = new OleDbDataAdapter(objOleDbCommand);
                DataSet ds = new DataSet();
                oDa.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    chklstTables.Items.Add(dr[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conCC.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (string chklst in chklstTables.CheckedItems)
            {
                    arrlstSelectedTables.Add(chklst);
            }
            this.Dispose();
        }
    }
}