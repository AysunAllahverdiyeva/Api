using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JawelryStore.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class MIG13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Imagess_ImagesId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ImagesId",
                table: "UserDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Imagess_ImagesId",
                table: "UserDetails",
                column: "ImagesId",
                principalTable: "Imagess",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Imagess_ImagesId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ImagesId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Imagess_ImagesId",
                table: "UserDetails",
                column: "ImagesId",
                principalTable: "Imagess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
