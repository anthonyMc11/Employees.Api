using Employees.Application.DTOs;
using Employees.Application.Models;

namespace Employees.Application.Services;

public interface IEmployeeService
{
    Task<bool> CreateAsync(CreateEmployeeDto employee);

    Task<Employee?> GetEmployeeById(Guid id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}