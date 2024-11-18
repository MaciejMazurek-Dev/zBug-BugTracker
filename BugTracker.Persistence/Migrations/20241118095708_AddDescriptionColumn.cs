using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3776), new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3848) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3857), new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3870), new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3876) });

            migrationBuilder.UpdateData(
                table: "IssuePriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3885), new DateTime(2024, 11, 18, 10, 57, 7, 621, DateTimeKind.Local).AddTicks(3891) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

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
    }
}
