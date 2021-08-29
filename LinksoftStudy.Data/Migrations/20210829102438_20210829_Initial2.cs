using Microsoft.EntityFrameworkCore.Migrations;

namespace LinksoftStudy.Data.Migrations
{
    public partial class _20210829_Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_People_ContacteeId",
                table: "ContactContactee");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_People_ContacteeId",
                table: "ContactContactee",
                column: "ContacteeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_People_ContacteeId",
                table: "ContactContactee");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_People_ContacteeId",
                table: "ContactContactee",
                column: "ContacteeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
