using Auction.Application.DTO.Auction;

namespace Auction.Application.Mapper
{
    public class AuctionMapper
    {
        public static AuctionResponseDto ToDto(Domain.Auction domain)
        {
            return new AuctionResponseDto
            {
                Id = domain.Id,
                Active = domain.Active,
                Vehicles = domain.Vehicles.Select(x => VehicleMapper.ToDto(x))
            };
        }
    }
}
