using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPagesWebApp.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        IEmployeeService _employeeService;
        public Employee? Employee { get; set; }
        public string Message { set; get; } = string.Empty;

        public DeleteModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task OnGet(int EmployeeId)
        {
            Employee = await _employeeService.GetEmployeeAsync(EmployeeId);
        }

        public async Task<IActionResult> OnPost(int EmployeeId)
        {
            var result = await _employeeService.DeleteEmployeeAsync(EmployeeId);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            Message = "Delete failed";
            return Page();
        }
    }
}
