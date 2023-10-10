using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hold.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnTexturetoProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Texture path",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Texture path",
                table: "Products");
        }
    }
}
