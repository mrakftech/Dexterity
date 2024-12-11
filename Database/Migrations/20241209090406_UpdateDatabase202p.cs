using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase202p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Setting",
                table: "FormTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PatientCustomForms",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCustomForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientCustomForms_FormTemplates_FormTemplateId",
                        column: x => x.FormTemplateId,
                        principalSchema: "Setting",
                        principalTable: "FormTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientCustomForms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientCustomForms_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientCustomForms_FormTemplateId",
                schema: "Consultation",
                table: "PatientCustomForms",
                column: "FormTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCustomForms_HcpId",
                schema: "Consultation",
                table: "PatientCustomForms",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCustomForms_PatientId",
                schema: "Consultation",
                table: "PatientCustomForms",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientCustomForms",
                schema: "Consultation");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Setting",
                table: "FormTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
