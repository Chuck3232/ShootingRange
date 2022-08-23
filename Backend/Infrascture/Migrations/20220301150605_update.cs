using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Ammunitions_AmmunitionId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "AmmunitionId",
                table: "Assignments",
                newName: "AmmoOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_AmmunitionId",
                table: "Assignments",
                newName: "IX_Assignments_AmmoOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AmmoOrders_AmmoOrderId",
                table: "Assignments",
                column: "AmmoOrderId",
                principalTable: "AmmoOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AmmoOrders_AmmoOrderId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "AmmoOrderId",
                table: "Assignments",
                newName: "AmmunitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_AmmoOrderId",
                table: "Assignments",
                newName: "IX_Assignments_AmmunitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Ammunitions_AmmunitionId",
                table: "Assignments",
                column: "AmmunitionId",
                principalTable: "Ammunitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
