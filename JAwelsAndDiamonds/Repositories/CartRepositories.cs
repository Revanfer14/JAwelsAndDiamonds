using JAwelsAndDiamonds.DatabaseSingleton;
using JAwelsAndDiamonds.Factories;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.Repositories
{
    public class CartRepositories
    {
        static DiamondEntitiesEntities1 db = DBSingleton.getInstance();
        public static void createNewCart(int userId, int jewelId)
        {
            var existingCart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);

            if (existingCart != null)
            {
                existingCart.Quantity += 1;
            }
            else
            {
                Cart newCart = CartFactories.createCart(userId, jewelId);
                db.Carts.Add(newCart);
            }
            db.SaveChanges();
        }

        public static List<dynamic> GetCartItems(int userId)
        {
            var cartData = from c in db.Carts
                           join j in db.MsJewels on c.JewelID equals j.JewelID
                           where c.UserID == userId
                           select new
                           {
                               c.JewelID,
                               j.JewelName,
                               j.JewelPrice,
                               j.MsBrand.BrandName,
                               c.Quantity,
                               Subtotal = j.JewelPrice * c.Quantity
                           };

            return cartData.ToList<dynamic>();
        }

        public static void UpdateCartItemQuantity(int userId, int jewelId, int quantity)
        {
            var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public static void RemoveCartItem(int userId, int jewelId)
        {
            var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }

        public static void ClearCart(int userId)
        {
            var userCart = db.Carts.Where(c => c.UserID == userId).ToList();
            db.Carts.RemoveRange(userCart);
            db.SaveChanges();
        }
    }
}