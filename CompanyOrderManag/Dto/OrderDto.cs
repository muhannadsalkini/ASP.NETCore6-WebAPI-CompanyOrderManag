using CompanyOrderManag.Models;

namespace CompanyOrderManag.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public ICollection<Company> Company { get; set; } // One To Many relationship
        public ICollection<Product> Product { get; set; } // One To Many relationship
        public string UserName { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
