using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase742p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigationAudits_Users_HcpId",
                schema: "Consultation",
                table: "InvestigationAudits");

            migrationBuilder.DropIndex(
                name: "IX_InvestigationAudits_HcpId",
                schema: "Consultation",
                table: "InvestigationAudits");

            migrationBuilder.DropColumn(
                name: "HcpId",
                schema: "Consultation",
                table: "InvestigationAudits");

            migrationBuilder.AddColumn<string>(
                name: "HcpName",
                schema: "Consultation",
                table: "InvestigationAudits",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HcpName",
                schema: "Consultation",
                table: "InvestigationAudits");

            migrationBuilder.AddColumn<Guid>(
                name: "HcpId",
                schema: "Consultation",
                table: "InvestigationAudits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationAudits_HcpId",
                schema: "Consultation",
                table: "InvestigationAudits",
                column: "HcpId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigationAudits_Users_HcpId",
                schema: "Consultation",
                table: "InvestigationAudits",
                column: "HcpId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
