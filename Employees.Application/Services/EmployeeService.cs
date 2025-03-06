using Employees.Application.Models;
using Employees.Application.Repositories;

namespace Employees.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public Task<bool> CreateAsync(Employee employee)
    {
        return employeeRepository.CreateAsync(employee);
    }

    public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return employeeRepository.GetAllEmployeesAsync();
    }

    public Task<Employee?> GetEmployeeById(Guid id)
    {
        return employeeRepository.GetEmployeeById(id);
    }
}