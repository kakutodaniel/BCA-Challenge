using Auction.Domain;
using Auction.Domain.Repository;
using Auction.Infra.Mapper;
using Auction.Infra.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auction.Infra.Repository
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        private readonly AuctionContext _context;

        public VehicleRepository(AuctionContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Vehicle vehicle)
        {
            var model = VehicleMapper.ToDataModel(vehicle);

            await _context.Vehicles.AddAsync(model);

            return model.Id;
        }

        public async Task<IEnumerable<Vehicle>> GetAsync(IEnumerable<int> ids)
        {
            var vehiclesDataModel = await _context.Vehicles
                                    .AsNoTracking()
                                    .Where(x => ids.Contains(x.Id))
                                    .ToListAsync();

            if (vehiclesDataModel == null || !vehiclesDataModel.Any())
            {
                return Enumerable.Empty<Vehicle>();
            }

            return vehiclesDataModel.Select(x => VehicleMapper.ToDomain(x));
        }

        public async Task<IEnumerable<Vehicle>> GetInActiveAuctionAsync(IEnumerable<int> ids)
        {
            var auctionVehiclesDataModel = await _context.AuctionsVehicles
                                                .AsNoTracking()
                                                .Include(x => x.Auction)
                                                .Where(x => x.Auction.Active)
                                                .Include(x => x.Vehicle)
                                                .ThenInclude(x => x.Auctions.Where(x => x.Active))
                                                .Where(x => ids.Contains(x.Vehicle.Id))
                                                .ToListAsync();

            if (auctionVehiclesDataModel == null || !auctionVehiclesDataModel.Any())
            {
                return Enumerable.Empty<Vehicle>();
            }

            return auctionVehiclesDataModel.Select(x => VehicleMapper.ToDomain(x.Vehicle));
        }

        public async Task<bool> ExistsByIdentifierAsync(string identifier)
        {
            return await _context.Vehicles
                        .AsNoTracking()
                        .Where(x => x.Identifier == identifier)
                        .AnyAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.Vehicles
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .AnyAsync();
        }

        public async Task<IEnumerable<Vehicle>> SearchAsync(string type, string manufacturer, string model, int? year)
        {
            var query = _context.Vehicles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(type))
            {
                query = query.Where(x => string.Equals(x.Type, type, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                query = query.Where(x => string.Equals(x.Manufacturer, manufacturer, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(model))
            {
                query = query.Where(x => string.Equals(x.Model, model, StringComparison.InvariantCultureIgnoreCase));
            }

            if (year != null && year > 0)
            {
                query = query.Where(x => x.Year == year);
            }

            var data = await query.AsNoTracking().ToListAsync();

            return data.Select(x => VehicleMapper.ToDomain(x));
        }

    }
}
