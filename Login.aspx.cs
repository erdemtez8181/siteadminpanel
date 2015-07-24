using Siteyonetim.Framework.Data;
using Siteyonetim.Framework.Business;
using System;
using System.Web;
using System.Net.Mail;
using System.Web.Security;

namespace AdminPanel
{
    public partial class Login : System.Web.UI.Page
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
                if (String.IsNullOrEmpty(this.txtPassword.Value) || String.IsNullOrEmpty(this.txtUserName.Value))
                {
                    pnlAlertMessage.Visible = true;
                    this.lblAlertMessage.Text = "Zorunlu Alanları Doldurunuz.";
                    this.txtUserName.Style.Add("border-color", "#a94442");
                    this.txtPassword.Style.Add("border-color", "#a94442");
                }
                else
                {
                    var objUser = new  DashboardUser();
                    Session.RemoveAll();
                    Session.Contents.RemoveAll();
                    bool Authenticate = objUser.authenticate(GlobalSettings.OrganizationConnectionString, txtUserName.Value, CryptoHelper.GetMd5Sum(txtPassword.Value));
                    if (Authenticate)
                    {
                        HttpContext.Current.Session["userID"] = objUser.UserId.ToString();
                        HttpContext.Current.Session["userName"] = objUser.UserName.ToString();
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        this.pnlAlertMessage.Visible = true;
                        dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                        this.lblAlertMessage.Text = "Kullanıcı Adı veya Şifre Hatalı";
                        return;
                    }


                }
                /// ---------------------------------------------------------------------------------------------------------------           
            }
            catch (Exception ex)
            {
                this.pnlAlertMessage.Visible = true;
                dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                this.lblAlertMessage.Text = ex.ToString();
            }
            /// ---------------------------------------------------------------------------------------------------------------
        }

        // *****************************************************************************************
        // Mail adresine şifre gönder
        // *****************************************************************************************
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int SuccessSend = 0;
                /// ---------------------------------------------------------------------------------------------------------------           
                DashboardUser objUser = new DashboardUser();
                objUser.GetItForEmailAddress(GlobalSettings.OrganizationConnectionString, this.txtemail.Value);
                if (objUser.Email == this.txtemail.Value)
                {
                    string Sender_Address = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_SENDER_ADDRESS.ToString());
                    string Password = GlobalSettings.getApplicationSystemSettingsStr(GlobalEnum.AppConfig.EMAIL_PASSWORD.ToString());
                    string strongPassword = Membership.GeneratePassword(8, 2);
                    string MessageBody = "Yeni Şifreniz Aşağıdadır.<br/><br/><b><u>Şifreniz:</u></b> " + strongPassword;
                    MailMessage mesaj = new MailMessage();//mail mesaj nesnesi yarat
                    mesaj.From = new MailAddress(Sender_Address, "Admin", System.Text.Encoding.UTF8);//nesnenin alanlarina gerekli bilgilerin atanmasi
                    SmtpClient smtp = new SmtpClient();
                    mesaj.To.Add(this.txtemail.Value);
                    mesaj.Subject = "KOis Dashboard - Şifre Hatırlatması";
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
                        string m_oldPassword = objUser.Password;

                        if (!strongPassword.Equals(m_oldPassword))
                            objUser.Password = CryptoHelper.GetMd5Sum(strongPassword.Trim());

                        objUser.UpdateNewPasswordForForget(null, GlobalSettings.OrganizationConnectionString, objUser.Password, this.txtemail.Value);

                        this.pnlAlertMessage.Visible = true;
                        dvAlertMessage.Attributes.Add("class", "alert alert-success");
                        this.lblAlertMessage.Text = "Şifreniz Mail Adresinize Gönderildi";
                    }
                    else
                    {
                        this.pnlAlertMessage.Visible = true;
                        dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                        this.lblAlertMessage.Text = "Mail Gönderimi Sırasında Hata";
                    }
                }
                else
                {
                    this.pnlAlertMessage.Visible = true;
                    dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                    this.lblAlertMessage.Text = "Mail Adresi Sistemde Kayıtlı Değildir";
                }
                //ClientScript.RegisterStartupScript(GetType(), "Hata", "alert(\'Lütfen Bir E-Mail Adresi Girin\');", true);
                /// ---------------------------------------------------------------------------------------------------------------           
            }
            catch (Exception ex)
            {
                this.pnlAlertMessage.Visible = true;
                dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                this.lblAlertMessage.Text = ex.ToString();
            }
            /// ---------------------------------------------------------------------------------------------------------------
        }
        // *****************************************************************************************
        // Kullanıcı Yarat
        // *****************************************************************************************
        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                /// ---------------------------------------------------------------------------------------------------------------           
                if (String.IsNullOrEmpty(txtRegisterNameSurname.Value) || String.IsNullOrEmpty(this.txtRegisterUserName.Value)
                    || String.IsNullOrEmpty(this.txtRegisterPassword.Value) || String.IsNullOrEmpty(this.txtRegisterPasswordAgain.Value))
                {
                    pnlAlertMessage.Visible = true;
                    this.lblAlertMessage.Text = "Zorunlu Alanları Doldurunuz.";
                    this.txtRegisterNameSurname.Style.Add("border-color", "#a94442");
                    this.txtRegisterUserName.Style.Add("border-color", "#a94442");
                    this.txtRegisterPassword.Style.Add("border-color", "#a94442");
                    this.txtRegisterPasswordAgain.Style.Add("border-color", "#a94442");
                    return;
                }
                DashboardUser objCreateUser = new DashboardUser();
                if (this.txtRegisterPassword.Value == this.txtRegisterPasswordAgain.Value)
                {
                    // Hızlı Kayıt Bilgileri
                    objCreateUser.UserName = this.txtRegisterUserName.Value;
                    objCreateUser.Password = CryptoHelper.GetMd5Sum(this.txtRegisterPassword.Value);
                    objCreateUser.Name = this.txtRegisterNameSurname.Value;
                    objCreateUser.Active = 1;
                    bool CreateUserSuccess = objCreateUser.RegisterUser(null, GlobalSettings.OrganizationConnectionString);

                    if (CreateUserSuccess)
                    {
                        this.pnlAlertMessage.Visible = true;
                        dvAlertMessage.Attributes.Add("class", "alert alert-success");
                        this.lblAlertMessage.Text = "Kullanıcı Kaydı Tamamlandı";
                    }
                    else
                    {
                        this.pnlAlertMessage.Visible = true;
                        dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                        this.lblAlertMessage.Text = "Kullanıcı Adı veya Şifre Hatalı";
                    }
                }
                else
                {
                    this.pnlAlertMessage.Visible = true;
                    dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                    this.lblAlertMessage.Text = "Şifre ile Şifre Tekrarı Uyumsuz";
                }
                /// ---------------------------------------------------------------------------------------------------------------           
            }
            catch (Exception ex)
            {
                this.pnlAlertMessage.Visible = true;
                dvAlertMessage.Attributes.Add("class", "alert alert-danger");
                this.lblAlertMessage.Text = ex.ToString();
            }
            /// ---------------------------------------------------------------------------------------------------------------
        }
    }
}