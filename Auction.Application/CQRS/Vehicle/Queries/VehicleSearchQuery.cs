using Auction.Application.DTO.Vehicle;
using MediatR;

namespace Auction.Application.CQRS.Vehicle.Queries
{
    public record VehicleSearchQuery(string? Type, string? Manufacturer, string? Model, int? Year) : IRequest<IEnumerable<VehicleSearchResponseDto>>;
}
