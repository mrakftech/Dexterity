using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase628p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrugAllergyName",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "DrugId",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "DrugType",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.DropColumn(
                name: "IsDrugAllergy",
                schema: "PM",
                table: "PatientAllergies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrugAllergyName",
                schema: "PM",
                table: "PatientAllergies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrugId",
                schema: "PM",
                table: "PatientAllergies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DrugType",
                schema: "PM",
                table: "PatientAllergies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDrugAllergy",
                schema: "PM",
                table: "PatientAllergies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
