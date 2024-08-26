using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHospitals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientHospitals_Clinic_ClinicId",
                schema: "PM",
                table: "PatientHospitals");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                schema: "PM",
                table: "PatientHospitals",
                newName: "HospitalId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientHospitals_ClinicId",
                schema: "PM",
                table: "PatientHospitals",
                newName: "IX_PatientHospitals_HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHospitals_Hospitals_HospitalId",
                schema: "PM",
                table: "PatientHospitals",
                column: "HospitalId",
                principalSchema: "PM",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientHospitals_Hospitals_HospitalId",
                schema: "PM",
                table: "PatientHospitals");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                schema: "PM",
                table: "PatientHospitals",
                newName: "ClinicId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientHospitals_HospitalId",
                schema: "PM",
                table: "PatientHospitals",
                newName: "IX_PatientHospitals_ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHospitals_Clinic_ClinicId",
                schema: "PM",
                table: "PatientHospitals",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
