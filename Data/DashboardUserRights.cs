using DataStoreServices;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DashboardUserRights
/// </summary>
/// <author>osman.kaykac@isis-bt.com</author>

namespace Siteyonetim.Framework.Data
{

    public class DashboardUserRights
    {
        // private members

        public Sql_Gateway DB_Gateway;

        int m_AuthorityId;
        int m_UserId;
        string m_UserName;
        bool m_InsertAuthority;
        bool m_UpdateAuthority;
        bool m_DeleteAuthority;
        bool m_StartStopAuthority;

        //int m_UpdateAuthority;
        bool _COMMIT = false;
        //Herhangi bir DB isleminin döndürdügü hata mesajini saklar
        public string Error_Message = "";

        // empty constructor
        public DashboardUserRights()
        {
            DB_Gateway = new Sql_Gateway();
        }


        //Hata mesajlar?
        private string _Error;
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        // full constructor
        public DashboardUserRights(int AuthorityId, int UserId, string UserName,
                               bool InsertAuthority, bool UpdateAuthority, bool DeleteAuthority, bool StartStopAuthority)
        {
            this.AuthorityId = AuthorityId;
            this.UserId = UserId;
            this.UserName = UserName;
            this.InsertAuthority = InsertAuthority;
            this.UpdateAuthority = UpdateAuthority;
            this.DeleteAuthority = DeleteAuthority;
            this.StartStopAuthority = StartStopAuthority;
        }


        // public accessors
        public int AuthorityId
        {
            get { return m_AuthorityId; }
            set { m_AuthorityId = value; }
        }
        public int UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }

        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        public bool InsertAuthority
        {
            get { return m_InsertAuthority; }
            set { m_InsertAuthority = value; }
        }

        public bool UpdateAuthority
        {
            get { return m_UpdateAuthority; }
            set { m_UpdateAuthority = value; }
        }

        public bool DeleteAuthority
        {
            get { return m_DeleteAuthority; }
            set { m_DeleteAuthority = value; }
        }

        public bool StartStopAuthority
        {
            get { return m_StartStopAuthority; }
            set { m_StartStopAuthority = value; }
        }

        public bool Delete(SqlTransaction objTransaction, string connectionString, int pAuthorityId, string pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"DELETE DashboardUserRights 
                                    WHERE AuthorityId = @pAuthorityId
                                    AND UserId = @pUserId";
                    cmd.Parameters.AddWithValue("@pAuthorityId", pAuthorityId);
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    if (DB_Gateway.Execute(cmd, objTransaction, connection, false, true) != (int)GlobalEnum.DB_EXECUTE.FAIL)
                    {


                    }
                    return true;
                }
            }
        }

        // Insert Method With Transaction
        public bool Insert(SqlTransaction objTransaction, string connectionString)
        {
            try
            {

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cmd.CommandText = @" INSERT INTO DashboardUserRights 
                                                (UserId
                                                ,InsertAuthority                                            
                                                ,UpdateAuthority                                            
                                                ,DeleteAuthority
                                                ,StartStopAuthority)

                                         VALUES (@pUserId,
                                                 @pInsertAuthority,
                                                 @pUpdateAuthority,
                                                 @pDeleteAuthority,
                                                 @pStartStopAuthority)";

                        cmd.Parameters.AddWithValue("@pUserId", UserId);
                        cmd.Parameters.AddWithValue("@pInsertAuthority", InsertAuthority);
                        cmd.Parameters.AddWithValue("@pUpdateAuthority", UpdateAuthority);
                        cmd.Parameters.AddWithValue("@pDeleteAuthority", DeleteAuthority);
                        cmd.Parameters.AddWithValue("@pStartStopAuthority", StartStopAuthority);
                        int Id = (int)DB_Gateway.Execute(cmd, objTransaction, connection, false, true);
                        if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                        {
                            m_AuthorityId = Id;
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {

                _Error = exception.Source + exception.Message;
                return false;
            }
        }

        // Update Method With Transaction
        public bool Update(SqlTransaction objTransaction, string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"UPDATE DashboardUserRights 
                                           SET   UserId               = @pUserId
                                                ,InsertAuthority      = @pInsertAuthority
                                                ,UpdateAuthority      = @pUpdateAuthority
                                                ,DeleteAuthority      = @pDeleteAuthority
                                                ,StartStopAuthority   = @pStartStopAuthority
                                           WHERE AuthorityId = @pAuthorityId";

                    cmd.Parameters.AddWithValue("@pAuthorityId", AuthorityId);
                    cmd.Parameters.AddWithValue("@pUserId", UserId);
                    cmd.Parameters.AddWithValue("@pInsertAuthority", InsertAuthority);
                    cmd.Parameters.AddWithValue("@pUpdateAuthority", UpdateAuthority);
                    cmd.Parameters.AddWithValue("@pDeleteAuthority", DeleteAuthority);
                    cmd.Parameters.AddWithValue("@pStartStopAuthority", StartStopAuthority);
                    DB_Gateway.Execute(cmd, objTransaction, connection, false, false);
                    return true;
                }
            }
        }

        public bool GetItInsertAuthorityForUserId(string connectionString, string pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SELECT AuthorityId, UserId
                                               FROM DashboardUserRights
                                               WHERE UserId = @pUserId
                                               AND   InsertAuthority = 1";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TransferToClass(dr);
                                return true;
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return false;
                }
            }
        }

        public bool GetItUpdateAuthorityForUserId(string connectionString, string pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SELECT AuthorityId, UserId
                                               FROM DashboardUserRights
                                               WHERE UserId = @pUserId
                                               AND   UpdateAuthority = 1";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TransferToClass(dr);
                                return true;
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return false;
                }
            }
        }

        public bool GetItDeleteAuthorityForUserId(string connectionString, string pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SELECT AuthorityId, UserId
                                               FROM DashboardUserRights
                                               WHERE UserId = @pUserId
                                               AND   DeleteAuthority = 1";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TransferToClass(dr);
                                return true;
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return false;
                }
            }
        }

        public bool GetItStartStopAuthorityForUserId(string connectionString, string pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SELECT AuthorityId, UserId
                                               FROM DashboardUserRights
                                               WHERE UserId = @pUserId
                                               AND   StartStopAuthority = 1";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TransferToClass(dr);
                                return true;
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return false;
                }
            }
        }

        public DataTable GetAllListDataTable(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" SELECT * FROM DashboardUserRights";
                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                {
                    if (dt != null)
                    {
                        connection.Close();
                    }
                }
                return DB_Gateway.ExecuteDataTable(cmd, connection);
            }
        }

        public List<DashboardUserRights> GetAllListForUserId(string connectionString, int pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardUserRights> DashboardUserRightsList = new List<DashboardUserRights>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" SELECT  DU.AuthorityId, DU.UserId, DUR.UserName, DU.InsertAuthority, 
                                                 DU.UpdateAuthority, DU.DeleteAuthority, DU.StartStopAuthority
                                         FROM    DashboardUserRights AS DU, DashboardUser AS DUR
                                         WHERE   DU.UserId = DUR.UserId
                                         AND     DU.UserId = @pUserId";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardUserRights objDashboardUserRights = new DashboardUserRights();
                                objDashboardUserRights.TransferToClass(dr);
                                DashboardUserRightsList.Add(objDashboardUserRights);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardUserRightsList;
            }
        }


        private void TransferToClass(DataRow m_dtData)
        {
            m_AuthorityId = DataHelper.ReadInt32(m_dtData, "AuthorityId");
            m_UserId = DataHelper.ReadInt32(m_dtData, "UserId");
            m_UserName = DataHelper.ReadString(m_dtData, "UserName");
            m_InsertAuthority = DataHelper.ReadBool(m_dtData, "InsertAuthority");
            m_UpdateAuthority = DataHelper.ReadBool(m_dtData, "UpdateAuthority");
            m_DeleteAuthority = DataHelper.ReadBool(m_dtData, "DeleteAuthority");
            m_StartStopAuthority = DataHelper.ReadBool(m_dtData, "StartStopAuthority");
        }

    }

}