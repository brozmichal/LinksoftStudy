using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinksoftStudy.Data.Migrations
{
    public partial class _20210826_ContactContactee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactContactee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    ContacteeId = table.Column<int>(type: "int", nullable: false),
                    PersonEntityId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactContactee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactContactee_People_ContacteeId",
                        column: x => x.ContacteeId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactContactee_People_ContactId",
                        column: x => x.ContactId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactContactee_People_PersonEntityId",
                        column: x => x.PersonEntityId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactee_ContacteeId",
                table: "ContactContactee",
                column: "ContacteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactee_ContactId",
                table: "ContactContactee",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactee_PersonEntityId",
                table: "ContactContactee",
                column: "PersonEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactContactee");
        }
    }
}
