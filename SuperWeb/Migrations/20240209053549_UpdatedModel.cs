using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows");

            migrationBuilder.DropIndex(
                name: "IX_UserFollows_UserID",
                table: "UserFollows");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_PostID",
                table: "PostLikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows",
                columns: new[] { "UserID", "UserFollowID" });

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostID_UserID",
                table: "PostLikes",
                columns: new[] { "PostID", "UserID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_PostID_UserID",
                table: "PostLikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_UserID",
                table: "UserFollows",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostID",
                table: "PostLikes",
                column: "PostID");
        }
    }
}
