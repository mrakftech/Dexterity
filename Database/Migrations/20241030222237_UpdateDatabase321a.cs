using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase321a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescriptions",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericOnly = table.Column<bool>(type: "bit", nullable: false),
                    Instruction1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initiated = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsInReview = table.Column<bool>(type: "bit", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalSchema: "Setting",
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DrugId",
                schema: "Consultation",
                table: "Prescriptions",
                column: "DrugId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions",
                schema: "Consultation");
        }
    }
}
