using System;
using System.Collections.Generic;
using System.Data;
using DataStoreServices;
using System.Data.SqlClient;
using Siteyonetim.Framework.Business;


namespace Siteyonetim.Framework.Data
{
    public class ParameterValues
    {
        #region General Properties
        //Database eriþim yöneticisi
        public Sql_Gateway DB_Gateway;
        //loglama aracý 

        #endregion

        #region Properties
        public int TypeID { get; set; }
        public int ModulId { get; set; }
        public string VKN { get; set; }
        public int ParameterID { get; set; }
        public int TopParameterID { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Versiyon { get; set; }
        public bool Secured { get; set; }
        public string DataType { get; set; }
        public int SectionOrder { get; set; }
        public bool Required { get; set; }
        public string ApplicationType { get; set; }
        public int FL_ACTIVE { get; set; }
        public int VersionId { get; set; }

        #endregion

        #region Constructorsd
        public ParameterValues()
        {
            DB_Gateway = new Sql_Gateway();
        }
        #endregion

        #region Methods
        public void TransferToClass(DataRow dr)
        {
            this.TypeID = DataHelper.ReadInt(dr, "TypeID");
            this.ModulId = DataHelper.ReadInt(dr, "ModulId");
            this.VKN = DataHelper.ReadString(dr, "VKN");
            this.ParameterID = DataHelper.ReadInt(dr, "ParameterID");
            this.TopParameterID = DataHelper.ReadInt(dr, "TopParameterID");
            this.Value = DataHelper.ReadString(dr, "Value");
            this.Description = DataHelper.ReadString(dr, "Description");
            this.Versiyon = DataHelper.ReadString(dr, "Versiyon");
            this.Secured = DataHelper.ReadBool(dr, "Secured");
            this.DataType = DataHelper.ReadString(dr, "DataType");
            this.SectionOrder = DataHelper.ReadInt(dr, "SectionOrder");
            this.Required = DataHelper.ReadBool(dr, "Required");
            this.ApplicationType = DataHelper.ReadString(dr, "ApplicationType");
            this.FL_ACTIVE = DataHelper.ReadInt(dr, "FL_ACTIVE");
            this.VersionId = DataHelper.ReadInt(dr, "VersionId");
        }


        public List<ParameterValues> GetAllParameterValues(GlobalEnum.Modul pModulID, string pVKN, string pDataType = "")
        {
            var ParameterValueList = new List<ParameterValues>();

            using (var con = new SqlConnection(GlobalSettings.OrganizationConnectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TypeID, ParameterID, TopParameterID, VKN, ModulId, DataType, ApplicationType
                                              ,Value, Description, Secured, Required, FL_ACTIVE, Versiyon
                                        FROM ParameterValues 
                                        WHERE ModulID = @ModulID AND VKN = @VKN";

                    if (!string.IsNullOrEmpty(pDataType))
                    {
                        cmd.CommandText += @" AND DataType = @DataType";
                        cmd.Parameters.AddWithValue("@DataType", pDataType);
                    }

                    cmd.Parameters.AddWithValue("@VKN", pVKN);
                    cmd.Parameters.AddWithValue("@ModulID", (int)pModulID);
                    cmd.CommandText += @" ORDER BY TypeID";

                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, con))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ParameterValues parameterValue = new ParameterValues();
                                parameterValue.TransferToClass(dr);
                               
                                    
                                    ParameterValueList.Add(parameterValue);
                                
                            }
                        }
                    }
                }
            }
            return ParameterValueList;
        }

        public List<ParameterValues> GetAllParameterValuesForEledger(string connection, GlobalEnum.Modul pModulID, string pVKN, string pDataType = "")
        {
            var ParameterValueList = new List<ParameterValues>();

            using (var con = new SqlConnection(connection))
            {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TypeID, ParameterID, TopParameterID, VKN, ModulId, DataType, ApplicationType
                                              ,Value, Description, Secured, Required, FL_ACTIVE, Versiyon
                                        FROM ParameterValues 
                                        WHERE ModulID = @ModulID AND VKN = @VKN";

                    if (!string.IsNullOrEmpty(pDataType))
                    {
                        cmd.CommandText += @" AND DataType = @DataType";
                        cmd.Parameters.AddWithValue("@DataType", pDataType);
                    }

                    cmd.Parameters.AddWithValue("@VKN", pVKN);
                    cmd.Parameters.AddWithValue("@ModulID", (int)pModulID);
                    cmd.CommandText += @" ORDER BY TypeID";

                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, con))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ParameterValues parameterValue = new ParameterValues();
                                parameterValue.TransferToClass(dr);
                                      ParameterValueList.Add(parameterValue);
                                
                            }
                        }
                    }
                }
            }
            return ParameterValueList;
        }

        public List<ParameterValues> GetAllByModulIDTypeID(GlobalEnum.Modul ModulID, GlobalEnum.PARTNER_PARAMETERS TypeID)
        {
            var list = new List<ParameterValues>();
            using (var con = new SqlConnection(GlobalSettings.OrganizationConnectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ParameterValues.Value,Partner.VKN ,ParameterValues.Secured
                                        FROM ParameterValues 
                                            INNER JOIN Partner ON Partner.VKN = ParameterValues.VKN
                                        WHERE Partner.FL_ACTIVE = 1 AND Partner.Active = 1 
                                            AND ParameterValues.TypeID = @TypeID 
                                            AND ParameterValues.ModulID = @ModulID
                                            AND ParameterValues.FL_ACTIVE = 1";

                    cmd.Parameters.AddWithValue("@TypeID", (int)TypeID);
                    cmd.Parameters.AddWithValue("@ModulID", (int)ModulID);

                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, con))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ParameterValues value = new ParameterValues();
                                value.TransferToClass(dr);
                                       list.Add(value);
                               
                            }
                        }
                    }
                }
            }
            return list;
        }

        public void Save(System.Data.SqlClient.SqlTransaction objTransaction)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {

                if (ParameterID == 0)
                {
                    cmd.CommandText = @" INSERT INTO ParameterValues (TopParameterID,TypeID,Value,Description,Versiyon,
                                                                      Secured,DataType,SectionOrder,Required,ApplicationType,
                                                                      FL_ACTIVE,ModulId,VersionId,VKN)
                                         VALUES (@TopParameterID,@TypeID,@Value,@Description,@Versiyon,@Secured,@DataType,
                                                 @SectionOrder,@Required,@ApplicationType,@FL_ACTIVE,@ModulId,@VersionId,@VKN)";
                }
                else
                {
                    cmd.CommandText = @" UPDATE ParameterValues 
                                         SET TopParameterID=@TopParameterID,TypeID=@TypeID,Value=@Value,
                                             Description=@Description,Versiyon=@Versiyon,Secured=@Secured,
                                             DataType=@DataType,SectionOrder=@SectionOrder,Required=@Required,
                                             ApplicationType=@ApplicationType,FL_ACTIVE=@FL_ACTIVE,
                                             ModulId=@ModulId,VersionId=@VersionId,VKN = @VKN
                                        WHERE ParameterID=@ParameterID";

                    cmd.Parameters.AddWithValue("@ParameterID", ParameterID);
                }

                cmd.Parameters.AddWithValue("@TopParameterID", TopParameterID);
                cmd.Parameters.AddWithValue("@TypeID", TypeID);
                cmd.Parameters.AddWithValue("@Value", Value);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Versiyon", Versiyon);
                cmd.Parameters.AddWithValue("@Secured", Secured);
                cmd.Parameters.AddWithValue("@DataType", DataType);
                cmd.Parameters.AddWithValue("@SectionOrder", SectionOrder);
                cmd.Parameters.AddWithValue("@Required", Required);
                cmd.Parameters.AddWithValue("@ApplicationType", ApplicationType);
                cmd.Parameters.AddWithValue("@FL_ACTIVE", FL_ACTIVE);
                cmd.Parameters.AddWithValue("@ModulId", ModulId);
                cmd.Parameters.AddWithValue("@VersionId", VersionId);
                cmd.Parameters.AddWithValue("@VKN", VKN);

                DB_Gateway.Execute(cmd, objTransaction, null, false, true);
            }
        }


        /// <summary>
        /// Dashboard üzerinden yeni yaratýlan müþterinin parametere bilgilerinin deðiþtirilmesi
        /// </summary>
        /// <returns></returns>
        /// <author>Osman KAYKAÇ</author>
        public bool UpdateNewCustomerParameter(SqlTransaction objTransaction, SqlConnection sqlConnection, string Value, int TypeID)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @"UPDATE ParameterValues 
                                    SET Value = @Value
                                    WHERE TypeID = @TypeID";
                cmd.Parameters.AddWithValue("@Value", Value);
                cmd.Parameters.AddWithValue("@TypeID", TypeID);
                int Id = (int)DB_Gateway.Execute(cmd, objTransaction, sqlConnection, false, true);
                if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {
                    return true;
                }
                return false;
            }
        }

        public void GetAll(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = @" SELECT * FROM ParameterValues 
                                     WHERE FL_ACTIVE = 1 AND TypeID = @TypeID 
                                         AND VKN = @VKN AND ModulID = @ModulId";

                cmd.Parameters.AddWithValue("@TypeID", TypeID);
                cmd.Parameters.AddWithValue("@VKN", VKN);
                cmd.Parameters.AddWithValue("@ModulId", ModulId);

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

            }
            if (connection != null)
                connection.Close();
        }
        #endregion

        #region Expanded Methods
        public bool Update(string vkn, GlobalEnum.Modul modul, GlobalEnum.PARTNER_PARAMETERS parameter, string value)
        {
            using (SqlConnection connection = new SqlConnection(GlobalSettings.OrganizationConnectionString))
            {
                connection.Open();
                using (System.Data.SqlClient.SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @" UPDATE ParameterValues 
                                         SET Value = @Value 
                                         WHERE VKN = @VKN and ModulId = @ModulId AND  TypeID=@TypeId";

                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.Parameters.AddWithValue("@ModulId", (int)modul);
                    cmd.Parameters.AddWithValue("@VKN", vkn);
                    cmd.Parameters.AddWithValue("@TypeId", (int)parameter);

                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 1)
                        return true;
                }
            }
            return false;
        }

        public List<ParameterValues> GetSectionParameterValues(string pConString, string pVkn, int pModulId, int? pParameterID = null)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(pConString))
            {
                List<ParameterValues> PartnerParametersList = new List<ParameterValues>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @" SELECT TypeID,ParameterID,TopParameterID,VKN,ModulId ,DataType,
                                         ApplicationType,Value,Description,Secured,Required,FL_ACTIVE,Versiyon
                                         FROM ParameterValues
                                         WHERE VKN = @VKN AND ModulId = @ModulId";

                    if (pParameterID != null)
                    {
                        cmd.CommandText += " AND ParameterID = @ParameterID ";
                        cmd.Parameters.AddWithValue("@ParameterID", pParameterID);
                    }

                    cmd.Parameters.AddWithValue("@VKN", pVkn);
                    cmd.Parameters.AddWithValue("@ModulID", pModulId);
                    cmd.CommandText += " ORDER BY TypeID";

                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ParameterValues objPartnerParameters = new ParameterValues();
                                objPartnerParameters.TransferToClass(dr);
                                PartnerParametersList.Add(objPartnerParameters);
                            }
                        }
                    }
                }

                if (connection != null)
                    connection.Close();

                return PartnerParametersList;
            }
        }

        public List<ParameterValues> GetParametersByTopID(string connectionString, string pVKN, int pModulID, int pTopParameterID)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<ParameterValues> PartnerParametersList = new List<ParameterValues>();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SELECT TypeID, Value,TopParameterID ,ModulId ,Description,VKN,Secured
                                        FROM ParameterValues  
                                        where TopParameterID = @TopParameterID and ModulID = @ModulID and  VKN = @VKN AND FL_ACTIVE = 1
                                        order by TypeID";
                    cmd.Parameters.AddWithValue("@TopParameterID", pTopParameterID);
                    cmd.Parameters.AddWithValue("@ModulID", pModulID);
                    cmd.Parameters.AddWithValue("@VKN", pVKN);


                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ParameterValues objPartnerParameters = new ParameterValues();
                                objPartnerParameters.TopParameterID = DataHelper.ReadInt(dr, "TopParameterID");
                                objPartnerParameters.TypeID = DataHelper.ReadInt(dr, "TypeID");
                                objPartnerParameters.Value = DataHelper.ReadString(dr, "Value");
                                objPartnerParameters.Description = DataHelper.ReadString(dr, "Description");
                                objPartnerParameters.Secured = DataHelper.ReadBool(dr, "Secured");
                                PartnerParametersList.Add(objPartnerParameters);
                            }
                        }
                    }
                }
                if (connection != null) connection.Close();
                return PartnerParametersList;
            }
        }

        #endregion

    }
}




