using Microsoft.EntityFrameworkCore.Migrations;

namespace LinksoftStudy.Data.Migrations
{
    public partial class _20210826_ContactContactee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_People_PersonEntityId",
                table: "ContactContactee");

            migrationBuilder.DropIndex(
                name: "IX_ContactContactee_PersonEntityId",
                table: "ContactContactee");

            migrationBuilder.DropColumn(
                name: "PersonEntityId",
                table: "ContactContactee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonEntityId",
                table: "ContactContactee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactee_PersonEntityId",
                table: "ContactContactee",
                column: "PersonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_People_PersonEntityId",
                table: "ContactContactee",
                column: "PersonEntityId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
