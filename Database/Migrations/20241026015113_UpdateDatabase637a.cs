using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase637a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationSetups_ImmunisationSetupId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.DropTable(
                name: "ImmunisationSetups",
                schema: "Setting");

            migrationBuilder.DropIndex(
                name: "IX_ImmunisationSchedule_ImmunisationSetupId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.DropColumn(
                name: "ImmunisationSetupId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.AddColumn<int>(
                name: "ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImmunisationPrograms",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false),
                    IsChildhood = table.Column<bool>(type: "bit", nullable: false),
                    AssignedCourses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunisationPrograms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId",
                principalSchema: "Setting",
                principalTable: "ImmunisationPrograms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.DropTable(
                name: "ImmunisationPrograms",
                schema: "Setting");

            migrationBuilder.DropIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.DropColumn(
                name: "ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule");

            migrationBuilder.AddColumn<int>(
                name: "ImmunisationSetupId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImmunisationSetups",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedCourses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsChildhood = table.Column<bool>(type: "bit", nullable: false),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunisationSetups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationSetupId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationSetupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunisationSchedule_ImmunisationSetups_ImmunisationSetupId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationSetupId",
                principalSchema: "Setting",
                principalTable: "ImmunisationSetups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
