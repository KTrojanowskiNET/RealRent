using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class SeedAgencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "AgencyId",
                keyValue: 1,
                columns: new[] { "Address", "Name", "PhoneNumber", "Slogan" },
                values: new object[] { "Wrzosowa 7/99", "Agency A", "111 627 199", "Slogan A" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "AgencyId",
                keyValue: 2,
                columns: new[] { "Address", "Name", "PhoneNumber", "Slogan" },
                values: new object[] { "Wrzosowa 7/999", "Agency B", "441 127 959", "Slogan B" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa761471-4283-4fed-9d12-46cd99252f8a", "9ffbbe1b-81ba-4c01-afc3-fe810a498d58" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "AgencyId",
                keyValue: 1,
                columns: new[] { "Address", "Name", "PhoneNumber", "Slogan" },
                values: new object[] { null, "X Property", "111 697 999", null });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "AgencyId",
                keyValue: 2,
                columns: new[] { "Address", "Name", "PhoneNumber", "Slogan" },
                values: new object[] { null, "A Property", "111 555 999", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9fcef14b-bb92-4c54-8bed-ac1229413e8c", "75ff2cfa-e853-411a-b5b5-844bc902be79" });
        }
    }
}
