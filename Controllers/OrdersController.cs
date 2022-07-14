using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrdersData _ordersData;
        private readonly ILogger _logger;

        public OrdersController(ILogger<OrdersController> logger, IOrdersData ordersData)
        {
            _ordersData = ordersData;
            _logger = logger;
        }


        [HttpGet("/apiNew/orders")]
        public IActionResult GetOrders()
        {
            _logger.LogInformation("Log accessing all orders data");
            return Ok(_ordersData.GetOrders());
        }

        [HttpGet("/apiNew/orderitems/{id}")]
        public IActionResult GetOrderItem(int id)
        {
            var order = _ordersData.GetOrder(id);
            if (order != null)
            {
                _logger.LogInformation("Log accessing available specified orders data (" + id + ")");
                return Ok(order);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specified orders data (" + id + ")");
                return NotFound("Order tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/orders")]
        public IActionResult AddOrderItem(orders order)
        {
            order.created_at = DateTime.Now;
            _logger.LogInformation("Log adding orders data");
            _ordersData.AddOrder(order);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + order.id, order);

        }

        [HttpDelete("/apiNew/orders/{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            var order = _ordersData.GetOrder(id);

            if (order != null)
            {
                _logger.LogInformation("Log deleting available specified orders data (" + id + ")");
                _ordersData.DeleteOrder(order);
                return Ok("Order berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified orders data (" + id + ")");
                return NotFound("Order tidak diketemukan");
            }
        }

        [HttpPatch("/api/orders/{id}")]
        public IActionResult SoftDeleteOrderItem(int id, orders order)
        {
            var existingOder = _ordersData.GetOrder(id);

            if (existingOder != null)
            {
                order.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified orders data (" + id + ")");
                order.id = existingOder.id;
                _ordersData.SoftDeleteOrder(order);
                return Ok(order);
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified orders data (" + id + ")");
                return NotFound("Order tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/orders/{id}")]
        public IActionResult UpdateOrderItem(int id, orders order)
        {
            var existingOder = _ordersData.GetOrder(id);

            if (existingOder != null)
            {
                order.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified orders data (" + id + ")");
                order.id = existingOder.id;
                _ordersData.UpdateOrder(order);
                return Ok(order);
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified orders data (" + id + ")");
                return NotFound("Order tidak diketemukan");
            }
        }
    }
}