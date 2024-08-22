using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransaction551 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "PatientManagement",
                table: "PatientTransactions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "PatientManagement",
                table: "PatientTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "PatientManagement",
                table: "PatientTransactions",
                type: "datetime2",
                nullable: true);
        }
    }
}
