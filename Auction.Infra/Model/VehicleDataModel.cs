namespace Auction.Infra.Model
{
    public class VehicleDataModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal StartingBid { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal LoadCapacity { get; set; }
        public List<AuctionDataModel> Auctions { get; set; }
    }
}
