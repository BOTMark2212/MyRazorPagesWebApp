using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPagesWebApp.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        IOrderService _orderService;
        public Order? Order { get; set; }
        public string Message { set; get; } = string.Empty;

        public DeleteModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGet(int OrderId)
        {
            Order = await _orderService.GetOrderAsync(OrderId);
        }

        public async Task<IActionResult> OnPost(int OrderId)
        {
            var result = await _orderService.DeleteOrderAsync(OrderId);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            Message = "Delete failed";
            return Page();
        }
    }
}
