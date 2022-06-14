using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class AddPreferenceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "qicfit",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "qicfit",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "qicfit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "qicfit",
                table: "Users");
        }
    }
}
