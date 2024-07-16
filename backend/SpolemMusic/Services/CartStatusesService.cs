using SpolemMusic.Data;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Data.Models;

namespace SpolemMusic.Server.Services
{
    public class CartStatusesService
    {
        private AppDBContext _context;

        public CartStatusesService(AppDBContext context) { _context = context; }

        public List<CartStatus> GetCartStatuses()
        {
            var cartStatuss = _context.CartStatuses.ToList();
            return cartStatuss;
        }

        public CartStatus AddCartStatus(CartStatusDTO cartStatus)
        {
            var _cartStatus = new CartStatus()
            {
                ClientId = cartStatus.ClientId,
                ProductId = cartStatus.ProductId,
            };
            _context.CartStatuses.Add(_cartStatus);
            _context.SaveChanges();

            return _cartStatus;
        }

        public void UpdateCartStatus(CartStatusDTO cartStatus, int id)
        {
            var _cartStatus = _context.CartStatuses.FirstOrDefault(c => c.Id == id);
            if (_cartStatus != null)
            {
                _cartStatus.ClientId = cartStatus.ClientId;
                _cartStatus.ProductId = cartStatus.ProductId;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteCartStatus(int id)
        {
            var _cartStatus = _context.CartStatuses.FirstOrDefault(c => c.Id == id);
            if (_cartStatus != null)
            {
                _context.CartStatuses.Remove(_cartStatus);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
