using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase908 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCondition",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFamilyHistory",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPastHistory",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsScoialHistory",
                schema: "Consultation",
                table: "ConsultationNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveCondition",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropColumn(
                name: "IsFamilyHistory",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropColumn(
                name: "IsPastHistory",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropColumn(
                name: "IsScoialHistory",
                schema: "Consultation",
                table: "ConsultationNotes");
        }
    }
}
