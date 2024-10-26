using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase714a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedCoursesToSchedule",
                schema: "Setting");

            migrationBuilder.DropColumn(
                name: "AssignedCourses",
                schema: "Setting",
                table: "ImmunisationPrograms");

            migrationBuilder.CreateTable(
                name: "AssignedCourseToPrograms",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ImmunisationProgramId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedCourseToPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedCourseToPrograms_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedCourseToPrograms_ImmunisationPrograms_ImmunisationProgramId",
                        column: x => x.ImmunisationProgramId,
                        principalSchema: "Setting",
                        principalTable: "ImmunisationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedCourseToPrograms_CourseId",
                schema: "Setting",
                table: "AssignedCourseToPrograms",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedCourseToPrograms_ImmunisationProgramId",
                schema: "Setting",
                table: "AssignedCourseToPrograms",
                column: "ImmunisationProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedCourseToPrograms",
                schema: "Setting");

            migrationBuilder.AddColumn<string>(
                name: "AssignedCourses",
                schema: "Setting",
                table: "ImmunisationPrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssignedCoursesToSchedule",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ImmunisationProgramId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedCoursesToSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedCoursesToSchedule_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedCoursesToSchedule_ImmunisationPrograms_ImmunisationProgramId",
                        column: x => x.ImmunisationProgramId,
                        principalSchema: "Setting",
                        principalTable: "ImmunisationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedCoursesToSchedule_CourseId",
                schema: "Setting",
                table: "AssignedCoursesToSchedule",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedCoursesToSchedule_ImmunisationProgramId",
                schema: "Setting",
                table: "AssignedCoursesToSchedule",
                column: "ImmunisationProgramId");
        }
    }
}
