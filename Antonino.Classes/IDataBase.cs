using System.Collections.Generic;

namespace Antonino.Classes
{
    public interface IDataBase
    {

        bool UpdateOrder(string id, OrderStatus status);

        IEnumerable<Order> GetAllOrders();

        Order GetOrder(string id);

        IEnumerable<Toy> GetAllToys();

        User GetUser(User user);
    }
}
