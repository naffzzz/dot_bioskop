using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IOrdersData
    {
        List<orders> GetOrders();

        orders GetOrder(int id);

        orders AddOrder(orders order);

        orders UpdateOrder(orders order);

        void DeleteOrder(orders order);
    }
}
