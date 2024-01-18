using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AppUserID",
                table: "Blogs",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserID",
                table: "Blogs",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserID",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AppUserID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Blogs");
        }
    }
}
