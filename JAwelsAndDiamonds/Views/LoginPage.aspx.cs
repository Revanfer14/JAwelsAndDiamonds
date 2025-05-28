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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (AuthControllers.IsUserAuthenticated())
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTb.Text;
            string password = passwordTb.Text;
            bool remember = rememberMe.Checked;

            string result = UserControllers.LoginUser(email, password, remember, Session, Response);

            if (result == "success")
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                errorLbl.Text = result;
                errorLbl.Visible = true;
                return;
            }
        }
    }
}