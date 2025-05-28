using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factories
{
    public class TransactionFactories
    {
        public static TransactionHeader createTransactionHeader(int userId, string payment)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.UserID = userId;
            transactionHeader.TransactionDate = DateTime.Now;
            transactionHeader.PaymentMethod = payment;
            transactionHeader.TransactionStatus = "Payment Pending";
            return transactionHeader;
        }

        public static TransactionDetail createTransactionDetail(int transactionId, int jewelId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionId;
            transactionDetail.JewelID = jewelId;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}