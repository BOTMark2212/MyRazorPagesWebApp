using MyRazorPagesWebApp.Models;

namespace MyRazorPagesWebApp.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
