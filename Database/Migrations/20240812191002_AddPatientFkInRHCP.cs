using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientFkInRHCP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "PatientManagement",
                table: "RelatedHcps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RelatedHcps_PatientId",
                schema: "PatientManagement",
                table: "RelatedHcps",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedHcps_Patients_PatientId",
                schema: "PatientManagement",
                table: "RelatedHcps",
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
                name: "FK_RelatedHcps_Patients_PatientId",
                schema: "PatientManagement",
                table: "RelatedHcps");

            migrationBuilder.DropIndex(
                name: "IX_RelatedHcps_PatientId",
                schema: "PatientManagement",
                table: "RelatedHcps");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "PatientManagement",
                table: "RelatedHcps");
        }
    }
}
