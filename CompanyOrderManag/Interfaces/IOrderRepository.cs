using CompanyOrderManag.Models;

namespace CompanyOrderManag.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrder(int id);
        bool OrderExist(int id);
        bool CreateOrder(Order order);
        bool Save();
    }
}
