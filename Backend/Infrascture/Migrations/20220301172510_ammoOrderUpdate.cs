using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class ammoOrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOrders_Orders_OrderId",
                table: "AmmoOrders");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "AmmoOrders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOrders_Orders_OrderId",
                table: "AmmoOrders",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "AmmoOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOrders_Orders_OrderId",
                table: "AmmoOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
