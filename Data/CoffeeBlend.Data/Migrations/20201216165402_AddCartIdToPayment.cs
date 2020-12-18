namespace CoffeeBlend.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddCartIdToPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CartId",
                table: "Payments",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Carts_CartId",
                table: "Payments",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Carts_CartId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CartId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Payments");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
