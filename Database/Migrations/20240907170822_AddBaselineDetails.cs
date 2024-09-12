using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddBaselineDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaselineDetails",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Bmi = table.Column<float>(type: "real", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbdominalCircumference = table.Column<float>(type: "real", nullable: false),
                    SmokerStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmokePerDay = table.Column<int>(type: "int", nullable: false),
                    SmokingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExSmokerYears = table.Column<int>(type: "int", nullable: false),
                    DrinkingStatus = table.Column<int>(type: "int", nullable: false),
                    WeeklyAlcohol = table.Column<int>(type: "int", nullable: false),
                    DrinkingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamilyCvdHistory = table.Column<bool>(type: "bit", nullable: false),
                    Lvh = table.Column<bool>(type: "bit", nullable: false),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    Cholesterol = table.Column<float>(type: "real", nullable: false),
                    Ldl = table.Column<float>(type: "real", nullable: false),
                    Hdl = table.Column<float>(type: "real", nullable: false),
                    Pulse = table.Column<int>(type: "int", nullable: false),
                    PulseRhythm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    PeakFlow = table.Column<int>(type: "int", nullable: false),
                    RespiratoryRate = table.Column<int>(type: "int", nullable: false),
                    CurrentOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtanceMisuse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaselineDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaselineDetails_ConsultationDetails_ConsultationDetailId",
                        column: x => x.ConsultationDetailId,
                        principalSchema: "Consultation",
                        principalTable: "ConsultationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "ConsultationDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaselineDetails",
                schema: "Consultation");
        }
    }
}
