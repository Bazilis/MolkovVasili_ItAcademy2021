using Microsoft.EntityFrameworkCore.Migrations;

namespace Hometask5.Migrations.Migrations
{
    public partial class RemoveOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyEntityId",
                table: "Users",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyEntityId",
                table: "Users",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
