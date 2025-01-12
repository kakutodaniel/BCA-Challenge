using Auction.Application.CQRS.Bid.Commands;
using Auction.Domain.Service.Interface;
using MediatR;

namespace Auction.Application.CQRS.Bid.Handlers
{
    public class PlacelBidCommandHandler : IRequestHandler<PlaceBidCommand, bool>
    {
        private readonly IBidService _bidService;

        public PlacelBidCommandHandler(IBidService bidService)
        {
            _bidService = bidService;
        }

        public async Task<bool> Handle(PlaceBidCommand request, CancellationToken cancellationToken)
        {
            return await _bidService.PlaceBidAsync(request.VehicleId, request.Amount);
        }
    }
}
