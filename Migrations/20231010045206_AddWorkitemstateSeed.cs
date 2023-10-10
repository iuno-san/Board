using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkitemstateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "workItemStates",
                column: "Value",
                value: "Rejected" );

            migrationBuilder.InsertData(
                table: "workItemStates",
                column: "Value",
                value: "On Hold");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Value",
                keyValue: "Rejected" );

            migrationBuilder.DeleteData(
               table: "workItemStates",
               keyColumn: "Value",
               keyValue: "On Hold");
        }
    }
}
