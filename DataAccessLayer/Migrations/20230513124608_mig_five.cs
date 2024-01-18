using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_AppUserID",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_BlogID",
                table: "Likes",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_AppUserID",
                table: "Likes",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Blogs_BlogID",
                table: "Likes",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_AppUserID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Blogs_BlogID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_BlogID",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "Likes");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_AppUserID",
                table: "Likes",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
