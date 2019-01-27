using System;
using System.Collections.Generic;
using System.Text;
using Centrum.BD;
using Centrum.BO;
using System.Data;
using System.Data.SqlClient;

namespace Centrum.BR
{
    public class ObjtblAttributeMasterBR
    {
        public ObjtblAttributeMasterBR()
        { }
        /// <summary>
        /// Method to insert record into the database.
        /// </summary>
        /// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool instblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD)
        {
            tblAttributeMasterBO otblAttributeMasterBO = new tblAttributeMasterBO();
            SqlTransaction oTran= clsConnection.BeginTransaction();
            otblAttributeMasterBO.instblAttributeMaster(oObjtblAttributeMasterBD, oTran);
            return true;
        }
        /// <summary>
        /// Method to update the record.
        /// </summary>
        /// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool updtblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD)
        {
            return true;
        }
        /// <summary>
        /// Method to delete record from the database.
        /// </summary>
        /// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool deltblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD)
        {
            return true;
        }
        /// <summary>
        /// Method to get all record from the database.
        /// </summary>
        /// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        /// <returns>DataTable</returns>
        /// <param name="oTran">SqlTransaction</param>
        public DataTable gettblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD)
        {
            throw new Exception("not implemented");
        }
        /// <summary>
        /// Method to get record from the database according to given Id.
        /// </summary>
        /// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        /// <returns>DataTable</returns>
        /// <param name="oTran">SqlTransaction</param>
        public DataTable gettblAttributeMasterByPrimaryId(ObjtblAttributeMasterBD oObjtblAttributeMasterBD)
        {
            throw new Exception("not implemented");
        }
    }
}
