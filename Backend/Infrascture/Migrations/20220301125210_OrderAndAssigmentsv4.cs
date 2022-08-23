using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class OrderAndAssigmentsv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Orders_OrderId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_OrderId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Weapons");

            migrationBuilder.CreateTable(
                name: "OrderWeapon",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uuid", nullable: false),
                    WeaponsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWeapon", x => new { x.OrdersId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_OrderWeapon_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderWeapon_WeaponsId",
                table: "OrderWeapon",
                column: "WeaponsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderWeapon");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Weapons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_OrderId",
                table: "Weapons",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Orders_OrderId",
                table: "Weapons",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
