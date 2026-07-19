using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;

namespace MyRazorPagesWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }
        IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet()
        {
            Products = await _productService.GetProductsAsync(null);
        }
    }
}
