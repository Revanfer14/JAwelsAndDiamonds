using JAwelsAndDiamonds.Controllers;
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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        protected void refreshGrid()
        {
            List<MsJewel> jewels = JewelControllers.GetJewels();
            jewelGridView.DataSource = jewels;
            jewelGridView.DataBind();
        }

        protected void jewelGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = jewelGridView.Rows[rowIndex];
                string jewelId = row.Cells[0].Text;

                Response.Redirect("~/Views/JewelDetailsPage.aspx?id=" + jewelId);
            }
        }
    }
}