using System.Collections.Generic;

namespace ECommerce.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public IList<Purchase> Purchases { get; set; }
        
    }

}