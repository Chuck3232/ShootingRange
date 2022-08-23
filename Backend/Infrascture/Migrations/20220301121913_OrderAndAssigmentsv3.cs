using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class OrderAndAssigmentsv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOrders_Orders_AmmoOrdersId",
                table: "AmmoOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Orders_WeaponsId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "WeaponsId",
                table: "Weapons",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_WeaponsId",
                table: "Weapons",
                newName: "IX_Weapons_OrderId");

            migrationBuilder.RenameColumn(
                name: "AmmoOrdersId",
                table: "AmmoOrders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AmmoOrders_AmmoOrdersId",
                table: "AmmoOrders",
                newName: "IX_AmmoOrders_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOrders_Orders_OrderId",
                table: "AmmoOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Orders_OrderId",
                table: "Weapons",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOrders_Orders_OrderId",
                table: "AmmoOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Orders_OrderId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Weapons",
                newName: "WeaponsId");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_OrderId",
                table: "Weapons",
                newName: "IX_Weapons_WeaponsId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "AmmoOrders",
                newName: "AmmoOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_AmmoOrders_OrderId",
                table: "AmmoOrders",
                newName: "IX_AmmoOrders_AmmoOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOrders_Orders_AmmoOrdersId",
                table: "AmmoOrders",
                column: "AmmoOrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Orders_WeaponsId",
                table: "Weapons",
                column: "WeaponsId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
