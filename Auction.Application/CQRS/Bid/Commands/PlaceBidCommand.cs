using MediatR;

namespace Auction.Application.CQRS.Bid.Commands
{
    public record PlaceBidCommand(int VehicleId, decimal Amount) : IRequest<bool>;
}
