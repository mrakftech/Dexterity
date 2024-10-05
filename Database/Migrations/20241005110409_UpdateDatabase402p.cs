using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase402p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationDetails_ClinicSites_ClinicSiteId",
                schema: "Consultation",
                table: "ConsultationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationDetails_Patients_PatientId",
                schema: "Consultation",
                table: "ConsultationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationDetails_Users_HcpId",
                schema: "Consultation",
                table: "ConsultationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationNotes_ConsultationDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationNotes_ICPC2_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTemplates_ICPC2_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ICPC2",
                schema: "Setting",
                table: "ICPC2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultationNotes",
                schema: "Consultation",
                table: "ConsultationNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultationDetails",
                schema: "Consultation",
                table: "ConsultationDetails");

            migrationBuilder.RenameTable(
                name: "ICPC2",
                schema: "Setting",
                newName: "HeathCodes",
                newSchema: "Setting");

            migrationBuilder.RenameTable(
                name: "ConsultationNotes",
                schema: "Consultation",
                newName: "Notes",
                newSchema: "Consultation");

            migrationBuilder.RenameTable(
                name: "ConsultationDetails",
                schema: "Consultation",
                newName: "Details",
                newSchema: "Consultation");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationNotes_HealthCodeId",
                schema: "Consultation",
                table: "Notes",
                newName: "IX_Notes_HealthCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationNotes_ConsultationDetailId",
                schema: "Consultation",
                table: "Notes",
                newName: "IX_Notes_ConsultationDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationDetails_PatientId",
                schema: "Consultation",
                table: "Details",
                newName: "IX_Details_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationDetails_HcpId",
                schema: "Consultation",
                table: "Details",
                newName: "IX_Details_HcpId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationDetails_ClinicSiteId",
                schema: "Consultation",
                table: "Details",
                newName: "IX_Details_ClinicSiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeathCodes",
                schema: "Setting",
                table: "HeathCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                schema: "Consultation",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                schema: "Consultation",
                table: "Details",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_ClinicSites_ClinicSiteId",
                schema: "Consultation",
                table: "Details",
                column: "ClinicSiteId",
                principalSchema: "Setting",
                principalTable: "ClinicSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Patients_PatientId",
                schema: "Consultation",
                table: "Details",
                column: "PatientId",
                principalSchema: "PM",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Users_HcpId",
                schema: "Consultation",
                table: "Details",
                column: "HcpId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Details_ConsultationDetailId",
                schema: "Consultation",
                table: "Notes",
                column: "ConsultationDetailId",
                principalSchema: "Consultation",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_HeathCodes_HealthCodeId",
                schema: "Consultation",
                table: "Notes",
                column: "HealthCodeId",
                principalSchema: "Setting",
                principalTable: "HeathCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTemplates_HeathCodes_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates",
                column: "HealthCodeId",
                principalSchema: "Setting",
                principalTable: "HeathCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_ClinicSites_ClinicSiteId",
                schema: "Consultation",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Patients_PatientId",
                schema: "Consultation",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Users_HcpId",
                schema: "Consultation",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Details_ConsultationDetailId",
                schema: "Consultation",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_HeathCodes_HealthCodeId",
                schema: "Consultation",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTemplates_HeathCodes_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                schema: "Consultation",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeathCodes",
                schema: "Setting",
                table: "HeathCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                schema: "Consultation",
                table: "Details");

            migrationBuilder.RenameTable(
                name: "Notes",
                schema: "Consultation",
                newName: "ConsultationNotes",
                newSchema: "Consultation");

            migrationBuilder.RenameTable(
                name: "HeathCodes",
                schema: "Setting",
                newName: "ICPC2",
                newSchema: "Setting");

            migrationBuilder.RenameTable(
                name: "Details",
                schema: "Consultation",
                newName: "ConsultationDetails",
                newSchema: "Consultation");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes",
                newName: "IX_ConsultationNotes_HealthCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_ConsultationDetailId",
                schema: "Consultation",
                table: "ConsultationNotes",
                newName: "IX_ConsultationNotes_ConsultationDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_PatientId",
                schema: "Consultation",
                table: "ConsultationDetails",
                newName: "IX_ConsultationDetails_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_HcpId",
                schema: "Consultation",
                table: "ConsultationDetails",
                newName: "IX_ConsultationDetails_HcpId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_ClinicSiteId",
                schema: "Consultation",
                table: "ConsultationDetails",
                newName: "IX_ConsultationDetails_ClinicSiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultationNotes",
                schema: "Consultation",
                table: "ConsultationNotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ICPC2",
                schema: "Setting",
                table: "ICPC2",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultationDetails",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationDetails_ClinicSites_ClinicSiteId",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "ClinicSiteId",
                principalSchema: "Setting",
                principalTable: "ClinicSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationDetails_Patients_PatientId",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "PatientId",
                principalSchema: "PM",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationDetails_Users_HcpId",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "HcpId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationNotes_ConsultationDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "ConsultationNotes",
                column: "ConsultationDetailId",
                principalSchema: "Consultation",
                principalTable: "ConsultationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationNotes_ICPC2_HealthCodeId",
                schema: "Consultation",
                table: "ConsultationNotes",
                column: "HealthCodeId",
                principalSchema: "Setting",
                principalTable: "ICPC2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTemplates_ICPC2_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates",
                column: "HealthCodeId",
                principalSchema: "Setting",
                principalTable: "ICPC2",
                principalColumn: "Id");
        }
    }
}
