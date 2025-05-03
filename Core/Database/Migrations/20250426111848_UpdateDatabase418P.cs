using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase418P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmFam",
                schema: "Setting",
                table: "Drugs",
                newName: "Strength");

            migrationBuilder.AddColumn<string>(
                name: "ATC1",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ATC2",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agent",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "Discount",
                schema: "Setting",
                table: "Drugs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DrugData",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FarmPrice",
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

            migrationBuilder.AddColumn<string>(
                name: "Ingredient1",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient2",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoicedCostPrice",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LastPrice",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStock",
                schema: "Setting",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PackSize",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackSizeMark",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackType",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackingClass",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductAuthority",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPrice",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VAT",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATC1",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ATC2",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Agent",
                schema: "Setting",
                table: "Drugs");

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
                name: "DrugData",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "FarmPrice",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Forms",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Ingredient1",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Ingredient2",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "InvoicedCostPrice",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "LastPrice",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "MinimumStock",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackSize",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackSizeMark",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackType",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackingClass",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ProductAuthority",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "RetailPrice",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "VAT",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.RenameColumn(
                name: "Strength",
                schema: "Setting",
                table: "Drugs",
                newName: "AmFam");
        }
    }
}
