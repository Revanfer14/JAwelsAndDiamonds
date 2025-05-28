<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Navbar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.CustomerPage.CartPage" %>

<asp:Content ID="CSS" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/CartPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <a href="../HomePage.aspx" class="btn back-btn">Back to Home</a>
    <h1>My Cart</h1>
    <asp:GridView CssClass="cart-gridview" ID="cartGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="cartGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="ID" />
            <asp:BoundField DataField="JewelName" HeaderText="Name" />
            <asp:BoundField DataField="BrandName" HeaderText="Brand" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="${0:N2}"
                HtmlEncode="true" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox CssClass="quantityTb" ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="${0:N2}"
                HtmlEncode="true" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" CssClass="grid-btn" runat="server" CommandName="UpdateItem" CommandArgument='<%# Eval("JewelID") %>' Text="Update" />
                    <asp:Button ID="btnRemove" CssClass="grid-btn remove-btn" runat="server" CommandName="RemoveItem" CommandArgument='<%# Eval("JewelID") %>' Text="Remove" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="error-label">
        <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>
    </div>

    <asp:Panel ID="panelBagianBawah" CssClass="bagian-bawah" runat="server" Visible="false">
        <div class="total-section">
            <div>
                Total:
            <asp:Label ID="lblTotal" runat="server" Text="$0.00" />
            </div>

            <div>
                Payment Method:
        <asp:DropDownList ID="paymentDropdown" runat="server">
            <asp:ListItem Text="Visa" Value="Visa" />
            <asp:ListItem Text="Paypal" Value="Paypal" />
            <asp:ListItem Text="Mastercard" Value="Mastercard" />
        </asp:DropDownList>
            </div>
        </div>

        <div class="action-buttons">
            <asp:Button ID="clearBtn" runat="server" CssClass="clearBtn" Text="Clear Cart" OnClick="clearBtn_Click" />
            <asp:Button ID="checkoutBtn" runat="server" CssClass="checkoutBtn" Text="Proceed to Checkout" OnClick="checkoutBtn_Click"/>
        </div>
    </asp:Panel>


</asp:Content>
