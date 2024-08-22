using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTransDetial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientTransactionDetails",
                schema: "PatientManagement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientTransactionDetails",
                schema: "PatientManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientTransactionId = table.Column<int>(type: "int", nullable: false),
                    ChargedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTransactionDetails_PatientTransactions_PatientTransactionId",
                        column: x => x.PatientTransactionId,
                        principalSchema: "PatientManagement",
                        principalTable: "PatientTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactionDetails_PatientTransactionId",
                schema: "PatientManagement",
                table: "PatientTransactionDetails",
                column: "PatientTransactionId");
        }
    }
}
