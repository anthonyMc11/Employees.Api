using Employees.Application.Models;
using Employees.Application.Repositories;
using FluentValidation;
using Microsoft.VisualBasic;

namespace Employees.Application.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;

        RuleFor(e => e.Id)
            .NotEmpty();

        RuleFor(e => e.Title)
            .NotEmpty();

        RuleFor(e => e.Firstname)
            .NotEmpty();

        RuleFor(e => e.Surname)
            .NotEmpty();

        RuleFor(e => e.DOB)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Employee DOB must be in the past");

        RuleFor(e => e.Gender)
            .NotEmpty();

        RuleFor(e => e.Address)
            .NotEmpty();

        RuleFor(e => e.Email)
            .MustAsync(ValidateEmailAsync)
            .WithMessage("An employee with this email address already exists");
    }
    private async Task<bool> ValidateEmailAsync(Employee employee, string email, CancellationToken token = default)
    {
        var existingEmployee = await _employeeRepository.GetEmployeeByEmail(email);
        if (existingEmployee is not null)
        {
            return existingEmployee.Id == employee.Id;
        }
        return existingEmployee is null;
    }
}
