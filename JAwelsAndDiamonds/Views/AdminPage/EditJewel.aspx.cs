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
    public partial class EditJewel : System.Web.UI.Page
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

                    string idParam = Request.QueryString["id"];

                    MsJewel jewel = JewelControllers.GetJewel(int.Parse(idParam));
                    nameTb.Text = jewel.JewelName;
                    brandDdl.SelectedValue = jewel.BrandID.ToString();
                    categoryDdl.SelectedValue = jewel.CategoryID.ToString();
                    priceTb.Text = jewel.JewelPrice.ToString();
                    yearTb.Text = jewel.JewelReleaseYear.ToString();

                    string currentClass = jewel.MsBrand.BrandClass;
                    string currentCountry = jewel.MsBrand.BrandCountry;

                    lblClass.Text = $"{currentClass}";
                    lblCountry.Text = $"{currentCountry}";

                    ViewState["JewelID"] = jewel.JewelID;
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            int jewelId = (int)ViewState["JewelID"];
            String name = nameTb.Text;
            int price = int.TryParse(priceTb.Text, out price) ? price : -1;
            int year = int.TryParse(yearTb.Text, out year) ? year : -1;
            int brand = Convert.ToInt32(brandDdl.SelectedValue);
            int category = Convert.ToInt32(categoryDdl.SelectedValue);

            if (JewelControllers.ValidateUpdateJewel(jewelId, name, price, year, brand, category, out string error))
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
            Response.Redirect("~/Views/JewelDetailsPage.aspx?id=" + ViewState["JewelID"]);
        }
    }
}