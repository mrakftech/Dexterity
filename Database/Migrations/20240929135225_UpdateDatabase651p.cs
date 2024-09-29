using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase651p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AppointmentTypes",
                schema: "Scheduler",
                newName: "AppointmentTypes",
                newSchema: "Setting");

            migrationBuilder.RenameTable(
                name: "AppointmentCancellationReasons",
                schema: "Scheduler",
                newName: "AppointmentCancellationReasons",
                newSchema: "Setting");

            migrationBuilder.CreateTable(
                name: "ICPC2",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chapter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descritpion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICPC2", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ICPC2",
                schema: "Setting");

            migrationBuilder.RenameTable(
                name: "AppointmentTypes",
                schema: "Setting",
                newName: "AppointmentTypes",
                newSchema: "Scheduler");

            migrationBuilder.RenameTable(
                name: "AppointmentCancellationReasons",
                schema: "Setting",
                newName: "AppointmentCancellationReasons",
                newSchema: "Scheduler");
        }
    }
}
