namespace Auction.Infra.Repository
{
    public abstract class BaseRepository
    {
        private readonly AuctionContext _context;

        protected BaseRepository(AuctionContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
