using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase849p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LetterDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LetterTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Letters_LetterTemplates_LetterTemplateId",
                        column: x => x.LetterTemplateId,
                        principalSchema: "Setting",
                        principalTable: "LetterTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Letters_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Letters_HcpId",
                schema: "Consultation",
                table: "Letters",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_LetterTemplateId",
                schema: "Consultation",
                table: "Letters",
                column: "LetterTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letters",
                schema: "Consultation");
        }
    }
}
