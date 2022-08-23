using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrascture.Migrations
{
    public partial class entryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "EntryRecords",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_EntryRecords_CustomerId",
                table: "EntryRecords",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryRecords_Customers_CustomerId",
                table: "EntryRecords",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryRecords_Customers_CustomerId",
                table: "EntryRecords");

            migrationBuilder.DropIndex(
                name: "IX_EntryRecords_CustomerId",
                table: "EntryRecords");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "EntryRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
