using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssuePriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuePriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IssueTypeId = table.Column<int>(type: "int", nullable: true),
                    IssueStatusId = table.Column<int>(type: "int", nullable: true),
                    IssuePriorityId = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assignee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_IssuePriorities_IssuePriorityId",
                        column: x => x.IssuePriorityId,
                        principalTable: "IssuePriorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issues_IssueStatuses_IssueStatusId",
                        column: x => x.IssueStatusId,
                        principalTable: "IssueStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issues_IssueTypes_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "IssuePriorities",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2219), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2270), "Low" },
                    { 2, new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2275), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2277), "Medium" },
                    { 3, new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2279), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2281), "High" },
                    { 4, new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2284), new DateTime(2024, 9, 30, 12, 23, 0, 449, DateTimeKind.Local).AddTicks(2286), "Critical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssuePriorityId",
                table: "Issues",
                column: "IssuePriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "IssuePriorities");

            migrationBuilder.DropTable(
                name: "IssueStatuses");

            migrationBuilder.DropTable(
                name: "IssueTypes");
        }
    }
}
