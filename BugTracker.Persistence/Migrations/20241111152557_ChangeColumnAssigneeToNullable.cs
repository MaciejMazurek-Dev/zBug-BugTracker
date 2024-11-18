using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnAssigneeToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Issues");

            migrationBuilder.AlterColumn<string>(
                name: "Assignee",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5209), new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5259) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5264), new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5266) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5269), new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5271) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5273), new DateTime(2024, 11, 11, 16, 25, 56, 714, DateTimeKind.Local).AddTicks(5275) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Assignee",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
