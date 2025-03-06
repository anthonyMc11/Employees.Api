using Employees.Application.DTOs;
using Employees.Application.Models;
using Employees.Application.Repositories;
using FluentValidation;

namespace Employees.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IValidator<CreateEmployeeDto> employeeValidator) : IEmployeeService
{
    public async Task<bool> CreateAsync(CreateEmployeeDto employee)
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