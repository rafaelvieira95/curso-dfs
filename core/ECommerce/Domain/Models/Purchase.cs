using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ECommerce.Domain.Helpers;

namespace ECommerce.Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public EFormatOfPayment FormatOfPayment { get; set; }
        public EStatusPurchase StatusPurchase { get; set; }
        public string Observation { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        
        [JsonIgnore] 
        public User User { get; set; }
        
        public int UserId { get; set; }
        public IList<Item> Items { get; set; }
       
    }
}