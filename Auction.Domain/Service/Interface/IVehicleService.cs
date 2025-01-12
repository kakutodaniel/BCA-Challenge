namespace Auction.Domain.Service.Interface
{
    public interface IVehicleService
    {
        Task<int> CreateAsync(Vehicle vehicle);
    }
}
