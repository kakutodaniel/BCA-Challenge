namespace Auction.Application.CQRS.Vehicle.Commands
{
    public record CreateSedanCommand(string Identifier, string Manufacturer, string Model, int Year, decimal StartingBid, int NumberOfDoors)
        : CreateVehicleCommand(Identifier, Manufacturer, Model, Year, StartingBid);
}
