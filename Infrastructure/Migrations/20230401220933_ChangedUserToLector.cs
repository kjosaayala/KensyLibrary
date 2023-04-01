using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserToLector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Users_UserId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "data");

            migrationBuilder.AddColumn<int>(
                name: "LectorId",
                schema: "operation",
                table: "BookRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lectors",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisableDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisableUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnableDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnableUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Lectors_UserId",
                schema: "operation",
                table: "BookRequests",
                column: "UserId",
                principalSchema: "data",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Lectors_UserId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.DropTable(
                name: "Lectors",
                schema: "data");

            migrationBuilder.DropColumn(
                name: "LectorId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisableDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisableUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnableDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnableUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Users_UserId",
                schema: "operation",
                table: "BookRequests",
                column: "UserId",
                principalSchema: "data",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
