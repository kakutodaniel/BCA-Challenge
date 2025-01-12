namespace Auction.Infra.Model
{
    public class AuctionVehicleDataModel
    {
        public AuctionDataModel Auction { get; set; }
        public int AuctionId { get; set; }
        public VehicleDataModel Vehicle { get; set; }
        public int VehicleId { get; set; }
    }
}
