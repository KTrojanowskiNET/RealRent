using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class UpdatedAgencyModelAndTagHelper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "7013f7a8-fd16-48c1-9183-29acbf9741c4", "4c4fa797-f8ed-4333-b74d-7c79fb363e6d" });

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
                values: new object[] { "6e75bba8-4afd-4993-a264-86ecfd913eab", "ad359009-cfb0-4a74-b584-19bdb96ef55c" });

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
