using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase744a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestigationSelectionList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationTemplateDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationSelectionList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationSelectionList_InvestigationTemplateDetails_InvestigationTemplateDetailId",
                        column: x => x.InvestigationTemplateDetailId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationTemplateDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationSelectionList_InvestigationTemplateDetailId",
                table: "InvestigationSelectionList",
                column: "InvestigationTemplateDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigationSelectionList");
        }
    }
}
