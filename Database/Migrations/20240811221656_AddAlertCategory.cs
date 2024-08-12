using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAlertCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Servity",
                schema: "PatientManagement",
                table: "PatientAlerts",
                newName: "Severity");

            migrationBuilder.AddColumn<int>(
                name: "AlertCategoryId",
                schema: "PatientManagement",
                table: "PatientAlerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlertCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAlerts_AlertCategoryId",
                schema: "PatientManagement",
                table: "PatientAlerts",
                column: "AlertCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAlerts_AlertCategories_AlertCategoryId",
                schema: "PatientManagement",
                table: "PatientAlerts",
                column: "AlertCategoryId",
                principalTable: "AlertCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAlerts_AlertCategories_AlertCategoryId",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.DropTable(
                name: "AlertCategories");

            migrationBuilder.DropIndex(
                name: "IX_PatientAlerts_AlertCategoryId",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.DropColumn(
                name: "AlertCategoryId",
                schema: "PatientManagement",
                table: "PatientAlerts");

            migrationBuilder.RenameColumn(
                name: "Severity",
                schema: "PatientManagement",
                table: "PatientAlerts",
                newName: "Servity");
        }
    }
}
