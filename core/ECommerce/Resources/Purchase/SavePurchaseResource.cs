using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Domain.Helpers;
using ECommerce.Domain.Models;
using ECommerce.Resources.Item;

namespace ECommerce.Resources.Purchase
{
    public  class SavePurchaseResource
    {
        [Required] 
        public double Price { get; set; }
        [Required]
        public EFormatOfPayment FormatOfPayment { get; set; }
        [Required]
        public EStatusPurchase StatusPurchase { get; set; }
        [MaxLength(255)]
        public string Observation { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Zip code invalid!")]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        public int UserId { get; set; }
        
        public IList<SaveItemResource> Items { get; set; }

    }
}