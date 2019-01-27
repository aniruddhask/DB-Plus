using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        DataSet dsSettings;
        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                fillValues();
            }
            catch
            {
            }
        }

        private void fillValues()
        {
            dsSettings = new DataSet();
            dsSettings.ReadXml(@".\SettingForDBPlus.xml");
            txtComment.Text = dsSettings.Tables[0].Rows[0]["CommentForProcedure"].ToString();
            txtDPost.Text = dsSettings.Tables[0].Rows[0]["DeletePost"].ToString();
            txtDPre.Text = dsSettings.Tables[0].Rows[0]["DeletePre"].ToString();
            txtIPost.Text = dsSettings.Tables[0].Rows[0]["InsertPost"].ToString();
            txtIPre.Text = dsSettings.Tables[0].Rows[0]["InsertPre"].ToString();
            txtIUPost.Text = dsSettings.Tables[0].Rows[0]["InsertUpdatePost"].ToString();
            txtIUPre.Text = dsSettings.Tables[0].Rows[0]["InsertUpdatePre"].ToString();
            txtSPost.Text = dsSettings.Tables[0].Rows[0]["SelectPost"].ToString();
            txtSPre.Text = dsSettings.Tables[0].Rows[0]["SelectPre"].ToString();
            cmbReturn.Text = dsSettings.Tables[0].Rows[0]["SelectStore"].ToString();

            txtInsert.Text = dsSettings.Tables[0].Rows[0]["DatabaseInsert"].ToString();
            txtUpdate.Text = dsSettings.Tables[0].Rows[0]["DatabaseUpdate"].ToString();
            txtDelete.Text = dsSettings.Tables[0].Rows[0]["DatabaseDelete"].ToString();
            txtSelect.Text = dsSettings.Tables[0].Rows[0]["DatabaseSelect"].ToString();
            txtChecking.Text = dsSettings.Tables[0].Rows[0]["DatabaseChecking"].ToString();
            txtNormal.Text = dsSettings.Tables[0].Rows[0]["Normal"].ToString();
            txtPropertyLayer.Text = dsSettings.Tables[0].Rows[0]["Client"].ToString();
            txtDataLayer.Text = dsSettings.Tables[0].Rows[0]["Server"].ToString();
            txtClassPost.Text = dsSettings.Tables[0].Rows[0]["ClassPostfix"].ToString();
            txtClassPre.Text = dsSettings.Tables[0].Rows[0]["ClassPrefix"].ToString();
            txtObjectInitial.Text = dsSettings.Tables[0].Rows[0]["ObjectInitial"].ToString();
            txtPropertyPost.Text = dsSettings.Tables[0].Rows[0]["PropertyClassPostfix"].ToString();
            txtPropertyPre.Text = dsSettings.Tables[0].Rows[0]["PropertyClassPrefix"].ToString();
 
            txtMySQLDSN.Text = dsSettings.Tables[0].Rows[0]["DSN"].ToString();
            chkData.Checked = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["IsSameServer"].ToString());
            chkProperty.Checked = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["IsSameClient"].ToString());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            DataRow drNewSetting = dsSettings.Tables[0].NewRow();
            drNewSetting["CommentForProcedure"] = txtComment.Text;
            drNewSetting["DeletePost"] = txtDPost.Text;
            drNewSetting["DeletePre"] = txtDPre.Text;
            drNewSetting["InsertPost"] = txtIPost.Text;
            drNewSetting["InsertPre"] = txtIPre.Text;
            drNewSetting["InsertUpdatePost"] = txtIUPost.Text;
            drNewSetting["InsertUpdatePre"] = txtIUPre.Text;
            drNewSetting["SelectPost"] = txtSPost.Text;
            drNewSetting["SelectPre"] = txtSPre.Text;
            drNewSetting["SelectStore"] = cmbReturn.Text;

            drNewSetting["DatabaseInsert"] = txtInsert.Text;
            drNewSetting["DatabaseUpdate"] = txtUpdate.Text;
            drNewSetting["DatabaseDelete"] = txtDelete.Text;
            drNewSetting["DatabaseSelect"] = txtSelect.Text;
            drNewSetting["DatabaseChecking"] = txtChecking.Text;
            drNewSetting["Normal"] = txtNormal.Text;
            if (chkProperty.Checked)
                drNewSetting["Client"] = txtNormal.Text;
            else
                drNewSetting["Client"] = txtPropertyLayer.Text;
            if (chkData.Checked)
                drNewSetting["Server"] = txtNormal.Text;
            else
                drNewSetting["Server"] = txtDataLayer.Text;
            drNewSetting["IsSameServer"] = chkData.Checked.ToString();
            drNewSetting["IsSameClient"] = chkProperty.Checked.ToString();
            drNewSetting["ClassPrefix"] = txtClassPre.Text;
            drNewSetting["ClassPostfix"] = txtClassPost.Text;
            drNewSetting["ObjectInitial"] = txtObjectInitial.Text;
            drNewSetting["PropertyClassPrefix"] = txtPropertyPre.Text;
            drNewSetting["PropertyClassPostfix"] = txtPropertyPost.Text;

            drNewSetting["DSN"] = txtMySQLDSN.Text;

            dsSettings.Tables[0].Rows.RemoveAt(0);
            dsSettings.Tables[0].Rows.Add(drNewSetting);
            System.IO.File.Delete(@".\SettingForDBPlus.xml");
            dsSettings.WriteXml(@".\SettingForDBPlus.xml");
            MessageBox.Show("Settings Updated Successfully.");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Do you want to restore the settings to default", "Default Setting Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr.ToString() == "Yes")
                {
                    DataRow drNewSetting = dsSettings.Tables[0].NewRow();
                    drNewSetting["CommentForProcedure"] = "";
                    drNewSetting["DeletePost"] = "_D";
                    drNewSetting["DeletePre"] = "p";
                    drNewSetting["InsertPost"] = "_I";
                    drNewSetting["InsertPre"] = "p";
                    drNewSetting["InsertUpdatePost"] = "_IU";
                    drNewSetting["InsertUpdatePre"] = "p";
                    drNewSetting["SelectPost"] = "_S";
                    drNewSetting["SelectPre"] = "p";
                    drNewSetting["SelectStore"] = "DataTable";
                    drNewSetting["DatabaseInsert"] = "ins";
                    drNewSetting["DatabaseUpdate"] = "upd";
                    drNewSetting["DatabaseDelete"] = "del";
                    drNewSetting["DatabaseSelect"] = "get";
                    drNewSetting["DatabaseChecking"] = "ifExisting";
                    drNewSetting["Normal"] = "";
                    drNewSetting["Client"] = "Test.Client";
                    drNewSetting["Server"] = "Test.Server";
                    drNewSetting["IsSameServer"] = "false";
                    drNewSetting["IsSameClient"] = "false";
                    drNewSetting["ClassPrefix"] = "";
                    drNewSetting["ClassPostfix"] = "";
                    drNewSetting["ObjectInitial"] = "o";
                    drNewSetting["PropertyClassPrefix"] = "Obj";
                    drNewSetting["PropertyClassPostfix"] = "";
                    drNewSetting["DSN"] = "sMySql";

                    dsSettings.Tables[0].Rows.RemoveAt(0);
                    dsSettings.Tables[0].Rows.Add(drNewSetting);
                    System.IO.File.Delete(@".\SettingForDBPlus.xml");
                    dsSettings.WriteXml(@".\SettingForDBPlus.xml");
                    MessageBox.Show("Successfull.");
                    fillValues();
                }
            }
            catch
            {
            }
        }
    }
}