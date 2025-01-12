using Auction.Domain.Repository;
using Auction.Infra.Model;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infra.Repository
{
    public class BidRepository : BaseRepository, IBidRepository
    {
        private readonly AuctionContext _context;

        public BidRepository(AuctionContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task CreateAsync(int vehicleId, int auctionId, decimal amount)
        {
            var vehicle = await _context.Vehicles.Where(x => x.Id == vehicleId).SingleAsync();

            var auction = await _context.Auctions.Where(x => x.Id == auctionId).SingleAsync();
            
            var model = new BidDataModel
            {
                Vehicle = vehicle,
                Auction = auction,
                Amount = amount
            };

            await _context.Bids.AddAsync(model);
        }

        public async Task<IEnumerable<decimal>> GetAmountsAsync(int vehicleId, int auctionId)
        {
            return await _context.Bids
                        .AsNoTracking()
                        .Where(x => x.Auction.Id == auctionId)
                        .Where(x => x.Vehicle.Id == vehicleId)
                        .Select(x => x.Amount)
                        .ToListAsync();

        }
    }
}
