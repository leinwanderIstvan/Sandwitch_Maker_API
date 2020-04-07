using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodAPI.Migrations
{
    public partial class AddNewSandwitchToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergen",
                table: "Sandwitches");

            migrationBuilder.DropColumn(
                name: "Ingredient",
                table: "Sandwitches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Allergen",
                table: "Sandwitches",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredient",
                table: "Sandwitches",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
