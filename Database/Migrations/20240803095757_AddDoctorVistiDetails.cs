using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorVistiDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorVisitCards",
                schema: "PatientManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DvNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvReviewNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvDistanceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorVisitCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorVisitCards_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PatientManagement",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisitCards_PatientId",
                schema: "PatientManagement",
                table: "DoctorVisitCards",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorVisitCards",
                schema: "PatientManagement");
        }
    }
}
