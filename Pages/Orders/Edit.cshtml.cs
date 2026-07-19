using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPagesWebApp.Pages.Orders
{
    public class EditModel : PageModel
    {
        IOrderService _orderService;
        [BindProperty]
        public Order? Order { get; set; }
        public string Message { set; get; } = string.Empty;

        public EditModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGet(int OrderId)
        {
            Order = await _orderService.GetOrderAsync(OrderId);
        }

        public async Task OnPost()
        {
            if (Order != null)
            {
                await _orderService.UpdateOrderAsync(Order);
                Message = "Update successful";
            }
        }
    }
}
