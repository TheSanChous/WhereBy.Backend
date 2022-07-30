using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereBuy.Persistence.Migrations
{
    public partial class AddNoticeCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Notices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notices_CreatorId",
                table: "Notices",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Users_CreatorId",
                table: "Notices",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Users_CreatorId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_CreatorId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Notices");
        }
    }
}
