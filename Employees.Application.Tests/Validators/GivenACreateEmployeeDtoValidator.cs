using Employees.Application.Repositories;
using Employees.Application.Validators;
using Moq;

namespace Employees.Application.Tests.Validators
{
    public class GivenACreateEmployeeDtoValidator
    {
        private readonly CreateEmployeeDtoValidator _sut;
        private readonly Mock<IEmployeeRepository> _mockRepository = new();
        public GivenACreateEmployeeDtoValidator()
        {
            _sut = new(_mockRepository.Object);
        }

        [Fact]
        public async Task WhenAValidEmployeeDto_ThenValidateSuccessfully()
        {
            var validEmployeeDto = TestDataGenerator.CreateValidCreateEmployeeDto();
            var result = await _sut.ValidateAsync(validEmployeeDto);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task WhenAnEmailAddressExistsAndTheIdMatches_ThenValidateSuccessfully()
        {
            var existingEmployee = TestDataGenerator.CreateValidEmployee();
            var validEmployeeDto = TestDataGenerator.CreateValidCreateEmployeeDto(existingEmployee.Id);

            _mockRepository.Setup(prov => prov.GetEmployeeByEmail(existingEmployee.Email)).ReturnsAsync(existingEmployee);

            var result = await _sut.ValidateAsync(validEmployeeDto);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task WhenAnEmailAddressExistsAndTheIdDoNotMatches_ThenValidateFailure()
        {
            var existingEmployee = TestDataGenerator.CreateValidEmployee();
            var newEmployeeDto = TestDataGenerator.CreateValidCreateEmployeeDto();

            _mockRepository.Setup(prov => prov.GetEmployeeByEmail(existingEmployee.Email)).ReturnsAsync(existingEmployee);

            var result = await _sut.ValidateAsync(newEmployeeDto);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task WhenADOBIsInvalid_ThenValidateFailure()
        {
            var invalidDobEmployeeDto = TestDataGenerator.CreateInvalidDOBCreateEmployeeDto();
           
            var result = await _sut.ValidateAsync(invalidDobEmployeeDto);
            Assert.False(result.IsValid);
        }
    }
}