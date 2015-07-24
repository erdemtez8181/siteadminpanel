<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page_Documentation.aspx.cs" Inherits="AdminPanel.Pages.Page_Documentation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Başlık -->
    <div class="row">
        <div class="col-md-12">
            <!--Navigasyon başlıyor-->
            <h3 class="page-title">Dökümantasyon
                <asp:Label ID="ww" runat="server"></asp:Label><small>ve Bilgilendirme</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <i class="fa fa-home"></i>
                    <a href="../Default.aspx">Anasayfa</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Dökümantasyon</a>
                </li>
            </ul>
            <!-- Navigasyon bitti-->
        </div>
    </div>
    <!-- Başlık-->
    <!-- Gelen Kutusu Başlıyor-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-envelope"></i>Yapılan Adımları Dökümante Et
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <%--<a href="javascript:;" class="reload"></a>--%>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-toolbar">
                        <div class="col-md-8">
                        </div>
                        <asp:Repeater ID="rptDocumentation" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                    <thead>
                                        <tr>
                                            <th>Sıra                                              
                                            </th>
                                            <th>Kullanıcı
                                            </th>
                                            <th>Yapılan Aksiyon
                                            </th>
                                            <th>Aksiyon Nedeni
                                            </th>
                                            <th>Tarih
                                            </th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "DashboardLogId")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "ActionMessage")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "ActionWhy")%>
                                    </td>
                                    <td class="center">
                                        <%# DataBinder.Eval(Container.DataItem, "ActionDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <%--<a href="#" id="btnQuery" runat="server" onclick="btnQuery_Click" class="btn dark">Sorgula <i class="fa fa-bolt"></i></a>--%>
                    </div>
                    <div class="table-toolbar">
                        <div class="input-group">
                            <div class="make-switch switch-large">
                                <asp:DropDownList ID="cboProcessType" runat="server" CssClass="form-control select2me" OnClientClick="ShowProgress();" AutoPostBack="true" OnSelectedIndexChanged="cboProcessType_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Operasyonel Hrkt" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Yetki Hareketleri"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Firma Hareketleri"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Tüm Hareketler..."></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="table-toolbar">
                        <div class="btn-group">
                            <asp:Button ID="btnProcess" runat="server" OnClick="btnProcess_Click" CssClass="btn blue" ToolTip="Dökümante Et" Text="Dökümante Et"></asp:Button>
                        </div>
                    </div>
                    <div id="FaultMessage" runat="server" class="note note-danger" visible="false">
                        <h4 class="block" style="font-family: Calibri; font-size: 20pt;">Veritabanı Seviyesinde Hata Oluştu! Aşağıdaki Detayı İnceleyiniz</h4>
                        <p>
                            <asp:Label ID="lblException" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Gelen Kutusu Bitti -->


    <!-- Gelen Fatura Mailing Başlıyor-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box purple">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cloud-download"></i>Fatura Raporu
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <%--<a href="javascript:;" class="reload"></a>--%>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-toolbar">
                        <div class="col-md-8">
                            <div class="input-group">
                            </div>
                        </div>
                        <asp:Repeater ID="rptInvoiceReport" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                    <thead>
                                        <tr>
                                            <th>DB_VKN                                              
                                            </th>
                                            <th>Firma Ünvanı
                                            </th>
                                            <th>Yıl
                                            </th>
                                            <th>Ay
                                            </th>
                                            <%--<th>Giden Yıl
                                            </th>
                                            <th>Giden Ay
                                            </th>--%>
                                            <th>Gelen Sayı
                                            </th>
                                            <th>Giden Sayı
                                            </th>
                                            <th>Toplam
                                            </th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "Şirket")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "Ünvan")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "GelenFaturaYil")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "GelenFaturaAy")%>
                                    </td>
                                    <%-- <td>
                                        <%# DataBinder.Eval(Container.DataItem, "GidenFaturaYil")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "GidenFaturaAy")%>
                                    </td>--%>
                                    <td class="center">
                                        <%# DataBinder.Eval(Container.DataItem, "Gelen")%>
                                    </td>
                                    <td class="center">
                                        <%# DataBinder.Eval(Container.DataItem, "Giden")%>
                                    </td>
                                    <td class="center">
                                        <%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Gelen")) + Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Giden"))%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="table-toolbar">
                        <div class="btn-group">
                            <asp:Button ID="btnGetInvoice" runat="server" OnClientClick="ShowProgress();" OnClick="btnGetInvoice_Click" CssClass="btn purple" ToolTip="Gelen ve Giden Faturaların Raporunu Döker" Text="Raporu Yürüt"></asp:Button>
                        </div>
                        <div class="btn-group">
                            <asp:Button ID="btnExportExcel" runat="server" OnClick="btnExportExcelInvoice_Click" CssClass="btn red" ToolTip="Excele Aktar" Text="Excele Aktar"></asp:Button>
                        </div>
                        <div class="btn-group">
                            <asp:Button ID="btnSendMail" runat="server" OnClientClick="ShowProgress();" OnClick="btnSendMail_Click" CssClass="btn yellow" ToolTip="Mail Gönder" Text="Mail Gönder"></asp:Button>
                        </div>
                    </div>
                    <div id="SuccessMessage" runat="server" class="note note-success" visible="false">
                        <h4 class="block" style="font-family: Calibri; font-size: 20pt;">İşlem Başarıyla Tamamlandı</h4>
                        <p>
                            <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div id="InboxReportFaultMessage" runat="server" class="note note-danger" visible="false">
                        <h4 class="block" style="font-family: Calibri; font-size: 20pt;">Veritabanı Seviyesinde Hata Oluştu! Aşağıdaki Detayı İnceleyiniz</h4>
                        <p>
                            <asp:Label ID="lblInboxAlertMailMessage" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Gelen Fatura Mailing Bitti -->

</asp:Content>
