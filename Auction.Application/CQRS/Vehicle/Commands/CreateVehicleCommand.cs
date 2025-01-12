using MediatR;

namespace Auction.Application.CQRS.Vehicle.Commands
{
    public record CreateVehicleCommand(string Identifier, string Manufacturer, string Model, int Year, decimal StartingBid) : IRequest<int>;
}
