using Employees.Application.DTOs;
using Employees.Application.Models;
using Employees.Contracts.Requests;
using Employees.Contracts.Responses;

namespace Employees.Api.Mapping;

public static class ContractMapping
{
    public static CreateEmployeeDto MapToEmployeeDto(this CreateEmployeeRequest request)
    {
        return new CreateEmployeeDto
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Firstname = request.Firstname,
            Surname = request.Surname,
            DOB = request.DOB,
            Gender = request.Gender,
            Email = request.Email,
            Address = request.Email
        };
    }

    public static EmployeeResponse MapToEmployeeResponse(this Employee employee)
    {
        return new EmployeeResponse
        {
            Id = employee.Id,
            EmployeeNo = employee.EmployeeNo,
            Title = employee.Title,
            Firstname = employee.Firstname,
            Surname = employee.Surname,
            DOB = employee.DOB,
            Gender = employee.Gender,
            Email = employee.Email,
            Address = employee.Email
        };
    }

    public static EmployeesResponse MapToEmployeesResponse(this IEnumerable<Employee> employees)
    {
        return new EmployeesResponse
        {
            Items = employees.Select(MapToEmployeeResponse)
        };
    }
}