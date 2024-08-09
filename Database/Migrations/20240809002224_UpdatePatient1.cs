using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatient1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvocacyNeeds",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Ethnicity",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InterpreterRequired",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Occupation",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PreferredLanguage",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Religion",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "TransportNeeds",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "DispensingStatus",
                schema: "PatientManagement",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DispensingStatus",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "AdvocacyNeeds",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterpreterRequired",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredLanguage",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportNeeds",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
