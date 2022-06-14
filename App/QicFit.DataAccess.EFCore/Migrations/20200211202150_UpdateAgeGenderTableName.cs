using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class UpdateAgeGenderTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgeGroupConfig_Workouts_WorkoutId",
                schema: "QicFit",
                table: "AgeGroupConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderConfig_Workouts_WorkoutId",
                schema: "QicFit",
                table: "GenderConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderConfig",
                schema: "QicFit",
                table: "GenderConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeGroupConfig",
                schema: "QicFit",
                table: "AgeGroupConfig");

            migrationBuilder.RenameTable(
                name: "GenderConfig",
                schema: "QicFit",
                newName: "Gender",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "AgeGroupConfig",
                schema: "QicFit",
                newName: "AgeGroups",
                newSchema: "QicFit");

            migrationBuilder.RenameIndex(
                name: "IX_GenderConfig_WorkoutId",
                schema: "QicFit",
                table: "Gender",
                newName: "IX_Gender_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_AgeGroupConfig_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                newName: "IX_AgeGroups_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                schema: "QicFit",
                table: "Gender",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeGroups",
                schema: "QicFit",
                table: "AgeGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgeGroups_Workouts_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gender_Workouts_WorkoutId",
                schema: "QicFit",
                table: "Gender",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgeGroups_Workouts_WorkoutId",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Gender_Workouts_WorkoutId",
                schema: "QicFit",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                schema: "QicFit",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeGroups",
                schema: "QicFit",
                table: "AgeGroups");

            migrationBuilder.RenameTable(
                name: "Gender",
                schema: "QicFit",
                newName: "GenderConfig",
                newSchema: "QicFit");

            migrationBuilder.RenameTable(
                name: "AgeGroups",
                schema: "QicFit",
                newName: "AgeGroupConfig",
                newSchema: "QicFit");

            migrationBuilder.RenameIndex(
                name: "IX_Gender_WorkoutId",
                schema: "QicFit",
                table: "GenderConfig",
                newName: "IX_GenderConfig_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_AgeGroups_WorkoutId",
                schema: "QicFit",
                table: "AgeGroupConfig",
                newName: "IX_AgeGroupConfig_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderConfig",
                schema: "QicFit",
                table: "GenderConfig",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeGroupConfig",
                schema: "QicFit",
                table: "AgeGroupConfig",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgeGroupConfig_Workouts_WorkoutId",
                schema: "QicFit",
                table: "AgeGroupConfig",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenderConfig_Workouts_WorkoutId",
                schema: "QicFit",
                table: "GenderConfig",
                column: "WorkoutId",
                principalSchema: "QicFit",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
