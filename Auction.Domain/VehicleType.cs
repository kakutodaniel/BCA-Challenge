namespace Auction.Domain
{
    public class VehicleType
    {
        public static readonly VehicleType Hatchback = new("Hatchback");
        public static readonly VehicleType Sedan = new("Sedan");
        public static readonly VehicleType SUV = new("SUV");
        public static readonly VehicleType Truck = new("Truck");

        public string Name { get; }

        public VehicleType(string name)
        {
            Name = name;
        }
    }
}
