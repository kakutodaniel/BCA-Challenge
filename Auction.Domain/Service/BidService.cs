using Auction.Domain.Exceptions;
using Auction.Domain.Repository;
using Auction.Domain.Service.Interface;

namespace Auction.Domain.Service
{
    public class BidService : IBidService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IBidRepository _bidRepository;

        public BidService(IVehicleRepository vehicleRepository, IBidRepository bidRepository)
        {
            _vehicleRepository = vehicleRepository;
            _bidRepository = bidRepository;
        }

        public async Task<bool> PlaceBidAsync(int vehicleId, decimal amount)
        {
            var vehicleExists = await _vehicleRepository.ExistsByIdAsync(vehicleId);

            if (!vehicleExists)
            {
                return false;
            }

            var vehicleInActiveAuction = (await _vehicleRepository.GetInActiveAuctionAsync(new int[] { vehicleId })).SingleOrDefault();

            if (vehicleInActiveAuction == null)
            {
                throw new DomainException($"Vehicle is not in an active auction");
            }

            var auctionId = vehicleInActiveAuction.Auctions.Single().Id;

            var bids = await _bidRepository.GetAmountsAsync(vehicleId, auctionId);
            var maxBid = bids.Any() ? Math.Max(bids.Max(), vehicleInActiveAuction.StartingBid) : vehicleInActiveAuction.StartingBid;

            if (amount <= maxBid)
            {
                throw new DomainException($"Amount is lower than the highest bid ({maxBid})");
            }

            await _bidRepository.CreateAsync(vehicleId, auctionId, amount);

            await _bidRepository.SaveAsync();

            return true;
        }
    }
}
