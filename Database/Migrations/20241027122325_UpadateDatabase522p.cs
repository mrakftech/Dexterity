using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpadateDatabase522p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId",
                principalSchema: "Setting",
                principalTable: "ImmunisationPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId",
                unique: true,
                filter: "[ImmunisationProgramId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId",
                principalSchema: "Setting",
                principalTable: "ImmunisationPrograms",
                principalColumn: "Id");
        }
    }
}
