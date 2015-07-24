using DataStoreServices;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DashboardUser
/// </summary>
/// <author>osman.kaykac@isis-bt.com</author>

namespace Siteyonetim.Framework.Data
{

    public class DashboardUser
    {
        // private members

        public Sql_Gateway DB_Gateway;

        int m_UserId;
        string m_UserName;
        string m_Password;
        string m_Email;
        string m_Name;
        string m_Surname;
        string m_Mission;
        string m_Telephone;
        string m_ImageName;
        int m_Active;
        //int m_Active;
        bool _COMMIT = false;
        //Herhangi bir DB isleminin döndürdügü hata mesajini saklar
        public string Error_Message = "";

        // empty constructor
        public DashboardUser()
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
        public DashboardUser(int UserId, string UserName,
                               string Password, string Email, string Name, string Surname, string Mission,
                               string Telephone, string ImageName, int Active)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.Name = Name;
            this.Surname = Surname;
            this.Mission = Mission;
            this.Telephone = Telephone;
            this.ImageName = ImageName;
            this.Active = Active;
        }


        // public accessors
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
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public string Surname
        {
            get { return m_Surname; }
            set { m_Surname = value; }
        }
        public string Mission
        {
            get { return m_Mission; }
            set { m_Mission = value; }
        }
        public string Telephone
        {
            get { return m_Telephone; }
            set { m_Telephone = value; }
        }
        public string ImageName
        {
            get { return m_ImageName; }
            set { m_ImageName = value; }
        }
        public int Active
        {
            get { return m_Active; }
            set { m_Active = value; }
        }

        public bool DeleteVirtual(SqlTransaction objTransaction, string connectionString, int pUserId, string pUserName)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"UPDATE DashboardUser
                                    WHERE UserId = @pUserId
                                    AND UserName = @pUserName
									AND Active = 0";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    cmd.Parameters.AddWithValue("@pUserName", pUserName);
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
                        cmd.CommandText = @" INSERT INTO DashboardUser 
                                                (UserName
                                                ,Password                                            
                                                ,Email                                            
                                                ,Name                                            
                                                ,Surname                                            
                                                ,Mission                                            
                                                ,Telephone                                              
                                                ,ImageName                                              
                                                ,Active)

                                         VALUES (@pUserName,
                                                 @pPassword,
                                                 @pEmail,
                                                 @pName,
                                                 @pSurname,
                                                 @pMission,
                                                 @pTelephone,
                                                 @pImageName,
                                                 @pActive)";

                        cmd.Parameters.AddWithValue("@pUserName", UserName);
                        cmd.Parameters.AddWithValue("@pPassword", Password);
                        cmd.Parameters.AddWithValue("@pEmail", Email);
                        cmd.Parameters.AddWithValue("@pName", Name);
                        cmd.Parameters.AddWithValue("@pSurname", Surname);
                        cmd.Parameters.AddWithValue("@pMission", Mission);
                        cmd.Parameters.AddWithValue("@pTelephone", Telephone);
                        cmd.Parameters.AddWithValue("@pImageName", ImageName);
                        cmd.Parameters.AddWithValue("@pActive", Active);
                        int Id = (int)DB_Gateway.Execute(cmd, objTransaction, connection, false, true);
                        if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                        {
                            m_UserId = Id;
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

        public bool RegisterUser(SqlTransaction objTransaction, string connectionString)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cmd.CommandText = @" INSERT INTO DashboardUser 
                                                (UserName
                                                ,Password                                              
                                                ,Name                                              
                                                ,Active)

                                         VALUES (@pUserName,
                                                 @pPassword,
                                                 @pName,
                                                 @pActive)";

                        cmd.Parameters.AddWithValue("@pUserName", UserName);
                        cmd.Parameters.AddWithValue("@pPassword", Password);
                        cmd.Parameters.AddWithValue("@pName", Name);
                        cmd.Parameters.AddWithValue("@pActive", Active);
                        int Id = (int)DB_Gateway.Execute(cmd, objTransaction, connection, false, true);
                        if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                        {
                            m_UserId = Id;
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
        public bool UpdateUserInfo(SqlTransaction objTransaction, string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"UPDATE DashboardUser 
                                           SET   UserName   = @pUserName
                                                ,Email      = @pEmail
                                                ,Name       = @pName
                                                ,Surname    = @pSurname
                                                ,Mission    = @pMission
                                                ,Telephone  = @pTelephone
                                                ,ImageName  = @pImageName
                                                ,Active     = @pActive
                                           WHERE UserId = @pUserId";

                    cmd.Parameters.AddWithValue("@pUserId", UserId);
                    cmd.Parameters.AddWithValue("@pUserName", UserName);
                    cmd.Parameters.AddWithValue("@pEmail", Email);
                    cmd.Parameters.AddWithValue("@pName", Name);
                    cmd.Parameters.AddWithValue("@pSurname", Surname);
                    cmd.Parameters.AddWithValue("@pMission", Mission);
                    cmd.Parameters.AddWithValue("@pTelephone", Telephone);
                    cmd.Parameters.AddWithValue("@pImageName", ImageName);
                    cmd.Parameters.AddWithValue("@pActive", Active);
                    //cmd.Parameters.AddWithValue("@pNewUserName", pNewUserName);
                    DB_Gateway.Execute(cmd, objTransaction, connection, false, false);
                    return true;
                }
            }
        }

        public bool UpdateUserPassword(SqlTransaction objTransaction, string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"UPDATE DashboardUser 
                                           SET   Password   = @pPassword
                                           WHERE UserId = @pUserId";

                    cmd.Parameters.AddWithValue("@pUserId", UserId);
                    cmd.Parameters.AddWithValue("@pPassword", Password);
                    DB_Gateway.Execute(cmd, objTransaction, connection, false, false);
                    return true;
                }
            }
        }

        public bool UpdateNewPasswordForForget(SqlTransaction objTransaction, string connectionString, string Password, string pEmail)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"UPDATE DashboardUser 
                                           SET   Password   = @pPassword
                                           WHERE Email = @pEmail";

                    cmd.Parameters.AddWithValue("@pEmail", pEmail);
                    cmd.Parameters.AddWithValue("@pPassword", Password);
                    DB_Gateway.Execute(cmd, objTransaction, connection, false, false);
                    return true;
                }
            }
        }

        public bool GetItForUserName(string connectionString, string pUserName)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SELECT UserId, UserName, Password, Email, Name, Surname, 
                                               Mission, Telephone, ImageName, Active
                                               FROM DashboardUser
                                               WHERE UserName = @pUserName";
                    cmd.Parameters.AddWithValue("@pUserName", pUserName);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TransferToClass(dr);
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return true;
                }
            }
        }

        public bool GetItForEmailAddress(string connectionString, string pEmail)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SELECT Email, Active
                                               FROM DashboardUser
                                               WHERE Email = @pEmail
                                               AND Active = 1";
                    cmd.Parameters.AddWithValue("@pEmail", pEmail);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                TransferToClass(dr);
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return true;
                }
            }
        }

        public DataTable GetAllListDataTable(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" SELECT * FROM DashboardUser";
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

        public List<DashboardUser> GetAllActiveUserList(string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardUser> DashboardUserList = new List<DashboardUser>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" SELECT UserId, UserName, Password, Email, Name, Surname, 
                                                Mission, Telephone, ImageName, Active
                                         FROM DashboardUser
                                         WHERE Active = 1";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardUser objDashboardUser = new DashboardUser();
                                objDashboardUser.TransferToClass(dr);
                                DashboardUserList.Add(objDashboardUser);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardUserList;
            }
        }

        public bool GetAllActiveUserForUserId(string connectionString, string pUserId)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardUser> DashboardUserList = new List<DashboardUser>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" SELECT UserId, UserName, Password, Email, Name, Surname, 
                                                Mission, Telephone, ImageName, Active
                                         FROM DashboardUser
                                         WHERE Active = 1
                                         AND UserId = @pUserId";
                    cmd.Parameters.AddWithValue("@pUserId", pUserId);
                    using (DataTable dt = new Sql_Gateway().ExecuteDataTable(cmd, connection))
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

        public bool authenticate(string connectionString, string p_Username, string p_Password)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM  DashboardUser 
                                                 WHERE Username = @pUsername AND Password = @pPassword
                                                 AND   Active = 1";
                    cmd.Parameters.AddWithValue("@pUsername", p_Username);
                    cmd.Parameters.AddWithValue("@pPassword", p_Password);

                    using (DataTable dt = new Sql_Gateway().ExecuteDataTable(cmd, connection))
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
                    return false;
                }
            }
        }

        public bool authenticateForLockScreen(string connectionString, string p_Password)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM  DashboardUser 
                                                 WHERE Password = @pPassword
                                                 AND   Active = 1";
                    cmd.Parameters.AddWithValue("@pPassword", p_Password);
                    using (DataTable dt = new Sql_Gateway().ExecuteDataTable(cmd, connection))
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
                    return false;
                }
            }
        }

        private void TransferToClass(DataRow m_dtData)
        {
            m_UserId = DataHelper.ReadInt32(m_dtData, "UserId");
            m_UserName = DataHelper.ReadString(m_dtData, "UserName");
            m_Password = DataHelper.ReadString(m_dtData, "Password");
            m_Email = DataHelper.ReadString(m_dtData, "Email");
            m_Name = DataHelper.ReadString(m_dtData, "Name");
            m_Surname = DataHelper.ReadString(m_dtData, "Surname");
            m_Mission = DataHelper.ReadString(m_dtData, "Mission");
            m_Telephone = DataHelper.ReadString(m_dtData, "Telephone");
            m_ImageName = DataHelper.ReadString(m_dtData, "ImageName");
            m_Active = DataHelper.ReadInt32(m_dtData, "Active");
        }

    }

}