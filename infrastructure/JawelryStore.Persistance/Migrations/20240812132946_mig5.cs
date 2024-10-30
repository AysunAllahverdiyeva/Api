using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JawelryStore.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date_Of_Base",
                table: "UserDetails",
                newName: "Date_Of_Birth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date_Of_Birth",
                table: "UserDetails",
                newName: "Date_Of_Base");
        }
    }
}
