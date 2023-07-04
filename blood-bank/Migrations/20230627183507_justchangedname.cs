using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class justchangedname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "EventDescs",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "EventDescs",
                newName: "status");
        }
    }
}
