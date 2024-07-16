using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Data.Models;
using SpolemMusic.Server.Services;

namespace SpolemMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("get-orders")]
        public IActionResult GetOrders()
        {
            var orders = _ordersService.GetOrders();
            return Ok(orders);
        }

        [HttpPost("add-order")]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {
            try
            {
                _ordersService.AddOrder(order);
                return Created(nameof(AddOrder), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-order/{id}")]
        public IActionResult UpdateOrder([FromBody] Order order, int id)
        {
            _ordersService.UpdateOrder(order, id);
            return Ok(order);
        }

        [HttpDelete("delete-order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _ordersService.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
