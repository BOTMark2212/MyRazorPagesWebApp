using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;

namespace MyRazorPagesWebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        IEmployeeService _employeeService;

        [BindProperty]
        public Employee? Employee { get; set; }
        public string Message { set; get; } = string.Empty;

        public CreateModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Employee != null)
            {
                await _employeeService.CreateEmployeeAsync(Employee);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
