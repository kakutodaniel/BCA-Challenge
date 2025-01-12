using Auction.Domain.Exceptions;
using Auction.Domain.Repository;
using Auction.Domain.Service;
using Auction.Tests.CrossCutting.Builders.Auction;
using Auction.Tests.CrossCutting.Builders.Vehicles;
using Moq;

namespace Auction.Domain.UnitTests.Service
{
    public class BidServiceTests
    {
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<IBidRepository> _bidRepositoryMock;
        private readonly BidService _bidService;

        public BidServiceTests()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _bidRepositoryMock = new Mock<IBidRepository>();
            _bidService = new BidService(_vehicleRepositoryMock.Object, _bidRepositoryMock.Object);
        }

        [Fact]
        public async Task PlaceBidAsync_ReturnsFalse_WhenVehicleDoesNotExist()
        {
            // Arrange
            var vehicleId = 1;
            _vehicleRepositoryMock.Setup(x => x.ExistsByIdAsync(vehicleId))
                .ReturnsAsync(false);

            // Act
            var result = await _bidService.PlaceBidAsync(vehicleId, 12000);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task PlaceBidAsync_ThrowsException_WhenVehicleNotInActiveAuction()
        {
            // Arrange
            var vehicleId = 1;

            _vehicleRepositoryMock.Setup(x => x.ExistsByIdAsync(vehicleId))
                .ReturnsAsync(true);

            _vehicleRepositoryMock.Setup(x => x.GetInActiveAuctionAsync(It.IsAny<int[]>()))
                .ReturnsAsync(Enumerable.Empty<Vehicle>());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DomainException>(() => _bidService.PlaceBidAsync(vehicleId, 12000));
            Assert.Equal("Vehicle is not in an active auction", exception.Message);
        }

        [Fact]
        public async Task PlaceBidAsync_ThrowsException_WhenBidIsLowerThanMaxBid()
        {
            // Arrange
            var vehicleId = 1;
            var auctionId = 1;
            var startingBid = 500m;
            var maxBid = 1000m;
            var bidAmount = 900m;

            var vehicle = new HatchbackBuilder()
                            .WithId(vehicleId)
                            .WithStartingBid(startingBid)
                            .WithAuctions(new Domain.Auction[] { new AuctionBuilder().WithId(auctionId).Build() })
                            .Build();

            _vehicleRepositoryMock.Setup(x => x.ExistsByIdAsync(vehicleId))
                .ReturnsAsync(true);

            _vehicleRepositoryMock.Setup(x => x.GetInActiveAuctionAsync(It.IsAny<int[]>()))
                .ReturnsAsync(new List<Vehicle> { vehicle });

            _bidRepositoryMock.Setup(x => x.GetAmountsAsync(vehicleId, auctionId))
                .ReturnsAsync(new List<decimal> { maxBid });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DomainException>(() => _bidService.PlaceBidAsync(vehicleId, bidAmount));
            Assert.Equal($"Amount is lower than the highest bid ({maxBid})", exception.Message);
        }

        [Fact]
        public async Task PlaceBidAsync_CreatesBid_WhenAmountIsGreaterThanMaxBid()
        {
            // Arrange
            var vehicleId = 1;
            var auctionId = 1;
            var startingBid = 500m;
            var maxBid = 1000m;
            var bidAmount = 1100m;

            var vehicle = new HatchbackBuilder()
                            .WithId(vehicleId)
                            .WithStartingBid(startingBid)
                            .WithAuctions(new Domain.Auction[] { new AuctionBuilder().WithId(auctionId).Build() })
                            .Build();

            _vehicleRepositoryMock.Setup(x => x.ExistsByIdAsync(vehicleId))
                .ReturnsAsync(true);

            _vehicleRepositoryMock.Setup(x => x.GetInActiveAuctionAsync(It.IsAny<int[]>()))
                .ReturnsAsync(new List<Vehicle> { vehicle });

            _bidRepositoryMock.Setup(x => x.GetAmountsAsync(vehicleId, auctionId))
                .ReturnsAsync(new List<decimal> { maxBid });

            // Act
            var result = await _bidService.PlaceBidAsync(vehicleId, bidAmount);

            // Assert
            Assert.True(result);
            _bidRepositoryMock.Verify(x => x.CreateAsync(vehicleId, auctionId, bidAmount), Times.Once);
            _bidRepositoryMock.Verify(x => x.SaveAsync(), Times.Once);
        }
    }
}
