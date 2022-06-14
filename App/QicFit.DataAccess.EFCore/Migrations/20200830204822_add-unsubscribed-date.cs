using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class addunsubscribeddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifiedDate",
                schema: "QicFit",
                table: "PreNotification");

            migrationBuilder.AddColumn<bool>(
                name: "Unsubscribed",
                schema: "QicFit",
                table: "PreNotification",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnsubscribedDate",
                schema: "QicFit",
                table: "PreNotification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unsubscribed",
                schema: "QicFit",
                table: "PreNotification");

            migrationBuilder.DropColumn(
                name: "UnsubscribedDate",
                schema: "QicFit",
                table: "PreNotification");

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedDate",
                schema: "QicFit",
                table: "PreNotification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
