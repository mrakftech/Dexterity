using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientGroupDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupHead",
                schema: "PatientManagement",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationshipToPatient",
                schema: "PatientManagement",
                table: "GroupPatients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupHead",
                schema: "PatientManagement",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RelationshipToPatient",
                schema: "PatientManagement",
                table: "GroupPatients");
        }
    }
}
