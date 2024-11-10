using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase84a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigationSelectionList_InvestigationTemplateDetails_InvestigationTemplateDetailId",
                schema: "Setting",
                table: "InvestigationSelectionList");

            migrationBuilder.DropIndex(
                name: "IX_InvestigationSelectionList_InvestigationTemplateDetailId",
                schema: "Setting",
                table: "InvestigationSelectionList");

            migrationBuilder.DropColumn(
                name: "InvestigationTemplateDetailId",
                schema: "Setting",
                table: "InvestigationSelectionList");

            migrationBuilder.AddColumn<Guid>(
                name: "InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationTemplateDetails_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails",
                column: "InvestigationSelectionListId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigationTemplateDetails_InvestigationSelectionList_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails",
                column: "InvestigationSelectionListId",
                principalSchema: "Setting",
                principalTable: "InvestigationSelectionList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigationTemplateDetails_InvestigationSelectionList_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvestigationTemplateDetails_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails");

            migrationBuilder.DropColumn(
                name: "InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationTemplateDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "InvestigationTemplateDetailId",
                schema: "Setting",
                table: "InvestigationSelectionList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationSelectionList_InvestigationTemplateDetailId",
                schema: "Setting",
                table: "InvestigationSelectionList",
                column: "InvestigationTemplateDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigationSelectionList_InvestigationTemplateDetails_InvestigationTemplateDetailId",
                schema: "Setting",
                table: "InvestigationSelectionList",
                column: "InvestigationTemplateDetailId",
                principalSchema: "Setting",
                principalTable: "InvestigationTemplateDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
