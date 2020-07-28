using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class AddOwnerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Homes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "CommercialSpaces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Apartments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9135f799-a3e2-4839-b495-75b15cdc7084", "22d05b90-8213-4610-9d48-8b88347f0826" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "CommercialSpaces");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Apartments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7135613c-ab22-46e7-95d0-11a508458fe2", "21f73e44-9688-40b3-a590-7f1465fe2860" });
        }
    }
}
