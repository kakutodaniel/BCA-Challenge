using Auction.Domain;

namespace Auction.Tests.CrossCutting.Builders.Vehicles
{
    public class HatchbackBuilder
    {
        private int _id;
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private int _numberOfDoors;
        private IEnumerable<Domain.Auction> _auctions;

        public HatchbackBuilder()
        {
            _id = 1;
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = DateTime.UtcNow.Year;
            _startingBid = 10000;
            _numberOfDoors = 4;
            _auctions = Enumerable.Empty<Domain.Auction>();
        }

        public HatchbackBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public HatchbackBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public HatchbackBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public HatchbackBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public HatchbackBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public HatchbackBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public HatchbackBuilder WithNumberOfDoors(int numberOfDoors)
        {
            _numberOfDoors = numberOfDoors;
            return this;
        }

        public HatchbackBuilder WithAuctions(IEnumerable<Domain.Auction> auctions)
        {
            _auctions = auctions;
            return this;
        }

        public Vehicle Build()
        {
            var vehicle = new Hatchback(_id, _identifier, _manufacturer, _model, _year, _startingBid, _numberOfDoors);
            vehicle.AddAuctions(_auctions);
            return vehicle;
        }
    }
}
