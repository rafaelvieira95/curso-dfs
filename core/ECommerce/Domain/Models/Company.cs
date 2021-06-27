using System.Collections.Generic;

namespace ECommerce.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public IList<Product> Products { get; set; }
    }
}