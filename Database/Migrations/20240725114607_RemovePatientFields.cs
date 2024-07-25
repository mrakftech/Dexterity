using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemovePatientFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IhINumber",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientStatus",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientType",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Ppsn",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UniqueNumber",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "PatientManagement",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyName",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                schema: "PatientManagement",
                table: "Patients",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IhINumber",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientStatus",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientType",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ppsn",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueNumber",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
