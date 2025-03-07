﻿using Employees.Api.Mapping;
using Employees.Application.Services;
using Employees.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers;

[ApiController]
public class EmployeesController(IEmployeeService employeeService) : Controller
{
    [HttpPost(ApiEndpoints.Employees.Create)]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request, CancellationToken token)
    {
        var employee = request.MapToEmployeeDto();
        var result = await employeeService.CreateAsync(employee);

        if (result)
        {
            var newEmployee = await employeeService.GetEmployeeById(employee.Id);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, newEmployee.MapToEmployeeResponse());
        }
        else
        {
            return new ConflictResult();
        }

        
    }

    [HttpGet(ApiEndpoints.Employees.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var employee = await employeeService.GetEmployeeById(id);
        if (employee is null)
        {
            return NotFound();
        }

        return Ok(employee.MapToEmployeeResponse());
    }

    [HttpGet(ApiEndpoints.Employees.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var employees = await employeeService.GetAllEmployeesAsync();
        
        return Ok(employees.MapToEmployeesResponse());
    }
}