namespace Auction.Domain.Repository
{
    public interface IBaseRepository
    {
        Task<int> SaveAsync();
    }
}
