using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHcpsFromUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HcpIds",
                schema: "Messaging",
                table: "UserTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HcpIds",
                schema: "Messaging",
                table: "UserTasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
