using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_eight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppUserID",
                table: "Notifications",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_AppUserID",
                table: "Notifications",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_AppUserID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AppUserID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Notifications");
        }
    }
}
