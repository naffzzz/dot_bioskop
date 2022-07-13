using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private IOrderItemsData _orderItemsData;

        public OrderItemsController(IOrderItemsData orderItemsData)
        {
            _orderItemsData = orderItemsData;
        }


        [HttpGet("/apiNew/orderitems")]
        public IActionResult getOrderItems()
        {
            return Ok(_orderItemsData.GetOrderItems());
        }

        [HttpGet("/apiNew/orderitems/{id}")]
        public IActionResult getOrderItem(int id)
        {
            var order_item = _orderItemsData.GetOrderItem(id);
            if (order_item != null)
            {
                return Ok(order_item);
            }

            return NotFound("Item order tidak diketemukan");
        }

        [HttpPost("/apiNew/orderitems")]
        public IActionResult addOrderItem(order_items order_item)
        {
            _orderItemsData.AddOrderItem(order_item);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + order_item.id, order_item);

        }

        [HttpDelete("/apiNew/orderitems/{id}")]
        public IActionResult deleteOrderItem(int id)
        {
            var order_item = _orderItemsData.GetOrderItem(id);

            if (order_item != null)
            {
                _orderItemsData.DeleteOrderItem(order_item);
                return Ok("Item order berhasil dihapus");
            }

            return NotFound("Item order tidak diketemukan");
        }

        [HttpPatch("/apiNew/orderitems/{id}")]
        public IActionResult updateOrderItem(int id, order_items order_item)
        {
            var existingOderItem= _orderItemsData.GetOrderItem(id);

            if (existingOderItem != null)
            {
                order_item.id = existingOderItem.id;
                _orderItemsData.UpdateOrderItem(order_item);
            }
            return Ok(order_item);
        }
    }
}