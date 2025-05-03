using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase556P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugStandardScripts",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeAsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ScriptType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationDays = table.Column<int>(type: "int", nullable: false),
                    GenericOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Instruction1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardScriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugStandardScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugStandardScripts_StandardScripts_StandardScriptId",
                        column: x => x.StandardScriptId,
                        principalSchema: "Setting",
                        principalTable: "StandardScripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugStandardScripts_StandardScriptId",
                schema: "Setting",
                table: "DrugStandardScripts",
                column: "StandardScriptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugStandardScripts",
                schema: "Setting");
        }
    }
}
