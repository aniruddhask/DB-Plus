using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class frmRegistrationKey : Form
    {
        public frmRegistrationKey()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProjectName.Text.Trim() == "")
                {
                    MessageBox.Show("Project Name is required.");
                    txtProjectName.Focus();
                    txtProjectName.SelectAll();
                }
                else if (txtRefNo.Text.Trim() == "")
                {
                    MessageBox.Show("Cleint Ref Number is required.");
                    txtRefNo.Focus();
                    txtRefNo.SelectAll();
                }
                else
                {
                    txtKey.Text = EncDec.Encrypt(txtRefNo.Text, txtProjectName.Text + txtRefNo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}