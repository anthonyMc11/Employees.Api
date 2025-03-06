using Employees.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Application;

public static class ApplcationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}

