using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "UsersClinics",
                schema: "UserManagement",
                newName: "UsersClinics",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "UserManagement",
                newName: "Users",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "SmsTemplates",
                schema: "Messaging",
                newName: "SmsTemplates",
                newSchema: "Setting");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "UserManagement",
                newName: "Roles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "UserManagement",
                newName: "Permissions",
                newSchema: "Identity");

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates",
                schema: "Setting");

            migrationBuilder.EnsureSchema(
                name: "UserManagement");

            migrationBuilder.RenameTable(
                name: "UsersClinics",
                schema: "Identity",
                newName: "UsersClinics",
                newSchema: "UserManagement");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Identity",
                newName: "Users",
                newSchema: "UserManagement");

            migrationBuilder.RenameTable(
                name: "SmsTemplates",
                schema: "Setting",
                newName: "SmsTemplates",
                newSchema: "Messaging");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Identity",
                newName: "Roles",
                newSchema: "UserManagement");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "Identity",
                newName: "Permissions",
                newSchema: "UserManagement");
        }
    }
}
