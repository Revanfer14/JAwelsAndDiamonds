<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="EditJewel.aspx.cs" Inherits="JAwelsAndDiamonds.Views.AdminPage.EditJewel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/EditJewelPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <h1>Edit Jewels</h1>
    <table class="details-table">
        <tr>
            <th>Name</th>
            <td>
                <asp:TextBox CssClass="tb" ID="nameTb" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Category</th>
            <td>
                <asp:DropDownList CssClass="ddl" ID="categoryDdl" DataValueField="CategoryID"
                    DataTextField="CategoryName"
                    AutoPostBack="false" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <th>Brand</th>
            <td>
                <asp:DropDownList CssClass="ddl" ID="brandDdl" DataValueField="BrandID"
                    DataTextField="BrandName"
                    AutoPostBack="false" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <th>Country</th>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="tes" /></td>
        </tr>
        <tr>
            <th>Class</th>
            <td>
                <asp:Label ID="lblClass" runat="server" Text="tes" /></td>
        </tr>
        <tr>
            <th>Price</th>
            <td>
                <asp:TextBox CssClass="tb" ID="priceTb" runat="server" /></td>
        </tr>
        <tr>
            <th>Release Year</th>
            <td>
                <asp:TextBox CssClass="tb" ID="yearTb" runat="server" /></td>
        </tr>
    </table>

    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>

    <div class="action-buttons" style="text-align: center; margin-top: 30px;">
        <asp:Button CssClass="cancelBtn" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
        <asp:Button CssClass="editBtn" ID="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click" />
    </div>
</asp:Content>
