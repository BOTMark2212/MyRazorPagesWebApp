using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPagesWebApp.Pages.Products
{
    public class EditModel : PageModel
    {
        IProductService _productService;
        [BindProperty]
        public Product? Product { get; set; }
        public string Message { set; get; } = string.Empty;

        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet(int ProductId) //hien thi form + du lieu hien tai
        {
            Product = await _productService.GetProductAsync(ProductId);
        }

        public async Task OnPost() //cap nhat thong tin product
        {
            if (Product != null)
            {
                await _productService.UpdateProductAsync(Product);
                Message = "Cap nhat thanh cong";
            }
        }
    }
}
