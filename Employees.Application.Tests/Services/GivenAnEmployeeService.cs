using Employees.Application.DTOs;
using Employees.Application.Models;
using Employees.Application.Repositories;
using Employees.Application.Services;
using FluentValidation;
using Moq;

namespace Employees.Application.Tests.Services;

public class GivenAnEmployeeService
{
    private readonly EmployeeService _sut;
    private readonly Mock<IEmployeeRepository> _mockRepository = new();
    private readonly Mock<IValidator<CreateEmployeeDto>> _mockValdiator = new();


    public GivenAnEmployeeService()
    {
        _sut = new EmployeeService(_mockRepository.Object, _mockValdiator.Object);
    }

    [Fact]
    public async Task WhenACreateRequestIsReceivedAndTheValidationFails_ThenExceptionIsThrown()
    {
        _mockValdiator.Setup(x => x.ValidateAsync(It.IsAny<IValidationContext>(),It.IsAny<CancellationToken>()))
            .ThrowsAsync(new ValidationException("Something is wrong"));
        
        var employeeDto = TestDataGenerator.CreateValidCreateEmployeeDto();
        await Assert.ThrowsAsync<ValidationException>(() => _sut.CreateAsync(employeeDto)); 
    }

}
