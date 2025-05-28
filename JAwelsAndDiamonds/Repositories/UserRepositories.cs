using JAwelsAndDiamonds.DatabaseSingleton;
using JAwelsAndDiamonds.Factories;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repositories
{
    public class UserRepositories
    {
        static DiamondEntitiesEntities1 db = DBSingleton.getInstance();

        public static void registerUser(string email, string username, string password, string gender, DateTime dob)
        {
            MsUser user = UserFactories.createUser(email, username, password, gender, dob);
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public static Boolean getUserEmail(string email)
        {
            return db.MsUsers.Any(x => x.UserEmail == email) ? true : false;
        }

        public static MsUser validateUser(string email, string password)
        {
            return (from x in db.MsUsers where x.UserEmail.Equals(email) && x.UserPassword == password select x).FirstOrDefault();
        }

        public static void changePassword(int id, string password)
        {
            MsUser user = db.MsUsers.Find(id);
            user.UserPassword = password;
            db.SaveChanges();
        }
    }
}