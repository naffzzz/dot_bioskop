using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Interfaces;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Datas
{
    public class SqlOrderItemsData : IOrderItemsData
    {
        private MyDBContext _myDBContext;

        public SqlOrderItemsData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public order_items AddOrderItem(order_items order_item)
        {
            _myDBContext.order_items.Add(order_item);
            _myDBContext.SaveChanges();
            return order_item;
        }

        public void DeleteOrderItem(order_items order_item)
        {
            _myDBContext.order_items.Remove(order_item);
            _myDBContext.SaveChanges();
        }

        public order_items GetOrderItem(int id)
        {
            var order_item = _myDBContext.order_items.Find(id);
            return order_item;
        }

        public List<order_items> GetOrderItems()
        {
            return _myDBContext.order_items.ToList();
        }
        public order_items SoftDeleteOrderItem(order_items order_item)
        {
            var existingOrderItem = _myDBContext.order_items.Find(order_item.id);
            if (existingOrderItem != null)
            {
                existingOrderItem.deleted_at = order_item.deleted_at;
                _myDBContext.order_items.Update(existingOrderItem);
                _myDBContext.SaveChanges();
            }
            return order_item;
        }

        public order_items UpdateOrderItem(order_items order_item)
        {
            var existingOrderItem = _myDBContext.order_items.Find(order_item.id);
            if(existingOrderItem != null)
            {
                existingOrderItem.order_id = order_item.order_id;
                existingOrderItem.movie_schedule_id = order_item.movie_schedule_id;
                existingOrderItem.qty = order_item.qty;
                existingOrderItem.price = order_item.price;
                existingOrderItem.sub_total_price = order_item.sub_total_price;
                existingOrderItem.updated_at = order_item.updated_at;
                _myDBContext.order_items.Update(existingOrderItem);
                _myDBContext.SaveChanges();
            }
            return order_item;
        }
    }
}
