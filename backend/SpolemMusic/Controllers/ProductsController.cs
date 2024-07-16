using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Server.Services;
using System.Reflection.Metadata.Ecma335;

namespace SpolemMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-products")]
        public IActionResult GetProducts() { 
            var products = _productsService.GetProducts();
            return Ok(products);
        }
        
        [HttpGet("get-products/{id}")]
        public IActionResult GetProductById(int id) { 
            var products = _productsService.GetProductById(id);
            return Ok(products);
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] ProductDTO product)
        {
            try
            {
                _productsService.AddProduct(product);
                return Created(nameof(AddProduct), "Utworzono");
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-product/{id}")]
        public IActionResult UpdateProduct([FromBody] ProductDTO product, int id) {
            _productsService.UpdateProduct(product, id);
            return Ok(product);
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productsService.DeleteProduct(id);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
