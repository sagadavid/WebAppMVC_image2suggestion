using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace image2suggestion.Data.Migrations
{
    public partial class imagepositiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Photo",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
