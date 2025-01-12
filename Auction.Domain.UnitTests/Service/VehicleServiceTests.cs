using Auction.Domain.Exceptions;
using Auction.Domain.Repository;
using Auction.Domain.Service;
using Auction.Tests.CrossCutting.Builders.Vehicles;
using Moq;

namespace Auction.Domain.UnitTests.Service
{
    public class VehicleServiceTests
    {
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly VehicleService _vehicleService;

        public VehicleServiceTests()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ThrowsException_WhenVehicleIdentifierExists()
        {
            // Arrange
            var vehicle = new TruckBuilder().WithIdentifier("VOLVO-9878").Build();
            _vehicleRepositoryMock.Setup(x => x.ExistsByIdentifierAsync(vehicle.Identifier))
                .ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DomainException>(() => _vehicleService.CreateAsync(vehicle));
            Assert.Equal("Vehicle identifier already exists", exception.Message);
        }

        [Fact]
        public async Task CreateAsync_CreatesVehicle_WhenVehicleIdentifierDoesNotExist()
        {
            // Arrange
            var vehicle = new TruckBuilder().WithIdentifier("VOLVO-9878").Build();
            _vehicleRepositoryMock.Setup(x => x.ExistsByIdentifierAsync(vehicle.Identifier))
                .ReturnsAsync(false);

            _vehicleRepositoryMock.Setup(x => x.CreateAsync(vehicle))
                .ReturnsAsync(1);

            // Act
            var result = await _vehicleService.CreateAsync(vehicle);

            // Assert
            Assert.Equal(1, result);
            _vehicleRepositoryMock.Verify(x => x.CreateAsync(vehicle), Times.Once);
            _vehicleRepositoryMock.Verify(x => x.SaveAsync(), Times.Once);
        }
    }
}
