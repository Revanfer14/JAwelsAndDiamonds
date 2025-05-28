using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Handlers
{
    public class UserHandlers
    {
        public static string RegisterUser(string email, string username, string password, string gender, DateTime dob)
        {
            UserRepositories.registerUser(email, username, password, gender, dob);
            return "Registration successful.";
        }

        public static bool CheckEmailExists(string email)
        {
            return UserRepositories.getUserEmail(email);
        }

        public static MsUser LoginUser(string email, string password)
        {
            return UserRepositories.validateUser(email, password);
        }

        public static string ChangePassword(int userId, string newPassword)
        {
            UserRepositories.changePassword(userId, newPassword);
            return "Password updated successfully.";
        }
    }

}