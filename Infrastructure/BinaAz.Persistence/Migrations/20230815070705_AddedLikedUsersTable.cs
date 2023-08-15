using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedLikedUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsAgency",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemUser",
                columns: table => new
                {
                    LikedId = table.Column<Guid>(type: "uuid", nullable: false),
                    LikedUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUser", x => new { x.LikedId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_ItemUser_Items_LikedId",
                        column: x => x.LikedId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemUser_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemUser_LikedUsersId",
                table: "ItemUser",
                column: "LikedUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemUser");

            migrationBuilder.DropColumn(
                name: "IsAgency",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
