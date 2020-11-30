using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeBlend.Data.Migrations
{
    public partial class AddRequstColumnToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Request",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Request",
                table: "Products");
        }
    }
}
