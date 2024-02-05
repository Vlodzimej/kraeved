using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KraevedAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedGeoObjectType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "GeoObjects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrls",
                table: "GeoObjects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "GeoObjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GeoObjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoObjectType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeoObjects_TypeId",
                table: "GeoObjects",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoObjects_GeoObjectType_TypeId",
                table: "GeoObjects",
                column: "TypeId",
                principalTable: "GeoObjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoObjects_GeoObjectType_TypeId",
                table: "GeoObjects");

            migrationBuilder.DropTable(
                name: "GeoObjectType");

            migrationBuilder.DropIndex(
                name: "IX_GeoObjects_TypeId",
                table: "GeoObjects");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "GeoObjects");

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "GeoObjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrls",
                table: "GeoObjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
