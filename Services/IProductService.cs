using MyRazorPagesWebApp.Models;

namespace MyRazorPagesWebApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(int? catId);
        Task<Product?> GetProductAsync(int id);
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
