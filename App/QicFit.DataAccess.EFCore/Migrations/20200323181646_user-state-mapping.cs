using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class userstatemapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                schema: "QicFit",
                table: "Users",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                schema: "QicFit",
                table: "Users",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_State_StateId",
                schema: "QicFit",
                table: "Users",
                column: "StateId",
                principalSchema: "QicFit",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_State_StateId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StateId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "QicFit",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "QicFit",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
