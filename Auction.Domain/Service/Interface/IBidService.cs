namespace Auction.Domain.Service.Interface
{
    public interface IBidService
    {
        Task<bool> PlaceBidAsync(int vehicleId, decimal amount);
    }
}
