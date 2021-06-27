using System.Collections.Generic;
using ECommerce.Resources.Purchase;

namespace ECommerce.Resources.User
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password {get; set;}
        public IList<PurchaseResource> Purchases { get; set; }
       
    }
}
