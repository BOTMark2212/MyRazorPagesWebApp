using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPagesWebApp.Pages.Products;

public class DetailModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public string Command;

    public void OnGet([FromServices] IProductService _productService)
    {
        Product = _productService.GetProduct(ProductId);
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
