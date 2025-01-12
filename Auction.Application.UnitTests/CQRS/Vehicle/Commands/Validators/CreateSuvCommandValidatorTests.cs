using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.CQRS.Vehicle.Commands.Validators;
using Auction.Application.Error;
using Auction.Tests.CrossCutting.Builders.Commands;
using FluentValidation;
using FluentValidation.TestHelper;

namespace Auction.Application.UnitTests.CQRS.Vehicle.Commands.Validators
{
    public class CreateSuvCommandValidatorTests : CreateVehicleCommandValidatorTests<CreateSuvCommand>
    {
        private readonly CreateSuvCommandValidator _validator;
        private readonly int _minNumberOfSeats = 4;
        private readonly int _maxNumberOfSeats = 20;

        public CreateSuvCommandValidatorTests()
        {
            _validator = new CreateSuvCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_NumberOfSeats_Is_Less_Than_4()
        {
            // Arrange
            var command = new CreateSuvCommandBuilder().WithNumberOfSeats(2).Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.NumberOfSeats)
                  .WithErrorMessage(string.Format(ErrorMessage.InclusiveBetween, "Number Of Seats", _minNumberOfSeats, _maxNumberOfSeats));
        }

        [Fact]
        public void Should_Have_Error_When_NumberOfSeats_Is_Greater_Than_20()
        {
            // Arrange
            var command = new CreateSuvCommandBuilder().WithNumberOfSeats(21).Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.NumberOfSeats)
                  .WithErrorMessage(string.Format(ErrorMessage.InclusiveBetween, "Number Of Seats", _minNumberOfSeats, _maxNumberOfSeats));
        }

        [Fact]
        public void Should_Not_Have_Error_When_NumberOfDoors_Is_Within_Range()
        {
            // Arrange
            var command = new CreateSuvCommandBuilder().Build();

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.NumberOfSeats);
        }

        protected override AbstractValidator<CreateSuvCommand> CreateValidator()
        {
            return new CreateSuvCommandValidator();
        }

        protected override CreateSuvCommand CreateVehicleCommand(string identifier = "identifier", string manufacturer = "manufacturer", string model = "model", int year = 2000, decimal startingBid = 12000)
        {
            return new CreateSuvCommandBuilder()
                    .WithIdentifier(identifier)
                    .WithManufacturer(manufacturer)
                    .WithModel(model)
                    .WithYear(year)
                    .WithStartingBid(startingBid)
                    .Build();
        }
    }
}
