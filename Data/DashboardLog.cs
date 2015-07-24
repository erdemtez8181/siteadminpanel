using DataStoreServices;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DashboardLog
/// </summary>
/// <author>osman.kaykac@isis-bt.com</author>

namespace Siteyonetim.Framework.Data
{

    public class DashboardLog
    {
        // private members

        public Sql_Gateway DB_Gateway;

        int m_DashboardLogId;
        int m_ProcessType;
        string m_UserName;
        string m_ActionMessage;
        string m_ActionWhy;
        DateTime m_ActionDate;
        //int m_ActionDate;
        bool _COMMIT = false;
        //Herhangi bir DB isleminin döndürdügü hata mesajini saklar
        public string Error_Message = "";

        // empty constructor
        public DashboardLog()
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
        public DashboardLog(int DashboardLogId, int ProcessType, string UserName,
                               string ActionMessage, string ActionWhy, DateTime ActionDate)
        {
            this.DashboardLogId = DashboardLogId;
            this.ProcessType = ProcessType;
            this.UserName = UserName;
            this.ActionMessage = ActionMessage;
            this.ActionWhy = ActionWhy;
            this.ActionDate = ActionDate;
        }


        // public accessors
        public int DashboardLogId
        {
            get { return m_DashboardLogId; }
            set { m_DashboardLogId = value; }
        }
        public int ProcessType
        {
            get { return m_ProcessType; }
            set { m_ProcessType = value; }
        }
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        public string ActionMessage
        {
            get { return m_ActionMessage; }
            set { m_ActionMessage = value; }
        }
        public string ActionWhy
        {
            get { return m_ActionWhy; }
            set { m_ActionWhy = value; }
        }

        public DateTime ActionDate
        {
            get { return m_ActionDate; }
            set { m_ActionDate = value; }
        }

        public bool DeleteVirtual(SqlTransaction objTransaction, string connectionString, int pDashboardLogId, string pUserName)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"UPDATE DashboardLog
                                    WHERE DashboardLogId = @pDashboardLogId
                                    AND UserName = @pUserName
									AND ActionDate = 0";
                    cmd.Parameters.AddWithValue("@pDashboardLogId", pDashboardLogId);
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
                        cmd.CommandText = @" INSERT INTO  DashboardLog 
                                                (ProcessType
                                                ,UserName
                                                ,ActionMessage                                              
                                                ,ActionWhy                                              
                                                ,ActionDate)

                                         VALUES (@pProcessType,
                                                 @pUserName,
                                                 @pActionMessage,
                                                 @pActionWhy,
                                                 @pActionDate)";

                        cmd.Parameters.AddWithValue("@pProcessType", ProcessType);
                        cmd.Parameters.AddWithValue("@pUserName", UserName);
                        cmd.Parameters.AddWithValue("@pActionMessage", ActionMessage);
                        cmd.Parameters.AddWithValue("@pActionWhy", ActionWhy);
                        cmd.Parameters.AddWithValue("@pActionDate", ActionDate);
                        DB_Gateway.Execute(cmd, objTransaction, connection, false, false);
                        return true;
                        //int Id = (int)DB_Gateway.Execute(cmd, objTransaction, connection, false, true);
                        //if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                        //{
                        //    DashboardLogId = Id;
                        //    return true;
                        //}
                        //return false;
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
                    cmd.CommandText = @"UPDATE DashboardLog 
                                           SET   ProcessType    = @pProcessType
                                                ,UserName       = @pUserName
                                                ,ActionMessage  = @pActionMessage
                                                ,ActionWhy      = @pActionWhy
                                                ,ActionDate     = @pActionDate
                                           WHERE DashboardLogId = @pDashboardLogId";

                    cmd.Parameters.AddWithValue("@pDashboardLogId", DashboardLogId);
                    cmd.Parameters.AddWithValue("@pProcessType", ProcessType);
                    cmd.Parameters.AddWithValue("@pUserName", UserName);
                    cmd.Parameters.AddWithValue("@pActionMessage", ActionMessage);
                    cmd.Parameters.AddWithValue("@pActionWhy", ActionWhy);
                    cmd.Parameters.AddWithValue("@pActionDate", ActionDate);
                    //cmd.Parameters.AddWithValue("@pNewUserName", pNewUserName);
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

                    cmd.CommandText = @"SELECT DashboardLogId, ProcessType, UserName, ActionMessage, ActionWhy, ActionDate
                                               FROM DashboardLog
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

        public bool DeleteNewCompanyForEInvoice(string connectionString, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                        BEGIN TRAN;
                                        DECLARE @NEWVKN NVARCHAR(11) = @pNewVKN;
                                        
                                          DELETE
                                          FROM [Organization].[dbo].[Partner]
                                          WHERE VKN = @NEWVKN;
                                          
                                          --DELETE
                                          --FROM [Organization].[dbo].[gn_Accountant]
                                          --WHERE VKN = @NEWVKN;
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[ParameterValues]
                                          where VKN = @NEWVKN;
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                            WHERE VKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[JobPosition]
                                            WHERE VKN = @NEWVKN                                          
                                            
                                          DELETE
                                          FROM [Organization].[dbo].[PartnerModules]
                                          WHERE VKN_TCKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[UserApprovalHierarchy]
                                          WHERE VKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[ApprovalHierarchy]
                                          WHERE VKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[UserMenu]
                                          WHERE VKN_TCKN = @NEWVKN
                                          
                                          COMMIT TRAN;
                                          EXEC('ALTER DATABASE Efatura_' + @NEWVKN + ' SET SINGLE_USER WITH ROLLBACK IMMEDIATE')
                                          EXEC('DROP DATABASE Efatura_' + @NEWVKN + '')";

                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            if (connection != null) connection.Close();
                            return true;
                        }
                        else
                        {
                            if (connection != null) connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool DeleteNewCompanyForELedger(string connectionString, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                        BEGIN TRAN;
                                        DECLARE @NEWVKN NVARCHAR(11) = @pNewVKN;
                                        
                                          --DELETE
                                          --FROM [Organization].[dbo].[Partner]
                                          --WHERE VKN = @NEWVKN;
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[gn_Accountant]
                                          WHERE VKN = @NEWVKN;
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[ParameterValues]
                                          where VKN = @NEWVKN;
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                            WHERE VKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[JobPosition]
                                            WHERE VKN = @NEWVKN                                         
                                            
                                          DELETE
                                          FROM [Organization].[dbo].[PartnerModules]
                                          WHERE VKN_TCKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[UserApprovalHierarchy]
                                          WHERE VKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[ApprovalHierarchy]
                                          WHERE VKN = @NEWVKN
                                          
                                          DELETE
                                          FROM [Organization].[dbo].[UserMenu]
                                          WHERE VKN_TCKN = @NEWVKN
                                          
                                          COMMIT TRAN;
                                          EXEC('ALTER DATABASE Eledger_' + @NEWVKN + ' SET SINGLE_USER WITH ROLLBACK IMMEDIATE')
                                          EXEC('DROP DATABASE Eledger_' + @NEWVKN + '')";

                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            if (connection != null) connection.Close();
                            return true;
                        }
                        else
                        {
                            if (connection != null) connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool CreateNewCompanyForEInvoice(string connectionString, string pOldVKN, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                            BEGIN TRAN;
                                            DECLARE @OLDVKN NVARCHAR(11) = @pOldVKN;
                                            DECLARE @NEWVKN NVARCHAR(11) = @pNewVKN;
                                            DECLARE @NEWPARTNERID INT;
                                            
                                            INSERT INTO [Organization].[dbo].[Partner]
                                            (
                                                   [OrganizationCode]
                                                  ,[VKN]
                                                  ,[TCKN]
                                                  ,[UNVAN]
                                                  ,[Name]
                                                  ,[Surname]
                                                  ,[StreetName]
                                                  ,[BuildingName]
                                                  ,[BuildingNumber]
                                                  ,[Room]
                                                  ,[CitySubdivisionName]
                                                  ,[Region]
                                                  ,[CityName]
                                                  ,[PostalZone]
                                                  ,[Country]
                                                  ,[Telephone]
                                                  ,[Telefax]
                                                  ,[ElectronicMail]
                                                  ,[WebsiteURI]
                                                  ,[TaxScheme]
                                                  ,[Active]
                                                  ,[Country_IdentificationCode]
                                                  ,[OrganizationID]
                                                  ,[CompanyCode]
                                                  ,[FL_ACTIVE]
                                                  ,[LiveStatus]
                                                  ,[fiscalYearStart]
                                                  ,[fiscalYearEnd]
                                                  ,[LedgerCreator]
                                                  ,[Alias]
                                                  ,[TAPDKNO]
                                            )
                                            SELECT [OrganizationCode]
                                                  ,@NEWVKN
                                                  ,@NEWVKN
                                                  ,[UNVAN]
                                                  ,[Name]
                                                  ,[Surname]
                                                  ,[StreetName]
                                                  ,[BuildingName]
                                                  ,[BuildingNumber]
                                                  ,[Room]
                                                  ,[CitySubdivisionName]
                                                  ,[Region]
                                                  ,[CityName]
                                                  ,[PostalZone]
                                                  ,[Country]
                                                  ,[Telephone]
                                                  ,[Telefax]
                                                  ,[ElectronicMail]
                                                  ,[WebsiteURI]
                                                  ,[TaxScheme]
                                                  ,[Active]
                                                  ,[Country_IdentificationCode]
                                                  ,[OrganizationID]
                                                  ,[CompanyCode]
                                                  ,[FL_ACTIVE]
                                                  ,[LiveStatus]
                                                  ,[fiscalYearStart]
                                                  ,[fiscalYearEnd]
                                                  ,[LedgerCreator]
                                                  ,[Alias]
                                                  ,[TAPDKNO]
                                              FROM [Organization].[dbo].[Partner]
                                              WHERE VKN = @OLDVKN;
                                            
                                            SELECT @NEWPARTNERID = SCOPE_IDENTITY();
                                              
                                            --INSERT INTO [Organization].[dbo].[gn_Accountant]
                                            --(
                                                   --[ModulID]
                                                  --,[VKN]
                                                  --,[PartnerID]
                                                  --,[CreateDate]
                                                  --,[FL_ACTIVE]
                                                  --,[accountantName]
                                                  --,[accountantBuildingNumber]
                                                  --,[accountantStreet]
                                                  --,[accountantAddressStreet2]
                                                  --,[accountantCity]
                                                  --,[accountantCountry]
                                                  --,[accountantZipOrPostalCode]
                                                  --,[accountantEngagementTypeDescription]
                                                  --,[accountantContactPhoneNumberDescription]
                                                  --,[accountantContactPhoneNumber]
                                                  --,[accountantContactFaxNumber]
                                                  --,[accountantContactEmailAddress]
                                                  --,[enteredBy]
                                                  --,[accountantUnvan]
                                                  --,[isCreator]
                                            --)
                                            --SELECT @NEWPARTNERID
                                                  --,@NEWVKN
                                                  --,@NEWPARTNERID
                                                  --,[CreateDate]
                                                  --,[FL_ACTIVE]
                                                  --,[accountantName]
                                                  --,[accountantBuildingNumber]
                                                  --,[accountantStreet]
                                                  --,[accountantAddressStreet2]
                                                  --,[accountantCity]
                                                  --,[accountantCountry]
                                                  --,[accountantZipOrPostalCode]
                                                  --,[accountantEngagementTypeDescription]
                                                  --,[accountantContactPhoneNumberDescription]
                                                  --,[accountantContactPhoneNumber]
                                                  --,[accountantContactFaxNumber]
                                                  --,[accountantContactEmailAddress]
                                                  --,[enteredBy]
                                                  --,[accountantUnvan]
                                                  --,[isCreator]
                                              --FROM [Organization].[dbo].[gn_Accountant]
                                              --WHERE VKN = @OLDVKN;
                                              
                                            INSERT INTO [Organization].[dbo].[ParameterValues] (
                                            [TypeID]
                                                  ,[ModulId]
                                                  ,[VKN]
                                                  ,[TopParameterID]
                                                  ,[Value]
                                                  ,[Description]
                                                  ,[Versiyon]
                                                  ,[Secured]
                                                  ,[DataType]
                                                  ,[SectionOrder]
                                                  ,[Required]
                                                  ,[ApplicationType]
                                                  ,[FL_ACTIVE]
                                                  ,[Parametre]
                                                  ,[VersionId])
                                            
                                            SELECT [TypeID]
                                                  ,[ModulId]
                                                  ,@NEWVKN
                                                  ,[TopParameterID]
                                                  ,[Value]
                                                  ,[Description]
                                                  ,[Versiyon]
                                                 ,[Secured]
                                                  ,[DataType]
                                                  ,[SectionOrder]
                                                  ,[Required]
                                                  ,[ApplicationType]
                                                  ,[FL_ACTIVE]
                                                  ,[Parametre]
                                                  ,[VersionId]
                                              FROM [Organization].[dbo].[ParameterValues]
                                              where VKN = @OLDVKN;
                                            
                                            INSERT INTO [Organization].[dbo].[ApprovalHierarchy]
                                            ([VKN]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[Description]
                                                  ,[IsAutoApproval]
                                                  ,[MaxWaitTime]
                                                  ,[ERPIsAutoSend]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[AutoGibProcess])
                                            SELECT @NEWVKN
                                                  ,[ApprovalHierarchyCode]
                                                  ,[Description]
                                                  ,[IsAutoApproval]
                                                  ,[MaxWaitTime]
                                                  ,[ERPIsAutoSend]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[AutoGibProcess]
                                              FROM [Organization].[dbo].[ApprovalHierarchy]
                                              WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[JobPosition]
                                            (
                                                   [VKN]
                                                  ,[JobPositionCode]
                                                  ,[Description]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                            )
                                            SELECT @NEWVKN
                                                  ,[JobPositionCode]
                                                  ,[Description]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                              FROM [Organization].[dbo].[JobPosition]
                                                WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                            (      [VKN]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[ApprovalLevel]
                                                  ,[JobPositionCode]
                                                  ,[IsActive]) 
                                            SELECT @NEWVKN
                                                  ,[ApprovalHierarchyCode]
                                                  ,[ApprovalLevel]
                                                  ,[JobPositionCode]
                                                  ,[IsActive]
                                              FROM [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                                WHERE VKN = @OLDVKN
                                                
                                            INSERT INTO [Organization].[dbo].[PartnerModules]
                                            (
                                                   [VKN_TCKN]
                                                  ,[ModuleId]
                                                  ,[Active]
                                                  ,[Creation]
                                            )
                                            
                                            SELECT @NEWVKN
                                                  ,[ModuleId]
                                                  ,[Active]
                                                  ,[Creation]
                                              FROM [Organization].[dbo].[PartnerModules]
                                              WHERE VKN_TCKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[UserApprovalHierarchy]
                                                               ([VKN]
                                                  ,[UserCode]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[BeginDate]
                                                  ,[EndDate]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                                  )
                                            SELECT  @NEWVKN
                                                  ,[UserCode]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[BeginDate]
                                                  ,[EndDate]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                              FROM [Organization].[dbo].[UserApprovalHierarchy]
                                              WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[UserMenu]
                                                               (
                                                   [MenuID]
                                                  ,[VKN_TCKN]
                                                  ,[UserID]
                                                  ,[TopID]
                                                  ,[Name]
                                                  ,[URL]
                                                  ,[Icon]
                                                  ,[Parametre]
                                                  ,[MenuOrder]
                                                  ,[SectionOrder]
                                                  ,[isSection]
                                                  ,[isViewMain]
                                                  ,[LargeIcon]
                                                  ,[DesktopTopID]
                                                  ,[ScreenID]
                                                  ,[FL_ACTIVE]
                                                  ,[PartnerID])
                                            SELECT  
                                                   [MenuID]
                                                  ,@NEWVKN
                                                  ,[UserID]
                                                  ,[TopID]
                                                  ,[Name]
                                                  ,[URL]
                                                  ,[Icon]
                                                  ,[Parametre]
                                                  ,[MenuOrder]
                                                  ,[SectionOrder]
                                                  ,[isSection]
                                                  ,[isViewMain]
                                                  ,[LargeIcon]
                                                  ,[DesktopTopID]
                                                  ,[ScreenID]
                                                  ,[FL_ACTIVE]
                                                  ,@NEWPARTNERID
                                              FROM [Organization].[dbo].[UserMenu]
                                              WHERE VKN_TCKN = @OLDVKN

                                              INSERT INTO [Organization].[dbo].[UserPartnerDetail]
                                                    ([UserID]
                                                    ,[PartnerID]
                                                    ,[Active]
                                                    ,[FL_ACTIVE]
                                                    ,[isDefault])

                                              SELECT TOP 1 204
                                                           ,@NEWPARTNERID
                                                           ,[Active]
                                                           ,[FL_ACTIVE]
                                                           ,[isDefault]
                                                FROM [Organization].[dbo].[UserPartnerDetail]                                

                                              COMMIT TRAN;
                                              
                                             EXEC('CREATE DATABASE Efatura_' + @NEWVKN + ' COLLATE Turkish_CI_AS');";

                    cmd.Parameters.AddWithValue("@pOldVKN", pOldVKN);
                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            if (connection != null) connection.Close();
                            return true;
                        }
                        else
                        {
                            if (connection != null) connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool CreateNewCompanyForELedgerTest(string connectionString, string pOldVKN, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                            BEGIN TRAN;
                                            DECLARE @OLDVKN NVARCHAR(11) = @pOldVKN;
                                            DECLARE @NEWVKN NVARCHAR(11) = @pNewVKN;
                                            DECLARE @NEWPARTNERID INT;
                                            
                                            INSERT INTO [Organization].[dbo].[Partner]
                                            (
                                                   [OrganizationCode]
                                                  ,[VKN]
                                                  ,[TCKN]
                                                  ,[UNVAN]
                                                  ,[Name]
                                                  ,[Surname]
                                                  ,[StreetName]
                                                  ,[BuildingName]
                                                  ,[BuildingNumber]
                                                  ,[Room]
                                                  ,[CitySubdivisionName]
                                                  ,[Region]
                                                  ,[CityName]
                                                  ,[PostalZone]
                                                  ,[Country]
                                                  ,[Telephone]
                                                  ,[Telefax]
                                                  ,[ElectronicMail]
                                                  ,[WebsiteURI]
                                                  ,[TaxScheme]
                                                  ,[Active]
                                                  ,[Country_IdentificationCode]
                                                  ,[OrganizationID]
                                                  ,[CompanyCode]
                                                  ,[FL_ACTIVE]
                                                  ,[LiveStatus]
                                                  ,[fiscalYearStart]
                                                  ,[fiscalYearEnd]
                                                  ,[LedgerCreator]
                                                  ,[Alias]
                                                  ,[TAPDKNO]
                                            )
                                            SELECT [OrganizationCode]
                                                  ,@NEWVKN
                                                  ,@NEWVKN
                                                  ,[UNVAN]
                                                  ,[Name]
                                                  ,[Surname]
                                                  ,[StreetName]
                                                  ,[BuildingName]
                                                  ,[BuildingNumber]
                                                  ,[Room]
                                                  ,[CitySubdivisionName]
                                                  ,[Region]
                                                  ,[CityName]
                                                  ,[PostalZone]
                                                  ,[Country]
                                                  ,[Telephone]
                                                  ,[Telefax]
                                                  ,[ElectronicMail]
                                                  ,[WebsiteURI]
                                                  ,[TaxScheme]
                                                  ,[Active]
                                                  ,[Country_IdentificationCode]
                                                  ,[OrganizationID]
                                                  ,[CompanyCode]
                                                  ,[FL_ACTIVE]
                                                  ,[LiveStatus]
                                                  ,[fiscalYearStart]
                                                  ,[fiscalYearEnd]
                                                  ,[LedgerCreator]
                                                  ,[Alias]
                                                  ,[TAPDKNO]
                                              FROM [Organization].[dbo].[Partner]
                                              WHERE VKN = @OLDVKN;
                                            
                                            SELECT @NEWPARTNERID = SCOPE_IDENTITY();
                                              
                                            --INSERT INTO [Organization].[dbo].[gn_Accountant]
                                            --(
                                                   --[ModulID]
                                                  --,[VKN]
                                                  --,[PartnerID]
                                                  --,[CreateDate]
                                                  --,[FL_ACTIVE]
                                                  --,[accountantName]
                                                  --,[accountantBuildingNumber]
                                                  --,[accountantStreet]
                                                  --,[accountantAddressStreet2]
                                                  --,[accountantCity]
                                                  --,[accountantCountry]
                                                  --,[accountantZipOrPostalCode]
                                                  --,[accountantEngagementTypeDescription]
                                                  --,[accountantContactPhoneNumberDescription]
                                                  --,[accountantContactPhoneNumber]
                                                  --,[accountantContactFaxNumber]
                                                  --,[accountantContactEmailAddress]
                                                  --,[enteredBy]
                                                  --,[accountantUnvan]
                                                  --,[isCreator]
                                            --)
                                            --SELECT @NEWPARTNERID
                                                  --,@NEWVKN
                                                  --,@NEWPARTNERID
                                                  --,[CreateDate]
                                                  --,[FL_ACTIVE]
                                                  --,[accountantName]
                                                  --,[accountantBuildingNumber]
                                                  --,[accountantStreet]
                                                  --,[accountantAddressStreet2]
                                                  --,[accountantCity]
                                                  --,[accountantCountry]
                                                  --,[accountantZipOrPostalCode]
                                                  --,[accountantEngagementTypeDescription]
                                                  --,[accountantContactPhoneNumberDescription]
                                                  --,[accountantContactPhoneNumber]
                                                  --,[accountantContactFaxNumber]
                                                  --,[accountantContactEmailAddress]
                                                  --,[enteredBy]
                                                  --,[accountantUnvan]
                                                  --,[isCreator]
                                              --FROM [Organization].[dbo].[gn_Accountant]
                                              --WHERE VKN = @OLDVKN;
                                              
                                            INSERT INTO [Organization].[dbo].[ParameterValues] (
                                            [TypeID]
                                                  ,[ModulId]
                                                  ,[VKN]
                                                  ,[TopParameterID]
                                                  ,[Value]
                                                  ,[Description]
                                                  ,[Versiyon]
                                                  ,[Secured]
                                                  ,[DataType]
                                                  ,[SectionOrder]
                                                  ,[Required]
                                                  ,[ApplicationType]
                                                  ,[FL_ACTIVE]
                                                  ,[Parametre]
                                                  ,[VersionId])
                                            
                                            SELECT [TypeID]
                                                  ,[ModulId]
                                                  ,@NEWVKN
                                                  ,[TopParameterID]
                                                  ,[Value]
                                                  ,[Description]
                                                  ,[Versiyon]
                                                 ,[Secured]
                                                  ,[DataType]
                                                  ,[SectionOrder]
                                                  ,[Required]
                                                  ,[ApplicationType]
                                                  ,[FL_ACTIVE]
                                                  ,[Parametre]
                                                  ,[VersionId]
                                              FROM [Organization].[dbo].[ParameterValues]
                                              where VKN = @OLDVKN;
                                            
                                            INSERT INTO [Organization].[dbo].[ApprovalHierarchy]
                                            ([VKN]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[Description]
                                                  ,[IsAutoApproval]
                                                  ,[MaxWaitTime]
                                                  ,[ERPIsAutoSend]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[AutoGibProcess])
                                            SELECT @NEWVKN
                                                  ,[ApprovalHierarchyCode]
                                                  ,[Description]
                                                  ,[IsAutoApproval]
                                                  ,[MaxWaitTime]
                                                  ,[ERPIsAutoSend]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[AutoGibProcess]
                                              FROM [Organization].[dbo].[ApprovalHierarchy]
                                              WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[JobPosition]
                                            (
                                                   [VKN]
                                                  ,[JobPositionCode]
                                                  ,[Description]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                            )
                                            SELECT @NEWVKN
                                                  ,[JobPositionCode]
                                                  ,[Description]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                              FROM [Organization].[dbo].[JobPosition]
                                                WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                            (      [VKN]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[ApprovalLevel]
                                                  ,[JobPositionCode]
                                                  ,[IsActive]) 
                                            SELECT @NEWVKN
                                                  ,[ApprovalHierarchyCode]
                                                  ,[ApprovalLevel]
                                                  ,[JobPositionCode]
                                                  ,[IsActive]
                                              FROM [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                                WHERE VKN = @OLDVKN
                                                
                                            INSERT INTO [Organization].[dbo].[PartnerModules]
                                            (
                                                   [VKN_TCKN]
                                                  ,[ModuleId]
                                                  ,[Active]
                                                  ,[Creation]
                                            )
                                            
                                            SELECT @NEWVKN
                                                  ,[ModuleId]
                                                  ,[Active]
                                                  ,[Creation]
                                              FROM [Organization].[dbo].[PartnerModules]
                                              WHERE VKN_TCKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[UserApprovalHierarchy]
                                                               ([VKN]
                                                  ,[UserCode]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[BeginDate]
                                                  ,[EndDate]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                                  )
                                            SELECT  @NEWVKN
                                                  ,[UserCode]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[BeginDate]
                                                  ,[EndDate]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                              FROM [Organization].[dbo].[UserApprovalHierarchy]
                                              WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[UserMenu]
                                                               (
                                                   [MenuID]
                                                  ,[VKN_TCKN]
                                                  ,[UserID]
                                                  ,[TopID]
                                                  ,[Name]
                                                  ,[URL]
                                                  ,[Icon]
                                                  ,[Parametre]
                                                  ,[MenuOrder]
                                                  ,[SectionOrder]
                                                  ,[isSection]
                                                  ,[isViewMain]
                                                  ,[LargeIcon]
                                                  ,[DesktopTopID]
                                                  ,[ScreenID]
                                                  ,[FL_ACTIVE]
                                                  ,[PartnerID])
                                            SELECT  
                                                   [MenuID]
                                                  ,@NEWVKN
                                                  ,[UserID]
                                                  ,[TopID]
                                                  ,[Name]
                                                  ,[URL]
                                                  ,[Icon]
                                                  ,[Parametre]
                                                  ,[MenuOrder]
                                                  ,[SectionOrder]
                                                  ,[isSection]
                                                  ,[isViewMain]
                                                  ,[LargeIcon]
                                                  ,[DesktopTopID]
                                                  ,[ScreenID]
                                                  ,[FL_ACTIVE]
                                                  ,@NEWPARTNERID
                                              FROM [Organization].[dbo].[UserMenu]
                                              WHERE VKN_TCKN = @OLDVKN

                                             INSERT INTO [Organization].[dbo].[UserPartnerDetail]
                                                    ([UserID]
                                                    ,[PartnerID]
                                                    ,[Active]
                                                    ,[FL_ACTIVE]
                                                    ,[isDefault])

                                              SELECT TOP 1 204
                                                          ,@NEWPARTNERID
                                                          ,[Active]
                                                          ,[FL_ACTIVE]
                                                          ,[isDefault]
                                                FROM [Organization].[dbo].[UserPartnerDetail]
                                              
                                              COMMIT TRAN;
                                              
                                             EXEC('CREATE DATABASE Eledger_' + @NEWVKN + ' COLLATE Turkish_CI_AS');";

                    cmd.Parameters.AddWithValue("@pOldVKN", pOldVKN);
                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            if (connection != null) connection.Close();
                            return true;
                        }
                        else
                        {
                            if (connection != null) connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool CreateNewCompanyForELedgerLive(string connectionString, string pOldVKN, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                            BEGIN TRAN;
                                            DECLARE @SQL NVARCHAR(MAX);
                                            DECLARE @SQL2 NVARCHAR(MAX);
                                            DECLARE @OLDVKN NVARCHAR(11) = @pOldVKN;
                                            DECLARE @NEWVKN NVARCHAR(11) = @pNewVKN;
                                            DECLARE @NEWPARTNERID INT;
                                            
                                            SET @SQL = ' ON PRIMARY ( NAME = N''Eledger_' + @NEWVKN + '_Data'', FILENAME = N''G:\Databases\Eledger_' + @NEWVKN + '.mdf'', SIZE = 167872KB, MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB )';
                                            SET @SQL2 = @SQL + ' LOG ON ( NAME = N''Eledger_' + @NEWVKN + '_Log'', FILENAME = N''G:\Databases\Eledger_' + @NEWVKN + '.ldf'', SIZE = 167872KB, MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB )';

                                            INSERT INTO [Organization].[dbo].[Partner]
                                            (
                                                   [OrganizationCode]
                                                  ,[VKN]
                                                  ,[TCKN]
                                                  ,[UNVAN]
                                                  ,[Name]
                                                  ,[Surname]
                                                  ,[StreetName]
                                                  ,[BuildingName]
                                                  ,[BuildingNumber]
                                                  ,[Room]
                                                  ,[CitySubdivisionName]
                                                  ,[Region]
                                                  ,[CityName]
                                                  ,[PostalZone]
                                                  ,[Country]
                                                  ,[Telephone]
                                                  ,[Telefax]
                                                  ,[ElectronicMail]
                                                  ,[WebsiteURI]
                                                  ,[TaxScheme]
                                                  ,[Active]
                                                  ,[Country_IdentificationCode]
                                                  ,[OrganizationID]
                                                  ,[CompanyCode]
                                                  ,[FL_ACTIVE]
                                                  ,[LiveStatus]
                                                  ,[fiscalYearStart]
                                                  ,[fiscalYearEnd]
                                                  ,[LedgerCreator]
                                                  ,[Alias]
                                                  ,[TAPDKNO]
                                            )
                                            SELECT [OrganizationCode]
                                                  ,@NEWVKN
                                                  ,@NEWVKN
                                                  ,[UNVAN]
                                                  ,[Name]
                                                  ,[Surname]
                                                  ,[StreetName]
                                                  ,[BuildingName]
                                                  ,[BuildingNumber]
                                                  ,[Room]
                                                  ,[CitySubdivisionName]
                                                  ,[Region]
                                                  ,[CityName]
                                                  ,[PostalZone]
                                                  ,[Country]
                                                  ,[Telephone]
                                                  ,[Telefax]
                                                  ,[ElectronicMail]
                                                  ,[WebsiteURI]
                                                  ,[TaxScheme]
                                                  ,[Active]
                                                  ,[Country_IdentificationCode]
                                                  ,[OrganizationID]
                                                  ,[CompanyCode]
                                                  ,[FL_ACTIVE]
                                                  ,[LiveStatus]
                                                  ,[fiscalYearStart]
                                                  ,[fiscalYearEnd]
                                                  ,[LedgerCreator]
                                                  ,[Alias]
                                                  ,[TAPDKNO]
                                              FROM [Organization].[dbo].[Partner]
                                              WHERE VKN = @OLDVKN;
                                            
                                            SELECT @NEWPARTNERID = SCOPE_IDENTITY();
                                              
                                             --INSERT INTO [Organization].[dbo].[gn_Accountant]
                                             --(
                                                    --[ModulID]
                                                   --,[VKN]
                                                   --,[PartnerID]
                                                   --,[CreateDate]
                                                   --,[FL_ACTIVE]
                                                   --,[accountantName]
                                                   --,[accountantBuildingNumber]
                                                   --,[accountantStreet]
                                                   --,[accountantAddressStreet2]
                                                   --,[accountantCity]
                                                   --,[accountantCountry]
                                                   --,[accountantZipOrPostalCode]
                                                   --,[accountantEngagementTypeDescription]
                                                   --,[accountantContactPhoneNumberDescription]
                                                   --,[accountantContactPhoneNumber]
                                                   --,[accountantContactFaxNumber]
                                                   --,[accountantContactEmailAddress]
                                                   --,[enteredBy]
                                                   --,[accountantUnvan]
                                                   --,[isCreator]
                                             --)
                                             --SELECT @NEWPARTNERID
                                                   --,@NEWVKN
                                                   --,@NEWPARTNERID
                                                   --,[CreateDate]
                                                   --,[FL_ACTIVE]
                                                   --,[accountantName]
                                                   --,[accountantBuildingNumber]
                                                   --,[accountantStreet]
                                                   --,[accountantAddressStreet2]
                                                   --,[accountantCity]
                                                   --,[accountantCountry]
                                                   --,[accountantZipOrPostalCode]
                                                   --,[accountantEngagementTypeDescription]
                                                   --,[accountantContactPhoneNumberDescription]
                                                   --,[accountantContactPhoneNumber]
                                                   --,[accountantContactFaxNumber]
                                                   --,[accountantContactEmailAddress]
                                                   --,[enteredBy]
                                                   --,[accountantUnvan]
                                                   --,[isCreator]
                                               --FROM [Organization].[dbo].[gn_Accountant]
                                               --WHERE VKN = @OLDVKN;
                                              
                                            INSERT INTO [Organization].[dbo].[ParameterValues] (
                                            [TypeID]
                                                  ,[ModulId]
                                                  ,[VKN]
                                                  ,[TopParameterID]
                                                  ,[Value]
                                                  ,[Description]
                                                  ,[Versiyon]
                                                  ,[Secured]
                                                  ,[DataType]
                                                  ,[SectionOrder]
                                                  ,[Required]
                                                  ,[ApplicationType]
                                                  ,[FL_ACTIVE]
                                                  ,[Parametre]
                                                  ,[VersionId])
                                            
                                            SELECT [TypeID]
                                                  ,[ModulId]
                                                  ,@NEWVKN
                                                  ,[TopParameterID]
                                                  ,[Value]
                                                  ,[Description]
                                                  ,[Versiyon]
                                                 ,[Secured]
                                                  ,[DataType]
                                                  ,[SectionOrder]
                                                  ,[Required]
                                                  ,[ApplicationType]
                                                  ,[FL_ACTIVE]
                                                  ,[Parametre]
                                                  ,[VersionId]
                                              FROM [Organization].[dbo].[ParameterValues]
                                              where VKN = @OLDVKN;
                                            
                                            INSERT INTO [Organization].[dbo].[ApprovalHierarchy]
                                            ([VKN]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[Description]
                                                  ,[IsAutoApproval]
                                                  ,[MaxWaitTime]
                                                  ,[ERPIsAutoSend]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[AutoGibProcess])
                                            SELECT @NEWVKN
                                                  ,[ApprovalHierarchyCode]
                                                  ,[Description]
                                                  ,[IsAutoApproval]
                                                  ,[MaxWaitTime]
                                                  ,[ERPIsAutoSend]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[AutoGibProcess]
                                              FROM [Organization].[dbo].[ApprovalHierarchy]
                                              WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[JobPosition]
                                            (
                                                   [VKN]
                                                  ,[JobPositionCode]
                                                  ,[Description]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                            )
                                            SELECT @NEWVKN
                                                  ,[JobPositionCode]
                                                  ,[Description]
                                                  ,[IsStatic]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                              FROM [Organization].[dbo].[JobPosition]
                                                WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                            (      [VKN]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[ApprovalLevel]
                                                  ,[JobPositionCode]
                                                  ,[IsActive]) 
                                            SELECT @NEWVKN
                                                  ,[ApprovalHierarchyCode]
                                                  ,[ApprovalLevel]
                                                  ,[JobPositionCode]
                                                  ,[IsActive]
                                              FROM [Organization].[dbo].[ApprovalHierarchyJobPosition]
                                                WHERE VKN = @OLDVKN
                                                
                                            INSERT INTO [Organization].[dbo].[PartnerModules]
                                            (
                                                   [VKN_TCKN]
                                                  ,[ModuleId]
                                                  ,[Active]
                                                  ,[Creation]
                                            )
                                            
                                            SELECT @NEWVKN
                                                  ,[ModuleId]
                                                  ,[Active]
                                                  ,[Creation]
                                              FROM [Organization].[dbo].[PartnerModules]
                                              WHERE VKN_TCKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[UserApprovalHierarchy]
                                                               ([VKN]
                                                  ,[UserCode]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[BeginDate]
                                                  ,[EndDate]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                                  )
                                            SELECT  @NEWVKN
                                                  ,[UserCode]
                                                  ,[ApprovalHierarchyCode]
                                                  ,[BeginDate]
                                                  ,[EndDate]
                                                  ,[IsActive]
                                                  ,[IsDeleted]
                                              FROM [Organization].[dbo].[UserApprovalHierarchy]
                                              WHERE VKN = @OLDVKN
                                              
                                            INSERT INTO [Organization].[dbo].[UserMenu]
                                                               (
                                                   [MenuID]
                                                  ,[VKN_TCKN]
                                                  ,[UserID]
                                                  ,[TopID]
                                                  ,[Name]
                                                  ,[URL]
                                                  ,[Icon]
                                                  ,[Parametre]
                                                  ,[MenuOrder]
                                                  ,[SectionOrder]
                                                  ,[isSection]
                                                  ,[isViewMain]
                                                  ,[LargeIcon]
                                                  ,[DesktopTopID]
                                                  ,[ScreenID]
                                                  ,[FL_ACTIVE]
                                                  ,[PartnerID])
                                            SELECT  
                                                   [MenuID]
                                                  ,@NEWVKN
                                                  ,[UserID]
                                                  ,[TopID]
                                                  ,[Name]
                                                  ,[URL]
                                                  ,[Icon]
                                                  ,[Parametre]
                                                  ,[MenuOrder]
                                                  ,[SectionOrder]
                                                  ,[isSection]
                                                  ,[isViewMain]
                                                  ,[LargeIcon]
                                                  ,[DesktopTopID]
                                                  ,[ScreenID]
                                                  ,[FL_ACTIVE]
                                                  ,@NEWPARTNERID
                                              FROM [Organization].[dbo].[UserMenu]
                                              WHERE VKN_TCKN = @OLDVKN

                                             INSERT INTO [Organization].[dbo].[UserPartnerDetail]
                                                    ([UserID]
                                                    ,[PartnerID]
                                                    ,[Active]
                                                    ,[FL_ACTIVE]
                                                    ,[isDefault])

                                              SELECT TOP 1 204
                                                          ,@NEWPARTNERID
                                                          ,[Active]
                                                          ,[FL_ACTIVE]
                                                          ,[isDefault]
                                                FROM [Organization].[dbo].[UserPartnerDetail]
                                              
                                              COMMIT TRAN;
                                              
                                             EXEC('CREATE DATABASE Efatura_' + @NEWVKN + @SQL2 + ' COLLATE Turkish_CI_AS');";

                    cmd.Parameters.AddWithValue("@pOldVKN", pOldVKN);
                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            if (connection != null) connection.Close();
                            return true;
                        }
                        else
                        {
                            if (connection != null) connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool CreateNewCompanyForEinvoiceTablesDB(string connectionString, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                        BEGIN TRAN;
                                         DECLARE @PKSchema varchar(255);
                                         DECLARE @SourceTable varchar(255);
                                         DECLARE @DestinationDB varchar(255);
                                         DECLARE @Schema varchar(15);
                                         DECLARE @NEWVKN varchar(11);
                                        
                                         SET @NEWVKN = @pNewVKN;
                                         SELECT @Schema = SCHEMA_NAME();
                                         SET @DestinationDB = '[Efatura_' + @NEWVKN + ']';
                                        
                                         --exec('CREATE DATABASE Efatura_' + @NEWVKN + ' COLLATE Turkish_CI_AS'); -- DB Yarattıysan Gerek Yok Kapat
                                         --create tabele
                                         DECLARE tablecursor CURSOR FOR
                                         SELECT TABLE_NAME FROM [Efatura_9999999999].INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT IN ('Profile', 'CodeLists');
                                         OPEN tablecursor;
                                         FETCH NEXT FROM tablecursor INTO @SourceTable;
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                           EXEC('SELECT TOP (0) * INTO ' + @DestinationDB + '.[' + @Schema + '].' + @SourceTable + ' FROM [Efatura_9999999999].' + '[' + @Schema + '].' + @SourceTable);
                                         
                                         --create primary or froein keys
                                         DECLARE @KeyName varchar(255);
                                         DECLARE @RefName varchar(255);
                                         DECLARE @RefTable varchar(255);
                                         DECLARE @KeyType varchar(25);
                                         DECLARE @KeyColumns varchar(4000);
                                         DECLARE @RefColumns varchar(4000);
                                         
                                         
                                         DECLARE indexcursor CURSOR FOR
                                         SELECT CONSTRAINT_SCHEMA, CONSTRAINT_NAME, CONSTRAINT_TYPE FROM [Efatura_9999999999].INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @SourceTable AND CONSTRAINT_TYPE IN ('PRIMARY KEY','FOREIGN KEY')
                                         OPEN indexcursor;
                                         FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyType;
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                            SET @KeyColumns = '';
                                            SET @RefColumns = '';
                                            SET @RefTable = '';
                                        
                                            SET @RefName = @KeyName;
                                            IF @KeyType = 'PRIMARY KEY'
                                            BEGIN
                                               SELECT @KeyColumns = @KeyColumns + '[' + COLUMN_NAME + '],'
                                               FROM [Efatura_9999999999].INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
                                               WHERE TABLE_NAME = @SourceTable AND TABLE_SCHEMA = @Schema AND CONSTRAINT_SCHEMA = @PKSchema AND CONSTRAINT_NAME = @KeyName
                                               ORDER BY ORDINAL_POSITION
                                        
                                               SET @KeyType = 'PRIMARY KEY CLUSTERED';
                                            END
                                            ELSE
                                            BEGIN
                                               SELECT @KeyColumns = @KeyColumns + '[' + fc.name + '],', @RefTable = kt.name, @RefColumns = @RefColumns + '[' + kc.name + '],'
                                               FROM  [Efatura_9999999999].sys.foreign_key_columns 
                                               LEFT JOIN [Efatura_9999999999].sys.tables ft ON ft.object_id = foreign_key_columns.parent_object_id
                                               LEFT JOIN [Efatura_9999999999].sys.columns fc ON fc.object_id = foreign_key_columns.parent_object_id AND fc.column_id = foreign_key_columns.parent_column_id
                                               LEFT JOIN [Efatura_9999999999].sys.tables kt ON kt.object_id = foreign_key_columns.referenced_object_id
                                               LEFT JOIN [Efatura_9999999999].sys.columns kc ON kc.object_id = foreign_key_columns.referenced_object_id AND kc.column_id = foreign_key_columns.referenced_column_id
                                               WHERE constraint_object_id = (SELECT object_id FROM [Efatura_9999999999].sys.foreign_keys WHERE name = @KeyName and schema_id = (SELECT schema_id FROM [Efatura_9999999999].sys.schemas where name = @PKSchema))
                                             
                                               SET @RefColumns = LEFT(@RefColumns, LEN(@RefColumns) - 1);
                                               SET @RefColumns = ' REFERENCES ' + @RefTable + ' (' + @RefColumns + ')';
                                            END
                                            SET @KeyColumns = LEFT(@KeyColumns, LEN(@KeyColumns) - 1);   
                                            exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] ADD CONSTRAINT [' + @RefName + '] ' + @KeyType + ' (' + @KeyColumns + ')' + @RefColumns);
                                            FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyType;
                                         END;
                                         CLOSE indexcursor;
                                         DEALLOCATE indexcursor;
                                        
                                         --create constraints
                                         DECLARE indexcursor CURSOR FOR
                                         SELECT TABLE_SCHEMA, COLUMN_NAME, COLUMN_DEFAULT FROM [Efatura_9999999999].INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @SourceTable AND COLUMN_DEFAULT IS NOT NULL AND COLUMN_DEFAULT <> ''
                                         OPEN indexcursor;
                                         FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyColumns;
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                            exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] ADD CONSTRAINT [DF_' + @SourceTable + '_' + @KeyName + '] DEFAULT ' + @KeyColumns + ' FOR [' + @KeyName + ']');
                                            FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyColumns;
                                         END;
                                         CLOSE indexcursor;
                                         DEALLOCATE indexcursor;
                                        
                                        
                                         --create other indexes
                                         DECLARE @IndexId int, @IndexName varchar(255), @IsUnique bit, @IsUniqueConstraint bit, @FilterDefinition nvarchar(max)
                                        
                                         DECLARE indexcursor CURSOR FOR
                                         SELECT index_id, name, is_unique, is_unique_constraint, filter_definition FROM [Efatura_9999999999].sys.indexes WHERE type = 2 and object_id = object_id('[' + @Schema + '].[' + @SourceTable + ']')
                                         OPEN indexcursor;
                                         FETCH NEXT FROM indexcursor INTO @IndexId, @IndexName, @IsUnique, @IsUniqueConstraint, @FilterDefinition;
                                         WHILE @@FETCH_STATUS = 0
                                            BEGIN
                                                 DECLARE @Unique varchar(255)
                                                 SET @Unique = CASE WHEN @IsUnique = 1 THEN ' UNIQUE ' ELSE '' END
                                        
                                                 DECLARE @IncludedColumns nvarchar(max)
                                                 SET @KeyColumns = ''
                                                 SET @IncludedColumns = ''
                                        
                                                 select @KeyColumns = @KeyColumns + '[' + c.name + '] ' + CASE WHEN is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END + ',' from [Efatura_9999999999].sys.index_columns ic
                                                 INNER JOIN [Efatura_9999999999].sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
                                                 where index_id = @IndexId and ic.object_id = object_id('[' + @Schema + '].[' + @SourceTable + ']') and key_ordinal > 0
                                                 order by index_column_id
                                        
                                                 select @IncludedColumns = @IncludedColumns + '[' + c.name + '],' from [Efatura_9999999999].sys.index_columns ic
                                                 INNER JOIN [Efatura_9999999999].sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
                                                 where index_id = @IndexId and ic.object_id = object_id('[' + @Schema + '].[' + @SourceTable + ']') and key_ordinal = 0
                                                 order by index_column_id
                                        
                                                 IF LEN(@KeyColumns) > 0
                                                     SET @KeyColumns = LEFT(@KeyColumns, LEN(@KeyColumns) - 1)
                                        
                                                 IF LEN(@IncludedColumns) > 0
                                                 BEGIN
                                                     SET @IncludedColumns = ' INCLUDE (' + LEFT(@IncludedColumns, LEN(@IncludedColumns) - 1) + ')'
                                                 END
                                        
                                                 IF @FilterDefinition IS NULL
                                                     SET @FilterDefinition = ''
                                                 ELSE
                                                     SET @FilterDefinition = 'WHERE ' + @FilterDefinition + ' '
                                        
                                                 SET @IndexName = REPLACE(@IndexName, '_'+@SourceTable+'_', '_'+@SourceTable+'_')
                                                 IF @IsUniqueConstraint = 0
                                                     exec('CREATE ' + @Unique + ' NONCLUSTERED INDEX [' + @IndexName + '] ON ' + @DestinationDB + ' [' + @Schema + '].[' + @SourceTable + '] (' + @KeyColumns + ')' + @IncludedColumns + @FilterDefinition)
                                                 ELSE
                                                     exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] ADD  CONSTRAINT [' + @IndexName + '] UNIQUE NONCLUSTERED (' + @KeyColumns + ')');
                                        
                                                 FETCH NEXT FROM indexcursor INTO @IndexId, @IndexName, @IsUnique, @IsUniqueConstraint, @FilterDefinition;
                                            END;
                                         CLOSE indexcursor;
                                         DEALLOCATE indexcursor;
                                        
                                         --create constraints
                                         DECLARE @ConstraintName varchar(255), @CheckClause nvarchar(max)
                                         DECLARE constraintcursor CURSOR FOR
                                             SELECT c.CONSTRAINT_NAME, CHECK_CLAUSE from [Efatura_9999999999].INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE t
                                             INNER JOIN [Efatura_9999999999].INFORMATION_SCHEMA.CHECK_CONSTRAINTS c ON c.CONSTRAINT_SCHEMA = TABLE_SCHEMA AND c.CONSTRAINT_NAME = t.CONSTRAINT_NAME
                                              WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @SourceTable
                                         OPEN constraintcursor;
                                         FETCH NEXT FROM constraintcursor INTO @ConstraintName, @CheckClause;
                                         WHILE @@FETCH_STATUS = 0
                                            BEGIN
                                                 exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] WITH CHECK ADD  CONSTRAINT [' + @ConstraintName + '] CHECK ' + @CheckClause)
                                                 exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] CHECK CONSTRAINT [' + @ConstraintName + ']')
                                                 FETCH NEXT FROM constraintcursor INTO @ConstraintName, @CheckClause;
                                            END;
                                         CLOSE constraintcursor;
                                         DEALLOCATE constraintcursor; 
                                         
                                         FETCH NEXT FROM tablecursor INTO @SourceTable;
                                         END;
                                         CLOSE tablecursor;
                                         DEALLOCATE tablecursor; 
                                          EXEC('SELECT * INTO ' + @DestinationDB + '.[' + @Schema + '].' + 'Profile' + ' FROM [Efatura_9999999999].' + '[' + @Schema + ']' + '.Profile');
                                          EXEC('SELECT * INTO ' + @DestinationDB + '.[' + @Schema + '].' + 'CodeLists' + ' FROM [Efatura_9999999999].' + '[' + @Schema + ']' + '.CodeLists');
                                         COMMIT TRAN;";
                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
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

        public bool CreateNewCompanyForEledgerTablesDB(string connectionString, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SET XACT_ABORT ON;
                                         BEGIN TRAN;
                                         DECLARE @PKSchema varchar(255);
                                         DECLARE @SourceTable varchar(255);
                                         DECLARE @DestinationDB varchar(255);
                                         DECLARE @Schema varchar(15);
                                         DECLARE @NEWVKN varchar(11);
                                        
                                         SET @NEWVKN = @pNewVKN;
                                         SELECT @Schema = SCHEMA_NAME();
                                         SET @DestinationDB = '[Eledger_' + @NEWVKN + ']';
                                        
                                         --exec('CREATE DATABASE Eledger_' + @NEWVKN + ' COLLATE Turkish_CI_AS'); -- DB Yarattıysan Gerek Yok Kapat
                                         --create tabele
                                         DECLARE tablecursor CURSOR FOR
                                         SELECT TABLE_NAME FROM [Eledger_4660392430].INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
                                         OPEN tablecursor;
                                         FETCH NEXT FROM tablecursor INTO @SourceTable;
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                           EXEC('SELECT TOP (0) * INTO ' + @DestinationDB + '.[' + @Schema + '].' + @SourceTable + ' FROM [Eledger_4660392430].' + '[' + @Schema + '].' + @SourceTable);
                                         
                                         --create primary or froein keys
                                         DECLARE @KeyName varchar(255);
                                         DECLARE @RefName varchar(255);
                                         DECLARE @RefTable varchar(255);
                                         DECLARE @KeyType varchar(25);
                                         DECLARE @KeyColumns varchar(4000);
                                         DECLARE @RefColumns varchar(4000);
                                         
                                         
                                         DECLARE indexcursor CURSOR FOR
                                         SELECT CONSTRAINT_SCHEMA, CONSTRAINT_NAME, CONSTRAINT_TYPE FROM [Eledger_4660392430].INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @SourceTable AND CONSTRAINT_TYPE IN ('PRIMARY KEY','FOREIGN KEY')
                                         OPEN indexcursor;
                                         FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyType;
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                            SET @KeyColumns = '';
                                            SET @RefColumns = '';
                                            SET @RefTable = '';
                                        
                                            SET @RefName = @KeyName;
                                            IF @KeyType = 'PRIMARY KEY'
                                            BEGIN
                                               SELECT @KeyColumns = @KeyColumns + '[' + COLUMN_NAME + '],'
                                               FROM [Eledger_4660392430].INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
                                               WHERE TABLE_NAME = @SourceTable AND TABLE_SCHEMA = @Schema AND CONSTRAINT_SCHEMA = @PKSchema AND CONSTRAINT_NAME = @KeyName
                                               ORDER BY ORDINAL_POSITION
                                        
                                               SET @KeyType = 'PRIMARY KEY CLUSTERED';
                                            END
                                            ELSE
                                            BEGIN
                                               SELECT @KeyColumns = @KeyColumns + '[' + fc.name + '],', @RefTable = kt.name, @RefColumns = @RefColumns + '[' + kc.name + '],'
                                               FROM  [Eledger_4660392430].sys.foreign_key_columns 
                                               LEFT JOIN [Eledger_4660392430].sys.tables ft ON ft.object_id = foreign_key_columns.parent_object_id
                                               LEFT JOIN [Eledger_4660392430].sys.columns fc ON fc.object_id = foreign_key_columns.parent_object_id AND fc.column_id = foreign_key_columns.parent_column_id
                                               LEFT JOIN [Eledger_4660392430].sys.tables kt ON kt.object_id = foreign_key_columns.referenced_object_id
                                               LEFT JOIN [Eledger_4660392430].sys.columns kc ON kc.object_id = foreign_key_columns.referenced_object_id AND kc.column_id = foreign_key_columns.referenced_column_id
                                               WHERE constraint_object_id = (SELECT object_id FROM [Eledger_4660392430].sys.foreign_keys WHERE name = @KeyName and schema_id = (SELECT schema_id FROM [Eledger_4660392430].sys.schemas where name = @PKSchema))
                                             
                                               SET @RefColumns = LEFT(@RefColumns, LEN(@RefColumns) - 1);
                                               SET @RefColumns = ' REFERENCES ' + @RefTable + ' (' + @RefColumns + ')';
                                            END
                                            SET @KeyColumns = LEFT(@KeyColumns, LEN(@KeyColumns) - 1);   
                                            exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] ADD CONSTRAINT [' + @RefName + '] ' + @KeyType + ' (' + @KeyColumns + ')' + @RefColumns);
                                            FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyType;
                                         END;
                                         CLOSE indexcursor;
                                         DEALLOCATE indexcursor;
                                        
                                         --create constraints
                                         DECLARE indexcursor CURSOR FOR
                                         SELECT TABLE_SCHEMA, COLUMN_NAME, COLUMN_DEFAULT FROM [Eledger_4660392430].INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @SourceTable AND COLUMN_DEFAULT IS NOT NULL AND COLUMN_DEFAULT <> ''
                                         OPEN indexcursor;
                                         FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyColumns;
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                            exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] ADD CONSTRAINT [DF_' + @SourceTable + '_' + @KeyName + '] DEFAULT ' + @KeyColumns + ' FOR [' + @KeyName + ']');
                                            FETCH NEXT FROM indexcursor INTO @PKSchema, @KeyName, @KeyColumns;
                                         END;
                                         CLOSE indexcursor;
                                         DEALLOCATE indexcursor;
                                        
                                        
                                         --create other indexes
                                         DECLARE @IndexId int, @IndexName varchar(255), @IsUnique bit, @IsUniqueConstraint bit, @FilterDefinition nvarchar(max)
                                        
                                         DECLARE indexcursor CURSOR FOR
                                         SELECT index_id, name, is_unique, is_unique_constraint, filter_definition FROM [Eledger_4660392430].sys.indexes WHERE type = 2 and object_id = object_id('[' + @Schema + '].[' + @SourceTable + ']')
                                         OPEN indexcursor;
                                         FETCH NEXT FROM indexcursor INTO @IndexId, @IndexName, @IsUnique, @IsUniqueConstraint, @FilterDefinition;
                                         WHILE @@FETCH_STATUS = 0
                                            BEGIN
                                                 DECLARE @Unique varchar(255)
                                                 SET @Unique = CASE WHEN @IsUnique = 1 THEN ' UNIQUE ' ELSE '' END
                                        
                                                 DECLARE @IncludedColumns nvarchar(max)
                                                 SET @KeyColumns = ''
                                                 SET @IncludedColumns = ''
                                        
                                                 select @KeyColumns = @KeyColumns + '[' + c.name + '] ' + CASE WHEN is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END + ',' from [Eledger_4660392430].sys.index_columns ic
                                                 INNER JOIN [Eledger_4660392430].sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
                                                 where index_id = @IndexId and ic.object_id = object_id('[' + @Schema + '].[' + @SourceTable + ']') and key_ordinal > 0
                                                 order by index_column_id
                                        
                                                 select @IncludedColumns = @IncludedColumns + '[' + c.name + '],' from [Eledger_4660392430].sys.index_columns ic
                                                 INNER JOIN [Eledger_4660392430].sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
                                                 where index_id = @IndexId and ic.object_id = object_id('[' + @Schema + '].[' + @SourceTable + ']') and key_ordinal = 0
                                                 order by index_column_id
                                        
                                                 IF LEN(@KeyColumns) > 0
                                                     SET @KeyColumns = LEFT(@KeyColumns, LEN(@KeyColumns) - 1)
                                        
                                                 IF LEN(@IncludedColumns) > 0
                                                 BEGIN
                                                     SET @IncludedColumns = ' INCLUDE (' + LEFT(@IncludedColumns, LEN(@IncludedColumns) - 1) + ')'
                                                 END
                                        
                                                 IF @FilterDefinition IS NULL
                                                     SET @FilterDefinition = ''
                                                 ELSE
                                                     SET @FilterDefinition = 'WHERE ' + @FilterDefinition + ' '
                                        
                                                 SET @IndexName = REPLACE(@IndexName, '_'+@SourceTable+'_', '_'+@SourceTable+'_')
                                                 IF @IsUniqueConstraint = 0
                                                     exec('CREATE ' + @Unique + ' NONCLUSTERED INDEX [' + @IndexName + '] ON ' + @DestinationDB + ' [' + @Schema + '].[' + @SourceTable + '] (' + @KeyColumns + ')' + @IncludedColumns + @FilterDefinition)
                                                 ELSE
                                                     exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] ADD  CONSTRAINT [' + @IndexName + '] UNIQUE NONCLUSTERED (' + @KeyColumns + ')');
                                        
                                                 FETCH NEXT FROM indexcursor INTO @IndexId, @IndexName, @IsUnique, @IsUniqueConstraint, @FilterDefinition;
                                            END;
                                         CLOSE indexcursor;
                                         DEALLOCATE indexcursor;
                                        
                                         --create constraints
                                         DECLARE @ConstraintName varchar(255), @CheckClause nvarchar(max)
                                         DECLARE constraintcursor CURSOR FOR
                                             SELECT c.CONSTRAINT_NAME, CHECK_CLAUSE from [Eledger_4660392430].INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE t
                                             INNER JOIN [Eledger_4660392430].INFORMATION_SCHEMA.CHECK_CONSTRAINTS c ON c.CONSTRAINT_SCHEMA = TABLE_SCHEMA AND c.CONSTRAINT_NAME = t.CONSTRAINT_NAME
                                              WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @SourceTable
                                         OPEN constraintcursor;
                                         FETCH NEXT FROM constraintcursor INTO @ConstraintName, @CheckClause;
                                         WHILE @@FETCH_STATUS = 0
                                            BEGIN
                                                 exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] WITH CHECK ADD  CONSTRAINT [' + @ConstraintName + '] CHECK ' + @CheckClause)
                                                 exec('ALTER TABLE ' + @DestinationDB + '.[' + @Schema + '].[' + @SourceTable + '] CHECK CONSTRAINT [' + @ConstraintName + ']')
                                                 FETCH NEXT FROM constraintcursor INTO @ConstraintName, @CheckClause;
                                            END;
                                         CLOSE constraintcursor;
                                         DEALLOCATE constraintcursor; 
                                         
                                         FETCH NEXT FROM tablecursor INTO @SourceTable;
                                         END;
                                         CLOSE tablecursor;
                                         DEALLOCATE tablecursor; 
                                         COMMIT TRAN;";
                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
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

        public bool CreateNewCompanyForEledgerStoreProcedureDB(string connectionString, string pNewVKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SET XACT_ABORT ON;
                                        BEGIN TRAN;
                                        DECLARE @sql nvarchar(max);
                                        DECLARE @Name nvarchar(max);
                                        DECLARE @NEWVKN varchar(11);
                                         
                                        DECLARE storeProcedure CURSOR FOR
                                           SELECT [Definition] FROM [Eledger_4660392430].[sys].[procedures] p
                                           INNER JOIN [Eledger_4660392430].sys.sql_modules m ON p.object_id = m.object_id
                                        
                                        OPEN storeProcedure
                                        
                                        FETCH NEXT FROM storeProcedure INTO @sql
                                        
                                        WHILE @@FETCH_STATUS = 0 
                                        BEGIN  
                                           SET @NEWVKN = @pNewVKN;
                                           SET @Name = 'Eledger_' + @NEWVKN + '';
                                           SET @sql = REPLACE(@sql,'''','''''')
                                           SET @sql = 'USE [' + @Name + ']; EXEC(''' + @sql + ''')'
                                        
                                           EXEC(@sql)
                                        
                                           FETCH NEXT FROM storeProcedure INTO @sql
                                        END             
                                        
                                        CLOSE storeProcedure
                                        DEALLOCATE storeProcedure
                                        COMMIT TRAN;";
                    cmd.Parameters.AddWithValue("@pNewVKN", pNewVKN);
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

        public bool UpdateWithScriptForELedgerDB(string connectionString, string pVKN, string pScipt)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {

                    cmd.CommandText = @"SET XACT_ABORT ON;
                                        BEGIN TRAN;

                                        DECLARE @VKN NVARCHAR(50) = @pVKN;
                                        DECLARE @SCRIPT NVARCHAR(MAX) = @pScipt;
                                        
                                        EXEC('USE ['+@VKN+'] ' + @SCRIPT)
                                          
                                          COMMIT TRAN;";
                    cmd.Parameters.AddWithValue("@pVKN", pVKN);
                    cmd.Parameters.AddWithValue("@pScipt", pScipt);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            if (connection != null) connection.Close();
                            return true;
                        }
                        else
                        {
                            if (connection != null) connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public DataTable GetAllListDataTable(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" SELECT * FROM DashboardLog";
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

        public List<DashboardLog> GetAllList(string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardLog> DashboardLogList = new List<DashboardLog>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" SELECT DashboardLogId, ProcessType, UserName, ActionMessage, ActionWhy, ActionDate
                                         FROM DashboardLog";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardLog objDashboardLog = new DashboardLog();
                                objDashboardLog.TransferToClass(dr);
                                DashboardLogList.Add(objDashboardLog);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardLogList;
            }
        }

        public List<DashboardLog> GetAllListProcessTypeAndToday(string connectionString, string pProcessType, string pUserName, DateTime pStartActionDate, DateTime pEndActionDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<DashboardLog> DashboardLogList = new List<DashboardLog>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SELECT DashboardLogId, ProcessType, UserName, ActionMessage, ActionWhy, ActionDate
                                        FROM DashboardLog
                                        WHERE ProcessType IN (@pProcessType)
                                        AND UserName = @pUserName
                                        AND ActionDate BETWEEN @pStartActionDate AND @pEndActionDate";
                    cmd.Parameters.AddWithValue("@pProcessType", pProcessType);
                    cmd.Parameters.AddWithValue("@pUserName", pUserName);
                    cmd.Parameters.AddWithValue("@pStartActionDate", pStartActionDate);
                    cmd.Parameters.AddWithValue("@pEndActionDate", pEndActionDate);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardLog objDashboardLog = new DashboardLog();
                                objDashboardLog.TransferToClass(dr);
                                DashboardLogList.Add(objDashboardLog);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardLogList;
            }
        }

        public List<DashboardLog> GetAllListForProcessType(string connectionString, int pProcessType)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardLog> DashboardLogList = new List<DashboardLog>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" SELECT DashboardLogId, ProcessType, UserName, ActionMessage, ActionWhy, ActionDate
                                     FROM DashboardLog
                                     WHERE ProcessType = @pProcessType";
                    cmd.Parameters.AddWithValue("@pProcessType", pProcessType);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardLog objDashboardLog = new DashboardLog();
                                objDashboardLog.TransferToClass(dr);
                                DashboardLogList.Add(objDashboardLog);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardLogList;
            }
        }

        private void TransferToClass(DataRow m_dtData)
        {
            m_DashboardLogId = DataHelper.ReadInt32(m_dtData, "DashboardLogId");
            m_ProcessType = DataHelper.ReadInt32(m_dtData, "ProcessType");
            m_UserName = Convert.ToString(m_dtData["UserName"]);
            m_ActionMessage = DataHelper.ReadString(m_dtData, "ActionMessage");
            m_ActionWhy = DataHelper.ReadString(m_dtData, "ActionWhy");
            m_ActionDate = DataHelper.ReadDateTime(m_dtData, "ActionDate");
        }

    }

}