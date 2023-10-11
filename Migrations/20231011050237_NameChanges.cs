using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Migrations
{
    /// <inheritdoc />
    public partial class NameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_users_UserId",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_AuthorId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_workItems_WorkItemId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_workItems_users_AuthorId",
                table: "workItems");

            migrationBuilder.DropForeignKey(
                name: "FK_workItems_workItemStates_StateId",
                table: "workItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemTag_tags_TagId",
                table: "WorkItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemTag_workItems_workItemId",
                table: "WorkItemTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workItemStates",
                table: "workItemStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workItems",
                table: "workItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tags",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "workItemStates",
                newName: "WorkItemStates");

            migrationBuilder.RenameTable(
                name: "workItems",
                newName: "WorkItems");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "workItemId",
                table: "WorkItemTag",
                newName: "WorkItemId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItemTag_workItemId",
                table: "WorkItemTag",
                newName: "IX_WorkItemTag_WorkItemId");

            migrationBuilder.RenameColumn(
                name: "RemainingWork",
                table: "WorkItems",
                newName: "RemaningWork");

            migrationBuilder.RenameIndex(
                name: "IX_workItems_StateId",
                table: "WorkItems",
                newName: "IX_WorkItems_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_workItems_AuthorId",
                table: "WorkItems",
                newName: "IX_WorkItems_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_UserId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItemStates",
                table: "WorkItemStates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Users_AuthorId",
                table: "comments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_WorkItems_WorkItemId",
                table: "comments",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_Users_AuthorId",
                table: "WorkItems",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_WorkItemStates_StateId",
                table: "WorkItems",
                column: "StateId",
                principalTable: "WorkItemStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemTag_Tags_TagId",
                table: "WorkItemTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemTag_WorkItems_WorkItemId",
                table: "WorkItemTag",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_Users_AuthorId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_WorkItems_WorkItemId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Users_AuthorId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_WorkItemStates_StateId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemTag_Tags_TagId",
                table: "WorkItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemTag_WorkItems_WorkItemId",
                table: "WorkItemTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItemStates",
                table: "WorkItemStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "WorkItemStates",
                newName: "workItemStates");

            migrationBuilder.RenameTable(
                name: "WorkItems",
                newName: "workItems");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "tags");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "addresses");

            migrationBuilder.RenameColumn(
                name: "WorkItemId",
                table: "WorkItemTag",
                newName: "workItemId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItemTag_WorkItemId",
                table: "WorkItemTag",
                newName: "IX_WorkItemTag_workItemId");

            migrationBuilder.RenameColumn(
                name: "RemaningWork",
                table: "workItems",
                newName: "RemainingWork");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItems_StateId",
                table: "workItems",
                newName: "IX_workItems_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItems_AuthorId",
                table: "workItems",
                newName: "IX_workItems_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "addresses",
                newName: "IX_addresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workItemStates",
                table: "workItemStates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workItems",
                table: "workItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tags",
                table: "tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_users_UserId",
                table: "addresses",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_AuthorId",
                table: "comments",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_workItems_WorkItemId",
                table: "comments",
                column: "WorkItemId",
                principalTable: "workItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_users_AuthorId",
                table: "workItems",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_workItemStates_StateId",
                table: "workItems",
                column: "StateId",
                principalTable: "workItemStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemTag_tags_TagId",
                table: "WorkItemTag",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemTag_workItems_workItemId",
                table: "WorkItemTag",
                column: "workItemId",
                principalTable: "workItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
