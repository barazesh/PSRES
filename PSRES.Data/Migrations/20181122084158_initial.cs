using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSRES.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    year = table.Column<int>(nullable: false),
                    month = table.Column<byte>(nullable: false),
                    day = table.Column<byte>(nullable: false),
                    hour = table.Column<byte>(nullable: false),
                    minute = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Serialcode = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensoringStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Zone = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ParentPin = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensoringStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterRecordings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeterId = table.Column<int>(nullable: false),
                    datetimeId = table.Column<int>(nullable: true),
                    TimeDateId = table.Column<int>(nullable: false),
                    activeEnergy = table.Column<int>(nullable: false),
                    peakActivePower = table.Column<int>(nullable: false),
                    reactiveEnergy = table.Column<int>(nullable: false),
                    peakReactivePower = table.Column<int>(nullable: false),
                    voltage = table.Column<decimal>(nullable: false),
                    current = table.Column<decimal>(nullable: false),
                    powerFactor = table.Column<decimal>(nullable: false),
                    frequency = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterRecordings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterRecordings_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeterRecordings_Dates_datetimeId",
                        column: x => x.datetimeId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SensorRecordings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SensoringStationId = table.Column<int>(nullable: false),
                    TimeDateId = table.Column<int>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    Illumination = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    Presence = table.Column<bool>(nullable: false),
                    SensoringStationEntityId = table.Column<int>(nullable: true),
                    TimeDateEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorRecordings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorRecordings_SensoringStations_SensoringStationEntityId",
                        column: x => x.SensoringStationEntityId,
                        principalTable: "SensoringStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SensorRecordings_Dates_TimeDateEntityId",
                        column: x => x.TimeDateEntityId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_MeterId",
                table: "MeterRecordings",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_datetimeId",
                table: "MeterRecordings",
                column: "datetimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_SensoringStationEntityId",
                table: "SensorRecordings",
                column: "SensoringStationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_TimeDateEntityId",
                table: "SensorRecordings",
                column: "TimeDateEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterRecordings");

            migrationBuilder.DropTable(
                name: "SensorRecordings");

            migrationBuilder.DropTable(
                name: "Meters");

            migrationBuilder.DropTable(
                name: "SensoringStations");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
