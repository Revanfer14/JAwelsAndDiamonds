<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleOrdersPage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.AdminPage.HandleOrdersPage" %>

<asp:Content ID="CSS" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/HandleOrdersPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <h1>Handle Orders</h1>
    <asp:GridView CssClass="gvOrders" ID="gvOrders" runat="server" AutoGenerateColumns="False" OnRowCommand="gvOrders_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
            <asp:TemplateField HeaderText="Action">
                <itemtemplate>
                    <asp:Button CssClass="btn" ID="btnConfirmPayment" runat="server" CommandName="ConfirmPayment" Text="Confirm Payment"
                        Visible='<%# Eval("TransactionStatus").ToString() == "Payment Pending" %>'
                        CommandArgument='<%# Eval("TransactionID") %>' />

                    <asp:Button CssClass="btn" ID="btnShipPackage" runat="server" CommandName="ShipPackage" Text="Ship Package"
                        Visible='<%# Eval("TransactionStatus").ToString() == "Shipment Pending" %>'
                        CommandArgument='<%# Eval("TransactionID") %>' />

                    <asp:Label CssClass="lbl" ID="lblWaiting" runat="server" Text="Waiting for user confirmation..."
                        Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                </itemtemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
