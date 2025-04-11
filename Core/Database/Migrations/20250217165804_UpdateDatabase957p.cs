using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase957p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                schema: "Identity",
                table: "Users",
                newName: "TelePhone");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address4",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BordAltranaisNumber",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaxNo",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GsmNumber",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedCouncilNumber",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address2",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address3",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address4",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BordAltranaisNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FaxNo",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GsmNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MedCouncilNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TelePhone",
                schema: "Identity",
                table: "Users",
                newName: "Phone");
        }
    }
}
