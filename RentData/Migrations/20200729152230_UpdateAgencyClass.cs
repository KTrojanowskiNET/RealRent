using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class UpdateAgencyClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Agencies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "Agencies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9fcef14b-bb92-4c54-8bed-ac1229413e8c", "75ff2cfa-e853-411a-b5b5-844bc902be79" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "Agencies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "153e022a-a133-443a-af27-331a2df3575c", "573ce173-d9d6-408b-97b3-047a5de878db" });
        }
    }
}
