using Auction.Domain;
using Auction.Infra.Model;

namespace Auction.Infra.Mapper
{
    public class VehicleMapper
    {
        public static VehicleDataModel ToDataModel(Vehicle vehicle)
        {
            var model = new VehicleDataModel
            {
                Identifier = vehicle.Identifier,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Year = vehicle.Year,
                StartingBid = vehicle.StartingBid
            };

            switch (vehicle)
            {
                case Hatchback hatchBack:
                    model.Type = VehicleType.Hatchback.Name;
                    model.NumberOfDoors = hatchBack.NumberOfDoors;
                    break;
                case Sedan sedan:
                    model.Type = VehicleType.Sedan.Name;
                    model.NumberOfDoors = sedan.NumberOfDoors;
                    break;
                case Suv suv:
                    model.Type = VehicleType.SUV.Name;
                    model.NumberOfSeats = suv.NumberOfSeats;
                    break;
                case Truck truck:
                    model.Type = VehicleType.Truck.Name;
                    model.LoadCapacity = truck.LoadCapacity;
                    break;
                default:
                    throw new NotImplementedException(); //TODO
            }

            return model;
        }

        public static Vehicle ToDomain(VehicleDataModel model)
        {
            switch (model.Type)
            {
                case var type when type == VehicleType.Hatchback.Name:
                    var hatchBack = new Hatchback(model.Id, model.Identifier, model.Manufacturer, model.Model, model.Year, model.StartingBid, model.NumberOfDoors);
                    hatchBack.AddAuctions(model.Auctions == null ? Enumerable.Empty<Domain.Auction>() : model.Auctions.Select(x => new Domain.Auction(x.Id, x.Active)));
                    return hatchBack;
                case var type when type == VehicleType.Sedan.Name:
                    var sedan = new Sedan(model.Id, model.Identifier, model.Manufacturer, model.Model, model.Year, model.StartingBid, model.NumberOfDoors);
                    sedan.AddAuctions(model.Auctions == null ? Enumerable.Empty<Domain.Auction>() : model.Auctions.Select(x => new Domain.Auction(x.Id, x.Active)));
                    return sedan;
                case var type when type == VehicleType.SUV.Name:
                    var suv = new Suv(model.Id, model.Identifier, model.Manufacturer, model.Model, model.Year, model.StartingBid, model.NumberOfSeats);
                    suv.AddAuctions(model.Auctions == null ? Enumerable.Empty<Domain.Auction>() : model.Auctions.Select(x => new Domain.Auction(x.Id, x.Active)));
                    return suv;
                case var type when type == VehicleType.Truck.Name:
                    var truck = new Truck(model.Id, model.Identifier, model.Manufacturer, model.Model, model.Year, model.StartingBid, model.LoadCapacity);
                    truck.AddAuctions(model.Auctions == null ? Enumerable.Empty<Domain.Auction>() : model.Auctions.Select(x => new Domain.Auction(x.Id, x.Active)));
                    return truck;
                default:
                    throw new NotImplementedException(); // TODO
            }
        }

    }
}
