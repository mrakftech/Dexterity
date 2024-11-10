using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase756a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "InvestigationSelectionList",
                newName: "InvestigationSelectionList",
                newSchema: "Setting");

            migrationBuilder.CreateTable(
                name: "InvestigationSelectionValues",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationSelectionListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationSelectionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationSelectionValues_InvestigationSelectionList_InvestigationSelectionListId",
                        column: x => x.InvestigationSelectionListId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationSelectionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationSelectionValues_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationSelectionValues",
                column: "InvestigationSelectionListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigationSelectionValues",
                schema: "Setting");

            migrationBuilder.RenameTable(
                name: "InvestigationSelectionList",
                schema: "Setting",
                newName: "InvestigationSelectionList");
        }
    }
}
