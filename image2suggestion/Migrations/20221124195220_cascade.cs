using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace image2suggestion.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Suggestion_SuggestionID",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Suggestion_SuggestionID",
                table: "Photo",
                column: "SuggestionID",
                principalTable: "Suggestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Suggestion_SuggestionID",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Suggestion_SuggestionID",
                table: "Photo",
                column: "SuggestionID",
                principalTable: "Suggestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
