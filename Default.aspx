<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminPanel._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Başlık-->
    <div class="row">
        <div class="col-md-12">
            <!--Navigasyon başlıyor-->
            <h3 class="page-title">Gösterge Paneli <small>ve Yönetim Ekranları</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <i class="fa fa-home"></i>
                    <a href="index.html">Anasayfa</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Gösterge Paneli</a>
                </li>
            </ul>
            <!-- Navigasyon bitti-->
        </div>
    </div>
    <!-- Başlık-->
    <!-- Dashboard Frameleri Başlıyor -->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box grey">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Gelen Kutusu
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="fa fa-user-md"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxNew" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Yeni
                                    </div>
                                </div>
                                <a class="more" href="#">Detay <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-in"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxProcessing" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        İşlenen
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxProcessingRecordDate" runat="server"></asp:Label>
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat purple">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-out"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxErpError" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Erp Hatası
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxErpErrorRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat yellow">
                                <div class="visual">
                                    <%--<i class="fa fa-medkit"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxException" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Hata
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxExceptionRecordDate" runat="server"></asp:Label>
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="fa fa-user-md"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxParseError" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Dönüsüm Hatası
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxParseErrorRecordDate" runat="server"></asp:Label>
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-in"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxPortError" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Port Hatası
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxPortErrorRecordDate" runat="server"></asp:Label>
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat purple">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-out"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxDied" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Died
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxDiedRecordDate" runat="server"></asp:Label>
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="fa fa-medkit"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblInboxCompleted" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Tamamlananlar
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblInboxCompletedRecordDate" runat="server"></asp:Label>
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Dashboard Frameleri Bitti -->
    <div class="clearfix">
    </div>
    <!-- Dashboard Frameleri Başlıyor -->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box purple">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Giden Kutusu
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="fa fa-user-md"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxNew" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Yeni
                                    </div>
                                </div>
                                <a class="more" href="#">Detay <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div runat="server" visible="false" class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-in"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxProcessing" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        İşlenen
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxProcessingRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat purple">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-out"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxErpError" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Erp Hatası
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxErpErrorRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat yellow">
                                <div class="visual">
                                    <%--<i class="fa fa-medkit"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxException" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Hata
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxExceptionRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="fa fa-user-md"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxParseError" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Dönüsüm Hatası
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxParseErrorRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-in"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxPortError" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Port Hatası
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxPortErrorRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div runat="server" visible="false" class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat purple">
                                <div class="visual">
                                    <%--<i class="fa fa-sign-out"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxDied" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Died
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxDiedRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                            <div class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="fa fa-medkit"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                        <asp:Label ID="lblOutboxCompleted" runat="server"></asp:Label>
                                    </div>
                                    <div class="desc">
                                        Tamamlananlar
                                    </div>
                                </div>
                                <a class="more" href="#">
                                    <asp:Label ID="lblOutboxCompletedRecordDate" runat="server"></asp:Label><i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Dashboard Frameleri Bitti -->
    <div class="clearfix">
    </div>
    <div class="row" runat="server" visible="false">
        <!-- En Çok Fatura Gönderenler Başlıyor -->
        <div class="col-md-6 col-sm-6">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-thumbs-o-up"></i>En Çok Fatura Gönderenler
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn btn-sm default" href="#" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">Filtrele <i class="fa fa-angle-down"></i>
                            </a>
                            <div class="dropdown-menu hold-on-click dropdown-checkboxes pull-right">
                                <label>
                                    <input type="checkbox" />
                                    Temel Faturalar</label>
                                <label>
                                    <input type="checkbox" checked="" />
                                    Ticari Faturalar</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="scroller" style="height: 300px;" data-always-visible="1" data-rail-visible="0">
                        <asp:Repeater ID="rptTopInvoiceSenders" runat="server">
                            <HeaderTemplate>
                                <ul class="feeds">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <div class="col1">
                                        <div class="cont">
                                            <div class="cont-col1">
                                                <div class="label label-sm label-info">
                                                    <i class="fa fa-check"></i>
                                                </div>
                                            </div>
                                            <div class="cont-col2">
                                                <div class="desc">
                                                    <%# DataBinder.Eval(Container.DataItem, "UNVAN") %>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col2">
                                        <div class="date">
                                            <%# DataBinder.Eval(Container.DataItem, "ItemCount") %>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="scroller-footer">
                        <div class="pull-right">
                            <a href="#">Detaylı Liste <i class="m-icon-swapright m-icon-gray"></i></a>&nbsp;
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- En Çok Fatura Gönderenler Bitti -->
        <!-- En Çok Fatura Alanlar Başlıyor -->
        <div class="col-md-6 col-sm-6">
            <div class="portlet box green tasks-widget">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-check"></i>En Çok Fatura Alanlar
                    </div>
                    <div class="tools">
                        <a href="#" class="reload"></a>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn default btn-xs" href="#" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">Filtrele <i class="fa fa-angle-down"></i>
                            </a>
                            <ul class="dropdown-menu pull-right">
                                <li class="divider"></li>
                                <li>
                                    <a href="#">Temel Faturalar</a>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    <a href="#">Ticari Faturalar</a>
                                </li>
                                <li class="divider"></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="task-content">
                        <div class="scroller" style="height: 305px;" data-always-visible="1" data-rail-visible1="1">



                            <asp:Repeater ID="rptTopInvoiceReceivers" runat="server">
                                <HeaderTemplate>
                                    <ul class="task-list">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class="task-title">
                                            <span class="task-title-sp">
                                                <%# DataBinder.Eval(Container.DataItem, "UNVAN") %>
                                            </span>
                                            <span class="label label-sm label-success">
                                                <%# DataBinder.Eval(Container.DataItem, "ItemCount") %>
                                            </span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="task-footer">
                        <span class="pull-right">
                            <a href="#">Detaylı Liste <i class="m-icon-swapright m-icon-gray"></i></a>&nbsp;
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <!-- En Çok fatura Alanlar Bitti -->
    </div>
    <div class="clearfix">
    </div>
    <div class="row" runat="server" visible="false">
        <!-- Sunucu ve Uygulama Bilgileri Başlıyor -->
        <div class="col-md-6 col-sm-6">
            <!-- Schedule-ISISCONNECTOR-IIS Başlıyor -->
            <div class="portlet box purple">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cogs"></i>Uygulama Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="dashboardApplication-stat green">
                                <div class="visual">
                                    <i class="fa fa-chain"></i>
                                    <span style="font-style: italic; color: lightblue">Konnektör</span>
                                </div>
                            </div>
                        </div>
                        <div class="margin-bottom-10 visible-sm">
                        </div>
                        <div class="col-md-4">
                            <div class="dashboardApplication-stat green">
                                <div class="visual">
                                    <i class="fa fa-tasks"></i>
                                    <span style="font-style: italic; color: lightblue">Schedule</span>
                                </div>
                            </div>
                        </div>
                        <div class="margin-bottom-10 visible-sm">
                        </div>
                        <div class="col-md-4">
                            <div class="dashboardApplication-stat green">
                                <div class="visual">
                                    <i class="fa fa-puzzle-piece"></i>
                                    <span style="font-style: italic; color: lightblue">IIS</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Schedule-ISISCONNECTOR-IIS Bitti -->
        </div>
        <!-- Sunucu ve Uygulama Bilgileri Bitti -->
        <!-- En Çok Hata Alanlar Başlıyor -->
        <div class="col-md-6 col-sm-6">
            <div class="portlet box red tasks-widget">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-wheelchair"></i>En Çok Hata Alanlar
                    </div>
                    <div class="tools">
                        <a href="#" class="reload"></a>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn default btn-xs" href="#" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">Filtrele <i class="fa fa-angle-down"></i>
                            </a>
                            <ul class="dropdown-menu pull-right">
                                <li class="divider"></li>
                                <li>
                                    <a href="#">Temel Faturalar</a>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    <a href="#">Ticari Faturalar</a>
                                </li>
                                <li class="divider"></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="task-content">
                        <div class="scroller" style="height: 305px;" data-always-visible="1" data-rail-visible1="1">
                            <asp:Repeater ID="rptInvoiceErrorReceivers" runat="server">
                                <HeaderTemplate>
                                    <ul class="task-list">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class="task-title">
                                            <span class="task-title-sp">
                                                <%# DataBinder.Eval(Container.DataItem, "UNVAN") %>
                                            </span>
                                            <span class="label label-sm label-success">
                                                <%# DataBinder.Eval(Container.DataItem, "ItemCount") %>
                                            </span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="task-footer">
                        <span class="pull-right">
                            <a href="#">Detaylı Liste <i class="m-icon-swapright m-icon-gray"></i></a>&nbsp;
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <!-- En Çok Hata Alanlar Bitti -->
    </div>
    <div class="clearfix">
    </div>
    <!-- Mesajlaşma -->
    <div class="row" runat="server" visible="false">
        <!-- Mesaj Duvarı Başlıyor -->
        <div class="col-md-6 col-sm-6">
            <div class="portlet">
                <div class="portlet-title line">
                    <div class="caption">
                        <i class="fa fa-comments"></i>Mesaj Duvarı
                    </div>
                    <div class="tools">
                        <a href="#" class="collapse"></a>
                        <a href="#" class="reload"></a>
                        <a href="#" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body" id="chats">
                    <div class="scroller" style="height: 435px;" data-always-visible="1" data-rail-visible1="1">
                        <ul class="chats">
                            <li class="in">
                                <img class="avatar img-responsive" alt="" src="assets/img/avatar1.jpg" />
                                <div class="message">
                                    <span class="arrow"></span>
                                    <a href="#" class="name"><%= HttpContext.Current.Session["userName"] %></a>
                                    <span class="datetime">24.01.2014 11:00
                                    </span>
                                    <span class="body">Test
                                    </span>
                                </div>
                            </li>
                            <li class="out">
                                <img class="avatar img-responsive" alt="" src="assets/img/avatar2.jpg" />
                                <div class="message">
                                    <span class="arrow"></span>
                                    <a href="#" class="name">Kerem Gelen</a>
                                    <span class="datetime">24.01.2014 11:10
                                    </span>
                                    <span class="body">Test
                                    </span>
                                </div>
                            </li>
                            <li class="in">
                                <img class="avatar img-responsive" alt="" src="assets/img/avatar1.jpg" />
                                <div class="message">
                                    <span class="arrow"></span>
                                    <a href="#" class="name">Tugay Fırat</a>
                                    <span class="datetime">24.01.2014 11:25
                                    </span>
                                    <span class="body">Test
                                    </span>
                                </div>
                            </li>
                            <li class="out">
                                <img class="avatar img-responsive" alt="" src="assets/img/avatar3.jpg" />
                                <div class="message">
                                    <span class="arrow"></span>
                                    <a href="#" class="name">Çağtay Bayrak</a>
                                    <span class="datetime">24.01.2014 11:42
                                    </span>
                                    <span class="body">Test
                                    </span>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="chat-form">
                        <div class="input-cont">
                            <input class="form-control" type="text" placeholder="Mesajınızı yazın..." />
                        </div>
                        <div class="btn-cont">
                            <span class="arrow"></span>
                            <a href="" class="btn blue icn-only"><i class="fa fa-check icon-white"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Mesaj Duvarı Bitti -->
        <!-- Bilet Sistemi ve Teknik Sorumlular Başlıyor -->
        <div class="col-md-6 col-sm-6">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-bookmark"></i>Bilet Sistemi ve Teknik Sorumlular
                    </div>
                    <div class="tools">
                        <a href="#" class="collapse"></a>
                        <a href="#" class="reload"></a>
                        <a href="#" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <!--Tablar-->
                    <div class="tabbable tabbable-custom">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a href="#tab_1_1" data-toggle="tab">Açık Biletler</a>
                            </li>
                            <li>
                                <a href="#tab_1_3" data-toggle="tab">Teknik Sorumlular</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <!--Açık Biletler-->
                            <div class="tab-pane active" id="tab_1_1">
                                <div class="scroller" style="height: 290px;" data-always-visible="1" data-rail-visible="0">
                                    <ul class="feeds">
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                Faturalar sap'ye neden gelmiyor?
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                ERP ye gönderilmiş faturalarla ilgili.
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                durum raporu e-fatura pdf olarak saklama hatası
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                Ego görsel çalışması
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                E-FATURAMIZ HAKK. BİLGİ RİCASI - TOFAŞ
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                ticari faturada GİB yanıtı
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                Deva e-defter tarih dönüştürme işlemlerinde yaşanan problemin düzeltilmesi
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                Yücel Boru e-defter ayarlarının yapılması 
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="col1">
                                                    <div class="cont">
                                                        <div class="cont-col1">
                                                            <div class="label label-sm label-success">
                                                                <i class="fa fa-bell-o"></i>
                                                            </div>
                                                        </div>
                                                        <div class="cont-col2">
                                                            <div class="desc">
                                                                TOFAS E fatura portal Canlı Sistem hatası 
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col2">
                                                    <div class="date">
                                                        Detay
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <!--Açık Biletler-->
                            <!--Teknik Sorumlular-->
                            <div class="tab-pane" id="tab_1_3">
                                <div class="scroller" style="height: 290px;" data-always-visible="1" data-rail-visible1="1">
                                    <div class="row">
                                        <div class="col-md-6 user-info">
                                            <img alt="" src="assets/img/avatar.png" class="img-responsive" />
                                            <div class="details">
                                                <div>
                                                    <a href="#"><%= HttpContext.Current.Session["userName"] %></a>
                                                    <span class="label label-sm label-success label-mini">Müsait
                                                    </span>
                                                </div>
                                                <div>
                                                    Son Giriş: 29 Jan 2013 10:45AM
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 user-info">
                                            <img alt="" src="assets/img/avatar.png" class="img-responsive" />
                                            <div class="details">
                                                <div>
                                                    <a href="#">Kerem GELEN</a>
                                                    <span class="label label-sm label-info label-mini">Dışarda
                                                    </span>
                                                </div>
                                                <div>
                                                    Son Giriş: 29 Jan 2013 10:45AM
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 user-info">
                                            <img alt="" src="assets/img/avatar.png" class="img-responsive" />
                                            <div class="details">
                                                <div>
                                                    <a href="#">Tugay FIRAT</a>
                                                    <span class="label label-sm label-danger">Meşgul
                                                    </span>
                                                </div>
                                                <div>
                                                    Son Giriş: 19 Jan 2013 12:45PM
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 user-info">
                                            <img alt="" src="assets/img/avatar.png" class="img-responsive" />
                                            <div class="details">
                                                <div>
                                                    <a href="#">Mursal Sönmez</a>
                                                    <span class="label label-sm label-success">Müsait
                                                    </span>
                                                </div>
                                                <div>
                                                    Son Giriş: 19 Jan 2013 11:55PM
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--Teknik Sorumlular-->
                        </div>
                    </div>
                    <!--Tablar-->
                </div>
            </div>
        </div>
        <!-- Bilet Sistemi ve Teknik Sorumlular Bitti -->
    </div>
</asp:Content>
