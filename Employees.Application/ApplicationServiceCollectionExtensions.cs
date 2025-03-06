using Employees.Application.Repositories;
using Employees.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Application;

public static class ApplcationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<IEmployeeService, EmployeeService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }
}