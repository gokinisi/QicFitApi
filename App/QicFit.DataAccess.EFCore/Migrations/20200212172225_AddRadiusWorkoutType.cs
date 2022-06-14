using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class AddRadiusWorkoutType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Radius",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "RadiusId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Radius",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radius", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutType",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_RadiusId",
                schema: "QicFit",
                table: "Workouts",
                column: "RadiusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts",
                column: "WorkoutTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Radius_RadiusId",
                schema: "QicFit",
                table: "Workouts",
                column: "RadiusId",
                principalSchema: "QicFit",
                principalTable: "Radius",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutType_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts",
                column: "WorkoutTypeId",
                principalSchema: "QicFit",
                principalTable: "WorkoutType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Radius_RadiusId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutType_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Radius",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "WorkoutType",
                schema: "QicFit");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_RadiusId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "RadiusId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutTypeId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "Radius",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
