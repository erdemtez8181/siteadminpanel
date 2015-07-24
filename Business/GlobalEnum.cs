using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Siteyonetim.Framework.Business
{

    public class GlobalEnum
    {
        public enum DB_EXECUTE { FAIL };
        public enum DOCUMENTTYPE { IDOCV1 = 1, IDOCV2 = 2, IDOCV3 = 3 };
        public enum MSG_TYPE { SUCCESS, WARNING, ERROR, CRITICAL_ERROR, INFORM, FATAL };
        public enum FL_ACTIVE { PASSIVE = 0, ACTIVE = 1, ALL = -1 };
        public enum DocIdentityType { SYSTEMENVELOPE = 1, SENDERENVELOPE = 2, POSTBOXENVELOPE = 3 }
        public enum ElementType { APPLICATIONRESPONSE, INVOICE, POSTBOXENVELOPE, SYSTEMENVELOPE }
        public enum XMLType { Invoice = 1, Envelope = 2, ApplicationResponse = 3 };
        public enum APPROVAL_CODE { SISTEM = 1, MUTABAKAT = 2, INFORMATION = 3 };
        public enum CONNECTION_TYPE { WEBSERVICE = 2, RFC = 3, FTP = 4, FOLDER = 5, HTTPPOST = 6 };
        public enum USER_GROUP { ADMIN = 20, SADMIN = 2 };

        public enum TEST_GROUP { GBHATA = 1, GBPERFORMANS = 2, PKHATA = 3, PKPERFORMANS = 3 };
        public enum TEST_MADDE { MADDE1 = 1, MADDE2 = 2, MADDE3 = 3, MADDE4 = 4 };

        public enum EnvelopeStatus { ALL, NEW, INCORRECT, COMPLATED, PROCESSING };

        //public enum APPLICATIONRESPONSE_TYPE { SYSTEM = 1, KABUL = 2, RED = 3};

        public enum LedgerMoveType
        {
            Error,
            Info,
            Warning,
        }

        public enum PROCESS_FUNCTION
        {
            SPOOLCONVERT = 100
        }

        public enum LedgerActionType
        {
            DATA_INSERT_WEBSERVICE,
            DATA_INSERT_WEBSERVICE_CSV,
            CONVERT_LEDGER,
            BACKUP_LEDGER,
            SEND_FOLDER,
            SIGN_LEDGER,
            VALIDATE_LEDGER,
            DELETE_ACCOUNT,
            DELETE_LEDGER,
            CONVERT_PDF,
            EXPORT_CSV,
            EXPORT_XSLX,
            TIME_SPAN,
            SEND_BERAT_TOGIB,
            DOWNLOAD_LEDGER,
            CREATE_SEARCH_INDEX,
            DATA_SFS_SEND,
            LEDGER_DRAFT_CALCULATE,
        }

      
        #region GİB bilgileri
        public sealed class GIB
        {
            public const string Alias = "GIB";
            public const string VKN = "3900383669";
            public const string PartyName = "Gelirler İdaresi Başkanlığı";
            public const string ShorName = "GİB";
            public const Int64 DefaultTCKN = 11111111111;
            public const Int64 DefaultVKN = 9999999999;
            public const Int64 ExportVKN = 2222222222;
            public const string DefaultPartyName = "Beyan Edilmedi";
        }
        #endregion

        public sealed class Logging
        {
            public enum ObjectType
            {
                EnvelopeOrInvoice,
                Envelope,
                Invoice,
                Ledger,
                LettersPatent,
                Connection,
                Report,
                ApplicationResponse,
                Mail,
                Service,
                WebService,
                eArhive,
                eInvoice,
                eLedger,
                User,
                ParameterValue,
                Filter,
                FilterCriteria,
                Design,
                InvoiceServerFuction
            }
        }

        public enum STATUS_ERP
        {
            HATA = 10,
            YENI = 20,
            BULUNAMADI = 25,
            IPTAL = 30,
            ALINDI = 40,
            GIB_HATA = 50,
            TAMAMLANDI = 60,
            KABUL = 70,
            RED = 80,
            ARSIV = 90,
            SILINEBILIR = 100,
        };

        public enum STATUS_SERVER
        {
            HATA = -100,
            KAPALI = 0,
            KAPATILIYOR = 100,
            ACILIYOR = 190,
            CALISIYOR = 200,
        };

        public enum AppConfig
        {
            IsTest,
            IsEntegrator,
            HasSSO,
            HasDirectConnection,
            DisabledControls,
            EFATURA,
            EFATURA_UBL_TR_MAINDOC,
            TEST_FOLDER,
            OUTBOUND_UBL,
            OUTBOUND_FOLDER,
            STATUS,
            INBOX_ZIP,
            TEST_INBOX_ZIP,
            ZIP,
            TEMP,
            EDEFTER_TEMP,
            //EDEFTER_XSD,
            EDEFTER_XSLT,
            SHORT_TEMP,
            //TEMP_OUTPUT,
            INBOX_ENVELOPE,
            INBOX_INCORRECT_ZIP,
            MATCHES_DLL,
            LOG,
            EDEFTER_LOG,
            ISISLOG,
            WEB_SERVICELOG,
            ISISXSLT,
            TIMESPAN_SERVER_ADRES,
            TIMESPAN_USERPASS,
            TIMESPAN_USERID,
            TIMESPAN_USERNO,
            TIMESPAN_PORT,
            JAVAPATH,
            JAVA_PARAMS,
            CONSOLE_PROGRAM_NAME,
            CONSOLE_PROGRAM_NAME_XML_SIGNER,
            DELETE_ARCHIVED_LEDGER,
            IS_SAVE_LEDGER,
            EMAIL_SENDER_ADDRESS,
            EMAIL_RECEIVER_ADDRESS,
            EMAIL_PASSWORD,
            EMAIL_CC_ADDRESS,
            EMAIL_PORT,
            EMAIL_HOST,
            EMAIL_USING_SSL,
            EMAIL_USEDEFAULTCREDENTIALS,

            XML_VIEW_PAGESIZE,
            XML_VIEW_PAGEPART,
            XML_CHECK_TASK_COUNT_RUN_AT_A_TIME,
            XML_CHECK_DETAIL_COUNT_FOR_A_TASK,
            LEDGER_ARCHIVE_METHOD,
            PAGING_CACHE_TIME,
            UBLTR20TR1_TO_ISISTR_UBL20TR10,
            GENERALXSLT,
            ISISTR_UBL20TR10_TO_UBLTR20TR1,
            ISISTR_UBL20TR10_TO_UBLTR20TR1_XSL1
        };

        public enum STATUS_SPOOL { HATA = -100, YENI = 0, CONVERTED = 1, PROCESS_RED = 3 };

        public enum STATUS_PROCESS { NEW = 0, WAITING = 1, CONVERTED = 2 };

        public enum SYSTEM_MODE { TEST = 0, LIVE = 1 };

        public enum APPROVAL_STATUS { OTO = 1, MANUAL = 2, TIMEOUT = 3 };

        public enum ERP_TABLE_TYPE { RETURN = 1 };

        public enum SERVER_PARAMS { SRV_COUNT = 0, SRV_ADRESS = 1, HANDLE_SERVERID = 2 };

        public sealed class DefaultValues
        {
            /// <summary>
            /// 199 Mb defter boyutu
            /// </summary>
            public const int LedgerMaxXmlSize = 208666624;
            /// <summary>
            /// default Bayi No
            /// </summary>
            public const string batchID = "0000";
            public const string uniqueID = "YEV2011000000";

            public const string partNumber = "000000";
            /// <summary>
            /// Parça numarasını verilen uzunlukta karaktere tamamlak için kullaılır.
            /// </summary>
            public const int PartNumberPadSize = 6;

            /// <summary>
            /// csv dosyaları işlenirken batch input kayıt sayısı
            /// </summary>
            public const int csvBatchInputCount = 50000;

            public const string LedgerProgramVersion = "v1.0";
            public const string XbrlVersiyon = "v1.0";
            public const string LedgerFiscalYearStartDay = "01.01";
            public const string LedgerFiscalYearEndDay = "31.12";
            public const string LedgerFiscalYearStartYear = "0";
            public const string LedgerFiscalYearEndYear = "0";
            public const string VKN_ISIS = "4660392430";
            public const string LEDGER_CURRENCY = "try";
            public const string LEDGER_CURRENCY_ISO = "iso4217:TRY";
        }

        public sealed class System
        {
            public sealed class StatusMessage
            {
                public const string ZARF_BASARIYLA_ISLENDI = "Zarf başarıyla işlendi";
                public const string ZARF_KUYRUGA_EKLENDI = "Zarf kuyruğa eklendi";
                public const string ZARF_ISLENIYOR = "Zarf işleniyor";
                public const string ZARF_MEVCUT = "Zarf sistemde mevcut";
                public const string CEVAP_GONDERILDI = "Sistem yanıtı gönderildi";
                public const string GONDERILDI = "Gönderildi";
                public const string GONDERILDI_ERP = "ERP'ye gönderildi";
                public const string GONDERILECEK_ERP = "ERP'ye gönderilmek üzere kuyruğa eklendi";
                public const string CEVAP_TAMAMLANDI = "Cevap tamamlandı";
                public const string CEVAP_ALINDI = "Cevap alındı";
                public const string IMZALANDI = "İmzalandı";
                public const string TPS_IMZA_GECERSIZ = "İmza geçersiz";
                public const string IMZALAMA_HATASI = "İmzalama hatası";
                public const string HATA = "Bir hata oluştu";
                public const string TASLAK = "Taslak";
                public const string ONAYLANDI = "Onaylandı";
                public const string ONAY_ERP = "Kaynak sistemde onaylandı";
                public const string OTOMATIK_ONAYLANDI = "Otomatik onaylandı";
                public const string KABUL = "Fatura kabul edildi";
                public const string KABUL_ERP = "Kaynak sistemde kabul edildi";
                public const string KABUL_TICARI = "Ticari fatura kabul edildi";
                public const string KABUL_TICARI_CEVAPSIZ = "Ticari cevap gönderilmeden kabul sayıldı";
                public const string KABUL_TICARI_GONDERILDI = "Ticari fatura için kabul cevabı gönderildi";
                public const string RED_ERP = "Kaynak sistemde red edildi";
                public const string IPTAL_ERP = "Kaynak sistemde iptal edildi";
                public const string IPTALDEN_TASLAGA_TASINDI = "İptalden taslağa taşındı";
                public const string HATALIDAN_TASLAGA_TASINDI = "Hatalıdan taslağa taşındı";
                public const string OTOMATIK_IPTAL = "Otomatik iptal edildi";
                public const string IPTAL = "İptal edildi";
                public const string IPTAL_IADE = "İade faturası düzenlenecek";
                public const string RED_TICARI = "Ticari fatura red edildi";
                public const string RED_TICARI_CEVAPSIZ = "Ticari fatura kabul edilmiş sayıldığından iade edilmeli";
                public const string RED_TICARI_GONDERILDI = "Ticari fatura için red cevabı gönderildi";
                public const string BULUNAMADI_ERP = "Temel fatura kaynak sistemde bulunamadı";
                public const string ZARF_YENI = "Yeni zarf kaydedildi";
                public const string GIB_ILETISIM_HATASI = "Zarf denemeler sonunda GİB'e gönderilemediği için iptal edildi";
                public const string GIB_TICARI_ILETISIM_HATASI = "Zarf denemeler sonunda GİB'e gönderilemediği için ticari cevap iptal edildi";
                public const string ISLENDI = "İşlendi bilgisi girildi";
                public const string ISLENDI_ERP = "Kayna sistemden işlendi bilgisi geldi";
                public const string DUZENLENDI = "Fatura portalde düzenlendi";
                public const string ARSIV_KUYRUGUNDA = "Arşiv Kuyruğunda";
                public const string SISTEM_TARAFINDAN_ISLENMESI_BEKLENIYOR = " servis tarafından işlenmesi bekleniyor.";
                public const string EARSIVE_GONDERILDI = "e-Arşiv'e gönderildi.";
                public const string FATURA_GORUNTULENDI = "Fatura görüntülendi.";
            }

            public sealed class EnvelopeMessage
            {
                public const string ZARF_BASARI_ILE_ISLENDI = "ZARF BASARIYLA ISLENDI";
                public const string ZARF_BASARI_ILE_ALINDI = "ZARF BAŞARI İLE ALINDI";
            }

            public enum APPROVAL_STATUS { OTO = 1, MANUAL = 2, TIMEOUT = 3 };

        }


        #region ZARF İLETİŞİM KODLARI
        public enum INVOICE_STATUS_CODE
        {
            ///---------------------------------------------------------------------------------------------------------------------------
            TASLAK = 0,
            GONDERILDI = 1,
            ZARF_KUYRUGA_EKLENDI = 1000,
            ZARF_ISLENIYOR = 1100,
            HATALILAR_BASLANGIC = 1101,
            ZIP_DOSYASI_DEGIL = 1110,
            ZARF_ID_UZUNLUGU_GECERSIZ = 1111,
            ZARF_ARSIVDEN_KOPYALANAMADI = 1120,
            ZIP_ACILAMADI = 1130,
            ZIP_BIR_DOSYA_ICERMELI = 1131,
            XML_DOSYASI_DEGIL = 1132,
            ZARF_ID_VE_XML_DOSYASININ_ADI_AYNI_OLMALI = 1133,
            DOKUMAN_AYRISTIRILAMADI = 1140,
            ZARF_ID_YOK = 1141,
            ZARF_ID_VE_ZIP_DOSYASI_ADI_AYNI_OLMALI = 1142,
            GECERSIZ_VERSIYON = 1143,
            SCHEMATRON_KONTROL_SONUCU_HATALI = 1150,
            XML_SEMA_KONTROLUNDEN_GECEMEDI = 1160,
            IMZA_SAHIBI_TCKN_VKN_ALINAMADI = 1161,
            IMZA_KAYDEDILEMEDI = 1162,
            GONDERILEN_ZARF_SISTEMDE_DAHA_ONCE_KAYITLI_OLAN_BIR_FATURAYI_ICERMEKTEDIR = 1163,
            YETKI_KONTROL_EDILEMEDI = 1170,
            GONDERICI_BIRIM_YETKISI_YOK = 1171,
            POSTA_KUTUSU_YETKISI_YOK = 1172,
            IMZA_YETKISI_KONTROL_EDILEMEDI = 1175,
            IMZA_SAHIBI_YETKISIZ = 1176,
            TPS_IMZA_GECERSIZ = 1177,
            ADRES_KONTROL_EDILEMEDI = 1180,
            ADRES_BULUNAMADI = 1181,
            SISTEM_YANITI_HAZIRLANAMADI = 1190,
            SISTEM_HATASI = 1195,
            HATALILAR_BITIS = 1199,
            ZARF_BASARIYLA_ISLENDI = 1200,
            DOKUMAN_BULUNAN_ADRESE_GONDERILEMEDI = 1210,
            DOKUMAN_GONDERIMI_BASARISIZ_TERKAR_GONDERME_SONLANDI = 1215,
            HEDEFTEN_SISTEM_YANITI_GELMEDI = 1220,
            HEDEFTEN_SISTEM_YANITI_BASARISIZ_GELDI = 1230,
            BASARIYLA_TAMAMLANDI = 1300,
            KABUL = 97000,
            RED = 97010,
            //FATURANIN_KABUL_OLMA_DURUMU = "KABUL",
            //FATURANIN_RED_OLMA_DURUMU = "RED",
            //FATURANIN_IADE_OLMA_DURUMU = "IADE",
            //SYSTEM_APPLICATION_RESPONSE = "S_APR",
            ///---------------------------------------------------------------------------------------------------------------------------

        };
        #endregion

        #region SİSTEM KODLARI
        public enum SYSTEM
        {
            HATA = -100,
            TASLAK = 99000,
            MUTABAKAT_ONAYI_BEKLENIYOR = 99010,
            MUTABAKAT_ONAYI = 99020,
            MUTABAKAT_RED = 99030,
            ONAY = 99040,
            TICARI_CEVAPSIZ_KABUL = 99045,
            IMZALI = 99050,
            IPTAL = 99060,
            TICARI_CEVAPSIZ_IPTAL = 99065,
            GONDERILDI = 99070,
            CEVAP_GONDERILDI = 99080,
            CEVAP_ALINDI = 99090,
            CEVAP_TAMAMLANDI = 99100,
            RED_CEVABI_GONDERILDI = 99105,    //TICARI_RED_CEVABI_GONDERILDI
            RED = 99110,    //TICARI_RED
            KABUL_CEVABI_GONDERILDI = 99115,  //TICARI_KABUL_CEVABI_GONDERILDI
            KABUL = 99120,  //TICARI_KABUL
            ERP_GONDERIM_KUYRUGUNDA = 99230,
            ERP_GONDERILDI = 99240,
            ARSIV_KUYRUGUNDA = 99250,
            ARSIV = 99260,
            AYRISTIRILIYOR = 99500,
            ANALIZEDILIYOR = 99550,
            GIDEN_ARSIVLENIYOR = 99600,
            GELEN_ARSIVLENIYOR = 99610,
            //BASARIYLA_TAMAMLANDI = 99105,

            DEFTEROLUSTUR = 10,
            KEBIROLUSTUR = 15,
            DEFTERNUMARALANDIR = 17,
            DEFTERSIL = 20,
            DEFTERDAMGALA = 25,
            DEFTER_ZAMAN_DAMGASI = 28,
            DEFTER_VALIDASYON = 29,
            DEFTER_ONAY = 30,
            DEFTER_ARSIV = 40,
            NOTCOMPLETED = -999,
            EXPORT_EXCEL = 9999999,
            EXPORT_PDF = 9999998,
            EXPORT_XLSX = 9999997,
            EXPORT_CSV = 9999996,
            LEDGER_CONTROL = 9999995,
            LEDGER_FILE_BACKUP = 9999994,
            LEDGER_DRAFT_CALCULATE = 9999993,
            LEDGER_TO_GIB_UPLOAD = 100,
            LEDGER_FROM_GIB_DOWNLOAD = 110,
            LEDGER_TO_ERP_UPLOAD = 120,

        }
        #endregion

        #region Partner Parameters
        public enum PARTNER_PARAMETERS
        {
            #region general
            FATURA_NOTLARI = 167,
            GENERAL_XSLT = 168,
            ARCHIVEDB = 169,
            //LICENCE_KEY = 170,
            LICENCE_PRIVATE_KEY = 171,
            LISTENER_VERSIYON = 172,
            PORTAL_VERSIYON = 173,
            LOG_DB_CONNECTION_STR = 174,
            DB_CONNECTION_STR = 175,
            ARCHIVE_DB_CONNECTION_STR = 176,
            BACKUPLOCATION = 177,
            //CERTIFICATE = 178,
            //CERTIFICATE_SERIAL = 179,
            //KEY_CONTAINER = 180,
            KEY_CONTAINER_PASS = 181,
            FTP_ADRESS = 182,
            FTP_USER = 183,
            FTP_PASSWORD = 184,
            LISTENER_FOLDER = 185,
            LISTENER_STATUS = 186,
            SRV_COUNT = 187,
            SRV_ADRESS = 188,
            SRV_STATUS = 189,
            OTO_APPROVAL = 190,
            INVOICE_ORDER_NO = 191,
            FTP_INVOICE_OBJECT = 192,
            XSD_INVOIC02_PATH = 193,
            XSD_APPRESPONSE_PATH = 194,
            XSD_XADES_PATH = 195,
            XSD_ENVELOPE_PATH = 196,
            XSD_INVOICE_PATH = 197,
            XSD_WITHOUT_SIGNATURE_PATH = 502,
            APPLICATION_RESPONSE_ORDER_NO = 198,
            BACKUP_TIME = 199,
            BACKUP_FREKANS = 200,
            BACKUP_FOLDER = 201,
            BACKUP_DAY = 202,
            //temel fatura onayının opsiyonel yapılması
            ApproveBasicInvoice = 203,
            WORK_FOLDER = 212,
            XLS_CODELIST = 213,
            XLS_APPLICATION_RESPONSE = 214,
            UNZIP_FOLDER = 215,
            TEMP_FOLDER = 216,
            APPROVAL_INVOICE = 217,
            OUTBOX_INVOICE = 218,
            OUTBOX_ENVELOPE = 219,
            OUTBOX_ZIP = 220,
            STORE_FOLDER = 221,
            //DB_PATH = 222,
            //DB_LOG_PATH = 223,
            //ARCHIVEDB_PATH = 224,
            ELEDGER_BATCH_LIST = 225,
            TEST_ENVELOPE = 226,
            SYSTEM_MODE = 227,
            TEST_INVOICE = 228,
            CERTIFICATE_PATH = 229,
            XSLT_UBL_VALIDATE = 230,
            ADDITIONAL_DOCUMENT_ORDER = 231,
            ARCHIVE_DATE = 234,
            ARCHIVE_START_TIME = 235,
            ARCHIVE_END_TIME = 236,
            ARCHIVE_DAY_RANGE = 237,
            ARCHIVE_OLDER_THAN = 238,
            ARCHIVE_RUNNING = 239,
            ARCHIVE_DELAY = 240,
            FTP_BILGILERI = 241,
            KLASOR_BILGILERI = 242,
            YEDEKLEME_BILGILERI = 243,
            ONAY_BILGILERI = 244,
            SERTIFIKA_BILGILERI = 245,
            VERSIYON_BILGILERI = 246,
            LISANS_BILGILERI = 247,
            ISLEM_PARAMETRELERI = 248,
            ARCHIVE_BILGILERI = 249,
            INVOICE_SEND_WAITING_TIME = 250,
            LAST_INVOICE_SEND_DATE = 253,
            TOKEN_ORDER = 254,
            TOKEN_NAME = 255,
            PORTALADRES = 256,
            ENVELOPE_INVOICE_COUNT = 257,
            TEST_VKN = 258,
            BAD_FILES_FOLDER = 259,
            INVOICE_SERVER_WCFPORT = 260,
            ERP_STATUS_FOLDER = 261,
            INVOICE_CLIENT_ID = 262,
            TOKEN_SERIAL = 263,
            TOKEN_WEB_SERVICE = 264,
            FUNCTION_OUT_FOLDER = 270,
            INBOX_INVOICE = 271,
            INBOX_ENVELOPE = 272,
            INBOX_ZIP = 273,
            ARCHIVE_FOLDER = 276,
            GIB_ENDPOINT_ADDRESS = 279,
            EDIT_ERP_INVOICE = 280,
            SYSTEM_MAIL_DESCRIPTIONS = 281,
            SYSTEM_ADMIN_MAIL = 282,
            XSD_LEDGER = 283,
            XSLT_JOURNAL_LEDGER = 284,
            XSLT_GENERAL_LEDGER = 285,
            XSLT_LEDGER_PATENT = 286,
            SCH_JOURNAL_LEDGER = 287,
            SCH_GENERAL_LEDGER = 288,
            SCH_LEDGER_PATENT = 289,
            END_OF_THE_PERIOD = 290,    //muhasabe dönem kapanış günü. default 0, yok.
            END_OF_THE_RESPONSE = 291,    //Faturanın sistemimize ulaşmasından (recorddate) itabiren en fazla kaç saat sonra cevap verilebilir. default 24 * 8 - 1.

            IS_HASH_SIGN = 292,
            LEDGER_MAX_XML_SIZE = 293,
            LEDGER_XSLT_FOLDER = 308,

            EMAIL_SENDER_ADDRESS = 331,
            EMAIL_PASSWORD = 332,
            EMAIL_CC_ADDRESS = 333,
            EMAIL_COMBINE = 334,                //Mailleri birleştir
            EMAIL_PORT = 335,
            EMAIL_HOST = 336,
            EMAIL_USING_SSL = 337,              //SSL Kullanımı
            EMAIL_USEDEFAULTCREDENTIALS = 390,  //Sunucu Kimlik Doğrulama

            LEDGER_ARCHIVE_FOLDER_PATH = 338,
            LEDGER_ARCHIVE_METHOD = 339,
            LEDGER_IS_DELETE_ARCHIVED_LEDGER = 340,
            LEDGER_AUTO_DELETE_APPROVED_FOR_ERP = 341,
            LEDGER_EXPORT_CSV_ROW_SIZE = 342,

            IS_CONTROL_DRAFT = 343,
            IS_PREVIOS_LEDGER_KONTROL = 344,
            IS_SET_YEVMIYE_NO = 345,
            IS_VALIDATE_LEDGER = 346,
            ORGANIZATION_CODE = 347,
            IS_VALIDATE_JOURNAL = 348,
            IS_SAVE_GIB_SOAP_MESSAGE = 349,
            IS_SEND_GIB_SOAP_MESSAGE = 351,

            LEDGER_DOWNLOAD_FOLDER = 350,

            DEFAULT_VKN_CONNECTION_STRING = 352,
            CONNECTORPATH = 355,
            CMTY_ISISXML = 356,
            CMTY_ISISSTATUSXML = 357,
            CMTY_ENVELOPE = 358,
            CMTY_UBL_OSP = 359,
            CMTY_STATU_OSP = 360,
            IS_ANSI_TO_UTF8_IN_CSVPARSER = 361,
            STANDART_KABUL_MESAJI = 362,
            STANDART_RED_MESAJI = 363,
            TEMEL_ONAY_MESAJI = 364,
            APPROVAL_MAIL_DAY = 365,
            CMTY_UBL_IN_ISISTR = 367,
            PORTAL_LINKI = 368,
            SIRKET_ADI = 369,
            LINK_TOKEN = 370,
            WEB_SERVICE_PASS = 371,
            LINK_LIFE_TIME = 372,
            PASSWORD_LIFE_TIME = 373,
            OLD_PASSWORD_COUNT = 374,
            WEB_SERVICE_IP_FILTER = 375,
            PASSWORD_MIN_LENGTH = 376,
            LEDGER_CLEAN_NONUTF8_REGEX_FILTER = 377,

            //-appconfigten aktarılanlar 
            SHORT_TEMP = 309,
            IS_LEDGER_SEND_DAILY = 310,
            LEDGER_APROVAL_IS_TIMESPAN = 311,

            IS_SEND_STATUSTOERP_PERFILE = 400,
            XSD_LEDGER_FILE_PATH = 401,
            LEDGER_CONVERT_PDF_AUTO = 402,
            WINDOWS_SERVICE_TCP_PORT = 403,
            LEDGER_MAX_TASK_COUNT = 404,
            LEDGER_START_DATE = 405,
            TOKEN_LOCAL_SIGN = 426,
            LEDGER_CURRENCY = 429,
            LEDGER_CURRENCY_ISO = 430,
            LEDGER_PERIOD_START_END_DAYS = 431,
            TOKEN_PUK = 222,

            #endregion

            #region eledger
            IS_LEDGER_POOLER_MODE = 406,
            LEDGER_GIB_WEBSERVICE_TIMEOUT_MINUTE = 407,
            LEDGER_IS_AUTO_CONVERT = 408,
            LEDGER_IS_AUTO_EXCEL_EXPORT = 409,
            LEDGER_IS_TIMESPAN_ON_SIGNTIME = 410,
            LEDGER_IS_VALIDATE_ON_SIGNTIME = 411,
            LEDGER_CHECK_PREVIOUS_CYCLE_PERMISSION_STATUS = 412,     //defterin bir önceki ayının çevrim izni statüsü
            LEDGER_CONVERT_DAY_COUNT = 413,
            LEDGER_FILE_LISTER_SOURCEPATH = 414,
            LEDGER_FILE_LISTER_DESTINATION = 415,
            LEDGER_FILE_LISTER_PARSERCLASS = 416,
            LEDGER_DELETE_FILE_TYPES = 417, //Örnek Kullanım: IMPORT_CSV,IMPORT_CSV_FTP,EXPORT_CSV,EXPORT_XLSX,XBRL_PDF,IMPORT_BERAT,LEDGER_CONTROL,LEDGER_WARNING
            LEDGER_CSV_BATCH_INPUT_COUNT = 418,
            LEDGER_IS_PATENT_AUTO_UPLOAD = 419,
            LEDGER_GIB_ELEDGER_SERVICE_URL = 420,
            LEDGER_SEND_DATA_TO_CUSTOMER_FOLDER_PATH = 421,
            LEDGER_FISCALYEAR_START_DAY = 422,
            LEDGER_FISCALYEAR_END_DAY = 423,
            IS_DONT_DELETE_INSERSECTING_DATE_IMPORT_DATA = 424,
            LEDGER_MAIL_REMAINING_WAIT_DAY_COUNT = 425,
            LEDGER_ACCURAL_LEDGER_SIZE = 427,
            LEDGER_BATCH_CONTROL = 428,

            IS_SPECIAL_PERIOD = 432,
            IS_DATA_ANALYSIS = 433,
            BACKUP_FOLDER_PATH = 434,
            ERPUPLOAD_LAST_ERP_UPLOAD_STATUS = 435,
            LEDGER_ERP_SEND_FOLDER = 436,
            IS_SEND_LEDGER_ERP = 437,
            IS_SEND_STATU_ERP = 438,
            LEDGER_DOWNLOAD_FILE_TYPES = 439,
            LEDGER_PAGING_SIZE = 441,
            LEDGER_CALCULATE_NOW = 442,
            IS_CREATE_SEARCH_INDEX = 443,
            IS_SFS_SEND = 444,

            #endregion

            #region earchive
            EARCHIVE_XSD_PATH = 450,
            EARCHIVE_ENDPOINT_ADDRESS = 451,
            EARCHIVE_CREATE_PDF = 452,
            EMAIL_FILETYPE = 453,
            PREPARE_REPORT_DAYS_BEFORE = 454,
            EARCHIVE_ENDPOINT_PASSWORD = 455,
            #endregion

            #region Entegratör parametreleri
            ENTEGRATOR_VKN = 520,
            #endregion
        }
        #endregion

        public enum ApplicationType
        {
            FILE,
            DIRECTORY,
            STRING,
            DBCONNECTIONSTR,
        }
        public enum AttachmentType
        {
            Additional,
            Order,
            Despatch,
            Receipt,
        }
        public enum Direction
        {
            Inbound = 1,
            Outbound = 2,
            All = 3
        }

        public enum ERP_XMLType { IDOC = 1, EDI96A = 2 };

        public enum PROFILEID { TEMELFATURA = 1, TICARIFATURA = 2 };

        public enum INVOICE_OBJECT_TYPE { INVOIC02 = 1, ZIEF_INVOIC02 = 2, AxisFatura1_0 = 3 };

        public enum UBLTRPART { HEADER = 1, ITEM = 2, TAX = 3 };

        public enum INVOICE_TYPE_CODE { SATIS = 1, IADE = 2 };
        public enum COMMERCIAL_RESPONSE { KABUL, RED };

        public enum CODE_LIST_TYPE
        {
            UnitCode = 1,
            CurrencyCode = 2,
            LanguageCode = 3,
            MIMEMediaTypeCode = 4
        };

        public enum FUNCTIONS
        {
            RFC_SERVER = 1,
        };

        public enum SYSTEM_USERS
        {
            SERVICE = 1,
            TEST = 2,
            WEBSERVICE = 3,
            ERP = 4
        };

        public enum CR_LOCK_FUNCTION { USER = 1, RECORD = 2, };

        public enum ledgerType
        {
            all = -1,
            journal = 1,
            ledger = 2,
            lettersPatent = 3,
        }

        public enum entriesType
        {
            none,
            account,//: information to fill in a chart of accounts file.  
            balance,//: the results of accumulation of a complete and validated list of entries for an account (or a list of account) in a specific period - sometimes called general ledger  
            entries,//:  a list of individual accounting entries, which might be posted/validated or nonposted/validated   
            journal,//: a self-balancing (Dr = Cr) list of entries for a specific period including beginning balance for that period.  
            ledger,//: a complete list of entries for a specific account (or list of accounts) for a specific period; note - debits do not have to equal credits.   
            assets,//: a listing of open receivables, payables, inventory, fixed assets or other information that can be extracted from but are not necessarily included as part of a journal entry.  
            trialBalance,//: the self-balancing (Dr = Cr) result of accumulation of a complete and validated list of entries for the entity in a complete list of accounts in a specific period.
            taxtables,//:  aids automated interpretation of instances that represent tax tables; Tax table are defined by using multiple [taxes] structures to gather the population of codes, authorities and rates; through [taxTableCode] cross-references in the [taxes] structure, these "master file" tax tables can be referenced.
            //Often sorted by date or by account, these terms have specific, and sometimes different, meanings in different areas. Common practice will drive accounting method/term matches.
        }


        public const string ServerWCFBaseAddress = "net.tcp://localhost:80{0}/{1}/";
        public const string DEFAULT_INVOICE_TYPE_CODE = "NONE";


        public enum LedgerGibStatus
        {
            HATA = -1,
            YENI = 40,
            GONDERILIYOR = 50,
            GONDERILDI = 400,
            GIBDENINDIRILDI = 500,
            TAMAMLANDI = 1100,

            //sendDocumentFile
            ERISIM_YETKILENDIRME_HATASI_SDF = 101,
            KULLANICININ_ILGILI_ROLU_YOK_SDF = 102,
            ATTACHMENT_NULL = 103,
            PAKET_ADI_BOS = 104,
            PAKETIN_ICERIGI_BOS = 105,
            PAKETIN_MAKSIMUM_BOYUTU_GECMIS = 106,
            DATAHANDLER_HATASI = 107,
            PAKETI_GONDERENIN_KULLANICI_KIMLIGI_ILE_SISTEMDEKI_KULLANICININ_KIMLIGI_UYUSMUYOR = 109,
            VERITABANI_HATASI_SDF = 110,
            PAKET_SISTEME_DAHA_ONCE_YUKLENMIS = 111,
            DISK_HATASI_SDF = 112,
            ISLEM_KUYRUGU_HATASI = 113,

            //receiveDocumentFile
            ERISIM_YETKILENDIRME_HATASI = 201,
            KULLANICININ_ILGILI_ROLU_YOK_RDF = 202,
            VERITABANI_HATASI_RDF = 203,
            PAKET_ADI_GECERLI_DEGIL_RDF = 204,
            GIB_ONAYLI_BERAT_INDIRMEK_ISTEYEN_KULLANICI_ILE_PAKETI_YUKLEYEN_KULLANICI_TUTARSIZ = 205,
            DISK_HATASI_RDF = 206,

            //getBatchStatus
            ERISIM_YETKILENDIRME_HATASI_GBS = 301,
            KULLANICININ_ILGILI_ROLU_YOK_GBS = 302,
            VERITABANI_HATASI_GBS = 303,
            PAKET_ADI_GECERLI_DEGIL_GBS = 304,
            PAKETI_DURUMUNU_SORGULAMAK_ISTEYEN_KULLANICI_ILE_PAKETI_YUKLEYEN_KULLANICI_TUTARSIZ = 305,
        }

        public enum LedgerStatus
        {
            NONE = 0,

            CANCELLATION_ERROR = -5,
            HATA = -100,
            ISLENIYOR = 10,
            KEBIROLUSTUR = 20,
            NUMARALANDIR = 30,

            YENI = 40,
            DEFTEROLUSTUR = 100,
            VALIDASYON = 150,
            ONAYLANIYOR = 170,
            ONAY = 200,
            ZIPLENDI = 400,
            TIME_STAMP = 500,
            INDIRILDI = 600,
            GIBONAYI = 1000,
            TAMAMLANDI = 1100,
            ARSIV = 1200,
            INCLUDE_ARSIV = 1300

        }

        public enum MapObjectParameters
        {
            XPATH = 1,
        }

        public enum Modul
        {
            None = 0,
            EInvoice = 10,
            ELedger = 20,
            ETicket = 30,
            EArchive = 40,
        }

        public enum TimeStampCommand
        {
            Stamp = 'Z',
            CheckTimeStamp = 'C',
            QueryCustomerCredit = 'K',
        };

        // burada yapılan değişiklik , services eledger tarafında da yapılmadılıdır.   
        public sealed class ledgerDocumentTypeCode
        {
            public const string JournalLedger = "Y";
            public const string GeneralLedger = "K";
            public const string JournalLedgerPatent = "YB";
            public const string GeneralLedgerPatent = "KB";

        }

        public sealed class ConnectionCode
        {
            public const string FTP = "FTP";
            public const string WEBSERVICE = "WEBSERVICE";
            public const string RFC = "RFC";
            public const string FOLDER = "FOLDER";
            public const string HTTPPOST = "HTTPPOST";
            public const string DEFAULT_PORTAL_VKN = "EPORTAL";
            public const string DEFAULT_ENTEGRATOR_VKN = "ENTEGRATOR";
        }

        public sealed class SystemConnectionTypeCode
        {
            public const string TO_ERP_CON = "TOERPCON";
            public const string TO_ERP_CON_STATUS = "TOERPCONSTATUS";
            public const string TO_GIB_CON = "TOGIBCON";

        }

        public sealed class ExtentsionIn
        {
            public const string SEARCH_FIELD = "SEARCH_FIELD";
            public const string ADDITIONAL_FIELD = "ADDITIONAL_FIELD";

        }

        public sealed class FilterGroupCode
        {
            //FilterGroupCode için sabitler
            public const string StaticJobPositionCode = "FATURA_DAGITICI";
            public const string StaticApprovalHieararcyCode = "FATURA_DAGITICI_HY";

            //Tüm faturalar için FilterGroupCode
            public const string IsAutoApproval = "IsAutoApproval";
            public const string ApprovalHieararcyCode = "ApprovalHieararcyCode";
            //exta veri; faturayı onaylaması beklenen iş posizyonu
            public const string JobPositionCode = "JobPositionCode";
            public const string ADDITIONAL_FIELD = "ADDITIONAL_FIELD";
            public const string SEARCH_FIELD = "SEARCH_FIELD";

            //Giden faturalar için FilterGroupCode
            public const string Alias = "Alias";
            public const string SenderAlias = "SenderAlias";
            public const string CopyIndicator = "CopyIndicator";
            public const string InvoiceTypeCode = "InvoiceTypeCode";
            public const string ProfileID = "ProfileID";
            public const string InvoiceDesignCode = "InvoiceDesignCode";
            public const string InvoicePrefixCode = "InvoicePrefixCode";
            public const string ReturnMessageTypeCode = "ReturnMessageTypeCode";
            public const string EArchiveType = "EArchiveType";

            public const string ModulCode = "ModulCode";
            public const string ReferenceNo = "ReferenceNo";
            public const string ReferenceDocumentTypeCode = "ReferenceDocumentTypeCode";

            //Gelen faturalar için FilterGroupCode
            public const string ConnectionSettingCode = "ConnectionSettingCode";
        }

        public sealed class ConnectorSetting
        {
            public ConnectorSetting(string connectorPath)
            {
                this.ConnectorPath = connectorPath;
            }
            public string ConnectorPath { get; set; }
            public string IsisStatusXmlListener { get { return ConnectorPath + "IsisStatusXmlListener.svc"; } }
            public string IsisTaxPayerQuery { get { return ConnectorPath + "IsisTaxPayerQuery.svc"; } }
            public string IsisUblTrListener { get { return ConnectorPath + "IsisUblTrListener.svc"; } }
            public string IsisXmlListener { get { return ConnectorPath + "IsisXmlListener.svc"; } }
            public string IsisLegacyUblTrListener { get { return ConnectorPath + "IsisLegacyUblTrListener.svc"; } }
            public string CustomXmlListener { get { return ConnectorPath + "CustomXmlListener.svc"; } }
            /// <summary>
            /// Portalden GİB'e gönderilmek üzere connectöre gönderilen zarfları alır
            /// </summary>
            public string IsisGIBToPortal { get { return ConnectorPath + "IsisGIBToPortal.svc"; } }
            public string IsisPortalToGib { get { return ConnectorPath + "IsisPortalToGib.svc"; } }
        }

        public sealed class IsAutoApproval
        {
            //FilterGroupCode için sabitler
            public const string Accept = "A"; //kabul
            public const string Cancel = "C"; //iptal
            public const string Wait = "W"; //beklet
        }

        public sealed class ERPIsAutoSend
        {
            //FilterGroupCode için sabitler
            public const string Imdlty = "I"; //Hemen
            public const string After = "A"; //Onay sonrası
            public const string Sign = "S"; //İmza sonrası
            public const string Wait = "W"; //beklet
        }

        public enum NoteType
        {
            /// <summary>
            /// Default Notlar
            /// </summary>
            D,
            /// <summary>
            /// Seçilebilecek Notlar
            /// </summary>
            K,
            /// <summary>
            /// Vergi İstisna Sebebi
            /// </summary>
            V,
        };

        public sealed class StatusXML
        {
            public sealed class Direction
            {
                public static string OutboundInvoice = "1";
                public static string InboundInvoice = "2";
            }

            public sealed class Type
            {
                public static string Query = "Q";
                public static string Status = "S";
                public static string Command = "C";
                public static string Response = "R";
            }

            public sealed class Status
            {
                public const string YENI = "00";
                //UBL-TR Dönüştürmede hata
                public const string UBLTR_DONUSUMUNDE_HATA = "10";
                //ISIS e-Portale Veri Gönderildi
                public const string PORTALE_VERI_GONDERILDI = "20";
                public const string GIB_ILETIM_HATASI = "25";
                public const string PORTALDEN_IPTAL_EDILDI = "30";
                public const string PORTALDEN_ONAYLANDI = "32";
                public const string GIB_ILETILDI = "35";
                public const string GIB_ALINDI_BILGISI = "40";
                public const string GIB_HATALI_BILGISI_GELDI = "50";
                public const string BASARIYLA_TAMAMLANDI = "60";
                public const string KABUL_BILGISI_GELDI = "70";
                public const string TICARI_CEVAPSIZ_KABUL = "71";
                public const string RED_BILGISI_GELDI = "80";
                public const string TICARI_CEVAPSIZ_IPTAL = "81";
                public const string MUHASEBELESTI = "85";
                public const string ARSIVLENDI = "90";
            }
        }

        public sealed class StaticXmlFormats
        {

            public enum StatusMessageTypes
            {
                CMTY_ISISTRSTATUSXML,
                CMTY_APPLICATION_RESPONSE
            }

            public enum InvoiceMessageTypes
            {
                CMTY_ISISTRXML,
                CMTY_UBL
            }
        }

        public enum INVOICE_SERVER_FUNCTION
        {
            APPROVAL_TRACKER = 1,
            ERP_INBOX_SENDER = 2,
            ERP_OUTBOX_SPOOL_CONVERTER = 3,
            ERP_SEND_INBOX_INVOICE = 4,
            ERP_SEND_OUTBOX_STATUS = 5,
            FOLDER_SPOOL_CONVERTER = 6,
            FTP = 7,
            GIB_TEST = 8,
            INBOX_APPRESPONSE_SENDER = 10,
            INBOX_ARCHIVE_TRACKER = 11,
            INBOX_ENVELOPE_SEPERATOR = 12,
            MUTABAKAT_MAIL_SENDER = 13,
            OUTBOX_APPRESPONSE_SENDER = 14,
            OUTBOX_ARCHIVE_TRACKER = 15,
            OUTBOX_INVOICE_SENDER = 16,
            OUTBOX_SPOOL_CONVERTER = 17,
            RFCCLIENT = 18,
            RFCSERVER = 19,
            TICARI_APPRESPONSE_SENDER = 20,
            TICARIFATURA_SEND_RESPONSE = 21,
            BACKUP = 22,
            OTO_ARCHIVE = 23,
        }

        /// <summary>
        /// 
        /// </summary>
        public sealed class WindowsServices
        {
            public const string MailPooler = "MailPooler";
            public const string ApprovalMailPooler = "ApprovalMailPooler";
            public const string TaskPooler = "TaskPooler";
            public const string ResendOutboundEnvelope = "ResendOutboundEnvelope";
            public const string SignDraftInvoicePooler = "SignDraftInvoicePooler";
            public const string InvoiceToEnvelopePooler = "InvoiceToEnvelopePooler";
            public const string SendEnvelopeGIBPooler = "SendEnvelopeGIBPooler";
            public const string SendStatusToERPPooler = "SendStatusToERPPooler";
            public const string SendInboundStatusToERPPooler = "SendInboundStatusToERPPooler";
            public const string SendUblToERPPooler = "SendUblToERPPooler";
            public const string GetApplicationResponsePooler = "GetApplicationResponsePooler";
            public const string GIBChecker = "GIBChecker";
            public const string ApprovalInboundInvoicePooler = "ApprovalInboundInvoicePooler";
            public const string ApprovalOutboundInvoicePooler = "ApprovalOutboundInvoicePooler";
            public const string SendInboundInvoiceToERPPooler = "SendInboundInvoiceToERPPooler";
            public const string GetTaxPayerListPooler = "GetTaxPayerListPooler";
            public const string GetEntegratorApplicationResponsePooler = "GetEntegratorApplicationResponsePooler";
            public const string EnvelopePooler = "EnvelopePooler";
            public const string SendInboundUblToERPPooler = "SendInboundUblToERPPooler";
            public const string ArchivePooler = "ArchivePooler";
            public const string LedgerRemindeMailPooler = "LedgerRemindeMailPooler";

            #region e-Defter
            public const string ApprovalLedgerPooler = "ApprovalLedgerPooler";
            public const string LedgerValidatePooler = "LedgerValidatePooler";
            public const string LedgerImportCsvPooler = "LedgerImportCsvPooler";
            public const string LedgerConvertPooler = "LedgerConvertPooler";

            public const string XBRLPdfConverterPooler = "XBRLPdfConverterPooler";
            public const string LedgerExportToExcelPooler = "LedgerExportToExcelPooler";
            public const string LedgerExportToCsvPooler = "LedgerExportToCsvPooler";
            public const string LedgerTimeSpanPooler = "LedgerTimeSpanPooler";
            public const string LedgerImportBeratPooler = "LedgerImportBeratPooler";
            public const string LedgerSemaControlPooler = "LedgerSemaControlPooler";
            public const string LedgerKebirPooler = "LedgerKebirPooler";
            public const string LedgerUniqueIdUpdatePooler = "LedgerUniqueIdUpdatePooler";
            public const string LedgerFileListenerPooler = "LedgerFileListenerPooler";
            public const string LedgerControlPooler = "LedgerControlPooler";
            public const string LedgerPatentToGibUploaderPooler = "LedgerPatentToGibUploaderPooler";
            public const string LedgerPatentFromGibDownloaderPooler = "LedgerPatentFromGibDownloaderPooler";
            public const string LedgerPatentToERPUploaderPooler = "LedgerPatentToERPUploaderPooler";
            public const string LedgerGarbageCollectorPooler = "LedgerGarbageCollectorPooler";
            public const string LedgerFileListenerCsvToXbrlPooler = "LedgerFileListenerCsvToXbrlPooler";

            public const string LedgerFileBackupPooler = "LedgerFileBackupPooler";
            public const string LedgerERPUploaderPooler = "LedgerERPUploaderPooler";
            public const string LedgerERPStatusUploaderPooler = "LedgerERPStatusUploaderPooler";
            public const string LedgerImportDirectXbrlPooler = "LedgerImportDirectXbrlPooler";



            #endregion

            public sealed class EArchive
            {
                public const string TaskPooler = "EArchive.TaskPooler";
            }
            public sealed class Eledger
            {
                public const string TaskPooler = "Eledger.TaskPooler";
            }

        }

        #region Mail
        public sealed class Mail
        {
            public sealed class Status
            {
                public const string New = "N";
                public const string Sended = "S";
                public const string Error = "E";
            }
            public sealed class Type
            {
                public const string Info = "I";
                public const string Warning = "W";
                public const string Error = "E";

            }
        }
        #endregion

        #region Entegrator
        public sealed class Partner
        {
            public sealed class RoleType
            {
                public const string GB = "GB";
                public const string PK = "PK";
                public const string AR = "AR";
                public const string EA = "EA";
                public const string GBName = "Gönderici Birim";
                public const string PKName = "Posta Kutusu";
                public const string ARName = "Arşiv";
                public const string EAName = "E-Arşiv";
            }

            public sealed class UserOptionCode
            {
                public const string Kamu = "1";
                public const string KamuName = "Kamu";
                public const string Ozel = "2";
                public const string OzelName = "Özel";

                //Sadece fatura saklama için
                public const string SaveKamu = "11";
                public const string SaveKamuName = "Fatura Saklama Kamu";
                public const string SaveOzel = "12";
                public const string SaveOzelName = "Fatura Saklama Özel";

            }

            public enum AliasType
            {
                ENTEGRATOR = 0,
                OZELENTEGRATOR = 1,
                BARINDIRMA = 2,
                EARSIV,
                OZELENTEGRATOR_SILME = 3,
                BARINDIRMA_SILME = 4,
                ENTEGRATOR_SILME = 5,
                EARSIV_SILME
            }

            public enum AccountType
            {
                ALL = 0,
                FORREGISTER = 1,
                FORUNREGISTER = 2
            }

            public sealed class Type
            {
                public const string REGISTER = "PROCESSUSERACCOUNT";
                public const string UNREGISTER = "CANCELUSERACCOUNT";
            }

            public enum Identifier
            {
                usergb,
                archive,
                earchive
            }
        }
        #endregion

        public sealed class StaticConnectionSettingCode
        {
            public const string GetTaxPayerList = "CSET_GIB_ISISTAXPAYERQUERY";
            public const string GetApplicationResponse = "CSET_GIB_APPLICATIONRESPONSE";
        }

        public enum InterventionLevel
        {
            Info = 0,
            User = 1,
            TechnicalUser = 2,
            Developer = 3
        }

        public enum ERPNOT_TYPE
        {
            BANKA1 = 1,
            BANKA2 = 2,
            SABIT_NOT = 3,
            ODEME_NOTU = 4,
            MONTAJ_BEDELI_DAHILDIR = 5,
            IHRACAT_KAYIT_NOTU = 6,
            NOT = 7,
        };

        public sealed class LedgerDocumentType
        {
            public static readonly string check = "check";
            //public static readonly string debitmemo = "debit-memo";
            //public static readonly string creditmemo = "credit-memo";
            // public static readonly string financecharge = "finance-charge";
            public static readonly string invoice = "invoice";
            public static readonly string ordercustomer = "order-customer";
            public static readonly string ordervendor = "order-vendor";
            //public static readonly string paymentother = "payment-other";
            // public static readonly string reminder = "reminder";
            // public static readonly string tegata = "tegata";
            public static readonly string voucher = "voucher";
            public static readonly string shipment = "shipment";
            public static readonly string receipt = "receipt";
            //public static readonly string manualadjustment = "manual-adjustment";
            public static readonly string other = "other";


        }


        public enum SCREEN
        {
            // TopID = 0 olan başlıklar.
            E_DEFTER = 80,
            EBILET = 85,
            EARSIV = 92,
            EFATURA_ARSIV = 149,
            ///--------------------------------------------------------------------
            ORGANIZATION = 1,
            ///--------------------------------------------------------------------
            FILTRELER = 2,
            ///--------------------------------------------------------------------
            TASLAKLAR = 6,
            ///--------------------------------------------------------------------
            GIDEN_FATURALAR = 8,
            ///--------------------------------------------------------------------
            GIDEN_ZARF_BAZINDA_LISTELE = 9,
            ///--------------------------------------------------------------------
            GELEN_FATURALAR = 12,
            ///--------------------------------------------------------------------
            GELEN_ZARF_BAZINDA_LISTELE = 13,
            ///--------------------------------------------------------------------
            ONAY_HIYERARSILERI = 15,
            ///--------------------------------------------------------------------
            ERP_FATURA_TURLERI = 17,
            ///--------------------------------------------------------------------
            ERP_FONKSIYON_TANIMLAMA = 18,
            ///--------------------------------------------------------------------
            ERP_FATURATURU_FILTRELEME = 19,
            ///--------------------------------------------------------------------
            SIRKET_PARAMETRELERI_BELIRLE = 21,
            ///--------------------------------------------------------------------
            SIRKET_GIRIS_OBJELERI = 22,
            ///--------------------------------------------------------------------
            ARSIVLEME_AYARLARI = 24,
            ///--------------------------------------------------------------------
            YEDEKLEME_AYARLARI = 25,
            ///--------------------------------------------------------------------
            ESLESTIRME_TABLOSU = 26,
            ///--------------------------------------------------------------------
            ESLESTIRME_SEMASI = 27,
            ///--------------------------------------------------------------------
            DIL_YONETIMI = 28,
            ///--------------------------------------------------------------------
            GRUP_TANIMLA = 30,
            ///--------------------------------------------------------------------
            KULLANICI_OLUSTUR = 31,
            ///--------------------------------------------------------------------
            KULLANICI_YETKILERI = 32,
            ///--------------------------------------------------------------------
            EKRAN_TANIMLA = 33,
            ///--------------------------------------------------------------------
            KILITLI_NESNELER = 34,
            ///--------------------------------------------------------------------
            SERVISLER = 35,
            ///--------------------------------------------------------------------
            PARAMETRE_DUZENLE = 37,
            ///--------------------------------------------------------------------
            SIRKET_BILGILERI = 38,
            ///--------------------------------------------------------------------
            KURULUM = 39,
            ///--------------------------------------------------------------------
            EKRAN_FONKSIYONLARI = 40,
            ///--------------------------------------------------------------------
            HAREKET_LISTESI = 43,
            ///--------------------------------------------------------------------
            LOGLARI_LISTELE = 44,
            ///--------------------------------------------------------------------
            FATURA_GONDERIM_ALIM_ZAMANLARI = 45,
            ///--------------------------------------------------------------------
            RAPORLAR = 48,
            ///--------------------------------------------------------------------
            GELEN_ARSIV_FATURALARI = 49,
            ///--------------------------------------------------------------------
            GIDEN_ARSIV_FATURALARI = 50,
            ///--------------------------------------------------------------------
            ERP_NOT_TURLERI = 51,
            ///-------------------------------------------------------------------
            FATURA_TURU = 52,
            ///--------------------------------------------------------------------
            EFATURA_SERVIS_FONKSIYONLARI = 53,
            ///--------------------------------------------------------------------
            EFATURA_SERVIS_AYARLARI = 54,
            ///--------------------------------------------------------------------
            HATALI_FATURALAR = 55,
            ///--------------------------------------------------------------------
            IPTAL_FATURALAR = 56,
            ///--------------------------------------------------------------------
            KILITLI_KOMUTLAR = 57,
            ///--------------------------------------------------------------------
            FATURA_OLUSTUR = 58,
            ///--------------------------------------------------------------------
            MUSTERI_BILGILERI = 59,
            ///--------------------------------------------------------------------
            MAIL_ONAY = 61,
            ///--------------------------------------------------------------------
            GELEN_FATURA_YANITLARI = 62,
            ///--------------------------------------------------------------------
            ERP_FATURALARI = 63,
            ///--------------------------------------------------------------------
            GRAFIK_RAPORLAR = 64,
            ///--------------------------------------------------------------------
            GELEN_ARSIV_ZARFLARI = 65,
            GIDEN_ARSIV_ZARFLARI = 66,
            ///--------------------------------------------------------------------
            FATURA_SIRANO_DUZENLE = 69,
            ///--------------------------------------------------------------------
            EL_GENERAL_LEDGER_LIST = 70,
            ///--------------------------------------------------------------------
            FATURA_GORSELI_TANIMLA = 71,
            ///--------------------------------------------------------------------
            FATURA_GRUBU_FONKSIYONU = 72,
            ///--------------------------------------------------------------------
            FATURA_GRUBU_YETKILERI = 73,
            ///--------------------------------------------------------------------
            EL_JOURNAL_LEDGER_LIST = 74,
            ///--------------------------------------------------------------------
            EDEFTER_TASLAKLAR = 75,
            ///--------------------------------------------------------------------
            FATURA_SERI_TANIMLA = 76,
            EPOSTA_TASARIMI = 77,
            FONKSIYON_IZINLERI = 115,
            ///------------------------------------------------------------------
            ///--Dispatcher
            CONNECTION_IP_LIST_PAGE = 123,
            CONNECTION_MESSAGE_TYPE_LIST_PAGE = 125,
            CONNECTION_PARSER_CLASS_LIST_PAGE = 127,
            CONNECTION_PORT_LIST_PAGE = 129,
            CONNECTION_PROFILE_LIST_PAGE = 131,
            CONNECTION_SETTING_LIST_PAGE = 133,
            CONNECTION_SYSTEM_LIST_PAGE = 135,
            CONNECTION_TYPE_LIST_PAGE = 137,
            CONNECTOR_PROCESS_LIST_PAGE = 139,
            CONNECTOR_PROCESS_CONNECTION_SETTING_LIST_PAGE = 143,
            ///--Dispatcher     
            ///------------------------------------------------------------------
            IS_POZISYONU = 141,
            ///----------------------------------------------------------------
            KULLANICI_IS_POZISYONU = 142,
            ///----------------------------------------------------------------
            ///---------------------------------------------------------------            
            KURALLAR = 145,
            CUSTOMTRANSFORMCODE = 146,
            ///----------------------------------------------------------------
            INVOICE_EXTENSION = 148,
            ///----------------------------------------------------------------
            MUKELLEF_LISTESI = 150,
            INVOICE_VALUES = 152,
            ///----------------------------------------------------------------
            SPECIAL_INBOX_INVOICE = 201,
            ///----------------------------------------------------------------
            SPECIAL_OUTBOX_INVOICE = 202,
            ///---------------------------------------------------------------
            #region Entegratör
            PARTNER_ALIAS = 200,
            #endregion Entegratör
            PORTAL_LOGGING = 203,
            CONNECTOR_EXCEPTION_LOGGING = 204,
            DISPATCHER_COPY = 205,


            #region EDEFTER

            LEDGER_REPORT_GENERATOR = 206,

            // LEDGER_LOCK_OBJECTS = 207,       EDEFTER_KILITLI_NESNELER=217 kullanılmakta

            ////----------------------------------------------------------------

            ELEDGER_VERI_YUKLEME = 96,
            ////----------------------------------------------------------------
            ELEDGER_UYARLAMALARI = 101,
            ////----------------------------------------------------------------
            ELEDGER_DOWNLOAD_PATENT_LIST = 108,
            ////----------------------------------------------------------------
            ELEDGER_UPLOAD_PATENT_LIST = 109,
            ////----------------------------------------------------------------
            ELEDGER_TRIAL_BALANCE = 116,
            ////----------------------------------------------------------------
            ELEDGER_PARAMETER_VALUES_EDIT = 118,
            ////----------------------------------------------------------------
            ELEDGER_UPLOAD_PATENT_DATA = 210,
            ////----------------------------------------------------------------
            //EDEFTER_TEKDUZENHESAPPLANI = 114, silincek 
            ///-----------------------------------------------------------------
            EDEFTER_ARSIV = 208,
            ///-----------------------------------------------------------------
            EDEFTER_EXCEL_UPLOAD = 209,
            ///-----------------------------------------------------------------
            EDEFTER_LISTE = 110,
            ///-----------------------------------------------------------------
            EDEFTER_ONAYLI_LISTESI = 211,
            ///-----------------------------------------------------------------
            EDEFTER_HAREKET_LISTESI = 212,
            ///-----------------------------------------------------------------
            ELEDGER_SESSION_TASK = 220,
            ///-----------------------------------------------------------------
            ELEDGER_DESIGN_MAIN = 221,
            ///-----------------------------------------------------------------
            ELEDGER_LEDGER_JOURNAL_COUNT = 222,
            ///-----------------------------------------------------------------
            EDEFTER_KONTROL_LISTESI = 223,
            ///-----------------------------------------------------------------
            EDEFTER_KONTROL_KAYDI_DUZENLE = 224,
            ///-----------------------------------------------------------------
            EDEFTER_BOLUMLENDIRME_LISTESI = 225,
            ///-----------------------------------------------------------------
            ELEDGER_MUHASEBECI_BILGILERI = 226,
            ///-----------------------------------------------------------------
            ELEDGER_SUBE_BILGILERI = 227,
            ///-----------------------------------------------------------------
            INVOICE_SERVER_FUNCTION_EDIT = 228,
            ///-----------------------------------------------------------------
            LEDGER_INDEX_SEARCH = 229,
            ///-----------------------------------------------------------------
            ELEDGER_SEARCH_PAGE = 230,
            ///-----------------------------------------------------------------
            EDEFTER_PAKET_YUKLE = 213,
            ///-----------------------------------------------------------------
            EDEFTER_BEKLEYEN_INDIRME = 214,       // bu sayfa LPWaitingDownload silinecek
            ///-----------------------------------------------------------------
            EDEFTER_LISTE_ALANI_GOSTER = 215,
            ///-----------------------------------------------------------------
            EDEFTER_DETAY_LISTESI = 216,
            ///-----------------------------------------------------------------
            EDEFTER_KILITLI_NESNELER = 217,
            ///-----------------------------------------------------------------
            //EDEFTER_XBRLDONUSTUR = 218, LEDGER_REPORT_GENERATOR 
            ///-----------------------------------------------------------------
            //EDEFTER_XBRLRAPORLA = 219,    LEDGER_REPORT_GENERATOR
            ///----------------------------------------------------------------- 
            ///----------------------------------------------------------------- 
            ///----------------------------------------------------------------- 
            ///----------------------------------------------------------------- 
            #endregion


            #region EArchive
            EARCHIVE_FATURA_LISTESI = 401,
            EARCHIVE_RAPOR_LISTESI = 402,
            EARCHIVE_MUHATAP_YONETIMI = 403,
            EARCHIVE_TASKS_LIST = 404,

            #endregion


        }


        public enum SCREEN_FUNCTION
        {
            ///--------------------------------------------------------------------
            VIEW = 1,
            ///--------------------------------------------------------------------
            SAVE = 2,
            ///--------------------------------------------------------------------
            UPDATE = 3,
            ///--------------------------------------------------------------------
            DELETE = 4,
            ///--------------------------------------------------------------------
            CANCEL = 5,
            ///--------------------------------------------------------------------
            SEND = 6,
            ///--------------------------------------------------------------------
            CONFIRM = 7,
            ///--------------------------------------------------------------------
            QUERY = 8,
            ///--------------------------------------------------------------------
            AGREEMENT_CONFIRM = 9,
            ///--------------------------------------------------------------------
            CARRY_ARCHIVE = 10,
            ///--------------------------------------------------------------------
            DOWNLOAD = 11,
            ///--------------------------------------------------------------------
            DEFINE_INVOICE_TYPE = 12,
            ///--------------------------------------------------------------------
            SEND_SAP = 13,
            ///--------------------------------------------------------------------
            SHOW = 14, // 1.3.0.0
            ///--------------------------------------------------------------------
            EXPORT_PDF = 15, // 1.3.0.0
            ///--------------------------------------------------------------------
            EXPORT_XML = 16, // 1.3.0.0
            ///--------------------------------------------------------------------
            CANCEL_APPROVED_INVOICE = 17,
            ///--------------------------------------------------------------------
            EXPORT_EXCEL = 18,
            ///--------------------------------------------------------------------
            TICARI_FATURA_YANITI = 19,
            ///--------------------------------------------------------------------
            STAMP = 20,
            ///--------------------------------------------------------------------
            NEW = 21,
            ///--------------------------------------------------------------------
            // = 22,
            ///--------------------------------------------------------------------
            CHANGE_APPROVAL_LIST = 23,
            ///--------------------------------------------------------------------
            PROXY_APPROVALHIERARCHY_CODE_COMBO = 24,
            ///--------------------------------------------------------------------
            REGISTER = 25,
            ///--------------------------------------------------------------------
            UNREGISTER = 26,
            ///--------------------------------------------------------------------
            LIST = 27
            ///--------------------------------------------------------------------
        }

        //X.Msg.show için başlıklar (title)
        public enum BSLK
        {
            BILGI,
            BILDIRI,
            BASARILI,
            HATA,
            UYARI
        }
        public enum MSG
        {
            MSG_SISTEMDE_BIR_HATA_OLUSTU_LUTFEN_SISTEM_YONETICISI_ILE_GORUSUNUZ,
            MSG_LUTFEN_EN_AZ_BIR_FATURA_SECINIZ,
            MSG_ONAY_HIYERARSI_ALANI_BOS_OLAMAZ,
            MSG_FATURANIN_TICARI_KABUL_RED_SURECI_TAMAMLANMIS,
            MSG_FATURANIN_ONAY_SURECI_TAMAMLANMAMIS,
            MSG_ONAYLANMIS_FATURAYI_MUTABAKAT_ONAYINA_GONDEREMEZSINIZ,
            MSG_FARKLI_SIRKET_FATURALARINI_MUTABAKAT_ONAYINA_GONDEREMEZSINIZ,
            MSG_ONCEDEN_ONAYLANMIS_FATURAYI_TEKRAR_ONAYLAYAMAZSINIZ,
            MSG_ONAYLANMIS_FATURALARI_IPTAL_EDEMEZSINIZ,
            MSG_FATURALAR_IPTAL_EDILDI,
            MSG_FATURANIN_DURUMU_UYGUN_DEGIL,
            MSG_FATURA_TARIHI_GECMIS_FATURAY_YENIDEN_DUZENLEYINIZ,
            MSG_FARKLI_ALICILARA_AIT_FATURALARI_TEK_ZARFA_KOYAMAZSINIZ,
            MSG_LUTFEN_ONCE_FATURALARI_ONAYLAYINIZ,
            MSG_LUTFEN_EN_AZ_BIR_KAYIT_SECINIZ,
            MSG_FATURALAR_GONDERIM_KUYRUGUNA_ISLENDI,
            MSG_ISLEM_DURUMU_TAMAMLANMAYAN_ZARF_ARSIVLENEMEZ,
            MSG_ARSIVLEME_KUYRUGUNDAKI_ZARF_ARSIVLENEMEZ,
            MSG_BASARIYLA_KAYDEDILDI,
            MSG_KAYIT_SILINDI,
            MSG_FONKSIYON_ALANI_BOS_BIRAKILMAMALIDIR,
            MSG_TABLO_ALANI_BOS_BIRAKILMAMALIDIR,
            MSG_GECERLI_DEGER_GIRINIZ,
            MSG_TABLOLARI,
            MSG_BU_KAYIT_ZATEN_TANIMLI,
            MSG_LUTFEN_SADECE_TICARI_FATURA_SECINIZ,
            MSG_FATURALAR_RED_KUYURUGUNA_EKLENDI,
            MSG_FATURALAR_KABUL_KUYURUGUNA_EKLENDI,
            MSG_FATURA_TURU_SECINIZ,
            MSG_LUTFEN_FATURA_TURLERINI_BELIRLEYINIZ,
            MSG_GONDERILMIS_FATURALARI_TEKRAR_GONDEREMEZSINIZ,
            MSG_GONDERILMIS_FATURALAR_UZERINDE_ISLEM_YAPILAMAZ,
            MSG_KABUL_YADA_RED_EDILEN_FATURALAR_UZERINDE_BU_ISLEM_YAPILAMAZ,
            MSG_MUTABAKAT_ONAYI,
            MSG_MUTABAKAT_RED,
            MSG_LUTFEN_ONCEKI_KURULUM_ADIMLARINI_TAMAMLAYINIZ,
            MSG_BU_ISLEMI_GERCEKLESTIRMEK_ICIN_YETKINIZ_YOKTUR,
            MSG_DEVAM_EDEBILMEK_ICIN_SIFRENIZI_DEGISTIRMELISINIZ,
            MSG_OTURUM_SURENIZ_DOLDU_YENIDEN_GIRIS_YAPINIZ,
            MSG_EN_AZ_UC_KARAKTER_OLMALI,
            MSG_DOSYA_BULUNAMADI,
            MSG_AYARLARIN_AKTIFLESMESI_ICIN_EFATURA_SERVISINI_YENIDEN_BASLATINIZ,
            MSG_SABITLER_DEGISTIRILEMEZ,
            MSG_IMZALI_FATURALAR_GONDERILEBILIR,
            MSG_ONAYLI_FATURALAR_GONDERILEBILIR,
            ///-------------------------------------------------------------
            //MSG_ONAYLANIYOR,
            MSG_IPTAL,
            MSG_GONDERIM_KUYRUGUNDA,
            MSG_ONAY_KUYRUGUNDA,
            MSG_ONAY,
            MSG_ISLEMINIZ_TAMAMLANDI,
            MSG_GONDERILIYOR,
            MSG_GONDERILDI,
            MSG_ARSIV_KUYRUGUNDA,
            MSG_IPTAL_ETMEK_ISTEDIGINIZ_FATURA_DAHA_ONCEDEN_RED_EDILMIS_IPTAL_EDILEMEZ,
            MSG_IPTAL_ETMEK_ISTEDIGINIZ_FATURA_DAHA_ONCEDEN_KABUL_EDILMIS_EDILEMEZ,

            ///-------------------------------------------------------------
            MSG_RFC_SERVER_BASLATILDI,
            ///-------------------------------------------------------------

            ///-------------------------------------------------------------
            MSG_RED_KUYRUGUNDA,
            MSG_REDEDILIYOR,
            MSG_RED,
            MSG_KABUL_KUYRUGUNDA,
            MSG_KABULEDILIYOR,
            MSG_KABUL,
            ///-------------------------------------------------------------
            MSG_ERP_GONDERIM_KUYRUGUNDA,
            MSG_ERP_GONDERILDI,
            //-----------------------------------------------
            MSG_TANIMLANMAMIS_TABLO_TURU,
            MSG_TANIMLI_TABLO_ALANI_YOK,
            //-----------------------------------------------


            //-----------------------------------------------
            MSG_OTOMATIK_ONAY_MAILI,
            MSG_GIDEN,
            MSG_GELEN,
            //-----------------------------------------------
            MSG_ONCEDEN_ONAYLANMIS_BIR_KAYDI_ONAYLAYAMAZSINIZ,
            MSG_DEFTER_ONAYLANDI_VE_BERAT_OLUSTURULDU,
            MSG_EDEFTER_SERVISI_KAPALI_LUTFEN_SISTEMYONETICISI_ILE_GORUSUNUZ,
            MSG_TEKILNO_BULUNAMADI,
            MSG_TANIMLI_FATURA_SERISI_BULUNAMADI,
            MSG_GECERSIZ_VKN,
            MSG_BU_FATURAYA_AIT_ISLEM_MEVCUT,
            MSG_FARKLI_PROFILDE_FATURALARLA_TOPLU_ISLEM_YAPILAMAZ,
            MSG_ONAY_SIRASI_SIZDE_DEGIL,
            MSG_HIYERASI_OTOMATIK_GIB_SURECINDE_OLDUGU_ICIN_ISLEM_YAPILAMADI,
            MSG_LUTFEN_ONCE_ALT_KRITERI_SILINIZ,
            MSG_AKTIF_ALT_KRITERE_SAHIP_PASIF_EDILEMEZ,
            MSG_FATURA_TASARIMINDA_HATALAR_TESPIT_EDILDI,
            MSG_SURECI_DEVAM_EDEN_FATURA_ONAYLANAMAZ,
            MSG_GIRILEN_DEGERDE_OZEL_KARAKTERLER_OLMAMALIDIR,
            MSG_GIRILEN_KAYIT_TABLODA_TANIMLI,
            MSG_ONAY_LISTESI_DEGISTIRME,
            MSG_FATURA_ALIAS_DEGISTIRME,
            MSG_FATURA_GORSEL_DEGISTIRME,
            MSG_BELGE_AKISI,
            MSG_FATURA_ONAY_LISTESI_DEGISTIRILDI,
            SECILI_KAYITLAR_KILITLI_LUTFEN_KONTROL_EDINIZ,
            ZARF_CEVABINDAN_ONCE_TICARI_CEVAP_GELDI,
            HATALI_ZARFA_TICARI_CEVAP_GELDI,
            TICARI_CEVAP_VERILEBILIR_DONEM_GECMIS,
            TICARI_CEVAP_VERILEN_FATURA_BULUNAMADI
        }

        public enum AppSettings
        {
            ApplicationName,
            PortalConfigPath,
            EndpointAddress,
            StartTrace,
            EsyaFolder,
            UseHsm,
            UsePfx,
            PfxFolder,
            EsyaLisansXml,
            XmlSignature,
            CertvalPolicy,
            CertvalPolicyMaliMuhur,
            CryptokiLicensee,
            CryptokiProductKey,
            cknfastdll
        }
        public enum LedgerFileType
        {
            IMPORT_CSV,
            IMPORT_ISIS_CSV2,
            EXPORT_CSV,
            EXPORT_XLSX,
            XBRL_PDF,
            //XBRL_PDF_LEDGER,     //  KEBIR
            //XBRL_PDF_JOURNAL,    //  YEVMIYE
            IMPORT_BERAT,
            LEDGER_CONTROL,
            LEDGER_ANALIZ,
            LEDGER_ERROR,
            LEDGER_WARNING,
            IMPORT_XBRL_TO_CSV,

            DIRECT_XBRL,

            SNDENV_BERAT,//SEND DOCUMENT
            GETENV_BERAT,//GET DOCUMENT
            GETSTTENV_BERAT,//GET STATÜ
            SEARCH_QUERY_XBRL,
            SEARCH_QUERY_CSV,
            SEARCH_QUERY_PDF,
            SEARCH_RESULT,

        }

        public enum LedgerCsvMessageType
        {
            /// <summary>
            /// ilk Kullanılan CSV versiyonu Mercedeste kullanıldığından hala aktif 
            /// </summary>
            ISIS_CSV1,
            /// <summary>
            /// Standart İSİS Csv Dosyası 
            /// </summary>
            ISIS_CSV2,
            /// <summary>
            /// içerisinde şirket ve muhasebeci bilgilleri yer alan satır satır AH AD bilgilerinin yer aldığı csv dosyası 
            /// </summary>
            ISIS_CSV3,
            /// <summary>
            /// Web Sevis Csv Dosyası Önce AH bilgileri ard arda yazılır sonra AD bilgileri art arta yazılır
            /// </summary>
            ISIS_CSV4,
            /// <summary>
            /// Philip Morris için kullanılan data pattern
            /// </summary>
            ISIS_CSV5,
            /// <summary>
            /// Mercedes için kullanılan data pattern
            /// </summary>
            ISIS_CSV6,
            ISIS_CSV7, //bayer 
            ISIS_CSV8, //ge marmara
            UNDEFINED,
            PERIOD_CONTROL,

            ISIS_ACCOUNT1,//: information to fill in a chart of accounts file.  
            ISIS_BALANCE1,//: the results of accumulation of a complete and validated list of entries for an account (or a list of account) in a specific period - sometimes called general ledger  
            ISIS_ENRIES1,//:  a list of individual accounting entries, which might be posted/validated or nonposted/validated   
            ISIS_JOURNAL1,//: a self-balancing (Dr = Cr) list of entries for a specific period including beginning balance for that period.  
            ISIS_LEDGER1,//: a complete list of entries for a specific account (or list of accounts) for a specific period; note - debits do not have to equal credits.   
            ISIS_ASSET1,//: a listing of open receivables, payables, inventory, fixed assets or other information that can be extracted from but are not necessarily included as part of a journal entry.  
            ISIS_TRIALBALANCE1,//: the self-balancing (Dr = Cr) result of accumulation of a complete and validated list of entries for the entity in a complete list of accounts in a specific period.
            ISIS_TAXTABLES1,//:  aids automated interpretation of instances that represent tax tables; Tax table are defined by using multiple [taxes] structures to gather the population of codes, authorities and rates; through [taxTableCode] cross-references in the [taxes] structure, these "master file" tax tables can be referenced.

        }

        public enum LedgerFileStatus
        {
            ANALIZ,
            HATA,
            OLUSTURULUYOR,
            OLUSTURULDU,
        }

       

        public sealed class AccountPeriodControlEnum
        {
            public const string VKN = "001";
            public const string RecordPeriod = "002";
            public const string PeriodCoveredStart = "003";
            public const string PeriodCoveredEnd = "004";
            public const string EntryCount = "005";
            public const string fiscalYearStart = "006";
            public const string fiscalYearEnd = "007";
            public const string DebitSum = "008";
            public const string CreditSum = "009";
            public const string PeriodClosed = "010";
            public const string isTest = "011";
            public const string ControlType = "012";
            public const string EnteredBeginDate = "013";
            public const string EnteredEndDate = "014";
            public const string batchID = "051";
            public const string batchDescription = "052";
        }

        public sealed class Folders
        {
            public const string processing = "processing";
            public const string complated = "complated";
            public const string incorrect = "incorrect";
        }

        public enum Destination
        {
            FILE,
            DATABASE,
        }

        public enum ResultEnum
        {
            NotAuthIp = -1,
            NullData = -2,
            EmptyConnectionCode = -3,
            InboxInsertError = -4,
            Error = -5,
            OutboxInsertError = -6,
            XmlError = -7,
            NoAuth = -8,
            Dublicate = -9,
            OK = 0,
            ContinueTask = 1,
        }

        public enum ServiceResult
        {
            OK,
            ERROR,
            RETRY,
            EXIST,
            EXCEPTION
        }
        public enum ControlResult
        {
            OK,
            ERROR,
            RETRY,
            EXIST,
            EXCEPTION,
            PREV_MONTH_LEDGER_NOT_EXISTS,
            START_DATE_CAN_NOT_BE_SMALL_THAN_ELEDGER_START_DATE,
            EDEFTER_TASLAK_VERILERI_VALIDASYONDAN_GECIRILMEMIS,
        }

        public enum MailTemplate
        {
            EARCHIVE_EMAIL
        }

        public enum Link
        {
            AND,
            OR
        }

        public enum Operator
        {
            EQ,
            NE,
            GT,
            GE,
            LT,
            LE,
            CS,
            NS,
            IN,
            BT,
            XSLT,
            SQL
        }
    }
}

