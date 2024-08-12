using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlertType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                schema: "PatientManagement",
                table: "PatientAlerts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResolved",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "PatientManagement",
                table: "PatientAlerts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
