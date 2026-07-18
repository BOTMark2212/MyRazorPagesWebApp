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

        public void OnGet(int ProductId) //hien thi form + du lieu hien tai
        {
            Product = _productService.GetProduct(ProductId);
        }

        public void OnPost() //cap nhat thong tin product
        {
            if (Product != null)
            {
                _productService.UpdateProduct(Product);
                Message = "Cap nhat thanh cong";
            }
        }
    }
}
