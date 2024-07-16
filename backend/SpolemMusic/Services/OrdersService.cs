using SpolemMusic.Data;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Data.Models;

namespace SpolemMusic.Server.Services
{
    public class OrdersService
    {
        private AppDBContext _context;

        public OrdersService(AppDBContext context) { _context = context; }

        public List<Order> GetOrders()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        public Order AddOrder(OrderDTO order)
        {
            var _order = new Order()
            {
                ClientId = order.ClientId,
                ProductIds = order.ProductIds,
                OrderDate = DateTime.Now,
                ExecutionDate = null,
                OrderReceived = false,
            };
            _context.Orders.Add(_order);
            _context.SaveChanges();

            return _order;
        }

        public void UpdateOrder(Order order, int id)
        {
            var _order = _context.Orders.FirstOrDefault(c => c.Id == id);
            if (_order != null)
            {
                _order.ClientId = order.ClientId;
                _order.ProductIds = order.ProductIds;
                _order.OrderDate = order.OrderDate;
                _order.ExecutionDate = order.ExecutionDate;
                _order.OrderReceived = order.OrderReceived;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteOrder(int id)
        {
            var _order = _context.Orders.FirstOrDefault(c => c.Id == id);
            if (_order != null)
            {
                _context.Orders.Remove(_order);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
