using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientHospital753a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitals_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHospitals_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals",
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
                name: "FK_PatientHospitals_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropIndex(
                name: "IX_PatientHospitals_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals");
        }
    }
}
