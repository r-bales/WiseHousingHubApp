using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WiseHousingHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareFeet = table.Column<double>(type: "float", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    ParkingSpaces = table.Column<int>(type: "int", nullable: false),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    WheelchairAccessible = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    LandlordId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateListed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LandlordId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_AspNetUsers_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_Landlords_LandlordId1",
                        column: x => x.LandlordId1,
                        principalTable: "Landlords",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "546da105-ac07-4327-95f8-cd20eb5d3148", null, "user", "user" },
                    { "9dcba639-420e-4a0a-92dc-34afb1f40b8e", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4126ad94-303f-41f1-a49f-70fb91c7bf50", 0, "2688b453-8438-4263-9e6e-f7a4a79c5756", "johndoe@aol.com", false, "John", "Doe", false, null, "JOHNDOE@AOL.COM", "JOHNDOE@AOL.COM", "AQAAAAIAAYagAAAAEMB0932TzmwTdSvvdTa/2PQC6lUrLirmKlrXzKeC07vn5gRKCYj9jY/FTdgGnECoRw==", "123-456-7890", false, "9636741a-a3f4-4b0f-92c2-1a946f9c1d9c", false, "johndoe@aol.com" },
                    { "cf455961-7b53-4058-b494-4f332fb35c85", 0, "163ed008-62be-4dcf-afa5-8d6603d8dd55", "admin@wisehousinghub.com", false, "Joe", "Tester", false, null, "ADMIN@WISEHOUSINGHUB.COM", "ADMIN@WISEHOUSINGHUB.COM", "AQAAAAIAAYagAAAAEIZGA4a2XjYFTyQ8CsX16MmSr9yYqml6R3Ae8mTNLG+rf58UUecx1FqNRDh1rtpK6g==", null, false, "c4f78075-1fcd-4886-acd0-692756a0ca8f", false, "admin@wisehousinghub.com" },
                    { "d8224d82-4bdd-4a77-807f-777a96ff8ea9", 0, "607094d9-dd83-47ed-9f0e-a5f264f1d174", "janesmith@gmail.com", false, "Jane", "Smith", false, null, "JANESMITH@GMAIL.COM", "JANESMITH@GMAIL.COM", "AQAAAAIAAYagAAAAEKdnvmyI7Ct6ax2fgVvFpiLM0TdJ1X8PiWZDI3cBYziS47y2c3gxVYznz7Xlijw/lg==", "713-210-1921", false, "910f5884-34ba-4958-9d35-fdbcd5c0b1d7", false, "janesmith@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "546da105-ac07-4327-95f8-cd20eb5d3148", "4126ad94-303f-41f1-a49f-70fb91c7bf50" },
                    { "9dcba639-420e-4a0a-92dc-34afb1f40b8e", "cf455961-7b53-4058-b494-4f332fb35c85" },
                    { "546da105-ac07-4327-95f8-cd20eb5d3148", "d8224d82-4bdd-4a77-807f-777a96ff8ea9" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "City", "DateListed", "Description", "Furnished", "ImageFileName", "IsVerified", "LandlordId", "LandlordId1", "LeaseType", "ParkingSpaces", "PetsAllowed", "Price", "SquareFeet", "State", "WheelchairAccessible", "Zip" },
                values: new object[,]
                {
                    { 1, "9070 Robinette Cir", 3, 3, "Wise", new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), "Welcome home to this beautiful manufactured 3 bedroom, 3 bathroom well maintained property. The location of this rental offers tons of conveniences. It is located close to restaurants, shopping centers, and schools. This rental looks and smells brand new on the inside. It features an open floor plan with the living room, dining room, and kitchen close together. The living room features a beautiful fireplace with gas logs. The kitchen has tons of cabinets and  a bar area. The master bedroom is very spacious with a large walk-in closet, 2 master bathrooms, and sitting area. Two additional bedrooms with walk-in closets are located on the opposite side of the rental along with a third full bath. It also features a pantry and laundry room.", true, "blue_trailer.jpg", true, "4126ad94-303f-41f1-a49f-70fb91c7bf50", null, "1-Year", 2, false, 900m, 1495.0, "Virginia", false, "24293" },
                    { 2, "9027 Camp Bethel Road", 1, 2, "Wise", new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), "Are you looking for a move in ready rental full of southern charm? With recent updates to include the windows, electrical, and roof you should have no worries! Beautiful hardwood flooring in the living room, sun room to enjoy your morning coffee, on over half an acre of land. Off to itself overlooking a horse pasture.", false, "green_house.jpg", true, "d8224d82-4bdd-4a77-807f-777a96ff8ea9", null, "1-Year", 3, true, 715m, 1309.0, "Virginia", false, "24293" },
                    { 3, "826 NE Hurricane Rd", 1, 3, "Wise", new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), "Check out this cottage-style rental with 3 bedroom and 1 bath that has been freshly remodeled. New roof, heat pump and kitchen makes this cozy little property stand out. The refurbished hard wood floors and freshly painted walls makes this rental ready to move right in. Located conveniently close to The University of Virginia's College at Wise and within walking distance to downtown Wise. Location and convenience makes this the rental for you. And the best part is out the back door just a few steps and cross the small bridge and across the creek you have a perfect place for a firepit and small gatherings.", false, "white_house.jpg", true, "d8224d82-4bdd-4a77-807f-777a96ff8ea9", null, "6-Month", 1, true, 790m, 1261.0, "Virginia", true, "24293" },
                    { 4, "6331 Stephens Rd", 2, 3, "Wise", new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), "This rental is 3 bed, 2 bath, and 1920 sq.ft. It has an open concept layout for main living area. Large kitchen with lots of oak cabinets, large island with built-in table, patio doors open onto small deck. Adjacent den has propane gas log fireplace. Formal dining room off the kitchen opens into a large living room. Large master suite with garden tub, stand up shower, large walk-in closet. Two additional bedrooms with separate full bath. Laundry room is located off kitchen/den area adjacent to back entrance. This property has a block perimeter. There is a large area fenced separately from the yard for dogs. The front yard has a nice stream that runs all year round.", false, "tan_doublewide.jpg", true, "4126ad94-303f-41f1-a49f-70fb91c7bf50", null, "1-Year", 3, true, 820m, 1920.0, "Virginia", false, "24293" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordId1",
                table: "Properties",
                column: "LandlordId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Landlords");
        }
    }
}
