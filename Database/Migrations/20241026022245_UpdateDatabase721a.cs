using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase721a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssigendShotToCourses",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ShotId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigendShotToCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssigendShotToCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigendShotToCourses_Shots_ShotId",
                        column: x => x.ShotId,
                        principalSchema: "Setting",
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigendShotToCourses_CourseId",
                schema: "Setting",
                table: "AssigendShotToCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssigendShotToCourses_ShotId",
                schema: "Setting",
                table: "AssigendShotToCourses",
                column: "ShotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigendShotToCourses",
                schema: "Setting");
        }
    }
}
