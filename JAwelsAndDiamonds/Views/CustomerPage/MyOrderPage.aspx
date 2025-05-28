<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="MyOrderPage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.CustomerPage.MyOrderPage" %>

<asp:Content ID="CSS" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/MyOrdersPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <h1>My Orders</h1>
    <asp:GridView CssClass="orderpage-gridview" ID="orderpageGv" runat="server" AutoGenerateColumns="False" OnRowCommand="orderpageGv_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <div class="btn-container">
                        <asp:LinkButton CssClass="grid-btn view-btn" ID="btnView" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>'>View Details</asp:LinkButton>
                        
                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Package"
                            CssClass="grid-btn"
                            Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>'
                            CommandName="Confirm"
                            CommandArgument='<%# Eval("TransactionID") %>' />

                        <asp:Button ID="btnReject" runat="server" Text="Reject Package"
                            CssClass="grid-btn reject-btn"
                            Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>'
                            CommandName="Reject"
                            CommandArgument='<%# Eval("TransactionID") %>' />
                        <div />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
