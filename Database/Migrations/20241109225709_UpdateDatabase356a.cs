using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase356a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Setting",
                table: "InvestigationGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AssignedInvestigationGroups",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedInvestigationGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedInvestigationGroups_InvestigationGroups_InvestigationGroupId",
                        column: x => x.InvestigationGroupId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedInvestigationGroups_InvestigationTemplates_InvestigationTemplateId",
                        column: x => x.InvestigationTemplateId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInvestigationGroups_InvestigationGroupId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                column: "InvestigationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInvestigationGroups_InvestigationTemplateId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                column: "InvestigationTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedInvestigationGroups",
                schema: "Setting");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Setting",
                table: "InvestigationGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
