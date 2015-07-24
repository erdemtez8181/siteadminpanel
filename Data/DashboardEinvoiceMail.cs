using DataStoreServices;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DashboardEinvoiceMail
/// </summary>
/// <author>osman.kaykac@isis-bt.com</author>

namespace Siteyonetim.Framework.Data
{

    public class DashboardEinvoiceMail
    {
        // private members

        public Sql_Gateway DB_Gateway;

        //EfaturaMailStoreProcedure
        string m_Şirket;
        string m_Ünvan;
        int m_GelenFaturaYil;
        int m_GelenFaturaAy;
        int m_GidenFaturaYil;
        int m_GidenFaturaAy;
        int m_Gelen;
        int m_Giden;
        int m_Toplam;

        //int m_ActionDate;
        bool _COMMIT = false;
        //Herhangi bir DB isleminin döndürdügü hata mesajini saklar
        public string Error_Message = "";

        // empty constructor
        public DashboardEinvoiceMail()
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
        public DashboardEinvoiceMail(string Şirket, string Ünvan, int GelenFaturaYil, int GelenFaturaAy,
                                     int GidenFaturaYil, int GidenFaturaAy, int Gelen, int Giden, int Toplam)
        {
            this.Şirket = Şirket;
            this.Ünvan = Ünvan;
            this.GelenFaturaYil = GelenFaturaYil;
            this.GelenFaturaAy = GelenFaturaAy;
            this.GidenFaturaYil = GidenFaturaYil;
            this.GidenFaturaAy = GidenFaturaAy;
            this.Gelen = Gelen;
            this.Giden = Giden;
            this.Toplam = Toplam;


        }

        // public accessors for EinvoiceMail
        public string Şirket
        {
            get { return m_Şirket; }
            set { m_Şirket = value; }
        }
        public string Ünvan
        {
            get { return m_Ünvan; }
            set { m_Ünvan = value; }
        }

        public int GelenFaturaYil
        {
            get { return m_GelenFaturaYil; }
            set { m_GelenFaturaYil = value; }
        }
        public int GelenFaturaAy
        {
            get { return m_GelenFaturaAy; }
            set { m_GelenFaturaAy = value; }
        }

        public int GidenFaturaYil
        {
            get { return m_GidenFaturaYil; }
            set { m_GidenFaturaYil = value; }
        }
        public int GidenFaturaAy
        {
            get { return m_GidenFaturaAy; }
            set { m_GidenFaturaAy = value; }
        }
        public int Gelen
        {
            get { return m_Gelen; }
            set { m_Gelen = value; }
        }
        public int Giden
        {
            get { return m_Giden; }
            set { m_Giden = value; }
        }

        public int Toplam
        {
            get { return m_Toplam; }
            set { m_Toplam = value; }
        }

        public DataTable GetAllListInboxDataTable(SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" DECLARE @VKN NVARCHAR(MAX) = '';
                                         DECLARE @SQL NVARCHAR(MAX) = '';
                                         DECLARE @UNVAN NVARCHAR(MAX)='';
                                         
                                         DECLARE CRS_AKB CURSOR FOR SELECT VKN FROM Partner
                                         OPEN CRS_AKB
                                         FETCH NEXT FROM CRS_AKB INTO @VKN  
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                         
                                         
                                         SET @UNVAN = (SELECT TOP(1) UNVAN FROM Partner WHERE VKN = @VKN)
                                         SET @VKN = 'Efatura_' + @VKN
                                         
                                         IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @VKN OR name = @VKN)))
                                         BEGIN
                                         
                                         IF @SQL != ''  
                                         SET @SQL = @SQL + ' UNION '   

                                         SET @SQL = @SQL + 'SELECT '''+@VKN+''' AS ''Şirket'','''+@UNVAN+''' AS ''Ünvan'',
                                         Year(inb.RecordDate)as GelenFaturaYil,
                                         Month(inb.RecordDate) as GelenFaturaAy,
                                         COUNT(*) AS ''Gelen''
                                         FROM '+@VKN+'.dbo.InboxInvoiceExtend inb 
                                         GROUP BY
                                         Year(inb.RecordDate),
                                         Month(inb.RecordDate) '
                                         
                                         END                                         
                                         FETCH NEXT FROM CRS_AKB INTO @VKN;
                                         END
                                         CLOSE CRS_AKB;  
                                         DEALLOCATE CRS_AKB;                                         
                                         EXEC (@SQL)";
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

        public DataTable GetAllListOutboxDataTable(SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" DECLARE @VKN NVARCHAR(MAX) = '';
                                         DECLARE @SQL2 NVARCHAR(MAX) = '';
                                         DECLARE @UNVAN NVARCHAR(MAX)='';
                                         
                                         DECLARE CRS_AKB CURSOR FOR SELECT VKN FROM Partner
                                         OPEN CRS_AKB
                                         FETCH NEXT FROM CRS_AKB INTO @VKN  
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                         
                                         
                                         SET @UNVAN = (SELECT TOP(1) UNVAN FROM Partner WHERE VKN = @VKN)
                                         SET @VKN = 'Efatura_' + @VKN
                                         
                                         IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @VKN OR name = @VKN)))
                                         BEGIN
                                         
                                         IF @SQL2 != ''  
                                         SET @SQL2 = @SQL2 + ' UNION '   

                                         SET @SQL2 = @SQL2 + 'SELECT '''+@VKN+''' AS ''GidenŞirket'','''+@UNVAN+''' AS ''GidenÜnvan'',
                                         Year(outb.RecordDate)as GidenFaturaYil,
                                         Month(outb.RecordDate) as GidenFaturaAy,
                                         COUNT(*) AS ''Giden''
                                         FROM '+@VKN+'.dbo.OutboxInvoiceExtend outb 
                                         GROUP BY
                                         Year(outb.RecordDate),
                                         Month(outb.RecordDate) '
                                         
                                         END                                         
                                         FETCH NEXT FROM CRS_AKB INTO @VKN;
                                         END
                                         CLOSE CRS_AKB;  
                                         DEALLOCATE CRS_AKB;                                         
                                         EXEC (@SQL2)";
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

        public List<DashboardEinvoiceMail> GetAllList(string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardEinvoiceMail> DashboardEinvoiceMailList = new List<DashboardEinvoiceMail>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" DECLARE @VKN NVARCHAR(MAX) = '';
                                         DECLARE @SQL NVARCHAR(MAX) = '';
                                         DECLARE @UNVAN NVARCHAR(MAX)='';
                                         
                                         DECLARE CRS_AKB CURSOR FOR SELECT VKN FROM Partner
                                         OPEN CRS_AKB
                                         FETCH NEXT FROM CRS_AKB INTO @VKN  
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN

                                         SET @UNVAN = (SELECT TOP(1) UNVAN FROM Partner WHERE VKN = @VKN)
                                         SET @VKN = 'Efatura_' + @VKN
                                         
                                         IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @VKN OR name = @VKN)))
                                         BEGIN
                                         
                                         IF @SQL != ''  
                                         SET @SQL = @SQL + ' UNION '
                                         
                                         SET @SQL = @SQL + 'SELECT '''+@VKN+''' AS ''Şirket'','''+@UNVAN+''' AS ''Ünvan'', i.GelenFaturaYil, i.GelenFaturaAy,
                                         o.GidenFaturaYil, o.GidenFaturaAy, i.Gelen AS Gelen, o.Giden AS Giden
                                         from 
                                         (Select Year(inb.RecordDate) as GelenFaturaYil,
                                         Month(inb.RecordDate) as GelenFaturaAy,
                                         COUNT(*) AS Gelen
                                         FROM '+@VKN+'.dbo.InboxInvoiceExtend inb 
                                         GROUP BY
                                         Year(inb.RecordDate),
                                         Month(inb.RecordDate) ) i

                                         FULL OUTER JOIN (Select Year(outb.RecordDate)as GidenFaturaYil,
                                         Month(outb.RecordDate) as GidenFaturaAy,
                                         COUNT(*) AS Giden
                                         FROM '+@VKN+'.dbo.OutboxInvoiceExtend outb 
                                         GROUP BY
                                         Year(outb.RecordDate),
                                         Month(outb.RecordDate) ) o
                                         ON i.GelenFaturaYil = o.GidenFaturaYil
                                         and i.GelenFaturaAy = o.GidenFaturaAy  '
                                         
                                         END
                                         
                                         FETCH NEXT FROM CRS_AKB INTO @VKN;
                                         END
                                         CLOSE CRS_AKB;  
                                         DEALLOCATE CRS_AKB;
                                         EXEC (@SQL)";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardEinvoiceMail objDashboardEinvoiceMail = new DashboardEinvoiceMail();
                                objDashboardEinvoiceMail.TransferToClass(dr);
                                DashboardEinvoiceMailList.Add(objDashboardEinvoiceMail);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardEinvoiceMailList;
            }
        }

        public DataTable GetAllListForMailing(SqlConnection connection)
        {
            DataTable objDataTableForMailing = new DataTable();
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" DECLARE @VKN NVARCHAR(MAX) = '';
                                         DECLARE @SQL NVARCHAR(MAX) = '';
                                         DECLARE @UNVAN NVARCHAR(MAX)='';
                                         
                                         DECLARE CRS_AKB CURSOR FOR SELECT VKN FROM Partner
                                         OPEN CRS_AKB
                                         FETCH NEXT FROM CRS_AKB INTO @VKN  
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN

                                         SET @UNVAN = (SELECT TOP(1) UNVAN FROM Partner WHERE VKN = @VKN)
                                         SET @VKN = 'Efatura_' + @VKN
                                         
                                         IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @VKN OR name = @VKN)))
                                         BEGIN
                                         
                                         IF @SQL != ''  
                                         SET @SQL = @SQL + ' UNION '
                                         
                                         SET @SQL = @SQL + 'SELECT '''+@VKN+''' AS ''Şirket'','''+@UNVAN+''' AS ''Ünvan'', i.GelenFaturaYil, i.GelenFaturaAy,
                                         o.GidenFaturaYil, o.GidenFaturaAy, i.Gelen AS Gelen, o.Giden AS Giden
                                         from 
                                         (Select Year(inb.RecordDate) as GelenFaturaYil,
                                         Month(inb.RecordDate) as GelenFaturaAy,
                                         COUNT(*) AS Gelen
                                         FROM '+@VKN+'.dbo.InboxInvoiceExtend inb 
                                         GROUP BY
                                         Year(inb.RecordDate),
                                         Month(inb.RecordDate) ) i

                                         FULL OUTER JOIN (Select Year(outb.RecordDate)as GidenFaturaYil,
                                         Month(outb.RecordDate) as GidenFaturaAy,
                                         COUNT(*) AS Giden
                                         FROM '+@VKN+'.dbo.OutboxInvoiceExtend outb 
                                         GROUP BY
                                         Year(outb.RecordDate),
                                         Month(outb.RecordDate) ) o
                                         ON i.GelenFaturaYil = o.GidenFaturaYil
                                         and i.GelenFaturaAy = o.GidenFaturaAy  '
                                         
                                         END
                                         
                                         FETCH NEXT FROM CRS_AKB INTO @VKN;
                                         END
                                         CLOSE CRS_AKB;  
                                         DEALLOCATE CRS_AKB;
                                         EXEC (@SQL)";
                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                {
                    if (dt != null)
                    {
                        objDataTableForMailing.Columns.Add("Şirket");
                        objDataTableForMailing.Columns.Add("Ünvan");
                        objDataTableForMailing.Columns.Add("Yil");
                        objDataTableForMailing.Columns.Add("Ay");
                        objDataTableForMailing.Columns.Add("Gelen");
                        objDataTableForMailing.Columns.Add("Giden");
                        objDataTableForMailing.Columns.Add("Toplam");

                        foreach (DataRow dr in dt.Rows)
                        {
                            DashboardEinvoiceMail objDashboardEinvoiceMail = new DashboardEinvoiceMail();
                            objDashboardEinvoiceMail.TransferToClass(dr);
                            DataRow dri = objDataTableForMailing.NewRow();
                            dri["Şirket"] = objDashboardEinvoiceMail.m_Şirket;
                            dri["Ünvan"] = objDashboardEinvoiceMail.m_Ünvan;
                            dri["Yil"] = objDashboardEinvoiceMail.m_GelenFaturaYil;
                            dri["Ay"] = objDashboardEinvoiceMail.m_GelenFaturaAy;
                            dri["Gelen"] = objDashboardEinvoiceMail.m_Gelen;
                            dri["Giden"] = objDashboardEinvoiceMail.m_Giden;
                            dri["Toplam"] = objDashboardEinvoiceMail.m_Toplam;
                            objDataTableForMailing.Rows.Add(dri);
                        }
                        connection.Close();
                    }
                }
                //return DB_Gateway.ExecuteDataTable(cmd, connection);
                return objDataTableForMailing;
            }
        }

        public List<DashboardEinvoiceMail> GetAllListInbox(string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardEinvoiceMail> DashboardEinvoiceMailList = new List<DashboardEinvoiceMail>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" DECLARE @VKN NVARCHAR(MAX) = '';
                                         DECLARE @SQL NVARCHAR(MAX) = '';
                                         DECLARE @UNVAN NVARCHAR(MAX)='';
                                         
                                         DECLARE CRS_AKB CURSOR FOR SELECT VKN FROM Partner
                                         OPEN CRS_AKB
                                         FETCH NEXT FROM CRS_AKB INTO @VKN  
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                         
                                         
                                         SET @UNVAN = (SELECT TOP(1) UNVAN FROM Partner WHERE VKN = @VKN)
                                         SET @VKN = 'Efatura_' + @VKN
                                         
                                         IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @VKN OR name = @VKN)))
                                         BEGIN
                                         
                                         IF @SQL != ''  
                                         SET @SQL = @SQL + ' UNION '   

                                         SET @SQL = @SQL + 'SELECT '''+@VKN+''' AS ''Şirket'','''+@UNVAN+''' AS ''Ünvan'',
                                         Year(inb.RecordDate)as GelenFaturaYil,
                                         Month(inb.RecordDate) as GelenFaturaAy,
                                         COUNT(*) AS ''Gelen''
                                         FROM '+@VKN+'.dbo.InboxInvoiceExtend inb 
                                         GROUP BY
                                         Year(inb.RecordDate),
                                         Month(inb.RecordDate) '
                                         
                                         END                                         
                                         FETCH NEXT FROM CRS_AKB INTO @VKN;
                                         END
                                         CLOSE CRS_AKB;  
                                         DEALLOCATE CRS_AKB;                                         
                                         EXEC (@SQL)";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardEinvoiceMail objDashboardEinvoiceMail = new DashboardEinvoiceMail();
                                objDashboardEinvoiceMail.TransferToClass(dr);
                                DashboardEinvoiceMailList.Add(objDashboardEinvoiceMail);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardEinvoiceMailList;
            }
        }

        public List<DashboardEinvoiceMail> GetAllListOutbox(string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<DashboardEinvoiceMail> DashboardEinvoiceMailList = new List<DashboardEinvoiceMail>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" DECLARE @VKN NVARCHAR(MAX) = '';
                                         DECLARE @SQL2 NVARCHAR(MAX) = '';
                                         DECLARE @UNVAN NVARCHAR(MAX)='';
                                         
                                         DECLARE CRS_AKB CURSOR FOR SELECT VKN FROM Partner
                                         OPEN CRS_AKB
                                         FETCH NEXT FROM CRS_AKB INTO @VKN  
                                         WHILE @@FETCH_STATUS = 0
                                         BEGIN
                                         
                                         
                                         SET @UNVAN = (SELECT TOP(1) UNVAN FROM Partner WHERE VKN = @VKN)
                                         SET @VKN = 'Efatura_' + @VKN
                                         
                                         IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @VKN OR name = @VKN)))
                                         BEGIN
                                         
                                         IF @SQL2 != ''  
                                         SET @SQL2 = @SQL2 + ' UNION '   

                                         SET @SQL2 = @SQL2 + 'SELECT '''+@VKN+''' AS ''GidenŞirket'','''+@UNVAN+''' AS ''GidenÜnvan'',
                                         Year(outb.RecordDate)as GidenFaturaYil,
                                         Month(outb.RecordDate) as GidenFaturaAy,
                                         COUNT(*) AS ''Giden''
                                         FROM '+@VKN+'.dbo.OutboxInvoiceExtend outb 
                                         GROUP BY
                                         Year(outb.RecordDate),
                                         Month(outb.RecordDate) '
                                         
                                         END                                         
                                         FETCH NEXT FROM CRS_AKB INTO @VKN;
                                         END
                                         CLOSE CRS_AKB;  
                                         DEALLOCATE CRS_AKB;                                         
                                         EXEC (@SQL2)";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                DashboardEinvoiceMail objDashboardEinvoiceMail = new DashboardEinvoiceMail();
                                objDashboardEinvoiceMail.TransferToClass(dr);
                                DashboardEinvoiceMailList.Add(objDashboardEinvoiceMail);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return DashboardEinvoiceMailList;
            }
        }

        //InboxInvoices
        private void TransferToClass(DataRow m_dtData)
        {
            m_Şirket = DataHelper.ReadString(m_dtData, "Şirket");
            m_Ünvan = DataHelper.ReadString(m_dtData, "Ünvan");
            if (DataHelper.ReadInt32(m_dtData, "GelenFaturaYil") < 0)
            {
                m_GelenFaturaYil = 0;
            }
            else
            {
                m_GelenFaturaYil = DataHelper.ReadInt32(m_dtData, "GelenFaturaYil");
            }

            if (DataHelper.ReadInt32(m_dtData, "GelenFaturaAy") < 0)
            {
                m_GelenFaturaAy = 0;
            }
            else
            {
                m_GelenFaturaAy = DataHelper.ReadInt32(m_dtData, "GelenFaturaAy");
            }

            if (DataHelper.ReadInt32(m_dtData, "GidenFaturaYil") < 0)
            {
                m_GidenFaturaYil = DataHelper.ReadInt32(m_dtData, "GelenFaturaYil");
            }
            else
            {
                m_GidenFaturaYil = DataHelper.ReadInt32(m_dtData, "GidenFaturaYil");
            }

            if (DataHelper.ReadInt32(m_dtData, "GidenFaturaAy") < 0)
            {
                m_GidenFaturaAy = DataHelper.ReadInt32(m_dtData, "GelenFaturaAy");
            }
            else
            {
                m_GidenFaturaAy = DataHelper.ReadInt32(m_dtData, "GidenFaturaAy");
            }

            if (DataHelper.ReadInt32(m_dtData, "Gelen") < 0)
            {
                m_Gelen = 0;
            }
            else
            {
                m_Gelen = DataHelper.ReadInt32(m_dtData, "Gelen");
            }
            if (DataHelper.ReadInt32(m_dtData, "Giden") < 0)
            {
                m_Giden = 0;
            }
            else
            {
                m_Giden = DataHelper.ReadInt32(m_dtData, "Giden");
            }
            m_Toplam = m_Gelen + m_Giden;
        }
    }
}