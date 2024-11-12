using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase748p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedInvestigationGroups_InvestigationTemplates_InvestigationTemplateId",
                schema: "Setting",
                table: "AssignedInvestigationGroups");

            migrationBuilder.DropTable(
                name: "InvestigationTemplateDetails",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "InvestigationTemplates",
                schema: "Setting");

            migrationBuilder.RenameColumn(
                name: "InvestigationTemplateId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                newName: "InvestigationId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedInvestigationGroups_InvestigationTemplateId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                newName: "IX_AssignedInvestigationGroups_InvestigationId");

            migrationBuilder.CreateTable(
                name: "Investigations",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationDetails",
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
                    InvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationSelectionListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationDetails_InvestigationSelectionList_InvestigationSelectionListId",
                        column: x => x.InvestigationSelectionListId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationSelectionList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestigationDetails_Investigations_InvestigationId",
                        column: x => x.InvestigationId,
                        principalSchema: "Setting",
                        principalTable: "Investigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationDetails_InvestigationId",
                schema: "Setting",
                table: "InvestigationDetails",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationDetails_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationDetails",
                column: "InvestigationSelectionListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedInvestigationGroups_Investigations_InvestigationId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                column: "InvestigationId",
                principalSchema: "Setting",
                principalTable: "Investigations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedInvestigationGroups_Investigations_InvestigationId",
                schema: "Setting",
                table: "AssignedInvestigationGroups");

            migrationBuilder.DropTable(
                name: "InvestigationDetails",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Investigations",
                schema: "Setting");

            migrationBuilder.RenameColumn(
                name: "InvestigationId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                newName: "InvestigationTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedInvestigationGroups_InvestigationId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                newName: "IX_AssignedInvestigationGroups_InvestigationTemplateId");

            migrationBuilder.CreateTable(
                name: "InvestigationTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationTemplateDetails",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationSelectionListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvestigationTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbsoluteMaximum = table.Column<double>(type: "float", nullable: false),
                    AbsoluteMinimum = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMaindatory = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalMaximum = table.Column<double>(type: "float", nullable: false),
                    NormalMinimum = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationTemplateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationTemplateDetails_InvestigationSelectionList_InvestigationSelectionListId",
                        column: x => x.InvestigationSelectionListId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationSelectionList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestigationTemplateDetails_InvestigationTemplates_InvestigationTemplateId",
                        column: x => x.InvestigationTemplateId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationTemplateDetails_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails",
                column: "InvestigationSelectionListId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationTemplateDetails_InvestigationTemplateId",
                schema: "Setting",
                table: "InvestigationTemplateDetails",
                column: "InvestigationTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedInvestigationGroups_InvestigationTemplates_InvestigationTemplateId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                column: "InvestigationTemplateId",
                principalSchema: "Setting",
                principalTable: "InvestigationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
