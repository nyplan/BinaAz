using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemNumber = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    SettlementId = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    RelevantPerson = table.Column<string>(type: "text", nullable: false),
                    IsAgent = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<int>(type: "integer", nullable: false),
                    SaleOrRentId = table.Column<int>(type: "integer", nullable: false),
                    Extract = table.Column<bool>(type: "boolean", nullable: true),
                    Mortgage = table.Column<bool>(type: "boolean", nullable: true),
                    DayOrMonthId = table.Column<int>(type: "integer", nullable: true),
                    Repair = table.Column<bool>(type: "boolean", nullable: true),
                    CountOfRoom = table.Column<int>(type: "integer", nullable: true),
                    Floor = table.Column<int>(type: "integer", nullable: true),
                    CountOfFloor = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PlotOfLand = table.Column<int>(type: "integer", nullable: true),
                    TypeOfBuildingId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_EnumValues_DayOrMonthId",
                        column: x => x.DayOrMonthId,
                        principalTable: "EnumValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_EnumValues_SaleOrRentId",
                        column: x => x.SaleOrRentId,
                        principalTable: "EnumValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_EnumValues_TypeOfBuildingId",
                        column: x => x.TypeOfBuildingId,
                        principalTable: "EnumValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_CityId",
                table: "Items",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DayOrMonthId",
                table: "Items",
                column: "DayOrMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DistrictId",
                table: "Items",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SaleOrRentId",
                table: "Items",
                column: "SaleOrRentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SettlementId",
                table: "Items",
                column: "SettlementId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeOfBuildingId",
                table: "Items",
                column: "TypeOfBuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageItem");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
