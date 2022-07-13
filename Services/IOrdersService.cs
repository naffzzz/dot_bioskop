using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IOrdersService
    {
        public List<orders> GetOrders();

        public orders AddOrders(orders order);

        public orders UpdateOrders(int id, orders order);

        public string DeleteOrders(int id);
    }
}
