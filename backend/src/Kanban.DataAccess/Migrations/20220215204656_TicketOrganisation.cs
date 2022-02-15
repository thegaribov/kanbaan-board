using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.DataAccess.Migrations
{
    public partial class TicketOrganisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrganisationId",
                table: "Tickets",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Organisations_OrganisationId",
                table: "Tickets",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Organisations_OrganisationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrganisationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Tickets");
        }
    }
}
