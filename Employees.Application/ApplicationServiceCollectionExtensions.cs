using Employees.Application.Repositories;
using Employees.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Application;

public static class ApplcationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<IEmployeeService, EmployeeService>();
        return services;
    }
}