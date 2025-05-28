using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views.AdminPage
{
    public partial class AddJewelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AuthControllers.IsAdmin())
                {
                    List<MsBrand> brandType = JewelControllers.GetBrands();
                    brandDdl.DataSource = brandType;
                    brandDdl.DataBind();

                    List<MsCategory> categoryType = JewelControllers.GetCategories();
                    categoryDdl.DataSource = categoryType;
                    categoryDdl.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            String name = nameTb.Text;
            int price = int.TryParse(priceTb.Text, out price) ? price : -1;
            int year = int.TryParse(yearTb.Text, out year) ? year : -1;
            int brand = Convert.ToInt32(brandDdl.SelectedValue);
            int category = Convert.ToInt32(categoryDdl.SelectedValue);

            if (JewelControllers.ValidateCreateJewel(name, price, year, brand, category, out string error))
            {
                errorLbl.Visible = false;
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                errorLbl.Text = error;
                errorLbl.Visible = true;
            }
        }
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}