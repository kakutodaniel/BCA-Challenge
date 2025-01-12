using Auction.Application.CQRS.Vehicle.Commands;

namespace Auction.Tests.CrossCutting.Builders.Commands
{
    public class CreateHatchBackCommandBuilder
    {
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private int _numberOfDoors;

        public CreateHatchBackCommandBuilder()
        {
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = 2000;
            _startingBid = 12000m;
            _numberOfDoors = 4;
        }

        public CreateHatchBackCommandBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public CreateHatchBackCommandBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public CreateHatchBackCommandBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public CreateHatchBackCommandBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public CreateHatchBackCommandBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public CreateHatchBackCommandBuilder WithNumberOfDoors(int numberOfDoors)
        {
            _numberOfDoors = numberOfDoors;
            return this;
        }

        public CreateHatchBackCommand Build()
        {
            return new CreateHatchBackCommand(_identifier, _manufacturer, _model, _year, _startingBid, _numberOfDoors);
        }
    }
}
