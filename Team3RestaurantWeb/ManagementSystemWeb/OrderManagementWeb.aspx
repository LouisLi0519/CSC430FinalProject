﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagementWeb.aspx.cs" Inherits="Team3RestaurantWeb.ManagementSystemWeb.OrderManagementWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 520px; margin-left: 280px">
            Order Management System&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnBackToMain" runat="server" OnClick="BtnBackToMain_Click" Text="BackToMain" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:GridView ID="GVOrderList" runat="server" AutoGenerateColumns="False" DataSourceID="OrderViewDataSource" OnSelectedIndexChanged="GVOrderList_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
                    <asp:BoundField DataField="IpadID" HeaderText="IpadID" SortExpression="IpadID" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="OrderTime" HeaderText="OrderTime" SortExpression="OrderTime" />

                    
                    <asp:TemplateField HeaderText="Modify Order">
                        <ItemTemplate>
                            <asp:Button ID="BtnViewOrder" runat="server" CommandArgument='<%# Eval("OrderID") %>' OnClick="BtnViewOrder_Click" Text="View" />
                            <asp:Button ID="BtnChangeStatus" runat="server" CommandArgument='<%# Eval("OrderID") %>' OnClick="BtnChangeStatus_Click" Text="ChangeStatusTo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <div>
            </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <asp:ObjectDataSource ID="OrderViewDataSource" runat="server" SelectMethod="GetOrderList" TypeName="Team3Restaurant.ManagementSystem.OrderManagement"></asp:ObjectDataSource>
        
        <div style="margin-left: 400px">
            <asp:DropDownList ID="DLOrderStatus" runat="server" Font-Bold="True" Font-Size="XX-Large">
                <asp:ListItem>Confirmed</asp:ListItem>
                <asp:ListItem>Received</asp:ListItem>
                <asp:ListItem>Finished</asp:ListItem>
                <asp:ListItem>Paid</asp:ListItem>
                <asp:ListItem>Cancelled</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div style="width: 525px; height: 146px; margin-left: 278px">
            <asp:GridView ID="GVOrderDetail" runat="server">
            </asp:GridView>
        </div>
        
        <p style="margin-left: 280px">
            &nbsp;</p>
        
    </form>
</body>
</html>
