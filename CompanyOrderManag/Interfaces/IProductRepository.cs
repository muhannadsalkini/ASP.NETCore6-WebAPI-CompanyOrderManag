using CompanyOrderManag.Models;

namespace CompanyOrderManag.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        bool ProductExist(int id);
        bool CreateProduct(Product product);
        bool Save();
    }
}
