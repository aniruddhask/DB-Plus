using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string strInstalledDate = EncDec.Encrypt("dTimeInstalled", "cDateTime");
            //    EncDec.Decrypt(Microsoft.Win32.Registry.ClassesRoot.GetValue(strInstalledDate).ToString(), "cDateTime");
            //    Application.Exit();
            //}
            //catch
            {
                string strInstalledDateKey = EncDec.Encrypt("dTimeInstalled", "cDateTime");
                string strInstalledDateValue = EncDec.Encrypt(DateTime.Now.Date.ToShortDateString(), "cDateTime");

                string strLastAccessDateKey = EncDec.Encrypt("LastAccessDate", "cDateTime");
                string strLastAccessDateValue = EncDec.Encrypt(DateTime.Now.Date.ToShortDateString(), "cDateTime");

                string strLastRegistrationDateKey = EncDec.Encrypt("LastRegistrationDate", "cDateTime");
                string strLastRegistrationDateValue = EncDec.Encrypt(DateTime.Now.Date.ToShortDateString(), "cDateTime");

                string strRegistrationKey = EncDec.Encrypt("DB2Register", "HDD 0506 Register");
                string strRegistrationValue = EncDec.Encrypt("Unregistered", "HDD 0506 Register");

                string strNumberOfDaysKey = EncDec.Encrypt("NOD", "NumberOfDays");
                string strNumberOfDaysValue = EncDec.Encrypt("10", "NumberOfDays");

                string strUnlimitedKey = EncDec.Encrypt("IsUnlimited", "bBool");
                string strUnlimitedValue = EncDec.Encrypt("0", "bBool");

                HDD oHDD = new HDD();
                Hashtable htHardDiskDetail = oHDD.getInfo();
                string strHDDSerialNumberKey = EncDec.Encrypt("HDD Enc", "HDD 0506");
                string strHDDSerialNumberValue = EncDec.Encrypt(htHardDiskDetail["SerialNumber"].ToString(), "HDD 0506");

                //making an entry to registry for number of days left.
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strNumberOfDaysKey, strNumberOfDaysValue);
                //making an entry to registry for installed date & time.
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strInstalledDateKey, strInstalledDateValue);
                //making an entry to registry for last access date & time.
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strLastAccessDateKey, strInstalledDateValue);
                //making an entry to registry for registering product.
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strRegistrationKey, strRegistrationValue);
                //making an entry to registry for hdd serial number.
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strLastRegistrationDateKey, strLastRegistrationDateValue);
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strUnlimitedKey, strUnlimitedValue);
                Microsoft.Win32.Registry.ClassesRoot.SetValue(strHDDSerialNumberKey, strHDDSerialNumberValue);
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}