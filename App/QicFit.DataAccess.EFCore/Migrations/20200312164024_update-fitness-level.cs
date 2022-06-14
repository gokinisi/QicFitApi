using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class updatefitnesslevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FitnessLevel",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "QicFit",
                table: "WorkoutType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FitnessLevelId",
                schema: "QicFit",
                table: "Workouts",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "QicFit",
                table: "Radius",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "QicFit",
                table: "Gender",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "QicFit",
                table: "AgeGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FitnessLevel",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_FitnessLevelId",
                schema: "QicFit",
                table: "Workouts",
                column: "FitnessLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_FitnessLevel_FitnessLevelId",
                schema: "QicFit",
                table: "Workouts",
                column: "FitnessLevelId",
                principalSchema: "QicFit",
                principalTable: "FitnessLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_FitnessLevel_FitnessLevelId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "FitnessLevel",
                schema: "QicFit");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_FitnessLevelId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "QicFit",
                table: "WorkoutType");

            migrationBuilder.DropColumn(
                name: "FitnessLevelId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "QicFit",
                table: "Radius");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "QicFit",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.AddColumn<int>(
                name: "FitnessLevel",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
