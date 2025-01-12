using Auction.Domain.Exceptions;
using Auction.Domain.Repository;
using Auction.Domain.Service;
using Auction.Tests.CrossCutting.Builders.Vehicles;
using Moq;

namespace Auction.Domain.UnitTests.Service
{
    public class AuctionServiceTests
    {
        private readonly Mock<IAuctionRepository> _mockAuctionRepository;
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly AuctionService _auctionService;

        public AuctionServiceTests()
        {
            _mockAuctionRepository = new Mock<IAuctionRepository>();
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _auctionService = new AuctionService(_mockAuctionRepository.Object, _mockVehicleRepository.Object);
        }

        [Fact]
        public async Task StartAsync_ThrowsException_WhenVehicleIdsAreEmpty()
        {
            // Arrange
            var vehicleIds = new List<int>();

            // Act & Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => _auctionService.StartAsync(vehicleIds));
            Assert.Equal("Vehicles can not be empty", ex.Message);
        }

        [Fact]
        public async Task StartAsync_ThrowsException_WhenVehiclesNotFound()
        {
            // Arrange
            var vehicleIds = new List<int> { 1, 2, 3 };
            _mockVehicleRepository.Setup(repo => repo.GetAsync(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(new List<Vehicle>());

            // Act & Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => _auctionService.StartAsync(vehicleIds));
            Assert.Equal("There are no vehicles with ids: 1,2,3", ex.Message);
        }

        [Fact]
        public async Task StartAsync_ThrowsException_WhenVehiclesAreInActiveAuction()
        {
            // Arrange
            var vehicleIds = new List<int> { 1, 2, 3 };
            var vehicle_1 = new HatchbackBuilder().WithId(1).Build();
            var vehicle_2 = new SedanBuilder().WithId(2).Build();
            var vehicle_3 = new SuvBuilder().WithId(3).Build();

            var vehicles = new List<Vehicle>
            {
                vehicle_1, vehicle_2, vehicle_3
            };

            _mockVehicleRepository.Setup(repo => repo.GetAsync(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(vehicles);

            _mockVehicleRepository.Setup(repo => repo.GetInActiveAuctionAsync(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(new List<Vehicle> { vehicle_2 });

            // Act & Assert
            var ex = await Assert.ThrowsAsync<DomainException>(() => _auctionService.StartAsync(vehicleIds));
            Assert.Equal("There are vehicles in active auction (ids: 2)", ex.Message);
        }

        [Fact]
        public async Task StartAsync_CreatesAuctionSuccessfully()
        {
            // Arrange
            var vehicleIds = new List<int> { 1, 2, 3 };
            var vehicle_1 = new HatchbackBuilder().WithId(1).Build();
            var vehicle_2 = new SedanBuilder().WithId(2).Build();
            var vehicle_3 = new SuvBuilder().WithId(3).Build();

            var vehicles = new List<Vehicle>
            {
                vehicle_1, vehicle_2, vehicle_3
            };

            _mockVehicleRepository.Setup(repo => repo.GetAsync(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(vehicles);

            _mockVehicleRepository.Setup(repo => repo.GetInActiveAuctionAsync(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(new List<Vehicle>());

            _mockAuctionRepository.Setup(repo => repo.CreateAsync(It.IsAny<Domain.Auction>()))
                .ReturnsAsync(1);

            // Act
            var auctionId = await _auctionService.StartAsync(vehicleIds);

            // Assert
            Assert.Equal(1, auctionId);
            _mockAuctionRepository.Verify(repo => repo.CreateAsync(It.IsAny<Domain.Auction>()), Times.Once);
            _mockAuctionRepository.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task StopAsync_ReturnsTrue_WhenAuctionIsStoppedSuccessfully()
        {
            // Arrange
            var auctionId = 1;
            _mockAuctionRepository.Setup(repo => repo.StopAsync(auctionId))
                .ReturnsAsync(true);

            // Act
            var result = await _auctionService.StopAsync(auctionId);

            // Assert
            Assert.True(result);
            _mockAuctionRepository.Verify(repo => repo.StopAsync(auctionId), Times.Once);
            _mockAuctionRepository.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task StopAsync_ReturnsFalse_WhenAuctionNotStopped()
        {
            // Arrange
            var auctionId = 1;
            _mockAuctionRepository.Setup(repo => repo.StopAsync(auctionId))
                .ReturnsAsync(false);

            // Act
            var result = await _auctionService.StopAsync(auctionId);

            // Assert
            Assert.False(result);
            _mockAuctionRepository.Verify(repo => repo.StopAsync(auctionId), Times.Once);
            _mockAuctionRepository.Verify(repo => repo.SaveAsync(), Times.Once);
        }
    }

}
