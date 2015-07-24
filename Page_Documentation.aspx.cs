using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using BusinessObjects;
using ServiceLibrary;
using System.Text.RegularExpressions;
using AdminPanel;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Data;
using System.IO;
using System.Globalization;
using OfficeOpenXml;
using System.Net.Mail;
using System.Web.Security;
using System.Web.Configuration;
using System.Reflection;
using System.Drawing;
using OfficeOpenXml.Style;


namespace AdminPanel.Pages
{
    public partial class Page_Documentation : PageBase
    {
        #region Global & Local Variable
        //*****Genel Değişkenler***//
        public int isChecked = 0;
        public int isSelected = 0;
        public int DataCount = 0;
        public static string LiveOrganizationConnectionString = "Data Source=SQL\\SQLCLUSTER;Initial Catalog=Organization;User ID=efatura;Password=AsdQwe!234;Integrated Security=False;MultipleActiveResultSets=True;Max Pool Size=1000;Pooling = True;Application Name=medomorg";
        public string Message = "Raporunuz Yıl ve Ay Bazında Excel Olarak Ekte Sunulmuştur.";

        #endregion

        // *****************************************************************************************2
        // Sayfa Başlangıcında Sol Menüde seçilmiş Link Class'larını Temizle
        // En Son bu sayfanın tıklanacak linkini aktif et
        // Sayfa Postback Olduğundaki işlemleri yürüt
        // *****************************************************************************************
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlGenericControl)this.Page.Master.FindControl("btnDashboard")).Attributes.Add("class", "");
            ((HtmlGenericControl)this.Page.Master.FindControl("btnEnvelope")).Attributes.Add("class", "");
            ((HtmlGenericControl)this.Page.Master.FindControl("btnInvoice")).Attributes.Add("class", "");
            ((HtmlGenericControl)this.Page.Master.FindControl("btnConnectorTool")).Attributes.Add("class", "");
            ((HtmlGenericControl)this.Page.Master.FindControl("btnDailyControllers")).Attributes.Add("class", "");
            ((HtmlGenericControl)this.Page.Master.FindControl("btnConnector")).Attributes.Add("class", "");
            /// ----------------------------------------------------------------------------------------------------------
            if (!Page.IsPostBack && !IsPostBack)
            {
                try
                {
                    constructData(this.cboProcessType.SelectedValue);
                    if (Convert.ToString(HttpContext.Current.Session["userName"]) == "osman")
                    {
                        this.btnSendMail.Visible = true;
                    }
                    else
                    {
                        this.btnSendMail.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    this.FaultMessage.Visible = true;
                    this.lblException.Text = ex.Message.ToString();
                }

                /// ----------------------------------------------------------------------------------------------------------                
            }
        }

        // *****************************************************************************************
        // İşlemleri Listele
        // *****************************************************************************************
        private void constructData(string pProcessType)
        {
            if (pProcessType == "4")
            {
                DashboardLog objDashboardLogAll = new DashboardLog();
                List<DashboardLog> dtDashboardLogAll = objDashboardLogAll.GetAllList(GlobalSettings.OrganizationConnectionString);
                if (!Object.Equals(dtDashboardLogAll, null) && dtDashboardLogAll.Count > 0)
                {
                    this.rptDocumentation.DataSource = dtDashboardLogAll;
                    this.rptDocumentation.DataBind();
                }
                else
                {
                    this.rptDocumentation.DataSource = null;
                    this.rptDocumentation.DataBind();
                }
            }
            else
            {
                DashboardLog objDashboardLog = new DashboardLog();
                List<DashboardLog> dtDashboardLog = objDashboardLog.GetAllListProcessTypeAndToday(GlobalSettings.OrganizationConnectionString, pProcessType,
                                                   HttpContext.Current.Session["userName"].ToString(),
                                                   DateTime.Today.AddHours(00).AddMinutes(00).AddSeconds(01),
                                                   DateTime.Today.AddDays(1).AddSeconds(-1));

                if (!Object.Equals(dtDashboardLog, null) && dtDashboardLog.Count > 0)
                {
                    this.rptDocumentation.DataSource = dtDashboardLog;
                    this.rptDocumentation.DataBind();
                }
                else
                {
                    this.rptDocumentation.DataSource = null;
                    this.rptDocumentation.DataBind();
                }
            }
        }

        // *****************************************************************************************
        // Seçilen işlem türüne göre yapılan işleri listele
        // *****************************************************************************************
        protected void cboProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            constructData(this.cboProcessType.SelectedValue);
        }

        // *****************************************************************************************
        // Bilgileri Excel'e Aktarır
        // *****************************************************************************************
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Dökümantasyon.xls");
            Response.AddHeader("Content-Type", "text/html;charset=UTF-8");
            Response.Charset = "UTF-8";
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.rptDocumentation.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            /// ---------------------------------------------------------------------------------------------------------------
        }

        // *****************************************************************************************
        // Bilgileri Excel'e Aktar
        // *****************************************************************************************
        protected void btnExportExcelInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rptInvoiceReport.Items.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=Fatura_Raporu.xls");
                    Response.AddHeader("Content-Type", "text/html;charset=UTF-8");
                    Response.Charset = "UTF-8";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentEncoding = System.Text.Encoding.Unicode;
                    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    this.rptInvoiceReport.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Hiçbir Veri Getirmediniz!');</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
        }

        // *****************************************************************************************
        // Gelen Fatura Raporu
        // *****************************************************************************************
        protected void btnGetInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardEinvoiceMail objInvoiceReport = new DashboardEinvoiceMail();
                List<DashboardEinvoiceMail> dtInvoiceReport = objInvoiceReport.GetAllList(LiveOrganizationConnectionString);
                if (!Object.Equals(dtInvoiceReport, null) && dtInvoiceReport.Count > 0)
                {
                    this.rptInvoiceReport.DataSource = dtInvoiceReport;
                    this.rptInvoiceReport.DataBind();
                }
                else
                {
                    this.rptInvoiceReport.DataSource = null;
                    this.rptInvoiceReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.InboxReportFaultMessage.Visible = true;
                this.lblInboxAlertMailMessage.Text = ex.Message.ToString();
            }
        }

        // *****************************************************************************************
        // Bilgileri Excel'e Aktarır(ExcelPackage)
        // *****************************************************************************************
        public void ExportExcel(DataTable dataTable, string pFileName)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Flush();
                string Time = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();

                var fileInfo = new FileInfo(Path.GetDirectoryName(@"C:\Program Files\ISIS\EFATURA\ExcelFile\") + "\\" + pFileName + "~" + Time + ".xlsx");

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    if (fileInfo.Exists)
                        fileInfo.Delete();

                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(pFileName);
                    worksheet.Cells["A1"].LoadFromDataTable(dataTable, true, OfficeOpenXml.Table.TableStyles.Dark10);

                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.Font.Italic = true;
                    worksheet.Cells["B1"].Style.Font.Bold = true;
                    worksheet.Cells["B1"].Style.Font.Italic = true;
                    worksheet.Cells["C1"].Style.Font.Bold = true;
                    worksheet.Cells["C1"].Style.Font.Italic = true;
                    worksheet.Cells["D1"].Style.Font.Bold = true;
                    worksheet.Cells["D1"].Style.Font.Italic = true;
                    worksheet.Cells["E1"].Style.Font.Bold = true;
                    worksheet.Cells["E1"].Style.Font.Italic = true;
                    worksheet.Cells["F1"].Style.Font.Bold = true;
                    worksheet.Cells["F1"].Style.Font.Italic = true;

                    worksheet.Cells["G1"].Style.Font.Size = 13;
                    worksheet.Cells["G1"].Style.Font.Bold = true;
                    worksheet.Cells["G1"].Style.Font.Italic = true;

                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        worksheet.Column(i).AutoFit();
                        if (dataTable.Columns[i - 1].DataType == System.Type.GetType("System.DateTime"))
                        {
                            worksheet.Column(i).Style.Numberformat.Format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        }
                    }
                    // Belirtilen FilePath'e Kaydeder
                    package.Save();
                }

                // Download yada Açma Kısmı Çalışır
                //HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=" + fileInfo.Name);
                //HttpContext.Current.Response.WriteFile(fileInfo.FullName);
                //HttpContext.Current.Response.Flush();

                // Direkt Download yada Açmak için
                //HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
                SendMail(Message, fileInfo.DirectoryName + "\\" + fileInfo.Name);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
        }

        // *****************************************************************************************
        // Raporu Mail Gönder
        // *****************************************************************************************

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            // DataTable ile Excele Aktarma
            DashboardEinvoiceMail objInvoiceReport = new DashboardEinvoiceMail();
            DataTable dtInvoiceReport = objInvoiceReport.GetAllListForMailing(new SqlConnection(LiveOrganizationConnectionString));
            if (dtInvoiceReport.Rows.Count > 0)
            {
                ExportExcel(dtInvoiceReport, "Fatura_Raporu");
            }
        }

        // *****************************************************************************************
        // Excel'e Aktarılan Dosyayı Mail Gönder
        // *****************************************************************************************
        private void SendMail(string Message, string pFilePath)
        {
            try
            {
                Attachment attachment;
                attachment = new Attachment(pFilePath);
                string ReceiverEmailAddress = WebConfigurationManager.AppSettings["EinvoiceReportEmailAddress"];
                int SuccessSend;

                string Sender_Address = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_SENDER_ADDRESS.ToString());
                string Password = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_PASSWORD.ToString());
                string MessageBody = Message;
                MailMessage mesaj = new MailMessage();//mail mesaj nesnesi yarat
                mesaj.From = new MailAddress(Sender_Address, "Admin", System.Text.Encoding.UTF8);//nesnenin alanlarina gerekli bilgilerin atanmasi
                SmtpClient smtp = new SmtpClient();
                mesaj.To.Add(ReceiverEmailAddress);
                mesaj.Attachments.Add(attachment);
                mesaj.Subject = "KOis Dashboard - Müşteri Fatura Kullanım Raporu";
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
                if (SuccessSend == 1)
                {
                    this.FaultMessage.Visible = false;
                    this.SuccessMessage.Visible = true;
                    this.lblSuccessMessage.Text = "Rapor Mail Olarak Gönderildi.";

                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Mail Gönderimi Sırasında Hata!');</script>");
                }
            }
            catch (Exception)
            {
                Response.Write(@"<script language='javascript'>alert('Mail Gönderimi Sırasında Hata!');</script>");
            }
        }
    }
}