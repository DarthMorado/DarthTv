using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarthTV.Migrations
{
    /// <inheritdoc />
    public partial class v012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Languages",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Genres",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "Value");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RuntimeMinutes",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Released",
                table: "Items",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Languages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Genres",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Countries",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RuntimeMinutes",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Released",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
