<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Team3 Restaurant</div>
        <asp:TextBox ID="TxtOrderID" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ReceiptDataSource">
            <ItemTemplate>
                ItemName:
                <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' />
                <br />
                Quantity:
                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                <br />
                Price:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                <br />
                Subtotal:
                <asp:Label ID="SubtotalLabel" runat="server" Text='<%# Eval("Subtotal") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ReceiptDataSource" runat="server" SelectMethod="GetReceipt" TypeName="Team3Restaurant.ManagementSystem.Receipt">
            <SelectParameters>
                <asp:QueryStringParameter Name="orderID" QueryStringField="orderID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="LblTotal" runat="server" Text="Total:$"></asp:Label>
        <asp:TextBox ID="TxtTotal" runat="server" ReadOnly="True"></asp:TextBox>
        <p>
            <asp:TextBox ID="TxtDateTime" runat="server" ReadOnly="True"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pay and Print Receipt" />
        <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
        <p>
            <asp:Button ID="BtnPrint" runat="server" OnClick="BtnPrint_Click" Text="Print(Go Back to Print System)" />
        </p>
    </form>
</body>
</html>
