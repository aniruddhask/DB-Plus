using System;
using System.Data;
using System.Data.SqlClient;

namespace CompleteDataBaseAccess
{
    public class clsExcelReport
    {
		private System.Int64 _lGrantID;
		
		public clsExcelReport()
		{}
        public clsExcelReport(System.Int64 GrantID)
		{
			_lGrantID = GrantID;
		}
		
		/// <summary>
		/// This is Properties For GrantID;
		/// </summary>
		public System.Int64 GrantID
		{
			set
			{
				_lGrantID = value;
			}
			get
			{
				return _lGrantID;
			}
		}
        
        /// <summary>
        /// To Get Student Details
        /// </summary>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public DataTable GetStudentDetails(char Flag)
        {
			SqlConnection con = new SqlConnection("user id=sa; pwd=sqlserver2005; initial catalog=TEG; data source=192.168.9.4");
            DataTable dtpStudentMaster_SELECT = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmdpStudentMaster_SELECT = new SqlCommand("pRPT_getStudent", con);
                cmdpStudentMaster_SELECT.CommandType = CommandType.StoredProcedure;
                cmdpStudentMaster_SELECT.Parameters.Add("@Flag", SqlDbType.Char).Value = Flag;
                cmdpStudentMaster_SELECT.Parameters.Add("@GrantID", SqlDbType.BigInt).Value = _lGrantID;
                SqlDataAdapter dapStudentMaster_SELECT = new SqlDataAdapter(cmdpStudentMaster_SELECT);
                dapStudentMaster_SELECT.Fill(dtpStudentMaster_SELECT);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
            return dtpStudentMaster_SELECT;
        }

        /// <summary>
        /// Get Number of Students by Grant
        /// </summary>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public DataTable GetAllStudents(char Flag)
        {
			SqlConnection con = new SqlConnection("user id=sa; pwd=sqlserver2005; initial catalog=TEG; data source=192.168.9.4");
            DataTable dtpStudentMaster_ALL = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmdpStudentMaster_SELECT = new SqlCommand("pRPT_getAllTest", con);
                cmdpStudentMaster_SELECT.CommandType = CommandType.StoredProcedure;
                cmdpStudentMaster_SELECT.Parameters.Add("@Flag", SqlDbType.Char).Value = Flag;
                cmdpStudentMaster_SELECT.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = _lGrantID;
                SqlDataAdapter dapStudentMaster_SELECT = new SqlDataAdapter(cmdpStudentMaster_SELECT);
                dapStudentMaster_SELECT.Fill(dtpStudentMaster_ALL);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
            return dtpStudentMaster_ALL;
        }

        /// <summary>
        /// Get Test Details
        /// </summary>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public DataSet GetTestDetails(char Flag, Int64 strId)
        {
			SqlConnection con = new SqlConnection("user id=sa; pwd=; initial catalog=TEG; data source=.");
            DataSet dsTestMaster_ALL = new DataSet();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmdpStudentMaster_SELECT = new SqlCommand("GetAllResults", con);
                cmdpStudentMaster_SELECT.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dapStudentMaster_SELECT = new SqlDataAdapter(cmdpStudentMaster_SELECT);
                dapStudentMaster_SELECT.Fill(dsTestMaster_ALL);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
            return dsTestMaster_ALL;
        }

    }//Class Close

    public class clsNameValue
    {
        private string _strName;
        private string _strValue;
        public clsNameValue(string Name, string Value)
        {
            _strName = Name;
            _strValue = Value;
        }
        public string cName
        {
            get { return _strName; }
            set { _strName = value; }
        }
        public string cValue
        {
            get { return _strValue; }
            set { _strValue = value; }
        }
    }
}//NameSpace Close
