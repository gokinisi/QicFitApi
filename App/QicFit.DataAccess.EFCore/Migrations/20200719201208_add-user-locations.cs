using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class adduserlocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "City",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                schema: "QicFit",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                schema: "QicFit",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_CityId",
                schema: "QicFit",
                table: "UserLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_StateId",
                schema: "QicFit",
                table: "UserLocations",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_City_CityId",
                schema: "QicFit",
                table: "UserLocations",
                column: "CityId",
                principalSchema: "QicFit",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_State_StateId",
                schema: "QicFit",
                table: "UserLocations",
                column: "StateId",
                principalSchema: "QicFit",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Users_City_CityId",
            //    schema: "QicFit",
            //    table: "Users",
            //    column: "CityId",
            //    principalSchema: "QicFit",
            //    principalTable: "City",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_City_CityId",
                schema: "QicFit",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_State_StateId",
                schema: "QicFit",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_City_CityId",
                schema: "QicFit",
                table: "Users");


            migrationBuilder.DropIndex(
                name: "IX_Users_CityId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_CityId",
                schema: "QicFit",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_StateId",
                schema: "QicFit",
                table: "UserLocations");


            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "QicFit",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
