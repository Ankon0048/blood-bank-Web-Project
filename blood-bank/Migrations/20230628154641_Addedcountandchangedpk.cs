﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class Addedcountandchangedpk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportDatas",
                table: "ReportDatas");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReportDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "ReportDatas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportDatas",
                table: "ReportDatas",
                column: "count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportDatas",
                table: "ReportDatas");

            migrationBuilder.DropColumn(
                name: "count",
                table: "ReportDatas");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReportDatas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportDatas",
                table: "ReportDatas",
                column: "UserId");
        }
    }
}
