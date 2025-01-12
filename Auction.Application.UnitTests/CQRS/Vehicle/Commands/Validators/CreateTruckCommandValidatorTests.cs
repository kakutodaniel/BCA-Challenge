using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.CQRS.Vehicle.Commands.Validators;
using Auction.Application.Error;
using Auction.Tests.CrossCutting.Builders.Commands;
using FluentValidation;
using FluentValidation.TestHelper;

namespace Auction.Application.UnitTests.CQRS.Vehicle.Commands.Validators
{
    public class CreateTruckCommandValidatorTests : CreateVehicleCommandValidatorTests<CreateTruckCommand>
    {
        private readonly CreateTruckCommandValidator _validator;
        private readonly decimal _minLoadCapacity = 1;
        private readonly decimal _maxLoadCapacity = 10000;

        public CreateTruckCommandValidatorTests()
        {
            _validator = new CreateTruckCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_LoadCapacity_Is_Less_Than_1()
        {
            // Arrange
            var command = new CreateTruckCommandBuilder().WithLoadCapacity(0).Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.LoadCapacity)
                  .WithErrorMessage(string.Format(ErrorMessage.InclusiveBetween, "Load Capacity", _minLoadCapacity, _maxLoadCapacity));
        }

        [Fact]
        public void Should_Have_Error_When_LoadCapacity_Is_Greater_Than_10000()
        {
            // Arrange
            var command = new CreateTruckCommandBuilder().WithLoadCapacity(10001).Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.LoadCapacity)
                  .WithErrorMessage(string.Format(ErrorMessage.InclusiveBetween, "Load Capacity", _minLoadCapacity, _maxLoadCapacity));
        }

        [Fact]
        public void Should_Not_Have_Error_When_LoadCapacity_Is_Within_Range()
        {
            // Arrange
            var command = new CreateTruckCommandBuilder().Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.LoadCapacity);
        }

        protected override AbstractValidator<CreateTruckCommand> CreateValidator()
        {
            return new CreateTruckCommandValidator();
        }

        protected override CreateTruckCommand CreateVehicleCommand(string identifier = "identifier", string manufacturer = "manufacturer", string model = "model", int year = 2000, decimal startingBid = 12000)
        {
            return new CreateTruckCommandBuilder()
                        .WithIdentifier(identifier)
                        .WithManufacturer(manufacturer)
                        .WithModel(model)
                        .WithYear(year)
                        .WithStartingBid(startingBid)
                        .Build();
        }
    }
}
