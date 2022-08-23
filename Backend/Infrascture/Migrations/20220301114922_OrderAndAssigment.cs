using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class OrderAndAssigment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Weapons",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "AmmoOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    SpotId = table.Column<Guid>(type: "uuid", nullable: true),
                    TrainigHours = table.Column<int>(type: "integer", nullable: false),
                    IsInstructor = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_ShootingSpots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "ShootingSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    SpotId = table.Column<Guid>(type: "uuid", nullable: true),
                    WeaponId = table.Column<Guid>(type: "uuid", nullable: true),
                    AmmunitionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Instuctor = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Ammunitions_AmmunitionId",
                        column: x => x.AmmunitionId,
                        principalTable: "Ammunitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_ShootingSpots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "ShootingSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_OrderId",
                table: "Weapons",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AmmoOrders_OrderId",
                table: "AmmoOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AmmunitionId",
                table: "Assignments",
                column: "AmmunitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CustomerId",
                table: "Assignments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_OrderId",
                table: "Assignments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SpotId",
                table: "Assignments",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_WeaponId",
                table: "Assignments",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SpotId",
                table: "Orders",
                column: "SpotId");

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

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_OrderId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_AmmoOrders_OrderId",
                table: "AmmoOrders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "AmmoOrders");
        }
    }
}
