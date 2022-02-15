using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.DataAccess.Migrations
{
    public partial class UserTicketOrganisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTicketOrganisations",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTicketOrganisations", x => new { x.UserId, x.OrganisationId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_UserTicketOrganisations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTicketOrganisations_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTicketOrganisations_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTicketOrganisations_OrganisationId",
                table: "UserTicketOrganisations",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTicketOrganisations_TicketId",
                table: "UserTicketOrganisations",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTicketOrganisations");
        }
    }
}
