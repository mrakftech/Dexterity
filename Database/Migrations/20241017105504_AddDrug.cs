using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDrug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Consultation",
                table: "Shots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Drugs",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmFam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackSize = table.Column<int>(type: "int", nullable: false),
                    PackSizeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackSizeUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteAutUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxRrp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GasCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoisonClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAuthortext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UomSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugCats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warnings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingrd1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingrd2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atc1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dentist = table.Column<bool>(type: "bit", nullable: false),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs",
                schema: "Setting");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Consultation",
                table: "Shots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
