using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class AgencyRelatioship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_AspNetUsers_UserId",
                table: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_UserId",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agencies");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Agencies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId1",
                table: "Agencies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "153e022a-a133-443a-af27-331a2df3575c", "573ce173-d9d6-408b-97b3-047a5de878db" });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_AdvertisementId",
                table: "Agencies",
                column: "AdvertisementId",
                unique: true,
                filter: "[AdvertisementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_AdvertisementId1",
                table: "Agencies",
                column: "AdvertisementId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_Advertisements_AdvertisementId",
                table: "Agencies",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "AdvertisementId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_Advertisements_AdvertisementId1",
                table: "Agencies",
                column: "AdvertisementId1",
                principalTable: "Advertisements",
                principalColumn: "AdvertisementId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_Advertisements_AdvertisementId",
                table: "Agencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_Advertisements_AdvertisementId1",
                table: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_AdvertisementId",
                table: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_AdvertisementId1",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "AdvertisementId1",
                table: "Agencies");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Agencies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9135f799-a3e2-4839-b495-75b15cdc7084", "22d05b90-8213-4610-9d48-8b88347f0826" });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_UserId",
                table: "Agencies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_AspNetUsers_UserId",
                table: "Agencies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
