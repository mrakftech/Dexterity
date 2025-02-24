using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase958p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                schema: "Scheduler",
                table: "AvailabilityExceptions",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "From",
                schema: "Scheduler",
                table: "AvailabilityExceptions",
                newName: "EndTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlock",
                schema: "Scheduler",
                table: "AvailabilityExceptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                schema: "Scheduler",
                table: "AvailabilityExceptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlock",
                schema: "Scheduler",
                table: "AvailabilityExceptions");

            migrationBuilder.DropColumn(
                name: "Subject",
                schema: "Scheduler",
                table: "AvailabilityExceptions");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                schema: "Scheduler",
                table: "AvailabilityExceptions",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                schema: "Scheduler",
                table: "AvailabilityExceptions",
                newName: "From");
        }
    }
}
