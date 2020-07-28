using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class ResetDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    RememberMe = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "Advertisements",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserRef = table.Column<string>(nullable: true),
                    IsPromoted = table.Column<bool>(nullable: false),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.AdvertisementId);
                    table.ForeignKey(
                        name: "FK_Advertisements_AspNetUsers_UserRef",
                        column: x => x.UserRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    AgencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.AgencyId);
                    table.ForeignKey(
                        name: "FK_Agencies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(nullable: false),
                    NumberOfRooms = table.Column<int>(nullable: false),
                    HaveBalcony = table.Column<bool>(nullable: false),
                    HaveFurnishings = table.Column<bool>(nullable: false),
                    HaveBasement = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SquareMetrage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ConstructionYear = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    MainPageDisplay = table.Column<bool>(nullable: false),
                    FromAgency = table.Column<bool>(nullable: false),
                    Agent = table.Column<string>(nullable: true),
                    Advance = table.Column<double>(nullable: true),
                    AdvertisementId = table.Column<int>(nullable: true),
                    MainImage_PhotoName = table.Column<string>(nullable: true),
                    MainImage_PhotoPath = table.Column<string>(nullable: true),
                    MainImageName = table.Column<string>(nullable: true),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialSpaces",
                columns: table => new
                {
                    CommercialSpaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfRooms = table.Column<int>(nullable: false),
                    LocalType = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SquareMetrage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ConstructionYear = table.Column<int>(nullable: false),
                    FullDescription = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    MainPageDisplay = table.Column<bool>(nullable: false),
                    FromAgency = table.Column<bool>(nullable: false),
                    Agent = table.Column<string>(nullable: true),
                    Advance = table.Column<double>(nullable: true),
                    AdvertisementId = table.Column<int>(nullable: true),
                    MainImage_PhotoName = table.Column<string>(nullable: true),
                    MainImage_PhotoPath = table.Column<string>(nullable: true),
                    MainImageName = table.Column<string>(nullable: true),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialSpaces", x => x.CommercialSpaceId);
                    table.ForeignKey(
                        name: "FK_CommercialSpaces_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfFloors = table.Column<int>(nullable: false),
                    NumberOfRooms = table.Column<int>(nullable: false),
                    TotalArea = table.Column<double>(nullable: false),
                    HaveFurnishings = table.Column<bool>(nullable: false),
                    HaveGarage = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SquareMetrage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ConstructionYear = table.Column<int>(nullable: false),
                    FullDescription = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    MainPageDisplay = table.Column<bool>(nullable: false),
                    FromAgency = table.Column<bool>(nullable: false),
                    Agent = table.Column<string>(nullable: true),
                    Advance = table.Column<double>(nullable: true),
                    AdvertisementId = table.Column<int>(nullable: true),
                    MainImage_PhotoName = table.Column<string>(nullable: true),
                    MainImage_PhotoPath = table.Column<string>(nullable: true),
                    MainImageName = table.Column<string>(nullable: true),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_Homes_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(nullable: false),
                    NumberOfFlatmates = table.Column<int>(nullable: true),
                    HaveFurnishings = table.Column<bool>(nullable: false),
                    TotalArea = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SquareMetrage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ConstructionYear = table.Column<int>(nullable: false),
                    FullDescription = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    MainPageDisplay = table.Column<bool>(nullable: false),
                    FromAgency = table.Column<bool>(nullable: false),
                    Agent = table.Column<string>(nullable: true),
                    Advance = table.Column<double>(nullable: true),
                    AdvertisementId = table.Column<int>(nullable: true),
                    MainImage_PhotoName = table.Column<string>(nullable: true),
                    MainImage_PhotoPath = table.Column<string>(nullable: true),
                    MainImageName = table.Column<string>(nullable: true),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments_Images",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments_Images", x => new { x.ApartmentId, x.Id });
                    table.ForeignKey(
                        name: "FK_Apartments_Images_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialSpaces_Images",
                columns: table => new
                {
                    CommercialSpaceId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialSpaces_Images", x => new { x.CommercialSpaceId, x.Id });
                    table.ForeignKey(
                        name: "FK_CommercialSpaces_Images_CommercialSpaces_CommercialSpaceId",
                        column: x => x.CommercialSpaceId,
                        principalTable: "CommercialSpaces",
                        principalColumn: "CommercialSpaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homes_Images",
                columns: table => new
                {
                    HomeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes_Images", x => new { x.HomeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Homes_Images_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms_Images",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms_Images", x => new { x.RoomId, x.Id });
                    table.ForeignKey(
                        name: "FK_Rooms_Images_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "AgencyId", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "X Property", "111 697 999", null },
                    { 2, "A Property", "111 555 999", null }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ApartmentId", "Address", "Advance", "AdvertisementId", "Agent", "City", "ConstructionYear", "Floor", "FromAgency", "FullDescription", "HaveBalcony", "HaveBasement", "HaveFurnishings", "MainImageName", "MainPageDisplay", "Name", "NumberOfRooms", "Price", "PropertyType", "ShortDescription", "SquareMetrage" },
                values: new object[,]
                {
                    { 1, "Przemiarki 2/1", 2500.0, null, null, "Kraków", 1998, 1, false, "Przykładowy opis mieszkania na potrzeby testowania aplikacji", false, false, false, "PhotoName", false, "Mieszkanie w centrum", 3, 1600.0, 1, null, 64.0 },
                    { 2, "Kunickiego 2/1", 2000.0, null, null, "Wrocław", 1995, 3, false, "Przykładowy opis mieszkania na potrzeby testowania aplikacji", false, false, false, "PhotoName", false, "Mieszkanie na przedmieściu", 2, 1300.0, 1, null, 54.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "ConfirmPassword", "FirstName", "LastName", "Password", "RememberMe" },
                values: new object[] { "1", 0, "7135613c-ab22-46e7-95d0-11a508458fe2", "AppUser", "boni@gmail.com", false, false, null, null, null, null, "123 233 122", false, "21f73e44-9688-40b3-a590-7f1465fe2860", false, "Boni", "Młotkowa 2/7", "bonih", "Bonifacy", "Serpentyna", "bonih", false });

            migrationBuilder.InsertData(
                table: "CommercialSpaces",
                columns: new[] { "CommercialSpaceId", "Address", "Advance", "AdvertisementId", "Agent", "City", "ConstructionYear", "Floor", "FromAgency", "FullDescription", "LocalType", "MainImageName", "MainPageDisplay", "Name", "NumberOfRooms", "Price", "PropertyType", "ShortDescription", "SquareMetrage" },
                values: new object[,]
                {
                    { 1, "Leśna 2/1", 700.0, null, null, "Katowice", 2002, 0, false, "Przykładowy opis lokalu użytkowego na potrzeby testowania aplikacji", 1, "PhotoName", false, "Biuro rachunkowe", 0, 1200.0, 2, null, 150.0 },
                    { 2, "Zana 2/1", 500.0, null, null, "Katowice", 2008, 0, false, "Przykładowy opis lokalu użytkowego na potrzeby testowania aplikacji", 2, "PhotoName", false, "Sala konferencyjna", 0, 1000.0, 2, null, 80.0 }
                });

            migrationBuilder.InsertData(
                table: "Homes",
                columns: new[] { "HomeId", "Address", "Advance", "AdvertisementId", "Agent", "City", "ConstructionYear", "FromAgency", "FullDescription", "HaveFurnishings", "HaveGarage", "MainImageName", "MainPageDisplay", "Name", "NumberOfFloors", "NumberOfRooms", "Price", "PropertyType", "ShortDescription", "SquareMetrage", "TotalArea" },
                values: new object[,]
                {
                    { 1, "Wiązów 3/9", 4000.0, null, null, "Warszawa", 2000, false, "Przykładowy opis domu na potrzeby testowania aplikacji", false, false, "PhotoName", false, "Dom nad jeziorem", 2, 6, 2500.0, 3, null, 140.0, 200.0 },
                    { 2, "Koziołka 3/9", 3000.0, null, null, "Pacanów", 2002, false, "Przykładowy opis domu na potrzeby testowania aplikacji", false, false, "PhotoName", false, "Dom w centrum", 1, 4, 2100.0, 3, null, 90.0, 160.0 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Address", "Advance", "AdvertisementId", "Agent", "City", "ConstructionYear", "Floor", "FromAgency", "FullDescription", "HaveFurnishings", "MainImageName", "MainPageDisplay", "Name", "NumberOfFlatmates", "Price", "PropertyType", "ShortDescription", "SquareMetrage", "TotalArea" },
                values: new object[,]
                {
                    { 1, "Słowackiego 2/5", 750.0, null, null, "Gliwice", 1992, 3, false, "Przykładowy opis pokoju na potrzeby testowania aplikacji", false, "PhotoName", false, "Przytulny pokój", 1, 500.0, 0, null, 12.0, 0.0 },
                    { 2, "Słoneczna 1/2", 800.0, null, null, "Lublin", 1995, 2, false, "Przykładowy opis pokoju na potrzeby testowania aplikacji", false, "PhotoName", false, "Pokój w Lublinie", 2, 570.0, 0, null, 16.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserRef",
                table: "Advertisements",
                column: "UserRef");

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_UserId",
                table: "Agencies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AdvertisementId",
                table: "Apartments",
                column: "AdvertisementId",
                unique: true,
                filter: "[AdvertisementId] IS NOT NULL");

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
                name: "IX_CommercialSpaces_AdvertisementId",
                table: "CommercialSpaces",
                column: "AdvertisementId",
                unique: true,
                filter: "[AdvertisementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_AdvertisementId",
                table: "Homes",
                column: "AdvertisementId",
                unique: true,
                filter: "[AdvertisementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AdvertisementId",
                table: "Rooms",
                column: "AdvertisementId",
                unique: true,
                filter: "[AdvertisementId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Apartments_Images");

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
                name: "CommercialSpaces_Images");

            migrationBuilder.DropTable(
                name: "Homes_Images");

            migrationBuilder.DropTable(
                name: "Rooms_Images");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CommercialSpaces");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
