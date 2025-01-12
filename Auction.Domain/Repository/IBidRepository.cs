namespace Auction.Domain.Repository
{
    public interface IBidRepository : IBaseRepository
    {
        Task CreateAsync(int vehicleId, int auctionId, decimal amount);

        Task<IEnumerable<decimal>> GetAmountsAsync(int vehicleId, int auctionId);
    }
}
