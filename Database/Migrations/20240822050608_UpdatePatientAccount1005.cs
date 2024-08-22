using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientAccount1005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_Users_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PatientTransactions_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenById");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_Users_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenById",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
