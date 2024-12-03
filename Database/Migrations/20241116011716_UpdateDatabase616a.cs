using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase616a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Consultation",
                table: "PatientInvestigations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Consultation",
                table: "PatientInvestigations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Consultation",
                table: "PatientInvestigations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationAudits_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits",
                column: "PatientInvestigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigationAudits_PatientInvestigations_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits",
                column: "PatientInvestigationId",
                principalSchema: "Consultation",
                principalTable: "PatientInvestigations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigationAudits_PatientInvestigations_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits");

            migrationBuilder.DropIndex(
                name: "IX_InvestigationAudits_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Consultation",
                table: "PatientInvestigations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Consultation",
                table: "PatientInvestigations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Consultation",
                table: "PatientInvestigations");

            migrationBuilder.DropColumn(
                name: "PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits");
        }
    }
}
