using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factories
{
    public class CartFactories
    {
        public static Cart createCart(int UserID, int JewelID)
        {
            Cart cart = new Cart();
            cart.UserID = UserID;
            cart.JewelID = JewelID;
            cart.Quantity = 1;
            return cart;
        }
    }
}