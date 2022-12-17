using CompanyOrderManag.Models;

namespace CompanyOrderManag.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stok { get; set; }
        public int Price { get; set; }
    }
}
