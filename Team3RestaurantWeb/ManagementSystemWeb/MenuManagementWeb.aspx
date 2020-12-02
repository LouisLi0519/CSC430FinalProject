<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuManagementWeb.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.MenuManagementWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Menu Management System<br />
        </div>
        <p>
            Menu List</p>
        <p>
&nbsp;<asp:Label ID="LblMenuID" runat="server" Text="MenuID"></asp:Label>
            <asp:DropDownList ID="DLMenuID" runat="server" AutoPostBack="True" DataSourceID="MenuIDDataSource" DataTextField="MenuID" DataValueField="MenuID" OnSelectedIndexChanged="DLMenuID_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="MenuIDDataSource" runat="server" SelectMethod="GetMenuIDAndType" TypeName="Team3Restaurant.ManagementSystem.MenuManagement"></asp:ObjectDataSource>
        </p>
        <asp:GridView ID="GVMenuDetail" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GVMenuDetail_SelectedIndexChanged" Width="591px">
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                <asp:BoundField DataField="ItemDesc" HeaderText="ItemDesc" SortExpression="ItemDesc" />
                <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" SortExpression="SalePrice" />
                <asp:BoundField DataField="EditDate" HeaderText="EditDate" SortExpression="EditDate" />
                <asp:TemplateField HeaderText="Modify">
                    <ItemTemplate>
                        <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("ItemID") %>' OnClick="Button3_Click" Text="Delete" />
                        <asp:Button ID="Button4" runat="server" CommandArgument='<%# Eval("ItemID") %>' OnClick="Button4_Click" Text="ChangePriceTo▼" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("ItemID") %>' Text="Delete" />
                <asp:Button ID="Button2" runat="server" Text="ChangePrice" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMenuDetails" TypeName="Team3Restaurant.ManagementSystem.MenuManagement">
            <SelectParameters>
                <asp:ControlParameter ControlID="DLMenuID" Name="menuID" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="466px">                                                                                     PriceChangeTo:</asp:TextBox>
        <asp:TextBox ID="TxtPrice" runat="server">none</asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    </form>
</body>
</html>
