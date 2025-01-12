using Auction.Domain.Exceptions;
using Auction.Domain.Repository;
using Auction.Domain.Service.Interface;

namespace Auction.Domain.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public AuctionService(IAuctionRepository auctionRepository, IVehicleRepository vehicleRepository)
        {
            _auctionRepository = auctionRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> StartAsync(IEnumerable<int> vehicleIds)
        {
            if (!vehicleIds.Any())
            {
                throw new DomainException($"Vehicles can not be empty");
            }

            var vehicles = await _vehicleRepository.GetAsync(vehicleIds);

            var difference = vehicleIds.Except(vehicles.Select(x => x.Id));

            if (difference.Any())
            {
                throw new DomainException($"There are no vehicles with ids: {string.Join(',', difference)}");
            }

            var vehiclesInActiveAuction = await _vehicleRepository.GetInActiveAuctionAsync(vehicleIds);

            if (vehiclesInActiveAuction.Any())
            {
                throw new DomainException($"There are vehicles in active auction (ids: {string.Join(',', vehiclesInActiveAuction.Select(x => x.Id))})");
            }

            var auction = new Auction(active: true);
            auction.AddVehicles(vehicles);

            var id = await _auctionRepository.CreateAsync(auction);

            await _auctionRepository.SaveAsync();

            return id;
        }

        public async Task<bool> StopAsync(int auctionId)
        {
            var result = await _auctionRepository.StopAsync(auctionId);
            await _auctionRepository.SaveAsync();

            return result;
        }
    }
}
