using Employees.Application.DTOs;
using Employees.Application.Models;

namespace Employees.Application.Mapping;

public static class DtoMapping
{
    public static Employee MapToEmployee(this CreateEmployeeDto dto, int employeeNo)
    {
        return new Employee
        {
            EmployeeNo = employeeNo,
            Id = dto.Id,
            Title = dto.Title,
            Firstname = dto.Firstname,
            Surname = dto.Surname,
            DOB = dto.DOB,
            Gender = dto.Gender,
            Email = dto.Email,
            Address = dto.Email
        };
    }
}