using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientIdInBaselineDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaitentId",
                schema: "Consultation",
                table: "BaselineDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "Consultation",
                table: "BaselineDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_PatientId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineDetails_Patients_PatientId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "PatientId",
                principalSchema: "PM",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaselineDetails_Patients_PatientId",
                schema: "Consultation",
                table: "BaselineDetails");

            migrationBuilder.DropIndex(
                name: "IX_BaselineDetails_PatientId",
                schema: "Consultation",
                table: "BaselineDetails");

            migrationBuilder.DropColumn(
                name: "PaitentId",
                schema: "Consultation",
                table: "BaselineDetails");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "Consultation",
                table: "BaselineDetails");
        }
    }
}
