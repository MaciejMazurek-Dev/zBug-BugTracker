using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixNullableInIssueEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7782), new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7848), new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7852), new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7857), new DateTime(2024, 11, 15, 15, 57, 48, 296, DateTimeKind.Local).AddTicks(7859) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7137), new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7276), new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7281), new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7286), new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7288) });
        }
    }
}
