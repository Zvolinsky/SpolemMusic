using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Server.Services;

namespace SpolemMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartStatusesController : ControllerBase
    {
        public CartStatusesService _cartStatusesService;

        public CartStatusesController(CartStatusesService cartStatusesService)
        {
            _cartStatusesService = cartStatusesService;
        }

        [HttpGet("get-cartStatuses")]
        public IActionResult GetCartStatuses()
        {
            var cartStatuses = _cartStatusesService.GetCartStatuses();
            return Ok(cartStatuses);
        }

        [HttpPost("add-cartStatus")]
        public IActionResult AddCartStatus([FromBody] CartStatusDTO cartStatus)
        {
            try
            {
                _cartStatusesService.AddCartStatus(cartStatus);
                return Created(nameof(AddCartStatus), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-cartStatus/{id}")]
        public IActionResult UpdateCartStatus([FromBody] CartStatusDTO cartStatus, int id)
        {
            _cartStatusesService.UpdateCartStatus(cartStatus, id);
            return Ok(cartStatus);
        }

        [HttpDelete("delete-cartStatus/{id}")]
        public IActionResult DeleteCartStatus(int id)
        {
            try
            {
                _cartStatusesService.DeleteCartStatus(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
