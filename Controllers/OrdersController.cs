using dot_bioskop.Models;
using dot_bioskop.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using dot_bioskop.Datas;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger _logger;
        private MyDBContext _myDBContext;

        public OrdersController(ILogger<OrdersController> logger, MyDBContext myDBContext)
        {
            _logger = logger;
            _myDBContext = myDBContext;
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("/apiNew/orders")]
        public IActionResult GetOrders()
        {
            var _ordersData = new SqlOrdersData(_myDBContext);
            _logger.LogInformation("Log accessing all orders data");
            return Ok(_ordersData.GetOrders());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("/apiNew/orders/{id}")]
        public IActionResult GetOrderItem(int id)
        {
            var _ordersData = new SqlOrdersData(_myDBContext);
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

        [Authorize(Roles = "1, 2")]
        [HttpPost("/apiNew/orders")]
        public IActionResult AddOrderItem(orders order)
        {
            var _ordersData = new SqlOrdersData(_myDBContext);
            OrdersValidation Obj = new OrdersValidation();
            order.created_at = DateTime.Now;
            ValidationResult Result = Obj.Validate(order);
            if (Result.IsValid)
            {
                _logger.LogInformation("Log adding orders data");
                _ordersData.AddOrder(order);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + order.id, order);
            }
            else
            {
                return BadRequest(Result);
            }
        }


        [Authorize(Roles = "1, 2")]
        [HttpDelete("/apiNew/orders/{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            var _ordersData = new SqlOrdersData(_myDBContext);
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

        [Authorize(Roles = "1, 2")]
        [HttpPatch("/api/orders/{id}")]
        public IActionResult SoftDeleteOrderItem(int id)
        {
            var _ordersData = new SqlOrdersData(_myDBContext);
            var existingOder = _ordersData.GetOrder(id);

            if (existingOder != null)
            {
                existingOder.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified orders data (" + id + ")");
                _ordersData.SoftDeleteOrder(existingOder);
                return Ok("Order berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified orders data (" + id + ")");
                return NotFound("Order tidak diketemukan");
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpPatch("/apiNew/orders/{id}")]
        public IActionResult UpdateOrderItem(int id, orders order)
        {
            var _ordersData = new SqlOrdersData(_myDBContext);
            var existingOder = _ordersData.GetOrder(id);

            if (existingOder != null)
            {
                order.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified orders data (" + id + ")");
                order.id = existingOder.id;
                _ordersData.UpdateOrder(order);
                return Ok("Order berhasil diperbarui");
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified orders data (" + id + ")");
                return NotFound("Order tidak diketemukan");
            }
        }
    }
}