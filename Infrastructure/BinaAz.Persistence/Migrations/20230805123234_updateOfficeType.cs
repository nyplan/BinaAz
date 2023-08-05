using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateOfficeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfBuilding",
                table: "Items",
                newName: "TypeOfOffice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfOffice",
                table: "Items",
                newName: "TypeOfBuilding");
        }
    }
}
