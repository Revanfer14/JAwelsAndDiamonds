using JAwelsAndDiamonds.Controllers;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MsUser user = Session["user"] as MsUser;

                if (user != null)
                {
                    lblName.Text = user.UserName;
                    lblEmail.Text = user.UserEmail;
                    lblGender.Text = user.UserGender;
                    lblDob.Text = user.UserDOB.ToString("yyyy-MM-dd");
                    lblRole.Text = user.UserRole;
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }     

        protected void changeBtn_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;

            string oldPassword = oldTb.Text;
            string newPassword = newTb.Text;
            string confirmPassword = confirmTb.Text;

            string result = UserControllers.UpdatePassword(user, oldPassword, newPassword, confirmPassword);

            if(result == "success")
            {
                errorLbl.ForeColor = System.Drawing.Color.Green;
                errorLbl.Font.Bold = true;
                errorLbl.Text = "Password changed successfully!";
            } else
            {
                errorLbl.ForeColor = System.Drawing.Color.Red;
                errorLbl.Font.Bold = true;
                errorLbl.Text = result;
            }

            errorLbl.Visible = true;
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            passwordPanel.Visible = true;
            cancelBtn.Visible = true;
            changeBtn.Visible = true;
            btnChangePassword.Visible = false;
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            passwordPanel.Visible = false;
            cancelBtn.Visible = false;
            changeBtn.Visible = false;
            btnChangePassword.Visible = true;
        }
    }
}