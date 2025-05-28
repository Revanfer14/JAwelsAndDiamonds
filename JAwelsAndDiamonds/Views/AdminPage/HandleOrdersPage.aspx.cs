using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views.AdminPage
{
    public partial class HandleOrdersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(AuthControllers.IsAdmin())
                {
                    refreshGrid();
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void refreshGrid()
        {
            gvOrders.DataSource = TransactionControllers.GetUnfinishedTransaction();
            gvOrders.DataBind();
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "ConfirmPayment")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                TransactionControllers.UpdateTransactionStatus(transactionId, "Shipment Pending");
            } else if (e.CommandName == "ShipPackage")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                TransactionControllers.UpdateTransactionStatus(transactionId, "Arrived");
            }

            refreshGrid();
        }
    }
}