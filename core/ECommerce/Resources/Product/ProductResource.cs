using System.Collections.Generic;
using System.Text.Json.Serialization;
using ECommerce.Resources.Item;

namespace ECommerce.Resources.Product
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Observation { get; set; }
        public string ImageUri { get; set; }
    }
}
