namespace Auction.Domain.Service.Interface
{
    public interface IAuctionService
    {
        Task<int> StartAsync(IEnumerable<int> vehicleIds);

        Task<bool> StopAsync(int auctionId);
    }
}
