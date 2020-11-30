<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCurrentOrderWeb.aspx.cs" Inherits="Team3RestaurantWeb.OrderSystem.ViewCurrentOrderWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Current Order<br />
            <br />
            <br />
            <asp:GridView ID="GVOrderList" runat="server" AutoGenerateColumns="False" DataSourceID="CurrentOrderSource" OnSelectedIndexChanged="GVOrderList_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="OrderNum" HeaderText="OrderNum" SortExpression="OrderNum" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="OrderTime" HeaderText="OrderTime" SortExpression="OrderTime" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="CurrentOrderSource" runat="server" SelectMethod="GetOrderList" TypeName="Team3Restaurant.OrderSystem">
                <SelectParameters>
                    <asp:QueryStringParameter Name="iPadID" QueryStringField="iPadID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Label ID="Label1" runat="server" Text="SelectToCancel"></asp:Label>
            <asp:DropDownList ID="DLCancelOrder" runat="server" OnSelectedIndexChanged="DLCancelOrder_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Button ID="BtnCancelOrder" runat="server" OnClick="BtnCancelOrder_Click" Text="CancelOrder" />
        </div>
        <asp:Button ID="BtnBackToMenu" runat="server" OnClick="BtnBackToMenu_Click" Text="BackToMenu" />
    </form>
</body>
</html>
