<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page_UserProfile.aspx.cs" Inherits="AdminPanel.Pages.Page_UserProfile" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="../assets/plugins/bootstrap-fileupload/bootstrap-fileupload.css" />
    <!-- Başlık-->
    <div class="row">
        <div class="col-md-12">
            <!--Navigasyon başlıyor-->
            <h3 class="page-title">Profil <small>Bilgileri</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <i class="fa fa-home"></i>
                    <a href="../Default.aspx">Anasayfa</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Kullanıcı Profili</a>
                </li>
            </ul>
            <!-- Navigasyon bitti-->
        </div>
    </div>
    <!-- Başlık-->

    <div class="row profile">
        <div class="col-md-12">
            <!--Tablar Başlıyor-->
            <div class="tabbable tabbable-custom tabbable-full-width">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#tab_1_1" data-toggle="tab">Genel</a>
                    </li>
                    <li>
                        <a href="#tab_1_3" data-toggle="tab" onclick="hideMessage()">Hesabım</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_1_1">
                        <div class="row">
                            <div class="col-md-3">
                                <ul class="list-unstyled profile-nav">
                                    <li>
                                        <img src="assets/img/profile/profile-img.png" class="img-responsive" alt="" />
                                    </li>
                                    <li>
                                        <a href="#">Mesajlarım
												<span>3
                                                </span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-md-8 profile-info">
                                        <h1><%= HttpContext.Current.Session["userName"] %></h1>
                                        <p>
                                            Profil bilgilerinizi güncelleyebilir.
                                        </p>
                                        <p>
                                            Mesajlarınızı takip edebilirsiniz.
                                        </p>
                                    </div>
                                    <%--<div class="col-md-4">
                                        <div class="portlet sale-summary">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    Biletler
                                                </div>
                                                <div class="tools">
                                                    <a class="reload" href="javascript:;"></a>
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <ul class="list-unstyled">
                                                    <li>
                                                        <span class="sale-info">BANA AİTLER <i class="fa fa-img-up"></i>
                                                        </span>
                                                        <span class="sale-num">23
                                                        </span>
                                                    </li>
                                                    <li>
                                                        <span class="sale-info">AÇIK BİLETLER <i class="fa fa-img-down"></i>
                                                        </span>
                                                        <span class="sale-num">87
                                                        </span>
                                                    </li>
                                                    <li>
                                                        <span class="sale-info">KAPANMIŞLAR
                                                        </span>
                                                        <span class="sale-num">2377
                                                        </span>
                                                    </li>
                                                    <li>
                                                        <span class="sale-info">TOPLAM
                                                        </span>
                                                        <span class="sale-num">2477
                                                        </span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="tab_1_3">
                        <div class="row profile-account">
                            <div class="col-md-3">
                                <ul class="ver-inline-menu tabbable margin-bottom-10">
                                    <li class="active">
                                        <a data-toggle="tab" href="#tab_1-1">
                                            <i class="fa fa-cog"></i>Kullanıcı Bilgileri </a>
                                        <span class="after"></span>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_2-2"><i class="fa fa-picture-o"></i>Resim Değiştir</a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_3-3"><i class="fa fa-lock"></i>Şifre Değiştir</a>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <div class="tab-content">
                                    <div id="tab_1-1" class="tab-pane active">
                                        <div id="form">
                                            <div class="form-group">
                                                <label class="control-label">Adınız</label>
                                                <input id="txtName" runat="server" type="text" placeholder="Adınız" class="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Soyadınız</label>
                                                <input id="txtSurName" runat="server" type="text" placeholder="Soyadınız" class="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">E-Mail</label>
                                                <input id="txtEmail" runat="server" type="text" placeholder="E-Mail" class="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Telefon</label>
                                                <input id="txtTelephone" runat="server" type="text" placeholder="Telefon" maxlength="11" class="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Göreviniz</label>
                                                <input id="txtMissions" runat="server" type="text" placeholder="Göreviniz" class="form-control" />
                                            </div>
                                            <div class="margiv-top-10">
                                                <asp:Button ID="btnSaveUserInfo" runat="server" CssClass="btn green" Text="Bilgileri Kaydet" OnClick="btnSaveUserInfo_Click" OnClientClick="ShowProgress();" />
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab_2-2" class="tab-pane">
                                        <p>
                                            Geçerli resminiz
                                        </p>
                                        <form action="#" role="form">
                                            <div class="form-group">
                                                <div class="thumbnail" style="width: 310px;">
                                                    <img src="assets/img/profile/profile-img.png" alt="">
                                                </div>
                                                <div class="margin-top-10 fileupload fileupload-new" data-provides="fileupload">
                                                    <div class="input-group input-group-fixed">
                                                        <span class="input-group-btn">
                                                            <span class="uneditable-input">
                                                                <i class="fa fa-file fileupload-exists"></i>
                                                                <span class="fileupload-preview"></span>
                                                            </span>
                                                        </span>
                                                        <span class="btn default btn-file">
                                                            <span class="fileupload-new">
                                                                <i class="fa fa-paper-clip"></i>&nbsp;Resim Seç
                                                            </span>
                                                            <span class="fileupload-exists">
                                                                <i class="fa fa-undo"></i>&nbsp;Değiştir
                                                            </span>
                                                            <input type="file" class="default" />
                                                        </span>
                                                        <a href="#" class="btn red fileupload-exists" data-dismiss="fileupload"><i class="fa fa-trash-o"></i>&nbsp;İptal</a>
                                                    </div>
                                                </div>
                                                <span class="label label-danger">Not!
                                                </span>
                                                <span>Bu özellik sadece Firefox(Mozilla), Chrome, Opera, Safari ve Internet Explorer 10 çalışır.
                                                </span>
                                            </div>
                                            <div class="margin-top-10">
                                                <a href="#" class="btn green">Kaydet</a>
                                                <a href="#" class="btn default">İptal</a>
                                            </div>
                                        </form>
                                    </div>
                                    <div id="tab_3-3" class="tab-pane">
                                        <div id="form-username" class="form-horizontal form-bordered">
                                            <div class="form-group last password-strength">
                                                <label class="control-label col-md-3">Mevcut Şifre</label>
                                                <div class="col-md-4">
                                                    <input id="txtSavedPassword" runat="server" disabled="disabled" type="text" class="form-control" name="password">
                                                </div>
                                            </div>
                                            <div class="form-group last password-strength">
                                                <label class="control-label col-md-3">Yeni Şifre</label>
                                                <div class="col-md-4">
                                                    <input type="password" class="form-control" name="password" id="password_strength">
                                                    <span class="help-block">Güvenlik seviyesini kontrol et
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group last password-strength">
                                                <label class="control-label col-md-3">Yeni Şifre Tekrarı</label>
                                                <div class="col-md-4">
                                                    <input id="txtReNewPassword" runat="server" type="password" class="form-control" name="password" onchange="controlPasswordMatch()">
                                                </div>
                                            </div>
                                            <div style="margin-left: 225px;">
                                                <asp:LinkButton ID="btnEditPasswordInfo" runat="server" CssClass="btn purple" OnClick="btnEditPasswordInfo_Click" OnClientClick="ShowProgress();"><i class="fa fa-check"></i>&nbsp;Kaydet</asp:LinkButton>
                                                <a href="Page_UserProfile.aspx" class="btn default">Vazgeç</a>
                                            </div>
                                            <%--<div class="form-actions fluid">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="col-md-offset-3 col-md-9">
                                                            <button type="submit" class="btn purple"><i class="fa fa-check"></i>Submit</button>
                                                            <button type="button" class="btn default">Cancel</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <div id="tab_4-4" class="tab-pane">
                                        <div>
                                            <table class="table table-bordered table-striped">
                                                <tr>
                                                    <td>Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus..
                                                    </td>
                                                    <td>
                                                        <label class="uniform-inline">
                                                            <input type="radio" name="optionsRadios1" value="option1" />
                                                            Yes
                                                        </label>
                                                        <label class="uniform-inline">
                                                            <input type="radio" name="optionsRadios1" value="option2" checked />
                                                            No
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon
                                                    </td>
                                                    <td>
                                                        <label class="uniform-inline">
                                                            <input type="checkbox" value="" />
                                                            Yes
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon
                                                    </td>
                                                    <td>
                                                        <label class="uniform-inline">
                                                            <input type="checkbox" value="" />
                                                            Yes
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon
                                                    </td>
                                                    <td>
                                                        <label class="uniform-inline">
                                                            <input type="checkbox" value="" />
                                                            Yes
                                                        </label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--end profile-settings-->
                                            <div class="margin-top-10">
                                                <a href="#" class="btn green">Save Changes</a>
                                                <a href="#" class="btn default">Cancel</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="SuccessMessage" runat="server" class="note note-success" visible="false">
                        <h4 class="block" style="font-family: Calibri; font-size: 20pt;">Güncelleme İşlemi Başarıyla Tamamlandı.</h4>
                        <p>
                            <asp:Label ID="lblProcessDataCount" runat="server" Font-Size="Larger" Font-Italic="true" ForeColor="ButtonShadow"></asp:Label>
                        </p>
                    </div>
                    <div id="FaultMessage" runat="server" class="note note-danger" visible="false">
                        <h4 class="block" style="font-family: Calibri; font-size: 20pt;">Veritabanı Seviyesinde Hata Oluştu! Aşağıdaki Detayı İnceleyiniz</h4>
                        <p>
                            <asp:Label ID="lblException" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <!--Tablar Bitti-->
        </div>
    </div>
    <!-- Görev Butonlarının Açılıp Kapatılması -->
    <script type="text/javascript">
        function controlPasswordMatch() {
            if (document.getElementById("password_strength").value == document.getElementById("MainContent_txtReNewPassword").value) {
                return;
            }
            else {
                alert('Şifre Tekrarı yada Yeni Şifre Eşlemiyor! Lütfen Kontrol Ediniz.');
            }
        };
        function hideMessage() {
            document.getElementById("MainContent_SuccessMessage").style.display = "none";
            document.getElementById("MainContent_FaultMessage").style.display = "none";
        }
    </script>
    <!-- Görev Butonlarının Açılıp Kapatılması -->
</asp:Content>
