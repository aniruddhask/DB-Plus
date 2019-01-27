using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.IO;

namespace CompleteDataBaseAccess
{
    public partial class frmWebFormDesign : Form
    {
        ArrayList arrlstParameters = new ArrayList();
        ArrayList arrlstTables = new ArrayList();
        DataTable dtReferencesForCurrentTable = new DataTable();
        OleDbConnection conCC;

        public frmWebFormDesign(ArrayList arrlstConnectionString)
        {
            InitializeComponent();
            arrlstParameters = arrlstConnectionString;
            if (arrlstParameters.Count != 5)
                conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString());
            else
                conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
        }

        private void frmWebFormDesign_Load(object sender, EventArgs e)
        {
            try
            {
                BindTables();
                GetAllReference();
                dtReferencesForCurrentTable.Columns.Add("TableName", typeof(string));
                dtReferencesForCurrentTable.Columns.Add("ColumnName", typeof(string));
                dtReferencesForCurrentTable.Columns.Add("DataValueField", typeof(string));
                dtReferencesForCurrentTable.Columns.Add("DataTextField", typeof(string));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BindTables()
        {
            try
            {
                OleDbCommand oOleDbCommand = new OleDbCommand("sp_tables", conCC);
                if (conCC.State == ConnectionState.Closed)
                    conCC.Open();
                //initializing a data adapter for getting tables from the database.
                OleDbDataAdapter daTables = new OleDbDataAdapter(oOleDbCommand);
                DataTable dtTables = new DataTable();
                //re-initialize the arraylist contains table names of the selected database.
                arrlstTables = new ArrayList();
                //filling the global datatable of tables.
                daTables.Fill(dtTables);
                foreach (DataRow dr in dtTables.Rows)
                {
                    //check for table and non system table.
                    if (dr[3].ToString().IndexOf("TABLE") != -1 || dr[3].ToString().IndexOf("SYSTEM VIEW") != -1)
                    {
                        //excluding the dtproperties table.
                        if (dr[2].ToString() != "dtproperties" && dr[3].ToString().IndexOf("SYS") == -1 && dr[2].ToString().StartsWith(System.Configuration.ConfigurationSettings.AppSettings["strTableInitial"]))
                        {
                            //adding a tablename into combo of table.
                            cmbTables.Items.Add(dr[2].ToString());
                            //adding a tablename into arraylist containing the table name(s).
                            arrlstTables.Add(dr[2].ToString());
                        }
                    }
                }
                //closing the connection.
                conCC.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string strCurrentTableName = "";
                dtReferencesForCurrentTable.Clear();
                strCurrentTableName = cmbTables.Text;
                GetRefColumns(strCurrentTableName);
                BindAllColumnsForGrid();
                btnControlCS.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BindAllColumnsForGrid()
        {
            try
            {
                cmbDateKeyField.Items.Clear();
                chklstGridColumns.Items.Clear();
                foreach (DataRow dr in dtReferencesForCurrentTable.Rows)
                {
                    OleDbCommand oOleDbCommand = new OleDbCommand("SELECT * FROM " + dr[0].ToString() + " WHERE 1 = 2", conCC);
                    OleDbDataAdapter da = new OleDbDataAdapter(oOleDbCommand);
                    DataTable dtCurrentTable = new DataTable();
                    da.Fill(dtCurrentTable);
                    foreach (DataColumn dc in dtCurrentTable.Columns)
                    {
                        if (dr[0].ToString() == cmbTables.Text)
                            cmbDateKeyField.Items.Add(dc.ColumnName);
                        chklstGridColumns.Items.Add(dr[0].ToString() + "-" + dc.ColumnName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Business Data
        private void GenerateBusinessData(string TableName)
        {
            try
            {
                OleDbCommand oOleDbCommand = new OleDbCommand("SELECT * FROM " + TableName + " WHERE 1 = 2", conCC);
                OleDbDataAdapter da = new OleDbDataAdapter(oOleDbCommand);
                DataTable dtCurrentTable = new DataTable();
                da.Fill(dtCurrentTable);
                //initializing the stream to creating a .cs file in C:\CompleteDataBaseAccess\  .
                System.IO.Stream objStream = new FileStream(@"C:\CompleteDataBaseAccess\clsBD" + TableName.Replace("tbl", "") + ".cs", System.IO.FileMode.OpenOrCreate);
                //initializing stream writer for writing the whole code in property class.
                System.IO.StreamWriter objStreamWriter = new StreamWriter(objStream);
                //writing code for generating Property Class.
                objStreamWriter.WriteLine("using System;");
                objStreamWriter.WriteLine("using System.Collections;");
                objStreamWriter.WriteLine("using System.Collections.Generic;");
                objStreamWriter.WriteLine("namespace CMAS.BusinessData");
                objStreamWriter.WriteLine("{");
                objStreamWriter.WriteLine("	/// <summary>");
                objStreamWriter.WriteLine("	/// Summary Description for clsBD" + TableName.Replace("tbl", ""));
                objStreamWriter.WriteLine("	/// </summary>");
                objStreamWriter.WriteLine("	public class clsBD" + TableName.Replace("tbl", ""));
                objStreamWriter.WriteLine("	{");
                objStreamWriter.WriteLine("		public clsBD" + TableName.Replace("tbl", "") + "()");
                objStreamWriter.WriteLine("		{}");
                foreach (DataColumn objDataColumn in dtCurrentTable.Columns)
                {
                    string varPri = "";
                    if (objDataColumn.DataType.ToString() == "System.String")
                        varPri = "str";
                    else if (objDataColumn.DataType.ToString() == "System.Int64")
                        varPri = "l";
                    else if (objDataColumn.DataType.ToString() == "System.Int32")
                        varPri = "i";
                    else if (objDataColumn.DataType.ToString() == "System.Boolean")
                        varPri = "bl";
                    else if (objDataColumn.DataType.ToString() == "System.DateTime")
                        varPri = "dTime";
                    objStreamWriter.WriteLine("\r\n		private " + objDataColumn.DataType.ToString() + " _" + varPri + objDataColumn.ColumnName + ";");
                    objStreamWriter.WriteLine("		/// <summary>");
                    objStreamWriter.WriteLine("		/// This is Properties For " + objDataColumn.ColumnName + ";");
                    objStreamWriter.WriteLine("		/// </summary>");
                    objStreamWriter.WriteLine("		public " + objDataColumn.DataType.ToString() + " " + objDataColumn.ColumnName);
                    objStreamWriter.WriteLine("		{");
                    objStreamWriter.WriteLine("			set");
                    objStreamWriter.WriteLine("			{");
                    objStreamWriter.WriteLine("				_" + varPri + objDataColumn.ColumnName + " = value;");
                    objStreamWriter.WriteLine("			}");
                    objStreamWriter.WriteLine("			get");
                    objStreamWriter.WriteLine("			{");
                    objStreamWriter.WriteLine("				return _" + varPri + objDataColumn.ColumnName + ";");
                    objStreamWriter.WriteLine("			}");
                    objStreamWriter.WriteLine("		}");
                }
                int iCounter = 1;
                foreach (DataRow drRef in dtReferencesForCurrentTable.Rows)
                {
                    if (iCounter != 1 && ((CheckBox)(panel1.Controls["chk" + iCounter.ToString()])).Checked)
                        if (((ComboBox)(panel1.Controls["cmbText" + iCounter.ToString()])).Text.Trim() == "")
                        {
                            objStreamWriter.WriteLine("\r\n		private clsBD" + drRef[0].ToString().Replace("tbl", "") + " _o" + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "") + " = new clsBD" + drRef[0].ToString().Replace("tbl", "") + "();");
                            objStreamWriter.WriteLine("		/// <summary>");
                            objStreamWriter.WriteLine("		/// This is Properties For clsBD" + drRef[0].ToString().Replace("tbl", "") + ";");
                            objStreamWriter.WriteLine("		/// </summary>");
                            objStreamWriter.WriteLine("		public clsBD" + drRef[0].ToString().Replace("tbl", "") + " " + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", ""));
                            objStreamWriter.WriteLine("		{");
                            objStreamWriter.WriteLine("			set");
                            objStreamWriter.WriteLine("			{");
                            objStreamWriter.WriteLine("				_o" + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "") + " = value;");
                            objStreamWriter.WriteLine("			}");
                            objStreamWriter.WriteLine("			get");
                            objStreamWriter.WriteLine("			{");
                            objStreamWriter.WriteLine("				return _o" + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "") + ";");
                            objStreamWriter.WriteLine("			}");
                            objStreamWriter.WriteLine("		}");
                        }
                        else
                        {
                            objStreamWriter.WriteLine("\r\n		private List<clsBD" + drRef[0].ToString().Replace("tbl", "") + "> _o" + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "") + " = new List<clsBD" + drRef[0].ToString().Replace("tbl", "") + ">();");
                            objStreamWriter.WriteLine("		/// <summary>");
                            objStreamWriter.WriteLine("		/// This is Properties For clsBD" + drRef[0].ToString().Replace("tbl", "") + ";");
                            objStreamWriter.WriteLine("		/// </summary>");
                            objStreamWriter.WriteLine("		public List<clsBD" + drRef[0].ToString().Replace("tbl", "") + "> " + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", ""));
                            objStreamWriter.WriteLine("		{");
                            objStreamWriter.WriteLine("			set");
                            objStreamWriter.WriteLine("			{");
                            objStreamWriter.WriteLine("				_o" + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "") + " = value;");
                            objStreamWriter.WriteLine("			}");
                            objStreamWriter.WriteLine("			get");
                            objStreamWriter.WriteLine("			{");
                            objStreamWriter.WriteLine("				return _o" + drRef[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "") + ";");
                            objStreamWriter.WriteLine("			}");
                            objStreamWriter.WriteLine("		}");
                        }
                    iCounter++;
                }
                objStreamWriter.WriteLine("	}//Class Close");
                objStreamWriter.WriteLine("}//NameSpace Close");
                objStreamWriter.Close();
                cmbTables.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region HTML Code
        DataTable dtReferences;
        /// <summary>
        /// 
        /// </summary>
        void GetAllReference()
        {
            try
            {
                dtReferences = new DataTable();
                string strCommand = "SELECT 	OBJECT_NAME(F.parent_object_id) AS TableName, COL_NAME(FC.parent_object_id, FC.parent_column_id) AS ColumnName, OBJECT_NAME (F.referenced_object_id) AS ReferenceTableName, ";
                strCommand += "		COL_NAME(FC.referenced_object_id, FC.referenced_column_id) AS ReferenceColumnName, F.Name AS ForeignKey ";
                strCommand += "FROM 	sys.foreign_keys AS F ";
                strCommand += "		INNER JOIN sys.foreign_key_columns AS FC ON (F.OBJECT_ID = FC.constraint_object_id) ";
                strCommand += "ORDER BY ReferenceColumnName";
                OleDbDataAdapter daTableColumn = new OleDbDataAdapter(strCommand, conCC);
                daTableColumn.Fill(dtReferences);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName">String</param>
        private void GetRefColumns(String TableName)
        {
            try
            {
                OleDbDataAdapter daTableColumn = new OleDbDataAdapter("SELECT * FROM " + TableName, conCC);
                DataTable dtTableData = new DataTable();
                daTableColumn.Fill(dtTableData);
                int iColumnCounter = 0;
                string strTableName = TableName;
                string strColumnName = "";
                foreach (DataColumn dcColumn in dtTableData.Columns)
                {
                    if (iColumnCounter == 0)
                    {
                        DataRow drNewReference = dtReferencesForCurrentTable.NewRow();
                        drNewReference[0] = TableName;
                        drNewReference[1] = dcColumn.ColumnName;
                        drNewReference[2] = dcColumn.ColumnName;
                        drNewReference[3] = "Name";
                        dtReferencesForCurrentTable.Rows.Add(drNewReference);
                    }
                    else
                    {
                        if (dcColumn.DataType.Name == "Int64" && dcColumn.ColumnName != "UserTransactionId")
                        {
                            foreach (DataRow dr in dtReferences.Rows)
                            {
                                if (dr["TableName"].ToString() == TableName && dr["ColumnName"].ToString() == dcColumn.ColumnName)
                                {
                                    strTableName = dr["ReferenceTableName"].ToString();
                                    strColumnName = dr["ReferenceColumnName"].ToString();
                                    DataRow drNewReference = dtReferencesForCurrentTable.NewRow();
                                    drNewReference[0] = strTableName;
                                    drNewReference[1] = dr["ReferenceColumnName"].ToString();
                                    drNewReference[2] = dr["ReferenceColumnName"].ToString();
                                    drNewReference[3] = "Name";
                                    bool IsAleadyAdded = false;
                                    foreach (DataRow drCheck in dtReferencesForCurrentTable.Rows)
                                    {
                                        if (drCheck[0].ToString() == strTableName && dr[1].ToString() == dr["ReferenceColumnName"].ToString())
                                            IsAleadyAdded = true;
                                    }
                                    if (!IsAleadyAdded)
                                        dtReferencesForCurrentTable.Rows.Add(drNewReference);
                                    GetRefObjects(strTableName);
                                    break;
                                }
                            }
                        }
                        else
                        {
                        }
                    }
                    iColumnCounter++;
                }
                string strCompleteBinding = "";
                int iRowCountet = 0;
                int iControlHeight = 25;

                panel1.Controls.Clear();
                foreach (DataRow dr in dtReferencesForCurrentTable.Rows)
                {
                    iRowCountet++;
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + dr[0].ToString(), conCC);
                    DataTable dtTableColumn = new DataTable();
                    da.Fill(dtTableColumn);
                    CheckBox chk = new CheckBox();
                    chk.Name = "chk" + iRowCountet.ToString();
                    chk.Top = iControlHeight * iRowCountet;
                    chk.Text = dr[0].ToString().Replace("tbl", "").Replace("CM", "").Replace("UM", "").Replace("SM", "").Replace("LM", "").Replace("MM", "");
                    chk.Left = 5;
                    chk.Width = 150;

                    ComboBox cmbText = new ComboBox();
                    cmbText.Name = "cmbText" + iRowCountet.ToString();
                    cmbText.Width = 200;
                    cmbText.Left = 180;
                    cmbText.Top = iControlHeight * iRowCountet;
                    ComboBox cmbValue = new ComboBox();
                    cmbValue.Name = "cmbValue" + iRowCountet.ToString();
                    cmbValue.Width = 200;
                    cmbValue.Left = 390;
                    cmbValue.Top = iControlHeight * iRowCountet;
                    foreach (DataColumn dc in dtTableColumn.Columns)
                    {
                        cmbText.Items.Add(dc.ColumnName);
                        cmbValue.Items.Add(dc.ColumnName);
                    }

                    ComboBox c1 = new ComboBox();
                    foreach (DataRow dr111 in dtReferencesForCurrentTable.Rows)
                    {
                        c1.Items.Add(dr111[0].ToString());
                    }
                    c1.Name = "cmbDepend" + iRowCountet.ToString();
                    c1.Text = dr[0].ToString();
                    c1.Left = 600;
                    c1.Top = iControlHeight * iRowCountet;
                    c1.Width = 300;

                    panel1.Controls.Add(chk);
                    panel1.Controls.Add(cmbText);
                    panel1.Controls.Add(cmbValue);
                    panel1.Controls.Add(c1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        private void GetRefObjects(String TableName)
        {
            try
            {
                OleDbDataAdapter daTableColumn = new OleDbDataAdapter("SELECT * FROM " + TableName, conCC);
                DataTable dtTableData = new DataTable();
                daTableColumn.Fill(dtTableData);
                int iColumnCounter = 0;
                string strTableName = TableName;
                foreach (DataColumn dcColumn in dtTableData.Columns)
                {
                    if (iColumnCounter != 0 && dcColumn.DataType.Name == "Int64" && dcColumn.ColumnName != "UserTransactionId")
                    {
                        foreach (DataRow dr in dtReferences.Rows)
                        {
                            if (dr["TableName"].ToString() == TableName && dr["ColumnName"].ToString() == dcColumn.ColumnName)
                            {
                                strTableName = dr["ReferenceTableName"].ToString();
                                DataRow drNewReference = dtReferencesForCurrentTable.NewRow();
                                drNewReference[0] = strTableName;
                                drNewReference[1] = dr["ReferenceColumnName"].ToString();
                                drNewReference[2] = dr["ReferenceColumnName"].ToString();
                                drNewReference[3] = "Name";
                                bool IsAleadyAdded = false;
                                foreach (DataRow drCheck in dtReferencesForCurrentTable.Rows)
                                {
                                    if (drCheck[0].ToString() == strTableName && dr[1].ToString() == dr["ReferenceColumnName"].ToString())
                                        IsAleadyAdded = true;
                                }
                                if (!IsAleadyAdded)
                                    dtReferencesForCurrentTable.Rows.Add(drNewReference);
                                //dtReferencesForCurrentTable.ImportRow(drNewReference);
                                GetRefObjects(strTableName);
                                break;
                            }
                        }
                    }
                    iColumnCounter++;
                }
            }
            catch (Exception ex)
            {

            }
        }


        ArrayList arr = new ArrayList();
        private void btnCreateControl_Click(object sender, EventArgs e)
        {
            try
            {
                arr = new ArrayList();
                foreach (int iSelectedIndex in chklstGridColumns.CheckedIndices)
                {
                    clsTable oTable = new clsTable();
                    oTable.DisplayColumn = chklstGridColumns.Items[iSelectedIndex].ToString().Substring(chklstGridColumns.Items[iSelectedIndex].ToString().IndexOf('-') + 1);
                    oTable.Name = chklstGridColumns.Items[iSelectedIndex].ToString().Substring(0, chklstGridColumns.Items[iSelectedIndex].ToString().IndexOf('-'));
                    arr.Add(oTable);
                }
                string strControls = "";
                CheckBox c = new CheckBox();
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl.GetType() == c.GetType())
                    {
                        if (((CheckBox)(ctrl)).Checked)
                        {
                            int iCounter = Convert.ToInt32(((CheckBox)(ctrl)).Name.Replace("chk", ""));
                            strControls += "Text: " + ((ComboBox)(panel1.Controls["cmbText" + iCounter.ToString()])).Text + ", Value: ";
                            strControls += ((ComboBox)(panel1.Controls["cmbValue" + iCounter.ToString()])).Text + ", Depends On: ";
                            strControls += ((ComboBox)(panel1.Controls["cmbDepend" + iCounter.ToString()])).Text + "\r\n";
                        }
                    }
                }
                //MessageBox.Show(strControls);
                System.IO.StreamWriter oSW = new System.IO.StreamWriter(@"C:\CompleteDataBaseAccess\ctrl" + cmbTables.Text.Replace("tbl", "") + ".ascx", true);
                string str = "";
                str = GenerateCodeHTML();
                oSW.Write(str);
                oSW.Close();
                MessageBox.Show(strControls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private string GenerateCodeHTML()
        {
            try
            {
                // Convert.ToChar(34)
                string strTableName = cmbTables.Text;
                string strHTML = "";
                strHTML += "<%@ Control Language=" + Convert.ToChar(34) + "C#" + Convert.ToChar(34) + " AutoEventWireup=" + Convert.ToChar(34) + "true" + Convert.ToChar(34) + " CodeFile=" + Convert.ToChar(34) + "ctrl" + strTableName.Replace("tbl", "") + ".ascx.cs" + Convert.ToChar(34) + " Inherits=" + Convert.ToChar(34) + "ctrl" + strTableName.Replace("tbl", "") + Convert.ToChar(34) + " %>\r\n";
                strHTML += "<table cellpadding=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + " cellspacing=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + ">\r\n";
                strHTML += "    <tr class=" + Convert.ToChar(34) + "HeaderRow" + Convert.ToChar(34) + ">\r\n";
                strHTML += "        <td colspan=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + ">\r\n";
                strHTML += "            Manage " + strTableName + "\r\n";
                strHTML += "        </td>\r\n";
                strHTML += "    </tr>\r\n";
                strHTML += "    <tr class=" + Convert.ToChar(34) + "MandatoryRow" + Convert.ToChar(34) + ">\r\n";
                strHTML += "        <td colspan=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + ">\r\n";
                strHTML += "            (<span class=" + Convert.ToChar(34) + "required" + Convert.ToChar(34) + ">*</span>) - Mandatory Fields.\r\n";
                strHTML += "        </td>\r\n";
                strHTML += "    </tr>\r\n";

                //code for all reference table
                string strRefTable = "";
                string strRefColumn = "";
                string strRefDepends = "";
                int iCounter = 0;
                foreach (DataRow drRef in dtReferencesForCurrentTable.Rows)
                {
                    iCounter++;
                    // checking for table need to be include.
                    if (iCounter != 1 && ((CheckBox)(panel1.Controls["chk" + iCounter.ToString()])).Checked)
                    {
                        strRefTable = ((CheckBox)(panel1.Controls["chk" + iCounter.ToString()])).Text.Replace("chk", "").Replace("tbl", "").Replace("tbl", "").Replace("MM", "").Replace("LM", "").Replace("SM", "").Replace("UM", "");
                        strRefColumn = ((ComboBox)(panel1.Controls["cmbText" + iCounter.ToString()])).Text.Replace("chk", "");
                        strRefDepends = ((ComboBox)(panel1.Controls["cmbDepend" + iCounter.ToString()])).Text.Replace("chk", "");

                        strHTML += "    <tr>\r\n";
                        strHTML += "        <td class=" + Convert.ToChar(34) + "TextColumn" + Convert.ToChar(34) + ">\r\n";
                        strHTML += "            Select " + strRefTable + " <span class=" + Convert.ToChar(34) + "required" + Convert.ToChar(34) + ">*</span>\r\n";
                        strHTML += "        </td>\r\n";
                        strHTML += "        <td class=" + Convert.ToChar(34) + "ControlColumn" + Convert.ToChar(34) + ">\r\n";
                        strHTML += "            <asp:DropDownList ID=" + Convert.ToChar(34) + "ddl" + strRefTable + "" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "DropDownList" + Convert.ToChar(34) + " AutoPostBack=" + Convert.ToChar(34) + "True" + Convert.ToChar(34) + "\r\n";
                        strHTML += "                OnSelectedIndexChanged=" + Convert.ToChar(34) + "ddl" + strRefTable + "_SelectedIndexChanged" + Convert.ToChar(34) + ">\r\n";
                        strHTML += "                <asp:ListItem>-Select " + strRefTable + "-</asp:ListItem>\r\n";
                        strHTML += "            </asp:DropDownList>\r\n";
                        strHTML += "            <asp:RequiredFieldValidator ID=" + Convert.ToChar(34) + "rfv" + strRefTable + "" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " ErrorMessage=" + Convert.ToChar(34) + "*" + Convert.ToChar(34) + " ControlToValidate=" + Convert.ToChar(34) + "ddl" + strRefTable + "" + Convert.ToChar(34) + "></asp:RequiredFieldValidator>\r\n";
                        strHTML += "        </td>\r\n";
                        strHTML += "    </tr>\r\n";
                    }
                }

                OleDbCommand oOleDbCommand = new OleDbCommand("SELECT * FROM " + strTableName + " WHERE 1 = 2", conCC);
                OleDbDataAdapter da = new OleDbDataAdapter(oOleDbCommand);
                DataTable dtCurrentTable = new DataTable();
                da.Fill(dtCurrentTable);
                int iColumnCounter = 0;
                foreach (DataColumn objDataColumn in dtCurrentTable.Columns)
                {
                    if (objDataColumn.ColumnName != "UserTransactionId" && objDataColumn.ColumnName != "CreatedDateTime" && objDataColumn.ColumnName != "Status" && iColumnCounter > 0 && objDataColumn.DataType.ToString() != "System.Int64")
                    {
                        string varPri = "";
                        string strControlName = "";
                        string strControlOpenTag = "";
                        string strControlClosingTag = "";
                        string strControlClass = "";
                        if (objDataColumn.DataType.ToString() == "System.String" || objDataColumn.DataType.ToString() == "System.Int64" || objDataColumn.DataType.ToString() == "System.Int32")
                        {
                            varPri = "str";
                            strControlName = "txt" + objDataColumn.ColumnName;
                            strControlOpenTag = "<asp:TextBox ";
                            strControlClosingTag = "</asp:TextBox> ";
                            strControlClass = "TextBox";
                        }
                        else if (objDataColumn.DataType.ToString() == "System.Boolean")
                        {
                            strControlName = "chk" + objDataColumn.ColumnName;
                            strControlOpenTag = "<asp:CheckBox ";
                            strControlClosingTag = "</asp:CheckBox> ";
                            strControlClass = "CheckBox";
                        }
                        else if (objDataColumn.DataType.ToString() == "System.DateTime")
                        {
                            strControlName = "txt" + objDataColumn.ColumnName;
                            strControlOpenTag = "<asp:TextBox ";
                            strControlClosingTag = "</asp:TextBox> ";
                            strControlClass = "TextBox";
                        }
                        strHTML += "    <tr>\r\n";
                        strHTML += "        <td class=" + Convert.ToChar(34) + "TextColumn" + Convert.ToChar(34) + ">\r\n";
                        strHTML += "            " + objDataColumn.ColumnName + " <span class=" + Convert.ToChar(34) + "required" + Convert.ToChar(34) + ">*</span>\r\n";
                        strHTML += "        </td>\r\n";
                        strHTML += "        <td class=" + Convert.ToChar(34) + "ControlColumn" + Convert.ToChar(34) + ">\r\n";
                        strHTML += "            " + strControlOpenTag + " ID=" + Convert.ToChar(34) + strControlName + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + strControlClass + Convert.ToChar(34) + ">" + strControlClosingTag + "\r\n";
                        strHTML += "            <asp:RequiredFieldValidator ID=" + Convert.ToChar(34) + "rfv" + strControlName + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " ErrorMessage=" + Convert.ToChar(34) + "*" + Convert.ToChar(34) + " ControlToValidate=" + Convert.ToChar(34) + strControlName + Convert.ToChar(34) + "></asp:RequiredFieldValidator>\r\n";
                        strHTML += "        </td>\r\n";
                        strHTML += "    </tr>\r\n";
                    }
                    iColumnCounter++;
                }
                strHTML += "    <tr>\r\n";
                strHTML += "        <td class=" + Convert.ToChar(34) + "TextColumn" + Convert.ToChar(34) + ">\r\n";
                strHTML += "            Status <span class=" + Convert.ToChar(34) + "required" + Convert.ToChar(34) + ">*</span>\r\n";
                strHTML += "        </td>\r\n";
                strHTML += "        <td class=" + Convert.ToChar(34) + "ControlColumn" + Convert.ToChar(34) + ">\r\n";
                strHTML += "            <asp:DropDownList ID=" + Convert.ToChar(34) + "ddlStatus" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "DropDownList" + Convert.ToChar(34) + ">\r\n";
                strHTML += "                <asp:ListItem Value=" + Convert.ToChar(34) + Convert.ToChar(34) + ">-Select Status-</asp:ListItem>\r\n";
                strHTML += "                <asp:ListItem Value=" + Convert.ToChar(34) + "1" + Convert.ToChar(34) + ">Active</asp:ListItem>\r\n";
                strHTML += "                <asp:ListItem Value=" + Convert.ToChar(34) + "0" + Convert.ToChar(34) + ">InActive</asp:ListItem>\r\n";
                strHTML += "            </asp:DropDownList>\r\n";
                strHTML += "            <asp:RequiredFieldValidator ID=" + Convert.ToChar(34) + "rfvStatus" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " ErrorMessage=" + Convert.ToChar(34) + "*" + Convert.ToChar(34) + " ControlToValidate=" + Convert.ToChar(34) + "ddlStatus" + Convert.ToChar(34) + "></asp:RequiredFieldValidator>\r\n";
                strHTML += "        </td>\r\n";
                strHTML += "    </tr>\r\n";
                strHTML += "    <tr>\r\n";
                strHTML += "        <td>\r\n";
                strHTML += "        </td>\r\n";
                strHTML += "        <td class=" + Convert.ToChar(34) + "ButtonColumn" + Convert.ToChar(34) + ">\r\n";
                strHTML += "            <asp:Button ID=" + Convert.ToChar(34) + "btnSave" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + "Save" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "Button" + Convert.ToChar(34) + " OnClick=" + Convert.ToChar(34) + "btnSave_Click" + Convert.ToChar(34) + "\r\n";
                strHTML += "                CausesValidation=" + Convert.ToChar(34) + "true" + Convert.ToChar(34) + " />\r\n";
                strHTML += "            <asp:Button ID=" + Convert.ToChar(34) + "btnCancel" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + "Cancel" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "Button" + Convert.ToChar(34) + " OnClick=" + Convert.ToChar(34) + "btnCancel_Click" + Convert.ToChar(34) + "\r\n";
                strHTML += "                CausesValidation=" + Convert.ToChar(34) + "false" + Convert.ToChar(34) + " />\r\n";
                strHTML += "            <asp:Button ID=" + Convert.ToChar(34) + "btnReset" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + "Reset" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "Button" + Convert.ToChar(34) + " OnClick=" + Convert.ToChar(34) + "btnReset_Click" + Convert.ToChar(34) + "\r\n";
                strHTML += "                CausesValidation=" + Convert.ToChar(34) + "false" + Convert.ToChar(34) + " /></td>\r\n";
                strHTML += "    </tr>\r\n";
                strHTML += "    <tr>\r\n";
                strHTML += "        <td colspan=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + " class=" + Convert.ToChar(34) + "GridColumn" + Convert.ToChar(34) + ">\r\n";
                strHTML += "            <asp:DataGrid ID=" + Convert.ToChar(34) + "dg" + strTableName.Replace("tbl", "") + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "DataGrid" + Convert.ToChar(34) + " AutoGenerateColumns=" + Convert.ToChar(34) + "False" + Convert.ToChar(34) + "\r\n";
                strHTML += "                DataKeyField=" + Convert.ToChar(34) + cmbDateKeyField.Text.Substring(cmbDateKeyField.Text.IndexOf('-')) + Convert.ToChar(34) + " AllowPaging=" + Convert.ToChar(34) + "True" + Convert.ToChar(34) + " OnDeleteCommand=" + Convert.ToChar(34) + "dg" + strTableName + "_DeleteCommand" + Convert.ToChar(34) + "\r\n";
                strHTML += "                OnPageIndexChanged=" + Convert.ToChar(34) + "dg" + strTableName.Replace("tbl", "") + "_PageIndexChanged" + Convert.ToChar(34) + " OnUpdateCommand=" + Convert.ToChar(34) + "dg" + strTableName.Replace("tbl", "") + "_UpdateCommand" + Convert.ToChar(34) + ">\r\n";
                strHTML += "                <Columns>\r\n";

                iColumnCounter = 0;
                foreach (DataColumn objDataColumn in dtCurrentTable.Columns)
                {
                    if (objDataColumn.ColumnName != "UserTransactionId" && objDataColumn.ColumnName != "CreatedDateTime" && objDataColumn.ColumnName != "Status" && iColumnCounter > 0)
                        strHTML += "                    <asp:BoundColumn DataField=" + Convert.ToChar(34) + objDataColumn.ColumnName + Convert.ToChar(34) + " HeaderText=" + Convert.ToChar(34) + objDataColumn.ColumnName + Convert.ToChar(34) + "></asp:BoundColumn>\r\n";
                    iColumnCounter++;
                }
                strHTML += "                    <asp:TemplateColumn HeaderText=" + Convert.ToChar(34) + "Edit" + Convert.ToChar(34) + " ItemStyle-Width=" + Convert.ToChar(34) + "50px" + Convert.ToChar(34) + ">\r\n";
                strHTML += "                        <ItemTemplate>\r\n";
                strHTML += "                            <asp:ImageButton ID=" + Convert.ToChar(34) + "imgEdit" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " ImageUrl=" + Convert.ToChar(34) + "../Images/icoEdit.png" + Convert.ToChar(34) + " CommandName=" + Convert.ToChar(34) + "Update" + Convert.ToChar(34) + "\r\n";
                strHTML += "                                CssClass=" + Convert.ToChar(34) + "ImageButton" + Convert.ToChar(34) + " CausesValidation=" + Convert.ToChar(34) + "false" + Convert.ToChar(34) + " />\r\n";
                strHTML += "                        </ItemTemplate>\r\n";
                strHTML += "                    </asp:TemplateColumn>\r\n";
                strHTML += "                    <asp:TemplateColumn HeaderText=" + Convert.ToChar(34) + "Delete" + Convert.ToChar(34) + " ItemStyle-Width=" + Convert.ToChar(34) + "50px" + Convert.ToChar(34) + ">\r\n";
                strHTML += "                        <ItemTemplate>\r\n";
                strHTML += "                            <asp:ImageButton ID=" + Convert.ToChar(34) + "imgDelete" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " ImageUrl=" + Convert.ToChar(34) + "~/Images/icoDelete.png" + Convert.ToChar(34) + "\r\n";
                strHTML += "                                CommandName=" + Convert.ToChar(34) + "Delete" + Convert.ToChar(34) + " CssClass=" + Convert.ToChar(34) + "ImageButton" + Convert.ToChar(34) + " CausesValidation=" + Convert.ToChar(34) + "false" + Convert.ToChar(34) + " OnClientClick=" + Convert.ToChar(34) + "return confirm('Are you sure?')" + Convert.ToChar(34) + " />\r\n";
                strHTML += "                        </ItemTemplate>\r\n";
                strHTML += "                    </asp:TemplateColumn>\r\n";
                strHTML += "                </Columns>\r\n";
                strHTML += "                <AlternatingItemStyle CssClass=" + Convert.ToChar(34) + "AlternatingRowStyle" + Convert.ToChar(34) + " />\r\n";
                strHTML += "                <FooterStyle CssClass=" + Convert.ToChar(34) + "FooterStyle" + Convert.ToChar(34) + " />\r\n";
                strHTML += "                <PagerStyle CssClass=" + Convert.ToChar(34) + "PagerStyle" + Convert.ToChar(34) + " NextPageText=" + Convert.ToChar(34) + "Next" + Convert.ToChar(34) + " Position=" + Convert.ToChar(34) + "TopAndBottom" + Convert.ToChar(34) + " PrevPageText=" + Convert.ToChar(34) + "Prev" + Convert.ToChar(34) + " />\r\n";
                strHTML += "                <ItemStyle CssClass=" + Convert.ToChar(34) + "RowStyle" + Convert.ToChar(34) + " />\r\n";
                strHTML += "                <HeaderStyle CssClass=" + Convert.ToChar(34) + "HeaderStyle" + Convert.ToChar(34) + " />\r\n";
                strHTML += "            </asp:DataGrid></td>\r\n";
                strHTML += "    </tr>\r\n";
                strHTML += "</table>\r\n";
                return strHTML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerateBD_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateBusinessData(cmbTables.Text);
                MessageBox.Show("Business Data for table: " + cmbTables.Text + " crated successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnControlCS_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTables.Text == "")
                {
                    MessageBox.Show("Please select DataKeyField");
                    cmbDateKeyField.Focus();
                    return;
                }
                else if (cmbDateKeyField.Text == "")
                {
                    MessageBox.Show("Please select DataKeyField");
                    cmbDateKeyField.Focus();
                    return;
                }
                else
                {
                    frmCS oCS = new frmCS(dtReferencesForCurrentTable);
                    oCS.TableName = cmbTables.Text;
                    oCS.IdentityColumn = cmbDateKeyField.Text;
                    oCS.CurrentConnection = conCC;
                    oCS.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnControlCS.Enabled = false;
        }
    }
    public class clsTable
    {
        private string _strName;
        private string _strValueColumn;
        private string _strDisplayColumn;

        public clsTable()
        { }

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public string DisplayColumn
        {
            get { return _strDisplayColumn; }
            set { _strDisplayColumn = value; }
        }

        public string ValueColumn
        {
            get { return _strValueColumn; }
            set { _strValueColumn = value; }
        }
    }
}