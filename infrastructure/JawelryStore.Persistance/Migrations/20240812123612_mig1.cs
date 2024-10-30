using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JawelryStore.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Userss");

            migrationBuilder.DropColumn(
                name: "Created_Id",
                table: "Userss");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Userss");

            migrationBuilder.DropColumn(
                name: "Updeted_Id",
                table: "Userss");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Created_Id",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Updeted_Id",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Created_Id",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Updeted_Id",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Userss",
                newName: "PasswordSalt");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Userss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Userss");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Userss",
                newName: "Password");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Userss",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Created_Id",
                table: "Userss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Userss",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Updeted_Id",
                table: "Userss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "UserDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Created_Id",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "UserDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Updeted_Id",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Created_Id",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Updeted_Id",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
