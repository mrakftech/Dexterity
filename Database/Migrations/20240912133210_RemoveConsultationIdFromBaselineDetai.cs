using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConsultationIdFromBaselineDetai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaselineDetails_ConsultationDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails");

            migrationBuilder.DropIndex(
                name: "IX_BaselineDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails");

            migrationBuilder.DropColumn(
                name: "ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "ConsultationDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineDetails_ConsultationDetails_ConsultationDetailId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "ConsultationDetailId",
                principalSchema: "Consultation",
                principalTable: "ConsultationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
