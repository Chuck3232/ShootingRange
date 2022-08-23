using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class weapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "Weapons");

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Weapons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "QuantityInStock",
                table: "Weapons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
