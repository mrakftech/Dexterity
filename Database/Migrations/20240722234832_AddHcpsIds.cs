using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddHcpsIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HcpIds",
                schema: "Messaging",
                table: "UserTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                schema: "Messaging",
                table: "UserTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HcpIds",
                schema: "Messaging",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                schema: "Messaging",
                table: "UserTasks");
        }
    }
}
