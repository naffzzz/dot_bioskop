using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrdersData _ordersData;

        public OrdersController(IOrdersData ordersData)
        {
            _ordersData = ordersData;
        }


        [HttpGet("/apiNew/orders")]
        public IActionResult getOrders()
        {
            return Ok(_ordersData.GetOrders());
        }

        [HttpGet("/apiNew/orderitems/{id}")]
        public IActionResult getOrderItem(int id)
        {
            var order = _ordersData.GetOrder(id);
            if (order != null)
            {
                return Ok(order);
            }

            return NotFound("Order tidak diketemukan");
        }

        [HttpPost("/apiNew/orders")]
        public IActionResult addOrderItem(orders order)
        {
            _ordersData.AddOrder(order);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + order.id, order);

        }

        [HttpDelete("/apiNew/orders/{id}")]
        public IActionResult deleteOrderItem(int id)
        {
            var order = _ordersData.GetOrder(id);

            if (order != null)
            {
                _ordersData.DeleteOrder(order);
                return Ok("Order berhasil dihapus");
            }

            return NotFound("Order tidak diketemukan");
        }

        [HttpPatch("/apiNew/orders/{id}")]
        public IActionResult updateOrderItem(int id, orders order)
        {
            var existingOder = _ordersData.GetOrder(id);

            if (existingOder != null)
            {
                order.id = existingOder.id;
                _ordersData.UpdateOrder(order);
            }
            return Ok(order);
        }
    }
}