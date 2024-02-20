using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Hicks.Migrations
{
    /// <inheritdoc />
    public partial class Version5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }
    }
}
