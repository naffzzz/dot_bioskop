using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private List<order_items> _orderItemsItem;

        public OrderItemsService()
        {
            _orderItemsItem = new List<order_items>();
        }

        public List<order_items> GetOrderItems()
        {
            return _orderItemsItem;
        }

        public order_items AddOrderItems(order_items order_item)
        {
            _orderItemsItem.Add(order_item);
            return order_item;
        }

        public order_items UpdateOrderItems(int id, order_items order_item)
        {
            for (var index = _orderItemsItem.Count - 1; index >= 0; index--)
            {
                if (_orderItemsItem[index].id == id)
                {
                    _orderItemsItem[index] = order_item;
                }
            }
            return order_item;
        }

        public string DeleteOrderItems(int id)
        {
            for (var index = _orderItemsItem.Count - 1; index >= 0; index--)
            {
                if (_orderItemsItem[index].id == id)
                {
                    _orderItemsItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
