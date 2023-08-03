using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addSettlementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Settlements",
                columns: new[] { "Id", "DistrictId", "Name" },
                values: new object[,]
                {
                    { 1, 7, "Boyukshor" },
                    { 2, 1, "Yasamal" },
                    { 3, 1, "Yeni Yasamal" },
                    { 4, 5, "8-ci kilometr" },
                    { 5, 5, "Keshle" },
                    { 6, 6, "Kubinka" },
                    { 7, 6, "1-ci Mikrorayon" },
                    { 8, 6, "2-ci Mikrorayon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_DistrictId",
                table: "Settlements",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settlements");
        }
    }
}
