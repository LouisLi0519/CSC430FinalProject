<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentSystem.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.PaymentSystem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Payment System<br />
        </div>
        <p>
            Finished Order List</p>
        <p>
            <asp:GridView ID="GVFinishedOrderList" runat="server" AutoGenerateColumns="False" DataSourceID="FinishedOrderDataSource">
                <Columns>
                    <asp:BoundField DataField="IpadID" HeaderText="IpadID" SortExpression="IpadID" />
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="BtnGenerateReceipt" runat="server" CommandArgument='<%# Eval("OrderID") %>' OnClick="LinkButton1_Click">Pay</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="FinishedOrderDataSource" runat="server" SelectMethod="ShowUnpaidOrders" TypeName="Team3Restaurant.ManagementSystem.OrderList"></asp:ObjectDataSource>
        </p>
        <asp:Button ID="BtnBackToMain" runat="server" OnClick="BtnBackToMain_Click" Text="BackToMain" />
    </form>
</body>
</html>
