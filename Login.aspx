<%@ Page Title="Giriş" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminPanel.Login" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
<head>
    <meta charset="utf-8" />
    <title>KOiS | Admin Dashboard Panel</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="KOiS Admin panel" name="author" />
    <!-- Mobile Uyumluluk -->
    <meta name="MobileOptimized" content="320">
    <!-- Mobile Uyumluluk -->

    <!-- Global stil ve fontlar başlıyor -->
    <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- Global CSS ve fontlar bitti-->

    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2_metro.css" />

    <!-- Tema CSS'leri başlıyor -->
    <link href="assets/css/style-kois.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/css/pages/login.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- Tema CSS'leri bitti -->
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
</head>
<body class="login">
    <form id="formLogin" runat="server" target="_top">
        <div class="logo">
            <img src="assets/img/kois.png" alt="logo" />
        </div>
        <div class="content">
            <!-- Login Form Başlıyor -->
            <div class="login-form">
                <h3 class="form-title">Kullanıcı Bilgilerini Giriniz</h3>
                <asp:Panel ID="pnlAlertMessage" Visible="false" runat="server">
                    <div id="dvAlertMessage" runat="server" class="alert alert-danger">
                        <button class="close" data-close="alert"></button>
                        <asp:Label ID="lblAlertMessage" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Kullanıcı Adı</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <input runat="server" id="txtUserName" class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Kullanıcı Adı" name="username" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Şifre</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <input runat="server" id="txtPassword" class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Şifre" name="password" />
                    </div>
                </div>

                <div class="form-actions">
                    <%-- <label class="checkbox">
                        <input type="checkbox" name="remember" value="1" />
                        Beni Hatırla
                    </label>--%>
                    <asp:LinkButton ID="btnLogin" runat="server" CssClass="btn green pull-right" Text="Tamam" OnClick="btnLogin_Click">Tamam <i class="m-icon-swapright m-icon-white"></i></asp:LinkButton>
                </div>
                <div class="forget-password">
                    <h4>Bilgilerini mi unuttun?</h4>
                    <p>
                        Lütfen <a href="javascript:;" id="forget-password">buraya</a>
                        tıklayın ve şifrenizi resetleyin.
                    </p>
                </div>
                <div class="create-account">
                    <p>
                        Üye değil misiniz ?&nbsp; <a href="javascript:;" id="register-btn">Kullanıcı Oluştur</a>
                    </p>
                </div>
            </div>
            <!-- Login Form Bitti -->

            <!-- Şifremi Unuttum Bölümü Başlıyor -->
            <div class="forget-form">
                <h3>Bilgilerini mi unuttun?</h3>
                <p>
                    Lütfen e-Mail adresinizi girin
                </p>
                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-envelope"></i>
                        <input id="txtemail" runat="server" class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Email" name="email" />
                    </div>
                </div>
                <div class="form-actions">
                    <button type="button" id="back-btn" class="btn">
                        <i class="m-icon-swapleft"></i>&nbsp;Geri
                    </button>
                    <asp:LinkButton ID="btnSend" runat="server" CssClass="btn green pull-right" Text="Gönder" OnClick="btnSend_Click">Gönder <i class="m-icon-swapright m-icon-white"></i></asp:LinkButton>
                </div>
            </div>
            <!-- Şifremi Unuttum Bölümü Bitti -->

            <!-- Kayıt Formu Bölümü Başlıyor -->
            <div class="register-form">
                <h3>Kayıt Ol</h3>
                <p>
                    Kullanıcı Bilgilerinizi Giriniz:
                </p>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Adınız/Soyadınız</label>
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <input id="txtRegisterNameSurname" runat="server" class="form-control placeholder-no-fix" type="text" placeholder="Adınız/Soyadınız" name="fullname" />
                    </div>
                </div>
                <p>
                    Hesap Bilgilerinizi Giriniz:
                </p>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Kullanıcı Adı</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <input id="txtRegisterUserName" runat="server" class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Kullanıcı Adı" name="username" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Şifre</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <input id="txtRegisterPassword" runat="server" class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Şifre" name="password" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Şifre Tekrarı</label>
                    <div class="controls">
                        <div class="input-icon">
                            <i class="fa fa-check"></i>
                            <input id="txtRegisterPasswordAgain" runat="server" class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Şifre Tekrarı" name="rpassword" />
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <button id="register-back-btn" type="button" class="btn">
                        <i class="m-icon-swapleft"></i>&nbsp;Geri
                    </button>
                    <asp:LinkButton ID="btnCreateUser" runat="server" CssClass="btn green pull-right" Text="Gönder" OnClick="btnCreateUser_Click"> Hesap Aç <i class="m-icon-swapright m-icon-white"></i></asp:LinkButton>
                </div>
            </div>
            <!-- Kayıt Formu Bölümü Bitti -->

        </div>
        <div class="copyright">
            2014 KOiS Yönetim Paneli
        </div>
    </form>
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
    <script src="assets/scripts/app.js" type="text/javascript"></script>
    <script src="assets/scripts/login.js" type="text/javascript"></script>

    <script>
        jQuery(document).ready(function () {
            App.init();
            Login.init();
        });
    </script>
</body>
</html>
