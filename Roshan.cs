using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class Roshan : Form
    {
        public Roshan()
        {
            InitializeComponent();
        }

        private void Roshan_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dsMainDataCollections = new DataSet();
                Hashtable htRelationship = new Hashtable();
                dsMainDataCollections.ReadXml(@"C:\Documents and Settings\Administrator\Desktop\Roshan Srivastava.xml");
                foreach (DataTable dtIndex in dsMainDataCollections.Tables)
                {
                    DataRelationCollection drcIsParent = dsMainDataCollections.Tables[dtIndex.TableName].ParentRelations;
                    if (drcIsParent.Count > 0)
                    {
                        string strParentTableName = drcIsParent[0].ToString().Replace("_" + dtIndex.TableName, "");
                        if (strParentTableName.ToLower() != "Loan_Application".ToLower())
                        {
                            if (htRelationship.Contains(strParentTableName))
                            {
                                DataSet ds = new DataSet();
                                ds = (DataSet)(htRelationship[strParentTableName]);
                                DataTable dt = new DataTable();
                                dt=dtIndex.Clone();
                                ds.Tables.Add(dt);
                                htRelationship[strParentTableName] = ds;
                            }
                            else
                            {
                                DataSet ds = new DataSet();
                                DataTable dt = new DataTable();
                                dt = dtIndex.Clone();
                                ds.Tables.Add(dt);
                                htRelationship.Add(strParentTableName, ds);
                            }
                        }
                    }
                }
                foreach (DictionaryEntry de in htRelationship)
                {
                    MessageBox.Show(de.Key.ToString() + "No of Tables: " + ((DataSet)de.Value).Tables.Count.ToString());
                }
/*
ApplicantId
EnquiryId
FirstName
MiddleName
LastName
Suffix
ApplicantType
Gender
SS#
DOB
Age
CitizensResidencyType
SchoolYears
EmploymentType
IncomeEmploymentMonthly
DependentCount
HomeNumber
CellPhone
Email
*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}