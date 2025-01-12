namespace Auction.Infra.Model
{
    public class BidDataModel
    {
        public long Id { get; set; }
        public VehicleDataModel Vehicle { get; set; }
        public AuctionDataModel Auction { get; set; }
        public decimal Amount { get; set; }
    }
}
