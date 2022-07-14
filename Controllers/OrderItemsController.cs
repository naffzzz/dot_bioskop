﻿using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private IOrderItemsData _orderItemsData;
        private readonly ILogger _logger;

        public OrderItemsController(ILogger<OrderItemsController> logger, IOrderItemsData orderItemsData)
        {
            _orderItemsData = orderItemsData;
            _logger = logger;
        }


        [HttpGet("/apiNew/orderitems")]
        public IActionResult getOrderItems()
        {
            _logger.LogInformation("Log accessing all order items data");
            return Ok(_orderItemsData.GetOrderItems());
        }

        [HttpGet("/apiNew/orderitems/{id}")]
        public IActionResult getOrderItem(int id)
        {
            var order_item = _orderItemsData.GetOrderItem(id);
            if (order_item != null)
            {
                _logger.LogInformation("Log accessing available specified order items data (" + id + ")");
                return Ok(order_item);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specified order items data (" + id + ")");
                return NotFound("Item order tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/orderitems")]
        public IActionResult addOrderItem(order_items order_item)
        {
            order_item.created_at = DateTime.Now;
            _logger.LogInformation("Log adding order items data");
            _orderItemsData.AddOrderItem(order_item);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + order_item.id, order_item);

        }

        [HttpDelete("/apiNew/orderitems/{id}")]
        public IActionResult deleteOrderItem(int id)
        {
            var order_item = _orderItemsData.GetOrderItem(id);

            if (order_item != null)
            {
                _logger.LogInformation("Log deleting available specified order items data (" + id + ")");
                _orderItemsData.DeleteOrderItem(order_item);
                return Ok("Item order berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified order items data (" + id + ")");
                return NotFound("Item order tidak diketemukan");
            }
        }

        [HttpPatch("/api/orderitems/{id}")]
        public IActionResult softDeleteOrderItem(int id, order_items order_item)
        {
            var existingOderItem = _orderItemsData.GetOrderItem(id);

            if (existingOderItem != null)
            {
                order_item.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified order items data (" + id + ")");
                order_item.id = existingOderItem.id;
                _orderItemsData.SoftDeleteOrderItem(order_item);
                return Ok("Item order berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified order items data (" + id + ")");
                return NotFound("Item order tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/orderitems/{id}")]
        public IActionResult updateOrderItem(int id, order_items order_item)
        {
            var existingOderItem= _orderItemsData.GetOrderItem(id);

            if (existingOderItem != null)
            {
                order_item.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified order items data (" + id + ")");
                order_item.id = existingOderItem.id;
                _orderItemsData.UpdateOrderItem(order_item);
                return Ok("Item order berhasil diperbarui");
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified order items data (" + id + ")");
                return NotFound("Item order tidak diketemukan");
            }
        }
    }
}