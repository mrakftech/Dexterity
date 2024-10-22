using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase221p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImmunisationSetups",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunisationSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseSchedules",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ImmunisationSetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_ImmunisationSetups_ImmunisationSetupId",
                        column: x => x.ImmunisationSetupId,
                        principalSchema: "Setting",
                        principalTable: "ImmunisationSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_CourseId",
                schema: "Setting",
                table: "CourseSchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_ImmunisationSetupId",
                schema: "Setting",
                table: "CourseSchedules",
                column: "ImmunisationSetupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedules",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "ImmunisationSetups",
                schema: "Setting");
        }
    }
}
