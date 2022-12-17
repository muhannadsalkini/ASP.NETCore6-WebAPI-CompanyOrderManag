using CompanyOrderManag.Models;

namespace CompanyOrderManag.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrder(int id);
        bool OrderExist(int id);
        bool CreateOrder(int productId, int companyId, Order order);
        bool Save();
    }
}
