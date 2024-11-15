using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase239a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestigationResults",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PatientInvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationResults_InvestigationDetails_InvestigationDetailId",
                        column: x => x.InvestigationDetailId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestigationResults_PatientInvestigations_PatientInvestigationId",
                        column: x => x.PatientInvestigationId,
                        principalSchema: "Consultation",
                        principalTable: "PatientInvestigations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationResults_InvestigationDetailId",
                schema: "Consultation",
                table: "InvestigationResults",
                column: "InvestigationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationResults_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationResults",
                column: "PatientInvestigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigationResults",
                schema: "Consultation");
        }
    }
}
