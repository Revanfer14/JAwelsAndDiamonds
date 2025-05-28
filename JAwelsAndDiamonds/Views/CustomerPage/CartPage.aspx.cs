using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views.CustomerPage
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AuthControllers.IsCustomer())
                {   
                    LoadCart();
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void LoadCart()
        {
            MsUser user = Session["user"] as MsUser;
            int userId = user.UserID;

            var cartItems = CartControllers.GetCartItems(userId);

            if (cartItems != null && cartItems.Count > 0)
            {
                cartGridView.DataSource = cartItems;
                cartGridView.DataBind();

                decimal total = cartItems.Sum(item => item.Subtotal);
                lblTotal.Text = $"${total:N2}";

                errorLbl.Text = "";
                errorLbl.Visible = false;

                panelBagianBawah.Visible = true;
            }
            else
            {
                cartGridView.DataSource = null;
                cartGridView.DataBind();
                lblTotal.Text = "$0.00";

                errorLbl.Text = "Your cart is empty.";
                errorLbl.Visible = true;

                panelBagianBawah.Visible = false;
            }
        }

        protected void cartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateItem" || e.CommandName == "RemoveItem")
            {
                MsUser user = Session["user"] as MsUser;
                int userId = user.UserID;

                int jewelId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Control)e.CommandSource).NamingContainer as GridViewRow;

                if (e.CommandName == "UpdateItem")
                {
                    TextBox txtQty = (TextBox)row.FindControl("txtQuantity");
                    int newQty;             

                    if (int.TryParse(txtQty.Text, out newQty) && newQty > 0)
                    { 
                        CartControllers.UpdateCartItemQuantity(userId, jewelId, newQty);
                        errorLbl.Visible = false;
                        LoadCart();      
                    }
                    else
                    {
                        errorLbl.Text = "Invalid quantity. Please enter a positive number.";
                        errorLbl.Visible = true;
                        return;
                    }
                }
                else if (e.CommandName == "RemoveItem")
                {
                    CartControllers.RemoveCartItem(userId, jewelId);

                    LoadCart();
                }
            }
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            int userId = user.UserID;

            CartControllers.ClearCart(userId);
            LoadCart();
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            int userId = user.UserID;

            string paymentMethod = paymentDropdown.SelectedValue;
            
            bool checkoutSuccess = TransactionControllers.CheckoutCart(userId, paymentMethod);

            if(checkoutSuccess)
            {
                Response.Redirect("~/Views/CustomerPage/MyOrderPage.aspx");
            } else
            {
                errorLbl.Text = "Checkout failed. Please try again.";
                errorLbl.Visible = true;
                return;
            }
        }
    }
}