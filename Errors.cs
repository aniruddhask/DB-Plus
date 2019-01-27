using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class Errors : Form
    {
        public Errors()
        {
            InitializeComponent();
        }
        int iIncrementar = 0;
        DataSet ds = new DataSet();        
        private void btnNext_Click(object sender, EventArgs e)
        {                  
            if (iIncrementar < ds.Tables[0].Rows.Count)
            {
                iIncrementar++;
                txtError.Text = ds.Tables[0].Rows[iIncrementar][0].ToString();
                txtDate.Text = ds.Tables[0].Rows[iIncrementar][1].ToString();
                checkForEnableDisableButtons();
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {            
            if ((iIncrementar) >0)
            {
                iIncrementar--;
                txtError.Text = ds.Tables[0].Rows[iIncrementar][0].ToString();
                txtDate.Text = ds.Tables[0].Rows[iIncrementar][1].ToString();
                btnNext.Enabled = true;
                btnLast.Enabled = true;
                checkForEnableDisableButtons();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            txtError.Text = ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1][0].ToString();
            txtDate.Text = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1].ToString();
            iIncrementar = ds.Tables[0].Rows.Count-1;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            checkForEnableDisableButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {             
            ds.ReadXml(@".\CompleteDataBaseErrors.xml");
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            iIncrementar = 1;
            txtError.Text = ds.Tables[0].Rows[0][0].ToString();
            txtDate.Text = ds.Tables[0].Rows[0][1].ToString();
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            checkForEnableDisableButtons();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void checkForEnableDisableButtons()
        {
            if (iIncrementar == 0)
                btnPrevious.Enabled = false;
            else
                btnPrevious.Enabled = true;

            if (iIncrementar == ds.Tables[0].Rows.Count - 1)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
        }
    }
}