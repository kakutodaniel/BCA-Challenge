using Auction.Domain;

namespace Auction.Tests.CrossCutting.Builders.Vehicles
{
    public class SedanBuilder
    {
        private int _id;
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private int _numberOfDoors;

        public SedanBuilder()
        {
            _id = 1;
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = DateTime.UtcNow.Year;
            _startingBid = 10000;
            _numberOfDoors = 4;
        }

        public SedanBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public SedanBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public SedanBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public SedanBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public SedanBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public SedanBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public SedanBuilder WithNumberOfDoors(int numberOfDoors)
        {
            _numberOfDoors = numberOfDoors;
            return this;
        }

        public Vehicle Build()
        {
            return new Sedan(_id, _identifier, _manufacturer, _model, _year, _startingBid, _numberOfDoors);
        }
    }
}
