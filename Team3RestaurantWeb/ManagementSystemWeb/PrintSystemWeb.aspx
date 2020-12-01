<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintSystemWeb.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.PrintSystemWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="margin-left: 40px">
            Print&nbsp;&nbsp;&nbsp; System</p>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="OrdersDataSource">
            <Columns>
                <asp:BoundField DataField="IpadID" HeaderText="IpadID" SortExpression="IpadID" />
                <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnPrint" runat="server" CommandArgument='<%# Eval("OrderID") %>' OnClick="BtnPrint_Click" Text="Print" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="OrdersDataSource" runat="server" SelectMethod="ShowAllOrders" TypeName="Team3Restaurant.ManagementSystem.PrintSystem"></asp:ObjectDataSource>
        <asp:Button ID="Btn" runat="server" OnClick="Btn_Click" Text="BackToMain" />
    </form>
</body>
</html>
