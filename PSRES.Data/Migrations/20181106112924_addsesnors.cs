using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSRES.Data.Migrations
{
    public partial class addsesnors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensoringStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Zone = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ParentPin = table.Column<int>(nullable: false),
                    Light = table.Column<bool>(nullable: false),
                    Temperature = table.Column<bool>(nullable: false),
                    Presence = table.Column<bool>(nullable: false),
                    distance = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensoringStations", x => x.Id);
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
                    Presence = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorRecordings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensoringStations");

            migrationBuilder.DropTable(
                name: "SensorRecordings");
        }
    }
}
