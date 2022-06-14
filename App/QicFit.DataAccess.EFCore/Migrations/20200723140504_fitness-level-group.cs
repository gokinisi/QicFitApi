using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class fitnesslevelgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FitnessLevelGroupId",
                schema: "QicFit",
                table: "FitnessLevel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FitnessLevelGroup",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessLevelGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessLevel_FitnessLevelGroupId",
                schema: "QicFit",
                table: "FitnessLevel",
                column: "FitnessLevelGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessLevel_FitnessLevelGroup_FitnessLevelGroupId",
                schema: "QicFit",
                table: "FitnessLevel",
                column: "FitnessLevelGroupId",
                principalSchema: "QicFit",
                principalTable: "FitnessLevelGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessLevel_FitnessLevelGroup_FitnessLevelGroupId",
                schema: "QicFit",
                table: "FitnessLevel");

            migrationBuilder.DropTable(
                name: "FitnessLevelGroup",
                schema: "QicFit");

            migrationBuilder.DropIndex(
                name: "IX_FitnessLevel_FitnessLevelGroupId",
                schema: "QicFit",
                table: "FitnessLevel");

            migrationBuilder.DropColumn(
                name: "FitnessLevelGroupId",
                schema: "QicFit",
                table: "FitnessLevel");
        }
    }
}
