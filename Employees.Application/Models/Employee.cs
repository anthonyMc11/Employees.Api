namespace Employees.Application.Models;

public class Employee
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Firstname { get; init; }
    public required string Surname { get; init; }
    public required DateOnly DOB { get; init; }
    public required string Gender { get; init; }
    public required string Email { get; init; }
    public required string Address { get; init; }
}