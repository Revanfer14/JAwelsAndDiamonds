using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.DatabaseSingleton;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AuthControllers.IsUserAuthenticated())
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string email = emailTb.Text;
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            string confirmPassword = confirmTb.Text;
            string gender = genderRBL.SelectedValue;
            DateTime birthdate = dobCalendar.SelectedDate;

            string error = UserControllers.ValidateUserRegister(email, username, password, confirmPassword, gender, birthdate);
            if(error != null)
            {
                errorLbl.Text = error;
                errorLbl.Visible = true;
                return;
            }

            errorLbl.Visible = false;

            UserControllers.Register(email, username, password, gender, birthdate);
            Response.Redirect("~/Views/LoginPage.aspx");
        }

    }
}