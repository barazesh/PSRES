using Microsoft.EntityFrameworkCore.Migrations;

namespace PSRES.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_MeterId",
                table: "MeterRecordings",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_TimeDateId",
                table: "MeterRecordings",
                column: "TimeDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterRecordings_Meters_MeterId",
                table: "MeterRecordings",
                column: "MeterId",
                principalTable: "Meters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterRecordings_Dates_TimeDateId",
                table: "MeterRecordings",
                column: "TimeDateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterRecordings_Meters_MeterId",
                table: "MeterRecordings");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterRecordings_Dates_TimeDateId",
                table: "MeterRecordings");

            migrationBuilder.DropIndex(
                name: "IX_MeterRecordings_MeterId",
                table: "MeterRecordings");

            migrationBuilder.DropIndex(
                name: "IX_MeterRecordings_TimeDateId",
                table: "MeterRecordings");
        }
    }
}
