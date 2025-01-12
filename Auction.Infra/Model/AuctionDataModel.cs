namespace Auction.Infra.Model
{
    public class AuctionDataModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public List<VehicleDataModel> Vehicles { get; set; }
    }
}
