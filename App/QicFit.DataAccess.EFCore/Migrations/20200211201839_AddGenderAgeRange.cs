using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class AddGenderAgeRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "FitnessLevelId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "AgeRangeId",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FitnessLevel",
                schema: "QicFit",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AgeGroupConfig",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range = table.Column<string>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroupConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeGroupConfig_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalSchema: "QicFit",
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgeRange",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeRange_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalSchema: "QicFit",
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenderConfig",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenderConfig_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalSchema: "QicFit",
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroupConfig_WorkoutId",
                schema: "QicFit",
                table: "AgeGroupConfig",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeRange_WorkoutId",
                schema: "QicFit",
                table: "AgeRange",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenderConfig_WorkoutId",
                schema: "QicFit",
                table: "GenderConfig",
                column: "WorkoutId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeGroupConfig",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "AgeRange",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "GenderConfig",
                schema: "QicFit");

            migrationBuilder.DropColumn(
                name: "AgeRangeId",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "FitnessLevel",
                schema: "QicFit",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "AgeId",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FitnessLevelId",
                schema: "QicFit",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
