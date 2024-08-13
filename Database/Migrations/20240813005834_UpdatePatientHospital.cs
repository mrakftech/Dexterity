using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientHospital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clinics_ClinicId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSites_Clinics_ClinicId",
                schema: "Setting",
                table: "ClinicSites");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientHospitals_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Clinics_ClinicId",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClinics_Clinics_ClinicId",
                schema: "Identity",
                table: "UserClinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Clinics_ClinicId",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_PatientHospitals_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                schema: "Setting",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropColumn(
                name: "Contact",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropColumn(
                name: "Fax",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropColumn(
                name: "PatientHospitalNo",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.RenameTable(
                name: "Clinics",
                schema: "Setting",
                newName: "Clinic",
                newSchema: "Setting");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinic",
                schema: "Setting",
                table: "Clinic",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitals_ClinicId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clinic_ClinicId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSites_Clinic_ClinicId",
                schema: "Setting",
                table: "ClinicSites",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHospitals_Clinic_ClinicId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Clinic_ClinicId",
                schema: "PatientManagement",
                table: "Patients",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClinics_Clinic_ClinicId",
                schema: "Identity",
                table: "UserClinics",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clinic_ClinicId",
                schema: "Identity",
                table: "Users",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Clinic_ClinicId",
                schema: "Messaging",
                table: "UserTasks",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clinic_ClinicId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSites_Clinic_ClinicId",
                schema: "Setting",
                table: "ClinicSites");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientHospitals_Clinic_ClinicId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Clinic_ClinicId",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClinics_Clinic_ClinicId",
                schema: "Identity",
                table: "UserClinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clinic_ClinicId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Clinic_ClinicId",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_PatientHospitals_ClinicId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinic",
                schema: "Setting",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                schema: "PatientManagement",
                table: "PatientHospitals");

            migrationBuilder.RenameTable(
                name: "Clinic",
                schema: "Setting",
                newName: "Clinics",
                newSchema: "Setting");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientHospitalNo",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                schema: "Setting",
                table: "Clinics",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitals_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clinics_ClinicId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSites_Clinics_ClinicId",
                schema: "Setting",
                table: "ClinicSites",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHospitals_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientHospitals",
                column: "PatientId",
                principalSchema: "PatientManagement",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Clinics_ClinicId",
                schema: "PatientManagement",
                table: "Patients",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClinics_Clinics_ClinicId",
                schema: "Identity",
                table: "UserClinics",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                schema: "Identity",
                table: "Users",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Clinics_ClinicId",
                schema: "Messaging",
                table: "UserTasks",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
