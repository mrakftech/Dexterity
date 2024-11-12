using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase414a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigations_InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations",
                column: "InvestigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInvestigations_Investigations_InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations",
                column: "InvestigationId",
                principalSchema: "Setting",
                principalTable: "Investigations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInvestigations_Investigations_InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations");

            migrationBuilder.DropIndex(
                name: "IX_PatientInvestigations_InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations");

            migrationBuilder.DropColumn(
                name: "InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations");
        }
    }
}
