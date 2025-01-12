namespace Auction.Domain.Repository
{
    public interface IVehicleRepository : IBaseRepository
    {
        Task<int> CreateAsync(Vehicle vehicle);

        Task<IEnumerable<Vehicle>> GetAsync(IEnumerable<int> ids);

        Task<IEnumerable<Vehicle>> GetInActiveAuctionAsync(IEnumerable<int> ids);

        Task<bool> ExistsByIdentifierAsync(string identifier);

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<Vehicle>> SearchAsync(string type, string manufacturer, string model, int? year);
    }
}
