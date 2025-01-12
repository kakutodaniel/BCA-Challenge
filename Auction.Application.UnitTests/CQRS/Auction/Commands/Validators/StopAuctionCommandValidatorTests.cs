using Auction.Application.CQRS.Auction.Commands.Validators;
using Auction.Application.CQRS.Auction.Commands;
using FluentValidation.TestHelper;
using Auction.Application.Error;

namespace Auction.Application.UnitTests.CQRS.Auction.Commands.Validators
{
    public class StopAuctionCommandValidatorTests
    {
        private readonly StopAuctionCommandValidator _validator;

        public StopAuctionCommandValidatorTests()
        {
            _validator = new StopAuctionCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_AuctionId_Is_Less_Than_1()
        {
            // Arrange
            var command = new StopAuctionCommand(0);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cmd => cmd.AuctionId)
                  .WithErrorMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "Auction Id", 1));
        }

        [Fact]
        public void Should_Not_Have_Error_When_AuctionId_Is_Valid()
        {
            // Arrange
            var command = new StopAuctionCommand(5);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(cmd => cmd.AuctionId);
        }
    }
}
