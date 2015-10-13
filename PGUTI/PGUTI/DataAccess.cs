using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;


/// <summary>
/// Data access class
/// </summary>
namespace NDataAccess
{
    public class DataAccess
    {
        /// <summary>
        /// Get result of a stored procedure as dataset
        /// </summary>
        /// <param name="SQLText">Stored procedure name</param>
        /// <returns>Result of the stored procedure as DataSet</returns>
        //public static DataSet GetDataSet(string SQLText)
        //{
        //    DataSet ds = new DataSet();
        //    ExecuteProc(SQLText, null, ds);
        //    return ds;
        //}

        ///// <summary>
        ///// Get result of a stored procedure as dataset
        ///// </summary>
        ///// <param name="StoredProcedureName">Stored procedure name</param>
        ///// <param name="TableName">Data table name</param>
        ///// <returns>Result of the stored procedure as DataSet</returns>
        //public static DataSet GetDataSet(string SQLText, string TableName)
        //{
        //    DataSet ds = new DataSet();
        //    ExecuteProc(SQLText, null, ds, TableName);
        //    return ds;
        //}

        ///// <summary>
        ///// Get result of a stored procedure as dataset
        ///// </summary>
        ///// <param name="StoredProcedureName">Stored procedure name</param>
        ///// <param name="Parameters">The procedure parameters</param>
        ///// <returns>Result of the stored procedure as DataSet</returns>
        //public static DataSet GetDataSet(string SQLText, Hashtable Parameters)
        //{
        //    DataSet ds = new DataSet();
        //    ExecuteProc(SQLText, Parameters, ds, "DATA");
        //    return ds;
        //}

        /// <summary>
        /// Get result of a stored procedure as dataset
        /// </summary>
        /// <param name="StoredProcedureName">Stored procedure name</param>
        /// <param name="Parameters">The procedure parameters</param>
        /// <param name="TableName">Data table name</param>
        /// <returns>Result of the stored procedure as DataSet</returns>
        //public static DataSet GetDataSet(string SQLText, Hashtable Parameters, string TableName)
        //{
        //    DataSet ds = new DataSet();
        //    ExecuteProc(SQLText, Parameters, ds, TableName);
        //    return ds;
        //}

        /// <summary>
        /// Get result of a stored procedure as dataset
        /// </summary>
        /// <param name="StoredProcedureName">Stored procedure name</param>
        /// <param name="Parameters">The procedure parameters</param>
        /// <param name="TableName">Data table name</param>
        /// <param name="ConnectionString">Connection string for database access</param>
        /// <returns>Result of the stored procedure as DataSet</returns>
        //public static DataSet GetDataSet(string SQLText, Hashtable Parameters, string TableName, string ConnectionString)
        //{
        //    //   Utils.Log.WriteLogFile("1.txt", SQLText);            
        //    DataSet ds = new DataSet();
        //    ExecuteProc(SQLText, Parameters, ds, TableName, ConnectionString);
        //    return ds;
        //}

        public static DataSet GetDataSet(string SQLText, string TableName, string ConnectionString)//+
        {
            //   Utils.Log.WriteLogFile("1.txt", SQLText);            
            DataSet ds = new DataSet();
            ExecuteProc(SQLText, ds, TableName, ConnectionString);
            return ds;
        }

        ///// <summary>
        ///// Get the first row of the query result
        ///// </summary>
        ///// <param name="StoredProcedureName">Stored procedure name</param>
        ///// <returns>The first DataRow of the stored procedure result</returns>
        //public static DataRow GetFirstRow(string SQLText)
        //{
        //    return GetFirstRow(SQLText, null);
        //}

        ///// <summary>
        ///// Get the first row of the query result
        ///// </summary>
        ///// <param name="StoredProcedureName">Stored procedure name</param>
        ///// <param name="Parameters">The procedure parameters</param>
        ///// <returns>The first DataRow of the stored procedure result</returns>
        //public static DataRow GetFirstRow(string SQLText, Hashtable Parameters)
        //{
        //    return GetFirstRow(SQLText, Parameters, null);
        //}

        ///// <summary>
        ///// Get the first row of the query result
        ///// </summary>
        ///// <param name="StoredProcedureName">Stored procedure name</param>
        ///// <param name="Parameters">The procedure parameters</param>
        ///// <param name="ConnectionString">Connection string for database access</param>
        ///// <returns>The first DataRow of the stored procedure result</returns>
        //public static DataRow GetFirstRow(string SQLText, Hashtable Parameters, string ConnectionString)
        //{
        //    DataSet ds = new DataSet();
        //    ExecuteProc(SQLText, Parameters, ds, "DATA", ConnectionString);
        //    if (ds.Tables["DATA"].Rows.Count > 0)
        //        return ds.Tables["DATA"].Rows[0];
        //    else
        //        return null;
        //}

        ///// <summary>
        ///// Stub for a full function executing some stored procedure
        ///// </summary>
        ///// <param name="StoredProcedureName">The stored procedure name</param>
        //public static void ExecuteProc(string SQLText)
        //{
        //    ExecuteProc(SQLText, null, null, null, null);
        //}

        ///// <summary>
        ///// Stub for a full function executing some stored procedure
        ///// </summary>
        ///// <param name="StoredProcedureName">The stored procedure name</param>
        ///// <param name="Parameters">The procedure parameters</param>
        //public static void ExecuteProc(string SQLText, Hashtable Parameters)
        //{
        //    ExecuteProc(SQLText, Parameters, null, null, null);
        //}

        ///// <summary>
        ///// Stub for a full function executing some stored procedure
        ///// </summary>
        ///// <param name="StoredProcedureName">The stored procedure name</param>
        ///// <param name="Parameters">The procedure parameters</param>
        ///// <param name="resultDataSet">The result dataset</param>
        //public static void ExecuteProc(string StoredProcedureName, Hashtable Parameters, DataSet resultDataSet)
        //{
        //    ExecuteProc(StoredProcedureName, Parameters, resultDataSet, null, null);
        //}

        ///// <summary>
        ///// Execute a stored procedure
        ///// </summary>
        ///// <param name="StoredProcedureName">Stored procedure name</param>
        ///// <param name="Parameters">The procedure parameters</param>
        ///// <param name="resultDataSet">Result dataset</param>
        ///// <param name="TableName">Data table name</param>
        //public static void ExecuteProc(string StoredProcedureName, Hashtable Parameters, DataSet resultDataSet, string TableName)
        //{
        //    ExecuteProc(StoredProcedureName, Parameters, resultDataSet, TableName, null);
        //}

        /// <param name="StoredProcedureName"></param>
        /// <param name="Parameters"></param>
        /// <param name="resultDataSet"></param>
        /// <param name="TableName"></param>
        /// <param name="ConnectionString"></param>
        //public static void ExecuteProc(string StoredProcedureName, Hashtable Parameters, DataSet resultDataSet, string TableName, string ConnectionString)
        //{
        //    bool exceptionOccured = false;
        //    Exception originalException = null;
        //    SqlConnection conn = null;
        //    SqlCommand cmd = null;
        //    //OracleConnection conn = null;
        //    //OracleCommand cmd = null;


        //    try
        //    {
        //        using (SqlDataAdapter adapt = new SqlDataAdapter())
        //        {
        //            if (ConnectionString == null)
        //                conn = new SqlConnection(""); //conn = new SqlConnection(Utils.GetCurrentConnectionString());
        //            else
        //                conn = new SqlConnection(ConnectionString);
        //            //conn.Charset = "UTF8";
        //            //  conn.Unicode = true;
        //            conn.ConnectionString = conn.ConnectionString;
        //            conn.Open();
        //            cmd = new SqlCommand(StoredProcedureName);
        //            cmd.CommandTimeout = 20 * 60 * 1000;
        //            cmd.Connection = conn;
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = StoredProcedureName;
        //            cmd.Parameters.Clear();

        //            if (Parameters != null)
        //                foreach (SqlParameter op in Parameters.Values)
        //                    cmd.Parameters.Add(op);


        //            adapt.UpdateCommand = cmd;
        //            adapt.SelectCommand = cmd;

        //            if (resultDataSet == null)
        //            {
        //                cmd.ExecuteNonQuery();
        //            }
        //            else
        //                if (TableName == null)
        //                    adapt.Fill(resultDataSet, StoredProcedureName);
        //                else
        //                    adapt.Fill(resultDataSet, TableName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        exceptionOccured = true;
        //        originalException = ex;
        //    }
        //    finally
        //    {
        //        if (!(cmd == null))
        //        {

        //            cmd.Dispose();
        //        }
        //        if (!(conn == null))
        //        {
        //            conn.Close();
        //            conn.Dispose();
        //        }
        //    }
        //    if (exceptionOccured)
        //    {
        //        throw new Exception(originalException.Message, originalException);
        //    }
        //}

        //+
        public static void ExecuteProc(string StoredProcedureName, DataSet resultDataSet, string TableName, string ConnectionString)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                using (SqlDataAdapter adapt = new SqlDataAdapter())
                {
                    if (ConnectionString == null)
                        conn = new SqlConnection(""); 
                    else
                        conn = new SqlConnection(ConnectionString);
                    conn.ConnectionString = conn.ConnectionString;
                    conn.Open();
                    cmd = new SqlCommand(StoredProcedureName);
                    cmd.CommandTimeout = 20 * 60 * 1000;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = StoredProcedureName;
                    cmd.Parameters.Clear();

                   


                    adapt.UpdateCommand = cmd;
                    adapt.SelectCommand = cmd;

                    if (resultDataSet == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    else
                        if (TableName == null)
                            adapt.Fill(resultDataSet, StoredProcedureName);
                        else
                            adapt.Fill(resultDataSet, TableName);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //public static object ExecuteScalar(DbCommand cmd)
        //{
        //    return cmd.ExecuteScalar();
        //}

        //public static string ConvertToString(object ob)
        //{
        //    return (ob == null ? "" : ob.ToString());
        //}

        //public static string ConvertWithDelim(object ob, string del)
        //{
        //    string s = ConvertToString(ob);
        //    return AddDelim(s, del);
        //}

        //public static string AddDelim(string s, string del)
        //{
        //    if (s != "")
        //    {
        //        s = s + del;
        //    }
        //    return s;
        //}

        //public static int? ConvertFromString(string input)
        //{
        //    return (string.IsNullOrEmpty(input) ? (int?)null : int.Parse(input));
        //}

        //public static float? ConvertFloatFromString(string input)
        //{
        //    return (string.IsNullOrEmpty(input) ? (float?)null : float.Parse(input));
        //}


        //public static DateTime? ConvertDateFromString(string input)
        //{
        //    return (string.IsNullOrEmpty(input) ? (DateTime?)null : DateTime.Parse(input));
        //}

        //public static void AddParameter(Hashtable ht, string name, object value, SqlDbType partype)
        //{
        //    ht.Add(name, new SqlParameter(name, partype));
        //    if (value == null || (value.GetType() == typeof(string) && (string.IsNullOrEmpty(value.ToString()))))
        //    {
        //        ((SqlParameter)ht[name]).Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        ((SqlParameter)ht[name]).Value = value;
        //    }

        //    ((SqlParameter)ht[name]).SqlDbType = partype;


        //    //ht.Add(name, new OracleParameter(name, partype));
        //    //if (value != null)
        //    //{
        //    //    ((OracleParameter)ht[name]).Value = value;
        //    //}
        //    //else
        //    //{
        //    //    ((OracleParameter)ht[name]).Value = DBNull.Value;
        //    //}

        //}

        //public static void AddOutPar(Hashtable ht, string name, SqlDbType partype)
        //{
        //    AddOutPar(ht, name, partype, null);
        //    //ht.Add(name, new OracleParameter(name, partype));
        //    //((OracleParameter)ht[name]).Direction = ParameterDirection.Output;
        //}

        //public static void AddOutPar(Hashtable ht, string name, SqlDbType partype, int? size)
        //{

        //    ht.Add(name, new SqlParameter(name, partype));
        //    ((SqlParameter)ht[name]).Direction = ParameterDirection.ReturnValue;
        //    if (size != null)
        //    {
        //        ((SqlParameter)ht[name]).Size = Convert.ToInt32(size);
        //    }

        //    //ht.Add(name, new OracleParameter(name, partype));
        //    //((OracleParameter)ht[name]).Direction = ParameterDirection.Output;
        //    //if (size != null)
        //    //{
        //    //    ((OracleParameter)ht[name]).Size = Convert.ToInt32(size);
        //    //}
        //}

        //public static Object GetOutVal(Hashtable ht, string name)
        //{
        //    //return ((OracleParameter)ht[name]).Value;
        //    return ((SqlParameter)ht[name]).Value;
        //}
        //public static void ExecuteNonQuery(string storedProcedureName, string connectionString, params SqlParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand sqlCommand = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.StoredProcedure };
        //        if (parameters != null)
        //            sqlCommand.Parameters.AddRange(parameters);
        //        connection.Open();
        //        sqlCommand.ExecuteNonQuery();
        //    }
        //}

        //public static void ExecuteNonQuery2(string storedProcedureName, string connectionString, params SqlParameter[] parameters)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {

        //            SqlCommand sqlCommand = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.Text };
        //            sqlCommand.CommandTimeout = 20 * 60 * 1000;
        //            if (parameters != null) sqlCommand.Parameters.AddRange(parameters);
        //            connection.Open();
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        string _s = storedProcedureName;
        //        string _p = "[";

        //        if (parameters != null)
        //        {
        //            foreach (SqlParameter _pp in parameters)
        //            {
        //                string a = _pp.ParameterName + "=" + _pp.Value.ToString();
        //                _p = _p + a + ";";
        //            }
        //        }
        //        _p = _p + "]";

        //    }
        //}

        public static void ExecuteNonQuery2(string storedProcedureName, string connectionString, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.Text };
                    sqlCommand.CommandTimeout = 20 * 60 * 1000;
                    if (parameters != null) sqlCommand.Parameters.AddRange(parameters);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        //public static string SqlExecuteRetStr(string ss, string name, string connectionString)
        //{

        //    string retStr = "";
        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(ss, conn);
        //            SqlDataReader myReader999 = cmd.ExecuteReader();
        //            while (myReader999.Read())
        //            {
        //                //     insertLogErrorServer("позывной", ss);
        //                // try
        //                //  {
        //                //    this.file.WriteLine(DateTime.Now.ToString() + "2");
        //                if (myReader999[name] != System.DBNull.Value)
        //                {
        //                    retStr = retStr + myReader999[name].ToString();
        //                }
        //                else retStr = "";

        //                //   this.file.WriteLine(DateTime.Now.ToString() + myReader999["ConnectedDriverStr"].ToString());
        //                //    this.file.WriteLine(DateTime.Now.ToString() + "3");
        //                //   }
        //                //  catch { }
        //            }
        //            myReader999.Close();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return retStr;
        //}



    }
}