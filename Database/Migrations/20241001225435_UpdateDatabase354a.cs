using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase354a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icd10",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.RenameColumn(
                name: "Icpc",
                schema: "Consultation",
                table: "ConsultationNotes",
                newName: "DiagnosisCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiagnosisCode",
                schema: "Consultation",
                table: "ConsultationNotes",
                newName: "Icpc");

            migrationBuilder.AddColumn<string>(
                name: "Icd10",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
