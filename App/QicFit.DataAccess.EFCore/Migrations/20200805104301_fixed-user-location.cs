using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class fixeduserlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Users_UserId",
                schema: "QicFit",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_UserId",
                schema: "QicFit",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "QicFit",
                table: "UserLocations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "QicFit",
                table: "UserLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserId",
                schema: "QicFit",
                table: "UserLocations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Users_UserId",
                schema: "QicFit",
                table: "UserLocations",
                column: "UserId1",
                principalSchema: "QicFit",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
