using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientAlerts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientAlerts_PatientId",
                schema: "PatientManagement",
                table: "PatientAlerts",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAlerts_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientAlerts",
                column: "PatientId",
                principalSchema: "PatientManagement",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAlerts_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.DropIndex(
                name: "IX_PatientAlerts_PatientId",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientAlerts");
        }
    }
}
