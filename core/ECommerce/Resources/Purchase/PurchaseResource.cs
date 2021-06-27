using System;
using System.Collections.Generic;
using ECommerce.Domain.Helpers;
using ECommerce.Resources.Item;


namespace ECommerce.Resources.Purchase
{
    public class PurchaseResource
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public EFormatOfPayment FormatOfPayment { get; set; }
        public EStatusPurchase StatusPurchase { get; set; }
        public string Observation { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        
    }
}