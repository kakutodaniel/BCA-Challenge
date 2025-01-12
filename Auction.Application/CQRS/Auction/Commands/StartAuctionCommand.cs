using MediatR;

namespace Auction.Application.CQRS.Auction.Commands
{
    public record StartAuctionCommand(int[] VehicleIds) : IRequest<int>;
}
