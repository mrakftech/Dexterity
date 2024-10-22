using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase733p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShotCourses",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ShotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShotCourses_Shots_ShotId",
                        column: x => x.ShotId,
                        principalSchema: "Setting",
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShotCourses_CourseId",
                schema: "Setting",
                table: "ShotCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotCourses_ShotId",
                schema: "Setting",
                table: "ShotCourses",
                column: "ShotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShotCourses",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Setting");
        }
    }
}
