namespace Employees.Contracts.Requests;

public class CreateEmployeeRequest
{
    public required string Title { get; init; }
    public required string Firstname { get; init; }
    public required string Surname { get; init; }
    public required DateOnly DOB { get; init; }
    public required string Gender { get; init; }
    public required string Email { get; init; }
    public required string Address { get; init; }
}
