using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactDetails",
                schema: "PatientManagement",
                table: "Patients",
                newName: "MobilePhone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "MobilePhone",
                schema: "PatientManagement",
                table: "Patients",
                newName: "ContactDetails");
        }
    }
}
