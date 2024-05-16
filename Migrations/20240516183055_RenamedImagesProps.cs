using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KraevedAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenamedImagesProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "HistoricalEvents",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "HistoricalEvents",
                newName: "Images");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "GeoObjects",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "GeoObjects",
                newName: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "HistoricalEvents",
                newName: "ThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "HistoricalEvents",
                newName: "ImageUrls");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "GeoObjects",
                newName: "ThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "GeoObjects",
                newName: "ImageUrls");
        }
    }
}
