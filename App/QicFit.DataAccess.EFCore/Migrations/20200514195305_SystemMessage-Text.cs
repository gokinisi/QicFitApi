using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class SystemMessageText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "QicFit",
                table: "SystemMessages",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                schema: "QicFit",
                table: "SystemMessages",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "Text",
                schema: "QicFit",
                table: "SystemMessages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "QicFit",
                table: "SystemMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeGroup",
                schema: "QicFit",
                table: "AgeGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AgeGroup_AgeGroupId",
                schema: "QicFit",
                table: "Workouts",
                column: "AgeGroupId",
                principalSchema: "QicFit",
                principalTable: "AgeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
