using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KraevedAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedGeoObjectType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoObjects_GeoObjectType_TypeId",
                table: "GeoObjects");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "GeoObjects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoObjects_GeoObjectType_TypeId",
                table: "GeoObjects",
                column: "TypeId",
                principalTable: "GeoObjectType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoObjects_GeoObjectType_TypeId",
                table: "GeoObjects");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "GeoObjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeoObjects_GeoObjectType_TypeId",
                table: "GeoObjects",
                column: "TypeId",
                principalTable: "GeoObjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
