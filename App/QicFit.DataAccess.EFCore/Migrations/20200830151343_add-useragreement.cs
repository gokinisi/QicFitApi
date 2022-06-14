using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class adduseragreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptCovidAgreement",
                schema: "QicFit",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptCovidAgreementDate",
                schema: "QicFit",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "AcceptUserAgreement",
                schema: "QicFit",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptUserAgreementDate",
                schema: "QicFit",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptCovidAgreement",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AcceptCovidAgreementDate",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AcceptUserAgreement",
                schema: "QicFit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AcceptUserAgreementDate",
                schema: "QicFit",
                table: "Users");
        }
    }
}
