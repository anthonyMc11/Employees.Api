using Employees.Application.DTOs;
using Employees.Application.Models;

namespace Employees.Application.Tests;

public static class TestDataGenerator
{
    public static Employee CreateValidEmployee(Guid? id = null)
    {
        return new Employee
        {
            Title = "Mr",
            EmployeeNo = 1,
            Firstname = "John",
            Surname = "Doe",
            DOB = DateOnly.Parse("1985-01-01"),
            Email = "j.doe@email.com",
            Address = "Somewhere",
            Gender = "Male",
            Id = id ?? Guid.NewGuid()
        };
    }

    public static CreateEmployeeDto CreateValidCreateEmployeeDto(Guid? id = null)
    {
        return new CreateEmployeeDto
        {
            Title = "Mr",
            Firstname = "John",
            Surname = "Doe",
            DOB = DateOnly.Parse("1985-01-01"),
            Email = "j.doe@email.com",
            Address = "Somewhere",
            Gender = "Male",
            Id = id ?? Guid.NewGuid()
        };
    }

    public static CreateEmployeeDto CreateInvalidDOBCreateEmployeeDto(Guid? id = null)
    {
        return new CreateEmployeeDto
        {
            Title = "Mr",
            Firstname = "John",
            Surname = "Doe",
            DOB = DateOnly.Parse("3000-01-01"),
            Email = "j.doe@email.com",
            Address = "Somewhere",
            Gender = "Male",
            Id = id ?? Guid.NewGuid()
        };
    }
}
