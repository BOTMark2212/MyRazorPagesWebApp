using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPagesWebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        IEmployeeService _employeeService;
        [BindProperty]
        public Employee? Employee { get; set; }
        public string Message { set; get; } = string.Empty;

        public EditModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task OnGet(int EmployeeId)
        {
            Employee = await _employeeService.GetEmployeeAsync(EmployeeId);
        }

        public async Task OnPost()
        {
            if (Employee != null)
            {
                await _employeeService.UpdateEmployeeAsync(Employee);
                Message = "Update successful";
            }
        }
    }
}
