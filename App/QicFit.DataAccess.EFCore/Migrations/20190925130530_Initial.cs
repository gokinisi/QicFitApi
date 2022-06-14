using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QicFit.DataAccess.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "qicfit");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    NumberType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityConsumptions",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ConsumedValue = table.Column<int>(nullable: false),
                    SpentMoneyValue = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityConsumptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrafficConsumptions",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ConsumedValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficConsumptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhotos",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhotos_Contacts_Id",
                        column: x => x.Id,
                        principalSchema: "qicfit",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCalls",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCall = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneCalls_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "qicfit",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsOn = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ThemeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Users_Id",
                        column: x => x.Id,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: false),
                    ClaimValue = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhotos_Users_Id",
                        column: x => x.Id,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "qicfit",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "qicfit",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceParameters",
                schema: "qicfit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceParameters_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceParameters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "qicfit",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceParameters_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "qicfit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameters_CreatedByUserId",
                schema: "qicfit",
                table: "DeviceParameters",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameters_DeviceId",
                schema: "qicfit",
                table: "DeviceParameters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameters_UpdatedByUserId",
                schema: "qicfit",
                table: "DeviceParameters",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CreatedByUserId",
                schema: "qicfit",
                table: "Devices",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UpdatedByUserId",
                schema: "qicfit",
                table: "Devices",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCalls_ContactId",
                schema: "qicfit",
                table: "PhoneCalls",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "qicfit",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "qicfit",
                table: "UserRoles",
                column: "RoleId");

            // Seed initial data
            migrationBuilder.Sql(SeedData.Initial("qicfit"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPhotos",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "DeviceParameters",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "ElectricityConsumptions",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "PhoneCalls",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "TrafficConsumptions",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "UserPhotos",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "Devices",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "qicfit");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "qicfit");
        }
    }
}
