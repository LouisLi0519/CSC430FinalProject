<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainScreenWeb.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.MainScreenWeb.MainScreenWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Team3 Restaurant Management System&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblStuff" runat="server" Text="Stuff"></asp:Label>
        <asp:TextBox ID="TxtStuffID" runat="server" OnTextChanged="StuffID_TextChanged"></asp:TextBox>
        <asp:Button ID="BtnLogout" runat="server" OnClick="BtnLogout_Click" Text="Logout" />
        <br />
        <br />
        <asp:LinkButton ID="LBIPadManagment" runat="server" OnClick="LBIPadManagment_Click">IPadManagment</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LBMenuMagament" runat="server" OnClick="LBMenuMagament_Click">MenuMagament</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LBOrderManagement" runat="server" OnClick="LBOrderManagement_Click">OrderManagement</asp:LinkButton>
        <p>
&nbsp;<asp:LinkButton ID="LBPaymentSystem" runat="server" OnClick="LBPaymentSystem_Click">PaymentSystem</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LBPrintSystem" runat="server" OnClick="LBPrintSystem_Click">PrintSystem</asp:LinkButton>
        </p>
    </form>
</body>
</html>
