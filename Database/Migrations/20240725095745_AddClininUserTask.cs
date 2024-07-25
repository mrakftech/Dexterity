using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClininUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedById",
                schema: "Messaging",
                table: "UserTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                schema: "Messaging",
                table: "UserTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AssignedById",
                schema: "Messaging",
                table: "UserTasks",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_ClinicId",
                schema: "Messaging",
                table: "UserTasks",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Clinics_ClinicId",
                schema: "Messaging",
                table: "UserTasks",
                column: "ClinicId",
                principalSchema: "Setting",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_AssignedById",
                schema: "Messaging",
                table: "UserTasks",
                column: "AssignedById",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Clinics_ClinicId",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_AssignedById",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_AssignedById",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_ClinicId",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "AssignedById",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                schema: "Messaging",
                table: "UserTasks");
        }
    }
}
