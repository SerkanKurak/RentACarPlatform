using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarPlatform.Infrastructure.Migrations
{
    public partial class SeedDbAndAddChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

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
                name: "CarCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarPurposes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPurposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

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
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Gearbox = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    TankCapacity = table.Column<int>(type: "int", nullable: false),
                    FuelConsumption = table.Column<double>(type: "float", nullable: false),
                    TrunkVolume = table.Column<int>(type: "int", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    Cubage = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PurposeId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_ApplicationUser_RenterId",
                        column: x => x.RenterId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_CarCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CarCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarPurposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "CarPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CountryName", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "3f6886a4-2245-4a3a-adc7-ada28f8446ab", null, "guest@mail.com", false, null, true, null, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEIvpBNcDOHItMD9Mlx4mioxX85f1S1BFRN87+ZVESjami2tritJyXLL9tR7B6UYATg==", null, false, null, false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "f7a2c21a-4247-4262-bf7f-ed5e7aba2ab3", null, "agent@mail.com", false, null, true, null, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEH5xZ0THZBY7Jdeev4Jle5NKkqGax0zVgcUlagtVfaWdhijjl/dSNC7YIbbTkHC/ww==", null, false, null, false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Седан" },
                    { 2, "Комби" },
                    { 3, "Джип" },
                    { 4, "Пикап" },
                    { 5, "Купе" },
                    { 6, "Кабрио" },
                    { 7, "Ван" },
                    { 8, "Хечбег" }
                });

            migrationBuilder.InsertData(
                table: "CarPurposes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Икономичен" },
                    { 2, "Икономичен Комби" },
                    { 3, "Компактен" },
                    { 4, "Стандартен" },
                    { 5, "Стандартен Комби" },
                    { 6, "Голям" },
                    { 7, "Луксозен" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "София - Офис" },
                    { 2, "София - Избран от вас адрес" },
                    { 3, "София - Летище Терминал 1" },
                    { 4, "София - Летище Терминал 2" },
                    { 5, "Варна - Офис" },
                    { 6, "Варна - Избран от вас адрес" },
                    { 7, "Варна - Летище" },
                    { 8, "Пловдив - Офис" },
                    { 9, "Пловдив - Избран от вас адрес" },
                    { 10, "Пловдив - Летище" }
                });

            migrationBuilder.InsertData(
                table: "Protections",
                columns: new[] { "Id", "Coverage", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Защита от кражба", "Основен", 0.00m },
                    { 2, "Защита от кражба,Застраховка злополука,Покрива щети на челното стъкло, фарове и гуми", "Среден", 30.00m },
                    { 3, "Защита от кражба,Застраховка злополука,Покрива щети на челното стъкло, фарове и гуми,Застраховка на багажа", "Висок", 50.00m }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AgentId", "Availability", "CategoryId", "Cubage", "Doors", "FuelConsumption", "FuelType", "Gearbox", "Horsepower", "ImageUrl", "IsActive", "LocationId", "Make", "Model", "PricePerDay", "PurposeId", "RenterId", "Seats", "TankCapacity", "TrunkVolume", "Year" },
                values: new object[,]
                {
                    { 1, 1, true, 1, 3500, 4, 8.0, "Дизел", "Автоматична", 265, "https://i.ytimg.com/vi/QQk2WVpkck0/maxresdefault.jpg", true, 1, "Mercedes-Benz", "E 350", 300m, 7, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 5, 80, 540, "2011" },
                    { 2, 1, true, 1, 5000, 4, 15.0, "Бензин", "Автоматична", 435, "https://rentaluxcar.bg/wp-content/uploads/2018/09/mercedes-s500-5.jpg", true, 1, "Mercedes-Benz", "S 500", 450m, 7, null, 5, 80, 560, "2018" },
                    { 3, 1, true, 1, 3000, 4, 14.5, "Бензин", "Автоматична", 350, "https://media.ed.edmunds-media.com/audi/a8/2021/oem/2021_audi_a8_sedan_l_fq_oem_2_815.jpg", true, 1, "Audi", "A8", 500m, 7, null, 5, 80, 520, "2021" },
                    { 4, 1, true, 3, 4000, 4, 20.0, "Бензин", "Автоматична", 550, "https://upload.wikimedia.org/wikipedia/commons/9/94/2020_Bentley_Bentayga_facelift.jpg", true, 1, "Bentley", "Bentayga", 700m, 7, null, 5, 85, 520, "2020" },
                    { 5, 1, true, 3, 3000, 4, 16.0, "Бензин", "Автоматична", 340, "https://www.ccarprice.com/products/Porsche-Cayenne-S-2019.png", true, 1, "Porsche", "Cayenne", 650m, 7, null, 5, 75, 600, "2019" },
                    { 6, 1, true, 3, 3000, 4, 16.5, "Дизел", "Автоматична", 351, "https://i.ytimg.com/vi/EP9BFxNb_3s/maxresdefault.jpg", true, 1, "Land Rover", "Range Rover", 700m, 7, null, 5, 85, 2450, "2020" },
                    { 7, 1, true, 5, 4000, 2, 16.0, "Бензин", "Автоматична", 470, "https://dubicars.com/images/485195/1000x564/car-to-point-automobile-fze/6f4b4686-0144-4e36-858d-8053c0c6a608.jpg", true, 1, "Mercedes-Benz", "S 560", 650m, 7, null, 4, 80, 700, "2020" },
                    { 8, 1, true, 1, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://cdn.jdpower.com/JDPA_2020%20Volkswagen%20Passat%20R-Line%20Aurora%20Red%20Front%20View%20Small_edited.jpg", true, 1, "Volkswagen", "Passat", 300m, 4, null, 5, 65, 1200, "2020" },
                    { 9, 1, true, 2, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://cdn.jdpower.com/JDPA_2020%20Volkswagen%20Passat%20R-Line%20Aurora%20Red%20Front%20View%20Small_edited.jpg", true, 1, "Volkswagen", "Passat", 300m, 5, null, 5, 65, 1400, "2020" },
                    { 10, 1, true, 2, 2000, 4, 7.0, "Дизел", "Автоматична", 185, "https://automedia.investor.bg/media/files/resized/uploadedfiles/640x0/b26/c230bdb3a7c8e9242f83577101b65b26-1920px-2018-skoda-octavia-5e-my185-110tsi-station-wagon-2018-11-02.jpg", true, 1, "Skoda", "Octavia", 280m, 5, null, 5, 60, 1300, "2017" },
                    { 11, 1, true, 6, 2000, 2, 6.0, "Дизел", "Автоматична", 136, "https://i.ebayimg.com/images/g/6akAAOSwFE1jZ3bV/s-l1600.jpg", true, 1, "Peugeot", "307", 200m, 3, null, 4, 50, 350, "2009" },
                    { 12, 1, true, 3, 1600, 4, 8.0, "Дизел", "Автоматична", 130, "https://feassets.bymycar.fr/vo/13/191976/0/renault-kadjar-tce-130-energy-occasion-2017-epinal.jpg", true, 1, "Renault", "Kadjar", 200m, 4, null, 5, 65, 1450, "2017" },
                    { 13, 1, true, 6, 2500, 2, 7.5, "Дизел", "Автоматична", 163, "http://usclassifieds4all.com/pictures/2960595/main.jpg", true, 1, "Audi", "A4", 170m, 4, null, 4, 65, 315, "2008" },
                    { 14, 1, true, 5, 2000, 2, 6.0, "Дизел", "Автоматична", 140, "https://www.motortrend.com/uploads/sites/5/2013/11/2013-Volkswagen-Scirocco-R-front-three-quarters1.jpg", true, 1, "Volkswagen", "Scirocco", 200m, 4, null, 4, 55, 300, "2013" },
                    { 15, 1, true, 2, 1600, 4, 5.0, "Дизел", "Автоматична", 110, "https://aaaautoeuimg.vshcdn.net/thumb/700122107_640x480x95.jpg?51677", true, 1, "Volkswagen", "Golf", 210m, 2, null, 5, 50, 1600, "2013" },
                    { 16, 1, true, 4, 3200, 4, 15.0, "Дизел", "Автоматична", 200, "https://www.auto-data.net/images/f10/ford-ranger-iii-double-cab.jpg", true, 2, "Ford", "Ranger", 280m, 6, null, 5, 80, 3000, "2012" },
                    { 17, 1, true, 2, 1400, 4, 5.0, "Дизел", "Ръчни", 90, "https://www.auto-data.net/images/f10/ford-ranger-iii-double-cab.jpg", true, 2, "Toyota", "Auris", 250m, 2, null, 5, 50, 1600, "2013" },
                    { 18, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://autobild.bg/wp-content/uploads/2021/09/IMG_5826.jpg", true, 2, "Opel", "Mokka", 280m, 1, null, 5, 45, 1100, "2020" },
                    { 19, 1, true, 7, 2000, 4, 7.0, "Дизел", "Автоматична", 140, "https://123auta-katalog-902363.c.cdn77.org/prodej/volkswagen/sharan/f_344277_volkswagen_sharan_1.jpg", true, 2, "Volkswagen", "Sharan", 260m, 1, null, 5, 70, 2400, "2012" },
                    { 20, 1, true, 8, 1200, 4, 5.0, "Бензин", "Автоматична", 110, "https://cloud.leparking.fr/2021/04/27/00/23/peugeot-208-peugeot-208-2015-67000km-garantie-inconnu_8085850837.jpg", true, 2, "Peugeot", "208", 200m, 1, null, 5, 50, 1000, "2015" },
                    { 21, 1, true, 8, 1200, 4, 5.0, "Бензин", "Автоматична", 110, "https://ssl.caranddriving.com/cdwebsite/image169.ashx?url=https://ssl.caranddriving.com/ssl/f2/images/used/big/peugeot2082015to2019.jpg", true, 3, "Peugeot", "208", 200m, 1, null, 5, 50, 1000, "2015" },
                    { 22, 1, true, 8, 1400, 4, 4.5, "Дизел", "Автоматична", 90, "https://cdn.japanesecartrade.com/jct/vehicle_image/1_163284229161533233e6ce7.png", true, 3, "Toyota", "Auris", 190m, 1, null, 5, 50, 800, "2016" },
                    { 23, 1, true, 2, 1400, 4, 4.5, "Дизел", "Автоматична", 90, "https://www.wyborkierowcow.pl/wp-content/uploads/2020/04/Toyota-Auris-II-05.jpg", true, 3, "Toyota", "Auris", 200m, 2, null, 5, 50, 1400, "2012" },
                    { 24, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://redbook.pxcrush.net/redbookcars/car/spec/rena11ld.jpg?pxc_method=fit&pxc_size=1795%2C1195", true, 3, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2014" },
                    { 25, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://www.nastarta.com/wp-content/uploads/2019/01/3c41a301-2020-renault-clio-exterior-24.jpg", true, 3, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 26, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://cdn.euroncap.com/media/63573/opelvauxhall-mokka.png", true, 3, "Opel", "Mokka", 270m, 1, null, 5, 45, 1100, "2021" },
                    { 27, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://www.elcarrocolombiano.com/wp-content/uploads/2020/03/20200304-RENAULT-DUSTER-2021-PRECIO-CARACTERISTICAS-EN-BRASIL-01.jpg", true, 3, "Dacia", "Duster", 280m, 1, null, 5, 50, 1150, "2021" },
                    { 28, 1, true, 1, 1600, 4, 7.0, "Бензин", "Автоматична", 132, "https://www.avtotachki.com/wp-content/uploads/2020/11/toyota-corolla-2016-1024x685.jpg", true, 3, "Toyota", "Corolla", 250m, 4, null, 5, 55, 1450, "2016" },
                    { 29, 1, true, 1, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://www.reezocar.com/raw/ouestfrance-auto.com/RZCOSTFR22082596/CITROEN-C5-00.jpg", true, 3, "Citroen", "C5", 240m, 1, null, 5, 70, 1300, "2016" },
                    { 30, 1, true, 8, 1200, 4, 4.0, "Дизел", "Автоматична", 75, "https://www.avtotachki.com/wp-content/uploads/2020/12/hyundai-i10-2017-1024x640.jpg", true, 3, "Hyundai", "i10", 200m, 1, null, 5, 40, 600, "2017" },
                    { 31, 1, true, 8, 1200, 4, 4.0, "Дизел", "Автоматична", 75, "https://www.auto-data.net/images/f11/Hyundai-Grand-i10-facelift-2017.jpg", true, 4, "Hyundai", "i10", 200m, 1, null, 5, 40, 600, "2017" },
                    { 32, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://upload.wikimedia.org/wikipedia/commons/c/c2/2018_Dacia_Duster_Comfort_1.6.jpg", true, 4, "Dacia", "Duster", 270m, 1, null, 5, 50, 1150, "2021" },
                    { 33, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://automedia.investor.bg//media/files/resized/article/w1200x630/a6c/1a2da3011137c52b83be083ab589ba6c-05-1.jpg", true, 4, "Dacia", "Duster", 270m, 1, null, 5, 50, 1150, "2021" },
                    { 34, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://i.dir-i.net/CMS/2020/04/29/r/5f_rmzt8o.jpg", true, 4, "Opel", "Mokka", 270m, 1, null, 5, 45, 1100, "2021" },
                    { 35, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://upload.wikimedia.org/wikipedia/commons/3/3e/2015_Renault_Clio_%28X98%29_Expression_hatchback_%2826317268600%29.jpg", true, 4, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2015" },
                    { 36, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://carsguide-res.cloudinary.com/image/upload/f_auto%2Cfl_lossy%2Cq_auto%2Ct_default/v1/editorial/reanault-clio-2015-%282%29.jpg", true, 4, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2015" },
                    { 37, 1, true, 1, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://www.honestjohn.co.uk/media/_v6/10057504/Citroen%20C5%20(3).jpg?width=640&height=426&rmode=crop", true, 4, "Citroen", "C5", 240m, 1, null, 5, 70, 1300, "2016" },
                    { 38, 1, true, 2, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://www.wallpaperup.com/uploads/wallpapers/2014/07/01/382987/466d31f330aaa936eb220137992039ae.jpg", true, 4, "Citroen", "C5", 240m, 2, null, 5, 70, 1900, "2016" },
                    { 39, 1, true, 1, 1600, 4, 5.0, "Дизел", "Автоматична", 110, "https://cars.usnews.com/static/images/Auto/izmo/i4875/2015_audi_s4_angularfront.jpg", true, 4, "Audi", "A3", 350m, 4, null, 5, 50, 800, "2015" },
                    { 40, 1, true, 1, 2000, 4, 6.0, "Бензин", "Автоматична", 215, "https://media.ed.edmunds-media.com/honda/accord/2017/oem/2017_honda_accord_coupe_touring-v-6_fq_oem_1_1600.jpg", true, 4, "Honda", "Accord", 330m, 4, null, 5, 60, 1300, "2017" },
                    { 41, 1, true, 1, 5000, 4, 15.0, "Бензин", "Автоматична", 435, "https://automoto.bg/listings/media/listing/1665143074_11663883691396796_h6.jpg", true, 5, "Mercedes-Benz", "S 500", 500m, 7, null, 5, 80, 1500, "2018" },
                    { 42, 1, true, 3, 4000, 4, 12.0, "Дизел", "Автоматична", 330, "https://media.ed.edmunds-media.com/mercedes-benz/gls-class/2020/oem/2020_mercedes-benz_gls-class_4dr-suv_gls-450-4matic_fq_oem_1_1600.jpg", true, 5, "Mercedes-Benz", "GLS", 600m, 7, null, 7, 90, 2400, "2020" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AgentId", "Availability", "CategoryId", "Cubage", "Doors", "FuelConsumption", "FuelType", "Gearbox", "Horsepower", "ImageUrl", "IsActive", "LocationId", "Make", "Model", "PricePerDay", "PurposeId", "RenterId", "Seats", "TankCapacity", "TrunkVolume", "Year" },
                values: new object[,]
                {
                    { 43, 1, true, 3, 3000, 4, 16.5, "Дизел", "Автоматична", 351, "https://motorwheels.com/wp-content/uploads/2022/04/277665549_2059777500848840_7494595185657904763_n-large.jpg", true, 5, "Land Rover", "Range Rover", 700m, 7, null, 7, 85, 2450, "2020" },
                    { 44, 1, true, 6, 6000, 2, 24.0, "Бензин", "Автоматична", 630, "https://www.carpixel.net/w/e0bcc7742ce822e710a2bd683ff62cce/bentley-continental-gt-speed-convertible-beverley-hills-by-mulliner-wallpaper-hd-116579.jpg", true, 5, "Bentley", "Continental", 750m, 7, null, 4, 90, 650, "2022" },
                    { 45, 1, true, 3, 6000, 4, 20.0, "Бензин", "Автоматична", 420, "https://media.ed.edmunds-media.com/cadillac/escalade/2021/oem/2021_cadillac_escalade_4dr-suv_premium-luxury_fq_oem_1_1280.jpg", true, 5, "Cadillac", "Escalade", 780m, 7, null, 6, 90, 3200, "2021" },
                    { 46, 1, true, 2, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://7cars.bg/wp-content/uploads/2020/06/7FEF9366-697C-4454-8420-9127B9917BFC-876x535.jpeg", true, 5, "Volkswagen", "Passat", 350m, 5, null, 5, 65, 1400, "2020" },
                    { 47, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://vcache.arnoldclark.com/imageserver/ATRKNZF1X7-DUN6/800/f", true, 5, "Opel", "Mokka", 300m, 1, null, 5, 45, 1100, "2020" },
                    { 48, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://rentacar.bg/wp-content/uploads/2021/11/new-Dacia-Duster-for-rent-a-car-by-Autojet.png", true, 5, "Dacia", "Duster", 270m, 1, null, 5, 50, 1150, "2021" },
                    { 49, 1, true, 1, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://images.cars.com/cldstatic/wp-content/uploads/volkswagen-passat-2020-01-angle--blue--exterior--front--mountains.jpg", true, 5, "Volkswagen", "Passat", 340m, 4, null, 5, 65, 1100, "2020" },
                    { 50, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://partners.renault.bg/uploads/renault_clio5_hev_ph1_013.jpg", true, 5, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 51, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://editorial.pxcrush.net/carsales/general/editorial/21227129_2019_-_new_renault_clio_test_drive_in_portugal.jpg?width=1024&height=682", true, 6, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 52, 1, true, 8, 1600, 4, 5.5, "Дизел", "Ръчни", 90, "https://senda.us/autocraft/avisnew/images/veh_images/16285796354WVWZZZ6RZCU081562_DSCN1049.jpg", true, 6, "Volkswagen", "Polo", 200m, 3, null, 5, 45, 900, "2012" },
                    { 53, 1, true, 8, 2000, 4, 6.0, "Дизел", "Автоматични", 150, "https://auto.ironhorse.ru/wp-content/uploads/2015/12/Golf-7-old.jpg", true, 6, "Volkswagen", "Golf", 220m, 3, null, 5, 50, 1200, "2013" },
                    { 54, 1, true, 1, 1600, 4, 5.0, "Дизел", "Автоматична", 110, "https://www.audiworld.com/wp-content/uploads/2014/09/15-a3-rt-8.jpg", true, 6, "Audi", "A3", 350m, 4, null, 5, 50, 800, "2015" },
                    { 55, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://carsguide-res.cloudinary.com/image/upload/f_auto%2Cfl_lossy%2Cq_auto%2Ct_default/v1/editorial/reanault-clio-2015-%282%29.jpg", true, 6, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2015" },
                    { 56, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://cdn3.focus.bg/autodata/i/renault/clio/clio-iv/large/d02101a58a3050ed3af28d218df191f8.jpg", true, 7, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2015" },
                    { 57, 1, true, 2, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://s1.cdn.autoevolution.com/images/gallery/CITROEN-C5-Tourer-5734_10.jpg", true, 7, "Citroen", "C5", 240m, 2, null, 5, 70, 1900, "2016" },
                    { 58, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://www.njuskalo.hr/image-w920x690/auti/renault-clio-tce-limited-edition-1-vlasnik-bogata-oprema-top-stanje-slika-178409760.jpg", true, 7, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 59, 1, true, 7, 2000, 4, 7.0, "Дизел", "Автоматична", 140, "https://123auta-katalog-902363.c.cdn77.org/prodej/volkswagen/sharan/f_493710_volkswagen_sharan_1.jpg", true, 7, "Volkswagen", "Sharan", 260m, 4, null, 7, 70, 2400, "2012" },
                    { 60, 1, true, 3, 5600, 4, 25.0, "Бензин", "Автоматична", 320, "https://cdn.car-recalls.eu/wp-content/uploads/2021/01/Infiniti-QX56-2009-airbag.jpg", true, 7, "Infiniti", "QX56", 280m, 6, null, 7, 100, 3400, "2009" },
                    { 61, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://car-images.bauersecure.com/wp-images/13181/mokka_100.jpg", true, 7, "Opel", "Mokka", 300m, 1, null, 5, 45, 1100, "2020" },
                    { 62, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://selection.renault.bg/thumbs/cars/4873/IMG_1035.jpg", true, 7, "Dacia", "Duster", 270m, 1, null, 5, 50, 1150, "2021" },
                    { 63, 1, true, 8, 1600, 4, 5.5, "Дизел", "Ръчни", 90, "https://imgd.aeplcdn.com/1280x720/cw/cars/discontinued/volkswagen/polo-2012-2014.jpg?q=75", true, 7, "Volkswagen", "Polo", 200m, 3, null, 5, 45, 900, "2012" },
                    { 64, 1, true, 8, 2000, 4, 6.0, "Дизел", "Автоматични", 150, "https://cars.usnews.com/static/images/Auto/izmo/352203/2013_volkswagen_golf_angularfront.jpg", true, 7, "Volkswagen", "Golf", 220m, 3, null, 5, 50, 1200, "2013" },
                    { 65, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://m4.netinfo.bg/media/images/38599/38599839/655-402-renault-clio-v-test-drajv.jpg", true, 7, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 66, 1, true, 3, 3000, 4, 11.0, "Дизел", "Автоматична", 286, "https://mobistatic1.focus.bg/mobile/photosmob/927/2/big/21536513728752927_U7.jpg", true, 8, "Audi", "Q8", 500m, 7, null, 5, 75, 1800, "2020" },
                    { 67, 1, true, 3, 3000, 4, 10.0, "Дизел", "Автоматична", 286, "https://www.trucks.com/wp-content/uploads/2018/11/2018-audi-q7-fea.jpg", true, 8, "Audi", "Q7", 480m, 7, null, 5, 75, 2000, "2018" },
                    { 68, 1, true, 1, 4000, 4, 12.0, "Дизел", "Автоматична", 400, "https://mobistatic4.focus.bg/mobile/photosorg/425/1/big/11666078881872425_Rd.jpg", true, 8, "BMW", "750", 500m, 7, null, 5, 80, 1500, "2019" },
                    { 69, 1, true, 3, 3000, 4, 10.0, "Дизел", "Автоматична", 286, "https://media.ed.edmunds-media.com/audi/q7/2018/oem/2018_audi_q7_4dr-suv_30t-prestige-quattro_fq_oem_1_1600.jpg", true, 8, "Audi", "Q7", 480m, 7, null, 5, 75, 2000, "2018" },
                    { 70, 1, true, 4, 5700, 4, 20.0, "Бензин", "Автоматична", 395, "https://di-uploads-pod12.dealerinspire.com/universitydodgeram/uploads/2017/11/2018Ram1500_UniversityDodge.jpg", true, 8, "RAM", "1500", 430m, 6, null, 6, 90, 2400, "2018" },
                    { 71, 1, true, 8, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://www.carpixel.net/w/a38025585b428caf0a5e472b1da228bb/mini-cooper-s-countryman-car-wallpaper-101089.jpg", true, 8, "Mini", "Countryman", 380m, 1, null, 5, 50, 1400, "2020" },
                    { 72, 1, true, 1, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://www.avtotachki.com/wp-content/uploads/2021/02/volkswagen-passat-2020.jpg", true, 8, "Volkswagen", "Passat", 350m, 4, null, 5, 65, 1100, "2020" },
                    { 73, 1, true, 6, 3000, 2, 8.0, "Дизел", "Автоматична", 204, "http://cdn.carbuzz.com/gallery-images/1600/336000/400/336459.jpg", true, 8, "Audi", "A5", 320m, 4, null, 4, 60, 800, "2013" },
                    { 74, 1, true, 7, 2000, 4, 7.5, "Дизел", "Автоматична", 140, "https://www.auto-data.net/images/f46/Volkswagen-Touran-I-facelift-2010_1.jpg", true, 8, "Volkswagen", "Touran", 250m, 3, null, 5, 60, 2000, "2012" },
                    { 75, 1, true, 5, 3000, 2, 9.0, "Дизел", "Автоматична", 245, "https://cdn.bmwblog.com/wp-content/uploads/2022/03/bmw-m3-e92-lime-rock-edition-fire-orange-20-scaled.jpg", true, 8, "BMW", "330", 300m, 4, null, 4, 60, 800, "2013" },
                    { 76, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://images.squarespace-cdn.com/content/v1/5d2c47a776332100010e62fd/1575048224795-A7H0U9QEXY8Z9FB4MNJU/IMG_2473.JPG?format=1000w", true, 9, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2015" },
                    { 77, 1, true, 2, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://a.allegroimg.com/s1024/0c6ebc/9e197b1f4b72afa9df79e0c2fb64", true, 9, "Citroen", "C5", 240m, 2, null, 5, 70, 1900, "2016" },
                    { 78, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://automedia.investor.bg/media/files/resized/gallery/760x/497/5855c3557474784b68eb0be859439497-03-19.jpg", true, 9, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 79, 1, true, 8, 2000, 4, 6.0, "Дизел", "Автоматични", 150, "https://images.drive.com.au/driveau/image/private/c_fill,f_auto,g_auto,h_674,q_auto:eco,w_1200/ca-s3/2012/09/2013-VW-Golf-front-side-static1-625x374.jpg", true, 9, "Volkswagen", "Golf", 220m, 3, null, 5, 50, 1200, "2013" },
                    { 80, 1, true, 8, 2000, 4, 6.0, "Дизел", "Автоматични", 160, "https://quatrorodas.abril.com.br/wp-content/uploads/2018/06/volkswagen-golf-highline-6.jpg", true, 9, "Volkswagen", "Golf", 260m, 3, null, 5, 50, 1250, "2013" },
                    { 81, 1, true, 8, 1500, 4, 4.0, "Дизел", "Автоматична", 90, "https://cdn.car-recalls.eu/wp-content/uploads/2020/04/renault-clior-rs-x98-2013_recall-768x576.jpg", true, 10, "Renault", "Clio", 200m, 1, null, 5, 45, 800, "2015" },
                    { 82, 1, true, 8, 1600, 4, 4.5, "Дизел", "Автоматична", 140, "https://images.ams.bg/images/articles/31550/euro-ncap-renault-clio-nay-siguren-avtomobil_big.jpg", true, 10, "Renault", "Clio", 220m, 1, null, 5, 45, 820, "2020" },
                    { 83, 1, true, 1, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://avtotachki.com/wp-content/uploads/2020/07/vw-passat-gte1-1024x555.jpg", true, 10, "Volkswagen", "Passat", 300m, 4, null, 5, 65, 1100, "2020" },
                    { 84, 1, true, 2, 2000, 4, 8.0, "Дизел", "Автоматична", 240, "https://www.auto-data.net/images/f87/Volkswagen-Passat-Alltrack-B8-facelift-2019.jpg", true, 10, "Volkswagen", "Passat", 310m, 5, null, 5, 65, 1800, "2020" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AgentId", "Availability", "CategoryId", "Cubage", "Doors", "FuelConsumption", "FuelType", "Gearbox", "Horsepower", "ImageUrl", "IsActive", "LocationId", "Make", "Model", "PricePerDay", "PurposeId", "RenterId", "Seats", "TankCapacity", "TrunkVolume", "Year" },
                values: new object[,]
                {
                    { 85, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://www.novakola.bg/wp-content/uploads/2022/06/Opel-Mokka-Pic-5-scaled-1.jpeg", true, 10, "Opel", "Mokka", 280m, 1, null, 5, 45, 1100, "2020" },
                    { 86, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 110, "https://www.autonews.bg/Files/statii/591-opel-mokka-s-matrichna-sistema-na-svetlinite-sreshu-zaslepyavane-video.jpg", true, 10, "Opel", "Mokka", 280m, 1, null, 5, 45, 1100, "2020" },
                    { 87, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://www.novakola.bg/wp-content/uploads/2022/06/New-Dacia-Duster-pic-5.jpg", true, 10, "Dacia", "Duster", 270m, 1, null, 5, 50, 1150, "2021" },
                    { 88, 1, true, 2, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://i.ytimg.com/vi/4nBmPiyv-_s/maxresdefault.jpg", true, 10, "Ford", "Focus", 230m, 5, null, 5, 60, 1400, "2017" },
                    { 89, 1, true, 1, 2000, 4, 5.0, "Дизел", "Автоматична", 150, "https://cdn-fastly.thetruthaboutcars.com/media/2022/07/19/9211131/ace-of-base-2017-ford-focus-s-sedan.jpg?size=1200x628", true, 10, "Ford", "Focus", 220m, 1, null, 5, 60, 1000, "2017" },
                    { 90, 1, true, 3, 1500, 4, 5.0, "Дизел", "Автоматична", 116, "https://storage.carspending.com/cache/vehicles/original/original_3388.png?w=1536&h=1536&fit=max&s=ba48810c8b701001a210b0197dab8ec7", true, 10, "Dacia", "Duster", 270m, 1, null, 5, 50, 1150, "2021" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

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
                name: "IX_Cars_AgentId",
                table: "Cars",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LocationId",
                table: "Cars",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PurposeId",
                table: "Cars",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");
        }

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
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Protections");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropTable(
                name: "CarPurposes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
