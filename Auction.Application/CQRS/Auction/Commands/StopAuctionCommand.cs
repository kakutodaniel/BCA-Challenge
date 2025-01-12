using MediatR;

namespace Auction.Application.CQRS.Auction.Commands
{
    public record StopAuctionCommand(int AuctionId) : IRequest<bool>;
}
