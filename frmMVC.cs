using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace CompleteDataBaseAccess
{
    public partial class frmMVC : Form
    {
        OleDbConnection conCC;
        public frmMVC(OleDbConnection Con)
        {
            conCC = Con;
            InitializeComponent();
        }

        ArrayList arrlstTables;
        private void btnFields_Click(object sender, EventArgs e)
        {
            try
            {
                arrlstTables = new ArrayList();
                OleDbCommand objOleDbCommand = new OleDbCommand("sp_tables", conCC);
                OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                DataTable dtTables = new DataTable();
                daTables.Fill(dtTables);
                foreach (DataRow dr in dtTables.Rows)
                {
                    //check for table and non system table.
                    if (dr[3].ToString().IndexOf("TABLE") != -1 || dr[3].ToString().IndexOf("SYSTEM VIEW") != -1)
                    {
                        //excluding the dtproperties table.
                        if (dr[2].ToString() != "dtproperties" && dr[3].ToString().IndexOf("SYS") == -1 && dr[2].ToString().StartsWith(System.Configuration.ConfigurationSettings.AppSettings["strTableInitial"]))
                        {
                            //adding a tablename into arraylist containing the table name(s).
                            arrlstTables.Add(dr[2].ToString());
                        }
                    }
                }
                frmChooseTables o = new frmChooseTables(arrlstTables);
                o.ShowDialog();
                string strOutput = "";
                foreach (string strTable in arrlstTables)
                {
                    OleDbCommand oOleDbCommandDataFromActiveTable = new OleDbCommand("select * from " + strTable, conCC);
                    OleDbDataAdapter da = new OleDbDataAdapter(oOleDbCommandDataFromActiveTable);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    strOutput += "#region " + strTable.Replace("tbl", "");
                    foreach (DataColumn objDataColumn in dt.Columns)
                    {
                        strOutput += "\r\npublic const string " + strTable.Replace("tbl", "") + "_" + objDataColumn.ColumnName.Replace(' ', '_') + " = " + Convert.ToChar(34) + objDataColumn.ColumnName + Convert.ToChar(34) + ";";
                    }
                    strOutput += "\r\n#endregion \r\n\r\n";
                }
                Clipboard.SetDataObject(strOutput);
                MessageBox.Show("Copied to clipboard.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            try
            {
                arrlstTables = new ArrayList();
                OleDbCommand objOleDbCommand = new OleDbCommand("SELECT * FROM sys.objects where type='p'", conCC);
                OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                DataTable dtTables = new DataTable();
                daTables.Fill(dtTables);
                foreach (DataRow dr in dtTables.Rows)
                {
                    arrlstTables.Add(dr[0].ToString());
                }
                frmChooseTables o = new frmChooseTables(arrlstTables);
                o.ShowDialog();
                string strOutput = "";
                foreach (string strTable in arrlstTables)
                {
                    strOutput += "\r\npublic const string " + strTable.Replace("usp", "sp") + " = " + Convert.ToChar(34) + strTable + Convert.ToChar(34) + ";";
                }
                Clipboard.SetDataObject(strOutput);
                MessageBox.Show("Copied to clipboard.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            try
            {
                arrlstTables = new ArrayList();
                OleDbCommand objOleDbCommand = new OleDbCommand("SELECT * FROM sys.objects where type='p'", conCC);
                OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                DataTable dtTables = new DataTable();
                daTables.Fill(dtTables);
                foreach (DataRow dr in dtTables.Rows)
                {
                    arrlstTables.Add(dr[0].ToString());
                }
                frmChooseTables o = new frmChooseTables(arrlstTables);
                o.ShowDialog();
                string strFinal = "";
                foreach (string strTable in arrlstTables)
                {
                    string strOutput = "";
                    OleDbCommand newSqlCommand = new OleDbCommand("SP_HELP " + strTable, conCC);
                    OleDbDataAdapter daParameter = new OleDbDataAdapter(newSqlCommand);
                    DataSet dsParameter = new DataSet();
                    daParameter.Fill(dsParameter);
                    string strFunctionName = "";
                    if (strTable.ToUpper().Contains("INSERT"))
                        strFunctionName = "\r\npublic string " + strTable.Replace("usp", "").Replace("tbl", "") + "(";
                    else
                        strFunctionName = "\r\npublic DataTable " + strTable.Replace("usp", "").Replace("tbl", "") + "(";
                    strOutput += "Hashtable htParams = new Hashtable();";
                    if (dsParameter.Tables.Count > 1)
                    {
                        string strDataType = "";
                        foreach (DataRow dr in dsParameter.Tables[1].Rows)
                        {
                            if (dr[1].ToString() == "char")
                                strDataType = "string";
                            else if (dr[1].ToString() == "bigint")
                                strDataType = "long";
                            else if (dr[1].ToString() == "varchar")
                                strDataType = "string";
                            else if (dr[1].ToString() == "bit")
                                strDataType = "bool";
                            else if (dr[1].ToString() == "float")
                                strDataType = "decimal";
                            else if (dr[1].ToString() == "tiniint")
                                strDataType = "Int16";
                            else if (dr[1].ToString() == "datetime")
                                strDataType = "DateTime";
                            else if (dr[1].ToString() == "int")
                                strDataType = "int";
                            else if (dr[1].ToString() == "numeric")
                                strDataType = "decimal";
                            else
                                strDataType = "string";
                            strFunctionName += strDataType + " " + dr[0].ToString().Remove(0, 1)+",";
                            strOutput += "\r\n " + @"// adding parameter with name " + dr[0].ToString() + " to the procedure.";
                            strOutput += "\r\n htParams.Add(" + Convert.ToChar(34) + dr[0].ToString().Remove(0, 1) + Convert.ToChar(34) + ", " + dr[0].ToString().Remove(0, 1) + ");";
                        }
                    }
                    strFinal += strFunctionName.Substring(0, strFunctionName.Length - 1) + ")\r\n{";
                    strFinal += "\r\n" + strOutput;

                    if (strTable.ToUpper().Contains("INSERT"))
                    {
                        strFinal += "\r\n " + @"// return primary key after executing the stored procedure.";
                        strFinal += "\r\n" + "return DALRep.SaveAndReturnPrimary(clsConstants." + strTable.Replace("usp", "sp") + ", htParams);\r\n}";
                    }
                    else
                    {
                        strFinal += "\r\n " + @"// return datatable after executing the stored procedure.";
                        strFinal += "\r\n" + "return DALRep.GetDataTable(clsConstants." + strTable.Replace("usp", "sp") + ", htParams);\r\n}";
                    }
                }
                Clipboard.SetDataObject(strFinal);

                MessageBox.Show("Copied to clipboard.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
