using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Centrum.BO
{
    public class clsConnection
    {
        private static bool _bTransactionStatus = false;
        private static SqlTransaction oTranObj;
        public clsConnection()
        { }

        public static SqlTransaction BeginTransaction()
        {
            try
            {
                if (TransactionStatus)
                    return oTranObj;
                SqlConnection oCon = new SqlConnection(ConfigurationSettings.AppSettings["strConnection"]);
                if (oCon.State == ConnectionState.Closed)
                    oCon.Open();
                oTranObj = oCon.BeginTransaction();
                //oCon.Close();
                TransactionStatus = true;
                //oTranObj = oTran;
                return oTranObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CommitTransaction(SqlTransaction oTran)
        {
            try
            {
                //oTran.Commit();
                oTranObj.Commit();
                TransactionStatus = false;
                return true;
            }
            catch (Exception ex)
            {
                TransactionStatus = false;
                oTranObj.Rollback();
                //oTran.Rollback();
                throw ex;
            }
            finally
            {
                if (oTranObj.Connection != null)
                    oTranObj.Connection.Close();
            }
        }

        public static bool TransactionStatus
        {
            set
            {
                _bTransactionStatus = value;
            }
            get
            {
                return _bTransactionStatus;
            }
        }
    }
}
