using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientTransactions",
                schema: "PatientManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrinted = table.Column<bool>(type: "bit", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Debt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TakenById1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TakenByIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTransactions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PatientManagement",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTransactions_Users_TakenById1",
                        column: x => x.TakenById1,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientTransactions_Users_TakenByIdId",
                        column: x => x.TakenByIdId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_TakenById1",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenById1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_TakenByIdId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenByIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientTransactions",
                schema: "PatientManagement");
        }
    }
}
