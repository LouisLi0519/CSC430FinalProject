<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPadManagementWeb.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.IPadManagementWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            IPad Management System</div>
        <asp:GridView ID="GVIPad" runat="server" AutoGenerateColumns="False" DataSourceID="IPadDataSource">
            <Columns>
                <asp:BoundField DataField="IPad" HeaderText="IPad" SortExpression="IPad" />
                <asp:BoundField DataField="Menu" HeaderText="Menu" SortExpression="Menu" />
            </Columns>
        </asp:GridView>
        <asp:DropDownList ID="DLIPad" runat="server" DataSourceID="IPadDataSource" DataTextField="IPad" DataValueField="IPad">
        </asp:DropDownList>
        <asp:DropDownList ID="DLMenu" runat="server" DataSourceID="MenuDataSource" DataTextField="Menu" DataValueField="Menu" OnSelectedIndexChanged="DLMenu_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="MenuDataSource" runat="server" SelectMethod="GetAllIMenus" TypeName="Team3Restaurant.ManagementSystem.IPadManagement"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="IPadDataSource" runat="server" SelectMethod="GetIPadDetail" TypeName="Team3Restaurant.ManagementSystem.IPadManagement"></asp:ObjectDataSource>
        <asp:Button ID="BtnApply" runat="server" OnClick="BtnApply_Click" Text="Apply" />
        <p>
            <asp:Button ID="BtnBackToMain" runat="server" OnClick="BtnBackToMain_Click" Text="BackToMain" />
        </p>
    </form>
</body>
</html>
