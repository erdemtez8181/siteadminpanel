using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Runtime.Remoting.Contexts;
using System.Web.Caching;
using System.Web.Services;
using System.Web.Security;
using System.Drawing;
using System.IO;
using System.Web.UI.HtmlControls;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Business;
using ServiceLibrary;
using BusinessObjects;
using System.Web.Configuration;
using System.Management;
using System.ServiceProcess;
using System.Net.Mail;
using System.Web.Security;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Data;

namespace AdminPanel
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region Global & Local Variable
        //*****Genel Değişkenler***//
        public double ConnectorPoolDBSize;
        public double ConnectorPoolDBSizePercent;
        public double EFaturaDBSize;
        public double EFaturaDBSizePercent;
        public double OrganizationDBSize;
        public double OrganizationDBSizePercent;
        public double DiskTotalSize;
        public int DatabaseWarningCount;
        public string ConenctorService = WebConfigurationManager.AppSettings["ConnectorName1"];
        public string ConenctorService2 = WebConfigurationManager.AppSettings["ConnectorName2"];
        public string ScheduleService = WebConfigurationManager.AppSettings["ScheduleServiceName1"];
        public string ScheduleService2 = WebConfigurationManager.AppSettings["ScheduleServiceName2"];
        public string DatabaseStatusMailMessage = "Disk Kapasitesinin %80'ini Geçen Veritabanları Aşağıdadır. Lütfen Acil olarak müdahale ediniz.<br/><br/><b><u>Database:</u></b> ";
        public int NotAlertMe = 0;
        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {

            /// ----------------------------------------------------------------------------------------------------------
            DisablePageCaching();
            IInboxManagerService objIMS = WCFProxy.Proxy<IInboxManagerService>();
            IOutboxManagerService objOms = WCFProxy.Proxy<IOutboxManagerService>();
            ((HtmlGenericControl)this.Page.Master.FindControl("spDatabaseWarningCount")).Attributes.Add("class", "");

            //lblInboxErrorCount.Text = Convert.ToString(objIMS.GetErrorCount());
            //lblOutboxErrorCount.Text = Convert.ToString(objOms.GetErrorCount());
            //this.btnDashboard.Attributes.Add("class", "start active");
            /// ----------------------------------------------------------------------------------------------------------
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /// ----------------------------------------------------------------------------------------------------------
            if (!Page.IsPostBack && !IsPostBack)
            {
                PageBase.GZipCompress(HttpContext.Current);
            }
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public);
            /// ----------------------------------------------------------------------------------------------------------
        }

        // *****************************************************************************************
        // Servislerin Durumunu Kontrol Et
        // *****************************************************************************************
    
        // *****************************************************************************************
        // Servisler Stop ise Kullanıcıya Mail Gönder
        // *****************************************************************************************
        private void SendMail(string WindowsServiceName, string Message)
        {
            try
            {
                if (Convert.ToInt32(Session["NotAlert"]) == 0)
                {
                    DashboardUser objUser = new DashboardUser();
                    objUser.GetAllActiveUserForUserId(GlobalSettings.OrganizationConnectionString, HttpContext.Current.Session["userID"].ToString());

                    string ReceiverEmailAddress = objUser.Email;
                    string CCEmailAddress = WebConfigurationManager.AppSettings["CCEmailAddress"];
                    int SuccessSend;

                    string Sender_Address = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_SENDER_ADDRESS.ToString());
                    string Password = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_PASSWORD.ToString());
                    string MessageBody = Message + WindowsServiceName;
                    MailMessage mesaj = new MailMessage();//mail mesaj nesnesi yarat
                    mesaj.From = new MailAddress(Sender_Address, "Admin", System.Text.Encoding.UTF8);//nesnenin alanlarina gerekli bilgilerin atanmasi
                    SmtpClient smtp = new SmtpClient();
                    mesaj.To.Add(ReceiverEmailAddress);
                    if (!String.IsNullOrEmpty(CCEmailAddress))
                    {
                        mesaj.CC.Add(CCEmailAddress);
                    }
                    mesaj.Subject = "KOis Dashboard - Servis Durumu Bilgilendirme (ACİL)";
                    mesaj.IsBodyHtml = true;
                    mesaj.BodyEncoding = System.Text.Encoding.UTF8;
                    mesaj.Body = MessageBody;
                    mesaj.Priority = MailPriority.High;
                    smtp.Credentials = new System.Net.NetworkCredential(Sender_Address, Password);//kullanici adi ve sifre
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Port = Convert.ToInt32(GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_PORT.ToString()));
                    smtp.Host = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_HOST.ToString());
                    bool EnableSsl = false;
                    Boolean.TryParse(GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_USING_SSL.ToString()), out EnableSsl);
                    smtp.EnableSsl = EnableSsl;
                    smtp.Send(mesaj);
                    SuccessSend = 1;
                    if (SuccessSend != 1)
                    {
                        Response.Write(@"<script language='javascript'>alert('Mail Gönderimi Sırasında Hata!');</script>");
                    }
                }
            }
            catch (Exception)
            {
                Response.Write(@"<script language='javascript'>alert('Mail Gönderimi Sırasında Hata!');</script>");
            }
        }

        // *****************************************************************************************
        // Windows Servisleri içinden Konnektör ve Schedule Bul
        // *****************************************************************************************
        public bool IsServiceInstalled(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.ServiceName == serviceName)
                    return true;
            }
            return false;
        }


        // *****************************************************************************************
        // Efatura DB Boyutunu Bul ve Diskteki Kapladığı Yeri Yüzdelik Olarak Hesapla
        // *****************************************************************************************
        private void GetEfaturaSize()
        {
            cls_Partner objPartner = new cls_Partner();
            int ResultSize = objPartner.ShowEFaturaSize(GlobalSettings.OrganizationConnectionString);
            EFaturaDBSize = ResultSize / 1000;
            EFaturaDBSize = Math.Floor(EFaturaDBSize);
            this.lblEFaturaSize.Text = "EFatura " + "(" + EFaturaDBSize + " GB" + ")";
            EFaturaDBSizePercent = this.EFaturaDBSize * 100 / DiskTotalSize;
            EFaturaDBSizePercent = Math.Floor(EFaturaDBSizePercent);
            this.lblEFaturaSizePercent.Text = EFaturaDBSizePercent.ToString();
            string ProgressBar = "width: " + Convert.ToString(EFaturaDBSizePercent) + "%";
            ((HtmlGenericControl)this.Page.Master.FindControl("spProgressEFatura")).Attributes.Add("style", ProgressBar);
            ((HtmlGenericControl)this.Page.Master.FindControl("spProgressEFatura")).Attributes.Add("aria-valuenow", ProgressBar);

            if (EFaturaDBSizePercent < 50.0 || EFaturaDBSizePercent == 50.0)
            {
                ((HtmlGenericControl)this.Page.Master.FindControl("spProgressEFatura")).Attributes.Add("class", "progress-bar progress-bar-success");
            }
            else if (EFaturaDBSizePercent > 50.0 || EFaturaDBSizePercent < 80.0)
            {
                ((HtmlGenericControl)this.Page.Master.FindControl("spProgressEFatura")).Attributes.Add("class", "progress-bar progress-bar-warning");
            }
            else if (EFaturaDBSizePercent == 80.0 || EFaturaDBSizePercent > 80.0)
            {
                ((HtmlGenericControl)this.Page.Master.FindControl("spProgressEFatura")).Attributes.Add("class", "progress-bar progress-bar-danger");

                // Boyut Yükseldiğinde Uyarı Simgesi Çıkar
                ((HtmlGenericControl)this.Page.Master.FindControl("spDatabaseWarningCount")).Attributes.Add("class", "badge");
                DatabaseWarningCount += 1;
                this.lblDatabaseWarningCount.Text = DatabaseWarningCount.ToString();
                this.btnCleanData.Visible = true;
                SendMail(this.lblEFaturaSizePercent.Text, DatabaseStatusMailMessage);
            }
        }

        // *****************************************************************************************
        // Organization DB Boyutunu Bul ve Diskteki Kapladığı Yeri Yüzdelik Olarak Hesapla
        // *****************************************************************************************
        private void GetOrganizationSize()
        {
            cls_Partner objPartner = new cls_Partner();
            string ResultSize = objPartner.ShowOrganizationSize(GlobalSettings.OrganizationConnectionString);
            OrganizationDBSize = Convert.ToDouble(ResultSize.Remove(ResultSize.Length - 6, 6)) / 1000;
            OrganizationDBSize = Math.Floor(OrganizationDBSize);
            this.lblOrganizationSize.Text = "Organization " + "(" + OrganizationDBSize + " GB" + ")";
            OrganizationDBSizePercent = this.OrganizationDBSize * 100 / DiskTotalSize;
            OrganizationDBSizePercent = Math.Floor(OrganizationDBSizePercent);
            this.lblOrganizationSizePercent.Text = OrganizationDBSizePercent.ToString();
            string ProgressBar = "width: " + Convert.ToString(OrganizationDBSizePercent) + "%";
            ((HtmlGenericControl)this.Page.Master.FindControl("spProgressOrganization")).Attributes.Add("style", ProgressBar);
            ((HtmlGenericControl)this.Page.Master.FindControl("spProgressOrganization")).Attributes.Add("aria-valuenow", ProgressBar);

            if (OrganizationDBSizePercent < 50.0 || OrganizationDBSizePercent == 50.0)
            {
                ((HtmlGenericControl)this.Page.Master.FindControl("spProgressOrganization")).Attributes.Add("class", "progress-bar progress-bar-success");
            }
            else if (OrganizationDBSizePercent > 50.0 || OrganizationDBSizePercent < 80.0)
            {
                ((HtmlGenericControl)this.Page.Master.FindControl("spProgressOrganization")).Attributes.Add("class", "progress-bar progress-bar-warning");
            }
            else if (OrganizationDBSizePercent == 80.0 || OrganizationDBSizePercent > 80.0)
            {
                ((HtmlGenericControl)this.Page.Master.FindControl("spProgressOrganization")).Attributes.Add("class", "progress-bar progress-bar-danger");

                // Boyut Yükseldiğinde Uyarı Simgesi Çıkar
                ((HtmlGenericControl)this.Page.Master.FindControl("spDatabaseWarningCount")).Attributes.Add("class", "badge");
                DatabaseWarningCount += 1;
                this.lblDatabaseWarningCount.Text = DatabaseWarningCount.ToString();
                this.btnCleanData.Visible = true;
                SendMail(this.lblOrganizationSize.Text, DatabaseStatusMailMessage);
            }
        }

        #region DisablePageCaching
        // *****************************************************************************************
        // Browser'ların Cache Tutmaması İçin
        // *****************************************************************************************
        public static void DisablePageCaching()
        {
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            HttpContext.Current.Response.AppendHeader("Expires", "0"); // Proxies.
            HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
        }
        #endregion

        // *****************************************************************************************
        // Servis Durumlarının Uyarı Mailini Kullanıcı Oturumu Kapatana Kadar Durdurur.
        // *****************************************************************************************
        protected void btnNotAlertMe_Click(object sender, EventArgs e)
        {
            NotAlertMe = 1;
            Session.Add("NotAlert", NotAlertMe);
        }
    }
}