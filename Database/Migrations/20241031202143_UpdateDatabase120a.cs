using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase120a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddedById",
                schema: "Consultation",
                table: "Prescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AddedById",
                schema: "Consultation",
                table: "Prescriptions",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Users_AddedById",
                schema: "Consultation",
                table: "Prescriptions",
                column: "AddedById",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Users_AddedById",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AddedById",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "AddedById",
                schema: "Consultation",
                table: "Prescriptions");
        }
    }
}
