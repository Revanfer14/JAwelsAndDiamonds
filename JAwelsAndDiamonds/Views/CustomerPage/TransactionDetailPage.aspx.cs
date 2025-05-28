using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views.CustomerPage
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idParam = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int transactionId))
                {
                    LoadTransactionDetail(transactionId);
                }
                else
                {
                    Response.Redirect("~/Views/CustomerPage/MyOrderPage.aspx");
                }
            }
        }

        private void LoadTransactionDetail(int transactionId)
        {
            var displayData = TransactionControllers.GetTransactionDetailDisplay(transactionId);

            gvTransactionDetails.DataSource = displayData.Any() ? displayData : null;
            gvTransactionDetails.DataBind();
        }
    }
}