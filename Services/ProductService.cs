using Microsoft.EntityFrameworkCore;
using MyRazorPagesWebApp.Models;

namespace MyRazorPagesWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(NorthwindContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateProductAsync failed");
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteProductAsync failed for id {Id}", id);
                return false;
            }
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<Product>> GetProductsAsync(int? catId)
        {
            var query = _context.Products.Include(p => p.Category).AsQueryable();
            if (catId.HasValue) query = query.Where(p => p.CategoryId == catId.Value);
            return await query.ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var p = await _context.Products.FindAsync(product.ProductId);
            if (p == null) return false;

            // Cập nhật các trường cần thiết
            p.ProductName = product.ProductName;
            p.CategoryId = product.CategoryId;
            p.UnitPrice = product.UnitPrice;
            p.UnitsOnOrder = product.UnitsOnOrder;
            p.UnitsInStock = product.UnitsInStock;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateProductAsync failed for id {Id}", product.ProductId);
                return false;
            }
        }
    }
}
