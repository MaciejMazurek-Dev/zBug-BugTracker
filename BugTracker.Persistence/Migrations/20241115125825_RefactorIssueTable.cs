using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorIssueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssuePriorities_IssuePriorityId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueStatuses_IssueStatusId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueTypes_IssueTypeId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Assignee",
                table: "Issues",
                newName: "AssigneeId");

            migrationBuilder.AlterColumn<int>(
                name: "IssueTypeId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IssueStatusId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IssuePriorityId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssuePriorities_IssuePriorityId",
                table: "Issues",
                column: "IssuePriorityId",
                principalTable: "IssuePriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueStatuses_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "IssueStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueTypes_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssuePriorities_IssuePriorityId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueStatuses_IssueStatusId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueTypes_IssueTypeId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "AssigneeId",
                table: "Issues",
                newName: "Assignee");

            migrationBuilder.AlterColumn<int>(
                name: "IssueTypeId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IssueStatusId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IssuePriorityId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssuePriorities_IssuePriorityId",
                table: "Issues",
                column: "IssuePriorityId",
                principalTable: "IssuePriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueStatuses_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "IssueStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueTypes_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypes",
                principalColumn: "Id");
        }
    }
}
