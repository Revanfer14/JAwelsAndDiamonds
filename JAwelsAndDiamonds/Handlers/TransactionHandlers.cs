using JAwelsAndDiamonds.Factories;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Handlers
{
    public class TransactionHandlers
    {
        public static List<TransactionHeader> GetTransactions()
        {
            return TransactionRepositories.GetTransactions();
        }

        public static bool CheckoutCart(int userId, string paymentMethod)
        {
            return TransactionRepositories.CheckoutCart(userId, paymentMethod);
        }

        public static List<TransactionHeader> GetUserTransaction(int userId)
        {
           return TransactionRepositories.GetUserTransaction(userId);
        }

        public static TransactionHeader GetTransactionById(int transactionId)
        {
            return TransactionRepositories.GetTransactionById(transactionId);
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            TransactionRepositories.UpdateTransactionStatus(transactionId, newStatus);
        }

        public static List<TransactionDetail> ShowTransactionDetail(int transactionId)
        {
            return TransactionRepositories.ShowTransactionDetail(transactionId);
        }

        public static List<TransactionHeader> GetUnfinishedTransaction()
        {
            return TransactionRepositories.GetUnfinishedTransaction();
        }
    }
}