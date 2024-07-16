using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public ReviewsService _reviewsService;

        public ReviewsController(ReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet("get-reviews")]
        public IActionResult GetReviews()
        {
            var reviews = _reviewsService.GetReviews();
            return Ok(reviews);
        }

        [HttpPost("add-review")]
        public IActionResult AddReview([FromBody] ReviewDTO review)
        {
            try
            {
                _reviewsService.AddReview(review);
                return Created(nameof(AddReview), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-review/{id}")]
        public IActionResult UpdateReview([FromBody] ReviewDTO review, int id)
        {
            _reviewsService.UpdateReview(review, id);
            return Ok(review);
        }

        [HttpDelete("delete-review/{id}")]
        public IActionResult DeleteReview(int id)
        {
            try
            {
                _reviewsService.DeleteReview(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
