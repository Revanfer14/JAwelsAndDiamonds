using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factories
{
    public class UserFactories
    {
        public static MsUser createUser(string email, string username, string password, string gender, DateTime dob)
        {
            MsUser user = new MsUser();
            user.UserEmail = email;
            user.UserName = username;
            user.UserPassword = password;
            user.UserGender = gender;
            user.UserDOB = dob;
            user.UserRole = "Customer";
            return user;
        }
    }
}