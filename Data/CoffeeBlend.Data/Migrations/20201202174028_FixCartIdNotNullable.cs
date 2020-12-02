using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeBlend.Data.Migrations
{
    public partial class FixCartIdNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "CartProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "CartProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
