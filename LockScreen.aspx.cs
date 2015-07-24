using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Business;
using Siteyonetim.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel
{
    public partial class LockScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] != null)
            {
                Session.RemoveAll();
                Session.Contents.RemoveAll();
            }
        }

        // *****************************************************************************************
        // Kullanıcı Adı Şifre Doğrulama ve Yönlendirme
        // *****************************************************************************************
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                /// ---------------------------------------------------------------------------------------------------------------
                if (String.IsNullOrEmpty(this.txtPassword.Value))
                {
                    this.alertMessage.Attributes.Add("class", "");
                    this.alertMessage.Attributes.Add("class", "alert alert-danger");
                    //ClientScript.RegisterStartupScript(GetType(), "Hata", "alert(\'Lütfen Şirenizi Girin\');", true);
                }
                else if (HttpContext.Current.Session["userName"] == null)
                {
                    Session.RemoveAll();
                    Session.Contents.RemoveAll();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    var objUser = new DashboardUser();
                    Session.RemoveAll();
                    Session.Contents.RemoveAll();
                    bool Authenticate = objUser.authenticateForLockScreen(GlobalSettings.OrganizationConnectionString, CryptoHelper.GetMd5Sum(txtPassword.Value));
                    if (Authenticate)
                    {
                        HttpContext.Current.Session["userID"] = objUser.UserId.ToString();
                        HttpContext.Current.Session["userName"] = objUser.UserName.ToString();
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        this.alertMessage.Attributes.Add("class", "");
                        this.alertMessage.Attributes.Add("class", "alert alert-danger");
                        return;
                    }


                }
                /// ---------------------------------------------------------------------------------------------------------------           
            }
            catch (Exception ex)
            {
                //this.alertMessage.InnerText = ex.Message.ToString();
                //this.lblHata.Text = ex.Message.ToString();
            }
            /// ---------------------------------------------------------------------------------------------------------------
        }
    }
}