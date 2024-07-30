using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicSites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                schema: "Setting",
                table: "Clinics",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "ClinicSites",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicSites_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSites_ClinicId",
                schema: "Setting",
                table: "ClinicSites",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicSites",
                schema: "Setting");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "Setting",
                table: "Clinics",
                newName: "Branch");
        }
    }
}
