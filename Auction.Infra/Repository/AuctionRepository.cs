using Auction.Domain.Repository;
using Auction.Infra.Mapper;
using Auction.Infra.Model;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infra.Repository
{
    public class AuctionRepository : BaseRepository, IAuctionRepository
    {
        private readonly AuctionContext _context;

        public AuctionRepository(AuctionContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Domain.Auction auction)
        {
            var vehicles = await _context.Vehicles.Where(x => auction.Vehicles.Select(x => x.Id).Contains(x.Id)).ToListAsync();

            var model = new AuctionDataModel
            {
                Active = auction.Active,
                Vehicles = vehicles
            };

            await _context.Auctions.AddAsync(model);

            return model.Id;
        }

        public async Task<bool> StopAsync(int id)
        {
            var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id);

            if (auction == null) { return false; }

            auction.Active = false;

            return true;
        }

        public async Task<IEnumerable<Domain.Auction>> GetAll()
        {
            var auctions = await _context.Auctions
                    .AsNoTracking()
                    .Include(x => x.Vehicles)
                    .ToListAsync();

            if (auctions == null || !auctions.Any())
            {
                return Enumerable.Empty<Domain.Auction>();
            }

            return auctions.Select(x => AuctionMapper.ToDomain(x));
        }
    }
}
