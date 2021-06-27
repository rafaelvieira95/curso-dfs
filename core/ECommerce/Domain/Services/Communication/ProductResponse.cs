using System;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Services.Communication
{
    public class ProductResponse: BaseResponse
    {
        public Product Product { get; private set; }
        
        public ProductResponse(string message, bool success, Product product) : base(message, success)
        {
            Product = product;
        }

        public ProductResponse(Product product) : this(String.Empty, true, product)
        {
            
        }

        public ProductResponse(string message) : this(message, false, null)
        {
            
        }
        
    }
}