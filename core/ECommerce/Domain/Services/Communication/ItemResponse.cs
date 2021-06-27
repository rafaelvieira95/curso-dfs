using System;
using System.Collections.Generic;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Services.Communication
{
    public class ItemResponse: BaseResponse
    {
        public Item Item { get; set; }
        
        public ItemResponse(string message, bool success, Item item) : base(message, success)
        {
            Item = item;
        }

        public ItemResponse(Item item) : this(String.Empty,true, item)
        {
            
        }

        public ItemResponse(string message) : this(message, false, null)
        {
            
        }
        
    }
}