using Microsoft.EntityFrameworkCore;
using MyRazorPagesWebApp.Models;

namespace MyRazorPagesWebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(NorthwindContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateOrderAsync failed");
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            try
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteOrderAsync failed for id {Id}", id);
                return false;
            }
        }

        public async Task<Order?> GetOrderAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var o = await _context.Orders.FindAsync(order.OrderId);
            if (o == null) return false;

            // Update necessary fields
            o.CustomerId = order.CustomerId;
            o.EmployeeId = order.EmployeeId;
            o.OrderDate = order.OrderDate;
            o.RequiredDate = order.RequiredDate;
            o.ShippedDate = order.ShippedDate;
            o.ShipVia = order.ShipVia;
            o.Freight = order.Freight;
            o.ShipName = order.ShipName;
            o.ShipAddress = order.ShipAddress;
            o.ShipCity = order.ShipCity;
            o.ShipRegion = order.ShipRegion;
            o.ShipPostalCode = order.ShipPostalCode;
            o.ShipCountry = order.ShipCountry;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateOrderAsync failed for id {Id}", order.OrderId);
                return false;
            }
        }
    }
}
