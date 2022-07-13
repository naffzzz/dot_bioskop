using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IOrderItemsService
    {
        public List<order_items> GetOrderItems();

        public order_items AddOrderItems(order_items order);

        public order_items UpdateOrderItems(int id, order_items order);

        public string DeleteOrderItems(int id);
    }
}
