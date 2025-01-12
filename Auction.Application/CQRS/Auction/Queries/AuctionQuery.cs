using Auction.Application.DTO.Auction;
using MediatR;

namespace Auction.Application.CQRS.Auction.Queries
{
    public record AuctionQuery : IRequest<IEnumerable<AuctionResponseDto>>;
}
