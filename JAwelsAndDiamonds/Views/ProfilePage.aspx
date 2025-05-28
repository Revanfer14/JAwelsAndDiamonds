<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.ProfilePage" %>

<asp:Content ID="CSS" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ProfilePage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">    
    <a href="HomePage.aspx" class="btn back-btn">Back to Home</a>
    <h1>Profile</h1>
    <table class="details-table">
        <tr>
            <th>Name</th>
            <td>
                <asp:Label ID="lblName" runat="server" /></td>
        </tr>
        <tr>
            <th>Email</th>
            <td>
                <asp:Label ID="lblEmail" runat="server" /></td>
        </tr>
        <tr>
            <th>Date of Birth</th>
            <td>
                <asp:Label ID="lblDob" runat="server" /></td>
        </tr>
        <tr>
            <th>Gender</th>
            <td>
                <asp:Label ID="lblGender" runat="server" /></td>
        </tr>
        <tr>
            <th>Role</th>
            <td>
                <asp:Label ID="lblRole" runat="server" /></td>
        </tr>

        <%-- Change Password Form --%>
        <asp:Panel ID="passwordPanel" runat="server" Visible="false">
            <tr>
                <th>Old Password</th>
                <td>
                    <asp:TextBox CssClass="tb" ID="oldTb" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <th>New Password</th>
                <td>
                    <asp:TextBox CssClass="tb" ID="newTb" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <th>Confirm New Password</th>
                <td>
                    <asp:TextBox CssClass="tb" ID="confirmTb" runat="server" TextMode="Password" /></td>
            </tr>

            <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>
        </asp:Panel>
    </table>

    <div class="action-buttons" style="text-align: center; margin-top: 30px;">
        <asp:Button CssClass="cancelBtn" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" Visible="false" />
        <asp:Button CssClass="changeBtn" ID="changeBtn" runat="server" Text="Change Password" OnClick="changeBtn_Click" Visible="false" />
        <asp:Button CssClass="btn" ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" Visible="true" />
    </div>
</asp:Content>
