using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase253a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestigationTemplateDetails",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMaindatory = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbsoluteMinimum = table.Column<double>(type: "float", nullable: false),
                    AbsoluteMaximum = table.Column<double>(type: "float", nullable: false),
                    NormalMinimum = table.Column<double>(type: "float", nullable: false),
                    NormalMaximum = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationTemplateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationTemplateDetails_InvestigationTemplates_InvestigationTemplateId",
                        column: x => x.InvestigationTemplateId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationTemplateDetails_InvestigationTemplateId",
                schema: "Setting",
                table: "InvestigationTemplateDetails",
                column: "InvestigationTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigationTemplateDetails",
                schema: "Setting");
        }
    }
}
