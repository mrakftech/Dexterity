using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase323a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icd10",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icpc",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icd10",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropColumn(
                name: "Icpc",
                schema: "Consultation",
                table: "ConsultationNotes");
        }
    }
}
