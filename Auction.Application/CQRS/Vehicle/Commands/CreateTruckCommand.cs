namespace Auction.Application.CQRS.Vehicle.Commands
{
    public record CreateTruckCommand(string Identifier, string Manufacturer, string Model, int Year, decimal StartingBid, decimal LoadCapacity)
        : CreateVehicleCommand(Identifier, Manufacturer, Model, Year, StartingBid);
}
