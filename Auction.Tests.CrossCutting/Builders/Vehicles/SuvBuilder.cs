using Auction.Domain;

namespace Auction.Tests.CrossCutting.Builders.Vehicles
{
    public class SuvBuilder
    {
        private int _id;
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private int _numberOfSeats;

        public SuvBuilder()
        {
            _id = 1;
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = DateTime.UtcNow.Year;
            _startingBid = 10000;
            _numberOfSeats = 4;
        }

        public SuvBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public SuvBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public SuvBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public SuvBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public SuvBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public SuvBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public SuvBuilder WithNumberOfSeats(int numberOfDoors)
        {
            _numberOfSeats = numberOfDoors;
            return this;
        }

        public Vehicle Build()
        {
            return new Suv(_id, _identifier, _manufacturer, _model, _year, _startingBid, _numberOfSeats);
        }
    }
}
