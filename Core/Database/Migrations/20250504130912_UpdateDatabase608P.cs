using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase608P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Users_AddedById",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AddedById",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "AddedById",
                schema: "Consultation",
                table: "Prescriptions",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Consultation",
                table: "Prescriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Consultation",
                table: "Prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "Consultation",
                table: "Prescriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Consultation",
                table: "Prescriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Setting",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                schema: "Setting",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Setting",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Consultation",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "Consultation",
                table: "Prescriptions",
                newName: "AddedById");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Setting",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                schema: "Setting",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Setting",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
