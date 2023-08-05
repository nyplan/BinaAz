using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsResidentialComplex",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelevantPerson",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsResidentialComplex",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RelevantPerson",
                table: "Users");
        }
    }
}
