using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeBlend.Data.Migrations
{
    public partial class UserOrderHistoryIdToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserOrderHistoryId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserOrderHistoryId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
