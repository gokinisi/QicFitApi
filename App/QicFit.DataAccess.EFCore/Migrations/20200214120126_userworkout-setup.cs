using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class userworkoutsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_UserId",
                schema: "QicFit",
                table: "UserWorkouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_WorkoutId",
                schema: "QicFit",
                table: "UserWorkouts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_Users_UserId",
                schema: "QicFit",
                table: "UserWorkouts",
                column: "UserId",
                principalSchema: "QicFit",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_Workouts_WorkoutId",
                schema: "QicFit",
                table: "UserWorkouts",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Users_UserId",
                schema: "QicFit",
                table: "UserWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Workouts_WorkoutId",
                schema: "QicFit",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_UserId",
                schema: "QicFit",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_WorkoutId",
                schema: "QicFit",
                table: "UserWorkouts");
        }
    }
}
