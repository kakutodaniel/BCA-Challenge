using Auction.Application.CQRS.Auction.Commands;
using Auction.Domain.Service.Interface;
using MediatR;

namespace Auction.Application.CQRS.Auction.Handlers
{
    public class StartAuctionCommandHandler : IRequestHandler<StartAuctionCommand, int>
    {
        private readonly IAuctionService _auctionService;

        public StartAuctionCommandHandler(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task<int> Handle(StartAuctionCommand request, CancellationToken cancellationToken)
        {
            return await _auctionService.StartAsync(request.VehicleIds);
        }
    }
}
