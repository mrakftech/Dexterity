using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase350P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agent",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Atc1",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Atc2",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ColourCode",
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
                name: "Dentist",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "DrugCats",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "FarmChange",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Form",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Forms",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "GasCharge",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Ingrd1",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Ingrd2",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "IngredientCostPrice",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "MaxRrp",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "MinimumStock",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "NoteAutUse",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackSize",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackSizeName",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PackSizeUnits",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PoisonClass",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ProductAuthortext",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Strength",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "UomSize",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Vat",
                schema: "Setting",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Warnings",
                schema: "Setting",
                table: "Drugs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agent",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atc1",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atc2",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColourCode",
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
                name: "Dentist",
                schema: "Setting",
                table: "Drugs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DrugCats",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FarmChange",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Form",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Forms",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GasCharge",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingrd1",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingrd2",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IngredientCostPrice",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxRrp",
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
                name: "NoteAutUse",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackSize",
                schema: "Setting",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PackSizeName",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackSizeUnits",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoisonClass",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductAuthortext",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Strength",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UomSize",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Vat",
                schema: "Setting",
                table: "Drugs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Warnings",
                schema: "Setting",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
