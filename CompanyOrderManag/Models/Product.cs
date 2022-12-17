using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CompanyOrderManag.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ICollection<Order> Order { get; set; } // One To Many relationship
        public string Name { get; set; }
        public int Stok { get; set; }
        public int Price { get; set; }
    }
}
