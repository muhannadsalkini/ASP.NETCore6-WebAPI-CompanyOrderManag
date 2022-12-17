using CompanyOrderManag.Data;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyOrderManag.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CreateOrder(int productId, int companyId, Order order)
        {
            var product = _context.Products.Where(p => p.Id == productId).FirstOrDefault();
            var company = _context.Companies.Where(c => c.Id == companyId).FirstOrDefault();

            var productData = new Product() // Inster into PokemonOwner tabel
            {
                Product = product,
            };

            _context.Add(productData);

            var companyData = new PokemonCategory()
            {
                Company = company,
            };

            _context.Add(companyData);

            _context.Add(order);

            return Save();
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.Id).ToList();
        }

        public bool OrderExist(int id)
        {
            return _context.Orders.Any(o => o.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
