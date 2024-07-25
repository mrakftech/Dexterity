using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddHCPInPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HealthCareProfessionalId",
                schema: "PatientManagement",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HealthCareProfessionalId",
                schema: "PatientManagement",
                table: "Patients",
                column: "HealthCareProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_HealthCareProfessionalId",
                schema: "PatientManagement",
                table: "Patients",
                column: "HealthCareProfessionalId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_HealthCareProfessionalId",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HealthCareProfessionalId",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HealthCareProfessionalId",
                schema: "PatientManagement",
                table: "Patients");
        }
    }
}
