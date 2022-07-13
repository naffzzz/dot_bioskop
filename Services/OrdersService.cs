using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class OrdersService : IOrdersService
    {
        private List<orders> _ordersItem;

        public OrdersService()
        {
            _ordersItem = new List<orders>();
        }

        public List<orders> GetOrders()
        {
            return _ordersItem;
        }

        public orders AddOrders(orders order)
        {
            _ordersItem.Add(order);
            return order;
        }

        public orders UpdateOrders(int id, orders order)
        {
            for (var index = _ordersItem.Count - 1; index >= 0; index--)
            {
                if (_ordersItem[index].id == id)
                {
                    _ordersItem[index] = order;
                }
            }
            return order;
        }

        public string DeleteOrders(int id)
        {
            for (var index = _ordersItem.Count - 1; index >= 0; index--)
            {
                if (_ordersItem[index].id == id)
                {
                    _ordersItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
