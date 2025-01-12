using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.Mapper;
using Auction.Domain.Service.Interface;
using MediatR;

namespace Auction.Application.CQRS.Vehicle.Handlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly IVehicleService _vehicleService;

        public CreateVehicleCommandHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var domain = VehicleMapper.ToDomain(request);

            return await _vehicleService.CreateAsync(domain);
        }
    }
}
