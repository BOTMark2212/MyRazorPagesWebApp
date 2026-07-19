using MyRazorPagesWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace MyRazorPagesWebApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly NorthwindContext _context;
        public CategoryService(NorthwindContext context) { _context = context; }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
