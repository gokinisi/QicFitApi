using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class AddWorkoutLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QicFit");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "qicfit",
                newName: "Users",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "qicfit",
                newName: "UserRoles",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "UserPhotos",
                schema: "qicfit",
                newName: "UserPhotos",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "qicfit",
                newName: "UserClaims",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "TrafficConsumptions",
                schema: "qicfit",
                newName: "TrafficConsumptions",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "Settings",
                schema: "qicfit",
                newName: "Settings",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "qicfit",
                newName: "Roles",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "PhoneCalls",
                schema: "qicfit",
                newName: "PhoneCalls",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "ElectricityConsumptions",
                schema: "qicfit",
                newName: "ElectricityConsumptions",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "Devices",
                schema: "qicfit",
                newName: "Devices",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "DeviceParameters",
                schema: "qicfit",
                newName: "DeviceParameters",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "Contacts",
                schema: "qicfit",
                newName: "Contacts",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "ContactPhotos",
                schema: "qicfit",
                newName: "ContactPhotos",
                newSchema: "QicFit");

            migrationBuilder.CreateTable(
                name: "Workouts",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    AgeId = table.Column<int>(nullable: false),
                    FitnessLevelId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false),
                    Radius = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalSchema: "QicFit",
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationRequirement",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationRequirement_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "QicFit",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationRequirement_LocationId",
                schema: "QicFit",
                table: "LocationRequirement",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WorkoutId",
                schema: "QicFit",
                table: "Locations",
                column: "WorkoutId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationRequirement",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "Workouts",
                schema: "QicFit");

            migrationBuilder.EnsureSchema(
                name: "qicfit");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "QicFit",
                newName: "Users",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "QicFit",
                newName: "UserRoles",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "UserPhotos",
                schema: "QicFit",
                newName: "UserPhotos",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "QicFit",
                newName: "UserClaims",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "TrafficConsumptions",
                schema: "QicFit",
                newName: "TrafficConsumptions",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "Settings",
                schema: "QicFit",
                newName: "Settings",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "QicFit",
                newName: "Roles",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "PhoneCalls",
                schema: "QicFit",
                newName: "PhoneCalls",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "ElectricityConsumptions",
                schema: "QicFit",
                newName: "ElectricityConsumptions",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "Devices",
                schema: "QicFit",
                newName: "Devices",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "DeviceParameters",
                schema: "QicFit",
                newName: "DeviceParameters",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "Contacts",
                schema: "QicFit",
                newName: "Contacts",
                newSchema: "qicfit");

            migrationBuilder.RenameTable(
                name: "ContactPhotos",
                schema: "QicFit",
                newName: "ContactPhotos",
                newSchema: "qicfit");
        }
    }
}
