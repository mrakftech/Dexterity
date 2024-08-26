using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingAppointments_ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingAppointments_Clinic_ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitingAppointments_Clinic_ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments");

            migrationBuilder.DropIndex(
                name: "IX_WaitingAppointments_ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments");
        }
    }
}
