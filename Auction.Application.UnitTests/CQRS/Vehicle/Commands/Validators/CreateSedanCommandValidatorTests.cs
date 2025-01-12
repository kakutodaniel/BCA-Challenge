using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.CQRS.Vehicle.Commands.Validators;
using Auction.Application.Error;
using Auction.Tests.CrossCutting.Builders.Commands;
using FluentValidation;
using FluentValidation.TestHelper;

namespace Auction.Application.UnitTests.CQRS.Vehicle.Commands.Validators
{
    public class CreateSedanCommandValidatorTests : CreateVehicleCommandValidatorTests<CreateSedanCommand>
    {
        private readonly CreateSedanCommandValidator _validator;
        private readonly int _minNumberOfDoors = 2;
        private readonly int _maxNumberOfDoors = 10;

        public CreateSedanCommandValidatorTests()
        {
            _validator = new CreateSedanCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_NumberOfDoors_Is_Less_Than_2()
        {
            // Arrange
            var command = new CreateSedanCommandBuilder().WithNumberOfDoors(1).Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.NumberOfDoors)
                  .WithErrorMessage(string.Format(ErrorMessage.InclusiveBetween, "Number Of Doors", _minNumberOfDoors, _maxNumberOfDoors));
        }

        [Fact]
        public void Should_Have_Error_When_NumberOfDoors_Is_Greater_Than_10()
        {
            // Arrange
            var command = new CreateSedanCommandBuilder().WithNumberOfDoors(11).Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.NumberOfDoors)
                  .WithErrorMessage(string.Format(ErrorMessage.InclusiveBetween, "Number Of Doors", _minNumberOfDoors, _maxNumberOfDoors));
        }

        [Fact]
        public void Should_Not_Have_Error_When_NumberOfDoors_Is_Within_Range()
        {
            // Arrange
            var command = new CreateSedanCommandBuilder().Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.NumberOfDoors);
        }

        protected override AbstractValidator<CreateSedanCommand> CreateValidator()
        {
            return new CreateSedanCommandValidator();
        }

        protected override CreateSedanCommand CreateVehicleCommand(string identifier = "identifier", string manufacturer = "manufacturer", string model = "model", int year = 2000, decimal startingBid = 12000)
        {
            return new CreateSedanCommandBuilder()
                    .WithIdentifier(identifier)
                    .WithManufacturer(manufacturer)
                    .WithModel(model)
                    .WithYear(year)
                    .WithStartingBid(startingBid)
                    .Build();
        }
    }
}
