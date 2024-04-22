using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection.Emit;
using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
    public class WiseContext : IdentityDbContext<ApplicationUser>
    {
        public WiseContext(DbContextOptions options) : base(options) { }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Landlord> Landlords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var user = new IdentityRole("user");
            user.NormalizedName = "user";

            modelBuilder.Entity<IdentityRole>().HasData(admin, user);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.Landlord)
                .WithMany(l => l.Properties)
                .HasForeignKey(p => p.LandlordId)
                .IsRequired(false);

            // Seed user data
            var adminUser = new ApplicationUser
            {
                UserName = "admin@wisehousinghub.com",
                Email = "admin@wisehousinghub.com",
                NormalizedUserName = "ADMIN@WISEHOUSINGHUB.COM",
                NormalizedEmail = "ADMIN@WISEHOUSINGHUB.COM",
                FirstName = "Joe",
                LastName = "Tester"
            };
            var adminPasswordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = adminPasswordHasher.HashPassword(adminUser, "P@ssword1");
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = admin.Id,
                UserId = adminUser.Id
            });


            var user1 = new ApplicationUser
            {
                UserName = "johndoe@aol.com",
                Email = "johndoe@aol.com",
                NormalizedUserName = "JOHNDOE@AOL.COM",
                NormalizedEmail = "JOHNDOE@AOL.COM",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123-456-7890"
            };
            var user1PasswordHasher = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = user1PasswordHasher.HashPassword(user1, "P@ssword1");
            modelBuilder.Entity<ApplicationUser>().HasData(user1);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = user.Id,
                UserId = user1.Id
            });


            var user2 = new ApplicationUser
            {
                UserName = "janesmith@gmail.com",
                Email = "janesmith@gmail.com",
                NormalizedUserName = "JANESMITH@GMAIL.COM",
                NormalizedEmail = "JANESMITH@GMAIL.COM",
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "713-210-1921"
            };
            var user2PasswordHasher = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = user2PasswordHasher.HashPassword(user2, "P@ssword1");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = user.Id,
                UserId = user2.Id
            });


            modelBuilder.Entity<Property>().HasData(
                new Property()
                {
                    Id = 1,
                    Address = "9070 Robinette Cir",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "Welcome home to this beautiful manufactured 3 bedroom, 3 bathroom well maintained property. The location of this rental offers tons of conveniences. It is located close to restaurants, shopping centers, and schools. This rental looks and smells brand new on the inside. It features an open floor plan with the living room, dining room, and kitchen close together. The living room features a beautiful fireplace with gas logs. The kitchen has tons of cabinets and  a bar area. The master bedroom is very spacious with a large walk-in closet, 2 master bathrooms, and sitting area. Two additional bedrooms with walk-in closets are located on the opposite side of the rental along with a third full bath. It also features a pantry and laundry room.",
                    Price = 900,
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
                    LandlordId = user1.Id,
                    IsVerified = true,
                },
                new Property()
                {
                    Id = 2,
                    Address = "9027 Camp Bethel Road",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "Are you looking for a move in ready rental full of southern charm? With recent updates to include the windows, electrical, and roof you should have no worries! Beautiful hardwood flooring in the living room, sun room to enjoy your morning coffee, on over half an acre of land. Off to itself overlooking a horse pasture.",
                    Price = 715,
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
                    LandlordId = user2.Id,
                    IsVerified = true,
                },
                new Property()
                {
                    Id = 3,
                    Address = "826 NE Hurricane Rd",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "Check out this cottage-style rental with 3 bedroom and 1 bath that has been freshly remodeled. New roof, heat pump and kitchen makes this cozy little property stand out. The refurbished hard wood floors and freshly painted walls makes this rental ready to move right in. Located conveniently close to The University of Virginia's College at Wise and within walking distance to downtown Wise. Location and convenience makes this the rental for you. And the best part is out the back door just a few steps and cross the small bridge and across the creek you have a perfect place for a firepit and small gatherings.",
                    Price = 790,
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
                    LandlordId = user2.Id,
                    IsVerified = true,
                },
                new Property()
                {
                    Id = 4,
                    Address = "6331 Stephens Rd",
                    City = "Wise",
                    State = "Virginia",
                    Zip = "24293",
                    Description = "This rental is 3 bed, 2 bath, and 1920 sq.ft. It has an open concept layout for main living area. Large kitchen with lots of oak cabinets, large island with built-in table, patio doors open onto small deck. Adjacent den has propane gas log fireplace. Formal dining room off the kitchen opens into a large living room. Large master suite with garden tub, stand up shower, large walk-in closet. Two additional bedrooms with separate full bath. Laundry room is located off kitchen/den area adjacent to back entrance. This property has a block perimeter. There is a large area fenced separately from the yard for dogs. The front yard has a nice stream that runs all year round.",
                    Price = 820,
                    LeaseType = "1-Year",
                    SquareFeet = 1920,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    ParkingSpaces = 3,
                    Furnished = false,
                    WheelchairAccessible = false,
                    PetsAllowed = true,
                    DateListed = DateTime.Today,
                    ImageFileName = "tan_doublewide.jpg",
                    LandlordId = user1.Id,
                    IsVerified = true,
				}
                );
        }
    }
}
