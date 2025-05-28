using JAwelsAndDiamonds.DatabaseSingleton;
using JAwelsAndDiamonds.Factories;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace JAwelsAndDiamonds.Repositories
{
    public class TransactionRepositories
    {
        static DiamondEntitiesEntities1 db = DBSingleton.getInstance();

        public static List<TransactionHeader> GetTransactions()
        {
            return db.TransactionHeaders.ToList();
        }

        public static bool CheckoutCart(int userId, string paymentMethod)
        {
            var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
            if (cartItems == null || !cartItems.Any()) return false;

            TransactionHeader transHeader = TransactionFactories.createTransactionHeader(userId, paymentMethod);
            db.TransactionHeaders.Add(transHeader);
            db.SaveChanges();

            foreach (var item in cartItems)
            {
                TransactionDetail transDetail = TransactionFactories.createTransactionDetail(transHeader.TransactionID, item.JewelID, item.Quantity);
                db.TransactionDetails.Add(transDetail);
            }

            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();

            return true;
        }

        public static List<TransactionHeader> GetUserTransaction(int userId)
        {
            return db.TransactionHeaders
                .Where(t => t.UserID == userId)
                .OrderBy(t => t.TransactionID)
                .ToList();
        }

        public static TransactionHeader GetTransactionById(int transactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            var transaction = db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = newStatus;
                db.SaveChanges();
            }
        }

        public static List<TransactionDetail> ShowTransactionDetail(int transactionId)
        {
            return db.TransactionDetails
                .Where(td => td.TransactionID == transactionId)
                .ToList();
        }

        public static List<TransactionHeader> GetUnfinishedTransaction()
        {
            return db.TransactionHeaders.Where(t => t.TransactionStatus != "Done" && t.TransactionStatus != "Rejected").ToList();
        }
    }
}