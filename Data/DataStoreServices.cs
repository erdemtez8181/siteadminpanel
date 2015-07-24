using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using Microsoft.CSharp;
using System.Collections.Specialized;
using System.Collections;


/// <summary>
/// Summary description for DataStoreServices
/// </summary>

namespace DataStoreServices
{

    public class Sql_Gateway
    {

        private IDbTransaction m_inDbTransaction;

        private IDbCommand m_DbCommand;

        #region Functions

        public IDbCommand getDbCommand
        {
            get
            {
                return this.m_DbCommand;
            }
        }
        public IDbTransaction getDbTransaction()
        {
            if (this.m_inDbTransaction != null)
                return this.m_inDbTransaction;
            return null;
        }

        public string getConnectionString()
        {
            string ConnectionString = String.Empty;

            ConnectionString = Siteyonetim.Framework.Business.GlobalSettings.OrganizationConnectionString;



            return ConnectionString;
        }

        public DataTable DataStoreServices(SqlCommand SqlCommand, IDbTransaction DbTransaction)
        {
            DataTable TempDataTable = new DataTable();
            SqlConnection SqlConnection = null;
            //SqlCommand SqlCommand = (SqlCommand)(this.CreateCommand(SQL));
            try
            {
                if (DbTransaction == null)
                {

                    SqlConnection = (SqlConnection)(this.CreateConnection(this.getConnectionString()));
                    SqlConnection.Open();
                }
                else
                {
                    SqlConnection = ((SqlTransaction)DbTransaction).Connection;
                    SqlCommand.Transaction = (SqlTransaction)DbTransaction;
                }
            }
            catch
            {
                throw;
            }

            // Set Command Connection
            SqlCommand.Connection = SqlConnection;

            SqlDataAdapter DataAdapter = (SqlDataAdapter)(this.CreateDataAdapter(SqlCommand));

            try
            {
                DataAdapter.Fill(TempDataTable);
            }
            catch (SqlException SqlException)
            {
                //Exception_Save(SqlException.Message, SQL);
                Exception_Save(SqlException.Message, SqlCommand);
                throw;
            }

            DataAdapter = null;

            if (DbTransaction == null)
            {
                if (SqlConnection != null) SqlConnection.Close();
            }

            return TempDataTable;
        }

        public DataTable DataStoreServices(string SQL, IDbTransaction DbTransaction)
        {
            DataTable TempDataTable = new DataTable();
            SqlConnection SqlConnection = null;
            SqlCommand SqlCommand = (SqlCommand)(this.CreateCommand(SQL));
            try
            {
                if (DbTransaction == null)
                {

                    SqlConnection = (SqlConnection)(this.CreateConnection(this.getConnectionString()));
                    SqlConnection.Open();
                }
                else
                {
                    SqlConnection = ((SqlTransaction)DbTransaction).Connection;
                    SqlCommand.Transaction = (SqlTransaction)DbTransaction;
                }
            }
            catch
            {
                throw;
            }

            // Set Command Connection
            SqlCommand.Connection = SqlConnection;

            SqlDataAdapter DataAdapter = (SqlDataAdapter)(this.CreateDataAdapter(SqlCommand));

            try
            {
                DataAdapter.Fill(TempDataTable);
            }
            catch (SqlException SqlException)
            {
                Exception_Save(SqlException.Message, SQL);
                throw;
            }

            DataAdapter = null;

            if (DbTransaction == null)
            {
                if (SqlConnection != null) SqlConnection.Close();
            }

            return TempDataTable;

        }

        public DataTable ExecuteDataTable(string SQL, System.Data.SqlClient.SqlConnection SqlConnection)
        {
            DataTable TempDataTable = new DataTable();

            if (SqlConnection.State != ConnectionState.Open)
                SqlConnection.Open();

            SqlCommand sqlCommand = (SqlCommand)(this.CreateCommand(SQL));

            // Set Command Connection
            sqlCommand.Connection = SqlConnection;

            SqlDataAdapter DataAdapter = (SqlDataAdapter)(this.CreateDataAdapter(sqlCommand));

            DataAdapter.Fill(TempDataTable);

            DataAdapter = null;

            if (SqlConnection != null) SqlConnection.Close();

            return TempDataTable;

        }

        public DataTable ExecuteDataTable(SqlCommand sqlCommand, SqlConnection Conn)
        {
            DataTable TempDataTable = new DataTable();

            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

            if (sqlCommand.Connection == null)
                sqlCommand.Connection = Conn;

            SqlDataAdapter DataAdapter = (SqlDataAdapter)(this.CreateDataAdapter(sqlCommand));
            DataAdapter.Fill(TempDataTable);
            DataAdapter = null;

            return TempDataTable;
        }

        public IDbTransaction BeginTransaction()
        {
            SqlTransaction SqlTransaction = null;

            try
            {
                SqlConnection SqlConnection = (SqlConnection)(this.CreateConnection(this.getConnectionString()));
                SqlConnection.Open();
                SqlTransaction = SqlConnection.BeginTransaction();
            }
            catch (SqlException sqlExc)
            {
                Exception_Save(sqlExc.Message, String.Empty);
                throw;
            }

            return SqlTransaction;
        }

        public DataTable ExecuteDataTable(SqlCommand DbCommand, SqlConnection Conn, SqlTransaction TransactionObject)
        {
            DataTable TempDataTable = new DataTable();

            if (TransactionObject != null)
            {
                DbCommand.Connection = TransactionObject.Connection;
                DbCommand.Transaction = TransactionObject;
                if (DbCommand.Connection.State != ConnectionState.Open)
                    DbCommand.Connection.Open();
            }
            else
            {
                if (Conn.State != ConnectionState.Open)
                    Conn.Open();
                DbCommand.Connection = Conn;
            }

            SqlDataAdapter DataAdapter = (SqlDataAdapter)(this.CreateDataAdapter(DbCommand));

            DataAdapter.Fill(TempDataTable);

            DataAdapter = null;

            return TempDataTable;
        }

        //Transaction var ise Transaction ile işlemleri yürüt, 
        //CreateNewTransaction ile connectiona bağlı transaction yürüt, 
        //hiç bişey yok ise sadece connection ile yürüt 
        public long Execute(IDbCommand DbCommand, SqlTransaction TransactionObject, SqlConnection ConnectionObject, bool CreateNewTransaction, bool NoID)
        {
            if (TransactionObject != null)
            {
                DbCommand.Connection = TransactionObject.Connection;
                DbCommand.Transaction = TransactionObject;
                if (DbCommand.Connection.State != ConnectionState.Open)
                    DbCommand.Connection.Open();
            }
            else
            {
                //transaction yok ise sadece connection ile bağlantı yap
                /*this.m_DbCommand.Connection = ConnectionObject;
                if (this.m_DbCommand.Connection.State == ConnectionState.Closed)
                    this.m_DbCommand.Connection.Open(); */

                DbCommand.Connection = ConnectionObject;
                if (DbCommand.Connection.State != ConnectionState.Open)
                    DbCommand.Connection.Open();
            }

            try
            {
                if (NoID)
                {
                    DbCommand.CommandTimeout = 300;
                    return DbCommand.ExecuteNonQuery();
                }
                else
                {
                    //Geriye ID dönülmesi isteniyor ise  sql comandına  scope_identity() parametresi ekleniyor.
                    DbCommand.CommandText = DbCommand.CommandText + ";";
                    DbCommand.CommandText += "SELECT CAST(scope_identity() AS int);";
                    DbCommand.CommandType = CommandType.Text;
                    object o = DbCommand.ExecuteScalar();
                    return o == DBNull.Value ? 0 : (int)o;
                }
            }
            catch (SqlException ex)
            {
                // Exception_Save(ex.Message, Convert.ToString(DbCommand));
                throw ex;
            }
            finally
            {
                if (TransactionObject == null)
                {
                    //'Transaction yoksa bağlantıyı kapat, transaction varsa, bağlantı  açık kalmalı...
                    //DbCommand.Connection.Close();
                }
            }
        }

        public long Execute(string SQL, IDbTransaction DbTransaction)
        {
            int returnCode = 0; ;

            SqlCommand SqlCommand = (SqlCommand)(this.CreateCommand(SQL));

            if (DbTransaction == null)
            {
                DbTransaction = BeginTransaction();
                this.m_inDbTransaction = DbTransaction;
                SqlCommand.Transaction = (SqlTransaction)DbTransaction;
                SqlCommand.Connection = (SqlConnection)(DbTransaction.Connection);
            }
            else
            {
                SqlCommand.Connection = ((SqlTransaction)DbTransaction).Connection;
                SqlCommand.Transaction = (SqlTransaction)DbTransaction;
            }

            try
            {
                returnCode = SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, SQL);
                throw ex;
            }
            finally
            {
                if (DbTransaction == null)
                {
                    //'Transaction yoksa bağlantıyı kapat, transaction varsa, bağlantı açık kalmalı...
                    SqlCommand.Connection.Close();
                }
            }

            SqlCommand = null;
            return returnCode;

        }

        public long Execute(IDbCommand DbCommand, object TransactionObject, bool NoID)
        {
            long lngNewID = 0;

            if (TransactionObject == null)
            {
                IDbTransaction DbTransaction = BeginTransaction();
                this.m_inDbTransaction = DbTransaction;
                DbCommand.Connection = (SqlConnection)(DbTransaction.Connection);
                DbCommand.Transaction = DbTransaction;

                if (DbCommand.Connection.State != ConnectionState.Open)
                    DbCommand.Connection.Open();
            }
            else
            {
                DbCommand.Connection = ((SqlTransaction)TransactionObject).Connection;
                DbCommand.Transaction = (SqlTransaction)TransactionObject;
            }

            try
            {
                DbCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, Convert.ToString(DbCommand));
                throw;
            }

            if (NoID)
            {
                lngNewID = 1;
            }
            else
            {
                lngNewID = Convert.ToInt64(((SqlCommand)DbCommand).Parameters[0].Value);  //'Insert için yeni al?nan ID'yi döndürür.
            }

            return lngNewID;

        }

        public long ExecuteScaler(SqlCommand cmd, IDbTransaction DbTransaction)
        {
            if (DbTransaction == null)
            {
                DbTransaction = BeginTransaction();
                this.m_inDbTransaction = DbTransaction;
                cmd.Transaction = (SqlTransaction)DbTransaction;
                cmd.Connection = (SqlConnection)(DbTransaction.Connection);
            }
            else
            {
                cmd.Connection = ((SqlTransaction)DbTransaction).Connection;
                cmd.Transaction = (SqlTransaction)DbTransaction;
            }

            try
            {
                return (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, cmd.CommandText);
                throw ex;
            }
            finally
            {
                if (DbTransaction == null)
                {
                    //'Transaction yoksa ba?lant?y? kapat, transaction varsa, ba?lant? aç?k kalmal?...
                    cmd.Connection.Close();
                }
            }
        }

        public int ExecuteNonQuery(SqlCommand cmd, IDbTransaction DbTransaction, IDbConnection DbConnection)
        {
            if (DbTransaction == null)
            {
                if (DbConnection.State != ConnectionState.Open)
                    DbConnection.Open();
                cmd.Connection = (SqlConnection)(DbConnection);
            }
            else
            {
                cmd.Connection = ((SqlTransaction)DbTransaction).Connection;
                cmd.Transaction = (SqlTransaction)DbTransaction;
            }

            try
            {
                return (int)cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, cmd.CommandText);
                throw ex;
            }
        }

        public object ExecuteScaler(SqlCommand cmd, IDbConnection DbConnection)
        {
            if (DbConnection.State != ConnectionState.Open)
                DbConnection.Open();
            cmd.Connection = (SqlConnection)(DbConnection);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, cmd.CommandText);
                throw ex;
            }
        }

        public object ExecuteScaler(IDbCommand DbCommand, IDbConnection DbConnection, IDbTransaction DbTransaction)
        {
            if (DbTransaction != null)
            {
                DbCommand.Connection = DbTransaction.Connection;
                DbCommand.Transaction = DbTransaction;
                if (DbCommand.Connection.State != ConnectionState.Open)
                    DbCommand.Connection.Open();
            }
            else
            {
                if (DbConnection.State != ConnectionState.Open)
                    DbConnection.Open();
                DbCommand.Connection = DbConnection;
            }
            try
            {
                return DbCommand.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, DbCommand.CommandText);
                throw ex;
            }
        }

        public void Exception_Save(string sMessage, SqlCommand SQLcommand)
        {
        }
        public void Exception_Save(string sMessage, string SQL)
        {
            //class_Standart BASIC = new class_Standart();

            //string strSQL = "INSERT INTO SQL_EXCEPTIONS (ID_EXCEPTION, DS_EXCEPTION, DS_SQL, DS_TARIH )" 
            //                + " VALUES (SEQ_ID_SQL_EXCEPTIONS.NEXTVAL , '" 
            //                + BASIC.Left(sMessage.Replace("'", "''").Replace("\"\"", "").Replace("\x0A", ""), 4000) 
            //                + "', '" + BASIC.Left(SQL.Replace("'", "''"), 4000) + "', sysdate)";

            //SqlCommand sqlCommand = new SqlCommand(strSQL);

            //sqlCommand.Connection = new SqlConnection(getConnectionString());
            //sqlCommand.Connection.Open();

            //try
            //{
            //    sqlCommand.ExecuteNonQuery();
            //}
            //catch (SqlException ex)
            //{
            //}
            //finally
            //{
            //    SqlCommand.Connection.Close();
            //}

            //sqlCommand = null;
        }

        public void myDataSet(string SQL, DataSet p_DataSet, string p_TableName)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand = new SqlCommand();

            SqlConnection = (SqlConnection)(this.CreateConnection(getConnectionString()));
            SqlConnection.Open();

            SqlCommand.Connection = SqlConnection;
            SqlCommand.CommandText = SQL;

            SqlDataAdapter SqlDataAdapter = (SqlDataAdapter)(this.CreateDataAdapter());
            SqlDataAdapter.SelectCommand = SqlCommand;

            try
            {
                SqlDataAdapter.Fill(p_DataSet, p_TableName);
            }
            catch (SqlException SqlExc)
            {
                Exception_Save(SqlExc.Message, SQL);
                throw;
            }

            SqlDataAdapter = null;
            if (SqlConnection != null) SqlConnection.Close();

        }
        public void ExecuteDataset(string SQL, DataSet p_DataSet, string p_TableName, SqlConnection SqlConnection)
        {
            SqlCommand SqlCommand = new SqlCommand();
            SqlConnection.Open();

            SqlCommand.Connection = SqlConnection;
            SqlCommand.CommandText = SQL;

            SqlDataAdapter SqlDataAdapter = (SqlDataAdapter)(this.CreateDataAdapter());
            SqlDataAdapter.SelectCommand = SqlCommand;

            try
            {
                SqlDataAdapter.Fill(p_DataSet, p_TableName);
            }
            catch (SqlException SqlExc)
            {
                Exception_Save(SqlExc.Message, SQL);
                throw;
            }

            SqlDataAdapter = null;
            if (SqlConnection != null) SqlConnection.Close();
        }

        public DataSet ExecuteDataset(System.Data.SqlClient.SqlCommand SqlCommand, SqlConnection SqlConnection)
        {
            DataSet ds = new DataSet();

            SqlCommand.Connection = SqlConnection;
            SqlDataAdapter SqlDataAdapter = (SqlDataAdapter)(this.CreateDataAdapter());
            SqlDataAdapter.SelectCommand = SqlCommand;

            SqlDataAdapter.Fill(ds);

            SqlDataAdapter = null;
            if (SqlConnection != null) SqlConnection.Close();
            return ds;
        }

        public DataTable DataStoreServicesProc(IDbCommand DbCommand)
        {
            DbCommand.Connection = (SqlConnection)(this.CreateConnection(getConnectionString()));
            DbCommand.Connection.Open();

            SqlDataAdapter SqlDataAdapter = (SqlDataAdapter)(this.CreateDataAdapter(DbCommand));
            DataSet DataSet = new DataSet();

            SqlDataAdapter.Fill(DataSet, "Temp");
            SqlDataAdapter = null;

            DbCommand.Connection.Close();

            return DataSet.Tables[0];
        }

        public bool ExecuteProcedure(IDbCommand SqlCommand, object TransactionObject)
        {
            if (TransactionObject == null)
            {
                SqlCommand.Connection = (SqlConnection)(this.CreateConnection(getConnectionString()));
                SqlCommand.Connection.Open();
            }
            else
            {
                SqlCommand.Transaction = (SqlTransaction)TransactionObject;
                SqlCommand.Connection = SqlCommand.Transaction.Connection;
            }

            try
            {
                SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Exception_Save(ex.Message, Convert.ToString(SqlCommand));
                return false;
            }
            finally
            {
                if (TransactionObject == null)
                {
                    //'Transaction yoksa baðlantýyý kapat, transaction varsa, baðlantý açýk kalmalý...
                    SqlCommand.Connection.Close();
                }
            }
            return true;
        }
        #endregion

        #region Command
        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public IDbCommand CreateCommand(string cmdText)
        {
            return new SqlCommand(cmdText);
        }

        public IDbCommand CreateCommand(string cmdText, IDbConnection connection)
        {
            IDbCommand SqlCommand = null;

            try
            {
                SqlCommand = new SqlCommand(cmdText, (SqlConnection)connection);
            }
            catch (SqlException sqlExc)
            {
                if (SqlCommand != null)
                    SqlCommand.Dispose();

                throw new Exception(sqlExc.Message);
            }

            return SqlCommand;
        }

        public IDbCommand CreateCommand(string cmdText, IDbConnection connection, IDbTransaction transaction)
        {
            IDbCommand SqlCommand = null;

            try
            {
                SqlCommand = new SqlCommand(cmdText, (SqlConnection)connection, (SqlTransaction)transaction);
            }
            catch (SqlException sqlExc)
            {
                if (SqlCommand != null)
                    SqlCommand.Dispose();

                throw new Exception(sqlExc.Message);
            }

            return SqlCommand;
        }
        #endregion

        #region DataReader
        public IDataReader CreateDataReader(IDbCommand dbCommand)
        {
            IDataReader dr = null;

            try
            {
                dr = dbCommand.ExecuteReader();
            }
            catch (SqlException sqlExc)
            {
                if (dr != null)
                {
                    if (!dr.IsClosed)
                        dr.Close();

                    dr.Dispose();
                }

                throw new Exception(sqlExc.Message);
            }

            return dr;
        }

        public IDataReader CreateDataReader(IDbCommand dbCommand, System.Data.CommandBehavior dbCommandBehavior)
        {
            IDataReader dr = null;

            try
            {
                dr = dbCommand.ExecuteReader(dbCommandBehavior);
            }
            catch (SqlException sqlExc)
            {
                if (dr != null)
                {
                    if (!dr.IsClosed)
                        dr.Close();

                    dr.Dispose();
                }

                throw new Exception(sqlExc.Message);
            }

            return dr;
        }
        #endregion

        #region Connection
        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            IDbConnection SqlConnection = null;

            try
            {
                SqlConnection = new SqlConnection(connectionString);
            }
            catch (SqlException sqlExc)
            {
                throw new Exception(sqlExc.Message);
            }

            return SqlConnection;
        }
        #endregion

        #region DataAdapter

        public IDbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }

        public IDbDataAdapter CreateDataAdapter(IDbCommand selectCommand)
        {
            IDbDataAdapter SqlDataAdapter = null;

            try
            {
                SqlDataAdapter = new SqlDataAdapter((SqlCommand)selectCommand);
            }
            catch (SqlException sqlExc)
            {
                throw new Exception(sqlExc.Message);
            }

            return SqlDataAdapter;
        }

        public IDbDataAdapter CreateDataAdapter(string selectCommandText, string selectConnectionString)
        {
            IDbDataAdapter SqlDataAdapter = null;

            try
            {
                SqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnectionString);
            }
            catch (SqlException sqlExc)
            {
                throw new Exception(sqlExc.Message);
            }

            return SqlDataAdapter;
        }

        public IDbDataAdapter CreateDataAdapter(string selectCommandText, IDbConnection selectConnection)
        {
            IDbDataAdapter SqlDataAdapter = null;

            try
            {
                SqlDataAdapter = new SqlDataAdapter(selectCommandText, (SqlConnection)selectConnection);
            }
            catch (SqlException sqlExc)
            {
                throw new Exception(sqlExc.Message);
            }

            return SqlDataAdapter;
        }
        #endregion
    }

    public class DataAccessLayer
    {
        public Sql_Gateway CreateDAL()
        {
            return new Sql_Gateway();
            //Sql_Gateway dataAccessLayer = null;

            //switch (dbType)
            //{
            //    case DalDbType.SqlServer2000:
            //        dataAccessLayer = new Sql_Gateway();
            //        break;
            //    //case DalDbType.SqlServer2000:
            //    //    dataAccessLayer = new SqlServer2000Dal();
            //    //    break;
            //    //case DalDbType.DB2iSeries:
            //    //    dataAccessLayer = new DB2iSeriesDal();
            //    //    break;
            //}

            //return dataAccessLayer;
        }
    }

    public class StoredProcedure : MarshalByRefObject, IDisposable
    {
        private Sql_Gateway m_dal = null;
        private bool m_disposed = false;
        private IDbCommand m_cmd = null;
        private string m_name = String.Empty;
        private bool m_cacheDisconnectData = false;
        private string m_connectionString = String.Empty;
        private SortedList m_parameters = new SortedList();

        #region Public

        #region Public Methods

        #region Overrides

        public override int GetHashCode()
        {
            controlIfDisposed();
            return base.GetHashCode();
        }


        public override string ToString()
        {
            controlIfDisposed();
            return base.ToString();
        }


        public override bool Equals(object obj)
        {
            controlIfDisposed();
            return base.Equals(obj);
        }


        #endregion

        #region Parameters

        public void ClearParameters()
        {
            controlIfDisposed();

            m_parameters.Clear();
            m_cmd.Parameters.Clear();
        }


        public IDbDataParameter CreateParameter()
        {
            controlIfDisposed();

            return m_cmd.CreateParameter();
        }


        public void AddParameter(IDbDataParameter parameter)
        {
            controlIfDisposed();

            m_parameters.Add(parameter.ParameterName + parameter.Value.ToString(), parameter);
        }


        public void AddParameters(IDbDataParameter[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
                AddParameter(parameters[i]);
        }


        #endregion


        /// <summary>
        /// Enable to dispose itself
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public int ExecuteNonQuery()
        {
            int result = 0;

            coreSettings();

            try
            {
                if (m_cmd.Connection.State != ConnectionState.Open)
                    m_cmd.Connection.Open();

                result = m_cmd.ExecuteNonQuery();
            }
            catch
            {
                result = -1;
            }
            finally
            {
                if (m_cmd.Connection != null && m_cmd.Connection.State == ConnectionState.Open)
                    m_cmd.Connection.Close();
            }

            return result;
        }


        public object ExecuteScalar()
        {
            return manageCaching(operationType.GetScalar);
        }


        public IDataReader CreateDataReader()
        {
            IDataReader dr = null;

            coreSettings();

            try
            {
                if (m_cmd.Connection.State != ConnectionState.Open)
                    m_cmd.Connection.Open();

                dr = m_cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exc)
            {
                Dispose(true);

                throw new Exception(exc.Message);
            }

            return dr;
        }


        /// <summary>
        /// Create a ResultSets.
        /// </summary>
        /// <returns>Return DataSet<./returns>
        public DataSet GetResultSet()
        {
            return (DataSet)manageCaching(operationType.GetResultSet);

            //DataSet ds = new DataSet("DS");

            //			coreSettings();
            //
            //			try
            //			{
            //				IDbDataAdapter da = m_dal.CreateDataAdapter(m_cmd);
            //				da.Fill(ds);
            //			}
            //			catch(Exception exc)
            //			{
            //				Dispose(true);
            //
            //				throw new Exception(exc.Message);
            //			}
            //			finally
            //			{
            //				if(m_cmd.Connection != null && m_cmd.Connection.State == ConnectionState.Open)
            //					m_cmd.   if (connection != null) connection.Close();
            //			}
            //			
            //			return ds;
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                controlIfDisposed();
                return m_name;
            }
            set
            {
                controlIfDisposed();
                m_name = value;
            }
        }


        public string ConnectionString
        {
            get
            {
                controlIfDisposed();
                return m_connectionString;
            }
            set
            {
                controlIfDisposed();
                m_connectionString = value;
            }
        }


        public bool CacheDisconnectData
        {
            get
            {
                controlIfDisposed();
                return m_cacheDisconnectData;
            }
            set
            {
                controlIfDisposed();
                m_cacheDisconnectData = value;
            }
        }


        #endregion

        #endregion

        #region Private

        #region Private Methods

        /// <summary>
        /// Set core stored procedure settings.
        /// </summary>
        private void coreSettings()
        {
            controlIfDisposed();

            try
            {
                if (m_cmd.Connection.State != ConnectionState.Open)
                    m_cmd.Connection.ConnectionString = m_connectionString;
            }
            catch
            {

                throw new Exception("Wrong connection string !!!");
            }

            // Set stored procedure's name. 
            m_cmd.CommandText = m_name;

            // Add parameters from m_parameters (SortedList) to command.
            addParameters(m_parameters);
        }


        /// <summary>
        /// If object is disposed throw an exception. 
        /// </summary>
        private void controlIfDisposed()
        {
            if (m_disposed)
                throw new Exception("You can't use StoredProcedure object because it has been disposed !!!");
        }


        /// <summary>
        /// Dispose StoredProcedures; resources.
        /// </summary>
        /// <param name="disposing">If false dispose unmanaged resources else dispose managed resources.</param>
        protected void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (m_cmd != null)
                {
                    // If disposing is true dispose managed resources
                    if (disposing)
                        if (m_cmd.Connection != null)
                        {
                            if (m_cmd.Connection.State == ConnectionState.Open)
                                m_cmd.Connection.Close();

                        }

                    // Dispose unmanaged resources

                    try
                    {
                        m_cmd.Dispose();
                    }
                    catch (Exception exc)
                    {
                        string excep = exc.Message;
                    }

                    m_cmd = null;
                }
            }

            m_disposed = true;
        }


        /// <summary>
        /// Create a unique identifier.
        /// </summary>
        /// <param name="oType">Operation Type (GetDataAdapter or GetScalar).</param>
        /// <returns>Return a unique identifier.</returns>
        private string getKey(operationType oType)
        {
            StringBuilder key = new StringBuilder(100);

            // Add stored procedure name to key.
            key.Append(m_name);

            foreach (DictionaryEntry parameter in m_parameters)
            {
                // Add parameter name - value to key.
                key.Append(parameter.Key.ToString());
            }


            // Add operation type to key.
            key.Append(oType.ToString());

            return key.ToString();
        }


        /// <summary>
        /// Add stored procedure's parameters to IDataParameterCollection
        /// </summary>
        /// <param name="parameters">IDbDataParameter's sorted list</param>
        private void addParameters(SortedList parameters)
        {
            m_cmd.Parameters.Clear();

            foreach (DictionaryEntry parameter in parameters)
                m_cmd.Parameters.Add(parameter.Value);
        }


        /// <summary>
        /// Get a disconnected object from cache if caching has been required, from db otherwise. 
        /// </summary>
        /// <param name="oType">Operation Type (GetDataAdapter or GetScalar).</param>
        /// <returns>Return a disconnected object.</returns>
        private object manageCaching(operationType oType)
        {
            string key = String.Empty;
            object returnedObject = null;

            coreSettings();

            //Is caching required?
            if (m_cacheDisconnectData == true)
            {
                //Get unique identifier.
                key = getKey(oType);

                //Get object from cache.
                returnedObject = System.Web.HttpRuntime.Cache.Get(key);

                //Is object found ?
                if (returnedObject == null)
                {
                    //Create and cache a new disconnected object.
                    returnedObject = getDisconnectObject(oType);
                    System.Web.HttpRuntime.Cache.Insert(key, returnedObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(1800));
                }
            }
            else
                returnedObject = getDisconnectObject(oType);

            return returnedObject;
        }


        /// <summary>
        /// Get a disconnected object.
        /// </summary>
        /// <param name="oType">Operation Type (GetDataAdapter or GetScalar).</param>
        /// <returns>Return a disconnected object.</returns>
        private object getDisconnectObject(operationType oType)
        {
            object returnedObject = null;

            try
            {
                if (m_cmd.Connection.State != ConnectionState.Open)
                    m_cmd.Connection.Open();

                switch (oType)
                {
                    case operationType.GetScalar: // Return a new Scalar object.
                        returnedObject = m_cmd.ExecuteScalar();
                        break;
                    case operationType.GetResultSet: // Return a new ResultSet.
                        returnedObject = new DataSet();
                        m_dal.CreateDataAdapter(m_cmd).Fill((DataSet)returnedObject);
                        break;
                }
            }
            finally
            {
                if (m_cmd.Connection != null && m_cmd.Connection.State == ConnectionState.Open)
                    m_cmd.Connection.Close();
            }

            return returnedObject;
        }


        #endregion

        private enum operationType { GetScalar, GetResultSet }


        #endregion

        #region Constructor and Destructor

        public StoredProcedure(Sql_Gateway dal)
        {
            if (dal == null)
                throw new Exception("Savet.Framework.Data.StoredProcedure - IDal parameter cannot be null.");

            m_dal = dal;
            m_cmd = m_dal.CreateCommand();
            m_cmd.Connection = m_dal.CreateConnection();
            m_cmd.CommandType = CommandType.StoredProcedure;
        }


        ~StoredProcedure()
        {
            Dispose(false);
        }


        #endregion

    }
}