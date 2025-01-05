using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Data.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Apartments");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Apartments",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
