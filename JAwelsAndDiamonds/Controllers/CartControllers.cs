using JAwelsAndDiamonds.Handlers;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controllers
{
    public class CartControllers
    {
        public static void createNewCart(int userId, int jewelId)
        {
            CartHandlers.createNewCart(userId, jewelId);
        }

        public static List<dynamic> GetCartItems(int userId)
        {
            return CartHandlers.GetCartItems(userId);
        }

        public static void UpdateCartItemQuantity(int userId, int jewelId, int quantity)
        {
            CartHandlers.UpdateCartItemQuantity(userId, jewelId, quantity);
        }

        public static void RemoveCartItem(int userId, int jewelId)
        {
            CartHandlers.RemoveCartItem(userId, jewelId);
        }

        public static void ClearCart(int userId)
        {
            CartHandlers.ClearCart(userId);
        }

    }
}