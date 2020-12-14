using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeBlend.Data.Migrations
{
    public partial class PriceToCartProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartProducts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartProducts");
        }
    }
}
