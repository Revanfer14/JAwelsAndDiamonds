<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="JewelDetailsPage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.JewelDetailsPage" %>


<asp:Content ID="CSS" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/JewelDetailsPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <a href="HomePage.aspx" class="btn back-btn">Back</a>
    <h1>Jewel Details</h1>
    <table class="details-table">
        <tr>
            <th>Name</th>
            <td>
                <asp:Label ID="lblName" runat="server" /></td>
        </tr>
        <tr>
            <th>Category</th>
            <td>
                <asp:Label ID="lblCategory" runat="server" /></td>
        </tr>
        <tr>
            <th>Brand</th>
            <td>
                <asp:Label ID="lblBrand" runat="server" /></td>
        </tr>
        <tr>
            <th>Country</th>
            <td>
                <asp:Label ID="lblCountry" runat="server" /></td>
        </tr>
        <tr>
            <th>Class</th>
            <td>
                <asp:Label ID="lblClass" runat="server" /></td>
        </tr>
        <tr>
            <th>Price</th>
            <td>
                <asp:Label ID="lblPrice" runat="server" /></td>
        </tr>
        <tr>
            <th>Release Year</th>
            <td>
                <asp:Label ID="lblYear" runat="server" /></td>
        </tr>
    </table>

    <div class="action-buttons" style="text-align: center; margin-top: 30px;">
        <asp:Button ID="btnAddToCart" runat="server" CssClass="btn" Text="Add to Cart" OnClick="btnAddToCart_Click" Visible="false" />
        <asp:Button ID="btnEdit" runat="server" CssClass="editbtn" Text="Edit" OnClick="btnEdit_Click" Visible="false" />
        <asp:Button ID="btnDelete" runat="server" CssClass="deletebtn" Text="Delete" OnClick="btnDelete_Click" Visible="false" />
    </div>
</asp:Content>


