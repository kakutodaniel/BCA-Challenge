namespace Auction.Domain
{
    public class Auction
    {
        public Auction(int id, bool active)
            : this(active)
        {
            Id = id;
        }

        public Auction(bool active)
        {
            Active = active;
        }

        public int Id { get; private set; }

        public bool Active { get; private set; }

        public IEnumerable<Vehicle> Vehicles { get; private set; }

        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

    }
}
