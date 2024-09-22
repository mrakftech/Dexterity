using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase112a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                schema: "PM",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDrugAllergies_Patients_PatientId",
                schema: "PM",
                table: "PatientDrugAllergies");

            migrationBuilder.DropIndex(
                name: "IX_PatientDrugAllergies_PatientId",
                schema: "PM",
                table: "PatientDrugAllergies");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_PatientId",
                schema: "PM",
                table: "PatientAllergies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugAllergies_PatientId",
                schema: "PM",
                table: "PatientDrugAllergies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientId",
                schema: "PM",
                table: "PatientAllergies",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                schema: "PM",
                table: "PatientAllergies",
                column: "PatientId",
                principalSchema: "PM",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDrugAllergies_Patients_PatientId",
                schema: "PM",
                table: "PatientDrugAllergies",
                column: "PatientId",
                principalSchema: "PM",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
