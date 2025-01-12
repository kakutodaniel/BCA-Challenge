using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Tests.CrossCutting.Utils;
using FluentValidation;

namespace Auction.Application.UnitTests.CQRS.Vehicle.Commands.Validators
{
    public abstract class CreateVehicleCommandValidatorTests<T> where T : CreateVehicleCommand
    {
        protected abstract AbstractValidator<T> CreateValidator();

        protected abstract T CreateVehicleCommand(
            string identifier = "identifier", 
            string manufacturer = "manufacturer", 
            string model = "model", 
            int year = 2000, 
            decimal startingBid = 12000m);

        [Fact]
        public void Should_Have_Error_When_Identifier_Is_Null()
        {
            // Arrange
            var command = CreateVehicleCommand(identifier: null);

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Identifier"));
        }

        [Fact]
        public void Should_Have_Error_When_Identifier_Is_Shorter_Than_2_Characters()
        {
            // Arrange
            var command = CreateVehicleCommand(identifier: "a");

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Identifier"));
        }

        [Fact]
        public void Should_Have_Error_When_Identifier_Is_Longer_Than_50_Characters()
        {
            // Arrange
            var command = CreateVehicleCommand(identifier: StringUtil.GenerateRandomString(51));

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Identifier"));
        }

        [Fact]
        public void Should_Have_Error_When_Manufacturer_Is_Null()
        {
            // Arrange
            var command = CreateVehicleCommand(manufacturer: null);

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Manufacturer"));
        }

        [Fact]
        public void Should_Have_Error_When_Manufacturer_Is_Shorter_Than_2_Characters()
        {
            // Arrange
            var command = CreateVehicleCommand(manufacturer: "a");

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Manufacturer"));
        }

        [Fact]
        public void Should_Have_Error_When_Manufacturer_Is_Longer_Than_50_Characters()
        {
            // Arrange
            var command = CreateVehicleCommand(manufacturer: StringUtil.GenerateRandomString(51));

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Manufacturer"));
        }

        [Fact]
        public void Should_Have_Error_When_Model_Is_Null()
        {
            // Arrange
            var command = CreateVehicleCommand(model: null);

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Model"));
        }

        [Fact]
        public void Should_Have_Error_When_Model_Is_Shorter_Than_2_Characters()
        {
            // Arrange
            var command = CreateVehicleCommand(model: "a");

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Model"));
        }

        [Fact]
        public void Should_Have_Error_When_Model_Is_Longer_Than_50_Characters()
        {
            // Arrange
            var command = CreateVehicleCommand(model: StringUtil.GenerateRandomString(51));

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Model"));
        }

        [Fact]
        public void Should_Have_Error_When_Year_Is_Less_Than_1900()
        {
            // Arrange
            var command = CreateVehicleCommand(year: 1800);

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Year"));
        }

        [Fact]
        public void Should_Have_Error_When_Year_Is_Greater_Than_Current_Year()
        {
            // Arrange
            var command = CreateVehicleCommand(year: DateTime.UtcNow.AddYears(1).Year);

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Year"));
        }

        [Fact]
        public void Should_Have_Error_When_StartingBid_Is_Less_Than_1()
        {
            // Arrange
            var command = CreateVehicleCommand(startingBid: 0.1m);

            // Act
            var result = CreateValidator().Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("Starting Bid"));
        }
    }
}
