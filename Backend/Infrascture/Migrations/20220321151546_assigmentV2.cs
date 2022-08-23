using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class assigmentV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Weapons_WeaponId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "OrderWeapon");

            migrationBuilder.RenameColumn(
                name: "WeaponId",
                table: "Assignments",
                newName: "WeaponOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_WeaponId",
                table: "Assignments",
                newName: "IX_Assignments_WeaponOrderId");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Assignments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeaponOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WeaponId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponOrder_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponOrder_OrderId",
                table: "WeaponOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponOrder_WeaponId",
                table: "WeaponOrder",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_WeaponOrder_WeaponOrderId",
                table: "Assignments",
                column: "WeaponOrderId",
                principalTable: "WeaponOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_WeaponOrder_WeaponOrderId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "WeaponOrder");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "WeaponOrderId",
                table: "Assignments",
                newName: "WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_WeaponOrderId",
                table: "Assignments",
                newName: "IX_Assignments_WeaponId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Weapons_WeaponId",
                table: "Assignments",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
