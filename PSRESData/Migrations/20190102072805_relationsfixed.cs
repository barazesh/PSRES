using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSRESData.Migrations
{
    public partial class relationsfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterRecordings_Dates_datetimeId",
                table: "MeterRecordings");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecordings_SensoringStations_SensoringStationEntityId",
                table: "SensorRecordings");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecordings_Dates_TimeDateEntityId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_SensorRecordings_SensoringStationEntityId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_SensorRecordings_TimeDateEntityId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_MeterRecordings_datetimeId",
                table: "MeterRecordings");

            migrationBuilder.DropColumn(
                name: "SensoringStationEntityId",
                table: "SensorRecordings");

            migrationBuilder.DropColumn(
                name: "TimeDateEntityId",
                table: "SensorRecordings");

            migrationBuilder.DropColumn(
                name: "datetimeId",
                table: "MeterRecordings");

            migrationBuilder.AddColumn<int>(
                name: "TimeDateId",
                table: "SensorRecordings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeDateId",
                table: "MeterRecordings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_SensoringStationId",
                table: "SensorRecordings",
                column: "SensoringStationId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_TimeDateId",
                table: "SensorRecordings",
                column: "TimeDateId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_TimeDateId",
                table: "MeterRecordings",
                column: "TimeDateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterRecordings_Dates_TimeDateId",
                table: "MeterRecordings",
                column: "TimeDateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecordings_SensoringStations_SensoringStationId",
                table: "SensorRecordings",
                column: "SensoringStationId",
                principalTable: "SensoringStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_MeterRecordings_Dates_TimeDateId",
                table: "MeterRecordings");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecordings_SensoringStations_SensoringStationId",
                table: "SensorRecordings");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecordings_Dates_TimeDateId",
                table: "SensorRecordings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_SensorRecordings_SensoringStationId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_SensorRecordings_TimeDateId",
                table: "SensorRecordings");

            migrationBuilder.DropIndex(
                name: "IX_MeterRecordings_TimeDateId",
                table: "MeterRecordings");

            migrationBuilder.DropColumn(
                name: "TimeDateId",
                table: "SensorRecordings");

            migrationBuilder.DropColumn(
                name: "TimeDateId",
                table: "MeterRecordings");

            migrationBuilder.AddColumn<int>(
                name: "SensoringStationEntityId",
                table: "SensorRecordings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeDateEntityId",
                table: "SensorRecordings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "datetimeId",
                table: "MeterRecordings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_SensoringStationEntityId",
                table: "SensorRecordings",
                column: "SensoringStationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorRecordings_TimeDateEntityId",
                table: "SensorRecordings",
                column: "TimeDateEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterRecordings_datetimeId",
                table: "MeterRecordings",
                column: "datetimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterRecordings_Dates_datetimeId",
                table: "MeterRecordings",
                column: "datetimeId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecordings_SensoringStations_SensoringStationEntityId",
                table: "SensorRecordings",
                column: "SensoringStationEntityId",
                principalTable: "SensoringStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecordings_Dates_TimeDateEntityId",
                table: "SensorRecordings",
                column: "TimeDateEntityId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
