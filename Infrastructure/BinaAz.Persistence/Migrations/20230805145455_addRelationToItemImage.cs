using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRelationToItemImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemNumber",
                table: "Items",
                column: "ItemNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ItemId",
                table: "Images",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Items_ItemId",
                table: "Images",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Items_ItemId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemNumber",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Images_ItemId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Images");
        }
    }
}
