using Employees.Application.Models;

namespace Employees.Application.Tests;

public static class TestDataGenerator
{
    public static Employee CreateValidEmployee()
    {
        return new Employee
        {
            Title = "Mr",
            Firstname = "John",
            Surname = "Doe",
            DOB = DateOnly.Parse("1985-01-01"),
            Email = "j.doe@email.com",
            Address = "Somewhere",
            Gender = "Male",
            Id = Guid.NewGuid()
        };
    }

    public static Employee CreateInvalidDOBEmployee()
    {
        return new Employee
        {
            Title = "Mr",
            Firstname = "John",
            Surname = "Doe",
            DOB = DateOnly.Parse("3000-01-01"),
            Email = "j.doe@email.com",
            Address = "Somewhere",
            Gender = "Male",
            Id = Guid.NewGuid()
        };
    }

}
