using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CompleteDataBaseAccess
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            #region Validation for Expiry
            try
            {
                btnContinue.Enabled = false;
                string strInstalledDateKey = EncDec.Encrypt("dTimeInstalled", "cDateTime");
                string strLastAccessDateKey = EncDec.Encrypt("LastAccessDate", "cDateTime");
                string strLastRegistrationDateKey = EncDec.Encrypt("LastRegistrationDate", "cDateTime");
                string strNumberOfDaysKey = EncDec.Encrypt("NOD", "NumberOfDays");
                string strUnlimitedKey = EncDec.Encrypt("IsUnlimited", "bBool");

                string strLastAccessDateValue = EncDec.Encrypt(DateTime.Now.Date.ToShortDateString(), "cDateTime");

                bool bIsUnlimited = Convert.ToBoolean(Convert.ToInt32(EncDec.Decrypt(Microsoft.Win32.Registry.ClassesRoot.GetValue(strUnlimitedKey).ToString(), "bBool")));
                if (!bIsUnlimited)
                {
                    EncDec.Decrypt(Microsoft.Win32.Registry.ClassesRoot.GetValue(strInstalledDateKey).ToString(), "cDateTime");
                    DateTime dTimeLastAccessDate = Convert.ToDateTime(EncDec.Decrypt(Microsoft.Win32.Registry.ClassesRoot.GetValue(strLastAccessDateKey).ToString(), "cDateTime"));
                    DateTime dTimeLastRegistrationDate = Convert.ToDateTime(EncDec.Decrypt(Microsoft.Win32.Registry.ClassesRoot.GetValue(strLastRegistrationDateKey).ToString(), "cDateTime"));
                    Int32 iNoOfDays = Convert.ToInt32(EncDec.Decrypt(Microsoft.Win32.Registry.ClassesRoot.GetValue(strNumberOfDaysKey).ToString(), "NumberOfDays"));
                    int iNumberOfDaysLeft = ((TimeSpan)dTimeLastRegistrationDate.Date.Subtract(dTimeLastAccessDate.Date)).Days;
                    if (dTimeLastAccessDate > DateTime.Now.Date)
                    {
                        MessageBox.Show("Make sure that your system clock is running properly", "System Type Check Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    if (iNoOfDays - iNumberOfDaysLeft > 0)
                    {
                        if (iNumberOfDaysLeft >= 0)
                        {
                            btnContinue.Enabled = true;
                            lblNoOfDays.Text = Convert.ToString(iNoOfDays - iNumberOfDaysLeft).PadLeft(2, '0');
                            Microsoft.Win32.Registry.ClassesRoot.SetValue(strLastAccessDateKey, strLastAccessDateValue);
                        }
                        else
                        {
                            lblNoOfDays.Text = "00";
                        }
                    }
                }
                else
                {
                    Connection oConnection = new Connection("First");
                    oConnection.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Process.Start(@".\DBSettings.exe");
                Application.Exit();
            }
            #endregion
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                //DataSet ds = new DataSet();
                ////ds.ReadXml(@"C:\abc1.xml");
                ////string strS = ds.GetXmlSchema();
                ////string strX = ds.GetXml();
                //System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("user id=sa; password=sa; initial catalog=tempdb; data source=.");
                //con.Open();
                //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Test WHERE tblId=1", con);
                //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                //DataSet dsDatabase = new DataSet();
                //da.Fill(dsDatabase);
                //Byte []b = StringToByte(dsDatabase.Tables[0].Rows[0]["A"].ToString());
                //ds = new DataSet();
                ////ds.ReadXmlSchema(new MemoryStream(b));
                //Byte[] bd = StringToByte(dsDatabase.Tables[0].Rows[0]["B"].ToString());
                //ds.ReadXml(new MemoryStream(bd));
                Connection oConnection = new Connection("First");
                oConnection.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static byte[] StringToByte(string InString)
        {
            string[] ByteStrings;
            ByteStrings = InString.Split(" ".ToCharArray());
            byte[] ByteOut;
            ByteOut = new byte[ByteStrings.Length - 1];
            for (int i = 0; i == ByteStrings.Length - 1; i++)
            {
                ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]));
            }
            return ByteOut;
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            gbxMain.Visible = false;
            gbxRegister.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                HDD oHDD = new HDD();
                Hashtable htHardDiskDetails = oHDD.getInfo();
                string strSerialInCode = EncDec.Decrypt(txtCode.Text.Substring(0, txtCode.Text.IndexOf("~")), "HDD 0506");
                DateTime dTimeRegistrationTill = Convert.ToDateTime(EncDec.Decrypt(txtCode.Text.Substring(txtCode.Text.IndexOf("~") + 1, txtCode.Text.Length - txtCode.Text.IndexOf("~") - 1), "cDateTime"));

                string strLastAccessDateKey = EncDec.Encrypt("LastAccessDate", "cDateTime");
                string strLastAccessDateValue = EncDec.Encrypt(DateTime.Now.Date.ToShortDateString(), "cDateTime");

                string strLastRegistrationDateKey = EncDec.Encrypt("LastRegistrationDate", "cDateTime");
                string strLastRegistrationDateValue = strLastAccessDateValue;

                string strRegistrationTillKey = EncDec.Encrypt("RegistrationTill", "cDateTime");
                string strRegistrationTillValue = EncDec.Encrypt(dTimeRegistrationTill.ToShortDateString(), "cDateTime");

                DateTime dTimeLastAccessDate = Convert.ToDateTime(strLastAccessDateValue);
                if (dTimeLastAccessDate.Date.CompareTo(DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("Date Time Of Your System Is Not Correct.");
                }
                else
                {
                    if (dTimeRegistrationTill.Date.CompareTo(DateTime.Now.Date) < 0)
                    {
                        MessageBox.Show("The Code You Currently Entered Is Not A Valid Code, \r\nThis Code Is Already Entered On Your Machine. \r\nPlease Register Now For New Code.");
                    }
                    else
                        if (strSerialInCode == htHardDiskDetails["SerialNumber"].ToString())
                        {
                            if (dTimeRegistrationTill.Date.CompareTo(new DateTime(1900, 1, 1)) == 0)
                            {
                                string strUnlimitedKey = EncDec.Encrypt("IsUnlimited", "bBool");
                                string strUnlimitedValue = EncDec.Encrypt("true", "bBool");

                                Microsoft.Win32.Registry.ClassesRoot.SetValue(strUnlimitedKey, strUnlimitedValue);
                            }
                            Microsoft.Win32.Registry.ClassesRoot.SetValue(strLastAccessDateKey, strLastAccessDateValue);
                            Microsoft.Win32.Registry.ClassesRoot.SetValue(strLastRegistrationDateKey, strLastRegistrationDateValue);
                            Microsoft.Win32.Registry.ClassesRoot.SetValue(strRegistrationTillKey, strRegistrationTillValue);
                        }
                        else
                        {
                            MessageBox.Show("Its not a valid code for this machine.");
                            btnContinue.Enabled = false;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not a valid code");
            }
        }

        private void btnGetRegistration_Click(object sender, EventArgs e)
        {
            Registration oRegistration = new Registration();
            oRegistration.ShowInTaskbar = false;
            oRegistration.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            gbxMain.Visible = true;
            gbxRegister.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += .1;
            else
                timer1.Stop();
        }
    }
}