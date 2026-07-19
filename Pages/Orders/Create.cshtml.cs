using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;

namespace MyRazorPagesWebApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        IOrderService _orderService;

        [BindProperty]
        public Order? Order { get; set; }
        public string Message { set; get; } = string.Empty;

        public CreateModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Order != null)
            {
                await _orderService.CreateOrderAsync(Order);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
