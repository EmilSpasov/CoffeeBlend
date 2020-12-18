namespace CoffeeBlend.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddTotalPriceToPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Payments");
        }
    }
}
