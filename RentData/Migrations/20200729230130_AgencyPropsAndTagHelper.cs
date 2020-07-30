using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class AgencyPropsAndTagHelper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agent",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Agent",
                table: "CommercialSpaces");

            migrationBuilder.DropColumn(
                name: "Agent",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "AgencyName",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyName",
                table: "Homes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyName",
                table: "CommercialSpaces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyName",
                table: "Apartments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "ShortDescription",
                value: "Przykładowy opis mieszkania na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "ShortDescription",
                value: "Przykładowy opis mieszkania na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e75bba8-4afd-4993-a264-86ecfd913eab", "ad359009-cfb0-4a74-b584-19bdb96ef55c" });

            migrationBuilder.UpdateData(
                table: "CommercialSpaces",
                keyColumn: "CommercialSpaceId",
                keyValue: 1,
                column: "ShortDescription",
                value: "Przykładowy opis lokalu użytkowego na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "CommercialSpaces",
                keyColumn: "CommercialSpaceId",
                keyValue: 2,
                column: "ShortDescription",
                value: "Przykładowy opis lokalu użytkowego na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "HomeId",
                keyValue: 1,
                column: "ShortDescription",
                value: "Przykładowy opis domu na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "HomeId",
                keyValue: 2,
                column: "ShortDescription",
                value: "Przykładowy opis domu na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "ShortDescription",
                value: "Przykładowy opis pokoju na potrzeby testowania aplikacji");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "ShortDescription",
                value: "Przykładowy opis pokoju na potrzeby testowania aplikacji");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AgencyName",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "AgencyName",
                table: "CommercialSpaces");

            migrationBuilder.DropColumn(
                name: "AgencyName",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "Agent",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agent",
                table: "CommercialSpaces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agent",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ba3f38b-84a6-4fc4-9c48-702a153c8995", "1b6bcaef-4491-46af-a429-f6f9e1ae95db" });

            migrationBuilder.UpdateData(
                table: "CommercialSpaces",
                keyColumn: "CommercialSpaceId",
                keyValue: 1,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "CommercialSpaces",
                keyColumn: "CommercialSpaceId",
                keyValue: 2,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "HomeId",
                keyValue: 1,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "HomeId",
                keyValue: 2,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "ShortDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "ShortDescription",
                value: null);
        }
    }
}
