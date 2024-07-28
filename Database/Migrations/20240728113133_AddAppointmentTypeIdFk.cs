using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentTypeIdFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments",
                column: "AppointmentTypeId",
                principalSchema: "Scheduler",
                principalTable: "AppointmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Scheduler",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
