using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CompleteDataBaseAccess
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            try
            {
                HDD oHDD = new HDD();
                Hashtable htHDD = oHDD.getInfo();
                string strCode=EncDec.Encrypt(htHDD["SerialNumber"].ToString(), "HDD 0506");
                Uri oUri = new Uri(ConfigurationSettings.AppSettings["strRegistrationUrl"] + "?code=" + strCode);
                wbRegistration.Url = oUri;
                wbRegistration.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}