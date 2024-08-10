using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemovedExtraPatientDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientExtraDetails",
                schema: "PatientManagement");

            migrationBuilder.AddColumn<string>(
                name: "DrugPaymentSchemeDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivateHealthInsuranceDetails",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrugPaymentSchemeDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritalDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OtherDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PrivateHealthInsuranceDetails",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.CreateTable(
                name: "PatientExtraDetails",
                schema: "PatientManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugPaymentSchemeDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateHealthInsuranceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientExtraDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientExtraDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PatientManagement",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientExtraDetails_PatientId",
                schema: "PatientManagement",
                table: "PatientExtraDetails",
                column: "PatientId");
        }
    }
}
