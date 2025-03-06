using Employees.Application.Models;
using Employees.Application.Repositories;
using FluentValidation;

namespace Employees.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IValidator<Employee> employeeValidator) : IEmployeeService
{
    public async Task<bool> CreateAsync(Employee employee)
    {
        await employeeValidator.ValidateAndThrowAsync(employee);
        return await employeeRepository.CreateAsync(employee);
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