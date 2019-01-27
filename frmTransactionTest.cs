using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Centrum.BD;
using Centrum.BR;

namespace CompleteDataBaseAccess
{
    public partial class frmTransactionTest : Form
    {
        public frmTransactionTest()
        {
            InitializeComponent();
        }

        private void btnTestTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please specify the number of Entries.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int iCounter = 0; iCounter < Convert.ToInt32(textBox1.Text); iCounter++)
                {
                    ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD = new ObjtblAttributeTypeMasterBD();
                    oObjtblAttributeTypeMasterBD.AttributeTypeId = "";
                    oObjtblAttributeTypeMasterBD.CreatedByUserId = "aniruddha singh kushwaha";
                    oObjtblAttributeTypeMasterBD.ModifiedByUserId = "aniruddha singh kushwaha";
                    oObjtblAttributeTypeMasterBD.Name = txtName.Text + iCounter.ToString().PadLeft(4) + DateTime.Now.ToString();
                    oObjtblAttributeTypeMasterBD.Status = false;
                    oObjtblAttributeTypeMasterBD.TypeOf = "Aniruddha";
                    ObjtblAttributeTypeMasterBR oObjtblAttributeTypeMasterBR = new ObjtblAttributeTypeMasterBR();
                    oObjtblAttributeTypeMasterBR.instblAttributeTypeMaster(oObjtblAttributeTypeMasterBD);
                }
                MessageBox.Show("Completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmTransactionTest_Load(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = System.Environment.MachineName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TcpIPWMI o = new TcpIPWMI();
                o.ListIP();
                //o.setIP("192.168.0.48", "255.255.255.0", "192.168.0.1");
                o.setIP("192.168.0.47", "255.255.255.0", "192.168.0.1");
                o.ListIP();
                o.setIP("192.168.0.49", "255.255.0.0", "192.168.2.1");
                o.ListIP();
                o.setIP("192.168.0.48", "255.255.255.0", "192.168.0.1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}