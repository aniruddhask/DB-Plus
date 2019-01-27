using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using DragExtenderProvider;
namespace CompleteDataBaseAccess
{
    public partial class Enterprise : Form
    {
        DragExtender dragExtender1;
        ArrayList arrlstParameters;
        public Enterprise(ArrayList arrlstConnectionString)
        {
            InitializeComponent();
            dragExtender1 = new DragExtender();
            arrlstParameters = arrlstConnectionString;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            //dragExtender1.Form = this;
            //dragExtender1.SetDraggable(this.pnlTables, true);
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItem oAdodItem = new AddItem(arrlstParameters);
            oAdodItem.ShowInTaskbar = false;
            oAdodItem.ShowDialog();
            int iLeft = 5;
            DataSet _oDataSetHoldingTheMainTableData = new DataSet();
            foreach (string strTableName in oAdodItem.arrlstSelectedTables)
            {
                OleDbConnection conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
                try
                {
                    conCC.Open();
                    OleDbCommand oCmd = new OleDbCommand("sp_help " + strTableName, conCC);
                    if (arrlstParameters[3].ToString().ToLower() != "sqloledb")
                    {
                        //reset the connection to mysql to getting all the record from the MySQL for selected database.
                        conCC = new OleDbConnection("User Id=" + arrlstParameters[1].ToString() + "; Password=" + arrlstParameters[2].ToString() + "; Data Source=" + arrlstParameters[0].ToString() + "; Provider=" + arrlstParameters[3].ToString() + "; Initial Catalog=" + arrlstParameters[4].ToString());
                    }
                    //check for connection state.
                    if (conCC.State == ConnectionState.Closed)
                        conCC.Open();
                    //initializing a command for getting all the data of selecte table.
                    OleDbCommand oOleDbCommandSelectDataFromSelectedTable = new OleDbCommand("select * from " + strTableName, conCC);
                    //initializing the data adapter for getting the table data.
                    OleDbDataAdapter oOleDbDataAdapterGetRecordsFromSelectedTable = new OleDbDataAdapter(oOleDbCommandSelectDataFromSelectedTable);
                    //clearing the data from the main dataset which holds the main table records.
                    _oDataSetHoldingTheMainTableData = new DataSet();
                    //filling the main dataset.
                    oOleDbDataAdapterGetRecordsFromSelectedTable.Fill(_oDataSetHoldingTheMainTableData, "dTabels");
                    //increamentor for pannel controls.
                    #region Previous Method to display table's detail.
                    //CheckedListBox chklst = new CheckedListBox();
                    //Label lbl = new Label();
                    //Panel pnl = new Panel();
                    //pnl.Name = "pnl" + strTableName;
                    //pnl.Left = iLeft;

                    //lbl.Name = "lbl" + strTableName;
                    //lbl.Width = 200;
                    //lbl.Height = 14;
                    //lbl.Text = strTableName;
                    //lbl.BackColor = Color.FromArgb(0, 0, 0);
                    //lbl.ForeColor = Color.White;

                    //chklst.Name = strTableName;
                    //chklst.Width = 200;
                    //chklst.Top = 15;
                    //chklst.ForeColor = Color.FromArgb(0, 0, 0);
                    //chklst.MouseMove += new MouseEventHandler(chklst_MouseMove);
                    //DragExtender dragExtender2 = new DragExtender();
                    //dragExtender2.Control = pnl;
                    //dragExtender2.SetDraggable(lbl, true);

                    //chklst.Items.Add("*(All Columns)");
                    //foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    //{
                    //    chklst.Items.Add(objDataColumn.ColumnName.ToString());
                    //}
                    //pnl.Controls.Add(lbl);
                    //pnl.Controls.Add(chklst);
                    //pnlTables.Controls.Add(pnl);
                    #endregion

                    TableView oTableView = new TableView(strTableName);
                    oTableView.Name = strTableName;
                    oTableView.AddColumn("(*) All Columns");
                    //dragExtender1.Control = oTableView;
                    //dragExtender1.SetDraggable(oTableView.Controls[1], true);
                    foreach (DataColumn objDataColumn in _oDataSetHoldingTheMainTableData.Tables[0].Columns)
                    {
                        oTableView.AddColumn(objDataColumn.ColumnName.ToString());
                    }
                    pnlTables.Controls.Add(oTableView);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conCC.Close();
                }
                iLeft += 205;
            }
        }

        void chklst_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
            }
        }

        
    //private  void  frm_MouseUp(object sender,System.Windows.Forms.MouseEventArgs e) 
    //{  
    //    //Checking the Mouse right Button
    //    If (e.Button == MouseButtons.Right)
    //    {
    //        ContextHandler(TextBox1,e);
    //        TextBox1.ContextMenu.Show(TextBox1, new Point(e.X,e.Y));
    //    }

    //}
       

    }



}