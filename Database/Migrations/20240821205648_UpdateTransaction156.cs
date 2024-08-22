using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransaction156 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_Users_TakenById1",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientTransactions_Users_TakenByIdId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PatientTransactions_TakenById1",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PatientTransactions_TakenByIdId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "TakenById1",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "TakenByIdId",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.AddColumn<Guid>(
                name: "TakenById",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "TakenById1",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TakenByIdId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_Users_TakenById1",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenById1",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTransactions_Users_TakenByIdId",
                schema: "PatientManagement",
                table: "PatientTransactions",
                column: "TakenByIdId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
