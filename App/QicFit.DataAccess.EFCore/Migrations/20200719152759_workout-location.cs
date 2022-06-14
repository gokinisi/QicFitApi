using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class workoutlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Workouts_Locations_LocationId",
            //    schema: "QicFit",
            //    table: "Workouts");

            migrationBuilder.DropTable(
                name: "LocationRequirement",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "QicFit");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_LocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutLocationId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "QicFit",
            //    table: "State",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "QicFit",
            //    table: "City",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "WorkoutLocations",
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
                    ZipCode = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationWorkoutTypes",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    WorkoutTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationWorkoutTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationWorkoutTypes_WorkoutLocations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "QicFit",
                        principalTable: "WorkoutLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationWorkoutTypes_WorkoutType_WorkoutTypeId",
                        column: x => x.WorkoutTypeId,
                        principalSchema: "QicFit",
                        principalTable: "WorkoutType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLocationRequirement",
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
                    WorkoutLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLocationRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutLocationRequirement_WorkoutLocations_WorkoutLocationId",
                        column: x => x.WorkoutLocationId,
                        principalSchema: "QicFit",
                        principalTable: "WorkoutLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutLocationId",
                schema: "QicFit",
                table: "Workouts",
                column: "WorkoutLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationWorkoutTypes_LocationId",
                schema: "QicFit",
                table: "LocationWorkoutTypes",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationWorkoutTypes_WorkoutTypeId",
                schema: "QicFit",
                table: "LocationWorkoutTypes",
                column: "WorkoutTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLocationRequirement_WorkoutLocationId",
                schema: "QicFit",
                table: "WorkoutLocationRequirement",
                column: "WorkoutLocationId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_City_WorkoutLocations_Id",
            //    schema: "QicFit",
            //    table: "City",
            //    column: "Id",
            //    principalSchema: "QicFit",
            //    principalTable: "WorkoutLocations",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_State_WorkoutLocations_Id",
            //    schema: "QicFit",
            //    table: "State",
            //    column: "Id",
            //    principalSchema: "QicFit",
            //    principalTable: "WorkoutLocations",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Workouts_WorkoutLocations_WorkoutLocationId",
        //        schema: "QicFit",
        //        table: "Workouts",
        //        column: "WorkoutLocationId",
        //        principalSchema: "QicFit",
        //        principalTable: "WorkoutLocations",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_WorkoutLocations_Id",
                schema: "QicFit",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_State_WorkoutLocations_Id",
                schema: "QicFit",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutLocations_WorkoutLocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "LocationWorkoutTypes",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "WorkoutLocationRequirement",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "WorkoutLocations",
                schema: "QicFit");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_WorkoutLocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutLocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "QicFit",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "QicFit",
                table: "City",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationRequirement",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_Workouts_LocationId",
                schema: "QicFit",
                table: "Workouts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationRequirement_LocationId",
                schema: "QicFit",
                table: "LocationRequirement",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Locations_LocationId",
                schema: "QicFit",
                table: "Workouts",
                column: "LocationId",
                principalSchema: "QicFit",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
