using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class UpdateAgeGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeRange",
                schema: "QicFit");

            migrationBuilder.DropIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                column: "WorkoutId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.CreateTable(
                name: "AgeRange",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeRange_WorkoutId",
                schema: "QicFit",
                table: "AgeRange",
                column: "WorkoutId",
                unique: true);
        }
    }
}
