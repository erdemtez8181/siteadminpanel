<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page_UserRights.aspx.cs" Inherits="AdminPanel.Pages.Page_UserRights" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Başlık -->
    <div class="row">
        <div class="col-md-12">
            <!--Navigasyon başlıyor-->
            <h3 class="page-title">Kullanıcı Yetkileri
                <asp:Label ID="ww" runat="server"></asp:Label><small>ve Roller</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <i class="fa fa-home"></i>
                    <a href="../Default.aspx">Anasayfa</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Kullanıcı Yetkileri</a>
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
                        <i class="fa fa-edit"></i>Yetkiler
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <%--<a href="javascript:;" class="reload"></a>--%>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <!-- Grid Çerçeve Sağ Üst Ayarları Bitti-->
                <div class="portlet-body">
                    <div class="table-toolbar">
                        <div class="col-md-12">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-user"></i>
                                </span>
                                <div class="btn-group">
                                    <asp:DropDownList ID="cboUsers" runat="server" Width="380" DataValueField="UserId" DataTextField="UserName" CssClass="form-control select2me"></asp:DropDownList>
                                </div>
                                <span class="input-group-addon">
                                    <i class="fa fa-sign-in"></i>
                                </span>
                                <div class="btn-group">
                                    <button type="button" class="btn purple">Yetki Listesi Değiştir</button>
                                    <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown"><i class="fa fa-angle-down"></i></button>
                                    <div class="dropdown-menu hold-on-click dropdown-checkboxes" role="menu">
                                        <label>
                                            <input type="checkbox" runat="server" id="chkInsert" />Insert</label>
                                        <label>
                                            <input type="checkbox" runat="server" id="chkUpdate" />Update</label>
                                        <label>
                                            <input type="checkbox" runat="server" id="chkDelete" />Delete</label>
                                        <label>
                                            <input type="checkbox" runat="server" id="chkStartStop" />Start/Stop</label>
                                    </div>
                                </div>
                                <span id="spnNewUserRights" runat="server" visible="false" class="input-group-addon">
                                    <i class="fa fa-plus"></i>
                                </span>
                                <div class="btn-group">
                                    <asp:Button ID="btnNewUserRights" CssClass="btn purple" runat="server" Visible="false" ToolTip="Yeni Yetki Ekle" Text="Yeni Yetki Ekle" OnClientClick="ShowProgress();"
                                        OnClick="btnNewUserRights_Click"></asp:Button>
                                </div>
                                <span class="input-group-addon">
                                    <i class="fa fa-umbrella"></i>
                                </span>
                                <div class="btn-group">
                                    <asp:Button ID="btnQuery" CssClass="btn dark" runat="server" ToolTip="Sorgula" Text="Sorgula" OnClientClick="ShowProgress();" OnClick="btnQuery_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <asp:Repeater ID="rptUserRights" runat="server" OnItemCommand="rptUserRights_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                    <thead>
                                        <tr>
                                            <th>Kayıt No
                                            </th>
                                            <th>Kullanıcı
                                            </th>
                                            <th>Insert Role
                                            </th>
                                            <th>Update Role
                                            </th>
                                            <th>Delete Role
                                            </th>
                                            <th>Start/Stop Role
                                            </th>
                                            <th>Güncelle
                                            </th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "UserId")%>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkInsert" runat="server" Checked='<%# Bind("InsertAuthority") %>' />
                                        <%# DataBinder.Eval(Container.DataItem, "InsertAuthority")%>                                       
                                    </td>
                                    <td class="center">
                                        <asp:CheckBox ID="chkUpdate" runat="server" Checked='<%# Bind("UpdateAuthority") %>' />
                                        <%# DataBinder.Eval(Container.DataItem, "UpdateAuthority")%>
                                    </td>
                                    <td class="center">
                                        <asp:CheckBox ID="chkDelete" runat="server" Checked='<%# Bind("DeleteAuthority") %>' />
                                        <%# DataBinder.Eval(Container.DataItem, "DeleteAuthority")%>
                                    </td>
                                    <td class="center">
                                        <asp:CheckBox ID="chkStartStop" runat="server" Checked='<%# Bind("StartStopAuthority") %>' />
                                        <%# DataBinder.Eval(Container.DataItem, "StartStopAuthority")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnUpdate" runat="server" OnClientClick="ShowProgress();" CssClass="btn green pull-right" Text="Güncelle" CommandArgument="update" CommandName='<%# Eval("AuthorityId") %>'>Güncelle <i class="fa fa-share"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
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
        </div>
    </div>
    <!-- Gelen Kutusu Bitti -->
</asp:Content>
