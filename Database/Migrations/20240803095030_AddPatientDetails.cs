using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GmsNumber",
                schema: "PatientManagement",
                table: "Patients",
                newName: "PrivateHealthInsuranceDetails");

            migrationBuilder.AddColumn<string>(
                name: "CompanyMedicalScheme",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrugPaymentSchemeDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalCardDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientType",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyMedicalScheme",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ContactDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DrugPaymentSchemeDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalCardDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientType",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PrivateHealthInsuranceDetails",
                schema: "PatientManagement",
                table: "Patients",
                newName: "GmsNumber");
        }
    }
}
