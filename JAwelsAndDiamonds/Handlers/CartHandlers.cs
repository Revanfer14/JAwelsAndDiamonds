using JAwelsAndDiamonds.Factories;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Handlers
{
    public class CartHandlers
    {
        public static void createNewCart(int userId, int jewelId)
        {
            CartRepositories.createNewCart(userId, jewelId);
        }

        public static List<dynamic> GetCartItems(int userId)
        {
            return CartRepositories.GetCartItems(userId);
        }

        public static void UpdateCartItemQuantity(int userId, int jewelId, int quantity)
        {
            CartRepositories.UpdateCartItemQuantity(userId, jewelId, quantity);
        }

        public static void RemoveCartItem(int userId, int jewelId)
        {
            CartRepositories.RemoveCartItem(userId, jewelId);
        }

        public static void ClearCart(int userId)
        {
            CartRepositories.ClearCart(userId);
        }

    }
}