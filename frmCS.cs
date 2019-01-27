using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.IO;

namespace CompleteDataBaseAccess
{
    public partial class frmCS : Form
    {
        DataTable dtRef;
        private string _strTableName = "";
        private string _strIdentityColumn = "";

        public string IdentityColumn
        {
            get { return _strIdentityColumn; }
            set { _strIdentityColumn = value; }
        }
        private OleDbConnection _CurrentConnection = new OleDbConnection();

        public OleDbConnection CurrentConnection
        {
            get { return _CurrentConnection; }
            set { _CurrentConnection = value; }
        }
        public string TableName
        {
            get { return _strTableName; }
            set { _strTableName = value; }
        }

        public frmCS(DataTable RefTable)
        {
            InitializeComponent();
            dtRef = RefTable;
        }

        private void frmCS_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadPanel()
        {
            try
            {
                int iRowCounter = 0;
                int iControlHeight = 25;
                foreach (DataRow drTables in dtRef.Rows)
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + drTables[0].ToString(), CurrentConnection);
                    DataTable dtTableColumn = new DataTable();
                    da.Fill(dtTableColumn);
                    CheckBox chk = new CheckBox();
                    chk.Name = "chk" + iRowCounter.ToString();
                    chk.Top = iControlHeight * iRowCounter;
                    chk.Text = drTables[0].ToString().Replace("tbl", "");
                    chk.Left = 5;
                    chk.Width = 150;

                    ComboBox cmbText = new ComboBox();
                    cmbText.Name = "cmbText" + iRowCounter.ToString();
                    cmbText.Width = 200;
                    cmbText.Left = 180;
                    cmbText.Top = iControlHeight * iRowCounter;
                    cmbText.DropDownStyle = ComboBoxStyle.DropDownList;
                    ComboBox cmbValue = new ComboBox();
                    cmbValue.Name = "cmbValue" + iRowCounter.ToString();
                    cmbValue.Width = 200;
                    cmbValue.Left = 390;
                    cmbValue.Top = iControlHeight * iRowCounter;
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    foreach (DataColumn dc in dtTableColumn.Columns)
                    {
                        cmbText.Items.Add(dc.ColumnName);
                        cmbValue.Items.Add(dc.ColumnName);
                    }

                    ComboBox c1 = new ComboBox();
                    c1.Items.Add("");
                    foreach (DataRow dr111 in dtRef.Rows)
                    {
                        c1.Items.Add(dr111[0].ToString());
                    }
                    c1.Name = "cmbDepend" + iRowCounter.ToString();
                    c1.Text = drTables[0].ToString();
                    c1.Left = 600;
                    c1.Top = iControlHeight * iRowCounter;
                    c1.Width = 200;
                    c1.SelectedIndexChanged += new EventHandler(c1_SelectedIndexChanged);
                    c1.DropDownStyle = ComboBoxStyle.DropDownList;

                    ComboBox c1Column = new ComboBox();
                    c1Column.Name = "cmbDependColumn" + iRowCounter.ToString();
                    c1Column.Text = drTables[0].ToString();
                    c1Column.Left = 800;
                    c1Column.Top = iControlHeight * iRowCounter;
                    c1Column.Width = 100;
                    c1Column.DropDownStyle = ComboBoxStyle.DropDownList;

                    ComboBox cOrder = new ComboBox();
                    cOrder.Name = "cmbOrder" + iRowCounter.ToString();
                    for (int iNumber = 1; iNumber <= dtRef.Rows.Count; iNumber++)
                    {
                        cOrder.Items.Add(iNumber.ToString());
                    }
                    cOrder.Left = 900;
                    cOrder.Top = iControlHeight * iRowCounter;
                    cOrder.Text = iRowCounter.ToString();
                    cOrder.Width = 50;
                    cOrder.DropDownStyle = ComboBoxStyle.DropDownList;

                    panel1.Controls.Add(chk);
                    panel1.Controls.Add(cmbText);
                    panel1.Controls.Add(cmbValue);
                    panel1.Controls.Add(c1);
                    panel1.Controls.Add(c1Column);
                    panel1.Controls.Add(cOrder);
                    iRowCounter++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = ((ComboBox)(sender));
                string strRefTableName = cmb.Text;
                int iCurrentSelection = Convert.ToInt32(cmb.Name.Replace("cmbDepend", ""));
                ((ComboBox)(panel1.Controls["cmbDependColumn" + iCurrentSelection.ToString()])).Items.Clear();
                if (strRefTableName != "")
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + strRefTableName + " WHERE 1 = 2", CurrentConnection);
                    DataTable dtTableColumn = new DataTable();
                    da.Fill(dtTableColumn);
                    foreach (DataColumn dc in dtTableColumn.Columns)
                    {
                        ((ComboBox)(panel1.Controls["cmbDependColumn" + iCurrentSelection.ToString()])).Items.Add(dc.ColumnName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GenerateCSCode()
        {
            try
            {
                string strCS = "";
                OleDbCommand oOleDbCommand = new OleDbCommand("SELECT * FROM " + TableName + " WHERE 1 = 2", CurrentConnection);
                OleDbDataAdapter da = new OleDbDataAdapter(oOleDbCommand);
                DataTable dtCurrentTable = new DataTable();
                da.Fill(dtCurrentTable);

                #region Page Header Using & Class Lines
                strCS += "using System;\r\n";
                strCS += "using System.Data;\r\n";
                strCS += "using System.Configuration;\r\n";
                strCS += "using System.Collections;\r\n";
                strCS += "using System.Web;\r\n";
                strCS += "using System.Web.Security;\r\n";
                strCS += "using System.Web.UI;\r\n";
                strCS += "using System.Web.UI.WebControls;\r\n";
                strCS += "using System.Web.UI.WebControls.WebParts;\r\n";
                strCS += "using System.Web.UI.HtmlControls;\r\n";
                strCS += "using CMAS.BusinessData;\r\n";
                strCS += "using CMAS.BusinessObject;\r\n";
                strCS += "\r\n";
                strCS += "public partial class ctrl" + TableName.Replace("tbl", "") + " : System.Web.UI.UserControl\r\n";
                strCS += "{\r\n";
                #endregion

                #region Load References for HTML & CS

                List<clsTableRef> oTableRef = new List<clsTableRef>();
                for (int iCurrentOrderNumber = 1; iCurrentOrderNumber <= dtRef.Rows.Count; iCurrentOrderNumber++)
                {
                    int iCurrentRow = 0;
                    foreach (DataRow drCurrentRow in dtRef.Rows)
                    {
                        if (((ComboBox)(panel1.Controls["cmbOrder" + iCurrentRow.ToString()])).Text == iCurrentOrderNumber.ToString() && ((CheckBox)(panel1.Controls["chk" + iCurrentRow.ToString()])).Checked)
                        {
                            string strRefTable = ((CheckBox)(panel1.Controls["chk" + iCurrentRow.ToString()])).Text.Replace("chk", "").Replace("tbl", "");
                            string strRefDepends = ((ComboBox)(panel1.Controls["cmbDepend" + iCurrentRow.ToString()])).Text.Replace("tbl", "");
                            string strText = ((ComboBox)(panel1.Controls["cmbText" + iCurrentRow.ToString()])).Text;
                            string strValue = ((ComboBox)(panel1.Controls["cmbValue" + iCurrentRow.ToString()])).Text;
                            clsTableRef oTable = new clsTableRef();
                            oTable.DependsOf = strRefDepends.Replace("tbl", "");
                            oTable.DisplayText = strValue;
                            oTable.IsMainTable = false;
                            oTable.PrimaryColumn = strText;
                            oTable.TableName = strRefTable;
                            oTable.Order = iCurrentOrderNumber;
                            oTable.RefTablePrimaryColumn = ((ComboBox)(panel1.Controls["cmbDependColumn" + iCurrentRow.ToString()])).Text;
                            oTableRef.Add(oTable);
                        }
                        iCurrentRow++;
                    }
                }

                ArrayList arrlstRefColumns = new ArrayList();
                foreach (clsTableRef oTable in oTableRef)
                {
                    arrlstRefColumns.Add(oTable.RefTablePrimaryColumn);
                }

                #endregion

                #region Generation of Page Load
                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "sender" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">EventArgs</param>\r\n";
                strCS += "    protected void Page_Load(object sender, EventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // cecking for the page post back\r\n";
                strCS += "            if (!IsPostBack)\r\n";
                strCS += "            {\r\n";
                if (oTableRef.Count == 0)
                {
                    strCS += "              Bind" + TableName.Replace("tbl", "") + "();\r\n";
                }
                foreach (clsTableRef oTable in oTableRef)
                {
                    if (oTable.DependsOf == "")
                        strCS += "                Bind" + oTable.TableName.Replace("tbl", "") + "();\r\n";
                }
                strCS += "            }\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            // inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "PageLoad" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region Create PostBack for Referened Table
                foreach (clsTableRef oTable in oTableRef)
                {
                    if (oTable.DependsOf != "")
                    {
                        strCS += "    protected void ddl" + oTable.DependsOf + "_SelectedIndexChanged(object sender, EventArgs e)\r\n";
                        strCS += "    {\r\n";
                        strCS += "        try\r\n";
                        strCS += "        {\r\n";
                        strCS += "            // creating object of clsBD" + TableName.Replace("tbl", "") + "\r\n";
                        strCS += "            clsBD" + oTable.TableName + " oBD" + oTable.TableName + " = new clsBD" + oTable.TableName + "();\r\n";
                        strCS += "            // assigning value in " + oTable.RefTablePrimaryColumn + " with the current selection of " + oTable.DependsOf + "\r\n";
                        strCS += "            oBD" + oTable.TableName + "." + oTable.RefTablePrimaryColumn + " = Convert.ToInt64(ddl" + oTable.DependsOf + ".SelectedValue);\r\n";
                        strCS += "            // assigning value in " + IdentityColumn + " with 0\r\n";
                        strCS += "            oBD" + oTable.TableName + "." + oTable.PrimaryColumn + " = 0;\r\n";
                        strCS += "            // creating object of clsBO" + TableName.Replace("tbl", "") + "\r\n";
                        strCS += "            clsBO" + oTable.TableName + " oBO" + oTable.TableName + " = new clsBO" + oTable.TableName + "();\r\n";
                        strCS += "            // calling method to bind " + oTable.TableName + "\r\n";
                        strCS += "            Bind" + oTable.TableName + "();\r\n";
                        strCS += "        }\r\n";
                        strCS += "        catch (Exception ex)\r\n";
                        strCS += "        {\r\n";
                        strCS += "            //inserting error to the database\r\n";
                        strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "ddl" + oTable.DependsOf + "_SelectedIndexChanged" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                        strCS += "        }\r\n";
                        strCS += "    }\r\n";
                        strCS += "\r\n";
                    }
                }
                #endregion

                #region Bind All References

                foreach (clsTableRef oTable in oTableRef)// && oTable.Order != 0
                {
                    strCS += "    /// <summary>\r\n";
                    strCS += "    /// \r\n";
                    strCS += "    /// </summary>\r\n";
                    strCS += "    private void Bind" + oTable.TableName + "()\r\n";
                    strCS += "    {\r\n";
                    strCS += "        try\r\n";
                    strCS += "        {\r\n";
                    strCS += "            // creating object of clsBD" + oTable.TableName.Replace("tbl", "") + "\r\n";
                    strCS += "            clsBD" + oTable.TableName + " oBD" + oTable.TableName + " = new clsBD" + oTable.TableName + "();\r\n";
                    strCS += "            // assigning value in " + oTable.PrimaryColumn + "\r\n";
                    strCS += "            oBD" + oTable.TableName + "." + oTable.PrimaryColumn + " = 0;\r\n";
                    strCS += "            // creating object of clsBO" + oTable.TableName + "\r\n";
                    strCS += "            clsBO" + oTable.TableName + " oBO" + oTable.TableName + " = new clsBO" + oTable.TableName + "();\r\n";
                    strCS += "            // assigning data sourse to ddl" + oTable.TableName + "\r\n";
                    strCS += "            ddl" + oTable.TableName + ".DataSource = oBO" + oTable.TableName + ".gettbl" + oTable.TableName + "(oBD" + oTable.TableName + ");\r\n";
                    strCS += "            // setting " + oTable.DisplayText + " colum to DataTextField\r\n";
                    strCS += "            ddl" + oTable.TableName + ".DataTextField = " + Convert.ToChar(34) + oTable.DisplayText + Convert.ToChar(34) + ";\r\n";
                    strCS += "            // setting " + oTable.PrimaryColumn + " colum to DataValueField\r\n";
                    strCS += "            ddl" + oTable.TableName + ".DataValueField = " + Convert.ToChar(34) + oTable.PrimaryColumn + Convert.ToChar(34) + ";\r\n";
                    strCS += "            // binding data to ddl" + oTable.TableName + "\r\n";
                    strCS += "            ddl" + oTable.TableName + ".DataBind();\r\n";
                    strCS += "            // inserting a new item with select value in ddl" + oTable.TableName + " at 0th position\r\n";
                    strCS += "            ddl" + oTable.TableName + ".Items.Insert(0, new ListItem(" + Convert.ToChar(34) + "-Select " + oTable.TableName + "-" + Convert.ToChar(34) + ", " + Convert.ToChar(34) + "" + Convert.ToChar(34) + "));\r\n";
                    strCS += "        }\r\n";
                    strCS += "        catch (Exception ex)\r\n";
                    strCS += "        {\r\n";
                    strCS += "            // throwing exception\r\n";
                    strCS += "            throw ex;\r\n";
                    strCS += "        }\r\n";
                    strCS += "    }\r\n";
                    strCS += "\r\n";
                }
                #endregion

                #region Bind Page Main Table With Table Name
                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    private void Bind" + TableName.Replace("tbl", "") + "()\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // checking session of " + TableName.Replace("tbl", "") + " table for null\r\n";
                strCS += "            if (Session[" + Convert.ToChar(34) + "s" + TableName.Replace("tbl", "") + "" + Convert.ToChar(34) + "] == null)\r\n";
                strCS += "            {\r\n";
                strCS += "                // creating object of clsBD" + TableName.Replace("tbl", "") + "\r\n";
                strCS += "                clsBD" + TableName.Replace("tbl", "") + " oBD" + TableName.Replace("tbl", "") + " = new clsBD" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "                // assigning value in " + IdentityColumn + "\r\n";
                strCS += "                oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = 0;\r\n";
                strCS += "                // creating object of clsBO" + TableName.Replace("tbl", "") + "\r\n";
                strCS += "                clsBO" + TableName.Replace("tbl", "") + " oBO" + TableName.Replace("tbl", "") + " = new clsBO" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "                // assigning data in session of " + TableName.Replace("tbl", "") + "\r\n";
                strCS += "                Session[" + Convert.ToChar(34) + "s" + TableName.Replace("tbl", "") + Convert.ToChar(34) + "] = oBO" + TableName.Replace("tbl", "") + ".get" + TableName + "(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "            }\r\n";
                strCS += "            // assigning data to grid\r\n";
                strCS += "            dg" + TableName.Replace("tbl", "") + ".DataSource = (DataTable)Session[" + Convert.ToChar(34) + "s" + TableName.Replace("tbl", "") + Convert.ToChar(34) + "];\r\n";
                strCS += "            // binding data to grid\r\n";
                strCS += "            dg" + TableName.Replace("tbl", "") + ".DataBind();\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            // throwing exception\r\n";
                strCS += "            throw ex;\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region DataGrid Delete Command
                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "source" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">DataGridCommandEventArgs</param>\r\n";
                strCS += "    protected void dg" + TableName.Replace("tbl", "") + "_DeleteCommand(object source, DataGridCommandEventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // creating object of clsBD" + TableName.Replace("tbl", "") + "\r\n";
                strCS += "            clsBD" + TableName.Replace("tbl", "") + " oBD" + TableName.Replace("tbl", "") + " = new clsBD" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "            // assigning data to StateId\r\n";
                strCS += "            oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = Convert.ToInt64(dg" + TableName.Replace("tbl", "") + ".DataKeys[e.Item.ItemIndex]);\r\n";
                strCS += "            // creating object of clsBO" + TableName.Replace("tbl", "") + " \r\n";
                strCS += "            clsBO" + TableName.Replace("tbl", "") + " oBO" + TableName.Replace("tbl", "") + " = new clsBO" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "            // creating object of UnitOfWorkScope for perforing delete with transation\r\n";
                strCS += "            using (new UnitOfWorkScope(true))\r\n";
                strCS += "            {\r\n";
                strCS += "                // calling method of business object class to delete record\r\n";
                strCS += "                oBO" + TableName.Replace("tbl", "") + ".del" + TableName + "(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "            }\r\n";
                strCS += "            // assigning value in " + IdentityColumn + " with 0\r\n";
                strCS += "            oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = 0;\r\n";
                strCS += "            // assigning data in session of state\r\n";
                strCS += "            Session[" + Convert.ToChar(34) + "s" + TableName.Replace("tbl", "") + "" + Convert.ToChar(34) + "] = oBO" + TableName.Replace("tbl", "") + ".get" + TableName + "(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "            // checking for grid row item if 1 then decrease page index by 1\r\n";
                strCS += "            if (dg" + TableName.Replace("tbl", "") + ".Items.Count == 1 && dg" + TableName.Replace("tbl", "") + ".CurrentPageIndex != 1)\r\n";
                strCS += "                // decreasing current page index by 1\r\n";
                strCS += "                dg" + TableName.Replace("tbl", "") + ".CurrentPageIndex = dg" + TableName.Replace("tbl", "") + ".CurrentPageIndex - 1;\r\n";
                strCS += "            // binding data to grid\r\n";
                strCS += "            Bind" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            //inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "dg" + TableName.Replace("tbl", "") + "_DeleteCommand" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region DataGrid Update Command
                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "source" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">DataGridCommandEventArgs</param>\r\n";
                strCS += "    protected void dg" + TableName.Replace("tbl", "") + "_UpdateCommand(object source, DataGridCommandEventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // creating object of clsBD" + TableName.Replace("tbl", "") + " \r\n";
                strCS += "            clsBD" + TableName.Replace("tbl", "") + " oBD" + TableName.Replace("tbl", "") + " = new clsBD" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "            // assigning data to " + TableName.Replace("tbl", "") + "Id\r\n";
                strCS += "            oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = Convert.ToInt64(dg" + TableName.Replace("tbl", "") + ".DataKeys[e.Item.ItemIndex]);\r\n";
                strCS += "            // creating object of clsBO" + TableName.Replace("tbl", "") + " \r\n";
                strCS += "            clsBO" + TableName.Replace("tbl", "") + " oBO" + TableName.Replace("tbl", "") + " = new clsBO" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "            // calling method to get records based on primary id\r\n";
                strCS += "            oBO" + TableName.Replace("tbl", "") + ".get" + TableName + "ByPrimaryId(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "            // clearing selection of state drop down\r\n";
                strCS += "            ddlStatus.ClearSelection();\r\n";
                strCS += "            // createing list item for selected status\r\n";
                strCS += "            ListItem lstStatus = ddlStatus.Items.FindByValue(oBD" + TableName.Replace("tbl", "") + ".Status.ToString());\r\n";
                strCS += "            // checking for list item status with null\r\n";
                strCS += "            if (lstStatus != null)\r\n";
                strCS += "            {\r\n";
                strCS += "                // selecting selected value of status\r\n";
                strCS += "                lstStatus.Selected = true;\r\n";
                strCS += "            }\r\n";
                int iColumnCounter = 0;
                foreach (DataColumn dc in dtCurrentTable.Columns)
                {
                    if (!arrlstRefColumns.Contains(dc.ColumnName) && dc.ColumnName != "UserTransactionId" && dc.ColumnName != "CreatedDateTime" && dc.ColumnName != "CreateDateTime" && dc.ColumnName != "Status" && iColumnCounter > 0)
                    {
                        string strControlName = "";
                        if (dc.DataType.ToString() == "System.String" || dc.DataType.ToString() == "System.Int32" || dc.DataType.ToString() == "System.DateTime" || dc.DataType.ToString() == "System.Decimal")
                        {
                            strControlName = "txt" + dc.ColumnName;
                            strCS += "            // assigning value to " + strControlName + "\r\n";
                            strCS += "            " + strControlName + ".Text = oBD" + TableName.Replace("tbl", "") + "." + dc.ColumnName + ".ToString();\r\n";
                        }
                        else if (dc.DataType.ToString() == "System.Boolean")
                        {
                            strControlName = "chk" + dc.ColumnName;
                            strCS += "            // assigning value to " + strControlName + "\r\n";
                            strCS += "            " + strControlName + ".Checked = oBD" + TableName.Replace("tbl", "") + "." + dc.ColumnName + ".ToString();\r\n";
                        }
                    }
                    iColumnCounter++;
                }
                foreach (clsTableRef oTable in oTableRef)
                {
                    strCS += "            // clearing drop down of " + oTable.TableName + "\r\n";
                    strCS += "            ddl" + oTable.TableName + ".ClearSelection();\r\n";
                    strCS += "            // creating objects of list item with selected " + oTable.TableName + "\r\n";
                    strCS += "            ListItem lst" + oTable.TableName + " = ddl" + oTable.TableName + ".Items.FindByValue(oBD" + TableName.Replace("tbl", "") + "." + oTable.PrimaryColumn + ".ToString());\r\n";
                    strCS += "            // checking for list item lst" + oTable.TableName + "with null\r\n";
                    strCS += "            if (lst" + oTable.TableName + " != null)\r\n";
                    strCS += "            {\r\n";
                    strCS += "                // selecting list of country\r\n";
                    strCS += "                lst" + oTable.TableName + ".Selected = true;\r\n";
                    strCS += "            }\r\n";
                }
                strCS += "            // initiallising view state of " + IdentityColumn + " with the current selected row\r\n";
                strCS += "            ViewState[" + Convert.ToChar(34) + "v" + IdentityColumn + Convert.ToChar(34) + "] = oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + ";\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            //inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "dg" + TableName.Replace("tbl", "") + "_UpdateCommand" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region DataGrid PageIndexChanged Command

                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "source" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">DataGridCommandEventArgs</param>\r\n";
                strCS += "    protected void dg" + TableName.Replace("tbl", "") + "_PageIndexChanged(object source, DataGridPageChangedEventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // changing page index with the current index\r\n";
                strCS += "            dg" + TableName.Replace("tbl", "") + ".CurrentPageIndex = e.NewPageIndex;\r\n";
                strCS += "            // binding grid with current page index\r\n";
                strCS += "            Bind" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            //inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "dg" + TableName.Replace("tbl", "") + "_PageIndexChanged" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region Save Button Click Command

                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "sender" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">EventArgs</param>\r\n";
                strCS += "    protected void btnSave_Click(object sender, EventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // creating object of clsBDSMState \r\n";
                strCS += "            clsBD" + TableName.Replace("tbl", "") + " oBD" + TableName.Replace("tbl", "") + " = new clsBD" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "            // assigning value to StateId\r\n";
                strCS += "            oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = 0;\r\n";
                strCS += "            // checking for " + IdentityColumn + " view state for null\r\n";
                strCS += "            if (ViewState[" + Convert.ToChar(34) + "v" + IdentityColumn + Convert.ToChar(34) + "] != null)\r\n";
                strCS += "                // assigning value to " + IdentityColumn.Replace("tbl", "") + " from ViewState of " + IdentityColumn + "\r\n";
                strCS += "                oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = Convert.ToInt64(ViewState[" + Convert.ToChar(34) + "v" + IdentityColumn + Convert.ToChar(34) + "]);\r\n";
                strCS += "            // creating object of cls" + TableName.Replace("tbl", "") + "\r\n";
                strCS += "            clsBO" + TableName.Replace("tbl", "") + " oBO" + TableName.Replace("tbl", "") + " = new clsBO" + TableName.Replace("tbl", "") + "();\r\n";

                iColumnCounter = 0;
                foreach (DataColumn dc in dtCurrentTable.Columns)
                {
                    if (!arrlstRefColumns.Contains(dc.ColumnName) && dc.ColumnName != "UserTransactionId" && dc.ColumnName != "CreatedDateTime" && dc.ColumnName != "CreateDateTime" && dc.ColumnName != "Status" && iColumnCounter > 0)
                    {
                        string strControlName = "";
                        string strControlValue = "";
                        if (dc.DataType.ToString() == "System.String" || dc.DataType.ToString() == "System.Int32" || dc.DataType.ToString() == "System.DateTime" || dc.DataType.ToString() == "System.Decimal")
                        {
                            strControlName = "txt" + dc.ColumnName;
                            if (dc.DataType.ToString() == "System.String")
                            {
                                strControlValue = strControlName + ".Text";
                            }
                            if (dc.DataType.ToString() == "System.Int32")
                            {
                                strControlValue = "Convert.ToInt32(" + strControlName + ".Text)";
                            }
                            if (dc.DataType.ToString() == "System.Decimal")
                            {
                                strControlValue = "Convert.ToDecimal(" + strControlName + ".Text)";
                            }
                            if (dc.DataType.ToString() == "System.DateTime")
                            {
                                strControlValue = "Convert.ToDateTime(" + strControlName + ".Text)";
                            }
                            strCS += "            // assigning value to object of clsBD" + TableName + " from " + strControlName + "\r\n";
                            strCS += "            oBD" + TableName.Replace("tbl", "") + "." + dc.ColumnName + " = " + strControlValue + ";\r\n";
                        }
                        else if (dc.DataType.ToString() == "System.Boolean")
                        {
                            strControlName = "chk" + dc.ColumnName;
                            strCS += "            // assigning value to object of clsBD" + TableName + " from " + strControlName + "\r\n";
                            strCS += "            oBD" + TableName.Replace("tbl", "") + "." + dc.ColumnName + " = " + strControlName + ".Checked;\r\n";
                        }
                        else if (dc.DataType.ToString() == "System.Int64")
                        {
                            strControlName = "ddl" + dc.ColumnName;
                            strCS += "            // assigning value to object of clsBD" + TableName + " from " + strControlName + "\r\n";
                            strCS += "            oBD" + TableName.Replace("tbl", "") + "." + dc.ColumnName + " = Convert.ToInt64(" + strControlName + ".SelectedValue);\r\n";
                        }
                    }
                    iColumnCounter++;
                }
                strCS += "            // assigning value to object of clsBD" + TableName + " from ddlStatus\r\n";
                strCS += "            oBD" + TableName.Replace("tbl", "") + ".Status = Convert.ToInt32(ddlStatus.SelectedValue);\r\n";
                strCS += "            // checking for " + IdentityColumn + " for 0\r\n";
                strCS += "            if (oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " == 0)\r\n";
                strCS += "            {\r\n";
                strCS += "                // creating object of UnitOfWorkScope for perforing insert with transation\r\n";
                strCS += "                using (new UnitOfWorkScope(true))\r\n";
                strCS += "                {\r\n";
                strCS += "                    // calling insert method of business object class of State\r\n";
                strCS += "                    oBO" + TableName.Replace("tbl", "") + ".ins" + TableName + "(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "                }\r\n";
                strCS += "            }\r\n";
                strCS += "            else\r\n";
                strCS += "            {\r\n";
                strCS += "                // creating object of UnitOfWorkScope for perforing update with transation\r\n";
                strCS += "                using (new UnitOfWorkScope(true))\r\n";
                strCS += "                {\r\n";
                strCS += "                    // calling update method of business object class of State\r\n";
                strCS += "                    oBO" + TableName.Replace("tbl", "") + ".upd" + TableName + "(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "                }\r\n";
                strCS += "            }\r\n";
                strCS += "            // assigning value in " + IdentityColumn + " with 0\r\n";
                strCS += "            oBD" + TableName.Replace("tbl", "") + "." + IdentityColumn + " = 0;\r\n";
                strCS += "            // assigning data in session of state\r\n";
                strCS += "            Session[" + Convert.ToChar(34) + "s" + TableName.Replace("tbl", "") + "" + Convert.ToChar(34) + "] = oBO" + TableName.Replace("tbl", "") + ".get" + TableName + "(oBD" + TableName.Replace("tbl", "") + ");\r\n";
                strCS += "            // calling method to bind state\r\n";
                strCS += "            Bind" + TableName.Replace("tbl", "") + "();\r\n";
                strCS += "            // calling method to reset all controls\r\n";
                strCS += "            ResetControls();\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            //inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "btnSave_Click" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region Cancel Button Click Command

                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "sender" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">EventArgs</param>\r\n";
                strCS += "    protected void btnCancel_Click(object sender, EventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // redirecting page to base\r\n";
                strCS += "            //Response.Redirect(Resources.rPageRedirection.pgState);\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            //inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "btnCancel_Click" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "\r\n";
                #endregion

                #region Reset Button Click Command

                strCS += "    /// <summary>\r\n";
                strCS += "    /// \r\n";
                strCS += "    /// </summary>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "sender" + Convert.ToChar(34) + ">object</param>\r\n";
                strCS += "    /// <param name=" + Convert.ToChar(34) + "e" + Convert.ToChar(34) + ">EventArgs</param>\r\n";
                strCS += "    protected void btnReset_Click(object sender, EventArgs e)\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // calling method to reset all controls\r\n";
                strCS += "            ResetControls();\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            //inserting error to the database\r\n";
                strCS += "            clsUtility.insError(this.ToString(), " + Convert.ToChar(34) + "btnReset_Click" + Convert.ToChar(34) + ", ex.ToString(), 1, Convert.ToInt64(Session[" + Convert.ToChar(34) + "UserId" + Convert.ToChar(34) + "]));\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                #endregion

                #region Method ResetControls
                strCS += "\r\n";
                strCS += "    private void ResetControls()\r\n";
                strCS += "    {\r\n";
                strCS += "        try\r\n";
                strCS += "        {\r\n";
                strCS += "            // setting view state to null\r\n";
                strCS += "            ViewState[" + Convert.ToChar(34) + "v" + IdentityColumn + Convert.ToChar(34) + "] = null; \r\n";
                iColumnCounter = 0;
                foreach (DataColumn dc in dtCurrentTable.Columns)
                {
                    if (!arrlstRefColumns.Contains(dc.ColumnName) && dc.ColumnName != "UserTransactionId" && dc.ColumnName != "CreatedDateTime" && dc.ColumnName != "CreateDateTime" && dc.ColumnName != "Status" && iColumnCounter > 0)
                    {
                        string strControlName = "";
                        if (dc.DataType.ToString() == "System.String" || dc.DataType.ToString() == "System.Int32" || dc.DataType.ToString() == "System.DateTime" || dc.DataType.ToString() == "System.Decimal")
                        {
                            strControlName = "txt" + dc.ColumnName;
                            strCS += "            // clearing " + strControlName + "\r\n";
                            strCS += "            " + strControlName + ".Text = string.Empty;\r\n";
                        }
                        else if (dc.DataType.ToString() == "System.Boolean")
                        {
                            strControlName = "chk" + dc.ColumnName;
                            strCS += "            // assigning value to " + strControlName + "\r\n";
                            strCS += "            " + strControlName + ".Checked = false;\r\n";
                        }
                    }
                    iColumnCounter++;
                }
                foreach (clsTableRef oTable in oTableRef)
                {
                    strCS += "            // clearing drop down of " + oTable.TableName + "\r\n";
                    strCS += "            ddl" + oTable.TableName + ".ClearSelection();\r\n";
                    strCS += "            // reseting Status with 1st Item\r\n";
                    strCS += "            ddl" + oTable.TableName + ".Items[0].Selected = true;\r\n";
                }
                strCS += "            // clearing ddlStatus\r\n";
                strCS += "            ddlStatus.ClearSelection();\r\n";
                strCS += "            // reseting Status with 1st Item\r\n";
                strCS += "            ddlStatus.Items[0].Selected = true;\r\n";
                strCS += "        }\r\n";
                strCS += "        catch (Exception ex)\r\n";
                strCS += "        {\r\n";
                strCS += "            throw ex;\r\n";
                strCS += "        }\r\n";
                strCS += "    }\r\n";
                strCS += "}\r\n";
                #endregion

                if (File.Exists(@"C:\CompleteDataBaseAccess\ctrl" + TableName.Replace("tbl", "") + ".ascx.cs"))
                    File.Delete(@"C:\CompleteDataBaseAccess\ctrl" + TableName.Replace("tbl", "") + ".ascx.cs");
                System.IO.StreamWriter oSW = new System.IO.StreamWriter(@"C:\CompleteDataBaseAccess\ctrl" + TableName.Replace("tbl", "") + ".ascx.cs", true);
                oSW.Write(strCS);
                oSW.Close();

                GenerateCodeHTML(oTableRef);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableRef">List<clsTableRef></param>
        private void GenerateCodeHTML(List<clsTableRef> TableRef)
        {
            try
            {
                string strTableName = TableName;
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

                #region Referenced DropDownLists
                foreach (clsTableRef oTable in TableRef)
                {
                    string strRefTable = oTable.TableName.Replace("tbl", "");
                    string strRefColumn = oTable.RefTablePrimaryColumn;
                    string strRefDepends = oTable.DependsOf;

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
                #endregion

                OleDbCommand oOleDbCommand = new OleDbCommand("SELECT * FROM " + strTableName + " WHERE 1 = 2", CurrentConnection);
                OleDbDataAdapter da = new OleDbDataAdapter(oOleDbCommand);
                DataTable dtCurrentTable = new DataTable();
                da.Fill(dtCurrentTable);
                int iColumnCounter = 0;

                #region Getting All Column Table's Column
                ArrayList arrlstRefColumns = new ArrayList();
                foreach (clsTableRef oTable in TableRef)
                {
                    arrlstRefColumns.Add(oTable.RefTablePrimaryColumn);
                }
                #endregion

                #region Generation All Column Of Current Table
                foreach (DataColumn objDataColumn in dtCurrentTable.Columns)
                {
                    if (!arrlstRefColumns.Contains(objDataColumn.ColumnName) && objDataColumn.ColumnName != "UserTransactionId" && objDataColumn.ColumnName != "CreateDateTime" && objDataColumn.ColumnName != "CreatedDateTime" && objDataColumn.ColumnName != "Status" && iColumnCounter > 0 && objDataColumn.DataType.ToString() != "System.Int64")
                    {
                        string strControlName = "";
                        string strControlOpenTag = "";
                        string strControlClosingTag = "";
                        string strControlClass = "";
                        if (objDataColumn.DataType.ToString() == "System.String" || objDataColumn.DataType.ToString() == "System.Int32" || objDataColumn.DataType.ToString() == "System.Decimal")
                        {
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
                #endregion

                #region Generating Code for Status & Button
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
                strHTML += "                DataKeyField=" + Convert.ToChar(34) + IdentityColumn + Convert.ToChar(34) + " AllowPaging=" + Convert.ToChar(34) + "True" + Convert.ToChar(34) + " OnDeleteCommand=" + Convert.ToChar(34) + "dg" + strTableName.Replace("tbl", "") + "_DeleteCommand" + Convert.ToChar(34) + "\r\n";
                strHTML += "                OnPageIndexChanged=" + Convert.ToChar(34) + "dg" + strTableName.Replace("tbl", "") + "_PageIndexChanged" + Convert.ToChar(34) + " OnUpdateCommand=" + Convert.ToChar(34) + "dg" + strTableName.Replace("tbl", "") + "_UpdateCommand" + Convert.ToChar(34) + ">\r\n";
                strHTML += "                <Columns>\r\n";
                #endregion

                iColumnCounter = 0;

                #region Code for Bind DataColumns into Grid
                foreach (DataColumn objDataColumn in dtCurrentTable.Columns)
                {
                    if (objDataColumn.ColumnName != "UserTransactionId" && objDataColumn.ColumnName != "CreatedDateTime" && objDataColumn.ColumnName != "Status" && iColumnCounter > 0)
                        strHTML += "                    <asp:BoundColumn DataField=" + Convert.ToChar(34) + objDataColumn.ColumnName + Convert.ToChar(34) + " HeaderText=" + Convert.ToChar(34) + objDataColumn.ColumnName + Convert.ToChar(34) + "></asp:BoundColumn>\r\n";
                    iColumnCounter++;
                }
                #endregion

                #region Code for Edit, Delete Column & StyleSheets of DataGrid
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
                #endregion

                strHTML += "    </tr>\r\n";
                strHTML += "</table>\r\n";

                if (File.Exists(@"C:\CompleteDataBaseAccess\ctrl" + TableName.Replace("tbl", "") + ".ascx"))
                    File.Delete(@"C:\CompleteDataBaseAccess\ctrl" + TableName.Replace("tbl", "") + ".ascx");
                System.IO.StreamWriter oSW = new System.IO.StreamWriter(@"C:\CompleteDataBaseAccess\ctrl" + TableName.Replace("tbl", "") + ".ascx", true);
                oSW.Write(strHTML);
                oSW.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerateCS_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateCSCode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
class clsTableRef
{
    public clsTableRef()
    { }
    private string _TableName;

    public string TableName
    {
        get { return _TableName; }
        set { _TableName = value; }
    }
    private string _PrimaryColumn;

    public string PrimaryColumn
    {
        get { return _PrimaryColumn; }
        set { _PrimaryColumn = value; }
    }
    private string _DisplayText;

    public string DisplayText
    {
        get { return _DisplayText; }
        set { _DisplayText = value; }
    }
    private string _DependsOf;

    public string DependsOf
    {
        get { return _DependsOf; }
        set { _DependsOf = value; }
    }
    private bool _IsMainTable;

    public bool IsMainTable
    {
        get { return _IsMainTable; }
        set { _IsMainTable = value; }
    }

    private int _Order;

    public int Order
    {
        get { return _Order; }
        set { _Order = value; }
    }

    private string _RefTablePrimaryColumn;

    public string RefTablePrimaryColumn
    {
        get { return _RefTablePrimaryColumn; }
        set { _RefTablePrimaryColumn = value; }
    }
}