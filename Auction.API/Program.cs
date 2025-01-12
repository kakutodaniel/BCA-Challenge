using Auction.API.Filters;
using Auction.Application.CQRS.Auction.Commands;
using Auction.Application.CQRS.Auction.Commands.Validators;
using Auction.Application.CQRS.Auction.Handlers;
using Auction.Application.CQRS.Auction.Queries;
using Auction.Application.CQRS.Bid.Commands;
using Auction.Application.CQRS.Bid.Commands.Validators;
using Auction.Application.CQRS.Bid.Handlers;
using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.CQRS.Vehicle.Commands.Validators;
using Auction.Application.CQRS.Vehicle.Handlers;
using Auction.Application.CQRS.Vehicle.Queries;
using Auction.Application.DTO.Auction;
using Auction.Application.DTO.Vehicle;
using Auction.Domain.Repository;
using Auction.Domain.Service;
using Auction.Domain.Service.Interface;
using Auction.Infra;
using Auction.Infra.Repository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        }).AddMvcOptions(options =>
        {
            options.Filters.Add<GlobalExceptionFilterAttribute>();
        });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<AuctionContext>(opt => opt.UseInMemoryDatabase("Auction"));

// domain service
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

// repository
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// cqrs - vehicle
builder.Services.AddScoped<IRequestHandler<CreateHatchBackCommand, int>, CreateVehicleCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateSedanCommand, int>, CreateVehicleCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateSuvCommand, int>, CreateVehicleCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateTruckCommand, int>, CreateVehicleCommandHandler>();

// cqrs - place bid
builder.Services.AddScoped<IRequestHandler<PlaceBidCommand, bool>, PlacelBidCommandHandler>();

// cqrs - auction
builder.Services.AddScoped<IRequestHandler<StartAuctionCommand, int>, StartAuctionCommandHandler>();
builder.Services.AddScoped<IRequestHandler<StopAuctionCommand, bool>, StopAuctionCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AuctionQuery, IEnumerable<AuctionResponseDto>>, AuctionQueryHandler>();

// cqrs - vehicle search
builder.Services.AddScoped<IRequestHandler<VehicleSearchQuery, IEnumerable<VehicleSearchResponseDto>>, VehicleSearchQueryHandler>();

// validators - vehicle
builder.Services.AddScoped<IValidator<CreateHatchBackCommand>, CreateHatchBackCommandValidator>();
builder.Services.AddScoped<IValidator<CreateSedanCommand>, CreateSedanCommandValidator>();
builder.Services.AddScoped<IValidator<CreateSuvCommand>, CreateSuvCommandValidator>();
builder.Services.AddScoped<IValidator<CreateTruckCommand>, CreateTruckCommandValidator>();

// validators - auction
builder.Services.AddScoped<IValidator<StartAuctionCommand>, StartAuctionCommandValidator>();
builder.Services.AddScoped<IValidator<StopAuctionCommand>, StopAuctionCommandValidator>();

// validators - bid
builder.Services.AddScoped<IValidator<PlaceBidCommand>, PlaceBidCommandValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
