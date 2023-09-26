using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Migrations
{
    /// <inheritdoc />
    public partial class UserToCommentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "comments");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_comments_AuthorId",
                table: "comments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_AuthorId",
                table: "comments",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_AuthorId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_AuthorId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "comments");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
