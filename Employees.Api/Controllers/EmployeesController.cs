using Employees.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers;

public class EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger) : Controller
{

}