using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;



using System.Data.SqlClient;
using System.Xml;
using System.Configuration;


// The SqlHelper class is intended to encapsulate high performance, scalable best practices for 
// common uses of SqlClient.

public sealed class SqlHelper
{

    #region "private utility methods & constructors"

    //Since this class provides only static methods, make the default constructor private to prevent 
    //instances from being created with "new SqlHelper()".
    private SqlHelper()
    {
    }
    //New


    private static AppSettingsReader _configReader = new AppSettingsReader();
    public static SqlConnection createConnection()
    {
        try
        {
            string strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
            //string strConnString = _configReader.GetValue("Main.ConnectionString", "".GetType()).ToString().Trim();
            //ConfigurationManager.ConnectionStrings("Main.ConnectionString").ConnectionString.ToString()
            SqlConnection myConnection = new SqlConnection(strConnString);
            myConnection.Open();
            return myConnection;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error in Connection Opening");
        }
    }

    public static void closeConnection(SqlConnection Conn)
    {
        try
        {
            Conn.Close();
            Conn.Dispose();

        }
        catch (Exception)
        {
        }
    }



    // This method is used to attach array of SqlParameters to a SqlCommand.
    // This method will assign a value of DbNull to any parameter with a direction of
    // InputOutput and a value of null.  
    // This behavior will prevent default values from being used, but
    // this will be the less common case than an intended pure output parameter (derived as InputOutput)
    // where the user provided no input value.
    // Parameters:
    // -command - The command to which the parameters will be added
    // -commandParameters - an array of SqlParameters tho be added to command
    private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
    {
        SqlParameter p = null;
        foreach (SqlParameter p_loopVariable in commandParameters)
        {
            p = p_loopVariable;
            //check for derived output value with no value assigned
            if (p.Direction == ParameterDirection.InputOutput & p.Value == null)
            {
                p.Value = null;
            }
            command.Parameters.Add(p);
        }
    }
    //AttachParameters

    // This method assigns an array of values to an array of SqlParameters.
    // Parameters:
    // -commandParameters - array of SqlParameters to be assigned values
    // -array of objects holding the values to be assigned

    private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
    {
        int i = 0;
        int j = 0;

        if ((commandParameters == null) & (parameterValues == null))
        {
            //do nothing if we get no data
            return;
        }

        // we must have the same number of values as we pave parameters to put them in
        if (commandParameters.Length != parameterValues.Length)
        {
            throw new ArgumentException("Parameter count does not match Parameter Value count.");
        }

        //value array
        j = commandParameters.Length - 1;
        for (i = 0; i <= j; i++)
        {
            commandParameters[i].Value = parameterValues[i];
        }

    }
    //AssignParameterValues

    // This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
    // to the provided command.
    // Parameters:
    // -command - the SqlCommand to be prepared
    // -connection - a valid SqlConnection, on which to execute this command
    // -transaction - a valid SqlTransaction, or 'null'
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // -commandParameters - an array of SqlParameters to be associated with the command or 'null' if no parameters are required

    private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
    {
        //if the provided connection is not open, we will open it
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        //associate the connection with the command
        command.Connection = connection;

        //set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText;

        //if we were provided a transaction, assign it.
        if ((transaction != null))
        {
            command.Transaction = transaction;
        }

        //set the command type
        command.CommandType = commandType;

        //attach the command parameters if they are provided
        if ((commandParameters != null))
        {
            AttachParameters(command, commandParameters);
        }

        return;
    }
    //PrepareCommand

    #endregion

    #region "ExecuteNonQuery"

    // Execute a SqlCommand (that returns no resultset and takes no parameters) against the database specified in 
    // the connection string. 
    // e.g.:  
    //  Dim result as Integer =  ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders")
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // Returns: an int representing the number of rows affected by the command
    public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteNonQuery(connectionString, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteNonQuery

    // Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
    // using the provided parameters.
    // e.g.:  
    // Dim result as Integer = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // -commandParameters - an array of SqlParamters used to execute the command
    // Returns: an int representing the number of rows affected by the command
    public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create & open a SqlConnection, and dispose of it after we are done.
        SqlConnection cn = new SqlConnection(connectionString);
        try
        {
            cn.Open();

            //call the overload that takes a connection in place of the connection string
            return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
        }
        finally
        {
            cn.Dispose();
        }
    }
    //ExecuteNonQuery

    // Execute a stored procedure via a SqlCommand (that returns no resultset) against the database specified in 
    // the connection string using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    //  Dim result as Integer = ExecuteNonQuery(connString, "PublishOrders", 24, 36)
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -spName - the name of the stored procedure
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    // Returns: an int representing the number of rows affected by the command
    public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)

            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteNonQuery

    // Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlConnection. 
    // e.g.:  
    // Dim result as Integer = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders")
    // Parameters:
    // -connection - a valid SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: an int representing the number of rows affected by the command
    public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteNonQuery(connection, commandType, commandText, (SqlParameter[])null);

    }
    //ExecuteNonQuery

    // Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
    // using the provided parameters.
    // e.g.:  
    //  Dim result as Integer = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an int representing the number of rows affected by the command 
    public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {

        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        int retval = 0;

        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

        //finally, execute the command.
        retval = cmd.ExecuteNonQuery();

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return retval;

    }
    //ExecuteNonQuery

    // Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified SqlConnection 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    //  Dim result as integer = ExecuteNonQuery(conn, "PublishOrders", 24, 36)
    // Parameters:
    // -connection - a valid SqlConnection
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: an int representing the number of rows affected by the command 
    public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        }

    }
    //ExecuteNonQuery

    // Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlTransaction.
    // e.g.:  
    //  Dim result as Integer = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders")
    // Parameters:
    // -transaction - a valid SqlTransaction associated with the connection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: an int representing the number of rows affected by the command 
    public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteNonQuery(transaction, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteNonQuery

    // Execute a SqlCommand (that returns no resultset) against the specified SqlTransaction
    // using the provided parameters.
    // e.g.:  
    // Dim result as Integer = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an int representing the number of rows affected by the command 
    public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        int retval = 0;

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

        //finally, execute the command.
        retval = cmd.ExecuteNonQuery();

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return retval;

    }
    //ExecuteNonQuery

    // Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified SqlTransaction 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim result As Integer = SqlHelper.ExecuteNonQuery(trans, "PublishOrders", 24, 36)
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: an int representing the number of rows affected by the command 
    public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteNonQuery

    #endregion

    #region "ExecuteDataset"

    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    // the connection string. 
    // e.g.:  
    // Dim ds As DataSet = SqlHelper.ExecuteDataset("", commandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteDataset(connectionString, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteDataset

    // Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    // using the provided parameters.
    // e.g.:  
    // Dim ds as Dataset = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // -commandParameters - an array of SqlParamters used to execute the command
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create & open a SqlConnection, and dispose of it after we are done.
        SqlConnection cn = new SqlConnection(connectionString);
        try
        {
            cn.Open();

            //call the overload that takes a connection in place of the connection string
            return ExecuteDataset(cn, commandType, commandText, commandParameters);
        }
        finally
        {
            cn.Dispose();
        }
    }
    //ExecuteDataset

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    // the connection string using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim ds as Dataset= ExecuteDataset(connString, "GetOrders", 24, 36)
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -spName - the name of the stored procedure
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
    {

        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteDataset

    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    // e.g.:  
    // Dim ds as Dataset = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -connection - a valid SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
    {

        //pass through the call providing null for the set of SqlParameters
        return ExecuteDataset(connection, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteDataset

    // Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    // using the provided parameters.
    // e.g.:  
    // Dim ds as Dataset = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connection - a valid SqlConnection
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // -commandParameters - an array of SqlParamters used to execute the command
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {

        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;

        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

        //create the DataAdapter & DataSet
        da = new SqlDataAdapter(cmd);

        //fill the DataSet using default values for DataTable names, etc.
        da.Fill(ds);

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        //return the dataset
        return ds;

    }
    //ExecuteDataset

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim ds As Dataset = ExecuteDataset(conn, "GetOrders", 24, 36)
    // Parameters:
    // -connection - a valid SqlConnection
    // -spName - the name of the stored procedure
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(SqlConnection connection, string spName, params object[] parameterValues)
    {
        //Return ExecuteDataset(connection, spName, parameterValues)
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
        }

    }
    //ExecuteDataset


    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
    // e.g.:  
    // Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders")
    // Parameters
    // -transaction - a valid SqlTransaction
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteDataset(transaction, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteDataset

    // Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    // using the provided parameters.
    // e.g.:  
    // Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters
    // -transaction - a valid SqlTransaction 
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command
    // -commandParameters - an array of SqlParamters used to execute the command
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

        //create the DataAdapter & DataSet
        da = new SqlDataAdapter(cmd);

        //fill the DataSet using default values for DataTable names, etc.
        da.Fill(ds);

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        //return the dataset
        return ds;
    }
    //ExecuteDataset

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified
    // SqlTransaction using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim ds As Dataset = ExecuteDataset(trans, "GetOrders", 24, 36)
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -spName - the name of the stored procedure
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    // Returns: a dataset containing the resultset generated by the command
    public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteDataset

    #endregion

    #region "ExecuteReader"
    // this enum is used to indicate whether the connection was provided by the caller, or created by SqlHelper, so that
    // we can set the appropriate CommandBehavior when calling ExecuteReader()
    private enum SqlConnectionOwnership
    {
        //Connection is owned and managed by SqlHelper
        Internal,
        //Connection is owned and managed by the caller
        External
    }
    //SqlConnectionOwnership

    // Create and prepare a SqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
    // If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
    // If the caller provided the connection, we want to leave it to them to manage.
    // Parameters:
    // -connection - a valid SqlConnection, on which to execute this command 
    // -transaction - a valid SqlTransaction, or 'null' 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParameters to be associated with the command or 'null' if no parameters are required 
    // -connectionOwnership - indicates whether the connection parameter was provided by the caller, or created by SqlHelper 
    // Returns: SqlDataReader containing the results of the command 
    private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlConnectionOwnership connectionOwnership)
    {
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        //create a reader
        SqlDataReader dr = null;

        PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);

        // call ExecuteReader with the appropriate CommandBehavior
        if (connectionOwnership == SqlConnectionOwnership.External)
        {
            dr = cmd.ExecuteReader();
        }
        else
        {
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return dr;
    }
    //ExecuteReader

    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    // the connection string. 
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteReader(connectionString, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteReader

    // Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    // using the provided parameters.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create & open a SqlConnection
        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();

        try
        {
            //call the private overload that takes an internally owned connection in place of the connection string
            return ExecuteReader(cn, (SqlTransaction)null, commandType, commandText, commandParameters, SqlConnectionOwnership.Internal);
        }
        catch
        {
            //if we fail to return the SqlDatReader, we need to close the connection ourselves
            cn.Dispose();
        }
        return null;
    }
    //ExecuteReader

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    // the connection string using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(connString, "GetOrders", 24, 36)
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteReader

    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
    {

        return ExecuteReader(connection, commandType, commandText, (SqlParameter[])null);

    }
    //ExecuteReader

    // Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    // using the provided parameters.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //pass through the call to private overload using a null transaction value
        return ExecuteReader(connection, (SqlTransaction)null, commandType, commandText, commandParameters, SqlConnectionOwnership.External);

    }
    //ExecuteReader

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(conn, "GetOrders", 24, 36)
    // Parameters:
    // -connection - a valid SqlConnection 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
    {
        //pass through the call using a null transaction value
        //Return ExecuteReader(connection, CType(Nothing, SqlTransaction), spName, parameterValues)

        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

            AssignParameterValues(commandParameters, parameterValues);

            //Return ExecuteReader(CommandType.StoredProcedure, spName, commandParameters)
            return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteReader(connection, CommandType.StoredProcedure, spName);
        }

    }
    //ExecuteReader

    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -transaction - a valid SqlTransaction  
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteReader(transaction, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteReader

    // Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    // using the provided parameters.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -commandType - the CommandType (stored procedure, text, etc.)
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: a SqlDataReader containing the resultset generated by the command 
    public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //pass through to private overload, indicating that the connection is owned by the caller
        return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
    }
    //ExecuteReader

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim dr As SqlDataReader = ExecuteReader(trans, "GetOrders", 24, 36)
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    // Returns: a SqlDataReader containing the resultset generated by the command
    public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

            AssignParameterValues(commandParameters, parameterValues);

            return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteReader

    #endregion

    #region "ExecuteScalar"

    // Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
    // the connection string. 
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount"))
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: an object containing the value in the 1x1 resultset generated by the command
    public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteScalar(connectionString, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteScalar

    // Execute a SqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
    // using the provided parameters.
    // e.g.:  
    // Dim orderCount As Integer = Cint(ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create & open a SqlConnection, and dispose of it after we are done.
        SqlConnection cn = new SqlConnection(connectionString);
        try
        {
            cn.Open();

            //call the overload that takes a connection in place of the connection string
            return ExecuteScalar(cn, commandType, commandText, commandParameters);
        }
        finally
        {
            cn.Dispose();
        }
    }
    //ExecuteScalar

    // Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the database specified in 
    // the connection string using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(connString, "GetOrderCount", 24, 36))
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteScalar

    // Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlConnection. 
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount"))
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteScalar(connection, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteScalar

    // Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    // using the provided parameters.
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        object retval = null;

        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

        //execute the command & return the results
        retval = cmd.ExecuteScalar();

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return retval;

    }
    //ExecuteScalar

    // Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(conn, "GetOrderCount", 24, 36))
    // Parameters:
    // -connection - a valid SqlConnection 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(SqlConnection connection, string spName, params object[] parameterValues)
    {

        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
        }

    }
    //ExecuteScalar

    // Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlTransaction.
    // e.g.:  
    // Dim orderCount As Integer  = CInt(ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount"))
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteScalar(transaction, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteScalar

    // Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction
    // using the provided parameters.
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
    // Parameters:
    // -transaction - a valid SqlTransaction  
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        object retval = null;

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

        //execute the command & return the results
        retval = cmd.ExecuteScalar();

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return retval;

    }
    //ExecuteScalar

    // Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim orderCount As Integer = CInt(ExecuteScalar(trans, "GetOrderCount", 24, 36))
    // Parameters:
    // -transaction - a valid SqlTransaction 
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: an object containing the value in the 1x1 resultset generated by the command 
    public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteScalar

    #endregion

    #region "ExecuteXmlReader"

    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    // e.g.:  
    // Dim r As XmlReader = ExecuteXmlReader(conn, CommandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    // Returns: an XmlReader containing the resultset generated by the command 
    public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteXmlReader(connection, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteXmlReader

    // Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    // using the provided parameters.
    // e.g.:  
    // Dim r As XmlReader = ExecuteXmlReader(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -connection - a valid SqlConnection 
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an XmlReader containing the resultset generated by the command 
    public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //pass through the call using a null transaction value
        //Return ExecuteXmlReader(connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        XmlReader retval = null;

        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

        //create the DataAdapter & DataSet
        retval = cmd.ExecuteXmlReader();

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return retval;


    }
    //ExecuteXmlReader

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim r As XmlReader = ExecuteXmlReader(conn, "GetOrders", 24, 36)
    // Parameters:
    // -connection - a valid SqlConnection 
    // -spName - the name of the stored procedure using "FOR XML AUTO" 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: an XmlReader containing the resultset generated by the command 
    public static XmlReader ExecuteXmlReader(SqlConnection connection, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteXmlReader


    // Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction
    // e.g.:  
    // Dim r As XmlReader = ExecuteXmlReader(trans, CommandType.StoredProcedure, "GetOrders")
    // Parameters:
    // -transaction - a valid SqlTransaction
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    // Returns: an XmlReader containing the resultset generated by the command 
    public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        //pass through the call providing null for the set of SqlParameters
        return ExecuteXmlReader(transaction, commandType, commandText, (SqlParameter[])null);
    }
    //ExecuteXmlReader

    // Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    // using the provided parameters.
    // e.g.:  
    // Dim r As XmlReader = ExecuteXmlReader(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    // Parameters:
    // -transaction - a valid SqlTransaction
    // -commandType - the CommandType (stored procedure, text, etc.) 
    // -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    // -commandParameters - an array of SqlParamters used to execute the command 
    // Returns: an XmlReader containing the resultset generated by the command
    public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        //create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        XmlReader retval = null;

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

        //create the DataAdapter & DataSet
        retval = cmd.ExecuteXmlReader();

        //detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear();

        return retval;

    }
    //ExecuteXmlReader

    // Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    // using the provided parameter values.  This method will discover the parameters for the 
    // stored procedure, and assign the values based on parameter order.
    // This method provides no access to output parameters or the stored procedure's return value parameter.
    // e.g.:  
    // Dim r As XmlReader = ExecuteXmlReader(trans, "GetOrders", 24, 36)
    // Parameters:
    // -transaction - a valid SqlTransaction
    // -spName - the name of the stored procedure 
    // -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    // Returns: a dataset containing the resultset generated by the command
    public static XmlReader ExecuteXmlReader(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        SqlParameter[] commandParameters = null;

        //if we receive parameter values, we need to figure out where they go
        if ((parameterValues != null) & parameterValues.Length > 0)
        {
            //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

            //assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues);

            //call the overload that takes an array of SqlParameters
            return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            //otherwise we can just call the SP without params
        }
        else
        {
            return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
        }
    }
    //ExecuteXmlReader

    #endregion

}
//SqlHelper

// SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
// ability to discover parameters for stored procedures at run-time.
public sealed class SqlHelperParameterCache
{

    #region "private methods, variables, and constructors"


    //Since this class provides only static methods, make the default constructor private to prevent 
    //instances from being created with "new SqlHelperParameterCache()".
    private SqlHelperParameterCache()
    {
    }
    //New 


    private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
    // resolve at run time the appropriate set of SqlParameters for a stored procedure
    // Parameters:
    // - connectionString - a valid connection string for a SqlConnection
    // - spName - the name of the stored procedure
    // - includeReturnValueParameter - whether or not to include their return value parameter>
    // Returns: SqlParameter()
    private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter, params object[] parameterValues)
    {

        SqlConnection cn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(spName, cn);
        SqlParameter[] discoveredParameters = null;

        try
        {
            cn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            discoveredParameters = new SqlParameter[cmd.Parameters.Count];
            cmd.Parameters.CopyTo(discoveredParameters, 0);
        }
        finally
        {
            cmd.Dispose();
            cn.Dispose();

        }

        return discoveredParameters;

    }
    //DiscoverSpParameterSet

    //deep copy of cached SqlParameter array
    private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
    {

        int i = 0;
        int j = originalParameters.Length - 1;
        SqlParameter[] clonedParameters = new SqlParameter[j + 1];

        for (i = 0; i <= j; i++)
        {
            clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
        }

        return clonedParameters;
    }
    //CloneParameters



    #endregion

    #region "caching functions"

    // add parameter array to the cache
    // Parameters
    // -connectionString - a valid connection string for a SqlConnection 
    // -commandText - the stored procedure name or T-SQL command 
    // -commandParameters - an array of SqlParamters to be cached 
    public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
    {
        string hashKey = connectionString + ":" + commandText;

        paramCache[hashKey] = commandParameters;
    }
    //CacheParameterSet

    // retrieve a parameter array from the cache
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -commandText - the stored procedure name or T-SQL command 
    // Returns: an array of SqlParamters 
    public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
    {
        string hashKey = connectionString + ":" + commandText;
        SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];

        if (cachedParameters == null)
        {
            return null;
        }
        else
        {
            return CloneParameters(cachedParameters);
        }
    }
    //GetCachedParameterSet

    #endregion

    #region "Parameter Discovery Functions"
    // Retrieves the set of SqlParameters appropriate for the stored procedure
    // 
    // This method will query the database for this information, and then store it in a cache for future requests.
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection 
    // -spName - the name of the stored procedure 
    // Returns: an array of SqlParameters
    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
    {
        return GetSpParameterSet(connectionString, spName, false);
    }
    //GetSpParameterSet 

    // Retrieves the set of SqlParameters appropriate for the stored procedure
    // 
    // This method will query the database for this information, and then store it in a cache for future requests.
    // Parameters:
    // -connectionString - a valid connection string for a SqlConnection
    // -spName - the name of the stored procedure 
    // -includeReturnValueParameter - a bool value indicating whether the return value parameter should be included in the results 
    // Returns: an array of SqlParameters 
    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
    {

        SqlParameter[] cachedParameters = null;
        string hashKey = null;

        hashKey = connectionString + ":" + spName + (includeReturnValueParameter == true ? ":include ReturnValue Parameter" : "");

        cachedParameters = (SqlParameter[])paramCache[hashKey];

        if ((cachedParameters == null))
        {
            paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter);
            cachedParameters = (SqlParameter[])paramCache[hashKey];

        }

        return CloneParameters(cachedParameters);

    }
    //GetSpParameterSet
    #endregion


}
//SqlHelperParameterCache 
