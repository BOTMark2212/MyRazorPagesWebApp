using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorPagesWebApp.Models;
using MyRazorPagesWebApp.Services;

namespace MyRazorPagesWebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public List<Employee> Employees { get; set; }
        IEmployeeService _employeeService;
        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task OnGet()
        {
            Employees = await _employeeService.GetEmployeesAsync();
        }
    }
}
