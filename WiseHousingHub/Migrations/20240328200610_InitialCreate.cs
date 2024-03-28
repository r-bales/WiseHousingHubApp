using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiseHousingHub.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareFeet = table.Column<double>(type: "float", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    ParkingSpaces = table.Column<int>(type: "int", nullable: false),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    WheelchairAccessible = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    DateListed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "john@example.com", "John", "Doe", "123-456-7890" });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "joet@aol.com", "Joe", "Tester", "555-744-3219" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "City", "DateListed", "Description", "Furnished", "ImageFileName", "IsVerified", "LandlordId", "LeaseType", "ParkingSpaces", "PetsAllowed", "Price", "SquareFeet", "State", "WheelchairAccessible", "Zip" },
                values: new object[] { 1, "9070 Robinette Cir", 3, 3, "Wise", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), "Welcome home to this beautiful manufactured 3 bedroom, 3 bathroom well maintained property. The location of this rental offers tons of conveniences. It is located close to restaurants, shopping centers, and schools. This rental looks and smells brand new on the inside. The rental features an open floor plan with the living room, dining room, and kitchen close together.", true, "blue_trailer.jpg", false, 1, "1-Year", 2, false, 650m, 1495.0, "Virginia", false, "24293" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "City", "DateListed", "Description", "Furnished", "ImageFileName", "IsVerified", "LandlordId", "LeaseType", "ParkingSpaces", "PetsAllowed", "Price", "SquareFeet", "State", "WheelchairAccessible", "Zip" },
                values: new object[] { 2, "9027 Camp Bethel Road", 1, 2, "Wise", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), "Are you looking for a move in ready rental full of southern charm? With recent updates to include the windows, electrical, and roof you should have no worries! Beautiful hardwood flooring in the living room, sun room to enjoy your morning coffee, on over half an acre of land. Off to itself overlooking a horse pasture.", false, "green_house.jpg", true, 2, "1-Year", 3, true, 790m, 1309.0, "Virginia", false, "24293" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "City", "DateListed", "Description", "Furnished", "ImageFileName", "IsVerified", "LandlordId", "LeaseType", "ParkingSpaces", "PetsAllowed", "Price", "SquareFeet", "State", "WheelchairAccessible", "Zip" },
                values: new object[] { 3, "826 NE Hurricane Rd", 1, 3, "Wise", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), "Check out this Cottage style house with 3 bedroom and 1 bath that has been freshly remodeled. New roof, heat pump and kitchen makes this cozy little home stand out. The refurbished hard wood floors and freshly painted walls makes this rental ready to move right in. Located conveniently close to The University of Virginias College at Wise and within walking distance to downtown Wise.", false, "white_house.jpg", false, 2, "6-Month", 1, true, 710m, 1261.0, "Virginia", true, "24293" });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties",
                column: "LandlordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Landlords");
        }
    }
}
