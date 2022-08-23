using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class assignmentUdpate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Customers_CustomerId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_ShootingSpots_SpotId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_CustomerId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_SpotId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "Assignments");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Assignments",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assignments");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Assignments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpotId",
                table: "Assignments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CustomerId",
                table: "Assignments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SpotId",
                table: "Assignments",
                column: "SpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Customers_CustomerId",
                table: "Assignments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_ShootingSpots_SpotId",
                table: "Assignments",
                column: "SpotId",
                principalTable: "ShootingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
