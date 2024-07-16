using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class ReviewsService
    {
        private AppDBContext _context;

        public ReviewsService(AppDBContext context) { _context = context; }

        public List<Review> GetReviews()
        {
            var reviews = _context.Reviews.ToList();
            return reviews;
        }

        public Review AddReview(ReviewDTO review)
        {
            var _review = new Review()
            {
                Rate = review.Rate,
                Comment = review.Comment,
                ProductId = review.ProductId,
            };
            _context.Reviews.Add(_review);
            _context.SaveChanges();

            return _review;
        }

        public void UpdateReview(ReviewDTO review, int id)
        {
            var _review = _context.Reviews.FirstOrDefault(c => c.Id == id);
            if (_review != null)
            {
                _review.Rate = review.Rate;
                _review.Comment = review.Comment;
                _review.ProductId = review.ProductId;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteReview(int id)
        {
            var _review = _context.Reviews.FirstOrDefault(c => c.Id == id);
            if (_review != null)
            {
                _context.Reviews.Remove(_review);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
