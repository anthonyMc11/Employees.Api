using Employees.Application.Models;

namespace Employees.Application.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = [];

        public Task<bool> CreateAsync(Employee employee)
        {
            _employees.Add(employee);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult(_employees.AsEnumerable());
        }

        public Task<Employee?> GetEmployeeById(Guid id)
        {
            var employee = _employees.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(employee);
        }
    }

    public interface IEmployeeRepository
    {
        Task<bool> CreateAsync(Employee employee);

        Task<Employee?> GetEmployeeById(Guid id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
