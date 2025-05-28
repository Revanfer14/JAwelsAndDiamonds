using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views.CustomerPage
{
    public partial class MyOrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AuthControllers.IsCustomer())
                {
                    LoadOrders();
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void LoadOrders()
        {
            MsUser user = (MsUser)Session["user"];

            int userId = user.UserID;

            var orders = TransactionControllers.GetUserTransaction(userId);

            orderpageGv.DataSource = orders;
            orderpageGv.DataBind();
        }

        protected void orderpageGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect("~/Views/CustomerPage/TransactionDetailPage.aspx?id=" + transactionId);
            }
            else if (e.CommandName == "Confirm")
            {
                TransactionControllers.UpdateTransactionStatus(transactionId, "Done");
                LoadOrders();
            }
            else if (e.CommandName == "Reject")
            {
                TransactionControllers.UpdateTransactionStatus(transactionId, "Rejected");
                LoadOrders();
            }
        }
    }
}