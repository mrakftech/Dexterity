using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFieldsInPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvocacyNeeds",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CauseOfDeath",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                schema: "PatientManagement",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEnrollment",
                schema: "PatientManagement",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DisRegistrationDate",
                schema: "PatientManagement",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DisRegistrationReason",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnrollmentStatus",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IhiNumber",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterpreterRequired",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ppsn",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredLanguage",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "PatientManagement",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportNeeds",
                schema: "PatientManagement",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NextKins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextKins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextKins_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PatientManagement",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientCarers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCarers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientCarers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PatientManagement",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NextKins_PatientId",
                table: "NextKins",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCarers_PatientId",
                table: "PatientCarers",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextKins");

            migrationBuilder.DropTable(
                name: "PatientCarers");

            migrationBuilder.DropColumn(
                name: "AdvocacyNeeds",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CauseOfDeath",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfEnrollment",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DisRegistrationDate",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DisRegistrationReason",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EnrollmentStatus",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Ethnicity",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IhiNumber",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InterpreterRequired",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Occupation",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Ppsn",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PreferredLanguage",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Religion",
                schema: "PatientManagement",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "TransportNeeds",
                schema: "PatientManagement",
                table: "Patients");
        }
    }
}
