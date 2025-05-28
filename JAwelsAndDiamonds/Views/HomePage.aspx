<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.HomePage" %>

<asp:Content ID="CSS" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/HomePage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <h1>JAwels & Diamonds</h1>
    <asp:GridView CssClass="jewel-grid" ID="jewelGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="jewelGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="ID" SortExpression="JewelID" />
            <asp:BoundField DataField="JewelName" HeaderText="Name" SortExpression="JewelName" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" SortExpression="JewelPrice" DataFormatString="${0:N2}"
                HtmlEncode="true" />
            <asp:ButtonField ButtonType="Button" CommandName="ViewDetails" HeaderText="View Details" ShowHeader="True" Text="View Details" />
        </Columns>
    </asp:GridView>
</asp:Content>

