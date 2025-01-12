using Auction.Application.CQRS.Vehicle.Queries;
using Auction.Application.DTO.Vehicle;
using Auction.Application.Mapper;
using Auction.Domain.Repository;
using MediatR;

namespace Auction.Application.CQRS.Vehicle.Handlers
{
    public class VehicleSearchQueryHandler : IRequestHandler<VehicleSearchQuery, IEnumerable<VehicleSearchResponseDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleSearchQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleSearchResponseDto>> Handle(VehicleSearchQuery request, CancellationToken cancellationToken)
        {
            var result = await _vehicleRepository.SearchAsync(request.Type, request.Manufacturer, request.Model, request.Year);

            return result.Select(x => VehicleMapper.ToSearchDto(x));
        }
    }
}
