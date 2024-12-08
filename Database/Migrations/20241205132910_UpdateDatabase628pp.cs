using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase628pp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "Setting",
                table: "Sketches");

            migrationBuilder.AddColumn<Guid>(
                name: "SketchCategoryId",
                schema: "Setting",
                table: "Sketches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sketches_SketchCategoryId",
                schema: "Setting",
                table: "Sketches",
                column: "SketchCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sketches_SketchCategories_SketchCategoryId",
                schema: "Setting",
                table: "Sketches",
                column: "SketchCategoryId",
                principalSchema: "Setting",
                principalTable: "SketchCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sketches_SketchCategories_SketchCategoryId",
                schema: "Setting",
                table: "Sketches");

            migrationBuilder.DropIndex(
                name: "IX_Sketches_SketchCategoryId",
                schema: "Setting",
                table: "Sketches");

            migrationBuilder.DropColumn(
                name: "SketchCategoryId",
                schema: "Setting",
                table: "Sketches");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "Setting",
                table: "Sketches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
