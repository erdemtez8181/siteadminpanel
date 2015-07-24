<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdminPanel.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="sid" DataSourceID="AccessDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="sid" HeaderText="sid" ReadOnly="True" SortExpression="sid" />
                <asp:BoundField DataField="kullanici" HeaderText="kullanici" SortExpression="kullanici" />
                <asp:BoundField DataField="sifre" HeaderText="sifre" SortExpression="sifre" />
                <asp:BoundField DataField="adi" HeaderText="adi" SortExpression="adi" />
                <asp:BoundField DataField="soyadi" HeaderText="soyadi" SortExpression="soyadi" />
                <asp:BoundField DataField="firmaadi" HeaderText="firmaadi" SortExpression="firmaadi" />
                <asp:BoundField DataField="firmaadres" HeaderText="firmaadres" SortExpression="firmaadres" />
                <asp:BoundField DataField="firmatel" HeaderText="firmatel" SortExpression="firmatel" />
                <asp:BoundField DataField="firmafax" HeaderText="firmafax" SortExpression="firmafax" />
                <asp:BoundField DataField="ekle" HeaderText="ekle" SortExpression="ekle" />
                <asp:BoundField DataField="degistir" HeaderText="degistir" SortExpression="degistir" />
                <asp:BoundField DataField="herksesigor" HeaderText="herksesigor" SortExpression="herksesigor" />
                <asp:BoundField DataField="herkesidegistir" HeaderText="herkesidegistir" SortExpression="herkesidegistir" />
                <asp:BoundField DataField="baskasirandevuver" HeaderText="baskasirandevuver" SortExpression="baskasirandevuver" />
            </Columns>
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="App_Data\Genel.mdb" DeleteCommand="DELETE FROM `sifre` WHERE `sid` = ?" InsertCommand="INSERT INTO `sifre` (`sid`, `kullanici`, `sifre`, `adi`, `soyadi`, `firmaadi`, `firmaadres`, `firmatel`, `firmafax`, `ekle`, `degistir`, `herksesigor`, `herkesidegistir`, `baskasirandevuver`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" SelectCommand="SELECT `sid`, `kullanici`, `sifre`, `adi`, `soyadi`, `firmaadi`, `firmaadres`, `firmatel`, `firmafax`, `ekle`, `degistir`, `herksesigor`, `herkesidegistir`, `baskasirandevuver` FROM `sifre`" UpdateCommand="UPDATE `sifre` SET `kullanici` = ?, `sifre` = ?, `adi` = ?, `soyadi` = ?, `firmaadi` = ?, `firmaadres` = ?, `firmatel` = ?, `firmafax` = ?, `ekle` = ?, `degistir` = ?, `herksesigor` = ?, `herkesidegistir` = ?, `baskasirandevuver` = ? WHERE `sid` = ?">
            <DeleteParameters>
                <asp:Parameter Name="sid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="kullanici" Type="String" />
                <asp:Parameter Name="sifre" Type="String" />
                <asp:Parameter Name="adi" Type="String" />
                <asp:Parameter Name="soyadi" Type="String" />
                <asp:Parameter Name="firmaadi" Type="String" />
                <asp:Parameter Name="firmaadres" Type="String" />
                <asp:Parameter Name="firmatel" Type="String" />
                <asp:Parameter Name="firmafax" Type="String" />
                <asp:Parameter Name="ekle" Type="String" />
                <asp:Parameter Name="degistir" Type="String" />
                <asp:Parameter Name="herksesigor" Type="String" />
                <asp:Parameter Name="herkesidegistir" Type="String" />
                <asp:Parameter Name="baskasirandevuver" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="kullanici" Type="String" />
                <asp:Parameter Name="sifre" Type="String" />
                <asp:Parameter Name="adi" Type="String" />
                <asp:Parameter Name="soyadi" Type="String" />
                <asp:Parameter Name="firmaadi" Type="String" />
                <asp:Parameter Name="firmaadres" Type="String" />
                <asp:Parameter Name="firmatel" Type="String" />
                <asp:Parameter Name="firmafax" Type="String" />
                <asp:Parameter Name="ekle" Type="String" />
                <asp:Parameter Name="degistir" Type="String" />
                <asp:Parameter Name="herksesigor" Type="String" />
                <asp:Parameter Name="herkesidegistir" Type="String" />
                <asp:Parameter Name="baskasirandevuver" Type="String" />
                <asp:Parameter Name="sid" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
    </form>
</body>
</html>
