using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;

namespace MyRazorPagesWebApp.Pages.Products;

public class DetailModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public string Command;

    public async Task OnGet([FromServices] IProductService _productService)
    {
        Product = await _productService.GetProductAsync(ProductId);
    }

    public void OnGetDetail()
    {
        Command = "Detail";
    }

    public void OnGetEdit()
    {
        Command = "Edit";
    }

    public void OnPost() { }
}
