using Employees.Application.DTOs;
using Employees.Application.Models;

namespace Employees.Application.Repositories;

public interface IEmployeeRepository
{
    Task<bool> CreateAsync(CreateEmployeeDto employee);

    Task<Employee?> GetEmployeeById(Guid id);

    Task<Employee?> GetEmployeeByEmail(string email);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}