using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaselineDetail1008p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaselineDetails",
                schema: "Consultation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaselineDetails",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbdominalCircumference = table.Column<float>(type: "real", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bmi = table.Column<float>(type: "real", nullable: false),
                    Cholesterol = table.Column<float>(type: "real", nullable: false),
                    CurrentOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    DrinkingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrinkingStatus = table.Column<bool>(type: "bit", nullable: false),
                    ExSmokerYears = table.Column<int>(type: "int", nullable: false),
                    FamilyCvdHistory = table.Column<bool>(type: "bit", nullable: false),
                    Hdl = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Ldl = table.Column<float>(type: "real", nullable: false),
                    Lvh = table.Column<bool>(type: "bit", nullable: false),
                    PeakFlow = table.Column<int>(type: "int", nullable: false),
                    Pulse = table.Column<int>(type: "int", nullable: false),
                    PulseRhythm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespiratoryRate = table.Column<int>(type: "int", nullable: false),
                    SmokePerDay = table.Column<int>(type: "int", nullable: false),
                    SmokerStatus = table.Column<bool>(type: "bit", nullable: false),
                    SmokingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubtanceMisuse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    WeeklyAlcohol = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaselineDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaselineDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaselineDetails_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_HcpId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_PatientId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "PatientId");
        }
    }
}
