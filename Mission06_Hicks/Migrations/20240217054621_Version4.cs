using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Hicks.Migrations
{
    /// <inheritdoc />
    public partial class Version4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Movies");
        }
    }
}
