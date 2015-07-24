using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using Siteyonetim.Framework.Business;
using System.Web.Configuration;

namespace Siteyonetim.Framework.Business
{
    public static class GlobalSettings
    {
        private static bool? _IsTest = null;
        public static bool IsTest
        {
            get
            {
                if (_IsTest == null)
                    _IsTest = getApplicationSystemSettingsBool(GlobalEnum.AppConfig.IsTest, true);
                if (_IsTest == true)
                    return true;
                else
                    return false;
            }
        }

        private static bool? _IsEntegrator = null;
        public static bool IsEntegrator
        {
            get
            {
                if (_IsEntegrator == null)
                    _IsEntegrator = getApplicationSystemSettingsBool(GlobalEnum.AppConfig.IsEntegrator);
                if (_IsEntegrator == true)
                    return true;
                else
                    return false;
            }
        }

        private static bool? _HasSSO = null;
        public static bool HasSSO
        {
            get
            {
                if (_HasSSO == null)
                    _HasSSO = getApplicationSystemSettingsBool(GlobalEnum.AppConfig.HasSSO);
                if (_HasSSO == true)
                    return true;
                else
                    return false;
            }
        }

        private static bool? _HasDirectConnection = null;
        public static bool HasDirectConnection
        {
            get
            {
                if (_HasDirectConnection == null)
                {
                    _HasDirectConnection = getApplicationSystemSettingsBool(GlobalEnum.AppConfig.HasDirectConnection);
                }
                if (_IsEntegrator == true)
                    return true;
                else
                    return false;
            }
        }



        private static string _configPath = null;
        public static string ConfigPath
        {
            get
            {
                if (_configPath == null)
                    _configPath = WebConfigurationManager.AppSettings["PortalConfigPath"];
                return _configPath;
            }
        }

        private static string _ApplicationName = null;
        public static string ApplicationName
        {
            get
            {
                if (_ApplicationName == null)
                {
                    _ApplicationName = GlobalSettings.GetAppSetting(GlobalEnum.AppSettings.ApplicationName);
                    if (String.IsNullOrEmpty(_ApplicationName))
                        _ApplicationName = "ISISSCHEDULE";
                }
                return _ApplicationName;
            }
        }

        private static int _InvoiceWorkerPort = 0;
        public static int InvoiceWorkerPort
        {
            get
            {
                if (_InvoiceWorkerPort == 0)
                {
                    string port = ConfigurationManager.AppSettings["InvoiceWorkerPort"];
                    if (!String.IsNullOrEmpty(port))
                        _InvoiceWorkerPort = Convert.ToInt32(port);
                }
                if (_InvoiceWorkerPort == 0)
                    _InvoiceWorkerPort = 8081;
                return _InvoiceWorkerPort;
            }
        }
        public static string DecryptString(string str)
        {
            try
            {
                string xml = System.IO.File.ReadAllText(Path.Combine(ConfigPath, "key.kez"));
                string bitStrengthString = xml.Substring(0, xml.IndexOf("</BitStrength>") + 14);
                xml = xml.Replace(bitStrengthString, "");

                LicenceHelper licHelper = new LicenceHelper();
                try
                {
                    return licHelper.DecryptString(str, 1024, xml);

                }
                catch (Exception ex)
                {
                    throw new Exception("Değer çözülemedi");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException("key dosyası bulunamadı");
            }
        }

        private static int _ScheduleServiceTCPPort = 1086;
        public static int ScheduleServiceTCPPort
        {
            get
            {
                if (_ScheduleServiceTCPPort == 0)
                {
                    string port = ConfigurationManager.AppSettings["ScheduleServiceTCPPort"];
                    if (!String.IsNullOrEmpty(port))
                        _ScheduleServiceTCPPort = Convert.ToInt32(port);
                }
                if (_ScheduleServiceTCPPort == 0)
                    _ScheduleServiceTCPPort = 8081;
                return _ScheduleServiceTCPPort;
            }
        }

        private static string _organizationString = null;
        /// <summary>
        /// Paramatreleri almak için kullandığımız ConnectionString i şifreli bir şekilde aşağıdaki path 'de saklıyoruz.
        /// Saklama işlemi için Tools Solutionındaki Cripto Projesini kullanıyoruz. Orda Encrypt edilen değer app.configde saklanır.
        /// App.Config de saklanan connectionString i adı ORGANIZATION_STRING olmalı
        /// </summary>
        /// <author>Ümit Çelik</author>
        public static string OrganizationConnectionString
        {
            get
            {
                if (_organizationString == null)
                {
                    string conStr = GlobalSettings.DecryptString(WebConfigurationManager.AppSettings["GenelConnectionString"]);
                    if (String.IsNullOrEmpty(conStr))
                    {
                        throw new Exception("ORGANIZATION_STRING connectionString değeri bulunamadı");
                    }
                    try
                    {
                        _organizationString = conStr;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return _organizationString;
            }
            set { _organizationString = value; }
        }





        public static string getApplicationSystemSettingsStr(GlobalEnum.AppConfig key)
        {
            return getApplicationSystemSettingsStr(key.ToString());
        }

        public static bool getApplicationSystemSettingsBool(GlobalEnum.AppConfig key, bool byDefault = false)
        {
            string value = getApplicationSystemSettingsStr(key);
            if (value == null)
                return byDefault;
            bool result = byDefault;
            Boolean.TryParse(value.ToLower(), out result);
            return result;
        }

        /// <summary>
        /// app.config system türünü alır.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <author>Osman KAYKAÇ</author>
        public static string getApplicationSystemSettingsStr(string key)
        {
            return WebConfigurationManager.AppSettings[key].ToString();
        }

        public static string TEMP_FOLDER { get { return getApplicationSystemSettingsStr(GlobalEnum.AppConfig.TEMP.ToString()); } }
        public static string UNZIP_FOLDER { get { return getApplicationSystemSettingsStr(GlobalEnum.AppConfig.ZIP.ToString()); } }
        public static string InvoiceConfigFile { get { return string.Format(getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EFATURA.ToString()) + "InvoiceConfig.XML"); } }

        public static string LOG_FOLDER { get { return string.Format(getApplicationSystemSettingsStr(GlobalEnum.AppConfig.ISISLOG.ToString())); } }

        public static string LEDGER_TEMP_FOLDER { get { return getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EDEFTER_TEMP.ToString()); } }

        public static string GetAppSetting(GlobalEnum.AppSettings appSetting)
        {
            return GetAppSetting(appSetting.ToString());
        }

        public static string GetAppSetting(string appSetting)
        {
            return ConfigurationManager.AppSettings[appSetting];
        }

        public static void setCommandParameters(ref SqlParameterCollection sqlParameterCollection, ref string sqlstr, string[] values)
        {
            string[] paramNames = values.Select((s, i) => "@param" + i.ToString()).ToArray();
            for (int i = 0; i < paramNames.Length; i++)
            {
                sqlParameterCollection.AddWithValue(paramNames[i], values[i]);
            }
            string inClause = string.Join(",", paramNames);
            sqlstr = string.Format(sqlstr, inClause);
        }
    }
}
