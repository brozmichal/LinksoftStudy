using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinksoftStudy.Data.Migrations
{
    public partial class _20210830_RenamePersonToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_People_ContacteeId",
                table: "ContactContactee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_People_ContactId",
                table: "ContactContactee");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_Users_ContacteeId",
                table: "ContactContactee",
                column: "ContacteeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_Users_ContactId",
                table: "ContactContactee",
                column: "ContactId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_Users_ContacteeId",
                table: "ContactContactee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactContactee_Users_ContactId",
                table: "ContactContactee");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_People_ContacteeId",
                table: "ContactContactee",
                column: "ContacteeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactContactee_People_ContactId",
                table: "ContactContactee",
                column: "ContactId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
