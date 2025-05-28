using JAwelsAndDiamonds.Datasets;
using JAwelsAndDiamonds.Handlers;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controllers
{
    public class TransactionControllers
    {
        public static List<TransactionHeader> GetTransactions()
        {
            return TransactionHandlers.GetTransactions();
        }

        public static bool CheckoutCart(int userId, string paymentMethod)
        {
            return TransactionHandlers.CheckoutCart(userId, paymentMethod);
        }

        public static List<TransactionHeader> GetUserTransaction(int userId)
        {
            return TransactionHandlers.GetUserTransaction(userId);
        }

        public static TransactionHeader GetTransactionById(int transactionId)
        {
            return TransactionHandlers.GetTransactionById(transactionId);
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            TransactionHandlers.UpdateTransactionStatus(transactionId, newStatus);
        }

        public static List<TransactionDetail> ShowTransactionDetail(int transactionId)
        {
            return TransactionHandlers.ShowTransactionDetail(transactionId);
        }

        public static List<TransactionHeader> GetUnfinishedTransaction()
        {
            return TransactionHandlers.GetUnfinishedTransaction();
        }

        public static List<object> GetTransactionDetailDisplay(int transactionId)
        {
            var details = ShowTransactionDetail(transactionId);

            if (details == null || !details.Any()) return new List<object>();

            return details.Select(td => new
            {
                td.TransactionID,
                JewelName = td.MsJewel.JewelName,
                td.Quantity
            }).ToList<object>();
        }

        public static DataSet1 GetDoneTransactionsReport()
        {
            var allTransactions = GetTransactions();
            var doneTransactions = allTransactions.Where(t => t.TransactionStatus == "Done").ToList();

            DataSet1 data = new DataSet1();

            var header = data.TransactionHeader;
            var detail = data.TransactionDetail;

            foreach (TransactionHeader t in doneTransactions)
            {
                var hrow = header.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;
                header.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detail.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["JewelID"] = d.JewelID;
                    drow["Quantity"] = d.Quantity;

                    decimal price = d.MsJewel.JewelPrice;
                    drow["Subtotal"] = price * d.Quantity;

                    detail.Rows.Add(drow);
                }
            }

            return data;
        }

    }
}