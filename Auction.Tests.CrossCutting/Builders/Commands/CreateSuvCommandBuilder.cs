using Auction.Application.CQRS.Vehicle.Commands;

namespace Auction.Tests.CrossCutting.Builders.Commands
{
    public class CreateSuvCommandBuilder
    {
        private string _identifier;
        private string _manufacturer;
        private string _model;
        private int _year;
        private decimal _startingBid;
        private int _numberOfSeats;

        public CreateSuvCommandBuilder()
        {
            _identifier = "identifier";
            _manufacturer = "manufacturer";
            _model = "model";
            _year = 2000;
            _startingBid = 12000m;
            _numberOfSeats = 4;
        }

        public CreateSuvCommandBuilder WithIdentifier(string identifier)
        {
            _identifier = identifier;
            return this;
        }

        public CreateSuvCommandBuilder WithManufacturer(string manufacturer)
        {
            _manufacturer = manufacturer;
            return this;
        }

        public CreateSuvCommandBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public CreateSuvCommandBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public CreateSuvCommandBuilder WithStartingBid(decimal startingBid)
        {
            _startingBid = startingBid;
            return this;
        }

        public CreateSuvCommandBuilder WithNumberOfSeats(int numberOfSeats)
        {
            _numberOfSeats = numberOfSeats;
            return this;
        }

        public CreateSuvCommand Build()
        {
            return new CreateSuvCommand(_identifier, _manufacturer, _model, _year, _startingBid, _numberOfSeats);
        }
    }
}
