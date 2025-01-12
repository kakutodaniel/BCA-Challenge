namespace Auction.Application.CQRS.Vehicle.Commands
{
    public record CreateSuvCommand(string Identifier, string Manufacturer, string Model, int Year, decimal StartingBid, int NumberOfSeats)
        : CreateVehicleCommand(Identifier, Manufacturer, Model, Year, StartingBid);
}
