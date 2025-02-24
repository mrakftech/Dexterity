using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase101A : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBlocked",
                schema: "Identity",
                table: "Users",
                newName: "IsLockOut");

            migrationBuilder.AddColumn<int>(
                name: "FailedAttempted",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedAttempted",
                schema: "Identity",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IsLockOut",
                schema: "Identity",
                table: "Users",
                newName: "IsBlocked");
        }
    }
}
