using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase329P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompositionCode",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostChange",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FarmChange",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Forms",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStock",
                schema: "Setting",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompositionCode",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "CostChange",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "FarmChange",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Forms",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "MinimumStock",
                schema: "Setting",
                table: "Drugs");
        }
    }
}
