﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderMenuWeb.aspx.cs" Inherits="Team3RestaurantWeb.OrderMenuWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <b>&nbsp;&nbsp;&nbsp;&nbsp; Team3 Restaurant</b></div>
        <asp:Label ID="LblIPadID" runat="server" Text="IPadID"></asp:Label>
            <b>
        <asp:TextBox ID="TxtIPadID" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </b>
        <asp:GridView ID="GVMenu" runat="server" AutoGenerateColumns="False" DataSourceID="MenuItemDataSource" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:TemplateField HeaderText="Quantity">  
                    <ItemTemplate>  
                        <asp:DropDownList ID="Quantity" runat="server"> 
                            <asp:ListItem Value ="0"></asp:ListItem>
                            <asp:ListItem Value ="1"></asp:ListItem>
                            <asp:ListItem Value ="2"></asp:ListItem>
                            <asp:ListItem Value ="3"></asp:ListItem>
                            <asp:ListItem Value ="4"></asp:ListItem>
                            <asp:ListItem Value ="5"></asp:ListItem>
                        </asp:DropDownList>  
                    </ItemTemplate>  
                </asp:TemplateField> 
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="MenuItemDataSource" runat="server" SelectMethod="ShowMenuItems" TypeName="Team3Restaurant.OrderSystem">
            <SelectParameters>
                <asp:Parameter DefaultValue="M100" Name="menuID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="BtnMakeOrder" runat="server" OnClick="BtnMakeOrder_Click" Text="Make Order" />
        <asp:Button ID="BtnClearOrder" runat="server" OnClick="BtnClearOrder_Click" Text="Clear" />
        <p>
            <asp:Button ID="BtnViewOrder" runat="server" OnClick="BtnViewOrder_Click" Text="ViewCurrentOrder" />
        </p>
    </form>
</body>
</html>
