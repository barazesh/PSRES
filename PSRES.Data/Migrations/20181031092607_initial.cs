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
                name: "MeterRecordings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeterId = table.Column<int>(nullable: false),
                    TimeDateId = table.Column<int>(nullable: false),
                    activeEnergy = table.Column<decimal>(nullable: false),
                    reactiveEnergy = table.Column<decimal>(nullable: false),
                    activePower = table.Column<int>(nullable: false),
                    reactivePower = table.Column<int>(nullable: false),
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
                        name: "FK_MeterRecordings_Dates_TimeDateId",
                        column: x => x.TimeDateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_MeterId",
                table: "MeterRecordings",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_TimeDateId",
                table: "MeterRecordings",
                column: "TimeDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterRecordings");

            migrationBuilder.DropTable(
                name: "Meters");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
