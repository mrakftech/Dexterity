using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchemaOfAppoinment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Clinics_ClinicId",
                schema: "AppointmentManagement",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                schema: "AppointmentManagement",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                schema: "AppointmentManagement",
                table: "Appointment");

            migrationBuilder.EnsureSchema(
                name: "Scheduler");

            migrationBuilder.RenameTable(
                name: "Appointment",
                schema: "AppointmentManagement",
                newName: "Appointments",
                newSchema: "Scheduler");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PatientId",
                schema: "Scheduler",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ClinicId",
                schema: "Scheduler",
                table: "Appointments",
                newName: "IX_Appointments_ClinicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                schema: "Scheduler",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clinics_ClinicId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                schema: "Scheduler",
                table: "Appointments",
                column: "PatientId",
                principalSchema: "PatientManagement",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clinics_ClinicId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.EnsureSchema(
                name: "AppointmentManagement");

            migrationBuilder.RenameTable(
                name: "Appointments",
                schema: "Scheduler",
                newName: "Appointment",
                newSchema: "AppointmentManagement");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                schema: "AppointmentManagement",
                table: "Appointment",
                newName: "IX_Appointment_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClinicId",
                schema: "AppointmentManagement",
                table: "Appointment",
                newName: "IX_Appointment_ClinicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                schema: "AppointmentManagement",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Clinics_ClinicId",
                schema: "AppointmentManagement",
                table: "Appointment",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                schema: "AppointmentManagement",
                table: "Appointment",
                column: "PatientId",
                principalSchema: "PatientManagement",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
