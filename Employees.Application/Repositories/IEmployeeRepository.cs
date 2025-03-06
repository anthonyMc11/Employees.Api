using Employees.Application.Models;

namespace Employees.Application.Repositories;

public interface IEmployeeRepository
{
    Task<bool> CreateAsync(Employee employee);

    Task<Employee?> GetEmployeeById(Guid id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}