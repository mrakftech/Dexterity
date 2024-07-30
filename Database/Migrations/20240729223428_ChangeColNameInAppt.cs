using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColNameInAppt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                schema: "Scheduler",
                table: "Appointments",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "End",
                schema: "Scheduler",
                table: "Appointments",
                newName: "EndTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                schema: "Scheduler",
                table: "Appointments",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                schema: "Scheduler",
                table: "Appointments",
                newName: "End");
        }
    }
}
