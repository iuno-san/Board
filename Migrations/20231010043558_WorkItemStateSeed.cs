using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Board.Migrations
{
    /// <inheritdoc />
    public partial class WorkItemStateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "workItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "To Do" },
                    { 2, "Doing" },
                    { 3, "Done" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
