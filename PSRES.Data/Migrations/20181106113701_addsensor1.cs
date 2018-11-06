using Microsoft.EntityFrameworkCore.Migrations;

namespace PSRES.Data.Migrations
{
    public partial class addsensor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_SensoringStationId",
                table: "SensorRecordings",
                column: "SensoringStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecordings_SensoringStations_SensoringStationId",
                table: "SensorRecordings",
                column: "SensoringStationId",
                principalTable: "SensoringStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecordings_SensoringStations_SensoringStationId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_SensorRecordings_SensoringStationId",
                table: "SensorRecordings");
        }
    }
}
