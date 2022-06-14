using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class FixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgeGroups_Workouts_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Gender_Workouts_WorkoutId",
                schema: "QicFit",
                table: "Gender");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Workouts_WorkoutId",
                schema: "QicFit",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_WorkoutId",
                schema: "QicFit",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Gender_WorkoutId",
                schema: "QicFit",
                table: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                schema: "QicFit",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "AgeGroupId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_AgeGroupId",
                schema: "QicFit",
                table: "Workouts",
                column: "AgeGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_GenderId",
                schema: "QicFit",
                table: "Workouts",
                column: "GenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_LocationId",
                schema: "QicFit",
                table: "Workouts",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AgeGroups_AgeGroupId",
                schema: "QicFit",
                table: "Workouts",
                column: "AgeGroupId",
                principalSchema: "QicFit",
                principalTable: "AgeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Gender_GenderId",
                schema: "QicFit",
                table: "Workouts",
                column: "GenderId",
                principalSchema: "QicFit",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AgeGroups_AgeGroupId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Gender_GenderId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Locations_LocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_AgeGroupId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_GenderId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_LocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "AgeGroupId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                schema: "QicFit",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WorkoutId",
                schema: "QicFit",
                table: "Locations",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_WorkoutId",
                schema: "QicFit",
                table: "Gender",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AgeGroups_Workouts_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gender_Workouts_WorkoutId",
                schema: "QicFit",
                table: "Gender",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Workouts_WorkoutId",
                schema: "QicFit",
                table: "Locations",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
