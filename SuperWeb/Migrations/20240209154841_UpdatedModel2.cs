using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Posts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PostCommentID",
                table: "PostComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostCommentID",
                table: "PostComments",
                column: "PostCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_PostCommentID",
                table: "PostComments",
                column: "PostCommentID",
                principalTable: "PostComments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_PostCommentID",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_PostCommentID",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCommentID",
                table: "PostComments");
        }
    }
}
