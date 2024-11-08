 using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase3221a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbsoluteMaximum",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "AbsoluteMinimum",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "FieldType",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "IsMaindatory",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "NormalMaximum",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "NormalMinimum",
                schema: "Setting",
                table: "InvestigationTemplates");

            migrationBuilder.DropColumn(
                name: "Unit",
                schema: "Setting",
                table: "InvestigationTemplates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AbsoluteMaximum",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AbsoluteMinimum",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaindatory",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "NormalMaximum",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NormalMinimum",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                schema: "Setting",
                table: "InvestigationTemplates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
