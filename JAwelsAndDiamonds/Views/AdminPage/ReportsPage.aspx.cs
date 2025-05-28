using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Datasets;
using JAwelsAndDiamonds.Handlers;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Reports;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views.AdminPage
{
    public partial class ReportsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthControllers.IsAdmin())
            {
                TransactionsDone report = new TransactionsDone();

                DataSet1 data = TransactionControllers.GetDoneTransactionsReport();
                report.SetDataSource(data);

                CrystalReportViewer1.ReportSource = report;
            }

        }
    }
}