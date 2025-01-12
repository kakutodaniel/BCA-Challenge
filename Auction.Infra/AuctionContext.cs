using Auction.Infra.Model;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infra
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options)
                : base(options)
        {
        }

        public DbSet<VehicleDataModel> Vehicles { get; set; }
        public DbSet<AuctionDataModel> Auctions { get; set; }
        public DbSet<BidDataModel> Bids { get; set; }
        public DbSet<AuctionVehicleDataModel> AuctionsVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDataModel>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<VehicleDataModel>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<VehicleDataModel>()
                .HasIndex(c => c.Identifier)
                .IsUnique();


            modelBuilder.Entity<AuctionDataModel>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<AuctionDataModel>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AuctionDataModel>()
                .HasMany(x => x.Vehicles)
                .WithMany(x => x.Auctions)
                .UsingEntity<AuctionVehicleDataModel>();

            modelBuilder.Entity<BidDataModel>()
                .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }

    }

}
