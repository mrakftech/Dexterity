using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddHCPInAppt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HcpId",
                schema: "Scheduler",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HcpId",
                schema: "Scheduler",
                table: "Appointments",
                column: "HcpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_HcpId",
                schema: "Scheduler",
                table: "Appointments",
                column: "HcpId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_HcpId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_HcpId",
                schema: "Scheduler",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "HcpId",
                schema: "Scheduler",
                table: "Appointments");
        }
    }
}
