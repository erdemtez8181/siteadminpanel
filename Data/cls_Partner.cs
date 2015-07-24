//Bu Kod ?sis Bili?im Taraf?ndan geli?tirilmi?tir (Version: 1.0) Date:3.25.2011 Time:11:58 
using System;
using System.Collections.Generic;
using System.Data;
using DataStoreServices;
using System.Data.SqlClient;
using Siteyonetim.Framework.Business;


namespace Siteyonetim.Framework.Data
{
    [Serializable]
    public class cls_Partner
    {
        #region General Properties
        //Database eri?im y?neticisi
        public Sql_Gateway DB_Gateway;

        //loglama arac? 

        #endregion

        #region Properties

        private int _PartnerID;
        public int PartnerID
        {
            get { return _PartnerID; }
            set { _PartnerID = value; }
        }

        private string _OrganizationCode;
        public string OrganizationCode
        {
            get { return _OrganizationCode; }
            set { _OrganizationCode = value; }
        }

        private string _VKN;
        public string VKN
        {
            get { return _VKN; }
            set { _VKN = value; }
        }

        private string _TCKN;
        public string TCKN
        {
            get { return _TCKN; }
            set { _TCKN = value; }
        }

        private string _UNVAN;
        public string UNVAN
        {
            get { return _UNVAN; }
            set { _UNVAN = value; }
        }
        private string _TAPDKNO;
        public string TAPDKNO
        {
            get { return _TAPDKNO; }
            set { _TAPDKNO = value; }
        }
        public string businessDescription
        {
            get;
            set;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }

        private string _StreetName;
        public string StreetName
        {
            get { return _StreetName; }
            set { _StreetName = value; }
        }

        private string _BuildingName;
        public string BuildingName
        {
            get { return _BuildingName; }
            set { _BuildingName = value; }
        }

        private string _BuildingNumber;
        public string BuildingNumber
        {
            get { return _BuildingNumber; }
            set { _BuildingNumber = value; }
        }

        private string _Room;
        public string Room
        {
            get { return _Room; }
            set { _Room = value; }
        }

        private string _CitySubdivisionName;
        public string CitySubdivisionName
        {
            get { return _CitySubdivisionName; }
            set { _CitySubdivisionName = value; }
        }

        private string _Region;
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        private string _CityName;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        private string _PostalZone;
        public string PostalZone
        {
            get { return _PostalZone; }
            set { _PostalZone = value; }
        }

        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }

        private string _Telefax;
        public string Telefax
        {
            get { return _Telefax; }
            set { _Telefax = value; }
        }

        private string _ElectronicMail;
        public string ElectronicMail
        {
            get { return _ElectronicMail; }
            set { _ElectronicMail = value; }
        }

        private string _WebsiteURI;
        public string WebsiteURI
        {
            get { return _WebsiteURI; }
            set { _WebsiteURI = value; }
        }

        private string _TaxScheme;
        public string TaxScheme
        {
            get { return _TaxScheme; }
            set { _TaxScheme = value; }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Country_IdentificationCode;
        public string Country_IdentificationCode
        {
            get { return _Country_IdentificationCode; }
            set { _Country_IdentificationCode = value; }
        }

        private int _OrganizationID;
        public int OrganizationID
        {
            get { return _OrganizationID; }
            set { _OrganizationID = value; }
        }

        private string _CompanyCode;
        public string CompanyCode
        {
            get { return _CompanyCode; }
            set { _CompanyCode = value; }
        }

        private int _FL_ACTIVE;
        public int FL_ACTIVE
        {
            get { return _FL_ACTIVE; }
            set { _FL_ACTIVE = value; }
        }

        private int _ERPCustomerNo;
        public int ERPCustomerNo
        {
            get { return _ERPCustomerNo; }
            set { _ERPCustomerNo = value; }
        }

        private string _LedgerCreator;
        public string LedgerCreator
        {
            get { return _LedgerCreator; }
            set { _LedgerCreator = value; }
        }

        private string _PartnerGb;
        public string PartnerGb
        {
            get { return _PartnerGb; }
            set { _PartnerGb = value; }
        }


        #endregion

        #region Constructors
        public cls_Partner()
        {
            DB_Gateway = new Sql_Gateway();
        }
        public cls_Partner(int PartnerID, string OrganizationCode, string VKN, string TCKN, string UNVAN, string TAPDKNO, string businessDescription, string Name, string Surname, string StreetName, string BuildingName, string BuildingNumber, string Room, string CitySubdivisionName, string Region, string CityName, string PostalZone, string Country, string Telephone, string Telefax, string ElectronicMail, string WebsiteURI, string TaxScheme, bool Active, string Country_IdentificationCode, int OrganizationID, string CompanyCode, int FL_ACTIVE)
        {
            this._PartnerID = PartnerID;
            this._OrganizationCode = OrganizationCode;
            this._VKN = VKN;
            this._TCKN = TCKN;
            this._UNVAN = UNVAN;
            this._TAPDKNO = TAPDKNO;
            this.businessDescription = businessDescription;
            this._Name = Name;
            this._Surname = Surname;
            this._StreetName = StreetName;
            this._BuildingName = BuildingName;
            this._BuildingNumber = BuildingNumber;
            this._Room = Room;
            this._CitySubdivisionName = CitySubdivisionName;
            this._Region = Region;
            this._CityName = CityName;
            this._PostalZone = PostalZone;
            this._Country = Country;
            this._Telephone = Telephone;
            this._Telefax = Telefax;
            this._ElectronicMail = ElectronicMail;
            this._WebsiteURI = WebsiteURI;
            this._TaxScheme = TaxScheme;
            this._Active = Active;
            this._Country_IdentificationCode = Country_IdentificationCode;
            this._OrganizationID = OrganizationID;
            this._CompanyCode = CompanyCode;
            this._FL_ACTIVE = FL_ACTIVE;
        }
        #endregion

        #region Methods

        //public bool Delete(System.Data.SqlClient.SqlTransaction objTransaction)
        //{
        //    return Delete(objTransaction, null);
        //}
        //public bool Delete(System.Data.SqlClient.SqlConnection SqlConnection)
        //{
        //    return Delete(null, SqlConnection);
        //}

        //public bool Delete(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        //{

        //    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
        //    {
        //        cmd.CommandText = "Delete from Partner WHERE PartnerID = @pPartnerID";
        //        cmd.Parameters.AddWithValue("@pPartnerID", _PartnerID);

        //        if (DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, true) != (int)GlobalEnum.DB_EXECUTE.FAIL)
        //        {


        //        }
        //        return true;
        //    }

        //}
        public bool DeleteVirtual(System.Data.SqlClient.SqlTransaction objTransaction)
        {
            return DeleteVirtual(objTransaction, null);
        }
        public bool DeleteVirtual(System.Data.SqlClient.SqlConnection SqlConnection)
        {
            return DeleteVirtual(null, SqlConnection);
        }
        public bool DeleteVirtual(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "update Partner set FL_ACTIVE = 0 WHERE PartnerID = @pPartnerID";
                cmd.Parameters.AddWithValue("@pPartnerID", _PartnerID);

                if (DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, true) != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {


                }
                return true;
            }

        }

        // Save Method With Transaction
        public bool Save(System.Data.SqlClient.SqlTransaction objTransaction)
        {
            if (_PartnerID == 0)
            {

                return Insert(objTransaction, null);
            }
            else
            {
                return Update(objTransaction, null);
            }
        }
        // Save Method With Connection
        public bool Save(string connectionString)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                return Save(connection);
            }
        }

        public bool Save(SqlConnection connection)
        {
            if (_PartnerID == 0)
            {
                return Insert(null, connection);
            }
            else
            {
                return Update(null, connection);
            }
        }

        // Insert Method With Transaction
        private bool Insert(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @"INSERT INTO Partner (OrganizationCode,VKN,TCKN,UNVAN,TAPDKNO,businessDescription,Name,Surname,StreetName,BuildingName,BuildingNumber,Room,CitySubdivisionName,Region,CityName,PostalZone,Country,Telephone,Telefax,ElectronicMail,WebsiteURI,TaxScheme,Active,Country_IdentificationCode,OrganizationID,CompanyCode,FL_ACTIVE, LedgerCreator,Alias) 
                                    VALUES (@pOrganizationCode,@pVKN,@pTCKN,@pUNVAN,@pTAPDKNO,@businessDescription,@pName,@pSurname,@pStreetName,@pBuildingName,@pBuildingNumber,@pRoom,@pCitySubdivisionName,@pRegion,@pCityName,@pPostalZone,@pCountry,@pTelephone,@pTelefax,@pElectronicMail,@pWebsiteURI,@pTaxScheme,@pActive,@pCountry_IdentificationCode,@pOrganizationID,@pCompanyCode,@pFL_ACTIVE,@pLedgerCreator,@pParnerGb)";
                cmd.Parameters.AddWithValue("@pOrganizationCode", DataHelper.HandleDBNullValue(_OrganizationCode));
                cmd.Parameters.AddWithValue("@pVKN", _VKN);
                cmd.Parameters.AddWithValue("@pTCKN", _TCKN);
                cmd.Parameters.AddWithValue("@pUNVAN", _UNVAN);
                cmd.Parameters.AddWithValue("@pTAPDKNO", _TAPDKNO);
                cmd.Parameters.AddWithValue("@businessDescription", businessDescription);

                cmd.Parameters.AddWithValue("@pName", _Name);
                cmd.Parameters.AddWithValue("@pSurname", _Surname);
                cmd.Parameters.AddWithValue("@pStreetName", _StreetName);
                cmd.Parameters.AddWithValue("@pBuildingName", _BuildingName);
                cmd.Parameters.AddWithValue("@pBuildingNumber", _BuildingNumber);
                cmd.Parameters.AddWithValue("@pRoom", _Room);
                cmd.Parameters.AddWithValue("@pCitySubdivisionName", _CitySubdivisionName);
                cmd.Parameters.AddWithValue("@pRegion", _Region);
                cmd.Parameters.AddWithValue("@pCityName", _CityName);
                cmd.Parameters.AddWithValue("@pPostalZone", _PostalZone);
                cmd.Parameters.AddWithValue("@pCountry", _Country);
                cmd.Parameters.AddWithValue("@pTelephone", _Telephone);
                cmd.Parameters.AddWithValue("@pTelefax", _Telefax);
                cmd.Parameters.AddWithValue("@pElectronicMail", _ElectronicMail);
                cmd.Parameters.AddWithValue("@pWebsiteURI", _WebsiteURI);
                cmd.Parameters.AddWithValue("@pTaxScheme", _TaxScheme);
                cmd.Parameters.AddWithValue("@pActive", _Active);
                cmd.Parameters.AddWithValue("@pCountry_IdentificationCode", _Country_IdentificationCode);
                cmd.Parameters.AddWithValue("@pOrganizationID", _OrganizationID);
                cmd.Parameters.AddWithValue("@pCompanyCode", _CompanyCode);
                cmd.Parameters.AddWithValue("@pFL_ACTIVE", 1);
                cmd.Parameters.AddWithValue("@pLedgerCreator", _LedgerCreator);
                cmd.Parameters.AddWithValue("@pParnerGb", _PartnerGb);




                int Id = (int)DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, false);
                if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {
                    _PartnerID = Id;
                    return true;
                }
                return false;
            }


        }
        // Update Method With Transaction
        private bool Update(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @"UPDATE Partner 
                                    SET OrganizationCode = @pOrganizationCode, VKN = @pVKN ,TCKN = @pTCKN ,UNVAN = @pUNVAN, TAPDKNO = @pTAPDKNO, businessDescription =@businessDescription ,Name = @pName ,Surname = @pSurname ,StreetName = @pStreetName ,BuildingName = @pBuildingName ,BuildingNumber = @pBuildingNumber ,Room = @pRoom ,CitySubdivisionName = @pCitySubdivisionName ,Region = @pRegion ,CityName = @pCityName ,PostalZone = @pPostalZone ,Country = @pCountry ,Telephone = @pTelephone ,Telefax = @pTelefax ,ElectronicMail = @pElectronicMail ,WebsiteURI = @pWebsiteURI ,TaxScheme = @pTaxScheme ,Active = @pActive ,Country_IdentificationCode = @pCountry_IdentificationCode ,OrganizationID = @pOrganizationID ,CompanyCode = @pCompanyCode, LedgerCreator = @pLedgerCreator, Alias = @pParnerGb 
                                    WHERE PartnerID = @pPartnerID";

                cmd.Parameters.AddWithValue("@pOrganizationCode", DataHelper.HandleDBNullValue(_OrganizationCode));
                cmd.Parameters.AddWithValue("@pPartnerID", _PartnerID);
                cmd.Parameters.AddWithValue("@pVKN", _VKN);
                cmd.Parameters.AddWithValue("@pTCKN", _TCKN);
                cmd.Parameters.AddWithValue("@pUNVAN", _UNVAN);
                cmd.Parameters.AddWithValue("@pTAPDKNO", _TAPDKNO);
                cmd.Parameters.AddWithValue("@businessDescription", businessDescription);

                cmd.Parameters.AddWithValue("@pName", _Name);
                cmd.Parameters.AddWithValue("@pSurname", _Surname);
                cmd.Parameters.AddWithValue("@pStreetName", _StreetName);
                cmd.Parameters.AddWithValue("@pBuildingName", _BuildingName);
                cmd.Parameters.AddWithValue("@pBuildingNumber", _BuildingNumber);
                cmd.Parameters.AddWithValue("@pRoom", _Room);
                cmd.Parameters.AddWithValue("@pCitySubdivisionName", _CitySubdivisionName);
                cmd.Parameters.AddWithValue("@pRegion", _Region);
                cmd.Parameters.AddWithValue("@pCityName", _CityName);
                cmd.Parameters.AddWithValue("@pPostalZone", _PostalZone);
                cmd.Parameters.AddWithValue("@pCountry", _Country);
                cmd.Parameters.AddWithValue("@pTelephone", _Telephone);
                cmd.Parameters.AddWithValue("@pTelefax", _Telefax);
                cmd.Parameters.AddWithValue("@pElectronicMail", _ElectronicMail);
                cmd.Parameters.AddWithValue("@pWebsiteURI", _WebsiteURI);
                cmd.Parameters.AddWithValue("@pTaxScheme", _TaxScheme);
                cmd.Parameters.AddWithValue("@pActive", _Active);
                cmd.Parameters.AddWithValue("@pCountry_IdentificationCode", _Country_IdentificationCode);
                cmd.Parameters.AddWithValue("@pOrganizationID", _OrganizationID);
                cmd.Parameters.AddWithValue("@pCompanyCode", _CompanyCode);
                cmd.Parameters.AddWithValue("@pLedgerCreator", _LedgerCreator);
                cmd.Parameters.AddWithValue("@pParnerGb", _PartnerGb);
                int Id = (int)DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, true);
                if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {
                    _PartnerID = Id;
                    return true;
                }
                return false;

            }


        }

        public bool UpdateUnvan(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "UPDATE Partner SET UNVAN = @UNVAN WHERE VKN = @VKN";
                cmd.Parameters.AddWithValue("@VKN", _VKN);
                cmd.Parameters.AddWithValue("@UNVAN", _UNVAN);
                int Id = (int)DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, true);
                if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {
                    _PartnerID = Id;
                    return true;
                }
                return false;
            }
        }

        // SavePartner Method With Connection
        public bool SavePartner(System.Data.SqlClient.SqlConnection SqlConnection)
        {
            if (_PartnerID == 0)
            {
                return InsertPartner(null, SqlConnection);
            }
            else
            {
                return UpdatePartner(null, SqlConnection);
            }
        }
        // InsertPartner Method With Transaction
        private bool InsertPartner(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Partner (OrganizationCode,VKN,TCKN,UNVAN,TAPDKNO,businessDescription,Name,Surname,StreetName,BuildingName,BuildingNumber,Room,CitySubdivisionName,Region,CityName,PostalZone,Country,Telephone,Telefax,ElectronicMail,WebsiteURI,TaxScheme,Active,Country_IdentificationCode,OrganizationID,CompanyCode,FL_ACTIVE,ERPCustomerNo) VALUES (@pOrganizationCode,@pVKN,@pTCKN,@pUNVAN,@pTAPDKNO,@businessDescription,@pName,@pSurname,@pStreetName,@pBuildingName,@pBuildingNumber,@pRoom,@pCitySubdivisionName,@pRegion,@pCityName,@pPostalZone,@pCountry,@pTelephone,@pTelefax,@pElectronicMail,@pWebsiteURI,@pTaxScheme,@pActive,@pCountry_IdentificationCode,@pOrganizationID,@pCompanyCode,@pFL_ACTIVE,@pERPCustomerNo)";
                cmd.Parameters.AddWithValue("@pOrganizationCode", _OrganizationCode);
                cmd.Parameters.AddWithValue("@pVKN", _VKN);
                cmd.Parameters.AddWithValue("@pTCKN", _TCKN);
                cmd.Parameters.AddWithValue("@pUNVAN", _UNVAN);
                cmd.Parameters.AddWithValue("@pTAPDKNO", _TAPDKNO);
                cmd.Parameters.AddWithValue("@businessDescription", businessDescription);

                cmd.Parameters.AddWithValue("@pName", _Name);
                cmd.Parameters.AddWithValue("@pSurname", _Surname);
                cmd.Parameters.AddWithValue("@pStreetName", _StreetName);
                cmd.Parameters.AddWithValue("@pBuildingName", _BuildingName);
                cmd.Parameters.AddWithValue("@pBuildingNumber", _BuildingNumber);
                cmd.Parameters.AddWithValue("@pRoom", _Room);
                cmd.Parameters.AddWithValue("@pCitySubdivisionName", _CitySubdivisionName);
                cmd.Parameters.AddWithValue("@pRegion", _Region);
                cmd.Parameters.AddWithValue("@pCityName", _CityName);
                cmd.Parameters.AddWithValue("@pPostalZone", _PostalZone);
                cmd.Parameters.AddWithValue("@pCountry", _Country);
                cmd.Parameters.AddWithValue("@pTelephone", _Telephone);
                cmd.Parameters.AddWithValue("@pTelefax", _Telefax);
                cmd.Parameters.AddWithValue("@pElectronicMail", _ElectronicMail);
                cmd.Parameters.AddWithValue("@pWebsiteURI", _WebsiteURI);
                cmd.Parameters.AddWithValue("@pTaxScheme", _TaxScheme);
                cmd.Parameters.AddWithValue("@pActive", _Active);
                cmd.Parameters.AddWithValue("@pCountry_IdentificationCode", _Country_IdentificationCode);
                cmd.Parameters.AddWithValue("@pOrganizationID", _OrganizationID);
                cmd.Parameters.AddWithValue("@pCompanyCode", _CompanyCode);
                cmd.Parameters.AddWithValue("@pFL_ACTIVE", 1);
                cmd.Parameters.AddWithValue("@pERPCustomerNo", _ERPCustomerNo);


                int Id = (int)DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, false);
                if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {
                    _PartnerID = Id;
                    return true;
                }
                return false;
            }


        }

        public List<cls_Partner> GetAllByVKN(string connectionString, string VKN)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                List<cls_Partner> result = new List<cls_Partner>();

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Partner WHERE VKN = @pVKN";
                    cmd.Parameters.AddWithValue("@pVKN", VKN);
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                cls_Partner pa = new cls_Partner();
                                pa.TransferToClass(dr);
                                result.Add(pa);
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return result;
                }
            }
        }

        // Update Method With Transaction
        private bool UpdatePartner(System.Data.SqlClient.SqlTransaction objTransaction, System.Data.SqlClient.SqlConnection SqlConnection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @"UPDATE Partner SET OrganizationCode = @pOrganizationCode,
                                                        VKN = @pVKN ,TCKN = @pTCKN ,UNVAN = @pUNVAN, 
                                                        TAPDKNO = @pTAPDKNO,businessDescription=@businessDescription, Name = @pName ,Surname = @pSurname,
                                                        StreetName = @pStreetName ,BuildingName = @pBuildingName,
                                                        BuildingNumber = @pBuildingNumber ,Room = @pRoom,
                                                        CitySubdivisionName = @pCitySubdivisionName ,Region = @pRegion,
                                                        CityName = @pCityName ,PostalZone = @pPostalZone,
                                                        Country = @pCountry ,Telephone = @pTelephone,
                                                        Telefax = @pTelefax ,ElectronicMail = @pElectronicMail,
                                                        WebsiteURI = @pWebsiteURI ,TaxScheme = @pTaxScheme,
                                                        Active = @pActive,
                                                        Country_IdentificationCode = @pCountry_IdentificationCode,
                                                        OrganizationID = @pOrganizationID ,CompanyCode = @pCompanyCode, 
                                                        FL_ACTIVE = @pFL_ACTIVE, LedgerCreator = @pLedgerCreator, Alias = @pParnerGb WHERE PartnerID = @pPartnerID";
                cmd.Parameters.AddWithValue("@pPartnerID", _PartnerID);
                cmd.Parameters.AddWithValue("@pOrganizationCode", _OrganizationCode);
                cmd.Parameters.AddWithValue("@pVKN", _VKN);
                cmd.Parameters.AddWithValue("@pTCKN", _TCKN);
                cmd.Parameters.AddWithValue("@pUNVAN", _UNVAN);
                cmd.Parameters.AddWithValue("@pTAPDKNO", _TAPDKNO);
                cmd.Parameters.AddWithValue("@businessDescription", businessDescription);

                cmd.Parameters.AddWithValue("@pName", _Name);
                cmd.Parameters.AddWithValue("@pSurname", _Surname);
                cmd.Parameters.AddWithValue("@pStreetName", _StreetName);
                cmd.Parameters.AddWithValue("@pBuildingName", _BuildingName);
                cmd.Parameters.AddWithValue("@pBuildingNumber", _BuildingNumber);
                cmd.Parameters.AddWithValue("@pRoom", _Room);
                cmd.Parameters.AddWithValue("@pCitySubdivisionName", _CitySubdivisionName);
                cmd.Parameters.AddWithValue("@pRegion", _Region);
                cmd.Parameters.AddWithValue("@pCityName", _CityName);
                cmd.Parameters.AddWithValue("@pPostalZone", _PostalZone);
                cmd.Parameters.AddWithValue("@pCountry", _Country);
                cmd.Parameters.AddWithValue("@pTelephone", _Telephone);
                cmd.Parameters.AddWithValue("@pTelefax", _Telefax);
                cmd.Parameters.AddWithValue("@pElectronicMail", _ElectronicMail);
                cmd.Parameters.AddWithValue("@pWebsiteURI", _WebsiteURI);
                cmd.Parameters.AddWithValue("@pTaxScheme", _TaxScheme);
                cmd.Parameters.AddWithValue("@pActive", _Active);
                cmd.Parameters.AddWithValue("@pCountry_IdentificationCode", _Country_IdentificationCode);
                cmd.Parameters.AddWithValue("@pOrganizationID", _OrganizationID);
                cmd.Parameters.AddWithValue("@pCompanyCode", _CompanyCode);
                cmd.Parameters.AddWithValue("@pFL_ACTIVE", _FL_ACTIVE);
                cmd.Parameters.AddWithValue("@pLedgerCreator", _LedgerCreator);
                cmd.Parameters.AddWithValue("@pParnerGb", _PartnerGb);
                int Id = (int)DB_Gateway.Execute(cmd, objTransaction, SqlConnection, false, true);
                if (Id != (int)GlobalEnum.DB_EXECUTE.FAIL)
                {
                    _PartnerID = Id;
                    return true;
                }
                return false;

            }

        }

        public bool GetItByVKN(string connectionString, string vkn)
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return GetItByVKN(sqlConnection, vkn);
            }
        }

        public bool GetItByVKN(SqlConnection sqlConnection, string vkn)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Partner WHERE VKN = @VKN AND FL_ACTIVE = 1";
                cmd.Parameters.AddWithValue("@VKN", vkn);
                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, sqlConnection))
                {
                    if (dt != null)
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

        public bool GetIt(string connectionString, int _PartnerID)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Partner WHERE PartnerID = @pPartnerID";
                    cmd.Parameters.AddWithValue("@pPartnerID", _PartnerID);
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


        public bool checkExistByVKN(string pVKN)
        {
            string strSQL = "";
            DataTable dtTemp;
            strSQL = "Select * from Partner where FL_ACTIVE=1 AND VKN = '" + pVKN + "'";

            dtTemp = DB_Gateway.DataStoreServices(strSQL, null);
            if (dtTemp.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public string ShowOrganizationSize(string connectionString)
        {
            string Size = "";
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = "exec sp_spaceused";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Size = dr[1].ToString();
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return Size;
                }
            }
        }

        public int ShowEFaturaSize(string connectionString)
        {
            int Size = 0;
            int TotalSize = 0;
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = @"SELECT ALDB.name,
                                        ROUND(SUM(MASFILE.size) * 8 / 1024, 0) AS Size_MB
                                        FROM sys.master_files AS MASFILE
                                        INNER JOIN sys.databases AS ALDB ON ALDB.database_id = MASFILE.database_id
                                        WHERE ALDB.database_id > 4
                                        and ALDB.name like 'Efatura%'
                                        GROUP BY ALDB.name
                                        ORDER BY ALDB.name";
                    using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                    {
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Size = Convert.ToInt32(dr[1].ToString());
                                TotalSize = TotalSize + Size;
                            }
                        }
                    }
                    if (connection != null) connection.Close();
                    return TotalSize;
                }
            }
        }

        public void TransferToClass(DataRow dr)
        {
            this._PartnerID = DataHelper.ReadInt(dr, "PartnerID");
            this._OrganizationCode = DataHelper.ReadString(dr, "OrganizationCode");
            this._VKN = DataHelper.ReadString(dr, "VKN");
            this._TCKN = DataHelper.ReadString(dr, "TCKN");
            this._UNVAN = DataHelper.ReadString(dr, "UNVAN");
            this._TAPDKNO = DataHelper.ReadString(dr, "TAPDKNO");
            this.businessDescription = DataHelper.ReadString(dr, "businessDescription");
            this._Name = DataHelper.ReadString(dr, "Name");
            this._Surname = DataHelper.ReadString(dr, "Surname");
            this._StreetName = DataHelper.ReadString(dr, "StreetName");
            this._BuildingName = DataHelper.ReadString(dr, "BuildingName");
            this._BuildingNumber = DataHelper.ReadString(dr, "BuildingNumber");
            this._Room = DataHelper.ReadString(dr, "Room");
            this._CitySubdivisionName = DataHelper.ReadString(dr, "CitySubdivisionName");
            this._Region = DataHelper.ReadString(dr, "Region");
            this._CityName = DataHelper.ReadString(dr, "CityName");
            this._PostalZone = DataHelper.ReadString(dr, "PostalZone");
            this._Country = DataHelper.ReadString(dr, "Country");
            this._Telephone = DataHelper.ReadString(dr, "Telephone");
            this._Telefax = DataHelper.ReadString(dr, "Telefax");
            this._ElectronicMail = DataHelper.ReadString(dr, "ElectronicMail");
            this._WebsiteURI = DataHelper.ReadString(dr, "WebsiteURI");
            this._TaxScheme = DataHelper.ReadString(dr, "TaxScheme");
            this._Active = DataHelper.ReadBool(dr, "Active");
            this._Country_IdentificationCode = DataHelper.ReadString(dr, "Country_IdentificationCode");
            this._OrganizationID = DataHelper.ReadInt(dr, "OrganizationID");
            this._CompanyCode = DataHelper.ReadString(dr, "CompanyCode");
            this._FL_ACTIVE = DataHelper.ReadInt(dr, "FL_ACTIVE");
            this._ERPCustomerNo = DataHelper.ReadInt(dr, "ERPCustomerNo");
            this._LedgerCreator = DataHelper.ReadString(dr, "LedgerCreator");
            this._PartnerGb = DataHelper.ReadString(dr, "Alias");



        }

        #endregion

        #region Collection

        public List<cls_Partner> GetAll(System.Data.SqlClient.SqlConnection connection, GlobalEnum.FL_ACTIVE pFL_ACTIVE)
        {

            List<cls_Partner> PartnerList = new List<cls_Partner>();
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "Select * FROM Partner " + ((pFL_ACTIVE != GlobalEnum.FL_ACTIVE.ALL) ? "where FL_ACTIVE = @pFL_ACTIVE" : "");
                cmd.Parameters.AddWithValue("@pFL_ACTIVE", pFL_ACTIVE);
                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                {
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cls_Partner objPartner = new cls_Partner();
                            objPartner.TransferToClass(dr);
                            PartnerList.Add(objPartner);
                        }
                    }

                }
            }
            if (connection != null) connection.Close();
            return PartnerList;
        }

        public List<cls_Partner> GetAllList(System.Data.SqlClient.SqlConnection connection)
        {

            List<cls_Partner> PartnerList = new List<cls_Partner>();
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "Select * FROM Partner where FL_ACTIVE = 1";
                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                {
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cls_Partner objPartner = new cls_Partner();
                            objPartner.TransferToClass(dr);
                            PartnerList.Add(objPartner);
                        }
                    }

                }
            }
            if (connection != null) connection.Close();
            return PartnerList;
        }

        public List<cls_Partner> GetAllByModulId(System.Data.SqlClient.SqlConnection connection, int ModuleId)
        {
            List<cls_Partner> PartnerList = new List<cls_Partner>();

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = @" SELECT * FROM Partner WHERE FL_ACTIVE = 1 and VKN in ( SELECT distinct VKN_TCKN FROM PartnerModules WHERE ModuleId = @ModuleId )";
                cmd.Parameters.AddWithValue("@ModuleId", ModuleId);

                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                {
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cls_Partner objPartner = new cls_Partner();
                            objPartner.TransferToClass(dr);
                            PartnerList.Add(objPartner);
                        }
                    }

                }
            }
            if (connection != null) connection.Close();
            return PartnerList;
        }

        public List<cls_Partner> GetAllListNewPartner(System.Data.SqlClient.SqlConnection connection)
        {

            List<cls_Partner> PartnerList = new List<cls_Partner>();
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.CommandText = "SELECT TOP 1 * FROM Partner WHERE FL_ACTIVE = 1 ORDER BY PartnerID DESC";
                using (DataTable dt = DB_Gateway.ExecuteDataTable(cmd, connection))
                {
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            cls_Partner objPartner = new cls_Partner();
                            objPartner.TransferToClass(dr);
                            PartnerList.Add(objPartner);
                        }
                    }

                }
            }
            if (connection != null) connection.Close();
            return PartnerList;
        }
        #endregion
    }
}
