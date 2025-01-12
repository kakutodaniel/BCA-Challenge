using Auction.Domain.Exceptions;
using Auction.Domain.Repository;
using Auction.Domain.Service.Interface;

namespace Auction.Domain.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> CreateAsync(Vehicle vehicle)
        {
            var existsByIdentifier = await _vehicleRepository.ExistsByIdentifierAsync(vehicle.Identifier);

            if (existsByIdentifier)
            {
                throw new DomainException($"Vehicle identifier already exists");
            }

            var id = await _vehicleRepository.CreateAsync(vehicle);

            await _vehicleRepository.SaveAsync();

            return id;
        }
    }
}
