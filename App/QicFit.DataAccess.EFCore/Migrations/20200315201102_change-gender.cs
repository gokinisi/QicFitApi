using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class changegender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "QicFit",
                table: "Users",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                schema: "QicFit",
                table: "Users",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gender_GenderId",
                schema: "QicFit",
                table: "Users",
                column: "GenderId",
                principalSchema: "QicFit",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gender_GenderId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GenderId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "QicFit",
                table: "Users");
        }
    }
}
