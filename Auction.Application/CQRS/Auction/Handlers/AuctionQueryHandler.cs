using Auction.Application.CQRS.Auction.Queries;
using Auction.Application.DTO.Auction;
using Auction.Application.Mapper;
using Auction.Domain.Repository;
using MediatR;

namespace Auction.Application.CQRS.Auction.Handlers
{
    public class AuctionQueryHandler : IRequestHandler<AuctionQuery, IEnumerable<AuctionResponseDto>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionQueryHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<IEnumerable<AuctionResponseDto>> Handle(AuctionQuery request, CancellationToken cancellationToken)
        {
            var result = await _auctionRepository.GetAll();

            return result.Select(x => AuctionMapper.ToDto(x));
        }
    }
}
