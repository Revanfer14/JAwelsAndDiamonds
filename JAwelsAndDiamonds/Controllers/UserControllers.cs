using JAwelsAndDiamonds.Handlers;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace JAwelsAndDiamonds.Controllers
{
    public class UserControllers
    {
        public static string ValidateUserRegister(string email, string username, string password, string confirmPassword, string gender, DateTime birthdate)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return "Invalid email format.";
            }
            else if (UserHandlers.CheckEmailExists(email))
            {
                return "Email already registered.";
            }
            else if (username.Length < 3 || username.Length > 25)
            {
                return "Username must be between 3 and 25 characters.";
            }
            else if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,20}$"))
            {
                return "Password must be alphanumeric and 8 to 20 characters.";
            }
            else if (password != confirmPassword)
            {
                return "Confirm password must match the password.";
            }
            else if (gender != "Male" && gender != "Female")
            {
                return "Please select a valid gender.";
            }
            else if (birthdate >= new DateTime(2010, 1, 1))
            {
                return "Date of birth must be earlier than 01/01/2010.";
            }

            return null;
        }

        public static string Register(string email, string username, string password, string gender, DateTime dob)
        {
            return UserHandlers.RegisterUser(email, username, password, gender, dob);
        }

        public static string LoginUser(string email, string password, bool rememberMe, HttpSessionState session, HttpResponse response)
        {
            MsUser user = UserHandlers.LoginUser(email, password);

            if (user != null)
            {
                session["user"] = user;
                session["role"] = user.UserRole;
                session["username"] = user.UserName;

                if (rememberMe)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie", user.UserName);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    response.Cookies.Add(cookie);
                }

                return "success";
            }

            return "Invalid email or password.";
        }

        public static string UpdatePassword(MsUser user, string oldPassword, string newPassword, string confirmPassword)
        {
            if (user == null)
            {
                return "User not found.";
            }

            if (oldPassword != user.UserPassword)
            {
                return "Old password is incorrect.";
            }

            if (newPassword.Length < 8 || newPassword.Length > 25 || !Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]+$"))
            {
                return "New password must be 8–25 characters and alphanumeric.";
            }

            if (newPassword != confirmPassword)
            {
                return "Confirm password does not match new password.";
            }

            UserHandlers.ChangePassword(user.UserID, newPassword);
            return "success";
        }
    }

}