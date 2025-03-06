using Employees.Application.Repositories;
using Employees.Application.Validators;
using Moq;

namespace Employees.Application.Tests.Validators
{
    public class GivenAnEmployeeValidator
    {
        private readonly EmployeeValidator _sut;
        private readonly Mock<IEmployeeRepository> _mockRepository = new();
        public GivenAnEmployeeValidator()
        {
            _sut = new(_mockRepository.Object);
        }

        [Fact]
        public async Task WhenAValidEmployee_ThenValidateSuccessfully()
        {
            var validEmployee = TestDataGenerator.CreateValidEmployee();
            var result = await _sut.ValidateAsync(validEmployee);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task WhenAnEmailAddressExistsAndTheIdMatches_ThenValidateSuccessfully()
        {
            var validEmployee = TestDataGenerator.CreateValidEmployee();

            _mockRepository.Setup(prov => prov.GetEmployeeByEmail(validEmployee.Email)).ReturnsAsync(validEmployee);

            var result = await _sut.ValidateAsync(validEmployee);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task WhenAnEmailAddressExistsAndTheIdDoNotMatches_ThenValidateFailure()
        {
            var validEmployee = TestDataGenerator.CreateValidEmployee();
            var existingEmployee = TestDataGenerator.CreateValidEmployee();

            _mockRepository.Setup(prov => prov.GetEmployeeByEmail(validEmployee.Email)).ReturnsAsync(existingEmployee);

            var result = await _sut.ValidateAsync(validEmployee);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task WhenADOBIsInvalid_ThenValidateFailure()
        {
            var invalidDobEmployee = TestDataGenerator.CreateInvalidDOBEmployee();
           
            var result = await _sut.ValidateAsync(invalidDobEmployee);
            Assert.False(result.IsValid);
        }
    }
}
