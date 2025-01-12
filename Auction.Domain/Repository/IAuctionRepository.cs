namespace Auction.Domain.Repository
{
    public interface IAuctionRepository : IBaseRepository
    {
        Task<int> CreateAsync(Auction auction);

        Task<bool> StopAsync(int id);

        Task<IEnumerable<Auction>> GetAll();
    }
}
