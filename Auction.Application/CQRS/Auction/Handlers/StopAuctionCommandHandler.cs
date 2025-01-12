using Auction.Application.CQRS.Auction.Commands;
using Auction.Domain.Service.Interface;
using MediatR;

namespace Auction.Application.CQRS.Auction.Handlers
{
    public class StopAuctionCommandHandler : IRequestHandler<StopAuctionCommand, bool>
    {
        private readonly IAuctionService _auctionService;

        public StopAuctionCommandHandler(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task<bool> Handle(StopAuctionCommand request, CancellationToken cancellationToken)
        {
            return await _auctionService.StopAsync(request.AuctionId);
        }
    }
}
