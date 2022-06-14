using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class RemovedUnusedIdFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRangeId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "QicFit",
                table: "Workouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeRangeId",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
