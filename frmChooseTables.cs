using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace CompleteDataBaseAccess
{
    public partial class frmChooseTables : Form
    {
        ArrayList _arrlst;
        public frmChooseTables(ArrayList arrlst)
        {
            _arrlst = arrlst;
            InitializeComponent();
        }

        private void frmChooseTables_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string strTable in _arrlst)
                {
                    chklstTables.Items.Add(strTable, true);
                }
                chkAll.Checked = true;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                _arrlst.Clear();
                foreach (string chk in chklstTables.CheckedItems)
                {
                    _arrlst.Add(chk);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chklstTables.Items.Clear();
                foreach (string strTable in _arrlst)
                {
                    chklstTables.Items.Add(strTable, chkAll.Checked);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}