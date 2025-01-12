using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.DTO.Vehicle;
using Auction.Domain;

namespace Auction.Application.Mapper
{
    public class VehicleMapper
    {
        public static Domain.Vehicle ToDomain(CreateVehicleCommand createVehicleCommand)
        {
            return createVehicleCommand switch
            {
                CreateHatchBackCommand hatch => new Hatchback(hatch.Identifier, hatch.Manufacturer, hatch.Model, hatch.Year, hatch.StartingBid, hatch.NumberOfDoors),
                CreateSedanCommand sedan => new Sedan(sedan.Identifier, sedan.Manufacturer, sedan.Model, sedan.Year, sedan.StartingBid, sedan.NumberOfDoors),
                CreateSuvCommand suv => new Suv(suv.Identifier, suv.Manufacturer, suv.Model, suv.Year, suv.StartingBid, suv.NumberOfSeats),
                CreateTruckCommand truck => new Truck(truck.Identifier, truck.Manufacturer, truck.Model, truck.Year, truck.StartingBid, truck.LoadCapacity),
                _ => throw new NotImplementedException(),// TODO
            };
        }

        public static VehicleResponseDto ToDto(Domain.Vehicle domain)
        {
            var dto = new VehicleResponseDto
            {
                Id = domain.Id,
                Identifier = domain.Identifier,
                Manufacturer = domain.Manufacturer,
                Model = domain.Model,
                Year = domain.Year,
                StartingBid = domain.StartingBid,
            };

            switch (domain)
            {
                case Hatchback hatch:
                    dto.Type = VehicleType.Hatchback.Name;
                    dto.NumberOfDoors = hatch.NumberOfDoors;
                    break;
                case Sedan sedan:
                    dto.Type = VehicleType.Sedan.Name;
                    dto.NumberOfDoors = sedan.NumberOfDoors;
                    break;
                case Suv suv:
                    dto.Type = VehicleType.SUV.Name;
                    dto.NumberOfSeats = suv.NumberOfSeats;
                    break;
                case Truck truck:
                    dto.Type = VehicleType.Truck.Name;
                    dto.LoadCapacity = truck.LoadCapacity;
                    break;
                default:
                    throw new NotImplementedException(); // TODO
            }

            return dto;
        }

        public static VehicleSearchResponseDto ToSearchDto(Domain.Vehicle domain)
        {
            var dto = new VehicleSearchResponseDto
            {
                Id = domain.Id,
                Identifier = domain.Identifier,
                Manufacturer = domain.Manufacturer,
                Model = domain.Model,
                Year = domain.Year,
                StartingBid = domain.StartingBid,
            };

            switch (domain)
            {
                case Hatchback hatch:
                    dto.Type = VehicleType.Hatchback.Name;
                    dto.NumberOfDoors = hatch.NumberOfDoors;
                    break;
                case Sedan sedan:
                    dto.Type = VehicleType.Sedan.Name;
                    dto.NumberOfDoors = sedan.NumberOfDoors;
                    break;
                case Suv suv:
                    dto.Type = VehicleType.SUV.Name;
                    dto.NumberOfSeats = suv.NumberOfSeats;
                    break;
                case Truck truck:
                    dto.Type = VehicleType.Truck.Name;
                    dto.LoadCapacity = truck.LoadCapacity;
                    break;
                default:
                    throw new NotImplementedException(); // TODO
            }

            return dto;
        }

    }
}
