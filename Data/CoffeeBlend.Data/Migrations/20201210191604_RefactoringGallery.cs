namespace CoffeeBlend.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RefactoringGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GalleryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Galleries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_ImageId",
                table: "Galleries",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Images_ImageId",
                table: "Galleries",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Images_ImageId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_ImageId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Galleries");

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_GalleryId",
                table: "Images",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
