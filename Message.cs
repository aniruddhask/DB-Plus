using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CompleteDataBaseAccess
{
    public partial class Message : Form
    {
        public Message(OleDbConnection ObjConccenction)
        {
            InitializeComponent();
            conCC = ObjConccenction;
        }
        #region Global Variables
        private OleDbConnection conCC;
        ArrayList arrlstTypeId;
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsMessageValid())
                {
                    conCC.Open();
                    OleDbCommand cmdpSometingSpecial_IU = new OleDbCommand("pSometingSpecial_IU", conCC);
                    cmdpSometingSpecial_IU.CommandType = CommandType.StoredProcedure;
                    cmdpSometingSpecial_IU.Parameters.Add("@Flag", OleDbType.Char).Value = 'I';
                    cmdpSometingSpecial_IU.Parameters.Add("@MsgId", OleDbType.BigInt).Value = 0;
                    cmdpSometingSpecial_IU.Parameters.Add("@TypeId", OleDbType.BigInt).Value = Convert.ToInt64(cmbType.SelectedValue);
                    cmdpSometingSpecial_IU.Parameters.Add("@Message", OleDbType.VarChar).Value = txtMsg.Text;
                    cmdpSometingSpecial_IU.Parameters.Add("@UserId", OleDbType.VarChar).Value = txtUser.Text;
                    cmdpSometingSpecial_IU.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conCC.Close();
            }
        }
        private bool IsMessageValid()
        {
            if (cmbType.Text == "-Select-")
            {
                MessageBox.Show("Please Select MessageType First.");
                cmbType.Focus();
                return false;
            }
            else if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter User Name.");
                txtUser.Focus();
                return false;
            }
            else
                return true;
        }
        private void fillMessageType()
        {
            try
            {
                arrlstTypeId = new ArrayList();
                conCC.Open();
                OleDbCommand cmdpGetMessageType = new OleDbCommand("pGetMessageType", conCC);
                cmdpGetMessageType.CommandType = CommandType.StoredProcedure;
                OleDbDataAdapter daMessageType = new OleDbDataAdapter(cmdpGetMessageType);
                DataTable dtMessageType = new DataTable();
                daMessageType.Fill(dtMessageType);
                cmbType.DataSource = dtMessageType;
                cmbType.DisplayMember = "Type";
                cmbType.ValueMember = "TypeId";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conCC.Close();
            }
        }

        private void Message_Load(object sender, EventArgs e)
        {
            fillMessageType();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}