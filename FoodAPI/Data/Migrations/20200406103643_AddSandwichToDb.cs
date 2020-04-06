using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodAPI.Migrations
{
    public partial class AddSandwichToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sandwitches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    SandwichName = table.Column<string>(nullable: false),
                    Ingredient = table.Column<string>(maxLength: 200, nullable: false),
                    Allergen = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandwitches", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sandwitches");
        }
    }
}
