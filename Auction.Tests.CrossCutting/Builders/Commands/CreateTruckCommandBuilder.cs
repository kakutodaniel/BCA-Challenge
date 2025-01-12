using Auction.Application.CQRS.Vehicle.Commands;

namespace Auction.Tests.CrossCutting.Builders.Commands
{
    public class CreateTruckCommandBuilder
    {
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private decimal _loadCapacity;

        public CreateTruckCommandBuilder()
        {
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = 2000;
            _startingBid = 12000m;
            _loadCapacity = 5000m;
        }

        public CreateTruckCommandBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public CreateTruckCommandBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public CreateTruckCommandBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public CreateTruckCommandBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public CreateTruckCommandBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public CreateTruckCommandBuilder WithLoadCapacity(decimal loadCapacity)
        {
            _loadCapacity = loadCapacity;
            return this;
        }

        public CreateTruckCommand Build()
        {
            return new CreateTruckCommand(_identifier, _manufacturer, _model, _year, _startingBid, _loadCapacity);
        }
    }
}
