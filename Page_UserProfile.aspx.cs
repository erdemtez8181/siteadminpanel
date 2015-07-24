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
using Siteyonetim.Framework.Business;

namespace AdminPanel.Pages
{
    public partial class Page_UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !IsPostBack)
            {
                constructUserInfo();
            }
        }

        // *****************************************************************************************
        // Kullanıcı Bilgilerini Getir
        // *****************************************************************************************
        private void constructUserInfo()
        {
            DashboardUser objUser = new DashboardUser();
            objUser.GetAllActiveUserForUserId(GlobalSettings.OrganizationConnectionString, HttpContext.Current.Session["userID"].ToString());
            this.txtName.Value = objUser.Name;
            this.txtSurName.Value = objUser.Surname;
            this.txtEmail.Value = objUser.Email;
            this.txtTelephone.Value = objUser.Telephone;
            this.txtMissions.Value = objUser.Mission;
            this.txtSavedPassword.Value = CryptoHelper.HashString(objUser.Password);

        }

        // *****************************************************************************************
        // Kullanıcı Bilgilerini Güncelle
        // *****************************************************************************************
        protected void btnSaveUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardUser objUser = new DashboardUser();
                objUser.UserId = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                objUser.UserName = HttpContext.Current.Session["userName"].ToString();
                objUser.Email = this.txtEmail.Value;
                objUser.Name = this.txtName.Value;
                objUser.Surname = this.txtSurName.Value;
                objUser.Mission = this.txtMissions.Value;
                objUser.Telephone = this.txtTelephone.Value;
                objUser.ImageName = "";
                objUser.Active = 1;
                objUser.UpdateUserInfo(null, GlobalSettings.OrganizationConnectionString);
                this.SuccessMessage.Visible = true;
            }
            catch (Exception ex)
            {
                this.SuccessMessage.Visible = false;
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
        }

        // *****************************************************************************************
        // Şifre Bilgileri Güncelle
        // *****************************************************************************************
        protected void btnEditPasswordInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardUser objUser = new DashboardUser();
                objUser.UserId = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                objUser.Password = CryptoHelper.GetMd5Sum(this.txtReNewPassword.Value);
                objUser.UpdateUserPassword(null, GlobalSettings.OrganizationConnectionString);
                this.SuccessMessage.Visible = true;
            }
            catch (Exception ex)
            {
                this.SuccessMessage.Visible = false;
                this.FaultMessage.Visible = true;
                this.lblException.Text = ex.Message.ToString();
            }
        }
    }
}