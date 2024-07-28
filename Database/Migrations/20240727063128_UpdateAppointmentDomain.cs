using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                schema: "Scheduler",
                table: "Appointments",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                schema: "Scheduler",
                table: "Appointments",
                newName: "End");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                schema: "Scheduler",
                table: "Appointments",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End",
                schema: "Scheduler",
                table: "Appointments",
                newName: "EndDate");
        }
    }
}
