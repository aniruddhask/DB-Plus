using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;

namespace CompleteDataBaseAccess
{
    public partial class DataGrid : Form
    {
        private OleDbConnection oOleDbConnection;
        ArrayList arrlstGridCommand;
        DataTable dtTables;
        public static DataSet dsColumns;
        public bool bIsProcedure;
        ArrayList arrlstParameters;
        public DataGrid(ArrayList arrlstConnectionString)
        {
            InitializeComponent();
            arrlstParameters = arrlstConnectionString;
        }

        #region Fill combo with the existing column
        private void fillDataKeyField()
        {
            cmbDataKeyField.Items.Clear();
            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
            {
                if (cmbSelection.Text != "Stored Procedure")
                {
                    if (oOleDbConnection.State == ConnectionState.Closed)
                        oOleDbConnection.Open();
                    OleDbCommand cmdGetColumns = new OleDbCommand("SP_HELP " + cmbDatasourceForDataGrid.Text, oOleDbConnection);
                    OleDbDataAdapter daGetColumns = new OleDbDataAdapter(cmdGetColumns);
                    dsColumns = new DataSet();
                    daGetColumns.Fill(dsColumns);
                    foreach (DataRow drKey in dsColumns.Tables[1].Rows)
                    {
                        cmbDataKeyField.Items.Add(drKey[0].ToString());
                    }
                    bIsProcedure = false;
                }
                else
                {
                    dsColumns = new DataSet();
                    ExecuteProcedure oExecuteProcedure = new ExecuteProcedure(oOleDbConnection, cmbDatasourceForDataGrid.Text);
                    oExecuteProcedure.ShowInTaskbar = false;
                    oExecuteProcedure.ShowDialog();
                    if (dsColumns.Tables.Count < 2)
                    {
                        foreach (DataColumn dcColumns in dsColumns.Tables[0].Columns)
                        {
                            cmbDataKeyField.Items.Add(dcColumns.ColumnName);
                        }
                    }
                    oOleDbConnection.Close();
                    bIsProcedure = true;
                }
            }
            else
            {
                oOleDbConnection = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
                if (oOleDbConnection.State == ConnectionState.Closed)
                    oOleDbConnection.Open();
                OleDbCommand oOleDbCommandSelectDataFromSelectedTable = new OleDbCommand("select * from " + this.cmbDatasourceForDataGrid.Text, oOleDbConnection);
                //OleDbCommand cmdGetColumns = new OleDbCommand("SP_HELP " + cmbDatasourceForDataGrid.Text, oOleDbConnection);
                OleDbDataAdapter daGetColumns = new OleDbDataAdapter(oOleDbCommandSelectDataFromSelectedTable);
                dsColumns = new DataSet();
                daGetColumns.Fill(dsColumns);
                foreach (DataColumn drKey in dsColumns.Tables[0].Columns)
                {
                    cmbDataKeyField.Items.Add(drKey.ColumnName);
                }
                bIsProcedure = false;
            }
        }
        #endregion

        #region Fill Listbox with existing columns
        private void fillColumnList()
        {
            lstDataGridGolumns.Items.Clear();
            if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
            {
                if (cmbSelection.Text != "Stored Procedure")
                {
                    if (oOleDbConnection.State == ConnectionState.Closed)
                        oOleDbConnection.Open();
                    OleDbCommand cmdGetColumns = new OleDbCommand("SP_HELP " + cmbDatasourceForDataGrid.Text, oOleDbConnection);
                    OleDbDataAdapter daGetColumns = new OleDbDataAdapter(cmdGetColumns);
                    dsColumns = new DataSet();
                    daGetColumns.Fill(dsColumns);
                    foreach (DataRow drKey in dsColumns.Tables[1].Rows)
                    {
                        lstDataGridGolumns.Items.Add(drKey[0].ToString());
                    }
                    bIsProcedure = false;
                }
                else
                {
                    if (dsColumns.Tables.Count < 2)
                    {
                        foreach (DataColumn dcColumns in dsColumns.Tables[0].Columns)
                        {
                            lstDataGridGolumns.Items.Add(dcColumns.ColumnName);
                        }
                    }
                    oOleDbConnection.Close();
                    bIsProcedure = true;
                }
            }
            else
            {
                oOleDbConnection = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
                if (oOleDbConnection.State == ConnectionState.Closed)
                    oOleDbConnection.Open();
                OleDbCommand oOleDbCommandSelectDataFromSelectedTable = new OleDbCommand("select * from " + this.cmbDatasourceForDataGrid.Text, oOleDbConnection);
                //OleDbCommand cmdGetColumns = new OleDbCommand("SP_HELP " + cmbDatasourceForDataGrid.Text, oOleDbConnection);
                OleDbDataAdapter daGetColumns = new OleDbDataAdapter(oOleDbCommandSelectDataFromSelectedTable);
                dsColumns = new DataSet();
                daGetColumns.Fill(dsColumns);
                foreach (DataColumn drKey in dsColumns.Tables[0].Columns)
                {
                    lstDataGridGolumns.Items.Add(drKey.ColumnName);
                }
                bIsProcedure = false;
            }
        }
        #endregion

        #region Creating Runtime Control For Buttons in DataGrid
        private void CreateParameter(int Count)
        {
            TextBox txt1 = new TextBox();
            txt1.Name = "txtColumn" + Count.ToString();
            txt1.Width = 80;
            txt1.Height = 13;
            txt1.Top = 25 * Count;
            txt1.Left = 5;
            //txt1.ForeColor = Color.FromArgb(156, 86, 136);

            ComboBox txt = new ComboBox();
            txt.Name = "txtCommand" + Count.ToString();
            txt.Width = 80;
            txt.Height = 13;
            txt.Top = 25 * Count;
            txt.Left = 85;
            txt.Items.Add("Cancel");
            txt.Items.Add("Update");
            txt.Items.Add("Delete");
            txt.Items.Add("Edit");
            txt.Items.Add("Item");
            txt.DropDownStyle = ComboBoxStyle.DropDownList;
            //txt.ForeColor = Color.FromArgb(156, 86, 136);

            Button btn = new Button();
            btn.Name = "btn" + Count.ToString();
            btn.Text = "Add More...";
            btn.Click += new EventHandler(btn_Click);
            //btn.BackColor = Color.FromArgb(156, 86, 136);
            //btn.ForeColor = Color.FromArgb(255, 255, 255);
            btn.Top = 25 * Count;
            btn.Left = 170;
            btn.Width = 70;

            pnlButton.Controls.Add(txt1);
            pnlButton.Controls.Add(txt);
            pnlButton.Controls.Add(btn);
        }
        #endregion

        #region Other Events
        void btn_Click(object sender, EventArgs e)
        {
            CreateParameter(pnlButton.Controls.Count / 3);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int iSelectedIndex = lstDataGridGolumns.SelectedIndex;
                if (iSelectedIndex != -1)
                    lstDataGridGolumns.Items.RemoveAt(iSelectedIndex);
                if (lstDataGridGolumns.Items.Count > 0)
                {
                    if (iSelectedIndex == lstDataGridGolumns.Items.Count)
                        lstDataGridGolumns.SelectedIndex = iSelectedIndex - 1;
                    else
                        lstDataGridGolumns.SelectedIndex = iSelectedIndex;
                }
                else
                    btnRemove.Enabled = false;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void btnReferesh_Click(object sender, EventArgs e)
        {
            try
            {
                fillColumnList();
                btnRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHasEvent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkHasEvent.Checked)
                {
                    CreateParameter(0);
                }
                else
                {
                    pnlButton.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDataGridGolumns.SelectedIndex > 0)
                {
                    int iSelectedIndex = lstDataGridGolumns.SelectedIndex;
                    object oSelected = lstDataGridGolumns.Items[lstDataGridGolumns.SelectedIndex];
                    lstDataGridGolumns.Items.Remove(oSelected);
                    lstDataGridGolumns.Items.Insert(iSelectedIndex - 1, oSelected);
                    lstDataGridGolumns.SelectedIndex = iSelectedIndex - 1;
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDataGridGolumns.SelectedIndex < lstDataGridGolumns.Items.Count - 1)
                {
                    int iSelectedIndex = lstDataGridGolumns.SelectedIndex;
                    object oSelected = lstDataGridGolumns.Items[lstDataGridGolumns.SelectedIndex];
                    lstDataGridGolumns.Items.Remove(oSelected);
                    lstDataGridGolumns.Items.Insert(iSelectedIndex + 1, oSelected);
                    lstDataGridGolumns.SelectedIndex = iSelectedIndex + 1;
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void cmbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtTables = new DataTable();
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                {
                    if (cmbSelection.Text == "Table")
                    {
                        if (oOleDbConnection.State == ConnectionState.Closed)
                            oOleDbConnection.Open();
                        OleDbCommand objOleDbCommand = new OleDbCommand("sp_tables", oOleDbConnection);
                        OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                        dtTables.Rows.Clear();
                        daTables.Fill(dtTables);
                        cmbDatasourceForDataGrid.Items.Clear();
                        foreach (DataRow dr in dtTables.Rows)
                        {
                            if (dr[3].ToString() == "TABLE")
                            {
                                if (dr[2].ToString() != "dtproperties" && dr[2].ToString().ToLower() != "sysdiagrams")
                                    cmbDatasourceForDataGrid.Items.Add(dr[2].ToString());
                            }
                        }
                        oOleDbConnection.Close();
                    }
                    else if (cmbSelection.Text == "View")
                    {
                        if (oOleDbConnection.State == ConnectionState.Closed)
                            oOleDbConnection.Open();
                        OleDbCommand objOleDbCommand = new OleDbCommand("sp_tables", oOleDbConnection);
                        OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                        dtTables.Rows.Clear();
                        daTables.Fill(dtTables);
                        cmbDatasourceForDataGrid.Items.Clear();
                        foreach (DataRow dr in dtTables.Rows)
                        {
                            if (dr[3].ToString().ToLower() == "View".ToLower())
                            {
                                if (dr[2].ToString() != "dtproperties")
                                    cmbDatasourceForDataGrid.Items.Add(dr[2].ToString());
                            }
                        }
                        oOleDbConnection.Close();
                    }
                    else if (cmbSelection.Text == "Stored Procedure")
                    {
                        if (oOleDbConnection.State == ConnectionState.Closed)
                            oOleDbConnection.Open();
                        OleDbCommand objOleDbCommand = new OleDbCommand("sp_help", oOleDbConnection);
                        OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                        dtTables.Rows.Clear();
                        daTables.Fill(dtTables);
                        cmbDatasourceForDataGrid.Items.Clear();
                        foreach (DataRow dr in dtTables.Rows)
                        {
                            if (dr[2].ToString().ToLower() == "stored procedure")
                            {
                                if (dr[0].ToString().IndexOf("dt_") == -1)
                                    cmbDatasourceForDataGrid.Items.Add(dr[0].ToString());
                            }
                        }
                        oOleDbConnection.Close();
                    }
                    else
                    {
                        if (oOleDbConnection.State == ConnectionState.Closed)
                            oOleDbConnection.Open();
                        OleDbCommand objOleDbCommand = new OleDbCommand("sp_tables", oOleDbConnection);
                        OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                        dtTables.Rows.Clear();
                        daTables.Fill(dtTables);
                        cmbDatasourceForDataGrid.Items.Clear();
                        foreach (DataRow dr in dtTables.Rows)
                        {
                            if (dr[3].ToString().ToLower() == "View".ToLower())
                            {
                                if (dr[2].ToString() != "dtproperties")
                                    cmbDatasourceForDataGrid.Items.Add(dr[2].ToString());
                            }
                        }
                        oOleDbConnection.Close();
                        //MessageBox.Show("This is not working properly");
                    }
                }
                else
                {
                    if (cmbSelection.Text == "Table")
                    {
                        if (oOleDbConnection.State == ConnectionState.Closed)
                            oOleDbConnection.Open();
                        OleDbCommand objOleDbCommand = new OleDbCommand();
                        //reset connection to the information_schema for getting tables of selected database from mysql database.
                        oOleDbConnection = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=Information_Schema");
                        //initialize the command for getting all the table of mysql selected database.
                        objOleDbCommand = new OleDbCommand("SELECT '0' AS 'Column1', '0' AS 'Column2', TABLE_NAME, Table_Type FROM TABLES WHERE TABLE_SCHEMA='" + arrlstParameters[4].ToString() + "'", oOleDbConnection);
                        OleDbDataAdapter daTables = new OleDbDataAdapter(objOleDbCommand);
                        dtTables.Rows.Clear();
                        daTables.Fill(dtTables);
                        cmbDatasourceForDataGrid.Items.Clear();
                        foreach (DataRow dr in dtTables.Rows)
                        {
                            if (dr[2].ToString() != "dtproperties")
                                cmbDatasourceForDataGrid.Items.Add(dr[2].ToString());
                        }
                        oOleDbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void cmbDatasourceForDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pnlButton.Controls.Clear();
                chkHasEvent.Checked = false;
                fillDataKeyField();
                fillColumnList();
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }

        private void DataGrid_Load(object sender, EventArgs e)
        {
            oOleDbConnection = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
            //btnChange.Enabled = false;
            //btnCS.Enabled = false;
        }

        #endregion

        #region Generate HTML Code
        private void btnHTML_Click(object sender, EventArgs e)
        {
            try
            {
                string strHTML = "";
                string strGridCommands = "";
                arrlstGridCommand = new ArrayList();
                strHTML += @"<table id=" + Convert.ToChar(34) + "tbl" + cmbDatasourceForDataGrid.Text + Convert.ToChar(34) + " width=" + Convert.ToChar(34) + "100%" + Convert.ToChar(34) + " border=" + Convert.ToChar(34) + "0" + Convert.ToChar(34) + " cellpadding=" + Convert.ToChar(34) + "0" + Convert.ToChar(34) + " cellspacing=" + Convert.ToChar(34) + "0" + Convert.ToChar(34) + " style=" + Convert.ToChar(34) + "font-family:Verdana; font-size:xx-small" + Convert.ToChar(34) + ">";

                if (bIsProcedure)
                {
                    foreach (DataRow drKey in dsColumns.Tables[0].Rows)
                    {
                        strHTML += "\r\n   <tr>";
                        strHTML += "\r\n       <td style=" + Convert.ToChar(34) + "width:30%" + Convert.ToChar(34) + ">" + drKey[0].ToString() + "</td>";
                        strHTML += "\r\n       <td><asp:TextBox ID=" + Convert.ToChar(34) + "txt" + drKey[0].ToString() + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + " Width=" + Convert.ToChar(34) + "50%" + Convert.ToChar(34) + "></asp:TextBox>" + "</td>";
                        strHTML += "\r\n   </tr>";
                    }
                }
                else
                {
                    foreach (DataRow drKey in dsColumns.Tables[1].Rows)
                    {
                        strHTML += "\r\n   <tr>";
                        strHTML += "\r\n       <td style=" + Convert.ToChar(34) + "width:30%" + Convert.ToChar(34) + ">" + drKey[0].ToString() + "</td>";
                        strHTML += "\r\n       <td><asp:TextBox ID=" + Convert.ToChar(34) + "txt" + drKey[0].ToString() + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + " Width=" + Convert.ToChar(34) + "50%" + Convert.ToChar(34) + "></asp:TextBox>" + "</td>";
                        strHTML += "\r\n   </tr>";
                    }
                }
                strHTML += "\r\n   <tr>";
                strHTML += "\r\n   <td colspan=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + "><asp:Button ID=" + Convert.ToChar(34) + "btnAddNew" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + "Add New" + Convert.ToChar(34) + " OnClick=" + Convert.ToChar(34) + "btnAddNew_Click" + Convert.ToChar(34) + " />";
                strHTML += "\r\n<asp:Button ID=" + Convert.ToChar(34) + "btnAdd" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Enabled=" + Convert.ToChar(34) + "false" + Convert.ToChar(34) + " Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + "Add" + Convert.ToChar(34) + " OnClick=" + Convert.ToChar(34) + "btnAdd_Click" + Convert.ToChar(34) + " />";
                strHTML += "\r\n<asp:Button ID=" + Convert.ToChar(34) + "btnUpdate" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " Enabled=" + Convert.ToChar(34) + "false" + Convert.ToChar(34) + " Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + "Update" + Convert.ToChar(34) + " OnClick=" + Convert.ToChar(34) + "btnUpdate_Click" + Convert.ToChar(34) + " /></td></tr>";
                strHTML += "\r\n   <tr>";
                strHTML += "\r\n       <td colspan=" + Convert.ToChar(34) + "2" + Convert.ToChar(34) + ">";
                int iCount = pnlButton.Controls.Count / 3;
                for (int iCounter = 0; iCounter < iCount; iCounter++)
                {
                    if (((ComboBox)(pnlButton.Controls[iCounter * 3 + 1])).Text == "Cancel")
                        strGridCommands += " OnCancelCommand=" + Convert.ToChar(34) + "dg" + cmbDatasourceForDataGrid.Text + "_CancelCommand" + Convert.ToChar(34);
                    else if (((ComboBox)(pnlButton.Controls[iCounter * 3 + 1])).Text == "Delete")
                        strGridCommands += " OnDeleteCommand=" + Convert.ToChar(34) + "dg" + cmbDatasourceForDataGrid.Text + "_DeleteCommand" + Convert.ToChar(34);
                    else if (((ComboBox)(pnlButton.Controls[iCounter * 3 + 1])).Text == "Edit")
                        strGridCommands += " OnEditCommand=" + Convert.ToChar(34) + "dg" + cmbDatasourceForDataGrid.Text + "_EditCommand" + Convert.ToChar(34);
                    else if (((ComboBox)(pnlButton.Controls[iCounter * 3 + 1])).Text == "Update")
                        strGridCommands += " OnUpdateCommand=" + Convert.ToChar(34) + "dg" + cmbDatasourceForDataGrid.Text + "_UpdateCommand" + Convert.ToChar(34);
                    else if (((ComboBox)(pnlButton.Controls[iCounter * 3 + 1])).Text == "Item")
                        strGridCommands += " OnItemCommand=" + Convert.ToChar(34) + "dg" + cmbDatasourceForDataGrid.Text + "_ItemCommand" + Convert.ToChar(34);
                    arrlstGridCommand.Add(((ComboBox)(pnlButton.Controls[iCounter * 3 + 1])).Text);
                }
                strHTML += "<asp:DataGrid ID=" + Convert.ToChar(34) + "dg" + cmbDatasourceForDataGrid.Text + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + " AutoGenerateColumns=" + Convert.ToChar(34) + "False" + Convert.ToChar(34) + " DataKeyField=" + Convert.ToChar(34) + cmbDataKeyField.Text + Convert.ToChar(34) + " Width=" + Convert.ToChar(34) + "100%" + Convert.ToChar(34) + strGridCommands + ">\r\n";
                strHTML += "    <Columns>";
                foreach (string strColumn in lstDataGridGolumns.Items)
                    strHTML += "        <asp:BoundColumn DataField=" + Convert.ToChar(34) + strColumn + Convert.ToChar(34) + " HeaderText=" + Convert.ToChar(34) + strColumn + Convert.ToChar(34) + "></asp:BoundColumn>\r\n";
                for (int iCounter = 0; iCounter < iCount; iCounter++)
                {
                    if (chkPushButton.Checked)
                        strHTML += "        <asp:ButtonColumn CommandName=" + Convert.ToChar(34) + ((ComboBox)(pnlButton.Controls[3 * iCounter + 1])).Text + Convert.ToChar(34) + " HeaderText=" + Convert.ToChar(34) + ((TextBox)(pnlButton.Controls[iCounter * 3])).Text + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + ((TextBox)(pnlButton.Controls[iCounter * 3])).Text + Convert.ToChar(34) + " ButtonType=" + Convert.ToChar(34) + "PushButton" + Convert.ToChar(34) + "></asp:ButtonColumn>\r\n";
                    else
                        strHTML += "        <asp:ButtonColumn CommandName=" + Convert.ToChar(34) + ((ComboBox)(pnlButton.Controls[3 * iCounter + 1])).Text + Convert.ToChar(34) + " HeaderText=" + Convert.ToChar(34) + ((TextBox)(pnlButton.Controls[iCounter * 3])).Text + Convert.ToChar(34) + " Text=" + Convert.ToChar(34) + ((TextBox)(pnlButton.Controls[iCounter * 3])).Text + Convert.ToChar(34) + "></asp:ButtonColumn>\r\n";
                }
                strHTML += "    </Columns>";
                strHTML += "    <ItemStyle Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + " />\r\n";
                strHTML += "    <HeaderStyle Font-Bold=" + Convert.ToChar(34) + "True" + Convert.ToChar(34) + " Font-Names=" + Convert.ToChar(34) + "Verdana" + Convert.ToChar(34) + " Font-Size=" + Convert.ToChar(34) + "XX-Small" + Convert.ToChar(34) + "/>\r\n";
                strHTML += "</asp:DataGrid>";
                strHTML += "\r\n       </td>";
                strHTML += "\r\n   </tr>";
                strHTML += "\r\n</table>";
                if (MessageBox.Show("Do you want to create a saperate " + cmbDatasourceForDataGrid.Text + ".aspx file or simply copy the generated code to Clipboard.", "File Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    System.IO.StreamWriter swHTML = new System.IO.StreamWriter(@"C:\CompleteDataBaseAccess\" + cmbDatasourceForDataGrid.Text + ".aspx");
                    swHTML.WriteLine("<%@ Page Language=" + Convert.ToChar(34) + "C#" + Convert.ToChar(34) + " AutoEventWireup=" + Convert.ToChar(34) + "true" + Convert.ToChar(34) + " CodeFile=" + Convert.ToChar(34) + cmbDatasourceForDataGrid.Text + ".aspx.cs" + Convert.ToChar(34) + " Inherits=" + Convert.ToChar(34) + cmbDatasourceForDataGrid.Text + " %>");
                    swHTML.WriteLine("<!DOCTYPE html PUBLIC " + Convert.ToChar(34) + "-//W3C//DTD XHTML 1.0 Transitional//EN" + Convert.ToChar(34) + "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + Convert.ToChar(34) + ">");
                    swHTML.WriteLine("<html xmlns=" + Convert.ToChar(34) + "http://www.w3.org/1999/xhtml" + Convert.ToChar(34) + " >");
                    swHTML.WriteLine("  <head runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + ">");
                    swHTML.WriteLine("      <title>Untitled Page</title>");
                    swHTML.WriteLine("  </head>");
                    swHTML.WriteLine("  <body>");
                    swHTML.WriteLine("      <form id=" + Convert.ToChar(34) + "form1" + Convert.ToChar(34) + " runat=" + Convert.ToChar(34) + "server" + Convert.ToChar(34) + ">");
                    swHTML.WriteLine("          <div>");
                    swHTML.WriteLine(strHTML);
                    swHTML.WriteLine("          </div>");
                    swHTML.WriteLine("      </form>");
                    swHTML.WriteLine("  </body>");
                    swHTML.WriteLine("</html>");
                    swHTML.Close();
                }
                else
                {
                    Clipboard.SetDataObject(strHTML);
                }
                btnChange.Enabled = true;
                btnCS.Enabled = true;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        #endregion

        #region Code For Generation of the Data Interaction Layer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCS_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                ArrayList arrlst = new ArrayList();
                foreach (string strTableName in cmbDatasourceForDataGrid.Items)
                {
                    arrlst.Add(strTableName);
                }
                frmChooseTables o = new frmChooseTables(arrlst);
                o.ShowDialog();
                foreach (string strTableName in arrlst)
                {
                    GenerateManager(strTableName);
                }
            }
            else
            {
                GenerateManager(cmbDatasourceForDataGrid.Text);
            }
        }
        #endregion

        private void GenerateManager(string strNameToUse)
        {
            try
            {
                DbPlusInOne oDbPlusInOneForWritingProcedureCodeInClassFile = new DbPlusInOne(arrlstParameters);
                DataSet dsSettings = new DataSet();
                string strCodeFile = "using System;";
                dsSettings.ReadXml(@".\SettingForDBPlus.xml");
                strCodeFile += "\r\nusing System.Data;";
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                    strCodeFile += "\r\nusing System.Data.SqlClient;";
                else
                    strCodeFile += "\r\nusing System.Data.OleDb;";
                strCodeFile += "\r\nusing System.Collections;";
                strCodeFile += "\r\nusing System.Configuration;";
                strCodeFile += "\r\nusing System.Collections.Generic;";
                strCodeFile += "\r\nusing System.ComponentModel;";
                strCodeFile += "\r\nusing System.Text;";
                if (arrlstParameters[3].ToString().ToLower() != "sqloledb")
                {
                    strCodeFile += "\r\nusing MySql;";
                    strCodeFile += "\r\nusing MySql.Data;";
                    strCodeFile += "\r\nusing MySql.Data.MySqlClient;";
                    strCodeFile += "\r\nusing MySql.Data.Types;";
                }
                strCodeFile += "\r\nusing " + dsSettings.Tables[0].Rows[0]["Client"].ToString() + ";\r\n\r\n";
                strCodeFile += "\r\nnamespace " + dsSettings.Tables[0].Rows[0]["Server"].ToString();
                strCodeFile += "\r\n{";
                strCodeFile += "\r\n    public class " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString();
                strCodeFile += "\r\n    {";
                strCodeFile += "\r\n        //define constructor.";
                strCodeFile += "\r\n        public " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + "()";
                strCodeFile += "\r\n        {   }";

                strCodeFile += "\r\n        private SqlTransaction _objectTransaction;";
                strCodeFile += "\r\n        /// <summary>   ";
                strCodeFile += "\r\n        /// Returns the ObjectContext instance that belongs to the    ";
                strCodeFile += "\r\n        /// current UnitOfWorkScope. If currently no UnitOfWorkScope   ";
                strCodeFile += "\r\n        /// exists, a local instance of the NorthwindObjectContext class   ";
                strCodeFile += "\r\n        /// is returned.   ";
                strCodeFile += "\r\n        /// </summary>   ";
                strCodeFile += "\r\n        protected SqlTransaction ObjectTransaction";
                strCodeFile += "\r\n        {";
                strCodeFile += "\r\n            get";
                strCodeFile += "\r\n            {";

                strCodeFile += "\r\n                if (UnitOfWorkScope.CurrentObjectTransaction != null)";
                strCodeFile += "\r\n                    return UnitOfWorkScope.CurrentObjectTransaction;";
                strCodeFile += "\r\n                else";
                strCodeFile += "\r\n                {";
                strCodeFile += "\r\n                    if (_objectTransaction == null)";
                strCodeFile += "\r\n                    {";
                strCodeFile += "\r\n                        SqlConnection _objectConnection = new SqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                strCodeFile += "\r\n                        if (_objectConnection.State == ConnectionState.Closed)";
                strCodeFile += "\r\n                            _objectConnection.Open();";
                strCodeFile += "\r\n                        _objectTransaction = _objectConnection.BeginTransaction();";
                strCodeFile += "\r\n                    }";
                strCodeFile += "\r\n                    return _objectTransaction;";
                strCodeFile += "\r\n                }";
                strCodeFile += "\r\n            }";
                strCodeFile += "\r\n        }";
                if (chkInsert.Checked)
                {
                    strCodeFile += "\r\n        /// <summary>";
                    strCodeFile += "\r\n        /// Method to insert record into the database.";
                    strCodeFile += "\r\n        /// </summary>";
                    strCodeFile += "\r\n        /// <param name=" + Convert.ToChar(34) + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + Convert.ToChar(34) + ">" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "</param>";
                    strCodeFile += "\r\n        /// <returns>bool</returns>";
                    strCodeFile += "\r\n        public bool " + dsSettings.Tables[0].Rows[0]["DatabaseInsert"].ToString() + strNameToUse + "(" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ")";
                    strCodeFile += "\r\n        {";
                    //strCodeFile += "\r\n            //creating the connectoin object.";
                    //if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                    //    strCodeFile += "\r\n            SqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new SqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                    //else
                    //    strCodeFile += "\r\n            MySqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new MySqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                    strCodeFile += "\r\n            try";
                    strCodeFile += "\r\n            {";
                    string strCodeForInsertion = oDbPlusInOneForWritingProcedureCodeInClassFile.GetCodeForServerFile(oOleDbConnection, strNameToUse, "I", true);
                    strCodeFile += "\r\n            " + strCodeForInsertion;
                    strCodeFile += "\r\n                //return true in case of successfully done.";
                    strCodeFile += "\r\n                return true;";
                    strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n            catch(Exception ex)";
                    strCodeFile += "\r\n            {";
                    strCodeFile += "\r\n                //rollback transaction.";
                    strCodeFile += "\r\n                //" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Tran.Rollback();";
                    strCodeFile += "\r\n                //throw exception.";
                    strCodeFile += "\r\n                throw ex;";
                    strCodeFile += "\r\n            }";
                    //strCodeFile += "\r\n            finally";
                    //strCodeFile += "\r\n            {";
                    //strCodeFile += "\r\n                //close the connection";
                    //strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con.Close();";
                    //strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n        }";
                }
                if (chkUpdate.Checked)
                {
                    strCodeFile += "\r\n        /// <summary>";
                    strCodeFile += "\r\n        /// Method to update the record.";
                    strCodeFile += "\r\n        /// </summary>";
                    strCodeFile += "\r\n        /// <param name=" + Convert.ToChar(34) + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + Convert.ToChar(34) + ">" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "</param>";
                    strCodeFile += "\r\n        /// <returns>bool</returns>";
                    strCodeFile += "\r\n        public bool " + dsSettings.Tables[0].Rows[0]["DatabaseUpdate"].ToString() + strNameToUse + "(" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ")";
                    strCodeFile += "\r\n        {";
                    //strCodeFile += "\r\n            //creating the connection object.";
                    //if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                    //    strCodeFile += "\r\n            SqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new SqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                    //else
                    //    strCodeFile += "\r\n            MySqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new MySqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                    strCodeFile += "\r\n            try";
                    strCodeFile += "\r\n            {";
                    string strCodeForInsertion = oDbPlusInOneForWritingProcedureCodeInClassFile.GetCodeForServerFile(oOleDbConnection, strNameToUse, "U", true);
                    strCodeFile += "\r\n            " + strCodeForInsertion;
                    strCodeFile += "\r\n                //return true in case of sucessfully done.";
                    strCodeFile += "\r\n                return true;";
                    strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n            catch(Exception ex)";
                    strCodeFile += "\r\n            {";
                    strCodeFile += "\r\n                //rollback transaction.";
                    strCodeFile += "\r\n                //" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Tran.Rollback();";
                    strCodeFile += "\r\n                //throw exception.";
                    strCodeFile += "\r\n                throw ex;";
                    strCodeFile += "\r\n            }";
                    //strCodeFile += "\r\n            finally";
                    //strCodeFile += "\r\n            {";
                    //strCodeFile += "\r\n                //closing the connection.";
                    //strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con.Close();";
                    //strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n        }";
                }
                //if (chkDelete.Checked)
                //{
                //    strCodeFile += "\r\n        /// <summary>";
                //    strCodeFile += "\r\n        /// Method to delete record from the database.";
                //    strCodeFile += "\r\n        /// </summary>";
                //    strCodeFile += "\r\n        /// <param name=" + Convert.ToChar(34) + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + Convert.ToChar(34) + ">" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "</param>";
                //    strCodeFile += "\r\n        /// <returns>bool</returns>";
                //    strCodeFile += "\r\n        public bool " + dsSettings.Tables[0].Rows[0]["DatabaseDelete"].ToString() + strNameToUse + "(" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ")";
                //    strCodeFile += "\r\n        {";
                //    //strCodeFile += "\r\n            //creation of connection object.";
                //    //if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                //    //    strCodeFile += "\r\n            SqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new SqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                //    //else
                //    //    strCodeFile += "\r\n            MySqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new MySqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                //    strCodeFile += "\r\n            try";
                //    strCodeFile += "\r\n            {";
                //    string strCodeForInsertion = oDbPlusInOneForWritingProcedureCodeInClassFile.GetCodeForServerFile(oOleDbConnection, strNameToUse, "D", true);
                //    strCodeFile += "\r\n            " + strCodeForInsertion;
                //    strCodeFile += "\r\n                //returns true in case of success.";
                //    strCodeFile += "\r\n                return true;";
                //    strCodeFile += "\r\n            }";
                //    strCodeFile += "\r\n            catch(Exception ex)";
                //    strCodeFile += "\r\n            {";
                //    strCodeFile += "\r\n                //rollback transaction.";
                //    strCodeFile += "\r\n                //" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Tran.Rollback();";
                //    strCodeFile += "\r\n                //throw exception.";
                //    strCodeFile += "\r\n                throw ex;";
                //    strCodeFile += "\r\n            }";
                //    //strCodeFile += "\r\n            finally";
                //    //strCodeFile += "\r\n            {";
                //    //strCodeFile += "\r\n                //closing the connection.";
                //    //strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con.Close();";
                //    //strCodeFile += "\r\n            }";
                //    strCodeFile += "\r\n        }";
                //}
                if (chkSelect.Checked)
                {
                    strCodeFile += "\r\n        /// <summary>";
                    strCodeFile += "\r\n        /// Method to get all record from the database.";
                    strCodeFile += "\r\n        /// </summary>";
                    strCodeFile += "\r\n        /// <param name=" + Convert.ToChar(34) + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + Convert.ToChar(34) + ">" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "</param>";
                    strCodeFile += "\r\n        /// <returns>" + dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() + "</returns>";
                    strCodeFile += "\r\n        public " + dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() + " " + dsSettings.Tables[0].Rows[0]["DatabaseSelect"].ToString() + strNameToUse + "(" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ")";
                    strCodeFile += "\r\n        {";
                    strCodeFile += "\r\n            //creating the connection object.";
                    if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                        strCodeFile += "\r\n            SqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = Connection.GetConnection();";
                    else
                        strCodeFile += "\r\n            MySqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new MySqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                    strCodeFile += "\r\n            try";
                    strCodeFile += "\r\n            {";
                    string strCodeForInsertion = oDbPlusInOneForWritingProcedureCodeInClassFile.GetCodeForServerFile(oOleDbConnection, strNameToUse, "A", true);
                    strCodeFile += "\r\n            " + strCodeForInsertion;
                    strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n            catch(Exception ex)";
                    strCodeFile += "\r\n            {";
                    //updated on 5th apr 2009
                    //strCodeFile += "\r\n                //rollback transaction.";
                    //strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Tran.Rollback();";
                    strCodeFile += "\r\n                //throw exception.";
                    strCodeFile += "\r\n                throw ex;";
                    strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n            finally";
                    strCodeFile += "\r\n            {";
                    strCodeFile += "\r\n                //closing the connection.";
                    strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con.Close();";
                    strCodeFile += "\r\n            }";
                    strCodeFile += "\r\n        }";
                }
                strCodeFile += "\r\n        /// <summary>";
                strCodeFile += "\r\n        /// Method to get record from the database according to given Id.";
                strCodeFile += "\r\n        /// </summary>";
                strCodeFile += "\r\n        /// <param name=" + Convert.ToChar(34) + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + Convert.ToChar(34) + ">" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "</param>";
                strCodeFile += "\r\n        /// <returns>" + dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() + "</returns>";
                strCodeFile += "\r\n        public " + dsSettings.Tables[0].Rows[0]["SelectStore"].ToString() + " " + dsSettings.Tables[0].Rows[0]["DatabaseSelect"].ToString() + strNameToUse + "ByPrimaryId(" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ")";
                strCodeFile += "\r\n        {";
                strCodeFile += "\r\n            //creating the connection object.";
                if (arrlstParameters[3].ToString().ToLower() == "sqloledb")
                    strCodeFile += "\r\n            SqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = Connection.GetConnection();";
                else
                    strCodeFile += "\r\n            MySqlConnection " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con = new MySqlConnection(ConfigurationSettings.AppSettings[" + Convert.ToChar(34) + "strConnection" + Convert.ToChar(34) + "]);";
                strCodeFile += "\r\n            try";
                strCodeFile += "\r\n            {";
                string strCodeForInsertion1 = oDbPlusInOneForWritingProcedureCodeInClassFile.GetCodeForServerFile(oOleDbConnection, strNameToUse, "S", true);
                strCodeFile += "\r\n            " + strCodeForInsertion1;
                strCodeFile += "\r\n            }";
                strCodeFile += "\r\n            catch(Exception ex)";
                strCodeFile += "\r\n            {";
                //commented on 5th apr 2009
                //strCodeFile += "\r\n                //rollback transaction.";
                //strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Tran.Rollback();";
                strCodeFile += "\r\n                //throw exception.";
                strCodeFile += "\r\n                throw ex;";
                strCodeFile += "\r\n            }";
                strCodeFile += "\r\n            finally";
                strCodeFile += "\r\n            {";
                strCodeFile += "\r\n                //closing the connection.";
                strCodeFile += "\r\n                " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + "Con.Close();";
                strCodeFile += "\r\n            }";
                strCodeFile += "\r\n        }";
                /*
                strCodeFile += "\r\n        private object GetOperation(string Operation)";
                strCodeFile += "\r\n        {";
                strCodeFile += "\r\n            string strOperation = " + Convert.ToChar(34) + "" + Convert.ToChar(34) + ";";
                strCodeFile += "\r\n            foreach (char ch in Operation)";
                strCodeFile += "\r\n            {";
                strCodeFile += "\r\n                if (Convert.ToInt32(ch) >= 65 && Convert.ToInt32(ch) <= 90)";
                strCodeFile += "\r\n                    strOperation += " + Convert.ToChar(34) + " " + Convert.ToChar(34) + " + ch;";
                strCodeFile += "\r\n                else";
                strCodeFile += "\r\n                    strOperation += ch;";
                strCodeFile += "\r\n            }";
                strCodeFile += "\r\n            return strOperation.Trim();";
                strCodeFile += "\r\n        }";
                strCodeFile += "\r\n    ";
                */
                strCodeFile += "\r\n    }";
                strCodeFile += "\r\n}";
                System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(@"C:\CompleteDataBaseAccess\" + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + strNameToUse + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + ".cs", false);
                oStreamWriter.Write(strCodeFile);
                oStreamWriter.Close();
                //btnCS.Enabled = false;
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        private bool ValidForASPX()
        {
            bool bIsValid = false;
            if (chkInsert.Checked)
                bIsValid = true;
            else if (chkUpdate.Checked)
                bIsValid = true;
            else if (chkDelete.Checked)
                bIsValid = true;
            else if (chkSelect.Checked)
                bIsValid = true;
            else
                bIsValid = false;
            return bIsValid;
        }

        #region Generate ASPX .cs Code
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidForASPX())
                {
                    string strASPX = "";
                    DataSet dsSettings = new DataSet();
                    dsSettings.ReadXml(@".\SettingForDBPlus.xml");
                    strASPX += "private void BindGrid()";
                    strASPX += "\r\n{";
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + " = new " + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "();";
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager = new " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + "();";
                    strASPX += "\r\ndg" + cmbDatasourceForDataGrid.Text + ".DataSource = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager." + dsSettings.Tables[0].Rows[0]["DatabaseSelect"].ToString() + cmbDatasourceForDataGrid.Text + "(" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ");";
                    strASPX += "\r\ndg" + cmbDatasourceForDataGrid.Text + ".DataBind();";
                    strASPX += "\r\n}";
                    foreach (string strCommand in arrlstGridCommand)
                    {
                        if (strCommand == "Cancel")
                        {
                            strASPX += "\r\n";
                            strASPX += "\r\nprotected void dg" + cmbDatasourceForDataGrid.Text + "_CancelCommand(object source, DataGridCommandEventArgs e)";
                            strASPX += "\r\n{";
                            strASPX += "\r\n}";
                        }
                        else if (strCommand == "Update")
                        {
                            strASPX += "\r\n";
                            strASPX += "\r\nprotected void dg" + cmbDatasourceForDataGrid.Text + "_UpdateCommand(object source, DataGridCommandEventArgs e)";
                            strASPX += "\r\n{";
                            strASPX += "\r\nbtnUpdate.Enabled = true;";
                            strASPX += "\r\nbtnAdd.Enabled = false;";
                            strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + " = new " + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "();";
                            strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dsColumns.Tables[1].Rows[0][0].ToString() + " = Convert.ToInt64(dg" + cmbDatasourceForDataGrid.Text + ".DataKeys[e.Item.ItemIndex]);";
                            strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager = new " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + "();";
                            strASPX += "\r\nDataTable dt" + cmbDatasourceForDataGrid.Text + " = " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager." + dsSettings.Tables[0].Rows[0]["DatabaseSelect"].ToString() + cmbDatasourceForDataGrid.Text + "ByPrimaryId(" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ");";
                            if (bIsProcedure)
                            {
                                foreach (DataRow drKey in dsColumns.Tables[0].Rows)
                                {
                                    strASPX += "\r\ntxt" + drKey[0].ToString() + ".Text = dt" + cmbDatasourceForDataGrid.Text + ".Rows[0][" + Convert.ToChar(34) + drKey[0].ToString() + Convert.ToChar(34) + "].ToString();";
                                }
                            }
                            else
                            {
                                foreach (DataRow drKey in dsColumns.Tables[1].Rows)
                                {
                                    strASPX += "\r\ntxt" + drKey[0].ToString() + ".Text = dt" + cmbDatasourceForDataGrid.Text + ".Rows[0][" + Convert.ToChar(34) + drKey[0].ToString() + Convert.ToChar(34) + "].ToString();";
                                }
                            }
                            strASPX += "\r\n}";
                        }
                        else if (strCommand == "Delete")
                        {
                            strASPX += "\r\n";
                            strASPX += "\r\nprotected void dg" + cmbDatasourceForDataGrid.Text + "_DeleteCommand(object source, DataGridCommandEventArgs e)";
                            strASPX += "\r\n{";
                            strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " = new " + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "();";
                            if (bIsProcedure)
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dsColumns.Tables[0].Rows[0][0].ToString() + " = Convert.ToInt64(dg" + cmbDatasourceForDataGrid.Text + ".DataKeys[e.Item.ItemIndex]);";
                            else
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dsColumns.Tables[1].Rows[0][0].ToString() + " = Convert.ToInt64(dg" + cmbDatasourceForDataGrid.Text + ".DataKeys[e.Item.ItemIndex]);";
                            strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager = new " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + "();";
                            strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager." + dsSettings.Tables[0].Rows[0]["DatabaseDelete"].ToString() + cmbDatasourceForDataGrid.Text + "(" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ");";
                            strASPX += "\r\nBindGrid();";
                            strASPX += "\r\n}";
                        }
                        else if (strCommand == "Item")
                        {
                            strASPX += "\r\n";
                            strASPX += "\r\nprotected void dg" + cmbDatasourceForDataGrid.Text + "_ItemCommand(object source, DataGridCommandEventArgs e)";
                            strASPX += "\r\n{";
                            strASPX += "\r\n}";
                        }
                        else if (strCommand == "Edit")
                        {
                            strASPX += "\r\n";
                            strASPX += "\r\nprotected void dg" + cmbDatasourceForDataGrid.Text + "_EditCommand(object source, DataGridCommandEventArgs e)";
                            strASPX += "\r\n{";
                            strASPX += "\r\n}";
                        }
                    }
                    strASPX += "\r\n";
                    strASPX += "\r\nprotected void btnAddNew_Click(object sender, EventArgs e)";
                    strASPX += "\r\n{";
                    strASPX += "\r\nbtnAddNew.Enabled = false;";
                    strASPX += "\r\nbtnAdd.Enabled = true;";
                    strASPX += "\r\nbtnUpdate.Enabled = true;";
                    if (bIsProcedure)
                    {
                        foreach (DataRow drKey in dsColumns.Tables[0].Rows)
                        {
                            strASPX += "\r\ntxt" + drKey[0].ToString() + ".Text = " + Convert.ToChar(34) + "" + Convert.ToChar(34) + ";";
                        }
                    }
                    else
                    {
                        foreach (DataRow drKey in dsColumns.Tables[1].Rows)
                        {
                            strASPX += "\r\ntxt" + drKey[0].ToString() + ".Text = " + +Convert.ToChar(34) + Convert.ToChar(34) + ";";
                        }
                    }
                    strASPX += "\r\n}";
                    strASPX += "\r\n";
                    strASPX += "\r\nprotected void btnAdd_Click(object sender, EventArgs e)";
                    strASPX += "\r\n{";
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + " = new " + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "();";
                    if (bIsProcedure)
                    {
                        foreach (DataRow dr in dsColumns.Tables[0].Rows)
                        {
                            if (dr[1].ToString().ToLower() == "varchar" || dr[1].ToString().ToLower() == "char")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = txt" + dr[0].ToString() + ".Text;";
                            else if (dr[1].ToString().ToLower() == "bigint")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToInt64(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "int")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToInt32(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "bit")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToBoolean(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "datetime")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToDateTime(txt" + dr[0].ToString() + ".Text);";
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dsColumns.Tables[1].Rows)
                        {
                            if (dr[1].ToString().ToLower() == "varchar" || dr[1].ToString().ToLower() == "char")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = txt" + dr[0].ToString() + ".Text;";
                            else if (dr[1].ToString().ToLower() == "bigint")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToInt64(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "int")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToInt32(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "bit")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToBoolean(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "datetime")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "." + dr[0].ToString() + " = Convert.ToDateTime(txt" + dr[0].ToString() + ".Text);";
                        }
                    }
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "Manager = new " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + "();";
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + "Manager." + dsSettings.Tables[0].Rows[0]["DatabaseInsert"].ToString() + cmbDatasourceForDataGrid.Text + "(" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ");";
                    strASPX += "\r\nbtnAdd.Enabled = false;";
                    strASPX += "\r\nbtnAddNew.Enabled = true;";
                    strASPX += "\r\nBindGrid();";
                    strASPX += "\r\n}";
                    strASPX += "\r\n";
                    strASPX += "\r\nprotected void btnUpdate_Click(object sender, EventArgs e)";
                    strASPX += "\r\n{";
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + " = new " + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "();";
                    if (bIsProcedure)
                    {
                        foreach (DataRow dr in dsColumns.Tables[0].Rows)
                        {
                            if (dr[1].ToString().ToLower() == "varchar" || dr[1].ToString().ToLower() == "char")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = txt" + dr[0].ToString() + ".Text;";
                            else if (dr[1].ToString().ToLower() == "bigint")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.ToInt64(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "int")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.ToInt32(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "bit")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.Boolean(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "datetime")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.ToDateTime(txt" + dr[0].ToString() + ".Text);";
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dsColumns.Tables[1].Rows)
                        {
                            if (dr[1].ToString().ToLower() == "varchar" || dr[1].ToString().ToLower() == "char")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = txt" + dr[0].ToString() + ".Text;";
                            else if (dr[1].ToString().ToLower() == "bigint")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.ToInt64(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "int")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.ToInt32(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "bit")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.Boolean(txt" + dr[0].ToString() + ".Text);";
                            else if (dr[1].ToString().ToLower() == "datetime")
                                strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + "." + dr[0].ToString() + " = Convert.ToDateTime(txt" + dr[0].ToString() + ".Text);";
                        }
                    }
                    strASPX += dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + " " + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager = new " + dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString() + "();";
                    strASPX += "\r\n" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + cmbDatasourceForDataGrid.Text + "Manager." + dsSettings.Tables[0].Rows[0]["DatabaseUpdate"].ToString() + cmbDatasourceForDataGrid.Text + "(" + dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString() + dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString() + cmbDatasourceForDataGrid.Text + dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString() + ");";
                    strASPX += "\r\nBindGrid();";
                    strASPX += "\r\nbtnUpdate.Enabled = false;";
                    strASPX += "\r\n}";
                    if (MessageBox.Show("Do you want to create a saperate " + cmbDatasourceForDataGrid.Text + ".aspx.cs file or simply copy the generated code to Clipboard.", "File Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                    {
                        System.IO.StreamWriter swASPXCS = new System.IO.StreamWriter(@"C:\CompleteDatabaseAccess\" + cmbDatasourceForDataGrid.Text + ".aspx.cs");
                        swASPXCS.WriteLine("using System.Web.UI;");
                        swASPXCS.WriteLine("using System.Web.UI.WebControls;");
                        swASPXCS.WriteLine("using System.Web.UI.WebControls.WebParts;");
                        swASPXCS.WriteLine("using System.Web.UI.HtmlControls;");
                        swASPXCS.WriteLine("using Test.Client;");
                        swASPXCS.WriteLine("using Test.Server;");
                        swASPXCS.WriteLine("public partial class Kavitha : System.Web.UI.Page");
                        swASPXCS.WriteLine("{");
                        swASPXCS.WriteLine("    protected void Page_Load(object sender, EventArgs e)");
                        swASPXCS.WriteLine("    {");
                        swASPXCS.WriteLine("        if (!Page.IsPostBack)");
                        swASPXCS.WriteLine("        {");
                        swASPXCS.WriteLine("            BindGrid();");
                        swASPXCS.WriteLine("        }");
                        swASPXCS.WriteLine("    }");
                        swASPXCS.WriteLine(strASPX);
                        swASPXCS.WriteLine("}");
                        swASPXCS.Close();
                    }
                    else
                    {
                        Clipboard.SetDataObject(strASPX);
                    }
                    btnChange.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Select Atleast On Operation (Insert, Update, Delete, Select).", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkInsert.Focus();
                }
            }
            catch (Exception ex)
            {
                insError(ex.ToString());
            }
        }
        #endregion

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