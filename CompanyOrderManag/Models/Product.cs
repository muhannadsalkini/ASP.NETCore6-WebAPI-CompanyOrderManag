using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CompanyOrderManag.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } // Product name
        public int Stok { get; set; }
        public int Price { get; set; }
        public ICollection<Order> Orders { get; set; } // Many relationship
        public Company Company { get; set; } // One relationship
    }
}
