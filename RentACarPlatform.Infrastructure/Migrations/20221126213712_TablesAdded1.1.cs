using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarPlatform.Infrastructure.Migrations
{
    public partial class TablesAdded11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategory_CategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarPurpose_PurposeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Location_LocationId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPurpose",
                table: "CarPurpose");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarCategory",
                table: "CarCategory");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "CarPurpose",
                newName: "CarPurposes");

            migrationBuilder.RenameTable(
                name: "CarCategory",
                newName: "CarCategories");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPurposes",
                table: "CarPurposes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarCategories",
                table: "CarCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Protections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Coverage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationId = table.Column<int>(type: "int", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Locations_DropOffLocationId",
                        column: x => x.DropOffLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_DropOffLocationId",
                table: "Rentals",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PickUpLocationId",
                table: "Rentals",
                column: "PickUpLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "CarCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarPurposes_PurposeId",
                table: "Cars",
                column: "PurposeId",
                principalTable: "CarPurposes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Locations_LocationId",
                table: "Cars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategories_CategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarPurposes_PurposeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Locations_LocationId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Protections");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPurposes",
                table: "CarPurposes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarCategories",
                table: "CarCategories");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "CarPurposes",
                newName: "CarPurpose");

            migrationBuilder.RenameTable(
                name: "CarCategories",
                newName: "CarCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPurpose",
                table: "CarPurpose",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarCategory",
                table: "CarCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategory_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "CarCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarPurpose_PurposeId",
                table: "Cars",
                column: "PurposeId",
                principalTable: "CarPurpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Location_LocationId",
                table: "Cars",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
