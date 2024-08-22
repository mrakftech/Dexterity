using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientAccountNewWay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PatientTransactions_PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "Balance",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "Credit",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.RenameColumn(
                name: "Debt",
                schema: "PatientManagement",
                table: "PatientTransactions",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "PatientAccountId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PatientAccounts",
                schema: "PatientManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAccounts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PatientManagement",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_PatientAccountId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "PatientAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PatientId",
                schema: "PatientManagement",
                table: "PatientAccounts",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_PatientAccounts_PatientAccountId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "PatientAccountId",
                principalSchema: "PatientManagement",
                principalTable: "PatientAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_PatientAccounts_PatientAccountId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropTable(
                name: "PatientAccounts",
                schema: "PatientManagement");

            migrationBuilder.DropIndex(
                name: "IX_PatientTransactions_PatientAccountId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "PatientAccountId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "PatientManagement",
                table: "PatientTransactions",
                newName: "Debt");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_Patients_PatientId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "PatientId",
                principalSchema: "PatientManagement",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
