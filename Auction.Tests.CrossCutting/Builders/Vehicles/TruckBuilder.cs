using Auction.Domain;

namespace Auction.Tests.CrossCutting.Builders.Vehicles
{
    public class TruckBuilder
    {
        private int _id;
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private decimal _loadCapacity;

        public TruckBuilder()
        {
            _id = 1;
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = DateTime.UtcNow.Year;
            _startingBid = 10000;
            _loadCapacity = 500M;
        }

        public TruckBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public TruckBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public TruckBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public TruckBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public TruckBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public TruckBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public TruckBuilder WithLoadCapacity(decimal loadCapacity)
        {
            _loadCapacity = loadCapacity;
            return this;
        }

        public Vehicle Build()
        {
            return new Truck(_id, _identifier, _manufacturer, _model, _year, _startingBid, _loadCapacity);
        }
    }
}
