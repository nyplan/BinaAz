using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_EnumValues_DayOrMonthId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_EnumValues_SaleOrRentId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_EnumValues_TypeOfBuildingId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "EnumValues");

            migrationBuilder.DropTable(
                name: "EnumKeys");

            migrationBuilder.DropIndex(
                name: "IX_Items_DayOrMonthId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SaleOrRentId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TypeOfBuildingId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SaleOrRentId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TypeOfBuildingId",
                table: "Items",
                newName: "TypeOfBuilding");

            migrationBuilder.RenameColumn(
                name: "DayOrMonthId",
                table: "Items",
                newName: "SaleOrRent");

            migrationBuilder.AddColumn<int>(
                name: "DayOrMonth",
                table: "Items",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOrMonth",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TypeOfBuilding",
                table: "Items",
                newName: "TypeOfBuildingId");

            migrationBuilder.RenameColumn(
                name: "SaleOrRent",
                table: "Items",
                newName: "DayOrMonthId");

            migrationBuilder.AddColumn<int>(
                name: "SaleOrRentId",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EnumKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnumValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KeyId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnumValues_EnumKeys_KeyId",
                        column: x => x.KeyId,
                        principalTable: "EnumKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_DayOrMonthId",
                table: "Items",
                column: "DayOrMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SaleOrRentId",
                table: "Items",
                column: "SaleOrRentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeOfBuildingId",
                table: "Items",
                column: "TypeOfBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumValues_KeyId",
                table: "EnumValues",
                column: "KeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_EnumValues_DayOrMonthId",
                table: "Items",
                column: "DayOrMonthId",
                principalTable: "EnumValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_EnumValues_SaleOrRentId",
                table: "Items",
                column: "SaleOrRentId",
                principalTable: "EnumValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_EnumValues_TypeOfBuildingId",
                table: "Items",
                column: "TypeOfBuildingId",
                principalTable: "EnumValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
