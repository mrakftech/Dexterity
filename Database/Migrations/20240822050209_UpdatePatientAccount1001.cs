using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientAccount1001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_Users_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_Users_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenById",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_Users_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_Users_TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenById",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
