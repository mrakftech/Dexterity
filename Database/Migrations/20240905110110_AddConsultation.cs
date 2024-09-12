using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Consultation");

            migrationBuilder.CreateTable(
                name: "ConsultationDetails",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pomr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicSiteId = table.Column<int>(type: "int", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultationDetails_ClinicSites_ClinicSiteId",
                        column: x => x.ClinicSiteId,
                        principalSchema: "Setting",
                        principalTable: "ClinicSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationDetails_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationDetails_ClinicSiteId",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "ClinicSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationDetails_HcpId",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationDetails_PatientId",
                schema: "Consultation",
                table: "ConsultationDetails",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultationDetails",
                schema: "Consultation");
        }
    }
}
