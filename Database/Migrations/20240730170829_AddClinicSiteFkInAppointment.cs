using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicSiteFkInAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ClinicSites_ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicSiteId",
                principalSchema: "Setting",
                principalTable: "ClinicSites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ClinicSites_ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments");
        }
    }
}
