using Auction.Application.CQRS.Bid.Commands;
using Auction.Application.CQRS.Bid.Commands.Validators;
using Auction.Application.Error;
using FluentValidation.TestHelper;

namespace Auction.Application.UnitTests.CQRS.Bid.Commands.Validators
{
    public class PlaceBidCommandValidatorTests
    {
        private readonly PlaceBidCommandValidator _validator;

        public PlaceBidCommandValidatorTests()
        {
            _validator = new PlaceBidCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_VehicleId_Is_Less_Than_1()
        {
            // Arrange
            var command = new PlaceBidCommand(0, 100);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.VehicleId)
                  .WithErrorMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "Vehicle Id", 1));
        }

        [Fact]
        public void Should_Have_Error_When_Amount_Is_Less_Than_1()
        {
            // Arrange
            var command = new PlaceBidCommand(1, 0);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.Amount)
                  .WithErrorMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "Amount", 1));
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid_Command()
        {
            // Arrange
            var command = new PlaceBidCommand(1, 12000);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.VehicleId);
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.Amount);
        }
    }
}
