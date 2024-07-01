using KraevedAPI.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KraevedAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserRolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles", 
                columns: ["Id", "Name"], 
                values: [ServiceConstants.Roles.Unknown.Id, ServiceConstants.Roles.Unknown.Name]);
            migrationBuilder.InsertData(
                table: "Roles", 
                columns: ["Id", "Name"], 
                values: [ServiceConstants.Roles.Admin.Id, ServiceConstants.Roles.Admin.Name]);
            migrationBuilder.InsertData(
                table: "Roles", 
                columns: ["Id", "Name"], 
                values: [ServiceConstants.Roles.User.Id, ServiceConstants.Roles.User.Name]);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: ServiceConstants.Roles.Unknown.Id);
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: ServiceConstants.Roles.Admin.Id);
            migrationBuilder.DeleteData(
                table: "Roles", 
                keyColumn: "Id",
                keyValue: ServiceConstants.Roles.User.Id);
        }
        
    }
}
