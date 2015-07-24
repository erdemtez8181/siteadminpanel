<%@ Page Title="Giriş" Language="C#" AutoEventWireup="true" CodeBehind="LockScreen.aspx.cs" Inherits="AdminPanel.LockScreen" %>

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
    <link href="assets/css/pages/lock.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- Tema CSS'leri bitti -->
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
</head>
<body onkeydown="return (event.keyCode!=13)">
    <div class="page-lock">
        <div class="page-logo">
            <a class="brand" href="Default.aspx">
                <img src="assets/img/kois.png" alt="logo" />
            </a>
        </div>
        <div class="page-body">
            <img class="page-lock-img" src="assets/img/profile/profile.jpg" alt="">
            <div class="page-lock-info">
                <div class="alert alert-danger display-hide" id="alertMessage" runat="server">
                    <button class="close" data-close="alert"></button>
                    <span>Şifre Hatalı, Kontrol Edin
                    </span>
                </div>
                <h1><%= HttpContext.Current.Session["userName"] %></h1>
                <span class="email"><%= HttpContext.Current.Session["userName"] %>
                </span>
                <span class="locked">Oturumunuz Kilitlendi
                </span>
                <form class="form-inline" runat="server" target="_top">
                    <div class="input-group input-medium">
                        <input type="password" class="form-control" placeholder="Şifreniz" id="txtPassword" runat="server">
                        <span class="input-group-btn">
                            <asp:LinkButton ID="btnLogin" runat="server" CssClass="btn blue icn-only" Text="Giriş" OnClick="btnLogin_Click"><i class="m-icon-swapright m-icon-white"></i></asp:LinkButton>
                        </span>
                    </div>
                    <div class="relogin">
                        <a href="Login.aspx"><%= HttpContext.Current.Session["userName"] %> Değil misiniz ?</a>
                    </div>
                </form>
            </div>
        </div>
        <div class="copyright">
            2014 KOis Yönetim Paneli
        </div>
    </div>
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="assets/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
    <script src="assets/scripts/app.js" type="text/javascript"></script>
    <script src="assets/scripts/lock.js"></script>

    <script>
        jQuery(document).ready(function () {
            App.init();
            Lock.init();
        });
    </script>
</body>
</html>
