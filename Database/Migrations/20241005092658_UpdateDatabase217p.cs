using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase217p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icd10",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropColumn(
                name: "Icpc",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropColumn(
                name: "DiagnosisCode",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.AddColumn<int>(
                name: "HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoteTemplates_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates",
                column: "HealthCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationNotes_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes",
                column: "HealthCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationNotes_ICPC2_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes",
                column: "HealthCodeId",
                principalSchema: "Setting",
                principalTable: "ICPC2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTemplates_ICPC2_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates",
                column: "HealthCodeId",
                principalSchema: "Setting",
                principalTable: "ICPC2",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationNotes_ICPC2_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTemplates_ICPC2_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropIndex(
                name: "IX_NoteTemplates_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ConsultationNotes_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropColumn(
                name: "HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropColumn(
                name: "HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.AddColumn<string>(
                name: "Icd10",
                schema: "Setting",
                table: "NoteTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icpc",
                schema: "Setting",
                table: "NoteTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiagnosisCode",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
