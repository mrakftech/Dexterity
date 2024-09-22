using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase204 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NkaFlag",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.AddColumn<bool>(
                name: "NkaFlag",
                schema: "PM",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NkaFlag",
                schema: "PM",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "NkaFlag",
                schema: "PM",
                table: "PatientAllergies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
