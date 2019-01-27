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
    public class tblAttributeMasterBO
    {
        SqlTransaction oTran;
        //define constructor.
        public tblAttributeMasterBO()
        { }
        /// <summary>
        /// Method to insert record into the database.
        /// </summary>
        /// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        /// <returns>bool</returns>
        /// <param name="oTran">SqlTransaction</param>
        public bool instblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD, SqlTransaction oTran)
        {
            //writing trace information at the begining of the method.
            oTran = clsConnection.BeginTransaction();
            try
            {
                //writing trace information writing trace log before creating a command object.
                // creating a command object to communicate with database & initializing command and connection to the object.
                SqlCommand cmdusptblAttributeMaster_IU = new SqlCommand("usptblAttributeMaster_IU");
                //writing trace information writing trace log before command type association
                // defining the command type.
                cmdusptblAttributeMaster_IU.CommandType = CommandType.StoredProcedure;
                //writing trace information writing trace log before transaction association
                //Assigning transaction reference to this command object.
                cmdusptblAttributeMaster_IU.Transaction = oTran;
                //writing trace information writing trace log before Associating connection
                //Associating connection to this command object from tansaction object.
                cmdusptblAttributeMaster_IU.Connection = oTran.Connection;
                //writing trace information writing trace log before adding @Flag parameter with this command
                // adding parameter with name @Flag to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@Flag", SqlDbType.Char).Value = 'I';
                //writing trace information writing trace log before adding @AttributeId parameter with this command
                // adding parameter with name @AttributeId to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@AttributeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeId;
                //writing trace information writing trace log before adding @Name parameter with this command
                // adding parameter with name @Name to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@Name", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.Name;
                //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
                // adding parameter with name @AttributeTypeId to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeTypeId;
                //writing trace information writing trace log before adding @Description parameter with this command
                // adding parameter with name @Description to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@Description", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.Description;
                //writing trace information writing trace log before adding @DisplayTo parameter with this command
                // adding parameter with name @DisplayTo to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@DisplayTo", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.DisplayTo;
                //writing trace information writing trace log before adding @IsSearchable parameter with this command
                // adding parameter with name @IsSearchable to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@IsSearchable", SqlDbType.Bit).Value = oObjtblAttributeMasterBD.IsSearchable;
                //writing trace information writing trace log before adding @IsPredefined parameter with this command
                // adding parameter with name @IsPredefined to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@IsPredefined", SqlDbType.Bit).Value = oObjtblAttributeMasterBD.IsPredefined;
                //writing trace information writing trace log before adding @Status parameter with this command
                // adding parameter with name @Status to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@Status", SqlDbType.Bit).Value = oObjtblAttributeMasterBD.Status;
                //writing trace information writing trace log before adding @CreatedDateTime parameter with this command
                // adding parameter with name @CreatedDateTime to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@CreatedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeMasterBD.CreatedDateTime;
                //writing trace information writing trace log before adding @CreatedByUserId parameter with this command
                // adding parameter with name @CreatedByUserId to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@CreatedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.CreatedByUserId;
                //writing trace information writing trace log before adding @LastModifiedDateTime parameter with this command
                // adding parameter with name @LastModifiedDateTime to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@LastModifiedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeMasterBD.LastModifiedDateTime;
                //writing trace information writing trace log before adding @ModifiedByUserId parameter with this command
                // adding parameter with name @ModifiedByUserId to the command.
                cmdusptblAttributeMaster_IU.Parameters.Add("@ModifiedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.ModifiedByUserId;
                //writing trace information befor execution of the command
                //executing the command to open connection.
                oObjtblAttributeMasterBD.AttributeId = Convert.ToString(cmdusptblAttributeMaster_IU.ExecuteScalar());
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
        ///// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        ///// <returns>bool</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public bool updtblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the updtblAttributeMaster method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeMaster_IU = new SqlCommand("usptblAttributeMaster_IU");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeMaster_IU.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeMaster_IU.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeMaster_IU.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @Flag parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Flag with this command object.");
        //        // adding parameter with name @Flag to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@Flag", SqlDbType.Char).Value = 'U';
        //        //writing trace information writing trace log before adding @AttributeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeId with this command object.");
        //        // adding parameter with name @AttributeId to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@AttributeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeId;
        //        //writing trace information writing trace log before adding @Name parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Name with this command object.");
        //        // adding parameter with name @Name to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@Name", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.Name;
        //        //writing trace information writing trace log before adding @AttributeTypeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeTypeId with this command object.");
        //        // adding parameter with name @AttributeTypeId to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@AttributeTypeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeTypeId;
        //        //writing trace information writing trace log before adding @Description parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Description with this command object.");
        //        // adding parameter with name @Description to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@Description", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.Description;
        //        //writing trace information writing trace log before adding @DisplayTo parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @DisplayTo with this command object.");
        //        // adding parameter with name @DisplayTo to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@DisplayTo", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.DisplayTo;
        //        //writing trace information writing trace log before adding @IsSearchable parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @IsSearchable with this command object.");
        //        // adding parameter with name @IsSearchable to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@IsSearchable", SqlDbType.Bit).Value = oObjtblAttributeMasterBD.IsSearchable;
        //        //writing trace information writing trace log before adding @IsPredefined parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @IsPredefined with this command object.");
        //        // adding parameter with name @IsPredefined to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@IsPredefined", SqlDbType.Bit).Value = oObjtblAttributeMasterBD.IsPredefined;
        //        //writing trace information writing trace log before adding @Status parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Status with this command object.");
        //        // adding parameter with name @Status to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@Status", SqlDbType.Bit).Value = oObjtblAttributeMasterBD.Status;
        //        //writing trace information writing trace log before adding @CreatedDateTime parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @CreatedDateTime with this command object.");
        //        // adding parameter with name @CreatedDateTime to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@CreatedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeMasterBD.CreatedDateTime;
        //        //writing trace information writing trace log before adding @CreatedByUserId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @CreatedByUserId with this command object.");
        //        // adding parameter with name @CreatedByUserId to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@CreatedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.CreatedByUserId;
        //        //writing trace information writing trace log before adding @LastModifiedDateTime parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @LastModifiedDateTime with this command object.");
        //        // adding parameter with name @LastModifiedDateTime to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@LastModifiedDateTime", SqlDbType.DateTime).Value = oObjtblAttributeMasterBD.LastModifiedDateTime;
        //        //writing trace information writing trace log before adding @ModifiedByUserId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @ModifiedByUserId with this command object.");
        //        // adding parameter with name @ModifiedByUserId to the command.
        //        cmdusptblAttributeMaster_IU.Parameters.Add("@ModifiedByUserId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.ModifiedByUserId;
        //        //writing trace information befor execution of the command
        //        CentrumLog.WriteInformation("Trace Information", 0, "Executing command of updtblAttributeMaster method.");
        //        //executing the command to open connection.
        //        cmdusptblAttributeMaster_IU.ExecuteNonQuery();
        //        //return true in case of sucessfully done.
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in updtblAttributeMaster method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "updtblAttributeMaster: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// Method to delete record from the database.
        ///// </summary>
        ///// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        ///// <returns>bool</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public bool deltblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the deltblAttributeMaster method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeMaster_D = new SqlCommand("usptblAttributeMaster_D");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeMaster_D.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeMaster_D.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeMaster_D.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @AttributeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeId with this command object.");
        //        // adding parameter with name @AttributeId to the command.
        //        cmdusptblAttributeMaster_D.Parameters.Add("@AttributeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeId;
        //        //writing trace information befor execution of the command
        //        CentrumLog.WriteInformation("Trace Information", 0, "Executing command of deltblAttributeMaster method.");
        //        //executing the command to open connection.
        //        cmdusptblAttributeMaster_D.ExecuteNonQuery();
        //        //returns true in case of success.
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in deltblAttributeMaster method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "deltblAttributeMaster: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// Method to get all record from the database.
        ///// </summary>
        ///// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        ///// <returns>DataTable</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public DataTable gettblAttributeMaster(ObjtblAttributeMasterBD oObjtblAttributeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the gettblAttributeMaster method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeMaster_S = new SqlCommand("usptblAttributeMaster_S");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeMaster_S.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeMaster_S.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeMaster_S.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @Flag parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Flag with this command object.");
        //        // adding parameter with name @Flag to the command.
        //        cmdusptblAttributeMaster_S.Parameters.Add("@Flag", SqlDbType.Char).Value = oObjtblAttributeMasterBD.DisplayTo != "" ? 'C' : 'A';
        //        //writing trace information writing trace log before adding @AttributeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeId with this command object.");
        //        // adding parameter with name @AttributeId to the command.
        //        cmdusptblAttributeMaster_S.Parameters.Add("@AttributeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeId;
        //        //writing trace information writing trace log before adding @DisplayTo parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @DisplayTo with this command object.");
        //        // adding parameter with name @DisplayTo to the command.
        //        cmdusptblAttributeMaster_S.Parameters.Add("@DisplayTo", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.DisplayTo;
        //        //creating the adaptor object to get data from the database.
        //        SqlDataAdapter dausptblAttributeMaster_S = new SqlDataAdapter(cmdusptblAttributeMaster_S);
        //        //creating the datatable object to hold data from the database.
        //        DataTable dtusptblAttributeMaster_S = new DataTable();
        //        //fill the datatable with data.
        //        dausptblAttributeMaster_S.Fill(dtusptblAttributeMaster_S);
        //        //return datatable.
        //        return dtusptblAttributeMaster_S;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in gettblAttributeMaster method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "gettblAttributeMaster: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// Method to get record from the database according to given Id.
        ///// </summary>
        ///// <param name="oObjtblAttributeMasterBD">ObjtblAttributeMasterBD</param>
        ///// <returns>DataTable</returns>
        ///// <param name="oTran">SqlTransaction</param>
        //public DataTable gettblAttributeMasterByPrimaryId(ObjtblAttributeMasterBD oObjtblAttributeMasterBD, ref SqlTransaction oTran)
        //{
        //    //writing trace information at the begining of the method.
        //    CentrumLog.WriteInformation("Trace Information", 0, "Begining of the gettblAttributeMasterByPrimaryId method");
        //    try
        //    {
        //        //writing trace information writing trace log before creating a command object.
        //        CentrumLog.WriteInformation("Trace Information", 0, "creating a command object.");
        //        // creating a command object to communicate with database & initializing command and connection to the object.
        //        SqlCommand cmdusptblAttributeMaster_S = new SqlCommand("usptblAttributeMaster_S");
        //        //writing trace information writing trace log before command type association
        //        CentrumLog.WriteInformation("Trace Information", 0, "associating command type with this command object.");
        //        // defining the command type.
        //        cmdusptblAttributeMaster_S.CommandType = CommandType.StoredProcedure;
        //        //writing trace information writing trace log before transaction association
        //        CentrumLog.WriteInformation("Trace Information", 0, "Assigning transaction reference with this command object.");
        //        //Assigning transaction reference to this command object.
        //        cmdusptblAttributeMaster_S.Transaction = oTran;
        //        //writing trace information writing trace log before Associating connection
        //        CentrumLog.WriteInformation("Trace Information", 0, "Associating connection with this command object.");
        //        //Associating connection to this command object from tansaction object.
        //        cmdusptblAttributeMaster_S.Connection = oTran.Connection;
        //        //writing trace information writing trace log before adding @Flag parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @Flag with this command object.");
        //        // adding parameter with name @Flag to the command.
        //        cmdusptblAttributeMaster_S.Parameters.Add("@Flag", SqlDbType.Char).Value = 'S';
        //        //writing trace information writing trace log before adding @AttributeId parameter with this command
        //        CentrumLog.WriteInformation("Trace Information", 0, "adding parameter @AttributeId with this command object.");
        //        // adding parameter with name @AttributeId to the command.
        //        cmdusptblAttributeMaster_S.Parameters.Add("@AttributeId", SqlDbType.VarChar).Value = oObjtblAttributeMasterBD.AttributeId;
        //        //creating the adaptor object to get data from the database.
        //        SqlDataAdapter dausptblAttributeMaster_S = new SqlDataAdapter(cmdusptblAttributeMaster_S);
        //        //creating the datatable object to hold data from the database.
        //        DataTable dtusptblAttributeMaster_S = new DataTable();
        //        //fill the datatable with data.
        //        dausptblAttributeMaster_S.Fill(dtusptblAttributeMaster_S);
        //        if (dtusptblAttributeMaster_S.Rows.Count > 0)
        //        {
        //            //Assigning value to AttributeId property from the record.
        //            oObjtblAttributeMasterBD.AttributeId = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["AttributeId"]);
        //            //Assigning value to Name property from the record.
        //            oObjtblAttributeMasterBD.Name = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["Name"]);
        //            //Assigning value to AttributeTypeId property from the record.
        //            oObjtblAttributeMasterBD.AttributeTypeId = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["AttributeTypeId"]);
        //            //Assigning value to Description property from the record.
        //            oObjtblAttributeMasterBD.Description = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["Description"]);
        //            //Assigning value to DisplayTo property from the record.
        //            oObjtblAttributeMasterBD.DisplayTo = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["DisplayTo"]);
        //            //Assigning value to IsSearchable property from the record.
        //            oObjtblAttributeMasterBD.IsSearchable = Convert.ToBoolean(dtusptblAttributeMaster_S.Rows[0]["IsSearchable"]);
        //            //Assigning value to IsPredefined property from the record.
        //            oObjtblAttributeMasterBD.IsPredefined = Convert.ToBoolean(dtusptblAttributeMaster_S.Rows[0]["IsPredefined"]);
        //            //Assigning value to Status property from the record.
        //            oObjtblAttributeMasterBD.Status = Convert.ToBoolean(dtusptblAttributeMaster_S.Rows[0]["Status"]);
        //            //Assigning value to CreatedDateTime property from the record.
        //            oObjtblAttributeMasterBD.CreatedDateTime = Convert.ToDateTime(dtusptblAttributeMaster_S.Rows[0]["CreatedDateTime"]);
        //            //Assigning value to CreatedByUserId property from the record.
        //            oObjtblAttributeMasterBD.CreatedByUserId = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["CreatedByUserId"]);
        //            //Assigning value to LastModifiedDateTime property from the record.
        //            oObjtblAttributeMasterBD.LastModifiedDateTime = Convert.ToDateTime(dtusptblAttributeMaster_S.Rows[0]["LastModifiedDateTime"]);
        //            //Assigning value to ModifiedByUserId property from the record.
        //            oObjtblAttributeMasterBD.ModifiedByUserId = Convert.ToString(dtusptblAttributeMaster_S.Rows[0]["ModifiedByUserId"]);
        //        }
        //        //return datatable.
        //        return dtusptblAttributeMaster_S;
        //    }
        //    catch (Exception ex)
        //    {
        //        //writing trace information  for rollback transaction
        //        CentrumLog.WriteInformation("Trace Information", 0, "rollback the transaction in case of any error in gettblAttributeMasterByPrimaryId method.");
        //        //rollback transaction.
        //        oTran.Rollback();
        //        //writing error log
        //        CentrumLog.WriteErrorTrace("Centrum Error Log", 0, "gettblAttributeMasterByPrimaryId: " + ex.ToString());
        //        //throw exception.
        //        throw ex;
        //    }
        //}
    }
}