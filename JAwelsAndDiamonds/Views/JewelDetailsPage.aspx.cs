using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.DatabaseSingleton;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views
{
    public partial class JewelDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idParam = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int jewelId))
                {
                    LoadJewelDetails(jewelId);
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        private void LoadJewelDetails(int jewelId)
        {
            var jewel = JewelControllers.GetJewelDetails(jewelId);

            if (jewel != null)
            {
                lblName.Text = jewel.JewelName;
                lblCategory.Text = jewel.CategoryName;
                lblBrand.Text = jewel.BrandName;
                lblCountry.Text = jewel.Country;
                lblClass.Text = jewel.BrandClass;
                lblPrice.Text = $"${jewel.JewelPrice:0.00}";
                lblYear.Text = jewel.JewelReleaseYear.ToString();

                ViewState["JewelID"] = jewel.JewelID;
            }

            ShowButtonsBasedOnRole();
        }

        private void ShowButtonsBasedOnRole()
        {
            if (AuthControllers.IsCustomer())
            {
                btnAddToCart.Visible = true;
            }
            else if (AuthControllers.IsAdmin())
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;

            int jewelId = (int)ViewState["JewelID"];
            int userId = user.UserID;

            CartControllers.createNewCart(userId, jewelId);

            Response.Redirect("~/Views/CustomerPage/CartPage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int jewelId = (int)ViewState["JewelID"];

            JewelControllers.DeleteJewel(jewelId);

            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int jewelId = (int)ViewState["JewelID"];
            Response.Redirect("~/Views/AdminPage/EditJewel.aspx?id=" + jewelId);
        }

    }
}