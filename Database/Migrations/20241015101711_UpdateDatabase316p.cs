using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase316p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShotBatchDetails",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchDetailId = table.Column<int>(type: "int", nullable: false),
                    ShotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotBatchDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotBatchDetails_BatchDetails_BatchDetailId",
                        column: x => x.BatchDetailId,
                        principalSchema: "Consultation",
                        principalTable: "BatchDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShotBatchDetails_Shots_ShotId",
                        column: x => x.ShotId,
                        principalSchema: "Consultation",
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShotBatchDetails_BatchDetailId",
                schema: "Consultation",
                table: "ShotBatchDetails",
                column: "BatchDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotBatchDetails_ShotId",
                schema: "Consultation",
                table: "ShotBatchDetails",
                column: "ShotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShotBatchDetails",
                schema: "Consultation");
        }
    }
}
