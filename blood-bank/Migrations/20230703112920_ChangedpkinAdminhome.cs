using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class ChangedpkinAdminhome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminHomeDatas",
                table: "AdminHomeDatas");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AdminHomeDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "AdminHomeDatas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminHomeDatas",
                table: "AdminHomeDatas",
                column: "Count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminHomeDatas",
                table: "AdminHomeDatas");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "AdminHomeDatas");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AdminHomeDatas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminHomeDatas",
                table: "AdminHomeDatas",
                column: "UserId");
        }
    }
}
