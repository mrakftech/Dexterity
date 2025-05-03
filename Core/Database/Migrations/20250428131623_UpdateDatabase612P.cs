using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase612P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrugId",
                schema: "Setting",
                table: "DrugStandardScripts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DrugStandardScripts_DrugId",
                schema: "Setting",
                table: "DrugStandardScripts",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugStandardScripts_Drugs_DrugId",
                schema: "Setting",
                table: "DrugStandardScripts",
                column: "DrugId",
                principalSchema: "Setting",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugStandardScripts_Drugs_DrugId",
                schema: "Setting",
                table: "DrugStandardScripts");

            migrationBuilder.DropIndex(
                name: "IX_DrugStandardScripts_DrugId",
                schema: "Setting",
                table: "DrugStandardScripts");

            migrationBuilder.DropColumn(
                name: "DrugId",
                schema: "Setting",
                table: "DrugStandardScripts");
        }
    }
}
