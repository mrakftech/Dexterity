using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "PM",
                table: "PatientAllergies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientId",
                schema: "PM",
                table: "PatientAllergies",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                schema: "PM",
                table: "PatientAllergies",
                column: "PatientId",
                principalSchema: "PM",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_PatientId",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "PM",
                table: "PatientAllergies");
        }
    }
}
