using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lblFileName.Text = openFileDialog1.FileName;
        }

        private void btnGetMethods_Click(object sender, EventArgs e)
        {
            StreamWriter swMethodDetails = new StreamWriter(@"C:\methods1.txt");
            foreach (string strAscx in Directory.GetFiles(@"D:\FAR\Auction.UI\UserControls"))
            {
                if (strAscx.Contains("ascx.cs") && !strAscx.Contains("Report"))
                {
                    StreamReader swCS = new StreamReader(strAscx);
                    swMethodDetails.WriteLine(strAscx);
                    swMethodDetails.WriteLine();
                    swMethodDetails.WriteLine();
                    string strLine = "";
                    string strMethodLine = "";
                    string strBOLine = "";
                    string strBOName = "";
                    string strObjectName = "";
                    Hashtable htBOMethodCollection = new Hashtable();
                    while (strLine != null)
                    {
                        if ((strObjectName == "oUpdateTransactionId" || strObjectName == "") && !strLine.Contains("//") && !strLine.Contains("Session") && strLine.Contains("BO") && !strLine.Contains("BO.") && (strLine.IndexOf("tbl") != -1 || strLine.IndexOf("Gen") != -1))
                        {
                            if (strLine.Contains("tbl"))
                            {
                                int iBOStart = strLine.IndexOf("tbl");
                                strBOLine = strLine.Substring(iBOStart);
                                if (strBOLine.Contains("="))
                                {
                                    int iBOLength = strBOLine.IndexOf(" ");
                                    strBOName = strBOLine.Substring(0, iBOLength).Replace("BD", "BO");
                                    strObjectName = strBOLine.Substring(strBOLine.IndexOf(" ") + 1, strBOLine.IndexOf("=") - strBOLine.IndexOf(" ") - 2);
                                    if (!htBOMethodCollection.Contains(strBOName))
                                    {
                                        ArrayList arrlstMethods = new ArrayList();
                                        htBOMethodCollection.Add(strBOName, arrlstMethods);
                                    }
                                }
                                else
                                    strObjectName = "";
                                //TreeNode tnBO=new TreeNode(strBOName);
                                //if (!treeView1.Nodes.Contains(tnBO))
                                //    treeView1.Nodes.Add(strBOName, strBOName);
                            }
                            //else
                            //{
                            //    int iBOStart = strLine.IndexOf("Gen");
                            //    strBOLine = strLine.Substring(iBOStart);
                            //    int iBOLength = strBOLine.IndexOf(".");
                            //    strBOName = strBOLine.Substring(0, iBOLength);
                            //    //TreeNode tnBO = new TreeNode(strBOName);
                            //    //if (!treeView1.Nodes.Contains(tnBO))
                            //    //    treeView1.Nodes.Add(strBOName, strBOName);
                            //    if (!htBOMethodCollection.Contains(strBOName))
                            //    {
                            //        ArrayList arrlstMethods = new ArrayList();
                            //        htBOMethodCollection.Add(strBOName, arrlstMethods);
                            //    }
                            //}

                            //TreeNode tnMethod = new TreeNode(strMethodName);
                            //if (!treeView1.Nodes.Contains(tnMethod))
                            //    if (!treeView1.Nodes[strBOName].Nodes.Contains(tnMethod))
                            //        treeView1.Nodes[strBOName].Nodes.Add(strMethodName, strMethodName);
                        }
                        else if (strLine.Contains(strObjectName) && strObjectName!="")
                        {
                            int iMethodStart = strLine.IndexOf(strObjectName) + strObjectName.Length;
                            strMethodLine = strLine.Substring(iMethodStart);
                            int iMethodLength = strMethodLine.IndexOf("(");
                            string strMethodName = strMethodLine.Substring(1, iMethodLength-1);
                            ArrayList arrlstMethods1 = (ArrayList)htBOMethodCollection[strBOName];
                            if (!arrlstMethods1.Contains(strMethodName))
                            {
                                arrlstMethods1.Add(strMethodName);
                                htBOMethodCollection[strBOName] = arrlstMethods1;
                            }
                            strObjectName = "";
                        }
                        strLine = swCS.ReadLine();
                    }
                    foreach (DictionaryEntry deBO in htBOMethodCollection)
                    {
                        swMethodDetails.WriteLine(@"        " + deBO.Key.ToString());
                        swMethodDetails.WriteLine();
                        foreach (string strMethodInner in (ArrayList)deBO.Value)
                        {
                            string strProcedureNameToWrite = "";
                            if (deBO.Key.ToString() != "tblUserfillSellerBO" && !deBO.Key.ToString().Contains("=") && !deBO.Key.ToString().Contains("Obj") && !deBO.Key.ToString().Contains("ddl") && !deBO.Key.ToString().Contains("tblAuctionVehicleDetailsBD") && !deBO.Key.ToString().Contains("tblHistory"))
                            {
                                StreamReader srBOToGetProcedureName = new StreamReader(@"D:\FAR\Auction.BO\" + deBO.Key.ToString() + ".cs");
                                string strProcedureName = "";
                                while (strProcedureName != null)
                                {
                                    if (strProcedureName.Contains(strMethodInner))
                                    {
                                        while (strProcedureNameToWrite == "")
                                        {
                                            if (!strProcedureName.Contains("//") && strProcedureName.Contains("SqlCommand("))
                                            {
                                                string strSP = strProcedureName.Substring(strProcedureName.IndexOf("SqlCommand(") + 12);
                                                strProcedureNameToWrite = strSP.Substring(0, strSP.IndexOf(",") - 1);
                                            }
                                            strProcedureName = srBOToGetProcedureName.ReadLine();
                                        }
                                    }
                                    strProcedureName = srBOToGetProcedureName.ReadLine();
                                }
                            }
                            swMethodDetails.WriteLine(@"                        " + strMethodInner + "      -       " + strProcedureNameToWrite);
                        }
                    }
                }
            }
            swMethodDetails.Close();
        }
    }
}