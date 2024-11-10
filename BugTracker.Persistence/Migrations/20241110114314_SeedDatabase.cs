using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IssueTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IssueStatuses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IssuePriorities",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9275), new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9331), new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9336), new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9338) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9340), new DateTime(2024, 11, 10, 12, 43, 13, 613, DateTimeKind.Local).AddTicks(9342) });

            migrationBuilder.InsertData(
                table: "IssueStatuses",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "New" },
                    { 2, null, null, "Assigned" },
                    { 3, null, null, "In progress" },
                    { 4, null, null, "Resolved" },
                    { 5, null, null, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Bug" },
                    { 2, null, null, "Defect" },
                    { 3, null, null, "New feature" },
                    { 4, null, null, "Task" },
                    { 5, null, null, "Improvement" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IssueStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IssueStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IssueStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IssueStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IssueStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IssueTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IssueStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IssuePriorities",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2219), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2275), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2277) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2279), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2281) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2284), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2286) });
        }
    }
}
