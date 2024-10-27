using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpadateDatabase450p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                schema: "Consultation",
                table: "AdministerShots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDue",
                schema: "Consultation",
                table: "AdministerShots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGiven",
                schema: "Consultation",
                table: "AdministerShots",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                schema: "Consultation",
                table: "AdministerShots");

            migrationBuilder.DropColumn(
                name: "IsDue",
                schema: "Consultation",
                table: "AdministerShots");

            migrationBuilder.DropColumn(
                name: "IsGiven",
                schema: "Consultation",
                table: "AdministerShots");
        }
    }
}
