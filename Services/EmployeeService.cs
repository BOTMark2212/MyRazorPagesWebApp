using Microsoft.EntityFrameworkCore;
using MyRazorPagesWebApp.Models;

namespace MyRazorPagesWebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(NorthwindContext context, ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateEmployeeAsync failed");
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteEmployeeAsync failed for id {Id}", id);
                return false;
            }
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ToListAsync();
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            var e = await _context.Employees.FindAsync(employee.EmployeeId);
            if (e == null) return false;

            // Update necessary fields
            e.FirstName = employee.FirstName;
            e.LastName = employee.LastName;
            e.Title = employee.Title;
            e.TitleOfCourtesy = employee.TitleOfCourtesy;
            e.BirthDate = employee.BirthDate;
            e.HireDate = employee.HireDate;
            e.Address = employee.Address;
            e.City = employee.City;
            e.Region = employee.Region;
            e.PostalCode = employee.PostalCode;
            e.Country = employee.Country;
            e.HomePhone = employee.HomePhone;
            e.Extension = employee.Extension;
            e.Notes = employee.Notes;
            e.ReportsTo = employee.ReportsTo;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateEmployeeAsync failed for id {Id}", employee.EmployeeId);
                return false;
            }
        }
    }
}
