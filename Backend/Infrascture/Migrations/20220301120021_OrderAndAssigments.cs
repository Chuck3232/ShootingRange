using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class OrderAndAssigments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOrders_Ammunitions_AmmoOrderId",
                table: "AmmoOrders");

            migrationBuilder.DropIndex(
                name: "IX_AmmoOrders_AmmoOrderId",
                table: "AmmoOrders");

            migrationBuilder.RenameColumn(
                name: "AmmoOrderId",
                table: "AmmoOrders",
                newName: "AmmunitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AmmoOrders_AmmunitionId",
                table: "AmmoOrders",
                column: "AmmunitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOrders_Ammunitions_AmmunitionId",
                table: "AmmoOrders",
                column: "AmmunitionId",
                principalTable: "Ammunitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOrders_Ammunitions_AmmunitionId",
                table: "AmmoOrders");

            migrationBuilder.DropIndex(
                name: "IX_AmmoOrders_AmmunitionId",
                table: "AmmoOrders");

            migrationBuilder.RenameColumn(
                name: "AmmunitionId",
                table: "AmmoOrders",
                newName: "AmmoOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AmmoOrders_AmmoOrderId",
                table: "AmmoOrders",
                column: "AmmoOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOrders_Ammunitions_AmmoOrderId",
                table: "AmmoOrders",
                column: "AmmoOrderId",
                principalTable: "Ammunitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
