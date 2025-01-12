using Auction.Infra.Model;

namespace Auction.Infra.Mapper
{
    public class AuctionMapper
    {
        public static Domain.Auction ToDomain(AuctionDataModel model)
        {
            var domain = new Domain.Auction(model.Id, model.Active);

            var vehicles = model.Vehicles.Select(x => VehicleMapper.ToDomain(x));

            domain.AddVehicles(vehicles);

            return domain;
        }
    }
}
