using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace image2suggestion.Migrations
{
    public partial class conto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "Photo",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
