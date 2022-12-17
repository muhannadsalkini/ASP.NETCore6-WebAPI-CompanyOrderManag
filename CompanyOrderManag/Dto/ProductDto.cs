using CompanyOrderManag.Models;

namespace CompanyOrderManag.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public ICollection<Company> Company { get; set; } // One To Many relationship
        public string Name { get; set; }
        public int Stok { get; set; }
        public int Price { get; set; }
    }
}
