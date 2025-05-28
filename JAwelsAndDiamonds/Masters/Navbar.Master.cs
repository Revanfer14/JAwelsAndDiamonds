using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Masters
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = AuthControllers.GetUsername();

            if (AuthControllers.IsCustomer())
            {   
                guestNavbar.Visible = false;
                customerNavbar.Visible = true;
                adminNavbar.Visible = false;

                currentUser.Text = $"Welcome, {username}!";
            }
            else if (AuthControllers.IsAdmin())
            {
                guestNavbar.Visible = false;
                customerNavbar.Visible = false;
                adminNavbar.Visible = true;

                currentAdmin.Text = $"Welcome, {username}!";
            } 
            else
            {
                guestNavbar.Visible = true;
                customerNavbar.Visible = false;
                adminNavbar.Visible = false;
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();

            if (Request.Cookies["user_cookie"] != null)
            {
                HttpCookie userCookie = new HttpCookie("user_cookie", "");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                userCookie.Value = null;
                Response.Cookies.Set(userCookie);
            }

            Response.Redirect("~/Views/HomePage.aspx", true);
        }

        protected void LoginBtnGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void CartBtnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CustomerPage/CartPage.aspx");
        }

        protected void OrdersBtnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CustomerPage/MyOrderPage.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void AddJewelBtnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminPage/AddJewelPage.aspx");
        }

        protected void ReportsBtnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminPage/ReportsPage.aspx");
        }

        protected void HandleOrderBtnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminPage/HandleOrdersPage.aspx");
        }

        protected void RegisterBtnGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}