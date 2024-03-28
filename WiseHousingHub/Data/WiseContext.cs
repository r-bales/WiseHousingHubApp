using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection.Emit;
using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
    public class WiseContext : DbContext
    {
        public WiseContext(DbContextOptions options) : base(options) { }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Landlord> Landlords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Landlord)
                .WithMany(l => l.Properties)
                .HasForeignKey(p => p.LandlordId)
                .IsRequired();

            modelBuilder.Entity<Landlord>().HasData(
                new Landlord() { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "123-456-7890" },
                new Landlord() { Id = 2, FirstName = "Joe", LastName = "Tester", Email = "joet@aol.com", PhoneNumber = "555-744-3219" }
                );

            modelBuilder.Entity<Property>().HasData(
                new Property()
                {
                    Id = 1,
                    Address = "9070 Robinette Cir",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "Welcome home to this beautiful manufactured 3 bedroom, 3 bathroom well maintained property. The location of this rental offers tons of conveniences. It is located close to restaurants, shopping centers, and schools. This rental looks and smells brand new on the inside. The rental features an open floor plan with the living room, dining room, and kitchen close together.",
                    Price = 650,
                    LeaseType = "1-Year",
                    SquareFeet = 1495,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    ParkingSpaces = 2,
                    Furnished = true,
                    WheelchairAccessible = false,
                    PetsAllowed = false,
                    DateListed = DateTime.Today,
                    ImageFileName = "blue_trailer.jpg",
                    LandlordId = 1,
                },
                new Property()
                {
                    Id = 2,
                    Address = "9027 Camp Bethel Road",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "Are you looking for a move in ready rental full of southern charm? With recent updates to include the windows, electrical, and roof you should have no worries! Beautiful hardwood flooring in the living room, sun room to enjoy your morning coffee, on over half an acre of land. Off to itself overlooking a horse pasture.",
                    Price = 790,
                    LeaseType = "1-Year",
                    SquareFeet = 1309,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    ParkingSpaces = 3,
                    Furnished = false,
                    WheelchairAccessible = false,
                    PetsAllowed = true,
                    DateListed = DateTime.Today,
                    ImageFileName = "green_house.jpg",
                    LandlordId = 2,
                    IsVerified = true,
                },
                new Property()
                {
                    Id = 3,
                    Address = "826 NE Hurricane Rd",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "Check out this Cottage style house with 3 bedroom and 1 bath that has been freshly remodeled. New roof, heat pump and kitchen makes this cozy little home stand out. The refurbished hard wood floors and freshly painted walls makes this rental ready to move right in. Located conveniently close to The University of Virginias College at Wise and within walking distance to downtown Wise.",
                    Price = 710,
                    LeaseType = "6-Month",
                    SquareFeet = 1261,
                    Bedrooms = 3,
                    Bathrooms = 1,
                    ParkingSpaces = 1,
                    Furnished = false,
                    WheelchairAccessible = true,
                    PetsAllowed = true,
                    DateListed = DateTime.Today,
                    ImageFileName = "white_house.jpg",
                    LandlordId = 2,
                }
                );

        }
    }
}
