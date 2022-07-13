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
    public class OrderItemsController : ControllerBase
    {
        private ILogger _logger;
        private IOrderItemsService _orderItemsService;


        public OrderItemsController(ILogger<OrderItemsController> logger, IOrderItemsService orderItemsService)
        {
            _logger = logger;
            _orderItemsService = orderItemsService;
        }

        [HttpGet("/api/orderitems")]
        public ActionResult<List<order_items>> GetOrderItems()
        {
            return _orderItemsService.GetOrderItems();
        }

        [HttpPost("/api/orderitems")]
        public ActionResult<order_items> AddOrderItems(order_items order_item)
        {
            _orderItemsService.AddOrderItems(order_item);
            return order_item;
        }

        [HttpPut("/api/orderitems/{id}")]
        public ActionResult<order_items> UpdateOrderItems(int id, order_items order_item)
        {
            _orderItemsService.UpdateOrderItems(id, order_item);
            return order_item;
        }

        [HttpDelete("/api/orderitems/{id}")]
        public ActionResult<string> DeleteOrderItems(int id)
        {
            _orderItemsService.DeleteOrderItems(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}