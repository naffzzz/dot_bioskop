using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IOrderItemsData
    {
        List<order_items> GetOrderItems();

        order_items GetOrderItem(int id);

        order_items AddOrderItem(order_items order_item);

        order_items UpdateOrderItem(order_items order_item);

        void DeleteOrderItem(order_items order_item);
    }
}
