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
using System.Drawing;


namespace AdminPanel.Pages
{
    public partial class Page_UserRights : PageBase
    {
        #region Global & Local Variable
        //*****Genel Değişkenler***//
        public string companyVKN;
        public string ConnectionSettingCode;
        public string DateRange = "";
        public int ProcessDataCount;
        public DateTime BeginDate;
        public DateTime EndDate;

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
            ((HtmlGenericControl)this.Page.Master.FindControl("btnConnector")).Attributes.Add("class", "");
            ((HtmlGenericControl)this.Page.Master.FindControl("btnUserRights")).Attributes.Add("class", "start active");
            /// ----------------------------------------------------------------------------------------------------------
            if (!Page.IsPostBack && !IsPostBack)
            {
                constructUser(0);
                checkInsertAuthority();
                /// ----------------------------------------------------------------------------------------------------------                
            }
        }


        // *****************************************************************************************
        // Şirketleri Listele
        // *****************************************************************************************
        private void constructUser(int pageIndex)
        {

            DashboardUser objUser = new DashboardUser();
            List<DashboardUser> dtUser = objUser.GetAllActiveUserList(GlobalSettings.OrganizationConnectionString);

            if (!Object.Equals(dtUser, null) && dtUser.Count > 0)
            {
                this.cboUsers.DataSource = dtUser;
                this.cboUsers.DataBind();
            }
            else
            {
                this.cboUsers.DataSource = null;
                this.cboUsers.DataBind();
            }
        }

        // *****************************************************************************************
        // Yetki Kontrolü
        // *****************************************************************************************
        private void checkInsertAuthority()
        {
            DashboardUserRights objAuthority = new DashboardUserRights();
            bool Authority = objAuthority.GetItInsertAuthorityForUserId(GlobalSettings.OrganizationConnectionString, HttpContext.Current.Session["userID"].ToString());
            if (Authority)
            {
                this.btnNewUserRights.Enabled = true;
                this.spnNewUserRights.Disabled = false;
            }
            else
            {
                this.btnNewUserRights.Enabled = false;
                this.spnNewUserRights.Disabled = true;
            }
        }


        // *****************************************************************************************
        // Seçilen kayıtlar üzerinde güncelleme yapılır
        // *****************************************************************************************
        protected void rptUserRights_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument.Equals("update"))
                {
                    this.FaultMessage.Visible = false;
                    string ChangingUserName = ((Label)e.Item.FindControl("lblUserName")).Text;

                    // Yetkileri Güncelle
                    DashboardUserRights objUserRights = new DashboardUserRights();
                    objUserRights.AuthorityId = Convert.ToInt32(((LinkButton)e.Item.FindControl("btnUpdate")).CommandName);
                    objUserRights.UserId = Convert.ToInt32(this.cboUsers.SelectedItem.Value);
                    objUserRights.InsertAuthority = ((CheckBox)e.Item.FindControl("chkInsert")).Checked;
                    objUserRights.UpdateAuthority = ((CheckBox)e.Item.FindControl("chkUpdate")).Checked;
                    objUserRights.DeleteAuthority = ((CheckBox)e.Item.FindControl("chkDelete")).Checked;
                    objUserRights.StartStopAuthority = ((CheckBox)e.Item.FindControl("chkStartStop")).Checked;
                    objUserRights.Update(null, GlobalSettings.OrganizationConnectionString);
                    // İşlemi Logla
                    DashboardLogSave(ChangingUserName);
                    this.SuccessMessage.Visible = true;
                    btnQuery_Click(btnQuery, null);

                }
            }
            catch (Exception ex)
            {
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
        }

        // *****************************************************************************************
        // Yeni Kullanıcının Yetkilerini Kaydeder
        // *****************************************************************************************
        protected void btnNewUserRights_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardUserRights objUserRights = new DashboardUserRights();
                objUserRights.UserId = Convert.ToInt32(this.cboUsers.SelectedItem.Value);
                objUserRights.InsertAuthority = this.chkInsert.Checked;
                objUserRights.UpdateAuthority = this.chkUpdate.Checked;
                objUserRights.DeleteAuthority = this.chkDelete.Checked;
                objUserRights.StartStopAuthority = this.chkStartStop.Checked;
                objUserRights.Insert(null, GlobalSettings.OrganizationConnectionString);

                this.SuccessMessage.Visible = true;
                btnQuery_Click(btnQuery, null);
            }
            catch (Exception ex)
            {
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
        }

        // *****************************************************************************************
        // Yapılan İşlemleri Logla
        // *****************************************************************************************
        private void DashboardLogSave(string ChangingUserName)
        {
            DashboardLog objDashboardLog = new DashboardLog();
            objDashboardLog.ProcessType = 2;
            objDashboardLog.UserName = HttpContext.Current.Session["userName"].ToString();
            objDashboardLog.ActionMessage = ChangingUserName + " Kullanıcısının Yetkisi Değiştirildi";
            objDashboardLog.ActionWhy = "";
            objDashboardLog.ActionDate = DateTime.Now;
            objDashboardLog.Insert(null, GlobalSettings.OrganizationConnectionString);
        }


        // *****************************************************************************************
        // Kriterlere Göre Şirketin Data Hareketini Getir
        // *****************************************************************************************
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                spnNewUserRights.Visible = false;
                btnNewUserRights.Visible = false;
                this.FaultMessage.Visible = false;
                /// ----------------------------------------------------------------------------------------------------------
                if (this.cboUsers.SelectedItem.Value != null)
                {
                    DashboardUserRights objRights = new DashboardUserRights();
                    List<DashboardUserRights> dtRights = objRights.GetAllListForUserId(GlobalSettings.OrganizationConnectionString, Convert.ToInt32(this.cboUsers.SelectedItem.Value));
                    if (dtRights.Count == 0)
                    {
                        spnNewUserRights.Visible = true;
                        btnNewUserRights.Visible = true;
                        this.rptUserRights.Visible = false;
                    }
                    else
                    {
                        this.rptUserRights.Visible = true;
                        this.rptUserRights.DataSource = dtRights;
                        this.rptUserRights.DataBind();

                        foreach (RepeaterItem dataItem in rptUserRights.Items)
                        {
                            DashboardUserRights objAuthority = new DashboardUserRights();
                            bool Authority = objAuthority.GetItUpdateAuthorityForUserId(GlobalSettings.OrganizationConnectionString, HttpContext.Current.Session["userID"].ToString());
                            if (!Authority)
                            {
                                ((LinkButton)dataItem.FindControl("btnUpdate")).Enabled = false;
                                ((LinkButton)dataItem.FindControl("btnUpdate")).ForeColor = Color.Gainsboro;
                            }
                        }
                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Gerekli Alanları Seçmediniz!');</script>");
                }
            }
            catch (Exception ex)
            {
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
            /// ---------------------------------------------------------------------------------------------------------------
        }
    }
}