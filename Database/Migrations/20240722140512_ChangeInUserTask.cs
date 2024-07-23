using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_PatientId",
                schema: "Messaging",
                table: "UserTasks",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Patients_PatientId",
                schema: "Messaging",
                table: "UserTasks",
                column: "PatientId",
                principalSchema: "PatientManagement",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Patients_PatientId",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_PatientId",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Messaging",
                table: "UserTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
