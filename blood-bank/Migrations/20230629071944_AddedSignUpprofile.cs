using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class AddedSignUpprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Userprofiles",
                table: "Userprofiles");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Userprofiles");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Userprofiles",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Userprofiles",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Userprofiles",
                newName: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Userprofiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NID",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userprofiles",
                table: "Userprofiles",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Userprofiles",
                table: "Userprofiles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Userprofiles");

            migrationBuilder.DropColumn(
                name: "NID",
                table: "Userprofiles");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Userprofiles");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Userprofiles",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Userprofiles",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Userprofiles",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Userprofiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userprofiles",
                table: "Userprofiles",
                column: "Username");
        }
    }
}
