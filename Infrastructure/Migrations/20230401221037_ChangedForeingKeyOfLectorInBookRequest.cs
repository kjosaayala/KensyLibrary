using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeingKeyOfLectorInBookRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Lectors_UserId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_UserId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_LectorId",
                schema: "operation",
                table: "BookRequests",
                column: "LectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Lectors_LectorId",
                schema: "operation",
                table: "BookRequests",
                column: "LectorId",
                principalSchema: "data",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Lectors_LectorId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_LectorId",
                schema: "operation",
                table: "BookRequests");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "operation",
                table: "BookRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_UserId",
                schema: "operation",
                table: "BookRequests",
                column: "UserId");

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
    }
}
