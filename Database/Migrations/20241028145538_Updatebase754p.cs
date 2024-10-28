using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Updatebase754p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "Side",
                schema: "Consultation",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReactionType",
                schema: "Consultation",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "Side",
                schema: "Consultation",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReactionType",
                schema: "Consultation",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId",
                unique: true);
        }
    }
}
