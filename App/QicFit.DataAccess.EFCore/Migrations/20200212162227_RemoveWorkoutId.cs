using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class RemoveWorkoutId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutId",
                schema: "QicFit",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                schema: "QicFit",
                table: "AgeGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                schema: "QicFit",
                table: "Gender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
