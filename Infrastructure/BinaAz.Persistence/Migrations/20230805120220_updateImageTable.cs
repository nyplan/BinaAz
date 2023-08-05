using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageItem");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ItemNumber",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ImageItem",
                columns: table => new
                {
                    ImagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageItem", x => new { x.ImagesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ImageItem_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageItem_ItemsId",
                table: "ImageItem",
                column: "ItemsId");
        }
    }
}
