using Auction.Application.CQRS.Auction.Commands.Validators;
using Auction.Application.CQRS.Auction.Commands;
using FluentValidation.TestHelper;
using Auction.Application.Error;

namespace Auction.Application.UnitTests.CQRS.Auction.Commands.Validators
{
    public class StartAuctionCommandValidatorTests
    {
        private readonly StartAuctionCommandValidator _validator;

        public StartAuctionCommandValidatorTests()
        {
            _validator = new StartAuctionCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_VehicleIds_Is_Null()
        {
            // Arrange
            var command = new StartAuctionCommand(null);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.VehicleIds)
                  .WithErrorMessage(string.Format(ErrorMessage.NotNull, "Vehicle Ids"));
        }

        [Fact]
        public void Should_Have_Error_When_VehicleIds_Is_Empty()
        {
            // Arrange
            var command = new StartAuctionCommand(Array.Empty<int>());

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.VehicleIds)
                  .WithErrorMessage(string.Format(ErrorMessage.NotEmpty, "Vehicle Ids"));
        }

        [Fact]
        public void Should_Not_Have_Error_When_VehicleIds_Is_Valid()
        {
            // Arrange
            var command = new StartAuctionCommand(new[] { 1, 2, 3 });

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.VehicleIds);
        }
    }
}
