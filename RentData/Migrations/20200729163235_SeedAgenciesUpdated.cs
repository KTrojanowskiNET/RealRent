using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class SeedAgenciesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ba3f38b-84a6-4fc4-9c48-702a153c8995", "1b6bcaef-4491-46af-a429-f6f9e1ae95db" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa761471-4283-4fed-9d12-46cd99252f8a", "9ffbbe1b-81ba-4c01-afc3-fe810a498d58" });
        }
    }
}
