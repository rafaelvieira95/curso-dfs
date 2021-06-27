using System.Text.Json.Serialization;
using ECommerce.Resources.Product;

namespace ECommerce.Resources.Item
{
    public class ItemResource
    {
        public int Quantity { get; set; }
        public ProductResource Product { get; set; }
    }
}