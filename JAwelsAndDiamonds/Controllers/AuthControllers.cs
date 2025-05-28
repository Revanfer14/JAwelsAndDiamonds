using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controllers
{
    public class AuthControllers
    {
        public static bool IsAdmin()
        {
            var role = HttpContext.Current.Session["role"]?.ToString();
            return role == "Admin";
        }

        public static bool IsCustomer()
        {
            var role = HttpContext.Current.Session["role"]?.ToString();
            return role == "Customer";
        }

        public static string GetUsername()
        {
            return HttpContext.Current.Session["username"]?.ToString();
        }
        public static bool IsUserAuthenticated()
        {
            return HttpContext.Current.Session["user"] != null || HttpContext.Current.Request.Cookies["user_cookies"] != null;
        }

    }
}