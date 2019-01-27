using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class ExecuteProcedure : Form
    {
        OleDbConnection oOleDbConnection;
        string strProcedureName;
        public ExecuteProcedure(OleDbConnection conCC, string Procedure)
        {
            InitializeComponent();
            oOleDbConnection = conCC;
            strProcedureName = Procedure;
        }

        #region Form Load
        private void ExecuteProcedure_Load(object sender, EventArgs e)
        {
            try
            {
                if (oOleDbConnection.State == ConnectionState.Closed)
                    oOleDbConnection.Open();
                OleDbCommand oOleDbCommand = new OleDbCommand("SP_HELP " + strProcedureName, oOleDbConnection);
                DataSet dsParameter = new DataSet();
                OleDbDataAdapter daParameter = new OleDbDataAdapter(oOleDbCommand);
                daParameter.Fill(dsParameter);
                if (dsParameter.Tables.Count == 1)
                    DataGrid.dsColumns = dsParameter;
                else
                {
                    int iCount = 0;
                    foreach (DataRow drColumns in dsParameter.Tables[1].Rows)
                    {
                        CreateParameter(drColumns, iCount, pnlParameters.Controls.Count/2);
                    }
                }
                oOleDbConnection.Close();
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        #endregion

        #region Creating controls for filling the values for execution of the procedure
        private void CreateParameter(DataRow drColumn, int Count, int Possition)
        {
            try
            {
                Label lbl = new Label();
                lbl.Name = "lbl" + Count.ToString();
                lbl.Width = 200;
                lbl.Height = 13;
                lbl.Text = drColumn[0].ToString().Replace(@"@", "");
                lbl.Top = 25 * Possition;
                lbl.Left = 5;
                //lbl.ForeColor = Color.FromArgb(156, 86, 136);

                TextBox txt = new TextBox();
                txt.Name = "txt" + Count.ToString();
                txt.Width = 300;
                txt.Height = 13;
                txt.MaxLength = Convert.ToInt32(drColumn["Length"]);
                if (drColumn["Type"].ToString() == "bigint" || drColumn["Type"].ToString() == "int")
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                txt.Top = 25 * Possition;
                txt.Left = 205;
                //txt.ForeColor = Color.FromArgb(156, 86, 136);

                pnlParameters.Controls.Add(lbl);
                pnlParameters.Controls.Add(txt);
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }
        #endregion

        #region Execute the procedure
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                int iCount = 1;
                string strCommand = "EXEC " + strProcedureName + " ";
                foreach (Control ctrl in pnlParameters.Controls)
                {
                    if (iCount % 2 == 0)
                    {
                        strCommand += "'" + ((TextBox)(ctrl)).Text + "', ";
                    }
                    iCount++;
                }
                if (oOleDbConnection.State == ConnectionState.Closed)
                    oOleDbConnection.Open();
                string str = strCommand.Remove(strCommand.LastIndexOf(","));
                OleDbCommand cmdInner = new OleDbCommand(str, oOleDbConnection);
                OleDbDataAdapter daInnder = new OleDbDataAdapter(cmdInner);
                DataSet ds = new DataSet();
                daInnder.Fill(ds);
                DataGrid.dsColumns = ds;
                btnClose_Click(sender, e);
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Error Inserting
        void insError(string strError)
        {
            DataSet dsRequirements = new DataSet();
            if (System.IO.File.Exists(@".\CompleteDataBaseErrors.xml"))
            {
                dsRequirements.ReadXml(@".\CompleteDataBaseErrors.xml");
                DataRow drError = dsRequirements.Tables[0].NewRow();
                drError["ErrorMessage"] = strError;
                if (DateTime.Now.Year == 2006)
                    drError["DateTime"] = System.DateTime.Now.ToString();
                else
                    drError["DateTime"] = "0";
                dsRequirements.Tables[0].Rows.Add(drError);
                System.IO.File.Delete(@".\CompleteDataBaseErrors.xml");
                dsRequirements.WriteXml(@".\CompleteDataBaseErrors.xml");
            }
            MessageBox.Show("Make Sure That You Have Not Lost Your Connection From Database, Or Try Again.");
        }
        #endregion
    }
}