using Newtonsoft.Json;

namespace ECommerce.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        public Product Product { get; set; }
        public int ProductId { get; set; }
       
        [JsonIgnore]
        public Purchase Purchase { get; set; }
        public int PurchaseId { get; set; }
        
    }
}