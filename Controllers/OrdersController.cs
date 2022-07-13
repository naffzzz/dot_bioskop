using dot_bioskop.DBContexts;
using dot_bioskop.Models;
using dot_bioskop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private ILogger _logger;
        private IOrdersService _ordersService;


        public OrdersController(ILogger<OrdersController> logger, IOrdersService ordersService)
        {
            _logger = logger;
            _ordersService = ordersService;
        }

        [HttpGet("/api/orders")]
        public ActionResult<List<orders>> GetOrders()
        {
            return _ordersService.GetOrders();
        }

        [HttpPost("/api/orders")]
        public ActionResult<orders> AddOrders(orders order)
        {
            _ordersService.AddOrders(order);
            return order;
        }

        [HttpPut("/api/orders/{id}")]
        public ActionResult<orders> UpdateOrders(int id, orders order)
        {
            _ordersService.UpdateOrders(id, order);
            return order;
        }

        [HttpDelete("/api/orders/{id}")]
        public ActionResult<string> DeleteOrders(int id)
        {
            _ordersService.DeleteOrders(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}