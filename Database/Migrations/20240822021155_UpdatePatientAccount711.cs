using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientAccount711 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientAccounts_PatientId",
                schema: "PatientManagement",
                table: "PatientAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PatientId",
                schema: "PatientManagement",
                table: "PatientAccounts",
                column: "PatientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientAccounts_PatientId",
                schema: "PatientManagement",
                table: "PatientAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PatientId",
                schema: "PatientManagement",
                table: "PatientAccounts",
                column: "PatientId");
        }
    }
}
