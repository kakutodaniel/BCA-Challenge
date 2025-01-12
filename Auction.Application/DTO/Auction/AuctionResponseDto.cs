using Auction.Application.DTO.Vehicle;

namespace Auction.Application.DTO.Auction
{
    public class AuctionResponseDto
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public IEnumerable<VehicleResponseDto> Vehicles { get; set; }
    }
}
