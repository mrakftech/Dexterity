using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Setting");

            migrationBuilder.EnsureSchema(
                name: "PatientManagement");

            migrationBuilder.EnsureSchema(
                name: "UserManagement");

            migrationBuilder.EnsureSchema(
                name: "Messaging");

            migrationBuilder.CreateTable(
                name: "Clinics",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "PatientManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ppsn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IhINumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsTemplates",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allowed = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "UserManagement",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mcn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUpdatePassword = table.Column<bool>(type: "bit", nullable: false),
                    IsForceReset = table.Column<bool>(type: "bit", nullable: false),
                    ResetPasswordAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "UserManagement",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersClinics",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersClinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersClinics_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersClinics_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagement",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagement",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                schema: "UserManagement",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClinicId",
                schema: "UserManagement",
                table: "Users",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "UserManagement",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersClinics_ClinicId",
                schema: "UserManagement",
                table: "UsersClinics",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersClinics_UserId",
                schema: "UserManagement",
                table: "UsersClinics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserId",
                schema: "Messaging",
                table: "UserTasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients",
                schema: "PatientManagement");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "SmsTemplates",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "UsersClinics",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "UserTasks",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "Clinics",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "UserManagement");
        }
    }
}
