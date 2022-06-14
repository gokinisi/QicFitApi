using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class updatedrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_Workouts_AgeGroupId",
            //    schema: "QicFit",
            //    table: "Workouts");

            //migrationBuilder.DropIndex(
            //    name: "IX_Workouts_GenderId",
            //    schema: "QicFit",
            //    table: "Workouts");

            //migrationBuilder.DropIndex(
            //    name: "IX_Workouts_LocationId",
            //    schema: "QicFit",
            //    table: "Workouts");

            //migrationBuilder.DropIndex(
            //    name: "IX_Workouts_RadiusId",
            //    schema: "QicFit",
            //    table: "Workouts");

            //migrationBuilder.DropIndex(
            //    name: "IX_Workouts_WorkoutTypeId",
            //    schema: "QicFit",
            //    table: "Workouts");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_AgeGroupId",
                schema: "QicFit",
                table: "Workouts",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_GenderId",
                schema: "QicFit",
                table: "Workouts",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_LocationId",
                schema: "QicFit",
                table: "Workouts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_RadiusId",
                schema: "QicFit",
                table: "Workouts",
                column: "RadiusId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts",
                column: "WorkoutTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_Workouts_RadiusId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts");

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

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_RadiusId",
                schema: "QicFit",
                table: "Workouts",
                column: "RadiusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts",
                column: "WorkoutTypeId",
                unique: true);
        }
    }
}
