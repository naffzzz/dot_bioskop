using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace dot_bioskop.Datas
{
    public class SqlOrdersData
    {
        private MyDBContext _myDBContext;

        public SqlOrdersData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public orders AddOrder(orders order)
        {
            _myDBContext.orders.Add(order);
            _myDBContext.SaveChanges();
            return order;
        }

        public void DeleteOrder(orders order)
        {
            _myDBContext.orders.Remove(order);
            _myDBContext.SaveChanges();
        }

        public orders GetOrder(int id)
        {
            var order = _myDBContext.orders.Where(b => b.id == id).Include(x => x.user).FirstOrDefault();
            return order;
        }

        public List<orders> GetOrders()
        {
            return _myDBContext.orders.Include(x => x.user).ToList();
        }

        public orders SoftDeleteOrder(orders order)
        {
            var existingOrder = _myDBContext.orders.Where(b => b.id == order.id).FirstOrDefault();
            if (existingOrder != null)
            {
                existingOrder.deleted_at = order.deleted_at;
                _myDBContext.orders.Update(existingOrder);
                _myDBContext.SaveChanges();
            }
            return order;
        }

        public orders UpdateOrder(orders order)
        {
            var existingOrder = _myDBContext.orders.Where(b => b.id == order.id).FirstOrDefault();
            if (existingOrder != null)
            {
                existingOrder.user_id = order.user_id;
                existingOrder.payment_method = order.payment_method;
                existingOrder.total_item_price = order.total_item_price;
                existingOrder.updated_at = order.updated_at;
                _myDBContext.orders.Update(existingOrder);
                _myDBContext.SaveChanges();
            }
            return order;
        }
    }
}
