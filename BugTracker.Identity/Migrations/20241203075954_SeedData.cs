using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7C85DDC9-5066-49D4-8D31-61C41D60414E", 0, "32fe9448-0c6c-43b2-b605-802c19c333a6", "admin@example.com", false, "Admin", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEC/tlG1etbHRwF9Vi/xhaTlLtnOVA0O+SWvDP0cU+HOY8qIiQbnwcJ14ueFAGwgv9g==", null, false, "ce907fd5-ccb4-4e96-a7ea-45712a14f5ef", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e964397b-012e-428c-8d9e-cca5aa85d8e6", "7C85DDC9-5066-49D4-8D31-61C41D60414E" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e964397b-012e-428c-8d9e-cca5aa85d8e6", "7C85DDC9-5066-49D4-8D31-61C41D60414E" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7C85DDC9-5066-49D4-8D31-61C41D60414E");
        }
    }
}
