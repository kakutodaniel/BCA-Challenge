using Auction.Application.CQRS.Vehicle.Commands;

namespace Auction.Tests.CrossCutting.Builders.Commands
{
    public class CreateSedanCommandBuilder
    {
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private int _numberOfDoors;

        public CreateSedanCommandBuilder()
        {
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = 2000;
            _startingBid = 12000m;
            _numberOfDoors = 4;
        }

        public CreateSedanCommandBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public CreateSedanCommandBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public CreateSedanCommandBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public CreateSedanCommandBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public CreateSedanCommandBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public CreateSedanCommandBuilder WithNumberOfDoors(int numberOfDoors)
        {
            _numberOfDoors = numberOfDoors;
            return this;
        }

        public CreateSedanCommand Build()
        {
            return new CreateSedanCommand(_identifier, _manufacturer, _model, _year, _startingBid, _numberOfDoors);
        }
    }
}
