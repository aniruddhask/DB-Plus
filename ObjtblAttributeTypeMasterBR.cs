using System;
using System.Collections.Generic;
using System.Text;
using Centrum.BD;
using Centrum.BO;
using System.Data;
using System.Data.SqlClient;

namespace Centrum.BR
{
    class ObjtblAttributeTypeMasterBR
    {

        //define constructor.
        public ObjtblAttributeTypeMasterBR()
        { }
        /// <summary>
        /// Method to insert record into the database.
        /// </summary>
        /// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool instblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD)
        {
            ObjtblAttributeMasterBD oObjtblAttributeMasterBD = new ObjtblAttributeMasterBD();
            oObjtblAttributeMasterBD.AttributeId = "";
            oObjtblAttributeMasterBD.CreatedByUserId = "aniruddha singh kushwaha";
            oObjtblAttributeMasterBD.Description = "aniruddha singh kushwahaaniruddha singh kushwahaaniruddha singh kushwahaaniruddha singh kushwahaaniruddha singh kushwaha";
            oObjtblAttributeMasterBD.DisplayTo = "aniruddha";
            oObjtblAttributeMasterBD.IsPredefined = false;
            oObjtblAttributeMasterBD.IsSearchable = false;
            oObjtblAttributeMasterBD.ModifiedByUserId = "aniruddha singh kushwaha";
            oObjtblAttributeMasterBD.Name = "Aniruddha Lalan";
            oObjtblAttributeMasterBD.Status = false;
            ObjtblAttributeMasterBR oObjtblAttributeMasterBR = new ObjtblAttributeMasterBR();

            tblAttributeTypeMasterBO otblAttributeTypeMasterBO = new tblAttributeTypeMasterBO();
            SqlTransaction oTran = clsConnection.BeginTransaction();
            otblAttributeTypeMasterBO.instblAttributeTypeMaster(oObjtblAttributeTypeMasterBD, otblAttributeTypeMasterBO.cTransaction);

            oObjtblAttributeMasterBD.AttributeTypeId = oObjtblAttributeTypeMasterBD.AttributeTypeId;

            oObjtblAttributeMasterBR.instblAttributeMaster(oObjtblAttributeMasterBD);
            clsConnection.CommitTransaction(otblAttributeTypeMasterBO.cTransaction);
            return true;
        }
        /// <summary>
        /// Method to update the record.
        /// </summary>
        /// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool updtblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD)
        {
            return false;
        }
        /// <summary>
        /// Method to delete record from the database.
        /// </summary>
        /// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool deltblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD)
        {
            return false;
        }
        /// <summary>
        /// Method to get all record from the database.
        /// </summary>
        /// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        /// <returns>DataTable</returns>
        /// <param name="oTran">SqlTransaction</param>
        public DataTable gettblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD)
        {
            throw new Exception("not implemented");
        }
        /// <summary>
        /// Method to get record from the database according to given Id.
        /// </summary>
        /// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        /// <returns>DataTable</returns>
        /// <param name="oTran">SqlTransaction</param>
        public DataTable gettblAttributeTypeMasterByPrimaryId(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD)
        {
            throw new Exception("not implemented");
        }
    }
}
