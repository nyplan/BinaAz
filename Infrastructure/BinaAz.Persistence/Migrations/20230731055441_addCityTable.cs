using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Baki" },
                    { 2, "Sumqayit" },
                    { 3, "Zaqatala" },
                    { 4, "Astara" },
                    { 5, "Yevlax" },
                    { 6, "Ucar" },
                    { 7, "Berde" },
                    { 8, "Cebrayil" },
                    { 9, "Qazax" },
                    { 10, "Quba" },
                    { 11, "Ismayilli" },
                    { 12, "Siyezen" },
                    { 13, "Tovuz" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
