using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T2_JulianaLeite.Data.Migrations
{
    /// <inheritdoc />
    public partial class Autocaravanista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome_JL",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome_JL",
                table: "AspNetUsers");
        }
    }
}
