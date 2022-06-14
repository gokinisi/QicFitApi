using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class workouttypefitnesslevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FitnessLevel_FitnessLevelGroup_FitnessLevelGroupId",
            //    schema: "QicFit",
            //    table: "FitnessLevel");

            //migrationBuilder.AlterColumn<int>(
            //    name: "FitnessLevelGroupId",
            //    schema: "QicFit",
            //    table: "FitnessLevel",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutTypeId",
                schema: "QicFit",
                table: "FitnessLevel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessLevel_WorkoutTypeId",
                schema: "QicFit",
                table: "FitnessLevel",
                column: "WorkoutTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FitnessLevel_FitnessLevelGroup_FitnessLevelGroupId",
            //    schema: "QicFit",
            //    table: "FitnessLevel",
            //    column: "FitnessLevelGroupId",
            //    principalSchema: "QicFit",
            //    principalTable: "FitnessLevelGroup",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessLevel_WorkoutType_WorkoutTypeId",
                schema: "QicFit",
                table: "FitnessLevel",
                column: "WorkoutTypeId",
                principalSchema: "QicFit",
                principalTable: "WorkoutType",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FitnessLevel_FitnessLevelGroup_FitnessLevelGroupId",
            //    schema: "QicFit",
            //    table: "FitnessLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessLevel_WorkoutType_WorkoutTypeId",
                schema: "QicFit",
                table: "FitnessLevel");

            migrationBuilder.DropIndex(
                name: "IX_FitnessLevel_WorkoutTypeId",
                schema: "QicFit",
                table: "FitnessLevel");

            migrationBuilder.DropColumn(
                name: "WorkoutTypeId",
                schema: "QicFit",
                table: "FitnessLevel");

            //migrationBuilder.AlterColumn<int>(
            //    name: "FitnessLevelGroupId",
            //    schema: "QicFit",
            //    table: "FitnessLevel",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FitnessLevel_FitnessLevelGroup_FitnessLevelGroupId",
            //    schema: "QicFit",
            //    table: "FitnessLevel",
            //    column: "FitnessLevelGroupId",
            //    principalSchema: "QicFit",
            //    principalTable: "FitnessLevelGroup",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
