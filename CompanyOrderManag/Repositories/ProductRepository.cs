using CompanyOrderManag.Data;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyOrderManag.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CreateProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }

        public bool ProductExist(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
