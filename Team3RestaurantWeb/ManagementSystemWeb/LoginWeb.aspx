<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWeb.aspx.cs" Inherits="Team3RestaurantWeb.LoginWeb.LoginWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 79px">
            Team3 Restaurant Management System<br />
            <br />
            <asp:Label ID="LblUserName" runat="server" Text="User"></asp:Label>
            <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
            <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />
        </div>
        <p>
            &nbsp;Designed by Team3&nbsp;</p>
    </form>
</body>
</html>
