using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Collections;

namespace CompleteDataBaseAccess
{
    public partial class frmCreateProcedure : Form
    {
        OracleConnection con = new OracleConnection();
        Hashtable htDataTypes = new Hashtable();

        public frmCreateProcedure()
        {
            InitializeComponent();
        }

        private void frmCreateProcedure_Load(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = "User Id=scott;Password=tiger;Data Source=Volvo;";
                FillTables();
                LoadDataTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadDataTypes()
        {
            DataSet dsTypes = new DataSet("Types");
            dsTypes.ReadXml(@".\Types.xml");
            foreach (DataRow dr in dsTypes.Tables[0].Rows)
            {
                htDataTypes.Add(dr[0], dr[1]);
            }

            //htDataTypes.Add("number", "int");
            //htDataTypes.Add("varchar2", "string");
            //htDataTypes.Add("date", "DateTime");
            //htDataTypes.Add("float", "float");
            //htDataTypes.Add("nvarchar2", "string");
            //htDataTypes.Add("nvarchar", "string");
            //htDataTypes.Add("number", "float");
            //htDataTypes.Add("number", "float");
        }

        private void FillTables()
        {
            OracleCommand OComm = new OracleCommand("select * from tab where tabtype = 'TABLE' ORDER BY TName", con);
            OComm.CommandType = CommandType.Text;
            OracleDataAdapter daEmpInfo = new OracleDataAdapter(OComm);
            DataTable dtTables = new DataTable();
            daEmpInfo.Fill(dtTables);
            cmbTables.DataSource = dtTables;
            cmbTables.DisplayMember = "TName";
            cmbTables.ValueMember = "TName";
        }


        private string GetProcedureCode(string TableName)
        {
            #region Create SP
            string strCompleteSQL = "";
            string strColumns = "";
            string strValues = "";
            string strIdColumn = "";
            OracleCommand OComm = new OracleCommand("SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, DATA_LENGTH, NULLABLE, COLUMN_ID from ALL_TAB_COLUMNS WHERE OWNER = 'SCOTT' AND TABLE_NAME = '" + TableName + "'", con);
            OComm.CommandType = CommandType.Text;
            OracleDataAdapter daEmpInfo = new OracleDataAdapter(OComm);
            DataTable dtColumns = new DataTable();
            daEmpInfo.Fill(dtColumns);


            foreach (DataRow drColumn in dtColumns.Rows)
            {
                //strCompleteSQL += "\r\n\r\nCREATE TABLE " + drText["TABLE_NAME"].ToString() + "\r\n(";
                if (drColumn["COLUMN_ID"].ToString() == "1")
                {
                    strIdColumn = drColumn["COLUMN_NAME"].ToString();
                    strCompleteSQL += "\r\n\r\nCREATE OR REPLACE PROCEDURE SP_" + drColumn["TABLE_NAME"].ToString() + "_I\r\n(";
                    strCompleteSQL += "\r\np_" + drColumn["COLUMN_NAME"].ToString() + " OUT " + drColumn["TABLE_NAME"].ToString() + "." + drColumn["COLUMN_NAME"].ToString() + "%TYPE";
                    strColumns = drColumn["COLUMN_NAME"].ToString();
                    strValues = drColumn["TABLE_NAME"].ToString() + "_SEQ.NEXTVAL";
                    //strCompleteSQL += drText["COLUMN_NAME"].ToString() + " " + drText["DATA_TYPE"].ToString() + "(" + drText["DATA_LENGTH"].ToString() + "),\r\n";
                }
                else
                {
                    strCompleteSQL += ",\r\np_" + drColumn["COLUMN_NAME"].ToString() + " IN " + drColumn["TABLE_NAME"].ToString() + "." + drColumn["COLUMN_NAME"].ToString() + "%TYPE";
                    strColumns += ", " + drColumn["COLUMN_NAME"].ToString();
                    strValues += ", p_" + drColumn["COLUMN_NAME"].ToString();
                    //strCompleteSQL += drText["COLUMN_NAME"].ToString() + " " + drText["DATA_TYPE"].ToString() + "(" + drText["DATA_LENGTH"].ToString() + "),\r\n";
                }
            }
            strCompleteSQL += "\r\n)";
            strCompleteSQL += "\r\nAS";
            strCompleteSQL += "\r\nBEGIN";
            strCompleteSQL += "\r\n INSERT INTO " + TableName + " (" + strColumns + ")";
            strCompleteSQL += "\r\n     VALUES (" + strValues + ");";
            strCompleteSQL += "\r\n COMMIT;";
            strCompleteSQL += "\r\nSELECT " + TableName + "_SEQ.CURRVAL INTO p_" + strIdColumn + " FROM DUAL;";
            strCompleteSQL += "\r\nEND;";
            return strCompleteSQL;
            #endregion

        }

        private void btnCreateProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProcedureType.Text == "INSERT")
                    txtOutput.Text = GetProcedureCode(cmbTables.Text);
                else if (cboProcedureType.Text == "UPDATE")
                    txtOutput.Text = GetProcedureCodeUpdate(cmbTables.Text);
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGenerateBusinessData_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Text = GetBD(cmbTables.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string GetBD(string TableName)
        {
            try
            {
                OracleCommand OComm = new OracleCommand("SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, DATA_LENGTH, NULLABLE, COLUMN_ID from ALL_TAB_COLUMNS WHERE OWNER = 'SCOTT' AND TABLE_NAME = '" + TableName + "'", con);
                OComm.CommandType = CommandType.Text;
                OracleDataAdapter daEmpInfo = new OracleDataAdapter(OComm);
                DataTable dtColumns = new DataTable();
                daEmpInfo.Fill(dtColumns);
                string strOut = "";
                strOut += "#region Private Members\r\n";
                foreach (DataRow drColumn in dtColumns.Rows)
                {
                    strOut += "\tprivate " + htDataTypes[drColumn["DATA_TYPE"].ToString().ToLower()].ToString() + " _" + drColumn["COLUMN_NAME"].ToString() + ";\r\n";
                }
                strOut += "#endregion\r\n\r\n";
                strOut += "#region Public Properties\r\n";
                foreach (DataRow drColumn in dtColumns.Rows)
                {
                    strOut += "\r\npublic " + htDataTypes[drColumn["DATA_TYPE"].ToString().ToLower()].ToString() + " " + drColumn["COLUMN_NAME"].ToString() + "\r\n";
                    strOut += "{\r\n";
                    strOut += "\tset\r\n";
                    strOut += "\t{\r\n";
                    strOut += "\t\t_" + drColumn["COLUMN_NAME"].ToString() + " = value;\r\n";
                    strOut += "\t}\r\n";
                    strOut += "\tget\r\n";
                    strOut += "\t{\r\n";
                    strOut += "\t\treturn " + drColumn["COLUMN_NAME"].ToString() + ";\r\n";
                    strOut += "\t}\r\n";
                    strOut += "}\r\n";
                }
                strOut += "#endregion";
                return strOut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetProcedureCodeUpdate(string TableName)
        {
            #region Create SP
            string strCompleteSQL = "";
            string strColumns = "";
            string strValues = "";
            string strIdColumn = "";
            OracleCommand OComm = new OracleCommand("SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, DATA_LENGTH, NULLABLE, COLUMN_ID from ALL_TAB_COLUMNS WHERE OWNER = 'SCOTT' AND TABLE_NAME = '" + TableName + "'", con);
            OComm.CommandType = CommandType.Text;
            OracleDataAdapter daEmpInfo = new OracleDataAdapter(OComm);
            DataTable dtColumns = new DataTable();
            daEmpInfo.Fill(dtColumns);

            strCompleteSQL += "\r\n\r\nCREATE OR REPLACE PROCEDURE SP_" + TableName + "_U\r\n(";
            strValues += "\r\n\tUPDATE " + TableName + "\tSET\r\n";
            foreach (DataRow drColumn in dtColumns.Rows)
            {
                if (drColumn["COLUMN_ID"].ToString() == "1")
                {
                    strIdColumn = "p_" + drColumn["COLUMN_NAME"].ToString();
                    strColumns = "\r\n\tWHERE " + drColumn["COLUMN_NAME"].ToString() + " = p_" + drColumn["COLUMN_NAME"].ToString() + ";";
                }
                strCompleteSQL += "\r\np_" + drColumn["COLUMN_NAME"].ToString() + " IN " + drColumn["TABLE_NAME"].ToString() + "." + drColumn["COLUMN_NAME"].ToString() + "%TYPE,";
                strValues += "\t\t" + drColumn["COLUMN_NAME"].ToString() + " = p_" + drColumn["COLUMN_NAME"].ToString() + ",\r\n";
            }
            strCompleteSQL += "\r\np_RETVAL OUT NUMBER\r\n)";
            strCompleteSQL += "\r\nAS";
            strCompleteSQL += "\r\nBEGIN";
            strCompleteSQL += "\r\n " + strValues.Substring(0, strValues.LastIndexOf(',')) + strColumns;
            strCompleteSQL += "\r\n COMMIT;";
            strCompleteSQL += "\r\n\tSELECT " + strIdColumn + " INTO p_RETVAL FROM DUAL;";
            strCompleteSQL += "\r\nEND;";
            return strCompleteSQL;
            #endregion

        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtOutput.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}