using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Centrum.BD;


namespace Centrum.BO
{
    public class tblAttributeTypeMasterBO
    {
        SqlTransaction oTran;
        //define constructor.
        public tblAttributeTypeMasterBO()
        { }
        /// <summary>
        /// Method to insert record into the database.
        /// </summary>
        /// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool instblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD, SqlTransaction oTran)
        {
            oTran = clsConnection.BeginTransaction();
            try
            {
                // creating a command object to communicate with database & initializing command and connection to the object.
                SqlCommand cmdusptblAttributeTypeMaster_IU = new SqlCommand("usptblAttributeTypeMaster_IU");
                //writing trace information writing trace log before command type association
                // defining the command type.
                cmdusptblAttributeTypeMaster_IU.CommandType = CommandType.StoredProcedure;
                //writing trace information writing trace log before transaction association
                //Assigning transaction reference to this command object.
                cmdusptblAttributeTypeMaster_IU.Transaction = oTran;
                //writing trace information writing trace log before Associating connection
                //Associating connection to this command object from tansaction object.
                cmdusptblAttributeTypeMaster_IU.Connection = oTran.Connection;
                //writing trace information writing trace log before adding @Flag parameter with this command
                // adding parameter with name @Flag to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@Flag", SqlDbType.Char).Value = 'I';
                //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
                // adding parameter with name @AttributeTypeId to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.AttributeTypeId;
                //writing trace information writing trace log before adding @Name parameter with this command
                // adding parameter with name @Name to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@Name", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.Name;
                //writing trace information writing trace log before adding @TypeOf parameter with this command
                // adding parameter with name @TypeOf to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@TypeOf", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.TypeOf;
                //writing trace information writing trace log before adding @Status parameter with this command
                // adding parameter with name @Status to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@Status", SqlDbType.Bit).Value = oObjtblAttributeTypeMasterBD.Status;
                //writing trace information writing trace log before adding @CreatedDateTime parameter with this command
                // adding parameter with name @CreatedDateTime to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@CreatedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeTypeMasterBD.CreatedDateTime;
                //writing trace information writing trace log before adding @CreatedByUserId parameter with this command
                // adding parameter with name @CreatedByUserId to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@CreatedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.CreatedByUserId;
                //writing trace information writing trace log before adding @LastModifiedDateTime parameter with this command
                // adding parameter with name @LastModifiedDateTime to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@LastModifiedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeTypeMasterBD.LastModifiedDateTime;
                //writing trace information writing trace log before adding @ModifiedByUserId parameter with this command
                // adding parameter with name @ModifiedByUserId to the command.
                cmdusptblAttributeTypeMaster_IU.Parameters.Add("@ModifiedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.ModifiedByUserId;
                //writing trace information befor execution of the command
                //executing the command to open connection.
                oObjtblAttributeTypeMasterBD.AttributeTypeId = Convert.ToString(cmdusptblAttributeTypeMaster_IU.ExecuteScalar());
                //return true in case of successfully done.
                return true;
            }
            catch (Exception ex)
            {
                //writing trace information  for rollback transaction
                //rollback transaction.
                oTran.Rollback();
                //writing error log
                //throw exception.
                throw ex;
            }
        }
        ///// <summary>
        ///// Method to update the record.
        ///// </summary>
        ///// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        ///// <returns>bool</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public bool updtblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the updtblAttributeTypeMaster method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeTypeMaster_IU = new SqlCommand("usptblAttributeTypeMaster_IU");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeTypeMaster_IU.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeTypeMaster_IU.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeTypeMaster_IU.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @Flag parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Flag with this command object.");
        //        // adding parameter with name @Flag to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@Flag", SqlDbType.Char).Value = 'U';
        //        //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeTypeId with this command object.");
        //        // adding parameter with name @AttributeTypeId to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.AttributeTypeId;
        //        //writing trace information writing trace log before adding @Name parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Name with this command object.");
        //        // adding parameter with name @Name to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@Name", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.Name;
        //        //writing trace information writing trace log before adding @TypeOf parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @TypeOf with this command object.");
        //        // adding parameter with name @TypeOf to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@TypeOf", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.TypeOf;
        //        //writing trace information writing trace log before adding @Status parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Status with this command object.");
        //        // adding parameter with name @Status to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@Status", SqlDbType.Bit).Value = oObjtblAttributeTypeMasterBD.Status;
        //        //writing trace information writing trace log before adding @CreatedDateTime parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @CreatedDateTime with this command object.");
        //        // adding parameter with name @CreatedDateTime to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@CreatedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeTypeMasterBD.CreatedDateTime;
        //        //writing trace information writing trace log before adding @CreatedByUserId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @CreatedByUserId with this command object.");
        //        // adding parameter with name @CreatedByUserId to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@CreatedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.CreatedByUserId;
        //        //writing trace information writing trace log before adding @LastModifiedDateTime parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @LastModifiedDateTime with this command object.");
        //        // adding parameter with name @LastModifiedDateTime to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@LastModifiedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeTypeMasterBD.LastModifiedDateTime;
        //        //writing trace information writing trace log before adding @ModifiedByUserId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @ModifiedByUserId with this command object.");
        //        // adding parameter with name @ModifiedByUserId to the command.
        //        cmdusptblAttributeTypeMaster_IU.Parameters.Add("@ModifiedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.ModifiedByUserId;
        //        //writing trace information befor execution of the command
        //        CentrumLog.WriteInformation("Trace Information", 0, "Executing command of updtblAttributeTypeMaster method.");
        //        //executing the command to open connection.
        //        cmdusptblAttributeTypeMaster_IU.ExecuteNonQuery();
        //        //return true in case of sucessfully done.
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in updtblAttributeTypeMaster method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "updtblAttributeTypeMaster: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// Method to delete record from the database.
        ///// </summary>
        ///// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        ///// <returns>bool</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public bool deltblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the deltblAttributeTypeMaster method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeTypeMaster_D = new SqlCommand("usptblAttributeTypeMaster_D");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeTypeMaster_D.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeTypeMaster_D.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeTypeMaster_D.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeTypeId with this command object.");
        //        // adding parameter with name @AttributeTypeId to the command.
        //        cmdusptblAttributeTypeMaster_D.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.AttributeTypeId;
        //        //writing trace information befor execution of the command
        //        CentrumLog.WriteInformation("Trace Information", 0, "Executing command of deltblAttributeTypeMaster method.");
        //        //executing the command to open connection.
        //        cmdusptblAttributeTypeMaster_D.ExecuteNonQuery();
        //        //returns true in case of success.
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in deltblAttributeTypeMaster method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "deltblAttributeTypeMaster: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// Method to get all record from the database.
        ///// </summary>
        ///// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        ///// <returns>DataTable</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public DataTable gettblAttributeTypeMaster(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the gettblAttributeTypeMaster method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeTypeMaster_S = new SqlCommand("usptblAttributeTypeMaster_S");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeTypeMaster_S.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeTypeMaster_S.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeTypeMaster_S.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @Flag parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Flag with this command object.");
        //        // adding parameter with name @Flag to the command.
        //        cmdusptblAttributeTypeMaster_S.Parameters.Add("@Flag", SqlDbType.Char).Value = 'A';
        //        //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeTypeId with this command object.");
        //        // adding parameter with name @AttributeTypeId to the command.
        //        cmdusptblAttributeTypeMaster_S.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.AttributeTypeId;
        //        //creating the adaptor object to get data from the database.
        //        SqlDataAdapter dausptblAttributeTypeMaster_S = new SqlDataAdapter(cmdusptblAttributeTypeMaster_S);
        //        //creating the datatable object to hold data from the database.
        //        DataTable dtusptblAttributeTypeMaster_S = new DataTable();
        //        //fill the datatable with data.
        //        dausptblAttributeTypeMaster_S.Fill(dtusptblAttributeTypeMaster_S);
        //        //return datatable.
        //        return dtusptblAttributeTypeMaster_S;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in gettblAttributeTypeMaster method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "gettblAttributeTypeMaster: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// Method to get record from the database according to given Id.
        ///// </summary>
        ///// <param name="oObjtblAttributeTypeMasterBD">ObjtblAttributeTypeMasterBD</param>
        ///// <returns>DataTable</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public DataTable gettblAttributeTypeMasterByPrimaryId(ObjtblAttributeTypeMasterBD oObjtblAttributeTypeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the gettblAttributeTypeMasterByPrimaryId method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeTypeMaster_S = new SqlCommand("usptblAttributeTypeMaster_S");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeTypeMaster_S.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeTypeMaster_S.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeTypeMaster_S.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @Flag parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Flag with this command object.");
        //        // adding parameter with name @Flag to the command.
        //        cmdusptblAttributeTypeMaster_S.Parameters.Add("@Flag", SqlDbType.Char).Value = 'S';
        //        //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeTypeId with this command object.");
        //        // adding parameter with name @AttributeTypeId to the command.
        //        cmdusptblAttributeTypeMaster_S.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeTypeMasterBD.AttributeTypeId;
        //        //creating the adaptor object to get data from the database.
        //        SqlDataAdapter dausptblAttributeTypeMaster_S = new SqlDataAdapter(cmdusptblAttributeTypeMaster_S);
        //        //creating the datatable object to hold data from the database.
        //        DataTable dtusptblAttributeTypeMaster_S = new DataTable();
        //        //fill the datatable with data.
        //        dausptblAttributeTypeMaster_S.Fill(dtusptblAttributeTypeMaster_S);
        //        if (dtusptblAttributeTypeMaster_S.Rows.Count > 0)
        //        {
        //            //Assigning value to AttributeTypeId property from the record.
        //            oObjtblAttributeTypeMasterBD.AttributeTypeId = Convert.ToString(dtusptblAttributeTypeMaster_S.Rows[0]["AttributeTypeId"]);
        //            //Assigning value to Name property from the record.
        //            oObjtblAttributeTypeMasterBD.Name = Convert.ToString(dtusptblAttributeTypeMaster_S.Rows[0]["Name"]);
        //            //Assigning value to TypeOf property from the record.
        //            oObjtblAttributeTypeMasterBD.TypeOf = Convert.ToString(dtusptblAttributeTypeMaster_S.Rows[0]["TypeOf"]);
        //            //Assigning value to Status property from the record.
        //            oObjtblAttributeTypeMasterBD.Status = Convert.ToBoolean(dtusptblAttributeTypeMaster_S.Rows[0]["Status"]);
        //            //Assigning value to CreatedDateTime property from the record.
        //            oObjtblAttributeTypeMasterBD.CreatedDateTime = Convert.ToDateTime(dtusptblAttributeTypeMaster_S.Rows[0]["CreatedDateTime"]);
        //            //Assigning value to CreatedByUserId property from the record.
        //            oObjtblAttributeTypeMasterBD.CreatedByUserId = Convert.ToString(dtusptblAttributeTypeMaster_S.Rows[0]["CreatedByUserId"]);
        //            //Assigning value to LastModifiedDateTime property from the record.
        //            oObjtblAttributeTypeMasterBD.LastModifiedDateTime = Convert.ToDateTime(dtusptblAttributeTypeMaster_S.Rows[0]["LastModifiedDateTime"]);
        //            //Assigning value to ModifiedByUserId property from the record.
        //            oObjtblAttributeTypeMasterBD.ModifiedByUserId = Convert.ToString(dtusptblAttributeTypeMaster_S.Rows[0]["ModifiedByUserId"]);
        //        }
        //        //return datatable.
        //        return dtusptblAttributeTypeMaster_S;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in gettblAttributeTypeMasterByPrimaryId method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "gettblAttributeTypeMasterByPrimaryId: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Get Transaction.
        /// </summary>
        public SqlTransaction cTransaction
        {
            set
            {
                oTran = value;
            }
            get
            {
                return oTran;
            }
        }
    }
}