using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugTracker.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bec2f559-0e72-4476-be34-d0425ccf889f", null, "User", "USER" },
                    { "e2b35cdc-f9b2-42a4-83c5-940b35c4193d", null, "Developer", "DEVELOPER" },
                    { "e964397b-012e-428c-8d9e-cca5aa85d8e6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec2f559-0e72-4476-be34-d0425ccf889f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2b35cdc-f9b2-42a4-83c5-940b35c4193d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e964397b-012e-428c-8d9e-cca5aa85d8e6");
        }
    }
}
