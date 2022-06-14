using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class RemovedUnusedRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPhotos",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "DeviceParameters",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "ElectricityConsumptions",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "PhoneCalls",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "TrafficConsumptions",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "Devices",
                schema: "QicFit");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "QicFit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberType = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOn = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "QicFit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "QicFit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityConsumptions",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumedValue = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpentMoneyValue = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityConsumptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrafficConsumptions",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumedValue = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficConsumptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhotos",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhotos_Contacts_Id",
                        column: x => x.Id,
                        principalSchema: "QicFit",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCalls",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    DateOfCall = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneCalls_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "QicFit",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceParameters",
                schema: "QicFit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceParameters_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "QicFit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceParameters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "QicFit",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceParameters_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "QicFit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameters_CreatedByUserId",
                schema: "QicFit",
                table: "DeviceParameters",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameters_DeviceId",
                schema: "QicFit",
                table: "DeviceParameters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameters_UpdatedByUserId",
                schema: "QicFit",
                table: "DeviceParameters",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CreatedByUserId",
                schema: "QicFit",
                table: "Devices",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UpdatedByUserId",
                schema: "QicFit",
                table: "Devices",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCalls_ContactId",
                schema: "QicFit",
                table: "PhoneCalls",
                column: "ContactId");
        }
    }
}
