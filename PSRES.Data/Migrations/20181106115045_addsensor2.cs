using Microsoft.EntityFrameworkCore.Migrations;

namespace PSRES.Data.Migrations
{
    public partial class addsensor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Light",
                table: "SensoringStations");

            migrationBuilder.DropColumn(
                name: "Presence",
                table: "SensoringStations");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "SensoringStations");

            migrationBuilder.DropColumn(
                name: "distance",
                table: "SensoringStations");

            migrationBuilder.AddColumn<bool>(
                name: "Reliable",
                table: "SensorRecordings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "SensoringStations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_TimeDateId",
                table: "SensorRecordings",
                column: "TimeDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecordings_Dates_TimeDateId",
                table: "SensorRecordings",
                column: "TimeDateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecordings_Dates_TimeDateId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_SensorRecordings_TimeDateId",
                table: "SensorRecordings");

            migrationBuilder.DropColumn(
                name: "Reliable",
                table: "SensorRecordings");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "SensoringStations");

            migrationBuilder.AddColumn<bool>(
                name: "Light",
                table: "SensoringStations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Presence",
                table: "SensoringStations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Temperature",
                table: "SensoringStations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "distance",
                table: "SensoringStations",
                nullable: false,
                defaultValue: false);
        }
    }
}
