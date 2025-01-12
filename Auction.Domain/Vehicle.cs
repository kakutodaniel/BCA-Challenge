namespace Auction.Domain
{
    public abstract class Vehicle
    {
        protected Vehicle(int id, string identifier, string manufacturer, string model, int year, decimal startingBid)
            : this(identifier, manufacturer, model, year, startingBid)
        {
            Id = id;
        }

        protected Vehicle(string identifier, string manufacturer, string model, int year, decimal startingBid)
        {
            Identifier = identifier;
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            StartingBid = startingBid;
        }

        public int Id { get; protected set; }
        public string Identifier { get; protected set; }
        public string Manufacturer { get; protected set; }
        public string Model { get; protected set; }
        public int Year { get; protected set; }
        public decimal StartingBid { get; protected set; }
        public IEnumerable<Auction> Auctions { get; private set; }

        public void AddAuctions(IEnumerable<Auction> auctions)
        {
            Auctions = auctions;
        }
    }

    public class Hatchback : Vehicle
    {
        public int NumberOfDoors { get; private set; }

        public Hatchback(int id, string identifier, string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
            : base(id, identifier, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }

        public Hatchback(string identifier, string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
            : base(identifier, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }
    }

    public class Sedan : Vehicle
    {
        public int NumberOfDoors { get; private set; }

        public Sedan(int id, string identifier, string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
            : base(id, identifier, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }

        public Sedan(string identifier, string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
            : base(identifier, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }
    }

    public class Suv : Vehicle
    {
        public int NumberOfSeats { get; private set; }

        public Suv(int id, string identifier, string manufacturer, string model, int year, decimal startingBid, int numberOfSeats)
            : base(id, identifier, manufacturer, model, year, startingBid)
        {
            NumberOfSeats = numberOfSeats;
        }

        public Suv(string identifier, string manufacturer, string model, int year, decimal startingBid, int numberOfSeats)
            : base(identifier, manufacturer, model, year, startingBid)
        {
            NumberOfSeats = numberOfSeats;
        }
    }

    public class Truck : Vehicle
    {
        public decimal LoadCapacity { get; private set; }

        public Truck(int id, string identifier, string manufacturer, string model, int year, decimal startingBid, decimal loadCapacity)
            : base(id, identifier, manufacturer, model, year, startingBid)
        {
            LoadCapacity = loadCapacity;
        }

        public Truck(string identifier, string manufacturer, string model, int year, decimal startingBid, decimal loadCapacity)
            : base(identifier, manufacturer, model, year, startingBid)
        {
            LoadCapacity = loadCapacity;
        }
    }
}
